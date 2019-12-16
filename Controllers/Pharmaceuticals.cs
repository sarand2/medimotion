using MediMotion.Model;
using MediMotion.Scenarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public Pharmaceuticals()
        {
            this.InitializeComponent();
            PharmaceuticalsCVS.Source = Pharmaceutical.GetPharmaceuticalsGrouped(50);
        }
        public async void pharmaItemClicked(object sender, ItemClickEventArgs e)
        {
            //ContentDialog dialog = new ContentDialog()
            //{
            //    Title = "  ⓘ Information",
            //    IsPrimaryButtonEnabled = true,
            //    PrimaryButtonText = "Close",
            //    Content = new PharmaDetails(),//new PharmaDetails(), // new PharmaDetails()
            //    MaxWidth = 650,
            //    MinWidth = 650,
            //    MinHeight = 800,
            //    MaxHeight = 800,
            //    Style = Application.Current.Resources["ScrollableContentDialogStyle"] as Style
            //};
            ContentDialog dialog = new ContentDialog()
            {
                Title = " ⓘ Information",
                Content = new ExampleControl(),
                MaxWidth = 2200,
                MinWidth = 2200,
                MinHeight = 1200,
                MaxHeight = 1200,
                IsPrimaryButtonEnabled = false,
                Style = Application.Current.Resources["ScrollableContentDialogStyle"] as Style
            };
            await dialog.ShowAsync();
        }
    }
}
