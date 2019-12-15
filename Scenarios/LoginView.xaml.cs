using MediMotion.Utilites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MediMotion.Scenarios
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        public LoginView()
        {
            this.InitializeComponent();

        }
        public async Task UpdateLock()
        {
           await Task.Run(async () =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    var imageSource = new BitmapImage(new Uri("ms-appx:///Images/voice_reco.gif"));
                    voicereco.Source = imageSource;
                    voicereco.Visibility = Visibility.Visible;
                    playVoice.Play();
                    await Task.Delay(4500);
                    lock_icon.Source = new BitmapImage(new Uri("ms-appx:///Images/lock_gif.gif"));
                    lock_icon.Source = new BitmapImage(new Uri("ms-appx:///Images/lock_gif.gif"));
                    await Task.Delay(3500);
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Confirmation",
                        MaxWidth = this.ActualWidth,
                        IsPrimaryButtonEnabled = false,
                        Content = new AuthentificationMessage()
                    };
                    voicereco.Source = null;
                    dialog.ShowAsync();
                    await Task.Delay(2000);
                    dialog.Hide();

                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(MainPage));
                    //lock_icon.Source = new BitmapImage(new Uri("ms-appx:///Images/lock_modern_unlocked.png"));
                    //  RadialProgressBarControl.Visibility = Visibility.Collapsed;
                });
            });
        }
        private async Task ProgressRingUpdate()
        {
            Random random = new Random();
            await Task.Run( async () =>
            {
                int max_times = 20;
                int times = 0;
                while (true)
                {
                    _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                      {
                          //RadialProgressBarControl.Value = random.Next(150, 340) * -1;

                      });
                    times++;
                    if (times < max_times)
                         await Task.Delay(100);
                    else
                    {
                        return;
                    }
                }
            });

            await Task.Run(async  () => 
            {
                _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                   // RadialProgressBarControl.Outline = new SolidColorBrush(Windows.UI.Colors.LawnGreen);
                });
                for (int i = 0; i < 365; i= i+5)
                {
                    _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                      {
                       //   RadialProgressBarControl.Value = i * -1;
                      });
                    await Task.Delay(1);
                }
                _ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                   // RadialProgressBarControl.Visibility = Visibility.Collapsed;
                });
            });

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _currentEffectMode = EffectMode.None;
        }

        // for icon animations
        Compositor _compositor = Window.Current.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void element_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Scale up to 1.5
            CreateOrUpdateSpringAnimation(1.2f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void element_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Scale back down to 1.0
            CreateOrUpdateSpringAnimation(1.0f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }
    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };

    protected override async void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                DoEffectOut();
                await Task.Delay(100);
            }
            base.OnKeyDown(e);
        }

        private async void OnShowLoginWithPassword(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            //passwordBox.Focus(FocusState.Programmatic);
        }

        private void OnBackgroundFocus(object sender, RoutedEventArgs e)
        {
            DoEffectIn();
        }

        private void OnForegroundFocus(object sender, RoutedEventArgs e)
        {
            DoEffectOut();
        }

        private EffectMode _currentEffectMode = EffectMode.None;

        private void DoEffectIn(double milliseconds = 1000)
        {
            if (_currentEffectMode == EffectMode.Foreground || _currentEffectMode == EffectMode.None)
            {
                _currentEffectMode = EffectMode.Background;
                background.Scale(milliseconds, 1.0, 1.1);
                background.Blur(milliseconds, 6.0, 0.0);
                foreground.Scale(500, 1.0, 0.95);
                foreground.Fade(milliseconds, 1.0, 0.75);
            }
        }

        private void DoEffectOut(double milliseconds = 1000)
        {
            if (_currentEffectMode == EffectMode.Background || _currentEffectMode == EffectMode.None)
            {
                _currentEffectMode = EffectMode.Foreground;
                background.Scale(milliseconds, 1.1, 1.0);
                background.Blur(milliseconds, 0.0, 6.0);
                foreground.Scale(500, 0.95, 1.0);
                foreground.Fade(milliseconds, 0.75, 1.0);
            }
        }

        public enum EffectMode
        {
            None,
            Background,
            Foreground,
            Disabled
        }

        private async void Login_click(object sender, RoutedEventArgs e)
        {
          //  RadialProgressBarControl.Visibility = Visibility.Visible;
           // await System.Threading.Tasks.Task.Run(() => ProgressRingUpdate());
            await UpdateLock();
        }

        private async void Close_click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
