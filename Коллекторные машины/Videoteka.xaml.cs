using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{

    /// <summary>
    /// Логика взаимодействия для Videoteka.xaml
    /// </summary>
    public class ImageFromString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            string path = value as string;
            return new BitmapImage(new Uri(path));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Videoteka : Page
    {
        class Video
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }

            [JsonProperty("isflash")]
            public bool IsFlash { get; set; } = false;
        }

        ObservableCollection<Video> VideoList;

        public Videoteka()
        {
            VideoList = JsonConvert.DeserializeObject<ObservableCollection<Video>>(Base.ReadFile("videoteka/videoteka.json"));

            InitializeComponent();

            r1.IsChecked = true;

            close.Click += (s, e) => 
            {
                grid_player.Visibility = System.Windows.Visibility.Hidden;
                player.uri = null;
            };
            reset.Click += (s, e) =>
            {
                videos.ItemsSource = VideoList;
                reset.Visibility = System.Windows.Visibility.Collapsed;
                textbox.Text = "";
            };

            videos.ItemsSource = VideoList;
        }

        private void OpenVideo(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            string title = ((border.Child as StackPanel).Children[1] as TextBlock).Text;

            foreach(Video v in VideoList)
                if(v.Title == title)
                {
                    if (!v.IsFlash)
                    {
                        player.uri = new Uri(v.Path);
                        grid_player.Visibility = System.Windows.Visibility.Visible;
                        //player.PlayVideo();
                    }    
                    else
                    {
                        string str = System.IO.Directory.GetCurrentDirectory() + "\\Sections\\";
                        System.Diagnostics.Process.Start(str + v.Path);
                    }
                    break;
                }
        }

        private void SortVideos(object sender, System.Windows.RoutedEventArgs e)
        {
            if(r1.IsChecked == true)
                VideoList = new ObservableCollection<Video>(VideoList.OrderBy(i => i.Title));
            else if(r2.IsChecked == true)
                VideoList = new ObservableCollection<Video>(VideoList.OrderByDescending(i => i.Title));
            videos.ItemsSource = VideoList;
        }

        private void Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string text = (sender as TextBox).Text.ToLower();
                System.Collections.Generic.IEnumerable<Video> Filter;
                if (text != "")
                {
                    reset.Visibility = System.Windows.Visibility.Visible;
                    Filter = VideoList.Where(i => i.Title.ToLower().Contains(text));
                    videos.ItemsSource = Filter;
                }
                else
                {
                    reset.Visibility = System.Windows.Visibility.Collapsed;
                    videos.ItemsSource = VideoList;
                    textbox.Text = "";
                }    
            }
        }
    }
}