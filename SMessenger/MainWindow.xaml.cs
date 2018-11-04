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
        ListView LMesseges;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            My_Title();

            Work_place();

            List_of_friends();

            Messeges();
        }

        #region Chat
        private void Messeges()
        {
            LMesseges = new ListView()
            {
                ItemContainerStyle = Application.Current.Resources["ListViewItemOptionStyle"] as Style,
                Background = Application.Current.Resources["WordBlueBrush"] as Brush
            };
            MRight.Children.Add(LMesseges);

            for (int i = 0; i < 10; ++i)
            {
                MessegeBubble d = new MessegeBubble();
                if (i == 1 || i == 4 || i == 5)
                {
                    d.Path_.HorizontalAlignment = d.Grid_.HorizontalAlignment = HorizontalAlignment.Right;
                    d.Time.HorizontalAlignment = HorizontalAlignment.Left;
                    d.Prof_name.Visibility = Visibility.Hidden;
                    d.Text_mess.Text = "444444444444444sd888888f55555555555555555555555555555555555555svhfshd";
                }
                else
                    d.Text_mess.Text = "jdbfhdbfh";
                d.Text_mess.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                Size size = d.Text_mess.DesiredSize;
                if (size.Width > 250)
                    d.Grid_.Width = 250;

                StackPanel messege = new StackPanel()
                {
                    Height = d.Height,
                    Width = ((this.Width - 5) / 2) - 15
                };

                messege.Children.Add(d);
                LMesseges.Items.Add(messege);
            }
        }
        #endregion

        #region List Friends
        private void List_of_friends()
        {
            ListView friends = new ListView();
            Grid.SetRow(friends, 1);

            StackPanel friend = new StackPanel()
            {
                Height = 50,
                Orientation = Orientation.Horizontal
            };

            Grid F = new Grid()
            {
                //ShowGridLines = true,
                Width = ((this.Width - 5) / 2) - 25
            };
           
            ColumnDefinition Ig = new ColumnDefinition()
            {
                Width = new GridLength(50)
            };
            ColumnDefinition An = new ColumnDefinition();
            F.ColumnDefinitions.Add(Ig);
            F.ColumnDefinitions.Add(An);

            Ellipse Im = new Ellipse()
            {
                Height = 50,
                Width = 50
            };
            ImageBrush myBrush = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"C:\Users\shafr\Desktop\1.jpg")),
                Stretch = Stretch.UniformToFill,
            };
            Im.Fill = myBrush;
            Grid.SetColumn(Im, 0);

            Grid Tx = new Grid()
            {
                //ShowGridLines = true
            };
            Grid.SetColumn(Tx, 1);
            RowDefinition Rtx_title = new RowDefinition()
            {
                Height = new GridLength(20)
            };
            RowDefinition Rtx = new RowDefinition();
            Tx.RowDefinitions.Add(Rtx_title);
            Tx.RowDefinitions.Add(Rtx);

            TextBlock tx_title = new TextBlock()
            {
                Text = "1111111111",
                FontSize = 15,
                FontFamily = new FontFamily("Comic Sans MS"),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(tx_title, 0);

            TextBlock tx = new TextBlock()
            {
                Text = "ssdfsdf555555555555555555555555555555555555555555555555555555555555555555555555555555555555",
                FontSize = 15,
                FontFamily = new FontFamily("Comic Sans MS"),
                VerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            Grid.SetRow(tx, 1);

            Tx.Children.Add(tx_title);
            Tx.Children.Add(tx);
            F.Children.Add(Im);
            F.Children.Add(Tx);
            friend.Children.Add(F);
            friends.Items.Add(friend);
            MLeft.Children.Add(friends);
        }
        #endregion

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
                FontFamily = new FontFamily("Comic Sans MS"),
                VerticalContentAlignment = VerticalAlignment.Center,
                BorderThickness = new Thickness(0)
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
            Grid.SetColumn(MRight, 2);

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