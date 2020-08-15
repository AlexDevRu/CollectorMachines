using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Plots.xaml
    /// </summary>
    public partial class Plots : UserControl
    {
        public Plots(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            viewbox.MouseDown += (s, e) => IncreaseImage();
        }

        double width = 0;

        public void IncreaseImage()
        {
            
        }
    }
}