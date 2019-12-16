using MediMotion.DataModel;
using MediMotion.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MediMotion.Scenarios
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TileDetails : Page
    {
        private UIElement cachedSecondaryCommandPanel = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedDetails"/> class.
        /// </summary>
        public TileDetails()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += ContentDialog_KeyDown;
            Loaded += FeedDetails_Loaded;
        }

        public void UpdateBindings()
        {
            // feeditems.Loaded += (s, ev) => feeditems.ScrollIntoView(ViewModel.PersistedEpisode, ScrollIntoViewAlignment.Leading);
        }

        private void FeedDetails_Loaded(object sender, RoutedEventArgs e)
        {
           // btnrefresh.Focus(FocusState.Programmatic);

            Loaded -= FeedDetails_Loaded;
        }
        public Feed CurrentFeed { get; private set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Canvas.SetZIndex(this, 0);
            if (e.Parameter is Feed)
            {
                CurrentFeed = (Feed)e.Parameter;
            }
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            Canvas.SetZIndex(this, 1);
        }
        private static bool IsEscPressed()
        {
            var escState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Escape);
            return (escState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }
        private void ContentDialog_KeyDown(CoreWindow window, KeyEventArgs e)
        {
            if (IsEscPressed())
            {
                MainPage.MainScenarioFrame.Navigate(typeof(TilePage));
            }
        }
    }
}
