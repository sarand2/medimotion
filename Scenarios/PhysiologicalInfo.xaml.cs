using MediMotion.DataModel;
using MediMotion.Model;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MediMotion.Scenarios
{
    public sealed partial class PhysiologicalInfo : ContentDialog, INotifyPropertyChanged
    {
        private Compositor _compositor;
        public ObservableCollection<Pose> PoseData { get; set; } = new ObservableCollection<Pose>();
        public ObservableCollection<Timing> WorkoutTimings { get; set; } = new ObservableCollection<Timing>();
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        public PhysiologicalInfo()
        {
            GenerateTimings();
            GeneratePoses();
            GeneratePictures();
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += ContentDialog_KeyDown;

            _compositor = ElementCompositionPreview.GetElementVisual(this)?.Compositor;


            var _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            var t = this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                _timer.Interval = TimeSpan.FromMilliseconds(1000);
                if (!_timer.IsEnabled)
                {
                    _timer.Start();
                }
            });
        }

        private int _animationDuration = 400;
        private void PhotoCollectionViewer_ChoosingItemContainer(ListViewBase sender,
            ChoosingItemContainerEventArgs args)
        {
            args.ItemContainer = args.ItemContainer ?? new GridViewItem();

            var fadeIn = _compositor.CreateScalarKeyFrameAnimation();
            fadeIn.Target = "Opacity";
            fadeIn.Duration = TimeSpan.FromMilliseconds(_animationDuration);
            fadeIn.InsertKeyFrame(0, 0);
            fadeIn.InsertKeyFrame(1, 1);
            fadeIn.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
            fadeIn.DelayTime = TimeSpan.FromMilliseconds(_animationDuration * 0.125 * args.ItemIndex);

            var fadeOut = _compositor.CreateScalarKeyFrameAnimation();
            fadeOut.Target = "Opacity";
            fadeOut.Duration = TimeSpan.FromMilliseconds(_animationDuration);
            fadeOut.InsertKeyFrame(1, 0);

            var scaleIn = _compositor.CreateVector3KeyFrameAnimation();
            scaleIn.Target = "Scale";
            scaleIn.Duration = TimeSpan.FromMilliseconds(_animationDuration);
            scaleIn.InsertKeyFrame(0f, new Vector3(1.2f, 1.2f, 1.2f));
            scaleIn.InsertKeyFrame(1f, new Vector3(1f, 1f, 1f));
            scaleIn.DelayBehavior = AnimationDelayBehavior.SetInitialValueBeforeDelay;
            scaleIn.DelayTime = TimeSpan.FromMilliseconds(_animationDuration * 0.125 * args.ItemIndex);

            // animations set to run at the same time are grouped
            var animationFadeInGroup = _compositor.CreateAnimationGroup();
            animationFadeInGroup.Add(fadeIn);
            animationFadeInGroup.Add(scaleIn);

            // Set up show and hide animations for this item container before the element is added to the tree.
            // These fire when items are added/removed from the visual tree, including when you set Visibilty
            ElementCompositionPreview.SetImplicitShowAnimation(args.ItemContainer, animationFadeInGroup);
            ElementCompositionPreview.SetImplicitHideAnimation(args.ItemContainer, fadeOut);
        }
        private void PhotoCollectionViewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            //App.MainFrame.Navigate(typeof(ImageEditingPage), e.ClickedItem as Photo);
        }

        private void GalleryItem_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            ScaleImage(frameworkElement, 1f);
        }

        private void GalleryItem_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            ScaleImage(frameworkElement, 1.1f);
        }

        private void ScaleImage(FrameworkElement frameworkElement, float scaleAmout)
        {
            var element = ElementCompositionPreview.GetElementVisual(frameworkElement);

            var scaleAnimation = _compositor.CreateVector3KeyFrameAnimation();
            scaleAnimation.Duration = TimeSpan.FromMilliseconds(500);
            scaleAnimation.InsertKeyFrame(1f, new Vector3(scaleAmout, scaleAmout, scaleAmout));

            element.CenterPoint = new Vector3((float)frameworkElement.ActualHeight / 2,
                (float)frameworkElement.ActualWidth / 2, 275f / 2);
            element.StartAnimation("Scale", scaleAnimation);

            if (scaleAmout > 1)
            {
                var shadow = _compositor.CreateDropShadow();
                shadow.Offset = new Vector3(15, 15, -10);
                shadow.BlurRadius = 5;
                shadow.Color = Colors.DarkGray;

                var sprite = _compositor.CreateSpriteVisual();
                sprite.Size = new Vector2((float)frameworkElement.ActualWidth - 20,
                    (float)frameworkElement.ActualHeight - 20);
                sprite.Shadow = shadow;

               // ElementCompositionPreview.SetElementChildVisual((UIElement)frameworkElement.FindName("Shadow"), sprite);
            }

        }
       
        private void GeneratePictures()
        {
            for (var i = 0; i < 5; i++)
                Photos.Add(new Photo
                {
                    Path = string.Format("/Images/xrays/xray{0}.png", i + 1)
                }); 
        }

        private void _timer_Tick(object sender, object e)
        {
            HeartLogoFill.Fade(1, 50).Then().Fade(0).Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void GenerateTimings()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            for (int i = 1; i < 32; i++)
            {
                WorkoutTimings.Add(new Timing { Day = i, Minutes = random.Next(160) });
            }
        }
        private void GeneratePoses()
        {
            var data = Pose.GeneratePoses();
            for (int i = 0; i < data.Count; i++)
            {
                PoseData.Add(new Pose { Name = data[i].Name, Comment = data[i].Comment, Position = data[i].Position, Score = data[i].Score });
            }
        }

        private double _pageWidth = 1000.0;
        private int barMargin = 5;
        private void Graph_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            var workoutTiming = args.Item as Timing;

            args.ItemContainer.MinWidth = (_pageWidth / 31) + barMargin;

            var bar = args.ItemContainer.ContentTemplateRoot as FrameworkElement;
            bar.Width = (_pageWidth / 31);

            var sprite = _compositor.CreateSpriteVisual();
            sprite.Size = new System.Numerics.Vector2((float)bar.Width, (float)workoutTiming.Minutes);
            sprite.Offset = new System.Numerics.Vector3(0f, (float)(-workoutTiming.Minutes) - 4, 0f);
            sprite.CenterPoint = new System.Numerics.Vector3(0f, (float)(workoutTiming.Minutes) + 4, 0f);
            var solidColorBrush = Application.Current.Resources["HighlightColor"] as SolidColorBrush;
            sprite.Brush = _compositor.CreateColorBrush(solidColorBrush.Color);

            var scaleAnimation = _compositor.CreateVector3KeyFrameAnimation();
            scaleAnimation.Duration = TimeSpan.FromMilliseconds(1000);
            scaleAnimation.InsertKeyFrame(0f, new System.Numerics.Vector3(1f, 0f, 0f));
            scaleAnimation.InsertKeyFrame(1f, new System.Numerics.Vector3(1f, 1f, 1f));
            sprite.StartAnimation("Scale", scaleAnimation);

            ElementCompositionPreview.SetElementChildVisual(VisualTreeHelper.GetChild(bar, 0) as UIElement, sprite);
        }
        private static bool IsEscPressed()
        {
            var escState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Escape);
            return (escState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }
        private void ContentDialog_KeyDown(CoreWindow window, KeyEventArgs e)
        {
            var a = 5+4;
            if (IsEscPressed())
            {
                this.Hide();
            }
        }
    }
}
