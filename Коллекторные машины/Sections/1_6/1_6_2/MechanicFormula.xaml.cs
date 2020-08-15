using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для MechanicFormula.xaml
    /// </summary>
    public partial class MechanicFormula : UserControl
    {
        public MechanicFormula(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }
    }
}