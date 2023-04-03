using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EleCho.FluentAnimation.Wpf;

public static partial class FluentAnimatorExtensions
{
    public static FluentAnimator<TElement> FluentAnimator<TElement>(this TElement element)
        where TElement : FrameworkElement
    {
        return new FluentAnimator<TElement>(element);
    }
}