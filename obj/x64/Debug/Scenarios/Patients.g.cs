﻿#pragma checksum "C:\Users\PC\Desktop\ZKS projektas\medimotion\Scenarios\Patients.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4A3BAA866B72B375A2777DA143792CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediMotion
{
    partial class Patients : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ContentPresenter_Content(global::Windows.UI.Xaml.Controls.ContentPresenter obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Content = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class Patients_obj8_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPatients_Bindings
        {
            private global::MediMotion.Model.Patient dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj10TextDisabled = false;
            private static bool isobj11TextDisabled = false;

            public Patients_obj8_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 65 && columnNumber == 28)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 71 && columnNumber == 29)
                {
                    isobj11TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 8: // Scenarios\Patients.xaml line 47
                        this.obj8 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Grid)target);
                        break;
                    case 10: // Scenarios\Patients.xaml line 64
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // Scenarios\Patients.xaml line 69
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = 1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj8.Target as global::Windows.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                    case 1:
                        global::Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj10);
                        nextPhase = 2;
                        break;
                    case 2:
                        global::Windows.UI.Xaml.Markup.XamlBindingHelper.ResumeRendering(this.obj11);
                        nextPhase = -1;
                        break;
                }
                this.Update_((global::MediMotion.Model.Patient) item, 1 << phase);
            }

            public void Recycle()
            {
                global::Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj10);
                global::Windows.UI.Xaml.Markup.XamlBindingHelper.SuspendRendering(this.obj11);
            }

            // IPatients_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MediMotion.Model.Patient)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MediMotion.Model.Patient obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0) | (1 << 1))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0) | (1 << 2))) != 0)
                    {
                        this.Update_Position(obj.Position, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 1) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 64
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                    }
                }
            }
            private void Update_Position(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 2) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 69
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class Patients_obj25_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPatients_Bindings
        {
            private global::MediMotion.Model.Patient dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj25;
            private global::Windows.UI.Xaml.Controls.TextBlock obj26;
            private global::Windows.UI.Xaml.Controls.TextBlock obj27;
            private global::Windows.UI.Xaml.Controls.TextBlock obj28;
            private global::Windows.UI.Xaml.Controls.TextBlock obj29;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj26TextDisabled = false;
            private static bool isobj27TextDisabled = false;
            private static bool isobj28TextDisabled = false;
            private static bool isobj29TextDisabled = false;

            public Patients_obj25_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 188 && columnNumber == 36)
                {
                    isobj26TextDisabled = true;
                }
                else if (lineNumber == 191 && columnNumber == 36)
                {
                    isobj27TextDisabled = true;
                }
                else if (lineNumber == 194 && columnNumber == 36)
                {
                    isobj28TextDisabled = true;
                }
                else if (lineNumber == 198 && columnNumber == 36)
                {
                    isobj29TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 25: // Scenarios\Patients.xaml line 185
                        this.obj25 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 26: // Scenarios\Patients.xaml line 186
                        this.obj26 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 27: // Scenarios\Patients.xaml line 189
                        this.obj27 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 28: // Scenarios\Patients.xaml line 192
                        this.obj28 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 29: // Scenarios\Patients.xaml line 195
                        this.obj29 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj25.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::MediMotion.Model.Patient) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IPatients_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MediMotion.Model.Patient)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MediMotion.Model.Patient obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                        this.Update_Position(obj.Position, phase);
                        this.Update_PhoneNumber(obj.PhoneNumber, phase);
                        this.Update_Biography(obj.Biography, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 186
                    if (!isobj26TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj26, obj, null);
                    }
                }
            }
            private void Update_Position(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 189
                    if (!isobj27TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj27, obj, null);
                    }
                }
            }
            private void Update_PhoneNumber(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 192
                    if (!isobj28TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj28, obj, null);
                    }
                }
            }
            private void Update_Biography(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Scenarios\Patients.xaml line 195
                    if (!isobj29TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj29, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class Patients_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPatients_Bindings
        {
            private global::MediMotion.Patients dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ContentPresenter obj23;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj23ContentDisabled = false;

            private Patients_obj1_BindingsTracking bindingsTracking;

            public Patients_obj1_Bindings()
            {
                this.bindingsTracking = new Patients_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 182 && columnNumber == 17)
                {
                    isobj23ContentDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 23: // Scenarios\Patients.xaml line 175
                        this.obj23 = (global::Windows.UI.Xaml.Controls.ContentPresenter)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IPatients_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MediMotion.Patients)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MediMotion.Patients obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_MasterListView(obj.MasterListView, phase);
                    }
                }
            }
            private void Update_MasterListView(global::Windows.UI.Xaml.Controls.ListView obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_MasterListView(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_MasterListView_SelectedItem(obj.SelectedItem, phase);
                    }
                }
            }
            private void Update_MasterListView_SelectedItem(global::System.Object obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Scenarios\Patients.xaml line 175
                    if (!isobj23ContentDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentPresenter_Content(this.obj23, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class Patients_obj1_BindingsTracking
            {
                private global::System.WeakReference<Patients_obj1_Bindings> weakRefToBindingObj; 

                public Patients_obj1_BindingsTracking(Patients_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<Patients_obj1_Bindings>(obj);
                }

                public Patients_obj1_Bindings TryGetBindingObject()
                {
                    Patients_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_MasterListView(null);
                }

                public void DependencyPropertyChanged_MasterListView_SelectedItem(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    Patients_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::Windows.UI.Xaml.Controls.ListView obj = sender as global::Windows.UI.Xaml.Controls.ListView;
                        if (obj != null)
                        {
                            bindings.Update_MasterListView_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                        }
                    }
                }
                private global::Windows.UI.Xaml.Controls.ListView cache_MasterListView = null;
                private long tokenDPC_MasterListView_SelectedItem = 0;
                public void UpdateChildListeners_MasterListView(global::Windows.UI.Xaml.Controls.ListView obj)
                {
                    if (obj != cache_MasterListView)
                    {
                        if (cache_MasterListView != null)
                        {
                            cache_MasterListView.UnregisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, tokenDPC_MasterListView_SelectedItem);
                            cache_MasterListView = null;
                        }
                        if (obj != null)
                        {
                            cache_MasterListView = obj;
                            tokenDPC_MasterListView_SelectedItem = obj.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty, DependencyPropertyChanged_MasterListView_SelectedItem);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Scenarios\Patients.xaml line 33
                {
                    this.SelectItmesBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.SelectItmesBtn).Click += this.SelectItems;
                }
                break;
            case 3: // Scenarios\Patients.xaml line 38
                {
                    this.AddItemBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.AddItemBtn).Click += this.AddItem;
                }
                break;
            case 4: // Scenarios\Patients.xaml line 39
                {
                    this.DeleteItemBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.DeleteItemBtn).Click += this.DeleteItem;
                }
                break;
            case 5: // Scenarios\Patients.xaml line 40
                {
                    this.DeleteItemsBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.DeleteItemsBtn).Click += this.DeleteItems;
                }
                break;
            case 6: // Scenarios\Patients.xaml line 41
                {
                    this.CancelSelectionBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.CancelSelectionBtn).Click += this.CancelSelection;
                }
                break;
            case 7: // Scenarios\Patients.xaml line 46
                {
                    this.ContactListViewTemplate = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 12: // Scenarios\Patients.xaml line 90
                {
                    this.PageSizeStatesGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                    ((global::Windows.UI.Xaml.VisualStateGroup)this.PageSizeStatesGroup).CurrentStateChanged += this.OnCurrentStateChanged;
                }
                break;
            case 13: // Scenarios\Patients.xaml line 115
                {
                    this.MasterDetailsStatesGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 14: // Scenarios\Patients.xaml line 117
                {
                    this.MasterState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 15: // Scenarios\Patients.xaml line 123
                {
                    this.MasterDetailsState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 16: // Scenarios\Patients.xaml line 129
                {
                    this.ExtendedSelectionState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 17: // Scenarios\Patients.xaml line 133
                {
                    this.MultipleSelectionState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 18: // Scenarios\Patients.xaml line 93
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 19: // Scenarios\Patients.xaml line 105
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 20: // Scenarios\Patients.xaml line 151
                {
                    this.MasterColumn = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 21: // Scenarios\Patients.xaml line 152
                {
                    this.DetailColumn = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 22: // Scenarios\Patients.xaml line 160
                {
                    this.MasterListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MasterListView).SelectionChanged += this.OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MasterListView).ItemClick += this.OnItemClick;
                }
                break;
            case 23: // Scenarios\Patients.xaml line 175
                {
                    this.DetailContentPresenter = (global::Windows.UI.Xaml.Controls.ContentPresenter)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Scenarios\Patients.xaml line 13
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Patients_obj1_Bindings bindings = new Patients_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 8: // Scenarios\Patients.xaml line 47
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element8 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    Patients_obj8_Bindings bindings = new Patients_obj8_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element8.DataContext);
                    element8.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element8, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element8, bindings);
                }
                break;
            case 25: // Scenarios\Patients.xaml line 185
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element25 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    Patients_obj25_Bindings bindings = new Patients_obj25_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element25.DataContext);
                    element25.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element25, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element25, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

