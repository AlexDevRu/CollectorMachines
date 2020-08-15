using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_3_1.xaml
    /// </summary>
    public partial class Theory1_3_1 : Page
    {
        const string prefix = "1_3/1_3_1/";

        Dictionary<string, object> tooltips2 = new Dictionary<string, object>()
        {
            { "F","магнитодвижущая сила в магнитной цепи машины постоянного тока" },
            { "F<sub>δ</sub>","магнитное напряжение воздушных зазоров" },
            { "F<sub>z</sub>","магнитное напряжение зубцовых зон" },
            { "F<sub>п</sub>","магнитное напряжение сердечников полюсов" },
            { "F<sub>я</sub>","магнитное напряжение сердечника якоря" },
            { "F<sub>яр</sub>","магнитное напряжение ярма" },
        };

        Dictionary<string, object> tooltips8 = new Dictionary<string, object>()
        {
            { "F<sub>п</sub>","магнитное напряжение сердечников полюсов" },
            { "H<sub>п</sub>","напряженность магнитного поля в сердечнике полюса; определяется по кривой намагничивания стали по величине магнитной индукции В<sub>п</sub>, которая подсчитывается по формуле<LineBreak/><formula>В<sub>п</sub>|=|{[Ф<sub>п</sub>]}{[S<sub>п</sub>]}</formula><LineBreak/>Ф<sub>п</sub> - магнитный поток на участке, Вб<LineBreak/>S<sub>п</sub> - площадь поперечного сечения участка, м²" },
        };

        Dictionary<string, object> tooltips9 = new Dictionary<string, object>()
        {
            { "H<sub>δ</sub>","напряженность магнитного поля в воздушном зазоре, А/м" },
            { "B<sub>δ</sub>","магнитная индукция в воздушном зазоре Тл" },
            { "δ","воздушный зазор, м" },
            { "μ<sub>0</sub>","μ<sub>0</sub>=4π·10⁻⁷ – магнитная постоянная, Гн/м" },
            { "K<sub>δ</sub>","коэффициент зазора, учитывающий увеличение магнитного сопротивления вследствие зубчатой поверхности якоря (К<sub>δ</sub> = 1,15 — 1,3)" },
        };

        Dictionary<string, object> tooltips10 = new Dictionary<string, object>()
        {
            { "H<sub>z</sub>","напряженность магнитного поля в зубцовом слое; определяется по кривой намагничивания стали по величине магнитной индукции, которая подсчитывается по формуле<LineBreak/><formula>B<sub>z</sub>|=|{[Ф<sub>z</sub>]}{[S<sub>z</sub>]}</formula><LineBreak/>Ф<sub>z</sub> - магнитный поток на участке, Вб<LineBreak/>S<sub>z</sub> - площадь поперечного сечения участка, м²" },
        };

        Dictionary<string, object> tooltips11 = new Dictionary<string, object>()
        {
            { "H<sub>я</sub>","напряженность магнитного поля в спинке якоря; определяется по кривой намагничивания стали по величине магнитной индукции В<sub>я</sub>, которая подсчитывается по формуле<LineBreak/><formula>B<sub>я</sub>|=|{[Ф<sub>я</sub>]}{[S<sub>я</sub>]}</formula><LineBreak/>Ф<sub>я</sub> -  магнитный поток на участке, Вб<LineBreak/>S<sub>я</sub> - площадь поперечного сечения участка, м²" },
        };

        Dictionary<string, object> tooltips12 = new Dictionary<string, object>()
        {
            { "H<sub>яр</sub>","напряженность магнитного поля в ярме; определяется по кривой намагничивания стали по величине магнитной индукции В<sub>яр</sub>, которая подсчитывается по формуле<LineBreak/><formula>B<sub>яр</sub>|=|{[Ф<sub>яр</sub>]}{[S<sub>яр</sub>]}</formula><LineBreak/>Ф<sub>яр</sub> -  магнитный поток на участке, Вб<LineBreak/>S<sub>яр</sub> - площадь поперечного сечения участка, м²" },
        };

        public Theory1_3_1()
        {
            InitializeComponent();

            l1.AddChilds(new List<Node> { l2, l3, l4, l5, l6, l7 });
            l7.AddChilds(new List<Node> { l8, l9, l10, l11, l12 });
            l2.AddChilds(new List<Node> { l8 });
            l3.AddChilds(new List<Node> { l9 });
            l4.AddChilds(new List<Node> { l10 });
            l5.AddChilds(new List<Node> { l11 });
            l6.AddChilds(new List<Node> { l12 });

            il1.MouseDown += (sender, e) => grid.Children.Add(new Plots(grid));

            il7.ToolTips = tooltips2;
            l8.ToolTips = tooltips8;
            l9.ToolTips = tooltips9;
            l10.ToolTips = tooltips10;
            l11.ToolTips = tooltips11;
            l12.ToolTips = tooltips12;
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_3_2());
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);

            line.Visibility = Visibility.Hidden;
            foreach (Node child in l7.Children)
                if (child.Visibility == Visibility.Visible)
                    line.Visibility = Visibility.Visible;
        }

        private bool IsAllChildrenHide(List<Node> nodes)
        {
            foreach (Node n in nodes)
                foreach (Node child in n.Children)
                    if (child.Visibility == Visibility.Visible)
                        return false;
            return true;
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            if (n.Name == "i372" || n.Name == "i373" || n.Name == "i374")
                Base.ShowInfo(n.Text, n.Image, grid, "1_2/1_2_1/", n.ToolTips, n.Size);
            else
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }
    }
}