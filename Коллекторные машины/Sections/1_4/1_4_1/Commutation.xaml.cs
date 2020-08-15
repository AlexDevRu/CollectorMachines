using System.Collections.Generic;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Commutation.xaml
    /// </summary>
    public partial class Commutation : UserControl
    {
        Dictionary<string, object> tooltips = new Dictionary<string, object>()
        {
            { "b<sub>Щ</sub>", "ширина щетки" },
            { "b<sub>К</sub>", "расстояние между серединами соседних коллекторных пластин" },
            { "n", "частота вращения якоря, об/мин" },
            { "K", "число коллекторных пластин" },
        };

        public Commutation(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            formula1.Content = FormulaParser.Parse("T<sub>K</sub>|=|{[60]}{[K][n]}|{[b<sub>Щ</sub>]}{[b<sub>К</sub>]}", 30, tooltips, false);
            formula2.Content = FormulaParser.Parse("e<sub>S</sub>|=|L<sub>S</sub>|{[di]}{[dt]}", 30, null, false);
            formula3.Content = FormulaParser.Parse("e<sub>M</sub>|=|M<sub>S</sub>|{[di]}{[dt]}", 30, null, false);
        }
    }
}