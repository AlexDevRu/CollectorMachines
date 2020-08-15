using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_5_1.xaml
    /// </summary>
    public partial class Theory1_5_1 : Page
    {
        const string prefix = "1_5/1_5_1/";

        public Theory1_5_1()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22 });
            l21.AddChilds(new List<Node> { l31, l32, l33, l34 });
            l22.AddChilds(new List<Node> { l35, l36, l37 });
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

        private void OpenImage(object sender, MouseButtonEventArgs e)
        {
            generator.Visibility = Visibility.Visible;
        }

        private void CloseImage(object sender, MouseButtonEventArgs e)
        {
            generator.Visibility = Visibility.Hidden;
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_5("Генератор постоянного тока независимого возбуждения", "1_5/1_5_2/"));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_5("Генератор постоянного тока смешанного возбуждения", "1_5/1_5_5/"));
        }
    }
}