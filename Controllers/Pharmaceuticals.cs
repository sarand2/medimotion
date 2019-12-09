using MediMotion.Model;
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
      
    }
}
