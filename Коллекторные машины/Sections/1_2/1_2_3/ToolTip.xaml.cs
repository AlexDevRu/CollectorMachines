using System.Windows;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    /// <summary>
    /// Логика взаимодействия для InfoF2.xaml
    /// </summary>
    public partial class ToolTip : Window
    {
        public ToolTip(UserControl control)
        {
            InitializeComponent();
            content.Content = control;
        }
    }
}