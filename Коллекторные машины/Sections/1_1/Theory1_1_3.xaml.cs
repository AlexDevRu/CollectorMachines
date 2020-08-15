using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_1_3.xaml
    /// </summary>
    public partial class Theory1_1_3 : Page
    {
        const string prefix = "1_1/1_1_3/";

        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "Ф","магнитный поток" },
                { "n","частота вращения якоря" },
            };

        public Theory1_1_3()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22 });
            l21.AddChilds(new List<Node> { l31, l32 });
            l22.AddChilds(new List<Node> { l33, l34 });
            l32.AddChilds(new List<Node> { l41 });
            l34.AddChilds(new List<Node> { l42 });

            i34.ToolTips = tooltips;

            i32.MouseDown += (s, e) => grid.Children.Add(new Generator(grid, tooltips));
            l31.MouseDown += (s, e) => grid.Children.Add(new Generator(grid, tooltips));
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            if(n.Name == "l41")
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size, true);
            else
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_1_1());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_1_2());
        }
    }
}