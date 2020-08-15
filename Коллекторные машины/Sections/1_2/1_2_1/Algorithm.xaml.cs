using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Algorithm.xaml
    /// </summary>
    public partial class Algorithm : UserControl
    {
        public Algorithm(Grid grid)
        {
            InitializeComponent();
            close.Click += (sender, e) => grid.Children.Remove(this);
        }

        private void ChangeTime(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (video.slider.Maximum == 1) return;

            Span span = sender as Span;

            switch(span.Name)
            {
                case "step1":
                    video.ChangeTime(0);
                    break;
                case "step2":
                    video.ChangeTime(39);
                    break;
                case "step3":
                    video.ChangeTime(84);
                    break;
                case "step4":
                    video.ChangeTime(95);
                    break;
                case "step5":
                    video.ChangeTime(100);
                    break;
            }
        }
    }
}