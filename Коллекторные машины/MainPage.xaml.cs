using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    /// 
    public class SectionItemData
    {
        public SectionItemData(string n, Page p)
        {
            Name = n;
            Page = p;
        }
        public string Name { get; }
        public Page Page { get; }
    }

    public partial class MainPage : Page
    {
        Button home;

        public MainPage(Button h)
        {
            InitializeComponent();
            home = h;
            close.Click += (s, e) =>
            {
                list.ItemsSource = null;
                items.Visibility = Visibility.Collapsed;
            };
        }

        private void OpenItems(object sender, MouseButtonEventArgs e)
        {
            Section s = sender as Section;
            items.Visibility = Visibility.Visible;
            List<SectionItemData> subsections = null;
            switch(s.Name)
            {
                case "Section1":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Основные законы электротехники в применении к теории электрических машин", new Theory1_1_1()),
                        new SectionItemData("Устройство МПТ", new Theory1_1_2()),
                        new SectionItemData("Принцип действия генератора и двигателя постоянного тока", new Theory1_1_3()),
                    };
                    break;
                case "Section2":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Типы обмоток якоря МПТ", new Theory1_2_1()),
                        new SectionItemData("Уравнительные соединения обмоток якоря", new Theory1_2_2_1()),
                        new SectionItemData("ЭДС обмоток якоря, электромагнитный момент МПТ", new Theory1_2_3()),
                    };
                    break;
                case "Section3":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Участки магнитной цепи МПТ", new Theory1_3_1()),
                        new SectionItemData("Реакция якоря и способы её устранения", new Theory1_3_2()),
                    };
                    break;
                case "Section4":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Виды коммутации", new Theory1_4_1()),
                        new SectionItemData("Степени искрения", new Theory1_4_2()),
                    };
                    break;
                case "Section5":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Классификация генераторов постоянного тока, характеристики генераторов", new Theory1_5_1()),
                        new SectionItemData("Генератор постоянного тока независимого возбуждения", new Theory1_5("Генератор постоянного тока независимого возбуждения", "1_5/1_5_2/")),
                        new SectionItemData("Генератор постоянного тока параллельного возбуждения", new Theory1_5("Генератор постоянного тока параллельного возбуждения", "1_5/1_5_3/")),
                        new SectionItemData("Генератор постоянного тока последовательного возбуждения", new Theory1_5("Генератор постоянного тока последовательного возбуждения", "1_5/1_5_4/")),
                        new SectionItemData("Генератор постоянного тока смешанного возбуждения", new Theory1_5("Генератор постоянного тока смешанного возбуждения", "1_5/1_5_5/")),
                    };
                    break;
                case "Section6":
                    const string title61 = "Коллектроные двигатели постоянного тока параллельного возбуждения";
                    const string title62 = "Коллектроные двигатели постоянного тока последовательного возбуждения";
                    const string title63 = "Коллектроные двигатели постоянного тока смешанного возбуждения";
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData(title61, new Theory1_6(title61, "1_6/1_6_1/")),
                        new SectionItemData(title62, new Theory1_6(title62, "1_6/1_6_2/")),
                        new SectionItemData(title63, new Theory1_6(title63, "1_6/1_6_3/")),
                        new SectionItemData("Режимы работы машины постоянного тока", new Theory1_6_4()),
                        new SectionItemData("Потери мощности в машине постоянного тока и КПД машины", new Theory1_6_5()),
                        new SectionItemData("Способы регулирования частоты вращения", new Theory1_6_6()),
                    };
                    break;
                case "Section7":
                    subsections = new List<SectionItemData>()
                    {
                        new SectionItemData("Тахогенератор постоянного тока", new Theory1_7_1()),
                        new SectionItemData("Бесколлекторные двигатели постоянного тока", new Theory1_7_2()),
                    };
                    break;
            }
            list.ItemsSource = subsections;
        }

        private void OpenSection(object sender, MouseButtonEventArgs e)
        {
            SectionItem item = sender as SectionItem;
            Base.frame.Navigate(item.OpenPage);
            home.Visibility = Visibility.Visible;
        }
    }
}