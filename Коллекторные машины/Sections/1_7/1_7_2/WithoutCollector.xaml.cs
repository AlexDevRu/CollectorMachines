using System.Windows.Controls;
using System.Windows;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для WithoutCollector.xaml
    /// </summary>
    public partial class WithoutCollector : UserControl
    {
        public WithoutCollector(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            image1.MouseDown += (s1, e1) => IncreaseImage(image1, 1);
            image2.MouseDown += (s1, e1) => IncreaseImage(image2, 3);
            image3.MouseDown += (s1, e1) => IncreaseImage(image3, 5);
        }


        private void IncreaseImage(Image image, int index)
        {
            if (stack.Children.Contains(image))
            {
                stack.Children.Remove(image);
                image_grid.Children.Add(image);
                image_grid.Visibility = Visibility.Visible;
            }
            else
            {
                image_grid.Children.Remove(image);
                stack.Children.Insert(index, image);
                image_grid.Visibility = Visibility.Collapsed;
            }
        }
    }
}