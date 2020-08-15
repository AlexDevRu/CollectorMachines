using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    /// 
    public class Answer
    {
        public Answer(int o, string t, string ra)
        {
            order = o;
            text = t;
            rightanswer = ra;
        }
        public int order;
        public string text;
        public string rightanswer;
    }

    class Formula
    {
        public string formula { get; set; }
        public int Order { get; set; }

        [JsonProperty("boxes")]
        public string Boxes { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("rightAnswer")]
        public double RightAnswer { get; set; }
    }

    class TaskData
    {
        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("given")]
        public List<string> Given { get; set; }

        [JsonProperty("determine")]
        public List<string> Determine { get; set; }

        [JsonProperty("text_formulas")]
        public List<string> TextFormulas { get; set; }

        [JsonProperty("formulas")]
        public List<Formula> FormulasList { get; set; }

        byte current = 0;
        public string GetCurrentText()
        {
            if (current < TextFormulas.Count)
            {
                string n = "<redBold>" + (current + 1).ToString() + ". </redBold>";
                TextFormulas[current] = n + TextFormulas[current];
                return TextFormulas[current++];
            }

            return null;
        }
    }

    class FormulaBorder : Border
    {
        public FormulaBorder()
        {
            Margin = new Thickness(0, 0, 0, 15);
            StackPanel container = new StackPanel() { Orientation = Orientation.Horizontal };
            Child = container;
        }

        private StackPanel GetStack() => Child as StackPanel;

        public Formula Formula { get; set; }
        public Action<bool, InputFields> Check { get; set; }

        public void AddFormulaBlock()
        {
            TextBlock formula = FormulaParser.Parse(Formula.formula, 35, null, false);
            formula.VerticalAlignment = VerticalAlignment.Center;
            GetStack().Children.Add(formula);
        }

        public void AddInputsBlock()
        {
            GetStack().Children.Add(new InputFields(Formula.Boxes, Check)
            {
                Unit = Formula.Unit,
                RightAnswer = Formula.RightAnswer,
                VerticalAlignment = VerticalAlignment.Center
            });
        }

        public void FormulasDrop()
        {
            StackPanel stack = GetStack();
            Margin = new Thickness(0, 0, 0, 15);

            if (stack.Children[stack.Children.Count - 1] is Image)
            {
                BorderBrush = Brushes.Transparent;
                Padding = new Thickness(0);
                CornerRadius = new CornerRadius(0);
                stack.Children.RemoveAt(2);
            }

            stack.Children.RemoveAt(1);
        }
            
        public void BrushBorder(STATUS status)
        {
            BorderThickness = new Thickness(4);
            Padding = new Thickness(10);
            CornerRadius = new CornerRadius(15);
            StackPanel stack = GetStack();

            if (status == STATUS.RIGHT)
            {
                BorderBrush = Brushes.Green;

                if (stack.Children.Count == 3)
                    (stack.Children[2] as Image).Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/icons/right.png"));
                else
                    AddIcon(@"pack://application:,,,/GlobalResources/icons/right.png");
            }
            else if(status == STATUS.WRONG)
            {
                BorderBrush = Brushes.Red;

                StackPanel stack1 = (stack.Children[1] as TextBlock).Inlines.Cast<InlineUIContainer>().ElementAt(0).Child as StackPanel;

                if (stack.Children.Count == 2)
                    AddIcon(@"pack://application:,,,/GlobalResources/icons/wrong.png");

                Width = stack.Width + 40;
            }
        }

        private void AddIcon(string url)
        {
            GetStack().Children.Add(new Image()
            {
                Source = new BitmapImage(new Uri(url)),
                Margin = new Thickness(30, 0, 0, 0),
                Width = 50,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center
            });
        }

        public enum STATUS { RIGHT, WRONG };
    }

    public partial class Task : Page
    {       
        string folder;
        UserControl algorithm;
        BitmapImage image;
        string ImageText;
        TaskData taskdata;

        public Task(string folder, UserControl algorithm, BitmapImage image, string ImageText)
        {
            InitializeComponent();
            this.folder = folder;
            this.algorithm = algorithm;
            this.image = image;
            this.ImageText = ImageText;

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Sections/" + folder + "self.json")) self_button.Visibility = Visibility.Collapsed;

            taskdata = JsonConvert.DeserializeObject<TaskData>(Base.ReadFile(folder + "task.json"));

            TextBlock cond = Helpers.GetFormattedText(taskdata.Condition, 20);
            condition.Content = cond;

            string given = string.Join("\n", taskdata.Given);
            condition_brief.Children.Insert(1, Helpers.GetFormattedText(given, 20));

            string determine = string.Join("\n", taskdata.Determine);
            condition_brief.Children.Add(Helpers.GetFormattedText(determine, 20));

            AddText();

            List<Border> formulas_blocks = new List<Border>();

            for (int i = 0; i < taskdata.FormulasList.Count; i++)
            {
                Formula f = taskdata.FormulasList[i];
                f.Order = i + 1;
                FormulaBorder border = new FormulaBorder() { Formula = f, Check = Check };
                border.AddFormulaBlock();
                border.MouseDown += Drag;
                formulas_blocks.Add(border);
            }

            Random random = new Random();
            for (int i = formulas_blocks.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = formulas_blocks[j];
                formulas_blocks[j] = formulas_blocks[i];
                formulas_blocks[i] = temp;
            }

            foreach (var t in formulas_blocks)
                formulas.Children.Add(t);
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            FormulaBorder formula = (FormulaBorder)sender;
            DataObject data = new DataObject(formula);
            DragDrop.DoDragDrop(formula.Parent, data, DragDropEffects.Move);
        }

        private void Area_Drop(object sender, DragEventArgs e)
        {
            FormulaBorder source = (FormulaBorder)e.Data.GetData(typeof(FormulaBorder));

            if (!area.Children.Contains(source))
            {
                var element = area.Children[area.Children.Count - 1];

                source.Margin = new Thickness(0, 10, 0, 25);
                source.HorizontalAlignment = HorizontalAlignment.Left;
                source.AddInputsBlock();
                formulas.Children.Remove(source);

                if(element is FormulaBorder)
                {
                    area.Children.Remove(element);
                    formulas.Children.Add(element);
                    (element as FormulaBorder).FormulasDrop();
                }

                area.Children.Add(source);
                source.BringIntoView();
            }
        }

        private void AddText()
        {
            string text = taskdata.GetCurrentText();
            if(text != null)
            {
                TextBlock textblock = Helpers.GetFormattedText(text);
                textblock.HorizontalAlignment = HorizontalAlignment.Left;
                textblock.MaxWidth = 700;
                area.Children.Add(textblock);
                textblock.BringIntoView();
            }  
            else
            {
                if(image != null)
                {
                    Image img = new Image() { Source = image, HorizontalAlignment = HorizontalAlignment.Center };
                    area.Children.Add(img);
                    img.BringIntoView();
                }
                if (ImageText != null)
                {
                    TextBlock textblock = Helpers.GetFormattedText(ImageText, 25);
                    textblock.FontWeight = FontWeights.Bold;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    area.Children.Add(textblock);
                    textblock.BringIntoView();
                }
                MessageBox.Show("Задача решена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void Formulas_Drop(object sender, DragEventArgs e)
        {
            FormulaBorder source = (FormulaBorder)e.Data.GetData(typeof(FormulaBorder));
            if (formulas.Children.Contains(source)) return;
            area.Children.Remove(source);

            source.FormulasDrop();
            
            formulas.Children.Add(source);
        }

        private void Check(bool right, InputFields inputs)
        {
            FormulaBorder border = (inputs.Parent as StackPanel).Parent as FormulaBorder;

            int index_area = area.Children.IndexOf(border);
            int order = 1;
            for (int i = 2; i < index_area; i += 2) ++order;

            if (right && order == border.Formula.Order)
            {
                inputs.LockFields();
                border.BrushBorder(FormulaBorder.STATUS.RIGHT);
                border.MouseDown -= Drag;
                AddText();
            }
            else
            {
                border.BrushBorder(FormulaBorder.STATUS.WRONG);
            }
        }

        private void SelfTasks(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new SelfTasks(folder + "self.json", this));
        }

        private void ShowAlgorithm(object sender, MouseButtonEventArgs e)
        {
            Window window = new Window() { WindowState = WindowState.Maximized, Title = "Алгоритм" };
            window.Content = algorithm;
            window.Owner = (Base.frame.Parent as Grid).Parent as Window;
            window.Show();
        }

        private void Anew(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Task(folder, algorithm, image, ImageText));
        }
    }
}