using System.Windows;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            ok.Click += (s, e) => Close();
        }
    }
}