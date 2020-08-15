using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_6_6.xaml
    /// </summary>
    public partial class Theory1_6_6 : Page
    {
        const string prefix = "1_6/1_6_6/";

        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "U", "U - напряжение, подводимое к двигателю" },
                { "n", "n - частота вращения двигателя" },
                { "M<sub>эм</sub>", "M<sub>эм</sub> - электромагнитный момент" },
                { "R<sub>Я</sub>", "R<sub>Я</sub> - сопротивление обмотки якоря" },
                { "R<sub>Д</sub>", "R<sub>Д</sub> - добавочное сопротивление в цепи якоря" },
                { "C<sub>E</sub>", "C<sub>E</sub> - конструктивный коэффициент ЭДС" },
                { "C<sub>M</sub>", "C<sub>M</sub> - конструктивный коэффициент момента" },
                { "Ф", "Ф - магнитный поток обмотки возбуждения" },
            };

        public Theory1_6_6()
        {
            InitializeComponent();

            root.AddChilds(new List<Node> { l21, l22, l23 });
            l21.AddChilds(new List<Node> { l31, l32, l33 });
            l22.AddChilds(new List<Node> { l34, l35, l36 });
            l23.AddChilds(new List<Node> { l37, l38, l39 });

            i372.MouseDown += (sender, e) => grid.Children.Add(new Way2(grid));
            i373.MouseDown += (sender, e) => grid.Children.Add(new Way3(grid));
            i332.MouseDown += (sender, e) => grid.Children.Add(new Specifications1(grid));
            i352.MouseDown += (sender, e) => grid.Children.Add(new Specifications2(grid));

            i341.ToolTips = tooltips;
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
            Base.frame.Navigate(new Theory1_6("Коллектроные двигатели постоянного тока параллельного возбуждения", "1_6/1_6_1/"));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_6_5());
        }
    }
}