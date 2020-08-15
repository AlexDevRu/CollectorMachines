using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;
using System.Windows.Media;

namespace Коллекторные_машины
{
    class Base
    {
        public static Frame frame;

        public static string ReadFile(string file)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Sections/" + file;
            return File.ReadAllText(path);
        }

        public static void ShowChildren(Node sender)
        {
            if (sender.Children.First().Visibility == Visibility.Hidden)
            {
                foreach (var item in sender.Children)
                    item.Visibility = Visibility.Visible;
            }
            else
            {
                Hide(sender.Children);
            }
        }


        private static void Hide(List<Node> Children)
        {
            foreach (var item in Children)
            {
                item.Visibility = Visibility.Hidden;
                if (item.Children != null)
                    Hide(item.Children);
            }   
        }


        public static void ShowInfo(string file, string image, Grid grid, string prefix, Dictionary<string, object> tooltips = null, int size = 20, bool stretch = false)
        {
            UserControl info = null;
            
            if (file != null && image == null)
                info = new TextOrImage(grid, ReadFile(prefix + file), true, tooltips, size);
            else if (file == null && image != null)
                info = new TextOrImage(grid, prefix + image, false, tooltips, size, stretch);
            else
                info = new TextWithImage(grid, ReadFile(prefix + file), prefix + image, tooltips, size, stretch);

            grid.Children.Add(info);
        }


        public static void IncreaseImage(Grid img_grid, int rowspan, int columnspan)
        {
            Grid.SetColumn(img_grid, 0);
            Grid.SetRow(img_grid, 0);
            Grid.SetRowSpan(img_grid, rowspan);
            Grid.SetColumnSpan(img_grid, columnspan);
            img_grid.Background = Brushes.White;
        }

        public static void ReduceImage(Grid img_grid, int row, int column)
        {
            Grid.SetColumn(img_grid, column);
            Grid.SetRow(img_grid, row);
            Grid.SetRowSpan(img_grid, 1);
            Grid.SetColumnSpan(img_grid, 1);
            img_grid.Background = Brushes.Transparent;
        }
    }
}