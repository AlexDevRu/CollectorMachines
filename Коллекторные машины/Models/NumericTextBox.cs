using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Коллекторные_машины
{
    class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            TextChanged += TextChangedFunc;
            PreviewTextInput += Validate;
        }

        public static void TextChangedFunc(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            #pragma warning disable CS0618
            var ft = new FormattedText
            (
                textBox.Text, CultureInfo.CurrentUICulture, textBox.FlowDirection,
                new Typeface(textBox.FontFamily, textBox.FontStyle,
                            weight: textBox.FontWeight, stretch: textBox.FontStretch),
                            textBox.FontSize, textBox.Foreground
            );
            #pragma warning restore CS0618

            if (ft.Width > 80)
                textBox.Width = ft.Width + 10;
            else
                textBox.Width = 80;
        }

        public static void Validate(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
                && (!textBox.Text.Contains(",")
                && textBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}