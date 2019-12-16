using MediMotion.Data;
using MediMotion.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MediMotion.Scenarios
{
    public sealed partial class ExampleControl : UserControl, INotifyPropertyChanged
    {
        private Compositor _compositor;
          
        public ExampleControl()
        {

            GenerateTimings();
            this.InitializeComponent();
            _compositor = ElementCompositionPreview.GetElementVisual(this)?.Compositor;
        }
        public ObservableCollection<Timing> WorkoutTimings { get; set; } = new ObservableCollection<Timing>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void GenerateTimings()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            for (int i = 1; i < 32; i++)
            {
                WorkoutTimings.Add(new Timing { Day = i, Minutes = random.Next(90) });
            }
        }
        private double _pageWidth = Window.Current.Bounds.Width;
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
    }
}
