using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Glossary.xaml
    /// </summary>

    public class TextFromString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return Helpers.GetFormattedText(value as string, int.Parse(parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Glossary : Page
    {
        class Concept
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; } = null;
        }

        ObservableCollection<Concept> ConceptList;

        public Glossary()
        {
            InitializeComponent();

            ConceptList = JsonConvert.DeserializeObject<ObservableCollection<Concept>>(Base.ReadFile("glossary/glossary.json"));

            r1.IsChecked = true;

            reset.Click += (s, e) =>
            {
                stack.ItemsSource = ConceptList;
                reset.Visibility = Visibility.Collapsed;
                textbox.Text = "";
            };

            stack.ItemsSource = ConceptList;
        }

        private void SortConcepts(object sender, RoutedEventArgs e)
        {
            if (r1.IsChecked == true)
                ConceptList = new ObservableCollection<Concept>(ConceptList.OrderBy(i => i.Name));
            else if (r2.IsChecked == true)
                ConceptList = new ObservableCollection<Concept>(ConceptList.OrderByDescending(i => i.Name));
            stack.ItemsSource = ConceptList;
        }

        private void Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string text = (sender as TextBox).Text.ToLower();
                IEnumerable<Concept> Filter;
                if (text != "")
                {
                    reset.Visibility = Visibility.Visible;
                    Filter = ConceptList.Where(i => i.Name.ToLower().Contains(text));
                    stack.ItemsSource = Filter;
                }
                else
                {
                    reset.Visibility = Visibility.Collapsed;
                    stack.ItemsSource = ConceptList;
                    textbox.Text = "";
                }
            }
        }

        private void IncreaseImage(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            image.Source = img.Source;
        }

        private void ReduceImage(object sender, MouseButtonEventArgs e)
        {
            if (image.Source != null) image.Source = null;
        }
    }
}