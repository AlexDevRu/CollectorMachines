using System.Windows.Controls;

namespace Коллекторные_машины.Section112
{
    /// <summary>
    /// Логика взаимодействия для Item10.xaml
    /// </summary>
    public partial class Item10 : UserControl
    {
        public Item10(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }
    }
}