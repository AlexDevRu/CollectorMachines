using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Anchors.xaml
    /// </summary>
    public partial class Anchors : UserControl
    {
        DoubleAnimation imageAnimation;
        Dictionary<Span, Image> res;

        public Anchors(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);

            res = new Dictionary<Span, Image>
            {
                { y, iy },
                { y1, iy1 },
                { y2, iy2 },
                { yk, iyk }
            };

            imageAnimation = new DoubleAnimation();
            imageAnimation.From = 1;
            imageAnimation.To = 0;
            imageAnimation.Duration = TimeSpan.FromSeconds(0.8);
            imageAnimation.RepeatBehavior = RepeatBehavior.Forever;
            imageAnimation.AutoReverse = true;

            image_grid.MouseDown += (ss, ee) =>
            {
                if (Grid.GetRow(image_grid) == 1)
                    Base.IncreaseImage(image_grid, 3, 5);
                else
                    Base.ReduceImage(image_grid, 1, 1);
            };
        }

        private void BeginAnim(object sender, MouseEventArgs e)
        {
            res[sender as Span].BeginAnimation(OpacityProperty, imageAnimation);
        }

        private void EndAnim(object sender, MouseEventArgs e)
        {
            res[sender as Span].BeginAnimation(OpacityProperty, null);
        }
    }
}