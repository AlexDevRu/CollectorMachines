using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_1_1.xaml
    /// </summary>
    public partial class Theory1_1_1 : Page
    {
        const string prefix = "1_1/1_1_1/";

        Dictionary<string, object> tooltips10 = new Dictionary<string, object>()
            {
                { "B","В - магнитная индукция внешнего магнитного поля" },
                { "I","I - сила тока в контуре" },
                { "S","S - площадь контура" },
                { "α","α - угол между направлением магнитного поля контура и направлением внешнего магнитного поля" },
            };
        Dictionary<string, object> tooltips2 = new Dictionary<string, object>()
            {
                { "e","е – заряд электрона" },
                { "υ", "υ - скорость движения электрона" },
                { "B","В - магнитная индукция внешнего магнитного поля" },
                { "α","α – угол между направлением движения проводника и направлением магнитного поля" },
                { "l", "l – длина проводника" }
            };

        public Theory1_1_1()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22 });
            l21.AddChilds(new List<Node> { l31, l32, l33 });
            l22.AddChilds(new List<Node> { l34, l35, l36, l37 });
            l33.AddChilds(new List<Node> { l41, l42, l43 });
            
            l34.MouseDown += (s, e) => grid.Children.Add(new Item8(grid));

            l31.ToolTips = tooltips2;
            l36.ToolTips = tooltips10;
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
            Base.frame.Navigate(new Theory1_1_2());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_1_3());
        }
    }
}