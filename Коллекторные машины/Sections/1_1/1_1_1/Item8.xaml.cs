using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Item8.xaml
    /// </summary>
    public partial class Item8 : UserControl
    {
        const string prefix = "1_1/1_1_1/9/";

        public Item8(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            link.Click += (sender, e) => grid.Children.Add(new TextWithImage(grid, Base.ReadFile(prefix + "text.txt"), prefix + "image.jpg"));

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