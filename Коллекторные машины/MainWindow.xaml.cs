using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainPage main;

        public MainWindow()
        {
            InitializeComponent();
            main = new MainPage(home);
            frame.Navigate(main);
            Base.frame = frame;

            close.Click += (s, e) =>
            {
                items.Visibility = Visibility.Collapsed;
            };
        }

        private void VisibleList(object sender, RoutedEventArgs e)
        {
            if (list.ItemsSource != null) items.Visibility = Visibility.Visible;
        }

        Dictionary<string, Tuple<string, List<Page>>> TestsData = new Dictionary<string, Tuple<string, List<Page>>>()
        {
            {
                "Тахогенератор постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_7/1_7_1/Test/questions.json",
                    new List<Page>() { new Test171.Question1() }
                )
            },
            {
                "Устройство машины постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_1/1_1_2/Test/questions.json",
                    new List<Page>() { new Test112.Question1(), new Test112.Question2() }
                )
            },
            {
                "Коммутация в машинах постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_4/1_4_1/Test/questions.json",
                    null
                )
            },
            {
                "Магнитная цепь машины постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_3/1_3_1/Test/questions.json",
                    null
                )
            },
            {
                "Коллекторные генераторы постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_5/Test/questions.json",
                    null
                )
            },
            {
                "Двигатели",
                new Tuple<string, List<Page>>
                (
                    "1_6/Test/questions.json",
                    null
                )
            },
            {
                "Обмотки якоря машины постоянного тока",
                new Tuple<string, List<Page>>
                (
                    "1_2/1_2_1/Test/questions.json",
                    null
                )
            }
        };

        private void Tests(object sender, RoutedEventArgs e)
        {
            items.Visibility = Visibility.Visible;
            list.FontSize = 30;
            List<SectionItemData> subsections = new List<SectionItemData>();

            foreach (var data in TestsData)
            {
                subsections.Add(new SectionItemData(data.Key, new Test(data.Value.Item1, data.Value.Item2)));
            }

            list.ItemsSource = subsections;
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"/Help/index.html");
        }

        private void About(object sender, RoutedEventArgs e)
        {
            new About().ShowDialog();
        }

        private void ReturnHome(object sender, RoutedEventArgs e)
        {
            home.Visibility = Visibility.Collapsed;
            Base.frame.Navigate(main);
            home.Click -= VisibleList;
        }

        private void Videoteka(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Videoteka());
            home.Visibility = Visibility.Visible;
        }

        private void Glossary(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Glossary());
            home.Visibility = Visibility.Visible;
        }


        class TaskData
        {
            public string Folder { get; set; }
            public UserControl Algorithm { get; set; }
            public BitmapImage Image { get; set; }
            public string ImageText { get; set; }
        }

        Dictionary<string, TaskData> TasksData = new Dictionary<string, TaskData>()
        {
            {
                "Коллекторный двигатель постоянного тока параллельного возбуждения",
                new TaskData()
                {
                    Folder = "1_6/1_6_1/Tasks/1/",
                    Algorithm = new Algorithm1_6_1()
                }
            },

            {
                "Коллекторный двигатель постоянного тока последовательного возбуждения",
                new TaskData()
                {
                    Folder = "1_6/1_6_2/Tasks/1/",
                    Algorithm = new Algorithm1_6_2()
                }
            },

            {
                "Потери мощности в машине постоянного тока и КПД машины",
                new TaskData()
                {
                    Folder = "1_6/1_6_5/Tasks/1/",
                    Algorithm = new Algorithm1_6_5()
                }
            },

            {
                "Генератор постоянного тока параллельного возбуждения",
                new TaskData()
                {
                    Folder = "1_5/1_5_3/Tasks/1/",
                    Algorithm = new Algorithm1_5_3()
                }
            },

            {
                "Генератор постоянного тока независимого возбуждения",
                new TaskData()
                {
                    Folder = "1_5/1_5_2/Tasks/1/",
                    Algorithm = new Algorithm1_5_2()
                }
            },

            {
                "Обмотки якоря. Пример 1",
                new TaskData()
                {
                    Folder = "1_2/1_2_1/Tasks/1/",
                    Image = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Sections/1_2/1_2_1/Tasks/1/image.jpg")),
                    ImageText = "Схема трехфазной петлевой обмотки",
                    Algorithm = new Algorithm1_2()
                }
            },

            {
                "Обмотки якоря. Пример 2",
                new TaskData()
                {
                    Folder = "1_2/1_2_1/Tasks/2/",
                    Image = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Sections/1_2/1_2_1/Tasks/2/image.jpg")),
                    ImageText = "Трехфазная однослойная обмотка статора с расположением лобовых частей в двух плоскостях",
                    Algorithm = new Algorithm1_2()
                }
            },

            {
                "Обмотки якоря. Пример 3",
                new TaskData()
                {
                    Folder = "1_2/1_2_1/Tasks/3/",
                    Image = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Sections/1_2/1_2_1/Tasks/3/image.jpg")),
                    ImageText = "Трехфазная однослойная шаблонная обмотка статора",
                    Algorithm = new Algorithm1_2()
                }
            },

            {
                "ЭДС обмоток якоря, электромагнитный момент МПТ",
                new TaskData()
                {
                    Folder = "1_2/1_2_3/Tasks/1/",
                    Algorithm = new Algorithm1_2_3()
                }
            },
        };

        private void Tasks(object sender, RoutedEventArgs e)
        {
            items.Visibility = Visibility.Visible;
            list.FontSize = 25;
            List<SectionItemData> subsections = new List<SectionItemData>();

            foreach(var data in TasksData)
            {
                subsections.Add(new SectionItemData(data.Key, new Task(data.Value.Folder, data.Value.Algorithm, data.Value.Image, data.Value.ImageText)));
            }

            list.ItemsSource = subsections;
        }

        private void OpenList(object sender, MouseButtonEventArgs e)
        {
            SectionItem item = sender as SectionItem;
            Base.frame.Navigate(item.OpenPage);
            home.Visibility = Visibility.Visible;
            items.Visibility = Visibility.Hidden;
            home.Click += VisibleList;
        }
    }
}