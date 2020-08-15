using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_6_5.xaml
    /// </summary>
    public partial class Theory1_6_5 : Page
    {
        const string prefix = "1_6/1_6_5/";

        Dictionary<string, object> tooltips6 = new Dictionary<string, object>()
            {
                { "k<sub>тр</sub>","k<sub>тр</sub> – коэффициент трения щеток о коллектор (k<sub>тр</sub> = 0,15 – 0,3)" },
                { "f<sub>щ</sub>","f<sub>щ</sub> - удельное (на единицу площади) давление на щетку" },
                { "S<sub>щ</sub>","S<sub>щ</sub> - контактная поверхность всех щеток" },
                { "υ<sub>к</sub>","υ<sub>к</sub> - окружная скорость коллектора" },
            };

        Dictionary<string, object> tooltips7 = new Dictionary<string, object>()
            {
                { "Q","Q – количество воздуха, прогоняемого через машину, м³/с" },
                { "υ","υ – окружная скорость вентиляционных крыльев по их внешнему диаметру, м/с" },
            };

        Dictionary<string, object> tooltips8 = new Dictionary<string, object>()
            {
                { "p<sub>1.0/50</sub>","p<sub>1.0/50</sub> - удельные потери в стали сердечника якоря  на единицу массы при частоте f = 50 Гц и индукции B = 1,0 Тл" },
                { "p<sub>1.5/50</sub>","p<sub>1.5/50</sub> – удельные потери в стали зубцов якоря на единицу массы при частоте f= 50 Гц и индукции B= 1,5 Тл" },
                { "B<sub>Я</sub>","B<sub>Я</sub> – среднее значение индукции в спинке якоря" },
                { "B<sub>Z</sub>","B<sub>Z</sub> – среднее значение индукции в зубцах" },
                { "G<sub>сЯ</sub>","G<sub>сЯ</sub> – масса стали спинки якоря" },
                { "G<sub>сZ</sub>","G<sub>сZ</sub> – масса стали зубцов" },
                { "k<sub>ДЯ</sub>","k<sub>ДЯ</sub> – коэффициент, учитывающий увеличение потерь вследствие обработки стали сердечника якоря (наклеп при штамповке, замыкание листов в пакете), из-за неравномерности распределения индукции и несинусоидальности закона изменения индукции во времени; k<sub>ДЯ</sub> = 3,6" },
                { "k<sub>ДZ</sub>","k<sub>ДZ</sub> – коэффициент, учитывающий увеличение потерь вследствие обработки стали зубцов якоря (наклеп при штамповке, замыкание листов в пакете), из-за неравномерности распределения индукции и несинусоидальности закона изменения индукции во времени; k<sub>ДZ</sub> = 4,0" },
            };

        Dictionary<string, object> tooltips12 = new Dictionary<string, object>()
            {
                { "I<sub>Я</sub>²","I<sub>Я</sub> – сила тока в обмотке якоря" },
                { "R<sub>Я</sub>","R<sub>Я</sub> – сопротивление обмотки якоря. Сопротивление обмотки зависит от температуры. Поэтому ГОСТ 25941-83 предусматривает определение потерь в обмотках при приведении их к рабочей температуре (75°C для классов обмоток A, E и B и 115°C для классов F и H)" },
            };

        Dictionary<string, object> tooltips14 = new Dictionary<string, object>()
            {
                { "I<sub>Я</sub>","I<sub>Я</sub> – сила тока в обмотке якоря" },
                { "ΔU<sub>щ</sub>","ΔU<sub>щ</sub> – падение напряжения на один щеточный контакт. Так как ΔU<sub>щ</sub> зависит сложным образом от разных величин и факторов, то для упрощения расчетов, согласно ГОСТ 11828-86, \"Машины электрические вращающиеся. Общие методы испытаний\", принимается для угольных и графитовых щеток ΔU<sub>щ</sub> = 1 В и для металлоугольных щеток ΔU<sub>щ</sub> = 0,3 В" },
            };

        Dictionary<string, object> tooltips15 = new Dictionary<string, object>()
            {
                { "P<sub>2</sub>","P<sub>2</sub> – электрическая мощность, отдаваемая приемнику" },
                { "P<sub>1</sub>","Р<sub>1</sub> - это механическая мощность, сообщаемая генератору первичным двигателем" },
                { "∑P","ΣР – потери мощности" },
            };

        Dictionary<string, object> tooltips16 = new Dictionary<string, object>()
            {
                { "P<sub>2</sub>","P<sub>2</sub> – механическая мощность на валу" },
                { "P<sub>1</sub>","Р<sub>1</sub> - мощность, потребляемая двигателем от источника постоянного тока" },
                { "∑P","ΣР – потери мощности" },
            };

        public Theory1_6_5()
        {
            InitializeComponent();

            root.AddChilds(new List<Node> { l21, l22, l23, l24 });
            l21.AddChilds(new List<Node> { l31, l32, l33 });
            l24.AddChilds(new List<Node> { l34, l35, l36, l37 });

            l22.ToolTips = tooltips15;
            l23.ToolTips = tooltips16;
            i313.ToolTips = tooltips6;
            i314.ToolTips = tooltips7;
            i321.ToolTips = tooltips8;
            i332.ToolTips = tooltips12;
            i334.ToolTips = tooltips14;
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_6_6());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_6_4());
        }
    }
}