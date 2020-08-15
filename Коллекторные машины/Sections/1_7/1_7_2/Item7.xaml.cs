using System.Windows.Controls;

namespace Коллекторные_машины.Section172
{
    /// <summary>
    /// Логика взаимодействия для Item7.xaml
    /// </summary>
    public partial class Item7 : UserControl
    {
        public Item7(Grid grid)
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