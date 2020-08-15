using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_2.xaml
    /// </summary>
    public partial class Algorithm1_2 : UserControl
    {
        public Algorithm1_2()
        {
            InitializeComponent();

            l1.Title = "Записать условие задачи";
            l2.Title = "Определить первый шаг:<LineBreak/><LineBreak/>" +
                       "<formula>y<sub>1</sub>|=|{[Z<sub>1</sub>]}{[2p]}</formula>";

            l3.Title = "Рассчитать число пазов на полюс и фазу:<LineBreak/><LineBreak/>" +
                       "<formula>q<sub>1</sub>|=|{[Z<sub>1</sub>]}{[2p][m<sub>1</sub>]}</formula>";

            l4.Title = "Определить пазовый угол:<LineBreak/><LineBreak/>" +
                       "<formula>γ|=|{[360]}{[Z<sub>1</sub>]}</formula>";

            l5.Title = "Определить сдвиг начал обмоток фаз:<LineBreak/><LineBreak/>" +
                       "<formula>λ|=|{[120]}{[γ]}</formula>";

            l6.Title = "Начертить развернутую схему трехфазной обмотки статора";

            l1.AddChilds(new List<Node> { l2 });
            l2.AddChilds(new List<Node> { l3 });
            l3.AddChilds(new List<Node> { l4 });
            l4.AddChilds(new List<Node> { l5 });
            l5.AddChilds(new List<Node> { l6 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }
    }
}
