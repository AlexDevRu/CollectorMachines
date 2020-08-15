using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для WindingAnchor.xaml
    /// </summary>
    public partial class WindingAnchor : UserControl
    {
        public WindingAnchor(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            image_grid.MouseDown += (ss, ee) =>
            {
                if (Grid.GetRow(image_grid) == 1)
                    Base.IncreaseImage(image_grid, 3, 5);
                else
                    Base.ReduceImage(image_grid, 1, 1);
            };
        }
    }
}