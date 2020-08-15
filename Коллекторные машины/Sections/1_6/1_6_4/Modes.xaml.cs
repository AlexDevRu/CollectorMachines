using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Modes.xaml
    /// </summary>
    public partial class Modes : UserControl
    {
        public Modes(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }
    }
}