using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SMessenger.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Sing_up_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Registration.Visibility = Visibility.Hidden;
            MainWindow.main.Chat.Visibility = Visibility.Visible;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Bord3.Background = Application.Current.Resources["WordVeryLightBlueBrush"] as Brush;
        }

        private void Expand_Collapsed(object sender, RoutedEventArgs e)
        {
            Bord3.Background = null;
        }
    }
}
