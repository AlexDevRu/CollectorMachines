using System.Collections.Generic;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Calculate.xaml
    /// </summary>
    public partial class Calculate : UserControl
    {
        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "a", "а – число параллельных ветвей" },
                { "p", "р – число главных магнитных полюсов" },
                { "K", "К – число коллекторных пластин" },
            };

        public Calculate(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            formula1.Content = FormulaParser.Parse("y<sub>ур</sub>|=|{[K]}{[a]}|=|{[K]}{[p]}", 30, tooltips, false);
            formula2.Content = FormulaParser.Parse("N<sub>ур</sub>|=|{[K]}{[a]}", 30, tooltips, false);
        }
    }
}