using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_6_2.xaml
    /// </summary>
    public partial class Algorithm1_6_2 : UserControl
    {
        public Algorithm1_6_2()
        {
            InitializeComponent();

            l1.Title = "Рассчитать номинальную мощность двигателя:<LineBreak/><LineBreak/>" +
                       "<formula>P<sub>ном</sub>|=|{[M<sub>ном</sub>][n<sub>ном</sub>]}{[9,55]}</formula>";

            l2.Title = "Определить потребляемую мощность:<LineBreak/><LineBreak/>" +
                       "<formula>P<sub>1</sub>|=|{[P<sub>ном</sub>]}{[η]}</formula>";

            l3.Title = "Рассчитать ток якоря:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>я</sub> = I<sub>в</sub> =|{[P<sub>1</sub>]}{[U<sub>ном</sub>]}</formula>";

            l4.Title = "Определить противоЭДС обмоток якоря:<LineBreak/><LineBreak/>" +
                       "<formula>E<sub>я</sub>|=|U<sub>ном</sub>|-|I<sub>я</sub>|(|R<sub>я</sub>|+|R<sub>в</sub>|)</formula>";

            l5.Title = "Рассчитать электромагнитную мощность двигателя:<LineBreak/><LineBreak/>" +
                       "<formula>P<sub>эм</sub>|=|E<sub>я</sub>|I<sub>я</sub></formula>";

            l1.AddChilds(new List<Node> { l2 });
            l2.AddChilds(new List<Node> { l3 });
            l3.AddChilds(new List<Node> { l4 });
            l4.AddChilds(new List<Node> { l5 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }
    }
}