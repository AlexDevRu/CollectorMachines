using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_7_2.xaml
    /// </summary>
    public partial class Theory1_7_2 : Page
    {
        const string prefix = "1_7/1_7_2/";

        public Theory1_7_2()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22, l23, l24 });
            l21.AddChilds(new List<Node> { l31 });
            l22.AddChilds(new List<Node> { l32, l33 });
            l31.AddChilds(new List<Node> { l41, l42 });
            l41.AddChilds(new List<Node> { l51, l52 });
            l42.AddChilds(new List<Node> { l53, l54 });

            i21.MouseDown += (s, e) => grid.Children.Add(new WithoutCollector(grid));
            i22.MouseDown += (s, e) => grid.Children.Add(new Section172.Item7(grid));
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;

            if(n.Name == "i22" || n.Name == "l33")
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size, true);
            else
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_7_1());
        }
    }
}