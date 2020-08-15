using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_5.xaml
    /// </summary>
    public partial class Theory1_5 : Page
    {
        readonly string prefix;
        Page next, prev;

        public Theory1_5(string name, string p)
        {
            InitializeComponent();
            prefix = p;
            root.Title = name;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            root.AddChilds(new List<Node> { l21, l22 });
            l22.AddChilds(new List<Node> { l32 });
            
            switch (prefix)
            {
                case "1_5/1_5_2/":
                    next = new Theory1_5("Генератор постоянного тока параллельного возбуждения", "1_5/1_5_3/");
                    prev = new Theory1_5_1();
                    forward.ToolTip = "Перейти к \"Генератор постоянного тока параллельного возбуждения\"";
                    back.ToolTip = "Перейти к \"Классификация генераторов постоянного тока, характеристики генераторов\"";
                    l31.Text = "hi1.txt";
                    l33.Text = "hi3.txt";
                    l31.Image = "hi1.png";
                    l33.Image = "hi3.png";
                    l22.Children.Add(l31);
                    l22.Children.Add(l33);
                    break;
                case "1_5/1_5_3/":
                    next = new Theory1_5("Генератор постоянного тока последовательного возбуждения", "1_5/1_5_4/");
                    prev = new Theory1_5("Генератор постоянного тока независимого возбуждения", "1_5/1_5_2/");
                    forward.ToolTip = "Перейти к \"Генератор постоянного тока последовательного возбуждения\"";
                    back.ToolTip = "Перейти к \"Генератор постоянного тока независимого возбуждения\"";
                    l31.Text = "hi1.txt";
                    l31.Image = "hi1.png";
                    l32.Text = "hi2.txt";
                    l32.Image = "hi2.png";
                    l33.Text = "hi3.txt";
                    l33.Image = "hi3.png";
                    l22.Children.Add(l31);
                    l22.Children.Add(l33);
                    break;
                case "1_5/1_5_4/":
                    l22.Children.Add(l31);
                    l31.Title = "Внешняя характеристика";
                    l32.Title = "Регулировочная характеристика";
                    l31.Text = "hi2.txt";
                    l31.Image = "hi2.png";
                    l32.Text = "hi3.txt";
                    l32.Image = null;
                    next = new Theory1_5("Генератор постоянного тока смешанного возбуждения", "1_5/1_5_5/");
                    prev = new Theory1_5("Генератор постоянного тока параллельного возбуждения", "1_5/1_5_3/");
                    forward.ToolTip = "Перейти к \"Генератор постоянного тока смешанного возбуждения\"";
                    back.ToolTip = "Перейти к \"Генератор постоянного тока параллельного возбуждения\"";
                    break;
                case "1_5/1_5_5/":
                    l22.Children.Remove(l32);
                    l22.Children.Add(l33);
                    l33.Title = "Внешняя характеристика";
                    l33.Text = "hi2.txt";
                    l33.Image = "hi2.png";
                    next = new Theory1_5_1();
                    prev = new Theory1_5("Генератор постоянного тока последовательного возбуждения", "1_5/1_5_4/");
                    forward.ToolTip = "Перейти к \"Классификация генераторов постоянного тока, характеристики генераторов\"";
                    back.ToolTip = "Перейти к \"Генератор постоянного тока последовательного возбуждения\"";
                    break;
            }
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            Base.ShowInfo(n.Text, n.Image, grid, prefix);
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(next);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(prev);
        }
    }
}