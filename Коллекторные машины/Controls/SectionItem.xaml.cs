using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для SectionItem.xaml
    /// </summary>
    public partial class SectionItem : UserControl
    {
        public SectionItem()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SectionItem), new PropertyMetadata(""));



        public Page OpenPage
        {
            get { return (Page)GetValue(OpenPageProperty); }
            set { SetValue(OpenPageProperty, value); }
        }
        public static readonly DependencyProperty OpenPageProperty =
            DependencyProperty.Register("OpenPage", typeof(Page), typeof(SectionItem), new PropertyMetadata(null));
    }
}