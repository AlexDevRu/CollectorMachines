using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Arrow.xaml
    /// </summary>
    public partial class Arrow : UserControl
    {
        public Arrow()
        {
            InitializeComponent();
        }

        public double Rotate
        {
            get { return (double)GetValue(RotateProperty); }
            set { SetValue(RotateProperty, value); }
        }
        public static readonly DependencyProperty RotateProperty =
            DependencyProperty.Register("Rotate", typeof(double), typeof(Arrow), new PropertyMetadata(0.0));




        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(Arrow), new FrameworkPropertyMetadata(Brushes.White));




        public double Length
        {
            get { return (double)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }
        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(double), typeof(Arrow), new PropertyMetadata(0.0));





        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }
        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(Arrow), new PropertyMetadata(7.0, ChangeY));

        private static void ChangeY(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Arrow arrow = (Arrow)d;
            double c = (double)e.NewValue * 1.428;
            arrow.Y = c;
            arrow.Point1 = new System.Windows.Point(0, c * 2);
            arrow.Point2 = new System.Windows.Point(c * 2, c);
        }





        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Arrow), new PropertyMetadata(10.0));





        public System.Windows.Point Point1
        {
            get { return (System.Windows.Point)GetValue(Point1Property); }
            set { SetValue(Point1Property, value); }
        }
        public static readonly DependencyProperty Point1Property =
            DependencyProperty.Register("Point1", typeof(System.Windows.Point), typeof(Arrow), new PropertyMetadata(new System.Windows.Point(0, 20)));


        public System.Windows.Point Point2
        {
            get { return (System.Windows.Point)GetValue(Point2Property); }
            set { SetValue(Point2Property, value); }
        }
        public static readonly DependencyProperty Point2Property =
            DependencyProperty.Register("Point2", typeof(System.Windows.Point), typeof(Arrow), new PropertyMetadata(new System.Windows.Point(20, 10)));
    }
}