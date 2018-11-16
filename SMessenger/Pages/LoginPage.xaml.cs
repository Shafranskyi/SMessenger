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
using System.Threading;

namespace SMessenger.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Login_page.Visibility = Visibility.Hidden;
            MainWindow.main.Chat.Visibility = Visibility.Visible;
        }

        private void S_up_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Login_page.Visibility = Visibility.Hidden;
            MainWindow.main.Registration.Visibility = Visibility.Visible;
        }
    }
}
