using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm1_6_5.xaml
    /// </summary>
    public partial class Algorithm1_6_5 : UserControl
    {
        public Algorithm1_6_5()
        {
            InitializeComponent();

            //t1.Inlines.Add(FormulaParser.Parse("P<sub>1</sub>|=|U<sub>ном</sub>|I<sub>ном</sub>", 30, null, false));

            l1.Title = "Рассчитать мощность, потребляемую двигателем при номинальной нагрузке:<LineBreak/>" +
                       "<formula>P<sub>1</sub>|=|U<sub>ном</sub>|I<sub>ном</sub></formula>";

            l2.Title = "Определить ток в обмотке возбуждения при номинальной нагрузке:<LineBreak/>" +
                       "<formula>I<sub>в</sub>|=|{[U<sub>ном</sub>]}{[R<sub>в</sub>]}</formula>";

            l3.Title = "Рассчитать номинальную мощность на валу двигателя:<LineBreak/>" +
                       "<formula>P<sub>ном</sub>|=|η|P<sub>1</sub></formula>";

            l4.Title = "Рассчитать величину добавочных потерь:<LineBreak/>" +
                       "<formula>P<sub>ном</sub>|=|0,01|P<sub>1</sub></formula>";

            l5.Title = "Рассчитать ток в обмотке якоря:<LineBreak/>" +
                       "<formula>I<sub>я</sub>|=|I<sub>ном</sub>|I<sub>в</sub></formula>";

            l6.Title = "Определить сумму потерь при номинальной нагрузке:<LineBreak/>" +
                       "<formula>ΣР|=|P<sub>1</sub>|-|P<sub>ном</sub></formula>";

            l7.Title = "Определить электрические потери в цепи якоря и обмотке возбуждения при номинальной нагрузке:<LineBreak/>" +
                       "<formula>Р<sub>э</sub> = I<sub>я</sub>²R<sub>я</sub> + I<sub>в</sub>²R<sub>в</sub></formula>";
            //<i>Р</i><si>мех</si><i> + Р</i><si>м</si><i> = ΣР – (Р</i><si>э</si><i> + Р</i><si>д</si><i>)</i>
            //I<sub>1</sub>|=|√75b|(75b|{[P<sub>мех</sub> + P<sub>м</sub>][+][P<sub>д</sub>][+][I<sub>в</sub>][<sup>2</sup>][R<sub>в</sub>]}{[R<sub>я</sub>]}|)75b
            l8.Title = "Определить механические и магнитные потери:<LineBreak/><LineBreak/>" +
                       "<formula>P<sub>мех</sub>+P<sub>м</sub>=ΣР-(P<sub>э</sub>+P<sub>д</sub>)</formula>";

            l9.Title = "Определить ток нагрузки при максимальном КПД:<LineBreak/><LineBreak/>" +
                       "<formula>I<sub>1</sub>|=|√50big|(50big|{[P<sub>мех</sub>+P<sub>м</sub>+P<sub>д</sub>+I<sub>в</sub>²R<sub>в</sub>]}{[R<sub>я</sub>]}|)50big</formula>";

            l10.Title = "Рассчитать максимальный КПД:<LineBreak/><LineBreak/>" +
                       "<formula>η<sub>max</sub> = 1|-|{[ΣР]}{[U(I<sub>1</sub>+I<sub>в</sub>)]}</formula>";

            l1.AddChilds(new List<Node> { l3 });
            l2.AddChilds(new List<Node> { l5 });
            l3.AddChilds(new List<Node> { l4, l6 });
            l4.AddChilds(new List<Node> { l8 });
            l5.AddChilds(new List<Node> { l7 });
            l6.AddChilds(new List<Node> { l8 });
            l7.AddChilds(new List<Node> { l8 });
            l8.AddChilds(new List<Node> { l9 });
            l9.AddChilds(new List<Node> { l10 });
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
