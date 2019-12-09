//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MediMotion
{
   
    public sealed partial class Reference : Page
    {
        private MainPage rootPage;
     
        // What is the program's last known full-screen state?
        // We use this to detect when the system forced us out of full-screen mode.
        private bool isLastKnownFullScreen = ApplicationView.GetForCurrentView().IsFullScreenMode;

        public Reference()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            
        }

        private void PubMed_Click(object sender, RoutedEventArgs e)
        {
            webView1.Navigate(new System.Uri("https://www.ncbi.nlm.nih.gov/pubmed/"));
        }
        private void Drugs_Click(object sender, RoutedEventArgs e)
        {
            webView1.Navigate(new System.Uri("https://www.drugs.com/"));
        }
        private void Ovid_Click(object sender, RoutedEventArgs e)
        {
            webView1.Navigate(new System.Uri("https://www.ovid.com/")); 
        }
        private void Science_Click(object sender, RoutedEventArgs e)
        {
            webView1.Navigate(new System.Uri("https://www.sciencedirect.com/"));
        }
    }
}
