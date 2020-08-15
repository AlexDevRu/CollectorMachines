using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для TextWithImage.xaml
    /// </summary>
    public partial class TextWithImage : UserControl
    {
        public TextWithImage(Grid grid1, string text, string img, Dictionary<string, object> tooltips = null, int size = 20, bool stretch = false)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid1.Children.Remove(this);
            image.Source = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Sections/" + img));
            image_grid.MouseDown += (ss, ee) =>
            {
                if (Grid.GetRow(image_grid) == 1)
                    Base.IncreaseImage(image_grid, 3, 5);
                else
                    Base.ReduceImage(image_grid, 1, 1);
            };

            TextBlock s = Helpers.GetFormattedText(text, size, tooltips);
            content.Inlines.Add(s);
            if (stretch)
            {
                grid.ColumnDefinitions[0].Width = new GridLength(0.2, GridUnitType.Star);
                int count = grid.ColumnDefinitions.Count;
                grid.ColumnDefinitions[count - 1].Width = new GridLength(50);
                notebook.Stretch = System.Windows.Media.Stretch.Fill;
                close.HorizontalAlignment = HorizontalAlignment.Right;
            } 
        }
    }
}