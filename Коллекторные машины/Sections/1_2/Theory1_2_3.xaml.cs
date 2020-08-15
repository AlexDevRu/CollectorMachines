using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_2_3.xaml
    /// </summary>
    public partial class Theory1_2_3 : Page
    {
        Dictionary<string, object> letter_tooltip = new Dictionary<string, object>()
        {
            { "l", "l – длина проводника" },
            { "υ", "υ – линейная скорость пересечения магнитного поля<LineBreak/><formula>v=|{[πDn]}{[60]}</formula><LineBreak/>D – диаметр якоря<LineBreak/>n – частота вращения якоря, об/мин" },
            { "B", "В – индукция магнитного поля" },
            { "B<sub>ср</sub>", new InfoF2() },
            { "Ф", "Ф – магнитный поток одного полюса" },
            { "τ", "τ – полюсное деление<LineBreak/><formula>τ=|{[πD]}{[2p]}</formula><LineBreak/>D – диаметр якоря<LineBreak/>2р – число полюсов" },
            { "2a", "2а – число параллельных ветвей" },
            { "a", "2а – число параллельных ветвей" },
            { "N", "N – количество проводников в обмотке" },
            { "e<sub>ср</sub>", "e<sub>ср</sub> - среднее значение ЭДС в проводнике за половину периода" },
            { "D", "D – диаметр якоря<LineBreak/><formula>D|=|{[2][p][τ]}{[π]}</formula><LineBreak/>τ – полюсное деление, 2р – число полюсов" },
            { "n", "n – частота вращения якоря, об/мин" },
            { "p", "2р – число полюсов" },
            { "C<sub>E</sub>", "С<sub>Е</sub> – конструктивный коэффициент ЭДС<LineBreak/><formula>C<sub>E</sub>|=|{[p][N]}{[60a]}</formula>" },
            { "I<sub>a</sub>", "I<sub>а</sub> – ток одной параллельной ветви якоря<LineBreak/><formula>I<sub>а</sub>|=|{[I<sub>я</sub>]}{[2a]}</formula><LineBreak/>2а – число параллельных ветвей, Iя - ток якоря" },
            { "I<sub>я</sub>", "I<sub>я</sub> – ток якоря" },
            { "F<sub>эмср</sub>", "F<sub>эмср</sub> - среднее значение электромагнитной силы за время прохождения проводника через зону одного полюса" },
            { "C<sub>M</sub>", "C<sub>M</sub> – конструктивный коэффициент  момента<LineBreak/><formula>C<sub>M</sub>|=|{[p][N]}{[2πa]}</formula>" },
        };

        Dictionary<int, string> formulas = new Dictionary<int, string>()
        {
            {1, "e|=|B|l|υ"},
            {2, "e<sub>ср</sub>|=|B<sub>ср</sub>|l|=|{[Ф]}{[τ][υ]}|l|υ|{[υ]}{[τ]}|Ф"},
            {3, "E|=|e<sub>ср</sub>|{[N]}{[2a]}|=|{[υ]}{[τ]}|Ф|{[N]}{[2a]}"},
            {4, "E|=|{[π][D]}{[60]}|n|{[2π]}{[π][D]}|{[N]}{[2a]}|Ф|=|{[p][N]}{[60a]}|n|Ф|=|C<sub>E</sub>|n|Ф"},
            {5, "F<sub>эм</sub>|=|B|l|I<sub>a</sub>"},
            {6, "F<sub>эмср</sub>|=|B<sub>ср</sub>|l|I<sub>a</sub>"},
            {7, "M<sub>эм</sub>|=|F<sub>эмср</sub>|{[D]}{[2]}"},
            {8, "M|=|F<sub>эмср</sub>|{[D]}{[2]}|N|=|B<sub>ср</sub>|I<sub>a</sub>|l|{[D]}{[2]}|N|=|{[Ф]}{[π][D][l][/][2][p]}|{[I<sub>я</sub>]}{[2a]}|l|{[D]}{[2]}|N|=|{[p][N]}{[2][π][a]}|I<sub>я</sub>|Ф|=|C<sub>M</sub>|I<sub>я</sub>|Ф"},
            {9, "{[C<sub>M</sub>]}{[C<sub>E</sub>]}|=|{[p][N]}{[2][π][a]}|{[60][a]}{[p][N]}|=|{[60]}{[2π]}|≈|9,57"},
        };


        public Theory1_2_3()
        {
            InitializeComponent();
        }

        private void ShowFormula(object sender, MouseButtonEventArgs e)
        {
            string name = (sender as Node).Name;
            int i = int.Parse(name[1].ToString());
            TextBlock t = FormulaParser.Parse(formulas[i], 30, letter_tooltip);
            formula.Content = t;
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_1());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_2_2_1());
        }
    }
}