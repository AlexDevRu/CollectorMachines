using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для node.xaml
    /// </summary>
    public partial class Node : UserControl
    {
        public Node()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleDependency = DependencyProperty.Register("Title", typeof(string), typeof(Node), new PropertyMetadata("", changeTitle));
        public static readonly DependencyProperty TitleSizeProperty = DependencyProperty.Register("TitleSize", typeof(int), typeof(Node), new PropertyMetadata(15));
        public static readonly DependencyProperty PictureProperty = DependencyProperty.Register("Picture", typeof(ImageSource), typeof(Node), new PropertyMetadata(new BitmapImage(new Uri(@"pack://application:,,,/GlobalResources/images/chip.png"))));
        public static readonly DependencyProperty ToolTipsProperty = DependencyProperty.Register("ToolTips", typeof(Dictionary<string, object>), typeof(Node), new PropertyMetadata(null));
        public static readonly DependencyProperty ImageDependency = DependencyProperty.Register("Image", typeof(string), typeof(Node));
        public static readonly DependencyProperty TextDependency = DependencyProperty.Register("Text", typeof(string), typeof(Node));
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(Node), new PropertyMetadata(20));



        public string Title
        {
            get
            {
                return (string)GetValue(TitleDependency);
            }
            set
            {
                SetValue(TitleDependency, value);
            }
        }
        private static void changeTitle(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Node node = (Node)d;
            TextBlock t = Helpers.GetFormattedText(e.NewValue.ToString(), node.TitleSize, null, false, false);
            t.TextAlignment = TextAlignment.Center;
            t.Foreground = Brushes.Black;
            node.content.Content = t;
        }



        public int TitleSize
        {
            get { return (int)GetValue(TitleSizeProperty); }
            set { SetValue(TitleSizeProperty, value); }
        }
        


        public ImageSource Picture
        {
            get { return (ImageSource)GetValue(PictureProperty); }
            set { SetValue(PictureProperty, value); }
        }


        public Dictionary<string, object> ToolTips
        {
            get { return (Dictionary<string, object>)GetValue(ToolTipsProperty); }
            set { SetValue(ToolTipsProperty, value); }
        }
        


        public string Image
        {
            get
            {
                return (string)GetValue(ImageDependency);
            }
            set
            {
                SetValue(ImageDependency, value);
            }
        }



        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }        



        public string Text
        {
            get
            {
                return (string)GetValue(TextDependency);
            }
            set
            {
                SetValue(TextDependency, value);
            }
        }

        public void AddChilds(List<Node> childs)
        {
            Children = childs;
            border.Style = (Style)FindResource("style_border");
        }

        public List<Node> Children = new List<Node>();
    }
}