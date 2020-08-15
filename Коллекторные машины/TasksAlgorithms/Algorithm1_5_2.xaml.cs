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
    /// Логика взаимодействия для Algorithm1_5_2.xaml
    /// </summary>
    public partial class Algorithm1_5_2 : UserControl
    {
        public Algorithm1_5_2()
        {
            InitializeComponent();

            l1.Title = "Записать условие задачи";
            l2.Title = "Рассчитать номинальный ток потребителя:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>ном</sub>|=|{[P<sub>ном</sub>]}{[U<sub>ном</sub>]}</formula>";

            l3.Title = "Рассчитать номинальный ток в обмотке возбуждения:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>вном</sub>|=|0,05|I<sub>я</sub></formula>";

            l4.Title = "Определить ЭДС:<LineBreak/><LineBreak/>" +
                       "<formula>Е|=|U<sub>ном</sub>|+|I<sub>ном</sub>|R<sub>я</sub></formula>";

            l5.Title = "Определить электромагнитный момент:<LineBreak/><LineBreak/>" +
                       "<formula>М|=|{[9,55][E][I<sub>ном</sub>]}{[n<sub>ном</sub>]}</formula>";

            l1.AddChilds(new List<Node> { l2 });
            l2.AddChilds(new List<Node> { l3, l4 });
            l4.AddChilds(new List<Node> { l5 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }
    }
}
