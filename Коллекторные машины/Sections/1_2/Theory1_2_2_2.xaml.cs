using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_2_2_2.xaml
    /// </summary>
    public partial class Theory1_2_2_2 : Page
    {
        const string prefix = "1_2/1_2_2/";

        public Theory1_2_2_2()
        {
            InitializeComponent();
            root.AddChilds(new List<Node>() { l21, l22 });
            l21.AddChilds(new List<Node>() { l31, l32 });
            l31.AddChilds(new List<Node>() { l42 });
            l32.AddChilds(new List<Node>() { l41 });
            l41.AddChilds(new List<Node>() { l53 });
            l42.AddChilds(new List<Node>() { l51, l52 });
            l52.AddChilds(new List<Node>() { l61 });
            l61.AddChilds(new List<Node>() { l71 });
            l71.AddChilds(new List<Node>() { l81, l82 });

            l53.MouseDown += (sender, e) => grid.Children.Add(new AreaApplication(grid));
            l82.MouseDown += (sender, e) => grid.Children.Add(new Calculate(grid));
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

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_3());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_1());
        }

        private void PrevPart(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_2_1());
        }
    }
}