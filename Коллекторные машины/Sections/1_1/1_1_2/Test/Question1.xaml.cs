using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Коллекторные_машины.Test112
{
    /// <summary>
    /// Логика взаимодействия для Question1.xaml
    /// </summary>
    public partial class Question1 : Page, ITestQuestion
    {
        Action<bool> ShowResult;

        public Question1()
        {
            InitializeComponent();
            RightAnswers = new Dictionary<Canvas, string>()
            {
                { c1, "сердечник главного полюса" },
                { c2, "обмотка возбуждения" },
                { c3, "щеткодержатель" },
                { c4, "щетки" },
                { c5, "коллектор" },
                { c6, "обмотка якоря" },
                { c7, "сердечник якоря" },
                { c8, "вентилятор" },
                { c9, "вал" },
                { c10, "подшипниковый щит" },
            };
        }

        public void AddShowResult(Action<bool> ShowResult) => this.ShowResult = ShowResult;

        Dictionary<Canvas, string> RightAnswers;

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            Border lbl = (Border)sender;
            DataObject data = new DataObject(lbl.Child as TextBlock);
            DragDrop.DoDragDrop(lbl, data, DragDropEffects.Move);
        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            TextBlock txt = (TextBlock)sender;
            TextBlock source = (TextBlock)e.Data.GetData(typeof(TextBlock));
            if (stack.Children.Contains(source.Parent as Border))
            {
                if (txt.Text != "")
                {
                    TextBlock text = new TextBlock() { Text = txt.Text };
                    Border border = new Border();
                    border.Style = (Style)FindResource("TextInBorder");
                    border.MouseDown += Drag;
                    border.Child = text;
                    stack.Children.Add(border);
                }
                txt.Text = source.Text;
                source.Text = "";
                stack.Children.Remove(source.Parent as Border);
            }
            else
            {
                string str = txt.Text;
                txt.Text = source.Text;
                source.Text = str;
            }
        }

        private void Stack_Drop(object sender, DragEventArgs e)
        {
            TextBlock source = (TextBlock)e.Data.GetData(typeof(TextBlock));
            if (stack.Children.Contains(source.Parent as Border)) return;
            TextBlock text = new TextBlock();
            text.Text = source.Text;
            source.Text = "";

            Border border = new Border();
            border.Style = (Style)FindResource("TextInBorder");
            border.MouseDown += Drag;
            border.Child = text;
            stack.Children.Add(border);
        }

        private void BrushCanvas(Canvas canvas, Brush brush)
        {
            foreach (var child in canvas.Children)
                if (child is Border)
                    (child as Border).BorderBrush = brush;
                else
                    (child as Shape).Stroke = brush;
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            byte empty = 0;
            TextBlock empty_block = null;
            foreach (Canvas c in answers.Children)
            {
                TextBlock text = (c.Children[0] as Border).Child as TextBlock;
                if (text.Text == "")
                {
                    ++empty;
                    empty_block = text;
                }
            }

            if (empty > 1)
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (empty == 1)
            {
                empty_block.Text = ((stack.Children[0] as Border).Child as TextBlock).Text;
                stack.Children.RemoveAt(0);
            }

            byte points = 0;
            foreach (Canvas c in answers.Children)
            {
                TextBlock text = (c.Children[0] as Border).Child as TextBlock;
                text.MouseDown -= Drag;
                if (text.Text == RightAnswers[c])
                {
                    ++points;
                    BrushCanvas(c, Brushes.Green);
                }
                else
                    BrushCanvas(c, Brushes.Red);
            }
            ShowResult(points == RightAnswers.Keys.Count);
        }

        public void Anew()
        {
            foreach (Canvas c in answers.Children)
            {
                BrushCanvas(c, Brushes.Blue);
                TextBlock textBlock = (c.Children[0] as Border).Child as TextBlock;
                textBlock.MouseDown += Drag;
                string text = textBlock.Text;
                textBlock.Text = "";
                TextBlock item = new TextBlock() { Text = text };

                Border border = new Border();
                border.Style = (Style)FindResource("TextInBorder");
                border.MouseDown += Drag;
                border.Child = item;
                stack.Children.Add(border);
            }
        }
    }
}