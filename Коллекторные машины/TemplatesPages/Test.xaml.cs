using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    /// 

    public class Variant
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        public TextBlock Formula { get; set; }

        [JsonProperty("isright")]
        public bool IsRight { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Question
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("manyAnswers")]
        public bool ManyAnswers { get; set; }

        [JsonProperty("answers")]
        public Variant[] Answers { get; set; }

        public Page Page { get; set; }
    }

    public partial class Test : Page
    {
        readonly int total;
        int count_right = 0;
        int active = 0;
        List<Question> questions;
        List<Page> additional;

        public Test(string questions_json, List<Page> additional)
        {
            InitializeComponent();
            this.additional = additional;
            System.Console.WriteLine("constructor test");

            questions = JsonConvert.DeserializeObject<List<Question>>(Base.ReadFile(questions_json));

            if(additional != null)
                foreach (Page p in additional)
                {
                    (p as ITestQuestion).AddShowResult(ShowResult);
                    questions.Insert(0, new Question() { Page = p });
                }

            total = questions.Count;

            Question q = questions[active];
            if (q.Page != null)
            {
                (q.Page as ITestQuestion).Anew();
                frame.Navigate(q.Page);
            }
            else
                frame.Navigate(new TestQuestion(q, ShowResult));
            ++active;
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            result.Visibility = Visibility.Collapsed;
            if (active == questions.Count)
            {
                test_result.Visibility = Visibility.Visible;
                count.Text = count_right + " из " + total;

                chart.ChartAreas[0].AxisY.Interval = 1;
                chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                if(count_right == 0)
                {
                    ellipse_grid.Visibility = Visibility.Visible;
                    winformhost.Visibility = Visibility.Collapsed;
                    ellipse.Fill = Brushes.Red;
                    ellipse_count.Text = total.ToString();
                }
                else if(count_right == total)
                {
                    ellipse_grid.Visibility = Visibility.Visible;
                    winformhost.Visibility = Visibility.Collapsed;
                    ellipse.Fill = Brushes.Green;
                    ellipse_count.Text = total.ToString();
                }
                else
                {
                    chart.Series[0].Points.AddXY((total - count_right).ToString(), total - count_right);
                    chart.Series[0].Points[0].Color = System.Drawing.Color.Red;
                    chart.Series[0].Points[0].Font = new System.Drawing.Font("Arial", 50);
                    chart.Series[0].Points[0].LabelForeColor = System.Drawing.Color.White;

                    chart.Series[0].Points.AddXY(count_right.ToString(), count_right);
                    chart.Series[0].Points[1].Color = System.Drawing.Color.Green;
                    chart.Series[0].Points[1].Font = new System.Drawing.Font("Arial", 50);
                    chart.Series[0].Points[1].LabelForeColor = System.Drawing.Color.White;
                }
                
                return;
            }
            Question q = questions[active];
            if(q.Page != null)
            {
                (q.Page as ITestQuestion).Anew();
                frame.Navigate(q.Page);
            }          
            else
                frame.Navigate(new TestQuestion(q, ShowResult));
            ++active;
            System.Windows.Controls.Grid.SetRowSpan(frame, 2);
        }

        private void ShowResult(bool right)
        {
            if(right)
            {
                result.Background = Brushes.Green;
                txt.Text = "Правильно";
                ++count_right;
            }
            else
            {
                result.Background = Brushes.Red;
                txt.Text = "Неправильно";
            }

            result.Visibility = Visibility.Visible;
            System.Windows.Controls.Grid.SetRowSpan(frame, 1);
        }

        private void Anew(object sender, RoutedEventArgs e)
        {
            test_result.Visibility = Visibility.Collapsed;
            System.Windows.Controls.Grid.SetRowSpan(frame, 2);
            count_right = 0;
            active = 0;
            Question q = questions[active];
            if (q.Page != null)
            {
                (q.Page as ITestQuestion).Anew();
                System.Console.WriteLine("first question");
                frame.Navigate(q.Page);
            }
            else
                frame.Content = new TestQuestion(q, ShowResult);
            ++active;

            chart.Series[0].Points.Clear();
        }
    }
}