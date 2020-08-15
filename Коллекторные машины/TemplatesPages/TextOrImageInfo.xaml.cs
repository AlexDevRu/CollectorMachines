using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для TextOrImage.xaml
    /// </summary>
    public partial class TextOrImage : UserControl
    {
        public TextOrImage(Grid grid1, string data, bool istext = true, Dictionary<string,object> tooltips = null, int size = 20, bool stretch = false)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid1.Children.Remove(this);
            if (istext)
            {
                scroll.Visibility = Visibility.Visible;
                TextBlock s = Helpers.GetFormattedText(data, size, tooltips);
                content.Inlines.Add(s);
            }
            else
            {
                image.Source = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Sections/" + data));
                image_grid.MouseDown += (ss, ee) =>
                {
                    if (Grid.GetRow(image_grid) == 1)
                        Base.IncreaseImage(image_grid, 3, 3);
                    else
                        Base.ReduceImage(image_grid, 1, 1);
                };

                if (stretch)
                {
                    grid.ColumnDefinitions[0].Width = new GridLength(1.3, GridUnitType.Star);
                    grid.ColumnDefinitions[1].Width = new GridLength(4, GridUnitType.Star);
                    grid.ColumnDefinitions[2].Width = new GridLength(2, GridUnitType.Star);
                    list.Stretch = System.Windows.Media.Stretch.Fill;
                    image.Stretch = System.Windows.Media.Stretch.Fill;
                }
            }
        }
    }
}