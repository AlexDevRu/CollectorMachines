using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_2_3.xaml
    /// </summary>
    public partial class Algorithm1_2_3 : UserControl
    {
        public Algorithm1_2_3()
        {
            InitializeComponent();
            l1.Title = "Записать условие задачи";
            l2.Title = "Рассчитать постоянный коэффициент ЭДС:<LineBreak/><LineBreak/>" +
                       "<formula>C<sub>E</sub>|=|{[p][N]}{[60][a]}</formula>";

            l3.Title = "Рассчитать постоянный коэффициент электромагнитного момента:<LineBreak/><LineBreak/>" +
                       "<formula>C<sub>M</sub>|=|{[p][N]}{[2][π][a]}</formula>";

            l4.Title = "Определить ЭДС, индуцируемую в обмотке якоря:<LineBreak/><LineBreak/>" +
                       "<formula>E|=|C<sub>E</sub>|n<sub>ном</sub>|Ф</formula>";

            l5.Title = "Определить электромагнитный момент:<LineBreak/><LineBreak/>" +
                       "<formula>M|=|C<sub>M</sub>|Ф|I<sub>я</sub></formula>";

            l6.Title = "Записать ответ";

            l1.AddChilds(new List<Node> { l2, l3 });
            l2.AddChilds(new List<Node> { l4 });
            l3.AddChilds(new List<Node> { l5 });
            l4.AddChilds(new List<Node> { l6 });
            l5.AddChilds(new List<Node> { l6 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }
    }
}
