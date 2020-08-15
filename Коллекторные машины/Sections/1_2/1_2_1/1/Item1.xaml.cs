using System.Windows.Controls;

namespace Коллекторные_машины.Section121
{
    /// <summary>
    /// Логика взаимодействия для Item21.xaml
    /// </summary>
    public partial class Item1 : UserControl
    {
        public Item1(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            link.Click += (sender, e) => grid.Children.Add(new WindingParams(grid));

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
