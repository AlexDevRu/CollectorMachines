using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_7_1.xaml
    /// </summary>
    public partial class Theory1_7_1 : Page
    {
        const string prefix = "1_7/1_7_1/";

        Dictionary<string, object> tooltips8 = new Dictionary<string, object>()
            {
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "Ф","магнитный поток" },
                { "n","частота вращения якоря" },
            };

        public Theory1_7_1()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22, l23, l24 });
            l21.AddChilds(new List<Node> { l31, l32 });
            l22.AddChilds(new List<Node> { l33, l34 });
            l23.AddChilds(new List<Node> { l35, l36, l37 });

            l35.MouseDown += (s,e) => grid.Children.Add(new OutputCharacteristic(grid));

            i23.ToolTips = tooltips8;
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
            Base.frame.Navigate(new Theory1_7_2());
        }
    }
}