using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Item14.xaml
    /// </summary>
    public partial class Item14 : UserControl
    {
        public Item14(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            link.Click += (s, e) =>
            {
                string str = System.IO.Directory.GetCurrentDirectory() + "\\Sections\\";
                System.Diagnostics.Process.Start(str + "1_1/1_1_2/16/flash.swf");
            };

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