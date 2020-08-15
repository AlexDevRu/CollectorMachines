using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Коллекторные_машины
{
    class InputFields : TextBlock
    {
        public InputFields(string e, Action<bool, InputFields> check)
        {
            Check = check;

            FontStyle = FontStyles.Italic;
            FontSize = 35;
            FontFamily = new FontFamily("Cambria Math");

            double d;
            Inlines.Add(input_fields_stack);
            string[] parts = e.Split('|');


            TextBlock equal_text = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Text = "=",
                Margin = new Thickness(0, 0, 10, 0)
            };
            input_fields_stack.Children.Add(equal_text);


            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];
                if (part == "box")
                {
                    Border border = new Border()
                    {
                        Padding = new Thickness(0, 0, 10, 0)
                    };

                    NumericTextBox textBoxTask = new NumericTextBox()
                    {
                        Width = 80,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = textBoxTask;

                    input_fields_stack.Children.Add(border);

                    numbers.Add(textBoxTask, expression.Length);
                }
                else if (operators.Contains(part) || double.TryParse(part, out d))
                {
                    expression += part.Replace(",", ".");

                    TextBlock text = new TextBlock()
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        Text = part.Replace("*", "∙"),
                        Margin = new Thickness(0, 0, 10, 0)
                    };

                    input_fields_stack.Children.Add(text);
                }
                else if (part.StartsWith("sqrt"))
                {
                    expression += "sqrt";

                    TextBlock text = new TextBlock()
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        Text = "√",
                        FontStyle = FontStyles.Normal,
                        Margin = new Thickness(0, 0, 10, 0)
                    };

                    if (part.Length > 4)
                    {
                        text.FontSize = 100;
                        IsSqrt = true;
                        text.Margin = new Thickness(0, 5, 4, 0);
                    }

                    input_fields_stack.Children.Add(text);
                }
                else if (part.StartsWith("pow2"))
                {
                    expression += "pow2";

                    TextBlock text = Helpers.GetFormattedText("<sup>2</sup>", (int)FontSize);

                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.Margin = new Thickness(0, 0, 10, 0);

                    input_fields_stack.Children.Add(text);
                }
                else if (part == "(b" || part == ")b")
                {
                    expression += part.Substring(0, 1);

                    if (IsSqrt && part == "(b") continue;
                    if (IsSqrt && part == ")b") { IsSqrt = false; continue; }

                    /*TextBlock text = new TextBlock()
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        Text = part.Substring(0, 1),
                        FontStyle = FontStyles.Normal,
                        FontSize = 75,
                        Margin = new Thickness(0, 0, 10, 0)
                    };

                    input_fields_stack.Children.Add(text);*/
                }
                else if (part.StartsWith("{"))
                {
                    Regex regex1 = new Regex(@"[^{}]+");
                    MatchCollection matches1 = regex1.Matches(part);

                    Border border_fraction = new Border()
                    {
                        Padding = new Thickness(0, 0, 10, 0)
                    };

                    if (IsSqrt)
                    {
                        border_fraction.BorderBrush = Brushes.Black;
                        border_fraction.BorderThickness = new Thickness(0, 6, 0, 0);
                    }

                    StackPanel fraction = new StackPanel() { Margin = new Thickness(0, 0, 10, 0) };

                    expression += "(";
                    bool first = true;

                    foreach (Match m in matches1)
                    {
                        Console.WriteLine(m.Value);
                        StackPanel stack = AddTextBoxes(m.Value);
                        Border border = new Border()
                        {
                            BorderBrush = Brushes.Black,
                            BorderThickness = new Thickness(0, 0, 0, 1)
                        };
                        border.Child = stack;
                        fraction.Children.Add(border);

                        if (first)
                        {
                            first = false;
                            expression += ")/(";
                        }
                    }

                    (fraction.Children[1] as Border).BorderThickness = new Thickness(0, 1, 0, 0);
                    expression += ")";

                    border_fraction.Child = fraction;

                    input_fields_stack.Children.Add(border_fraction);
                }
            }

            equal = new Button()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Content = "=",
                Padding = new Thickness(10, 0, 10, 0),
                Margin = new Thickness(0, 0, 10, 0)
            };
            equal.Click += Calc;
            input_fields_stack.Children.Add(equal);

            input_fields_stack.Children.Add(text_result);
        }

        private void AddNumber(NumericTextBox textBox)
        {
            if (!numbers.Keys.Contains(textBox)) return;

            int i = numbers[textBox];

            expression = expression.Insert(i + offset - 1, textBox.Text.Replace(",", "."));
            offset += textBox.Text.Count();
            numbers.Remove(textBox);
        }

        private void Calc(object sender, RoutedEventArgs e)
        {
            string expr = expression;
            Dictionary<NumericTextBox, int> numbers2 = new Dictionary<NumericTextBox, int>();

            foreach (var key in numbers.Keys)
                if (key.Text != "")
                    numbers2.Add(key, numbers[key]);
                else
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            foreach (var k in numbers.Keys.ToArray())
                AddNumber(k);

            Console.WriteLine(expression);

            CalcFunc("pow2", Math.Pow, 2);
            CalcFunc("sqrt", Math.Sqrt);

            Console.WriteLine(expression);
            double res = Math.Round(double.Parse(new DataTable().Compute(expression, null).ToString()), 2);
            string res_str = res.ToString();

            if (Unit != null) res_str += " " + Unit;

            text_result.Text = res_str;
            expression = expr;
            numbers = numbers2;
            offset = 1;

            Check(res == RightAnswer, this);
        }

        private void CalcFunc(string func_str, Func<double, double, double> func, double two)
        {
            Regex sqrt = new Regex(@"\(([\d\+\*\-\/\(\)\.]+)\)" + func_str + @"|([\d\.]+)" + func_str);
            MatchCollection matches = sqrt.Matches(expression);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Groups[1].Value + "      " + m.Value);
                string expr = m.Groups[1].Value;

                if (!m.Groups[1].Success) expr = m.Groups[2].Value;

                string sqrt_str = new DataTable().Compute(expr.Replace(',', '.'), null).ToString();
                string sqrt_res = func(double.Parse(sqrt_str), two).ToString().Replace(',', '.');
                expression = expression.Replace(m.Value, sqrt_res);
            }
        }

        private void CalcFunc(string func_str, Func<double, double> func)
        {
            Regex sqrt = new Regex(func_str + @"\(([\d\+\*\-\/\(\)\.]+)\)");
            MatchCollection matches = sqrt.Matches(expression);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Groups[1].Value + "      " + m.Value);
                string sqrt_str = new DataTable().Compute(m.Groups[1].Value, null).ToString();
                string sqrt_res = func(double.Parse(sqrt_str)).ToString().Replace(',', '.');
                expression = expression.Replace(m.Value, sqrt_res);
            }
        }

        public void LockFields()
        {
            foreach (var k in numbers.Keys) k.IsReadOnly = true;
            equal.IsEnabled = false;
        }

        private StackPanel AddTextBoxes(string str)
        {
            StackPanel stack = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5, 2, 5, 2),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            double d;
            string[] parts = str.Split('@');

            foreach (string part in parts)
            {
                if (part == "box")
                {
                    NumericTextBox textBoxTask = new NumericTextBox()
                    {
                        Width = 80,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, 0, 10, 0)
                    };

                    //border.Child = textBoxTask;

                    stack.Children.Add(textBoxTask);

                    numbers.Add(textBoxTask, expression.Length);
                }
                else if (operators.Contains(part) || double.TryParse(part, out d))
                {
                    expression += part.Replace(",", ".");

                    TextBlock text = new TextBlock()
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        Text = part.Replace("*", "∙"),
                        Margin = new Thickness(0, 0, 10, 0)
                    };

                    stack.Children.Add(text);
                }
                else if (part.StartsWith("pow2"))
                {
                    expression += "pow2";

                    TextBlock text = Helpers.GetFormattedText("<sup>2</sup>", (int)FontSize);

                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.Margin = new Thickness(0, 0, 10, 0);

                    stack.Children.Add(text);
                }
            }

            (stack.Children[stack.Children.Count - 1] as FrameworkElement).Margin = new Thickness(0);

            return stack;
        }

        Action<bool, InputFields> Check;
        Button equal;

        bool IsSqrt = false;
        string expression = "";
        int offset = 1;
        string[] operators = { "+", "-", "*", "(", ")" };

        Dictionary<NumericTextBox, int> numbers = new Dictionary<NumericTextBox, int>();
        StackPanel input_fields_stack = new StackPanel() { Orientation = Orientation.Horizontal };
        TextBlock text_result = new TextBlock()
        {
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(0, 0, 10, 0)
        };

        public double RightAnswer { get; set; } = 0;
        public string Unit { get; set; }
    }
}