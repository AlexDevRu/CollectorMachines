using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для OutputCharacteristic.xaml
    /// </summary>
    public partial class OutputCharacteristic : UserControl
    {
        public OutputCharacteristic(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }
    }
}