using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для SelfTasks.xaml
    /// </summary>

    public partial class SelfTasks : Page
    {
        class SelfTaskAnswer
        {
            [JsonProperty("letter")]
            public string Letter { get; set; }

            [JsonProperty("number")]
            public double Number { get; set; }

            [JsonProperty("unit")]
            public string Unit { get; set; }
        }

        class SameAnswers
        {
            [JsonProperty("numbers")]
            public List<double> Numbers { get; set; }

            [JsonProperty("unit")]
            public string Unit { get; set; }
        }

        class SelfTask
        {
            [JsonProperty("condition")]
            public string Condition { get; set; }

            [JsonProperty("answers")]
            public List<SelfTaskAnswer> Answers { get; set; }

            [JsonProperty("sameAnswers")]
            public List<SameAnswers> SameAnswers { get; set; }
        }

        class MyTextBox : NumericTextBox
        {
            public double Answer { get; set; }
        }

        class MyStackPanel : StackPanel
        {
            public List<double> Answers { get; set; }
        }

        List<SelfTask> Tasks;

        public SelfTasks(string json, Page example)
        {
            InitializeComponent();

            byte n = 1;

            Tasks = JsonConvert.DeserializeObject<List<SelfTask>>(Base.ReadFile(json));

            foreach(SelfTask task in Tasks)
            {
                TabItem tab = new TabItem();

                ScrollViewer scroll = new ScrollViewer();
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });

                Image background = new Image()
                {
                    Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/backgrounds/notebook_list.jpg")),
                    Stretch = Stretch.Fill
                };
                Grid.SetColumnSpan(background, 3);
                grid.Children.Add(background);

                TextBlock condition = Helpers.GetFormattedText(task.Condition, 30);
                condition.Margin = new Thickness(0, 0, 0, 20);

                Border border = new Border() { BorderThickness = new Thickness(4), CornerRadius = new CornerRadius(10) };
                StackPanel check_panel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 20),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                border.Child = check_panel;


                StackPanel textboxes = new StackPanel() { Margin = new Thickness(0, 0, 20, 0) };
                check_panel.Children.Add(textboxes);
                if(task.Answers != null)
                {
                    foreach(SelfTaskAnswer a in task.Answers)
                    {
                        StackPanel stack_textbox = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 0, 0, 10) };
                        MyTextBox tb = new MyTextBox()
                        {
                            FontSize = 30,
                            FontStyle = FontStyles.Italic,
                            Margin = new Thickness(0, 0, 10, 0),
                            Answer = a.Number,
                            MinWidth = 70,
                            FontFamily = new FontFamily("Cambria Math")
                        };

                        if(a.Letter != null) stack_textbox.Children.Add(Helpers.GetFormattedText(a.Letter, 30));
                        stack_textbox.Children.Add(tb);
                        stack_textbox.Children.Add(Helpers.GetFormattedText(a.Unit, 30));
                        textboxes.Children.Add(stack_textbox);
                    }
                }
                else if(task.SameAnswers != null)
                {
                    foreach(SameAnswers same in task.SameAnswers)
                    {
                        MyStackPanel stack_same_answers = new MyStackPanel() { Answers = same.Numbers };
                        textboxes.Children.Add(stack_same_answers);

                        foreach(double num in same.Numbers)
                        {
                            StackPanel stack_textbox = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 0, 0, 10) };
                            MyTextBox tb = new MyTextBox()
                            {
                                FontSize = 30,
                                FontStyle = FontStyles.Italic,
                                Margin = new Thickness(0, 0, 10, 0),
                                MinWidth = 70,
                                Answer = num,
                                FontFamily = new FontFamily("Cambria Math")
                            };

                            stack_textbox.Children.Add(tb);
                            stack_textbox.Children.Add(Helpers.GetFormattedText(same.Unit, 30));
                            stack_same_answers.Children.Add(stack_textbox);
                        }
                    }
                }

                Button check = new Button()
                {
                    Content = "Проверить ответ",
                    Padding = new Thickness(10),
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 20
                };
                check.Click += CheckAnswers;
                check_panel.Children.Add(check);

                StackPanel stack_anew = new StackPanel() { Margin = new Thickness(0, 20, 0, 0) };
                Button anew = new Button()
                {
                    Content = "Вернуться к примеру",
                    Padding = new Thickness(10),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 20
                };
                anew.Click += (s, e) => Base.frame.Navigate(example);
                stack_anew.Children.Add(anew);


                StackPanel stack = new StackPanel()
                {
                    MaxWidth = 900,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stack.Children.Add(condition);
                stack.Children.Add(border);
                stack.Children.Add(stack_anew);

                scroll.Content = stack;
                Grid.SetColumn(scroll, 1);
                grid.Children.Add(scroll);

                Button prev = new Button()
                {
                    Height = 90,
                    Width = 80,
                    Content = "<",
                    FontSize = 40,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetColumn(prev, 0);
                prev.Click += Prev;

                Button next = new Button()
                {
                    Height = 90,
                    Width = 80,
                    Content = ">",
                    FontSize = 40,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetColumn(next, 2);
                next.Click += Next;

                grid.Children.Add(prev);
                grid.Children.Add(next);

                tab.Content = grid;
                TextBlock header = new TextBlock()
                {
                    Text = "Задача " + (n++).ToString(),
                    FontSize = 20
                };
                tab.Header = header;
                tabs.Items.Add(tab);
            }
        }

        byte wrong = 0;

        private void CheckAnswers(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            StackPanel answers = (button.Parent as StackPanel).Children[0] as StackPanel;
            Border border = (button.Parent as StackPanel).Parent as Border;
            bool iswrong = false;

            foreach (var child in answers.Children)
            {
                if(child is MyStackPanel)
                {
                    List<double> numbers = new List<double>();
                    foreach(StackPanel stack in (child as MyStackPanel).Children)
                    {
                        MyTextBox textBox = stack.Children[0] as MyTextBox;
                        if(textBox.Text == "")
                        {
                            MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        numbers.Add(double.Parse(textBox.Text));
                    }
                    numbers.Sort();
                    (child as MyStackPanel).Answers.Sort();
                    bool right = true;
                    for(int i = 0; i < numbers.Count; i++)
                        if(numbers[i] != (child as MyStackPanel).Answers[i])
                        {
                            right = false; break;
                        }

                    if (right)
                    {
                        border.BorderBrush = Brushes.Green;
                        foreach (StackPanel stack in (child as MyStackPanel).Children)
                            (stack.Children[0] as MyTextBox).IsReadOnly = true;

                        StackPanel check_panel = button.Parent as StackPanel;
                        if (check_panel.Children.Count == 3)
                            (check_panel.Children[2] as Image).Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/icons/right.png"));
                        else
                            AddIcon(@"pack://application:,,,/GlobalResources/icons/right.png", check_panel);
                    }
                    else
                    {
                        if (!iswrong) { ++wrong; iswrong = true; }
                        if (wrong == 3)
                        {
                            border.BorderBrush = Brushes.Green;
                            foreach (StackPanel stack in (child as MyStackPanel).Children)
                            {
                                MyTextBox my = stack.Children[0] as MyTextBox;
                                my.Text = my.Answer.ToString();
                                my.IsReadOnly = true;
                            }
                            button.IsEnabled = false;

                            StackPanel check_panel = button.Parent as StackPanel;
                            if (check_panel.Children.Count == 3)
                                (check_panel.Children[2] as Image).Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/icons/right.png"));
                            else
                                AddIcon(@"pack://application:,,,/GlobalResources/icons/right.png", check_panel);
                        }
                        else
                        {
                            border.BorderBrush = Brushes.Red;

                            StackPanel check_panel = button.Parent as StackPanel;
                            if (check_panel.Children.Count == 2)
                                AddIcon(@"pack://application:,,,/GlobalResources/icons/wrong.png", check_panel);
                        }
                            
                    }
                }
                else
                {
                    MyTextBox myTextBox = (child as StackPanel).Children[0] as MyTextBox;
                    if (myTextBox == null) myTextBox = (child as StackPanel).Children[1] as MyTextBox;
                    if (myTextBox.Text == "")
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (double.Parse(myTextBox.Text) == myTextBox.Answer)
                    {
                        border.BorderBrush = Brushes.Green;
                        myTextBox.IsReadOnly = true;

                        StackPanel check_panel = button.Parent as StackPanel;
                        if (check_panel.Children.Count == 3)
                            (check_panel.Children[2] as Image).Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/icons/right.png"));
                        else
                            AddIcon(@"pack://application:,,,/GlobalResources/icons/right.png", check_panel);
                    }
                    else
                    {
                        if (!iswrong) { ++wrong; iswrong = true; }
                        if (wrong == 3)
                        {
                            border.BorderBrush = Brushes.Green;
                            myTextBox.Text = myTextBox.Answer.ToString();
                            myTextBox.IsReadOnly = true;
                            button.IsEnabled = false;

                            StackPanel check_panel = button.Parent as StackPanel;
                            if (check_panel.Children.Count == 3)
                                (check_panel.Children[2] as Image).Source = new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/icons/right.png"));
                            else
                                AddIcon(@"pack://application:,,,/GlobalResources/icons/right.png", check_panel);
                        }
                        else
                        {
                            border.BorderBrush = Brushes.Red;

                            StackPanel check_panel = button.Parent as StackPanel;
                            if (check_panel.Children.Count == 2)
                                AddIcon(@"pack://application:,,,/GlobalResources/icons/wrong.png", check_panel);
                        }
                            
                    }
                }
            }
        }

        private void AddIcon(string url, StackPanel stack)
        {
            stack.Children.Add(new Image()
            {
                Source = new BitmapImage(new Uri(url)),
                Margin = new Thickness(30, 0, 0, 0),
                Width = 50,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center
            });
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            wrong = 0;
            tabs.SelectedIndex = tabs.SelectedIndex == tabs.Items.Count - 1 ? 0 : ++tabs.SelectedIndex;
        }

        private void Prev(object sender, RoutedEventArgs e)
        {
            wrong = 0;
            tabs.SelectedIndex = tabs.SelectedIndex == 0 ? tabs.Items.Count - 1 : --tabs.SelectedIndex;
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wrong = 0;
        }
    }
}