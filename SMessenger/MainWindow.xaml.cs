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

namespace SMessenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button first, third, second;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            My_Title();

            Button menu = new Button() { Style = Application.Current.Resources["Kv"] as Style, Margin = new Thickness(5) };
            menu.Content = "M";
            menu.FontSize = 15;
            Grid.SetColumn(menu, 0);

            TextBox search = new TextBox() { Style = Application.Current.Resources["TextBox"] as Style, Margin = new Thickness(10),
                Background = new SolidColorBrush(Color.FromRgb(234, 229, 229)), FontSize = 15, FontFamily = new FontFamily("Comi"), VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetColumn(search, 1);


            Grid Friends = new Grid();
            Grid F_S_and_M = new Grid();
            F_S_and_M.ShowGridLines = true;
            Friends.ShowGridLines = true;
            Grid Log = new Grid();

            Grid.SetRow(F_S_and_M, 0);
            Grid.SetColumn(Friends, 0);
            Grid.SetColumn(Log, 1);

            RowDefinition Fr1 = new RowDefinition();
            Fr1.Height = new GridLength(50);
            RowDefinition Fr2 = new RowDefinition();
            ColumnDefinition Fc1 = new ColumnDefinition();
            Fc1.Width = new GridLength(50);
            ColumnDefinition Fc2 = new ColumnDefinition();
            Friends.RowDefinitions.Add(Fr1);
            Friends.RowDefinitions.Add(Fr2);
            F_S_and_M.ColumnDefinitions.Add(Fc1);
            F_S_and_M.ColumnDefinitions.Add(Fc2);
            F_S_and_M.Children.Add(menu);
            F_S_and_M.Children.Add(search);
            Friends.Children.Add(F_S_and_M);

            Grid All = new Grid();
            All.ShowGridLines = true;
            ColumnDefinition A1 = new ColumnDefinition();
            ColumnDefinition A2 = new ColumnDefinition();
            ColumnDefinition A3 = new ColumnDefinition();
            A2.Width = new GridLength(5);
            A1.MaxWidth = Own.ActualWidth / 2;  A1.MinWidth = 50;

            All.ColumnDefinitions.Add(A1);  All.ColumnDefinitions.Add(A2);  All.ColumnDefinitions.Add(A3);

            GridSplitter Spl = new GridSplitter() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Stretch, Width = 5,
                Background = new SolidColorBrush(Colors.Black) };
            Grid.SetColumn(Spl, 1);
            All.Children.Add(Spl);  All.Children.Add(Log);  All.Children.Add(Friends);
            Grid.SetRow(All, 1);
            Own.Children.Add(All);
        }

        private void My_Title()
        {
            row1.Height = new GridLength(this.Height / 14);
            DockPanel own = new DockPanel();
            own.LastChildFill = false;

            first = new Button() { Width = this.Height / 14, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Style = Application.Current.Resources["Circle"] as Style };
            third = new Button() { Width = first.Width, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Style = Application.Current.Resources["Circle"] as Style };
            second = new Button() { Width = first.Width, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Style = Application.Current.Resources["Circle"] as Style };
            first.Content = "X";
            second.Content = "+";
            second.FontSize = third.FontSize = 15;
            third.Content = "_";

            DockPanel.SetDock(first, Dock.Right);  own.Children.Add(first);
            DockPanel.SetDock(second, Dock.Right);   own.Children.Add(second);
            DockPanel.SetDock(third, Dock.Right);   own.Children.Add(third);

            Grid.SetRow(own, 0);
            Own.Children.Add(own);

            first.Click += new RoutedEventHandler(First_Button);
            second.Click += new RoutedEventHandler(Second_Button);
            third.Click += new RoutedEventHandler(Third_Button);
        }

        private void Second_Button(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                second.Content = "-";
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                second.Content = "+";
            }
        }

        private void Third_Button(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void First_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}