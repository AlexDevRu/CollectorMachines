using System.Windows.Controls;
using System.Windows.Media;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Specifications2.xaml
    /// </summary>
    public partial class Specifications2 : UserControl
    {
        public Specifications2(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            viewbox.MouseDown += (ss, ee) =>
            {
                if (Grid.GetRow(viewbox) == 1)
                {
                    Grid.SetColumn(viewbox, 0);
                    Grid.SetRow(viewbox, 0);
                    Grid.SetRowSpan(viewbox, 3);
                    Grid.SetColumnSpan(viewbox, 3);
                    canvas.Background = Brushes.White;
                }
                else
                {
                    Grid.SetColumn(viewbox, 1);
                    Grid.SetRow(viewbox, 1);
                    Grid.SetRowSpan(viewbox, 1);
                    Grid.SetColumnSpan(viewbox, 1);
                    canvas.Background = Brushes.Transparent;
                }
            };
        }
    }
}