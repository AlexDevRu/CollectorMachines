using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Коллекторные_машины
{
    class FormulaParser
    {
        public static TextBlock Parse(string text, int size, Dictionary<string, object> dict = null, bool iswhite = true)
        {
            Brush brush = Brushes.White;
            if (!iswhite) brush = Brushes.Black;
            bool IsSqrt = false;

            TextBlock textBlock = new TextBlock()
            {
                FontFamily = new FontFamily("Cambria Math"),
                FontSize = size,
                FontStyle = FontStyles.Italic,
                Foreground = brush
            };

            StackPanel formula = new StackPanel() { Orientation = Orientation.Horizontal };

            List<string> parts = new List<string>(text.Split('|'));
            foreach (var part in parts)
            {
                if (part.Contains('{'))
                {
                    Regex regex1 = new Regex(@"[^{}]+");
                    MatchCollection matches1 = regex1.Matches(part);

                    Border border_fraction = new Border()
                    {
                        Padding = new Thickness(0, 0, 10, 0),
                    };

                    if (IsSqrt)
                    {
                        border_fraction.BorderBrush = brush;
                        border_fraction.BorderThickness = new Thickness(0, 6, 0, 0);
                    }

                    StackPanel fraction = new StackPanel() { VerticalAlignment = VerticalAlignment.Center };

                    foreach (Match m in matches1)
                    {
                        Regex regex2 = new Regex(@"\[([^]]*)\]");
                        MatchCollection matches2 = regex2.Matches(m.Value);
                        StackPanel numerator = new StackPanel()
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Center
                        };

                        foreach (Match mm in matches2)
                        {
                            TextBlock num = Helpers.GetFormattedText(mm.Groups[1].Value, size);
                            num.Foreground = brush;
                            num.Margin = new Thickness(0, 0, 3, 0);
                            SetToolTip(dict, mm.Groups[1].Value, num, brush);
                            numerator.Children.Add(num);
                        }
                        fraction.Children.Add(numerator);
                    }

                    Line line = new Line() {
                        Stroke = brush,
                        StrokeThickness = 2
                    };
                    Binding bind = new Binding();
                    bind.Source = fraction;
                    bind.Path = new PropertyPath("ActualWidth");
                    line.SetBinding(Line.X2Property, bind);
                    fraction.Children.Insert(1, line);

                    border_fraction.Child = fraction;
                    formula.Children.Add(border_fraction);
                }
                else
                {
                    if (IsSqrt && part == "(b") continue;
                    if (IsSqrt && part == ")b") { IsSqrt = false; continue; }

                    Border factor = new Border()
                    {
                        Padding = new Thickness(0, 0, 10, 0),
                    };

                    if (IsSqrt)
                    {
                        factor.BorderBrush = brush;
                        factor.BorderThickness = new Thickness(0, 5, 0, 0);
                    }

                    TextBlock block;

                    if(part.EndsWith("big"))
                    {
                        int bigsize = int.Parse(part.Substring(1, part.Length - 4));
                        block = Helpers.GetFormattedText(part[0].ToString(), bigsize);
                        block.FontStyle = FontStyles.Normal;
                        IsSqrt = true;
                        factor.Padding = new Thickness(0, 0, 4, 0);
                        block.Margin = new Thickness(0, 5, 0, 0);
                    }   
                    else
                        block = Helpers.GetFormattedText(part, size);

                    block.Foreground = brush;
                    block.VerticalAlignment = VerticalAlignment.Center;

                    SetToolTip(dict, part, block, brush);

                    factor.Child = block;
                    formula.Children.Add(factor);
                }
            }

            textBlock.Inlines.Add(formula);
            return textBlock;
        }

        private static void SetToolTip(Dictionary<string, object> dict, string part, TextBlock block, Brush brush)
        {
            if (dict != null && dict.Keys.Contains(part))
            {
                if (dict[part] is string)
                {
                    string tooltip = dict[part].ToString();
                    TextBlock t = Helpers.GetFormattedText(tooltip, 20, null);
                    t.MaxWidth = 300;
                    block.ToolTip = t;
                }
                else if (dict[part] is UserControl)
                {
                    UserControl w = (UserControl)dict[part];
                    block.MouseDown += (s, e) =>
                    {
                        ToolTip tooltip = new ToolTip(w);
                        tooltip.ShowDialog();
                    };
                    block.MouseEnter += (s, e) => block.Foreground = Brushes.Blue;
                    block.MouseLeave += (s, e) => block.Foreground = brush;
                }
            }
        }
    }
}