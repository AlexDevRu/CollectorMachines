using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_6_4.xaml
    /// </summary>
    public partial class Theory1_6_4 : Page
    {
        const string prefix = "1_6/1_6_4/";

        public Theory1_6_4()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22, l23 });
            l22.AddChilds(new List<Node> { l31, l32, l33 });

            iroot1.MouseDown += (sender, e) => grid.Children.Add(new Modes(grid));
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
            Base.frame.Navigate(new Theory1_6_5());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_6("Коллектроные двигатели постоянного тока смешанного возбуждения", "1_6/1_6_3/"));
        }
    }
}