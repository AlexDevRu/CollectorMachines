using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_2_1.xaml
    /// </summary>
    public partial class Theory1_2_1 : Page
    {
        const string prefix = "1_2/1_2_1/";

        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "y<sub>1</sub>","у<sub>1</sub> – первый частичный шаг" },
                { "y<sub>2</sub>","у<sub>2</sub> – второй частичный шаг" },
                { "y","у – результирующий шаг" },
                { "y<sub>к</sub>","у<sub>к</sub> – шаг обмотки по коллектору" },
                { "Z<sub>эл</sub>","Z<sub>эл</sub> – число пазов" },
                { "b","b – число, которое отнимают или иногда добавляют к Z<sub>эл</sub>, чтобы при делении у было целым числом" },
                { "2p","2р – число полюсов" },
                { "p","2р – число полюсов" },
                { "2a","2а – число параллельных ветвей" },
            };


        public Theory1_2_1()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22, l23, l24, l25, l26 });
            l21.AddChilds(new List<Node> { l31, l32 });
            l26.AddChilds(new List<Node> { l33, l34 });

            l25.MouseDown += (sender, e) => grid.Children.Add(new WindingParams(grid));
            iroot1.MouseDown += (sender, e) => grid.Children.Add(new Section121.Item1(grid));
            iroot2.MouseDown += (sender, e) => grid.Children.Add(new Algorithm(grid));
            l24.MouseDown += (sender, e) => grid.Children.Add(new Anchors(grid));
            l33.MouseDown += (sender, e) => grid.Children.Add(new SectionLoop(grid));
            l34.MouseDown += (sender, e) => grid.Children.Add(new SectionWave(grid));

            i211.ToolTips = tooltips;
            i221.ToolTips = tooltips;
            i231.ToolTips = tooltips;
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, 20, n.Name == "l31" || n.Name == "l32");
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_2_1());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_3());
        }
    }
}