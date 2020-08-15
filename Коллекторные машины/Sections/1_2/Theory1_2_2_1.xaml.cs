using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_2_2.xaml
    /// </summary>
    public partial class Theory1_2_2_1 : Page
    {
        const string prefix = "1_2/1_2_2/";

        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "S", "S – число секций" },
                { "Z", "Z – число пазов" },
                { "a", "а – число параллельных ветвей" },
                { "ц.ч.", "ц.ч. – целое число" },
                { "p", "р – число главных магнитных полюсов" },
                { "m", "m – число простых обмоток в сложной обмотке" },
            };



        public Theory1_2_2_1()
        {
            InitializeComponent();

            root.AddChilds(new List<Node> { l21, l22, l23});
            l21.AddChilds(new List<Node> { l31, l32 });
            l22.AddChilds(new List<Node> { l33, l34 });
            l23.AddChilds(new List<Node> { l35, l36 });
            l36.AddChilds(new List<Node> { l41, l42 });

            l32.ToolTips = tooltips;
            l34.ToolTips = tooltips;
            l41.ToolTips = tooltips;
            l42.ToolTips = tooltips;
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

        private void NextPart(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_2_2());
        }
    }
}