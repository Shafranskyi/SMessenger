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
using System.Windows.Shapes;
using SMessenger.Controls;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SMessenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;
        Button first, third, second, menu;
        Grid MTitle, All, MLeft, MRight;
        ListView LMesseges;
        public TextBox Tx_mess;

        public MainWindow()
        {
            InitializeComponent();
            main = this;
            Network.Start_Network();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            My_Title();

            Work_place();

            List_of_friends();

            Messeges();

            //JsoN();
        }

        #region Json
        private void JsoN()
        {
            Person person1 = new Person("Tom", "Readl", 29);
            Person person2 = new Person("Bill", "Gates", 25);
            Person[] people = new Person[] { person1, person2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, people);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.ReadObject(fs);

                foreach (Person p in newpeople)
                {
                   MessageBox.Show($"{p.Name}, {p.Surname}, {p.Age}");
                }
            }
        }
        #endregion

        #region Chat
        private void Messeges()
        {
            LMesseges = new ListView()
            {
                ItemContainerStyle = Application.Current.Resources["ListViewItemOptionStyle"] as Style,
                Background = Application.Current.Resources["WordBlueBrush"] as Brush
            };
            Grid.SetRow(LMesseges, 0);
            MRight.Children.Add(LMesseges);

            Grid Write_messege = new Grid();
            Grid.SetRow(Write_messege, 1);
            ColumnDefinition Wr1 = new ColumnDefinition()
            {
                Width = new GridLength(((this.Width - 5) / 2) - 60)
            };
            ColumnDefinition Wr2 = new ColumnDefinition();
            Write_messege.ColumnDefinitions.Add(Wr1);
            Write_messege.ColumnDefinitions.Add(Wr2);
            
            Tx_mess = new TextBox()
            {
                FontSize = 10
            };
            Grid.SetColumn(Tx_mess, 0);

            Button Send = new Button()
            {
                Style = Application.Current.Resources["Kv"] as Style,
                Width = 50,
                Height = 30,
                Content = "Send"
            };
            Send.Click += new RoutedEventHandler(Send_Click);
            Grid.SetColumn(Send, 1);

            Write_messege.Children.Add(Tx_mess);
            Write_messege.Children.Add(Send);
            MRight.Children.Add(Write_messege);

            MessageBox.Show(Tx_mess.ActualWidth.ToString());
        }
        #endregion

        #region Create Messege
        public void Create_Messege(string Messege)
        {
            MessegeBubble d = new MessegeBubble();
            d.Path_.HorizontalAlignment = d.Grid_.HorizontalAlignment = HorizontalAlignment.Right;
            d.Time.HorizontalAlignment = HorizontalAlignment.Left;
            d.Prof_name.Visibility = Visibility.Hidden;
            d.Text_mess.Text = Messege;

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

            Grid Tx = new Grid();
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
                Margin = new Thickness(5),
                Content = "M",
                FontSize = 15
            };
            Grid.SetColumn(menu, 0);
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
            RowDefinition Mr1 = new RowDefinition();
            RowDefinition Mr2 = new RowDefinition()
            {
                Height = new GridLength(100)
            };
            MRight.RowDefinitions.Add(Mr1);
            MRight.RowDefinitions.Add(Mr2);
            
            All.Children.Add(MLeft);
            All.Children.Add(Spl);
            All.Children.Add(MRight);

            Own.Children.Add(All);
        }
        #endregion

        #region Create Title
        private void My_Title()
        {
            try
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
                    Style = Application.Current.Resources["Circle"] as Style
                };
                third = new Button()
                {
                    Content = "_",
                    Width = first.Width,
                    FontSize = 15,
                    Style = Application.Current.Resources["Circle"] as Style
                };
                second = new Button()
                {
                    Content = "+",
                    Width = first.Width,
                    FontSize = 15,
                    Style = Application.Current.Resources["Circle"] as Style
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
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
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

        #region Events
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Network.Send();
        }
        #endregion
    }
}