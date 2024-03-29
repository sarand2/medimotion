﻿using MediMotion.Model;
using MediMotion.Scenarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MediMotion
{
    //TODO: Consider load the details asyncronisly. Try to load the data in a Distpacher.
    //TODO: Consider PLM

    public sealed partial class Pharmaceuticals : Page
    {
        private static ContentDialog dialog = null;
        public Pharmaceuticals()
        {
            this.InitializeComponent();
            PharmaceuticalsCVS.Source = Pharmaceutical.GetPharmaceuticalsGrouped(50);

            Window.Current.CoreWindow.KeyDown += ContentDialog_KeyDown;

        }
        public async void pharmaItemClicked(object sender, ItemClickEventArgs e)
        {
             dialog = new ContentDialog()
            {
                Title = "  ⓘ Information",
                IsPrimaryButtonEnabled = false,
                PrimaryButtonText = "",
                Content = new PharmaDetails(),
                MaxWidth = 650,
                MinWidth = 650,
                MinHeight = 800,
                MaxHeight = 800,
                Style = Application.Current.Resources["ScrollableContentDialogStyle"] as Style
            };
            await dialog.ShowAsync();
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
                if(dialog != null)
                    dialog.Hide();
            }
        }
    }
}
