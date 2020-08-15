using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для AdditionalMagneticPoles.xaml
    /// </summary>
    public partial class AdditionalMagneticPoles : UserControl
    {
        public AdditionalMagneticPoles(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            image.MouseDown += (ss, ee) =>
            {
                if (stack.Children.Contains(image))
                {
                    stack.Children.Remove(image);
                    image_grid.Children.Add(image);
                    image.Height = 800;
                    image_grid.Visibility = Visibility.Visible;
                }
                else
                {
                    image_grid.Children.Remove(image);
                    stack.Children.Insert(0, image);
                    image.Height = 200;
                    image_grid.Visibility = Visibility.Collapsed;
                }
            };

            viewbox.MouseDown += (ss, ee) =>
            {
                if (Grid.GetRow(viewbox) == 1)
                {
                    Grid.SetColumn(viewbox, 0);
                    Grid.SetRow(viewbox, 0);
                    Grid.SetRowSpan(viewbox, 3);
                    Grid.SetColumnSpan(viewbox, 5);
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