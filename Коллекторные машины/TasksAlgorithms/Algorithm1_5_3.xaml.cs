using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_5_3.xaml
    /// </summary>
    public partial class Algorithm1_5_3 : UserControl
    {
        public Algorithm1_5_3()
        {
            InitializeComponent();
            l1.Title = "Записать условие задачи";
            l2.Title = "Определить номинальный ток генератора:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>ном</sub>|=|{[P<sub>ном</sub>]}{[U<sub>ном</sub>]}</formula>";

            l3.Title = "Рассчитать ток обмотки возбуждения:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>в</sub>|=|{[U<sub>ном</sub>]}{[R<sub>в</sub>]}</formula>";

            l4.Title = "Определить ток якоря:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>я</sub>|=|I<sub>ном</sub>|+|I<sub>в</sub></formula>";

            l5.Title = "Рассчитать ЭДС обмотки якоря в номинальном режиме:<LineBreak/><LineBreak/>" +
                       "<formula>Е|=|U<sub>ном</sub>|+|I<sub>я</sub>|R<sub>я</sub></formula>";

            l1.AddChilds(new List<Node> { l2, l3 });
            l2.AddChilds(new List<Node> { l4 });
            l3.AddChilds(new List<Node> { l4 });
            l4.AddChilds(new List<Node> { l5 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }
    }
}