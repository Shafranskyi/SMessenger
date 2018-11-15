using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net.Sockets;
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
        public TextBox Tx_mess;

        public MainWindow()
        {
            InitializeComponent();
            main = this;
            //Network.Start_Network();
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
            New_Right.Children.Add(Write_messege);
            
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
            Chat.Items.Add(messege);
        }
        #endregion

        #region Add Friend
        private void Friend()
        {
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
        }
        #endregion

        #region Work place
        private void Work_place()
        {
            //TextBox search = new TextBox()
            //{
            //    Style = Application.Current.Resources["TextBox"] as Style,
            //    Margin = new Thickness(10),
            //    Background = new SolidColorBrush(Color.FromRgb(234, 229, 229)),
            //    FontSize = 15,
            //    FontFamily = new FontFamily("Comic Sans MS"),
            //    VerticalContentAlignment = VerticalAlignment.Center,
            //    BorderThickness = new Thickness(0)
            //};
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

        #region Windows Event
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LC.MaxWidth = Own.ActualWidth / 2;

            //My_Title();

            //Work_place();

            //List_of_friends();

            Messeges();

            //JsoN();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Network.socket.Shutdown(SocketShutdown.Both);
            Network.socket.Close();
        }
        #endregion
    }
}