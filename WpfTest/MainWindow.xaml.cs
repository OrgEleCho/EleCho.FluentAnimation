using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Color newColor;
            if (flag)
            {
                newValue = 400;
                newColor = Colors.Purple;
            }
            else
            {
                newValue = 200;
                newColor = Colors.Pink;
            }

            flag ^= true;

            Expression<Func<object, object>> expr = str => int.Parse((string)str);


            var animator = element.FluentAnimator()
                .SubAnimator(animator => animator
                    .AnimateTo(Canvas.LeftProperty, newValue)
                    .AnimateTo(ele => ((SolidColorBrush)ele.Background).Color, newColor)
                    .WithEasingFunction(new CircleEase() { EasingMode = EasingMode.EaseInOut }))
                .Delay(TimeSpan.FromMilliseconds(200))
                .SubAnimator(animator => animator
                    .AnimateTo(Canvas.TopProperty, newValue)
                    .AnimateTo(ele => ((SolidColorBrush)ele.Background).Color, newColor)
                    .WithEasingFunction(new BounceEase() { EasingMode = EasingMode.EaseOut }))
                .WithDuration(TimeSpan.FromSeconds(1))
                .Start();

            var animator2 = element.FluentAnimator()
                .AnimateWidthTo(100)
                .AnimateHeightTo(200)
                .WithDuration(200)
                .Start();
        }
    }
}
