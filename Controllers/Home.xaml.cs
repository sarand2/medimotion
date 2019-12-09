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

using MediMotion.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MediMotion
{
   
    public sealed partial class Home : Page
    {
        private MainPage rootPage;

        // What is the program's last known full-screen state?
        // We use this to detect when the system forced us out of full-screen mode.
        private bool isLastKnownFullScreen = ApplicationView.GetForCurrentView().IsFullScreenMode;
        private ObservableCollection<ActivePatient> activePatients = new ObservableCollection<ActivePatient>();
        private ObservableCollection<ActivePatient> activePatientsToday = new ObservableCollection<ActivePatient>();
        public Home()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            activePatients = ActivePatient.getActivePatients(100);
            getActivePatientsToday();

        }
        private void getActivePatientsToday()
        {
            List<ActivePatient> tempList = new List<ActivePatient>();
            foreach(ActivePatient patient in activePatients)
            {
                String[] splitted = patient.Date.Split('-');
                int year = int.Parse(splitted[0]);
                int month = int.Parse(splitted[1]);
                int day = int.Parse(splitted[2]);
                int hours = int.Parse(splitted[3]);
                int minutes = int.Parse(splitted[4]);
                if(DateTimeOffset.Now.Year == year && DateTimeOffset.Now.Month == month && DateTimeOffset.Now.Day == day)
                {
                    string date = hours + ":";
                    if (minutes.ToString().Length == 1)
                    {
                        date += "0" + minutes.ToString();
                    }
                    else
                    {
                        date += minutes.ToString();
                    }
                    ActivePatient temp = new ActivePatient()
                    {
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        Category = patient.Category,
                        Method = patient.Method,
                        Date = date
                    };
                    tempList.Add(temp);
                }
            }
            tempList.Sort();
            foreach(ActivePatient patient in tempList)
            {
                activePatientsToday.Add(patient);
            }
        }
        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender,
                                   CalendarViewDayItemChangingEventArgs args)
        {
            // Render basic day items.
            if (args.Phase == 0)
            {
                // Register callback for next phase.
                args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
            }
            // Set blackout dates.
            else if (args.Phase == 1)
            {
                // Blackout dates in the past, Sundays, and dates that are fully booked.
                if (args.Item.Date < DateTimeOffset.Now ||
                    args.Item.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    args.Item.IsBlackout = true;
                }
                if (args.Item.Date.Month == 12 && args.Item.Date.Day == 24 || args.Item.Date.Day==25 || args.Item.Date.Day == 31)
                {
                    args.Item.IsBlackout = true;
                }
                // Register callback for next phase.
                args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
            }
            // Set density bars.
            else if (args.Phase == 2)
            {
                // Avoid unnecessary processing.
                // You don't need to set bars on past dates or Sundays.
                if (args.Item.Date > DateTimeOffset.Now &&
                    args.Item.Date.DayOfWeek != DayOfWeek.Sunday)
                {
                    // Get bookings for the date being rendered.

                    //var currentBookings = Bookings.GetBookings(args.Item.Date);

                    List<Windows.UI.Color> densityColors = new List<Windows.UI.Color>();
                    // Set a density bar color for each of the days bookings.
                    // It's assumed that there can't be more than 10 bookings in a day. Otherwise,
                    // further processing is needed to fit within the max of 10 density bars.
                    foreach (ActivePatient patient in activePatients)
                    {
                            String[] splitted = patient.Date.Split('-');
                            int year = int.Parse(splitted[0]);
                            int month = int.Parse(splitted[1]);
                            int day = int.Parse(splitted[2]);

                            if (args.Item.Date.Year == year && args.Item.Date.Month == month && args.Item.Date.Day == day && args.Item.IsBlackout == false)
                            {
                                densityColors.Add(Colors.Green);
                            }
                    }
                    args.Item.SetDensityColors(densityColors);
                }
            }
        }

     
        void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                var view = ApplicationView.GetForCurrentView();
                if (view.IsFullScreenMode)
                {
                    view.ExitFullScreenMode();
                    rootPage.NotifyUser("Exited full screen mode due to keypress", NotifyType.StatusMessage);
                    isLastKnownFullScreen = false;
                }
            }
        }
    }
}
