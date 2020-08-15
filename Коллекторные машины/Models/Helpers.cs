using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Коллекторные_машины
{
    class Helpers
    {
        public static TextBlock GetFormattedText(string str, int size = 20, Dictionary<string, object> dict = null, bool iswhite = false, bool scroll = true)
        {
            int i;
            double sub = size * 0.65;
            double f = size * 1.5;
            string plaintext = "";
            TextBlock t = new TextBlock() { FontSize = size, TextWrapping = TextWrapping.Wrap };
            for (; str != "";)
            {
                i = 0;
                if (str.StartsWith("<LineBreak/>"))
                {
                    t.Inlines.Add(plaintext);
                    plaintext = "";
                    t.Inlines.Add(new LineBreak());
                    i += 12;
                }
                else if (str.StartsWith("<sub>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</sub>", ref i, ref plaintext, t, ref str)) { BaselineAlignment = BaselineAlignment.Subscript, FontSize = sub });
                }
                else if (str.StartsWith("<sup>"))
                {
                    t.Inlines.Add(new TextBlock() { Text = GetStringInTag("</sup>", ref i, ref plaintext, t, ref str), BaselineOffset = size * 1.3, FontSize = sub * 0.8 });
                }
                else if (str.StartsWith("<dsup>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</dsup>", ref i, ref plaintext, t, ref str)) { BaselineAlignment = BaselineAlignment.Superscript, FontSize = sub * 0.8 });
                }
                else if (str.StartsWith("<hsup>"))
                {
                    t.Inlines.Add(new TextBlock() { Text = GetStringInTag("</hsup>", ref i, ref plaintext, t, ref str), BaselineOffset = size * 1.8, FontSize = sub * 0.8, Margin = new Thickness(-10, 0, 0, 0) });
                }
                else if (str.StartsWith("<formula>"))
                {
                    string texf = GetStringInTag("</formula>", ref i, ref plaintext, t, ref str);
                    TextBlock tb = FormulaParser.Parse(texf, (int)f, dict, iswhite);
                    tb.Foreground = Brushes.Black;
                    if (scroll)
                    {
                        ScrollViewer s = new ScrollViewer() { HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, VerticalScrollBarVisibility = ScrollBarVisibility.Disabled };
                        s.MouseWheel += (ss, ee) => ee.Handled = true;
                        s.Content = tb;
                        t.Inlines.Add(s);
                    }
                    else t.Inlines.Add(tb);
                }
                else if (str.StartsWith("<Bold>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</Bold>", ref i, ref plaintext, t, ref str)) { FontWeight = FontWeights.Bold, Foreground = Brushes.Blue });
                }
                else if (str.StartsWith("<sBold>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</sBold>", ref i, ref plaintext, t, ref str)) { FontWeight = FontWeights.Bold, Foreground = Brushes.Blue, BaselineAlignment = BaselineAlignment.Subscript, FontSize = sub });
                }
                else if (str.StartsWith("<redBold>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</redBold>", ref i, ref plaintext, t, ref str)) { FontWeight = FontWeights.Bold, Foreground = Brushes.Red });
                }
                else if (str.StartsWith("<i>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</i>", ref i, ref plaintext, t, ref str)) { FontStyle = FontStyles.Italic });
                }
                else if (str.StartsWith("<si>"))
                {
                    t.Inlines.Add(new Run(GetStringInTag("</si>", ref i, ref plaintext, t, ref str)) { FontStyle = FontStyles.Italic, BaselineAlignment = BaselineAlignment.Subscript, FontSize = sub });
                }
                else
                {
                    plaintext += str[0];
                    ++i;
                }
                str = str.Substring(i);
            }
            if (plaintext != "")
                t.Inlines.Add(plaintext);
            return t;
        }

        private static string GetStringInTag(string tag, ref int i, ref string plaintext, TextBlock t, ref string str)
        {
            string sub = "";
            int j = i + tag.Length - 1;
            while (str.Substring(j, tag.Length) != tag)
            {
                sub += str[j++];
            }
            i = j + tag.Length;
            t.Inlines.Add(plaintext);
            plaintext = "";
            return sub;
        }

        public static string GetStringInTag(string tag, string str)
        {
            string sub = "";
            int j = tag.Length - 1;
            while (str.Substring(j, tag.Length) != tag)
            {
                sub += str[j++];
            }
            return sub;
        }
    }
}