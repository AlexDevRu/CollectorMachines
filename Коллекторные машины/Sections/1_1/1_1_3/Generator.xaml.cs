using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Generator.xaml
    /// </summary>
    public partial class Generator : UserControl
    {
        public Generator(Grid grid, Dictionary<string, object> tooltips)
        {
            InitializeComponent();
            formula.Content = FormulaParser.Parse("Е|=|C<sub>E</sub>|Ф|n", 30, tooltips, false);
            close.Click += (sender, e) => grid.Children.Remove(this);
            video.slider.ValueChanged += TimeCode;
        }

        private void TimeCode(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue >= 46)
            {
                time1.Foreground = Brushes.Black;
                time2.Foreground = Brushes.Black;
                time3.Foreground = Brushes.Black;
                time4.Foreground = Brushes.Red;
                time4.BringIntoView();
            }
            else if (e.NewValue >= 28)
            {
                time1.Foreground = Brushes.Black;
                time2.Foreground = Brushes.Black;
                time3.Foreground = Brushes.Red;
                time4.Foreground = Brushes.Black;
                time3.BringIntoView();
            }
            else if (e.NewValue >= 22)
            {
                time1.Foreground = Brushes.Black;
                time2.Foreground = Brushes.Red;
                time3.Foreground = Brushes.Black;
                time4.Foreground = Brushes.Black;
                time2.BringIntoView();
            }
            else if (e.NewValue >= 10)
            {
                time1.Foreground = Brushes.Red;
                time2.Foreground = Brushes.Black;
                time3.Foreground = Brushes.Black;
                time4.Foreground = Brushes.Black;
                time1.BringIntoView();
            }
            else if (e.NewValue == 0)
            {
                time1.Foreground = Brushes.Black;
                time2.Foreground = Brushes.Black;
                time3.Foreground = Brushes.Black;
                time4.Foreground = Brushes.Black;
            }
        }
    }
}