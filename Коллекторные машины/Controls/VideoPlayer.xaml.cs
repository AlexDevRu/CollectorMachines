using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {
        public VideoPlayer()
        {
            InitializeComponent();
            pause = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new Rectangle() { Fill=Brushes.White, Width=10, Height=45, Margin = new Thickness(5,0,5,0) },
                    new Rectangle() { Fill=Brushes.White, Width=10, Height=45, Margin = new Thickness(5,0,5,0) }
                }
            };
            play = new Polygon()
            {
                Fill = Brushes.White,
                Stroke = Brushes.White,
                Points = new PointCollection() { new Point(5, 0), new Point(5, 30), new Point(30, 15) }
            };

            restart = new Canvas() { Width = 50, Height = 50 };
            Path path = new Path() { Stroke = Brushes.White, StrokeThickness = 4 };

            PathGeometry pg = new PathGeometry();
            PathFigure pf1 = new PathFigure() { StartPoint = new Point(25, 45) };
            pf1.Segments.Add(new ArcSegment() { Point = new Point(25, 0), Size = new Size(10, 10) });

            PathFigure pf2 = new PathFigure() { StartPoint = new Point(25, 0) };
            pf2.Segments.Add(new ArcSegment() { Point = new Point(5, 25), Size = new Size(20, 22) });

            pg.Figures.Add(pf1);
            pg.Figures.Add(pf2);
            path.Data = pg;

            restart.Children.Add(path);
            restart.Children.Add(new Polygon() { Fill = Brushes.White,
                Points = new PointCollection() { new Point(0, 25), new Point(10, 20), new Point(8, 30) } });

            State = play;
            
            video.MouseEnter += (s, e) => button.Visibility = Visibility.Visible;
            video.MouseLeave += (s, e) => button.Visibility = Visibility.Collapsed;
            button.MouseEnter += (s, e) => button.Visibility = Visibility.Visible;
        }

        static StackPanel pause;
        static Polygon play;
        static Canvas restart;

        public Uri uri
        {
            get { return (Uri)GetValue(uriProperty); }
            set { SetValue(uriProperty, value); }
        }
        public static readonly DependencyProperty uriProperty =
            DependencyProperty.Register("uri", typeof(Uri), typeof(VideoPlayer), new PropertyMetadata(null, StartVideo));



        private static void StartVideo(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VideoPlayer v = (VideoPlayer)d;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler((s, ee) => v.slider.Value = v.video.Position.TotalSeconds);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            v.video.Play();
        }



        public UIElement State
        {
            get { return (UIElement)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(UIElement), typeof(VideoPlayer), new PropertyMetadata(pause));





        private void Button_Click(object sender, RoutedEventArgs e) => ChangeState();
        private void Video_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => ChangeState();

        private void ChangeState()
        {
            if (State == pause)
            {
                PauseVideo();
            }
            else if(State == play)
            {
                PlayVideo();
            }
            else if(State == restart)
            {
                video.Position = TimeSpan.FromSeconds(0);
                slider.Value = 0;
                PlayVideo(); 
            }
        }

        public void PlayVideo()
        {
            Console.WriteLine("play video");
            State = pause;
            video.Play();
        }

        public void PauseVideo()
        {
            State = play;
            video.Pause();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeTime(e.NewValue);
        }

        public void ChangeTime(double value)
        {
            TimeSpan ts = TimeSpan.FromSeconds(value);
            video.Position = ts;

            if (State == restart && value < slider.Maximum)
            {
                State = pause;
            }
        }

        private void Video_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(video.NaturalDuration.TimeSpan.TotalMilliseconds);
            slider.Maximum = ts.TotalSeconds;
            PauseVideo();
        }

        private void Video_MediaEnded(object sender, RoutedEventArgs e)
        {
            State = restart;
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video.Volume = volume.Value;
        }
    }
}