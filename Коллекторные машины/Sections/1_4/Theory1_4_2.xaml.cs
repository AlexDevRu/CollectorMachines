using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_4_2.xaml
    /// </summary>
    public partial class Theory1_4_2 : Page
    {
        const string prefix = "1_4/1_4_2/";

        public Theory1_4_2()
        {
            InitializeComponent();

            root.AddChilds(new List<Node> { l21, l22 });
            l21.AddChilds(new List<Node> { l31, l32, l33 });
            l22.AddChilds(new List<Node> { l34, l35, l36, l37, l38 });
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_4_1());
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
    }
}