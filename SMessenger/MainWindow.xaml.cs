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
        Button first, third, second, menu;
        Grid MTitle, All, MLeft, MRight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            My_Title();

            Work_place();

        }

        #region Work place
        private void Work_place()
        {
            All = new Grid();
            Grid.SetRow(All, 1);
            ColumnDefinition A1 = new ColumnDefinition
            {
                MaxWidth = Own.ActualWidth / 2,
                MinWidth = 50
            };
            ColumnDefinition A2 = new ColumnDefinition
            {
                Width = new GridLength(5)
            };
            ColumnDefinition A3 = new ColumnDefinition();
            All.ColumnDefinitions.Add(A1);
            All.ColumnDefinitions.Add(A2);
            All.ColumnDefinitions.Add(A3);

            MLeft = new Grid();
            Grid.SetColumn(MLeft, 0);
            RowDefinition Fr1 = new RowDefinition
            {
                Height = new GridLength(50)
            };
            RowDefinition Fr2 = new RowDefinition();
            MLeft.RowDefinitions.Add(Fr1);
            MLeft.RowDefinitions.Add(Fr2);

            Grid Row_Search_and_Menu = new Grid();
            Grid.SetRow(Row_Search_and_Menu, 0);
            ColumnDefinition Fc1 = new ColumnDefinition
            {
                Width = new GridLength(50)
            };
            ColumnDefinition Fc2 = new ColumnDefinition();
            Row_Search_and_Menu.ColumnDefinitions.Add(Fc1);
            Row_Search_and_Menu.ColumnDefinitions.Add(Fc2);

            menu = new Button()
            {
                Style = Application.Current.Resources["Kv"] as Style,
                Margin = new Thickness(5)
            };
            Grid.SetColumn(menu, 0);
            menu.Content = "M";
            menu.FontSize = 15;
            TextBox search = new TextBox()
            {
                Style = Application.Current.Resources["TextBox"] as Style,
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Color.FromRgb(234, 229, 229)),
                FontSize = 15,
                FontFamily = new FontFamily("Comi"),
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(search, 1);

            Row_Search_and_Menu.Children.Add(menu);
            Row_Search_and_Menu.Children.Add(search);
            MLeft.Children.Add(Row_Search_and_Menu);

            GridSplitter Spl = new GridSplitter()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Width = 5,
                Background = new SolidColorBrush(Colors.Black)
            };
            Grid.SetColumn(Spl, 1);

            MRight = new Grid();
            Grid.SetColumn(MRight, 1);

            All.Children.Add(MLeft);
            All.Children.Add(Spl);
            All.Children.Add(MRight);
            
            Own.Children.Add(All);
        }
        #endregion

        #region Create Title
        private void My_Title()
        {
            row1.Height = new GridLength(33);
            MTitle = new Grid();
            ColumnDefinition MT1 = new ColumnDefinition();
            ColumnDefinition MT2 = new ColumnDefinition()
            {
                Width = new GridLength(33 * 3)
            };
            MTitle.ColumnDefinitions.Add(MT1); MTitle.ColumnDefinitions.Add(MT2);
            Grid.SetRow(MTitle, 0);

            DockPanel Title_buttons = new DockPanel
            {
                LastChildFill = false
            };
            Grid.SetColumn(Title_buttons, 1);
            first = new Button()
            {
                Content = "X",
                Width = 33,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Style = Application.Current.Resources["Circle"] as Style
            };
            third = new Button()
            {
                Content = "_",
                Width = first.Width,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Style = Application.Current.Resources["Circle"] as Style,
                FontSize = 15
            };
            second = new Button()
            {
                Content = "+",
                Width = first.Width,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Style = Application.Current.Resources["Circle"] as Style,
                FontSize = 15
            };
            DockPanel.SetDock(first, Dock.Right); Title_buttons.Children.Add(first);
            DockPanel.SetDock(second, Dock.Right); Title_buttons.Children.Add(second);
            DockPanel.SetDock(third, Dock.Right); Title_buttons.Children.Add(third);

            Label Drag = new Label();
            Grid.SetColumn(Drag, 0);

            MTitle.Children.Add(Title_buttons); MTitle.Children.Add(Drag);
            Own.Children.Add(MTitle);

            first.Click += new RoutedEventHandler(First_Button);
            second.Click += new RoutedEventHandler(Second_Button);
            third.Click += new RoutedEventHandler(Third_Button);
            Drag.MouseDown += new MouseButtonEventHandler(DragDown);
        }
        #endregion

        #region MoveWindow
        private void DragDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Title Buttons Events
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
        #endregion
    }
}