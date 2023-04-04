using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EleCho.FluentAnimation.Wpf;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        bool flag;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button element)
                return;

            double newValue;
            if (flag)
                newValue = 400;
            else
                newValue = 200;

            flag ^= true;


            var animator = element.FluentAnimator()
                .AnimateTo(Canvas.LeftProperty, newValue, TimeSpan.FromMilliseconds(1000), new CircleEase() { EasingMode = EasingMode.EaseInOut })
                .Delay(TimeSpan.FromMilliseconds(200))
                .AnimateTo(Canvas.TopProperty, newValue, TimeSpan.FromMilliseconds(1000), new BounceEase() { EasingMode = EasingMode.EaseOut })
                .WithDuration(TimeSpan.FromSeconds(1))
                .Start();
        }
    }
}
