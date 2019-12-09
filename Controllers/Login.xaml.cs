
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace MediMotion
{

    public sealed partial class Login : Page
    {
        public static Login Current;
        private const int ButtonSize = 100;

        private const int WsExNoactivate = 0x08000000;
        private const int GwlExstyle = -20;

        public Login()
        {
            this.InitializeComponent();
            Current = this;
            userTextBox.AddHandler(TappedEvent, new TappedEventHandler(userTextBoxTapped), true);
            passTextBox.AddHandler(TappedEvent, new TappedEventHandler(passTextBoxTapped), true);

        }

        private void createKeyboard()
        {
            if (keyboardInput.Children != null)
            {
                keyboardInput.Children.Clear();
            }
            if (numericInput.Children != null)
            {
                numericInput.Children.Clear();
            }

            for (var i = 0; i < 10; i++)
            {
                numericInput.Children.Add(new Button { Content = i.ToString(), Width = 120, Height = 70 });
            }

            for (var c = 'a'; c <= 'z'; c++)
            {
                keyboardInput.Children.Add(new Button { Content = c, Width = 120, Height = 55 });
            }

            keyboardInput.Children.Add(new Button { Content = ';', Width = 120, Height = 55 });
            keyboardInput.Children.Add(new Button { Content = ':', Width = 120, Height = 55 });
            keyboardInput.Children.Add(new Button { Content = ',', Width = 120, Height = 55 });
            keyboardInput.Children.Add(new Button { Content = '.', Width = 120, Height = 55 });
        }
        private void userTextBoxTapped(object sender, TappedRoutedEventArgs e)
        {
            createKeyboard();
            foreach (Button button in numericInput.Children)
            {
                button.Click += user_Button_Click;
            }
            foreach (Button button in keyboardInput.Children)
            {
                button.Click += user_Button_Click;
            }
        }
        private void passTextBoxTapped(object sender, TappedRoutedEventArgs e)
        {
            createKeyboard();
            foreach (Button button in numericInput.Children)
            {
                button.Click += pass_Button_Click;
            }
            foreach (Button button in keyboardInput.Children)
            {
                button.Click += pass_Button_Click;
            }

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(this.userTextBox.Text == "house" && this.passTextBox.Password == "house")
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainPage));
            } else
            {
                this.userTextBox.Background = new SolidColorBrush(Colors.Red);
                this.passTextBox.Background= new SolidColorBrush(Colors.Red);
            }
        }
            
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        private void user_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var chars = button.Content.ToString().ToCharArray();
            if (chars.Length == 0)
            {
                return;
            }
            this.userTextBox.Text = this.userTextBox.Text += chars[0];
        }
        private void pass_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var chars = button.Content.ToString().ToCharArray();
            if (chars.Length == 0)
            {
                return;
            }
            this.passTextBox.Password = this.passTextBox.Password += chars[0];
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    }

}
