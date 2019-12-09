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

    public sealed partial class Patients : Page
    {
        private Patient selectedPatient;

        private ObservableCollection<Patient> PatientsList;

        public Patients()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;

            // Get the contacts from a Service
            // Remember to enable the NavigationCacheMode of this Page to avoid
            // load the data every time user navigates back and forward.    
            PatientsList = Patient.GetPatients(140);
            if (PatientsList.Count > 0)
            {
                MasterListView.ItemsSource = PatientsList;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Details view can remove an item from the list.
            if (e.Parameter as string == "Delete")
            {
                DeleteItem(null, null);
            }
            base.OnNavigatedTo(e);
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (selectedPatient == null && PatientsList.Count > 0)
            {
                selectedPatient = PatientsList[0];
                MasterListView.SelectedIndex = 0;
            }
            // If the app starts in narrow mode - showing only the Master listView - 
            // it is necessary to set the commands and the selection mode.
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                VisualStateManager.GoToState(this, MasterState.Name, true);
            }
            else if (PageSizeStatesGroup.CurrentState == WideState)
            {
                // In this case, the app starts is wide mode, Master/Details view, 
                // so it is necessary to set the commands and the selection mode.
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
                MasterListView.SelectionMode = ListViewSelectionMode.Extended;
                MasterListView.SelectedItem = selectedPatient;
            }
            else
            {
                new InvalidOperationException();
            }
        }
        private void OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            bool isNarrow = e.NewState == NarrowState;
            if (isNarrow)
            {
                Frame.Navigate(typeof(DetailsPage), selectedPatient, new SuppressNavigationTransitionInfo());
            }
            else
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
                MasterListView.SelectionMode = ListViewSelectionMode.Extended;
                MasterListView.SelectedItem = selectedPatient;
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PageSizeStatesGroup.CurrentState == WideState)
            {
                if (MasterListView.SelectedItems.Count == 1)
                {
                    selectedPatient = MasterListView.SelectedItem as Patient;
                    EnableContentTransitions();
                }
                // Entering in Extended selection
                else if (MasterListView.SelectedItems.Count > 1
                     && MasterDetailsStatesGroup.CurrentState == MasterDetailsState)
                {
                    VisualStateManager.GoToState(this, ExtendedSelectionState.Name, true);
                }
            }
            // Exiting Extended selection
            if (MasterDetailsStatesGroup.CurrentState == ExtendedSelectionState &&
                MasterListView.SelectedItems.Count == 1)
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
            }
        }
        // ItemClick event only happens when user is a Master state. In this state, 
        // selection mode is none and click event navigates to the details view.
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            // The clicked item it is the new selected contact
            selectedPatient = e.ClickedItem as Patient;
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                // Go to the details page and display the item 
                Frame.Navigate(typeof(DetailsPage), selectedPatient, new DrillInNavigationTransitionInfo());
            }
            //else
            {
                // Play a refresh animation when the user switches detail items.
                //EnableContentTransitions();
            }
        }
        private void EnableContentTransitions()
        {
            DetailContentPresenter.ContentTransitions.Clear();
            DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }
        #region Commands
        private void AddItem(object sender, RoutedEventArgs e)
        {
            Patient c = Patient.GetNewContact();
            PatientsList.Add(c);

            // Select this item in case that the list is empty
            if (MasterListView.SelectedIndex == -1)
            {
                MasterListView.SelectedIndex = 0;
                selectedPatient = MasterListView.SelectedItem as Patient;
                // Details view is collapsed, in case there is not items.
                // You should show it just in case. 
                DetailContentPresenter.Visibility = Visibility.Visible;
            }
        }
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (selectedPatient != null)
            {
                PatientsList.Remove(selectedPatient);

                if (MasterListView.Items.Count > 0)
                {
                    MasterListView.SelectedIndex = 0;
                    selectedPatient = MasterListView.SelectedItem as Patient;
                }
                else
                {
                    // Details view is collapsed, in case there is not items.
                    DetailContentPresenter.Visibility = Visibility.Collapsed;
                    selectedPatient = null;
                }
            }
        }
        private void DeleteItems(object sender, RoutedEventArgs e)
        {
            if (MasterListView.SelectedIndex != -1)
            {
                List<Patient> selectedItems = new List<Patient>();
                foreach (Patient contact in MasterListView.SelectedItems)
                {
                    selectedItems.Add(contact);
                }
                foreach (Patient contact in selectedItems)
                {
                    PatientsList.Remove(contact);
                }
                if (MasterListView.Items.Count > 0)
                {
                    MasterListView.SelectedIndex = 0;
                    selectedPatient = MasterListView.SelectedItem as Patient;
                }
                else
                {
                    DetailContentPresenter.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void SelectItems(object sender, RoutedEventArgs e)
        {
            if (MasterListView.Items.Count > 0)
            {
                VisualStateManager.GoToState(this, MultipleSelectionState.Name, true);
            }
        }
        private void CancelSelection(object sender, RoutedEventArgs e)
        {
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                VisualStateManager.GoToState(this, MasterState.Name, true);
            }
            else
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
            }
        }
        private void ShowSplitView(object sender, RoutedEventArgs e)
        {
            // Clearing the cache
            int cacheSize = ((Frame)Parent).CacheSize;
            ((Frame)Parent).CacheSize = 0;
            ((Frame)Parent).CacheSize = cacheSize;

            //MySamplesPane.SamplesSplitView.IsPaneOpen = !MySamplesPane.SamplesSplitView.IsPaneOpen;
        }
        #endregion
    }
}
