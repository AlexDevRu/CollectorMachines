using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Mechanism.xaml
    /// </summary>
    public partial class Mechanism : UserControl
    {
        public Mechanism(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }
    }
}