using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для TestQuestion.xaml
    /// </summary>

    class MyTextBlock : TextBlock
    {
        public MyTextBlock(TextBlock text):base()
        {
            Inlines.Add(text);
        }

        public bool IsRight { get; set; }
        public bool IsFormula { get; set; } = false;
    }

    public partial class TestQuestion : Page
    {
        Variant[] answers;
        Action<bool> ShowResult;

        public TestQuestion(Question question_data, Action<bool> ShowResult)
        {
            InitializeComponent();

            if(question_data.Name != null)
            {
                TextBlock question = new TextBlock()
                {
                    FontSize = 40,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                };
                question.Text = question_data.Name;

                content.Children.Add(question);
            }
            if (question_data.Image != null)
            {
                Image image = new Image()
                {
                    Source = new BitmapImage(new Uri(question_data.Image)),
                    MaxWidth = question_data.Width,
                    Margin = new Thickness(0, 15, 0, 0)
                };
                content.Children.Add(image);
            }

            answers = question_data.Answers;
            this.ShowResult = ShowResult;
            foreach(var a in answers)
            {
                if (question_data.ManyAnswers)
                {
                    if(a.Text != null)
                    {
                        if(a.Text.Contains("<formula>"))
                        {
                            TextBlock formula = FormulaParser.Parse(Helpers.GetStringInTag("</formula>", a.Text), 30, null, false);
                            MyTextBlock myTextBlock = new MyTextBlock(formula) { IsRight = a.IsRight, IsFormula = true };
                            stackAnswers.Children.Add(new CheckBox() { Content = myTextBlock });
                        } 
                        else
                        {
                            TextBlock text = Helpers.GetFormattedText(a.Text, 30);
                            MyTextBlock myTextBlock = new MyTextBlock(text) { IsRight = a.IsRight };
                            stackAnswers.Children.Add(new CheckBox() { Content = myTextBlock });
                        }   
                    }    
                    else if(a.Image != null)
                        stackAnswers.Children.Add(new CheckBox() { Content = new Image() { MaxWidth = a.Width, Source = new BitmapImage(new Uri(a.Image)) } });
                }     
                else
                {
                    if (a.Text != null)
                    {
                        if (a.Text.Contains("<formula>"))
                        {
                            TextBlock formula = FormulaParser.Parse(Helpers.GetStringInTag("</formula>", a.Text), 30, null, false);
                            MyTextBlock myTextBlock = new MyTextBlock(formula) { IsRight = a.IsRight, IsFormula = true };
                            stackAnswers.Children.Add(new RadioButton() { GroupName = "variants", Content = myTextBlock });
                        }   
                        else
                        {
                            TextBlock text = Helpers.GetFormattedText(a.Text, 30);
                            MyTextBlock myTextBlock = new MyTextBlock(text) { IsRight = a.IsRight };
                            stackAnswers.Children.Add(new RadioButton() { GroupName = "variants", Content = myTextBlock });
                        }
                    }
                        
                    else if (a.Image != null)
                        stackAnswers.Children.Add(new RadioButton() { Content = new Image() { MaxWidth = a.Width, Source = new BitmapImage(new Uri(a.Image)), Margin = new Thickness(3) } });
                }   
            }
        }

        private bool SearchVariant(object obj)
        {
            if (obj is MyTextBlock)
                return (obj as MyTextBlock).IsRight;
            foreach (Variant variant in answers)
            {
                if(obj is Image && variant.Image == (obj as Image).Source.ToString())
                    return variant.IsRight;
            }        
            return false;
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            bool check = false;

            foreach (ToggleButton variant in stackAnswers.Children)
                if (variant.IsChecked == true) { check = true; break; }

            if(!check)
            {
                MessageBox.Show("Не отмечено ни одного варианта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool right = true;
            button_check.Visibility = Visibility.Collapsed;

            foreach(ToggleButton variant in stackAnswers.Children)
            {
                variant.IsEnabled = false;
                object obj = variant.Content;
                 
                if(variant.IsChecked == true)
                {
                    variant.Foreground = Brushes.White;

                    if (SearchVariant(obj))
                        variant.Background = Brushes.Green;
                    else
                    {
                        variant.Background = Brushes.Red;
                        right = false;
                    }

                    if (obj is MyTextBlock)
                    {
                        if ((obj as MyTextBlock).IsFormula)
                        {
                            TextBlock t = (obj as MyTextBlock).Inlines.Cast<InlineUIContainer>().ElementAt(0).Child as TextBlock;
                            StackPanel stack = t.Inlines.Cast<InlineUIContainer>().ElementAt(0).Child as StackPanel;
                            foreach (var child in stack.Children)
                            {
                                foreach (var c in (child as StackPanel).Children)
                                    if (c is Line)
                                        (c as Line).Stroke = Brushes.White;
                                    else if (c is TextBlock)
                                        (c as TextBlock).Foreground = Brushes.White;
                                    else if (c is StackPanel)
                                        foreach (TextBlock tc in (c as StackPanel).Children)
                                            tc.Foreground = Brushes.White;
                            }
                        }
                    }
                }

                if (variant.IsChecked == false && SearchVariant(obj))
                    right = false;
            }

            ShowResult(right);
        }
    }
}