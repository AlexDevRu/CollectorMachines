using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_3_2.xaml
    /// </summary>
    public partial class Theory1_3_2 : Page
    {
        const string prefix = "1_3/1_3_2/";

        public Theory1_3_2()
        {
            InitializeComponent();

            root.AddChilds(new List<Node> { l21, l22, l23 });
            l22.AddChilds(new List<Node> { l31, l32, l33, l34 });

            l21.MouseDown += (sender, e) => grid.Children.Add(new Mechanism(grid));
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_3_1());
        }
    }
}