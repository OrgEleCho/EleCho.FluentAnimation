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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button element)
                return;

            double newValue;
            if (element.Width == 200)
                newValue = 400;
            else
                newValue = 200;


            var animator = element.FluentAnimator()
                .AnimateTo(ele => ele.Width, newValue, TimeSpan.FromMilliseconds(100))
                .Then()
                .AnimateTo(ele => ele.Height, newValue, TimeSpan.FromMilliseconds(100))
                .WithEasingFunction(new CircleEase() { EasingMode = EasingMode.EaseOut })
                .Start();
        }
    }
}
