using System.Collections.Generic;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для WindingParams.xaml
    /// </summary>
    public partial class WindingParams : UserControl
    {
        const string prefix = "1_2/1_2_1/6/";

        Dictionary<string, object> tooltips = new Dictionary<string, object>()
            {
                { "D", "D – диаметр якоря, м" },
                { "p", "р – число пар полюсов" }
            };

        public WindingParams(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
            link.Click += (sender, e) =>
            {
                grid.Children.Remove(this);
                grid.Children.Add(new TextWithImage(grid, Base.ReadFile(prefix + "text.txt"), prefix + "image.png", tooltips));
            };
        }
    }
}