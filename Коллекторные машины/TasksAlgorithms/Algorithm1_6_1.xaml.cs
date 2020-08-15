using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_6_1.xaml
    /// </summary>
    public partial class Algorithm1_6_1 : UserControl
    {
        public Algorithm1_6_1()
        {
            InitializeComponent();
            l1.Title = "Рассчитать ток в обмотке возбуждения в номинальном режиме:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>вном</sub>|=|{[U<sub>ном</sub>]}{[R<sub>в</sub>]}</formula>";

            l2.Title = "Рассчитать ток в обмотке якоря при номинальном режиме:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>яном</sub>|=|I<sub>ном</sub>|-|I<sub>в.ном</sub></formula>";

            l3.Title = "Рассчитать противоЭДС, индуктируемую в обмотке якоря, при номинальной скорости его вращения:<LineBreak/><LineBreak/>" +
                       "<formula>E<sub>ном</sub>|=|U<sub>ном</sub>|-|R<sub>я</sub>|I<sub>я.ном</sub></formula>";

            l31.Title = "Рассчитать скорость вращения якоря в режиме идеального холостого хода:<LineBreak/><LineBreak/>" +
                       "<formula>n<sub>0</sub>|=|{[U<sub>ном</sub>]}{[E<sub>я</sub>]}|n<sub>ном</sub></formula>";

            l4.Title = "Определить номинальную электромагнитную мощность:<LineBreak/><LineBreak/>" +
                       "<formula>Р<sub>эм.ном</sub>|=|E<sub>я</sub>|I<sub>я.ном</sub></formula>";

            l5.Title = "Определить вращающий электромагнитный момент двигателя при номинальном режиме:<LineBreak/><LineBreak/>" +
                       "<formula>M|=|{[9,55][Р<sub>эм.ном</sub>]}{[n<sub>ном</sub>]}</formula>";

            l1.AddChilds(new List<Node> { l2 });
            l2.AddChilds(new List<Node> { l3 });
            l3.AddChilds(new List<Node> { l31, l4 });
            l4.AddChilds(new List<Node> { l5 });
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Node node = sender as Node;
            Base.ShowChildren(node);
            Node n = node.Children[0];
            for (int i = 1; i < node.Children.Count; i++)
                if (Canvas.GetTop(node.Children[i]) > Canvas.GetTop(n))
                    n = node.Children[i];
            n.BringIntoView();
        }
    }
}