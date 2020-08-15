using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Application.xaml
    /// </summary>
    public partial class AreaApplication : UserControl
    {
        const string prefix = "1_2/1_2_2/19/";

        public AreaApplication(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            link.Click += (sender, e) => grid.Children.Add(new TextOrImage(grid, Base.ReadFile(prefix + "text.txt")));
        }
    }
}