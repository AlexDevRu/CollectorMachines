using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Theory1_1_2.xaml
    /// </summary>
    public partial class Theory1_1_2 : Page
    {
        const string prefix = "1_1/1_1_2/";

        Dictionary<string, string> images = new Dictionary<string, string>()
        {
            { "i221","4/image.jpg" },
            { "i211","3/image.jpg" },
            { "iroot1","2/image.jpg" },
            { "i361","23/image.jpg" },
        };


        public Theory1_1_2()
        {
            InitializeComponent();
            root.AddChilds(new List<Node> { l21, l22 });
            l21.AddChilds(new List<Node> { l31, l32, l33, l34 });
            l22.AddChilds(new List<Node> { l35, l36, l37, l38 });

            i362.MouseDown += (sender, e) => grid.Children.Add(new Collector(grid));
            i321.MouseDown += (sender, e) => grid.Children.Add(new Item14(grid));
            i331.MouseDown += (sender, e) => grid.Children.Add(new MainMagneticPoles(grid));
            i332.MouseDown += (sender, e) => grid.Children.Add(new Section112.Item10(grid));
            i341.MouseDown += (sender, e) => grid.Children.Add(new AdditionalMagneticPoles(grid));
            i371.MouseDown += (sender, e) => grid.Children.Add(new WindingAnchor(grid));
        }

        private void ShowChildren(object sender, MouseButtonEventArgs e)
        {
            Base.ShowChildren(sender as Node);
        }

        private void ShowInfo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            if(n.Name == "i372" || n.Name == "i373" || n.Name == "i374")
                Base.ShowInfo(n.Text, n.Image, grid, "1_2/1_2_1/", n.ToolTips, n.Size);
            else
                Base.ShowInfo(n.Text, n.Image, grid, prefix, n.ToolTips, n.Size);
        }

        private void OpenImage(object sender, MouseButtonEventArgs e)
        {
            string path = (sender as Image).Name;
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Sections/" + prefix + images[path]);
        }

        private void OpenVideo(object sender, MouseButtonEventArgs e)
        {
            Node n = sender as Node;
            string str = System.IO.Directory.GetCurrentDirectory() + "\\Sections\\";
            System.Diagnostics.Process.Start(str + prefix + n.Text);
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_1_3());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Base.frame.Navigate(new Theory1_1_1());
        }
    }
}