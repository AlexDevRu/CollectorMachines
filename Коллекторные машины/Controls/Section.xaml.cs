using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Section.xaml
    /// </summary>
    public partial class Section : UserControl
    {
        public Section()
        {
            InitializeComponent();
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Section), new PropertyMetadata(""));





        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(Section), new PropertyMetadata(null));





        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(Section), new PropertyMetadata(150));


    }
}