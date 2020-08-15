using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_6.xaml
    /// </summary>
    public partial class Theory1_6 : Page
    {
        readonly string prefix;
        Page next, prev;

        public Theory1_6(string name, string p)
        {
            InitializeComponent();
            prefix = p;
            root.Title = name;
        }

        Dictionary<string, object> tooltips8 = new Dictionary<string, object>()
            {
                { "U","напряжение, подводимое к двигателю" },
                { "n","частота вращения двигателя" },
                { "I<sub>Я</sub>","сила тока в цепи якоря" },
                { "R<sub>Я</sub>","сопротивление обмотки якоря" },
                { "R<sub>доб</sub>","добавочное сопротивление в цепи якоря" },
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "Ф<sub>1</sub>","магнитные потоки параллельной и последовательной обмоток возбуждения" },
                { "Ф<sub>2</sub>","магнитные потоки параллельной и последовательной обмоток возбуждения" },
            };

        Dictionary<string, object> tooltips17 = new Dictionary<string, object>()
            {
                { "U","напряжение, подводимое к двигателю" },
                { "n","частота вращения двигателя" },
                { "M<sub>эм</sub>","электромагнитный момент" },
                { "R<sub>Я</sub>","сопротивление обмотки якоря" },
                { "R<sub>Д</sub>","добавочное сопротивление в цепи якоря" },
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "C<sub>M</sub>","конструктивный коэффициент момента" },
                { "Ф","магнитный поток обмотки возбуждения" },
            };

        Dictionary<string, object> tooltips19 = new Dictionary<string, object>()
            {
                { "U","напряжение, подводимое к двигателю" },
                { "n","частота вращения двигателя" },
                { "I<sub>Я</sub>","сила тока в цепи якоря" },
                { "R<sub>Я</sub>","сопротивление обмотки якоря" },
                { "R<sub>Д</sub>","добавочное сопротивление в цепи якоря" },
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "C<sub>M</sub>","конструктивный коэффициент момента" },
                { "Ф","магнитный поток обмотки возбуждения" },
                { "n<sub>0</sub>","скорость идеального холостого хода<LineBreak/><formula>n<sub>0</sub>|=|{[U]}{[C<sub>E</sub>][Ф]}</formula>" },
                { "Δn","изменение частоты вращения ротора, вызванное падением напряжения в цепи якоря<LineBreak/><formula>Δn|=|{[(][R<sub>я</sub>][+][R<sub>д</sub>][)][I<sub>я</sub>]}{[C<sub>E</sub>][Ф]}</formula>" },
            };

        Dictionary<string, object> tooltips23 = new Dictionary<string, object>()
            {
                { "U","напряжение, подводимое к двигателю" },
                { "n","частота вращения двигателя" },
                { "I<sub>Я</sub>","сила тока в цепи якоря" },
                { "R<sub>Я</sub>","сопротивление обмотки якоря" },
                { "R<sub>Д</sub>","добавочное сопротивление в цепи якоря" },
                { "R<sub>ОВ</sub>","сопротивление обмотки возбуждения" },
                { "C<sub>E</sub>","конструктивный коэффициент ЭДС" },
                { "C<sub>M</sub>","конструктивный коэффициент момента" },
            };

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            root.AddChilds(new List<Node> { l21, l22, l23, l24 });
            l23.AddChilds(new List<Node> { l31, l32 });
            l31.AddChilds(new List<Node> { l41, l42 });
            l32.AddChilds(new List<Node> { l43, l44 });

            switch (prefix)
            {
                case "1_6/1_6_1/":
                    next = new Theory1_6("Коллекторные двигатели постоянного тока последовательного возбуждения", "1_6/1_6_2/");
                    prev = new Theory1_6_6();
                    forward.ToolTip = "Перейти к \"Коллекторные двигатели постоянного тока последовательного возбуждения\"";
                    back.ToolTip = "Перейти к \"Способы регулирования частоты вращения\"";
                    l21.Image = "11/image.png";
                    l22.Text = "13/text.txt";
                    l24.Text = "15/text.txt";
                    l41.Text = "17/text.txt";
                    l41.ToolTips = tooltips17;
                    l42.Text = "18/text.txt";
                    l42.Image = "18/image.png";
                    l43.Text = "19/text.txt";
                    l43.ToolTips = tooltips19;
                    l43.Size = 17;
                    l44.Text = "20/text.txt";
                    l44.Image = "20/image.png";
                    break;
                case "1_6/1_6_2/":
                    next = new Theory1_6("Коллекторные двигатели постоянного тока смешанного возбуждения", "1_6/1_6_3/");
                    prev = new Theory1_6("Коллекторные двигатели постоянного тока параллельного возбуждения", "1_6/1_6_1/");
                    forward.ToolTip = "Перейти к \"Коллекторные двигатели постоянного тока смешанного возбуждения\"";
                    back.ToolTip = "Перейти к \"Коллекторные двигатели постоянного тока параллельного возбуждения\"";
                    l21.Image = "12/image.png";
                    l22.Text = "14/text.txt";
                    l24.Text = "16/text.txt";
                    l41.MouseDown -= ShowInfo;
                    l42.MouseDown -= ShowInfo;
                    l41.MouseDown += (s1, e1) => grid.Children.Add(new MechanicFormula(grid));
                    l42.MouseDown += (s2, e2) => grid.Children.Add(new Mechanic(grid));
                    l43.Text = "23/text.txt";
                    l43.ToolTips = tooltips23;
                    l43.Size = 15;
                    l44.Text = "24/text.txt";
                    l44.Image = "24/image.png";
                    break;
                case "1_6/1_6_3/":
                    next = new Theory1_6_4();
                    prev = new Theory1_6("Коллекторные двигатели постоянного тока последовательного возбуждения", "1_6/1_6_2/");
                    forward.ToolTip = "Перейти к \"Режимы работы машины постоянного тока\"";
                    back.ToolTip = "Перейти к \"Коллекторные двигатели постоянного тока последовательного возбуждения\"";
                    l21.Image = "2/image.png";
                    l22.Text = "10/text.txt";
                    l24.Text = "3/text.txt";
                    l41.Text = "6/text.txt";
                    l42.MouseDown -= ShowInfo;
                    l42.MouseDown += (s1, e1) => grid.Children.Add(new Mechanic2(grid));
                    l43.Text = "8/text.txt";
                    l43.ToolTips = tooltips8;
                    l44.Text = "9/text.txt";
                    l44.Image = "9/image.png";
                    break;
            }
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(next);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(prev);
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            if(n.Name == "i31" || n.Name == "i32" || n.Name == "iroot")
                Base.ShowInfo(n.Text, n.Image, grid, "1_6/");
            else
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }
    }
}