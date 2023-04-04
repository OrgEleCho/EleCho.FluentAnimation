using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;
using EleCho.FluentAnimation.Wpf.Utilities;

namespace EleCho.FluentAnimation.Wpf;

public partial class FluentAnimator<TElement>
    where TElement : FrameworkElement
{
    public FluentAnimator(TElement target)
    {
        Target = target;
    }

    public TElement Target { get; private set; }
    public Type TargetType { get; } = typeof(TElement);


    public Storyboard Storyboard { get; } = new Storyboard();

    private TimeSpan BeginTimeOffset { get; set; } =
        TimeSpan.Zero;

    private IEasingFunction DefaultEasingFunction { get; set; } =
        new CircleEase() { EasingMode = EasingMode.EaseOut };



    private record struct Option<T>(bool HasValue, T? Value)
    {
        public static Option<T> None() => new Option<T>(false, default);

        public static implicit operator Option<T>(T value) => new Option<T>(true, value);
    }

    private FluentAnimator<TElement> EasingAnimate<TProperty>(
        DependencyProperty dependencyProperty,
        Option<TProperty> from, Option<TProperty> to, Option<TProperty> by,
        bool? isAdditive = null, bool? isCumulative = null, IEasingFunction? easingFunction = null,
        double? speedRatio = null, double? accelerationRatio = null, double? decelerationRatio = null,
        TimeSpan? beginTime = null, Duration? duration = null, bool? autoReverse = null,
        RepeatBehavior? repeatBehavior = null, FillBehavior? fillBehavior = null)
    {
        // 获取时间线
        AnimationTimeline timeline =
            GetEasingTimeline(from, to, by, isAdditive, isCumulative, easingFunction, speedRatio, accelerationRatio, decelerationRatio, beginTime, duration, autoReverse, repeatBehavior, fillBehavior);


        // 动画偏移量机制
        if (timeline.BeginTime == null)
            timeline.BeginTime = BeginTimeOffset;
        else
            timeline.BeginTime = timeline.BeginTime + BeginTimeOffset;

        // 目标属性
        Storyboard.SetTargetProperty(timeline, new PropertyPath($"({dependencyProperty.OwnerType.Name}.{dependencyProperty.Name})"));
        Storyboard.Children.Add(timeline);

        return this;
    }

    private FluentAnimator<TElement> EasingAnimate<TProperty>(
        Expression<Func<TElement, TProperty>> propertyGetter,
        Option<TProperty> from, Option<TProperty> to, Option<TProperty> by,
        bool? isAdditive = null, bool? isCumulative = null, IEasingFunction? easingFunction = null,
        double? speedRatio = null, double? accelerationRatio = null, double? decelerationRatio = null,
        TimeSpan? beginTime = null, Duration? duration = null, bool? autoReverse = null,
        RepeatBehavior? repeatBehavior = null, FillBehavior? fillBehavior = null)
    {
        if (propertyGetter.Body is not MemberExpression memberExpression)
            throw new ArgumentException("Expression must be a member expression", nameof(propertyGetter));

        // 从表达式解析属性路径
        PropertyPath propertyPath =
            ExpressionUtils.ToPropertyPath(propertyGetter);

        // 获取时间线
        AnimationTimeline timeline =
            GetEasingTimeline(from, to, by, isAdditive, isCumulative, easingFunction, speedRatio, accelerationRatio, decelerationRatio, beginTime, duration, autoReverse, repeatBehavior, fillBehavior);

        // 动画偏移量机制
        if (timeline.BeginTime == null)
            timeline.BeginTime = BeginTimeOffset;
        else
            timeline.BeginTime = timeline.BeginTime + BeginTimeOffset;

        // 目标属性
        Storyboard.SetTargetProperty(timeline, propertyPath);
        Storyboard.Children.Add(timeline);

        return this;
    }



    #region 基础重载


    public FluentAnimator<TElement> AnimateBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty by, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), Option<TProperty>.None(), by,
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty by, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(dependencyProperty, from, Option<TProperty>.None(), by,
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> Animate<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty by, Duration duration) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), Option<TProperty>.None(), by,
            duration: duration);

    public FluentAnimator<TElement> AnimateTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty to, Duration duration) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to, Duration duration) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty by, Duration duration) =>
        EasingAnimate(dependencyProperty, from, Option<TProperty>.None(), by,
            duration: duration);

    public FluentAnimator<TElement> Animate<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to, Duration duration) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty by) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), Option<TProperty>.None(), by);

    public FluentAnimator<TElement> AnimateTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty to) =>
        EasingAnimate(dependencyProperty, Option<TProperty>.None(), to, Option<TProperty>.None());

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None());

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty by) =>
        EasingAnimate(dependencyProperty, from, Option<TProperty>.None(), by);

    public FluentAnimator<TElement> Animate<TProperty>(DependencyProperty dependencyProperty,
        TProperty from, TProperty to) =>
        EasingAnimate(dependencyProperty, from, to, Option<TProperty>.None());










    public FluentAnimator<TElement> AnimateBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty by, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), Option<TProperty>.None(), by,
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty by, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(propertyGetter, from, Option<TProperty>.None(), by,
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> Animate<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to, Duration duration, IEasingFunction easingFunction) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None(),
            duration: duration, easingFunction: easingFunction);

    public FluentAnimator<TElement> AnimateBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty by, Duration duration) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), Option<TProperty>.None(), by,
            duration: duration);

    public FluentAnimator<TElement> AnimateTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty to, Duration duration) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to, Duration duration) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty by, Duration duration) =>
        EasingAnimate(propertyGetter, from, Option<TProperty>.None(), by,
            duration: duration);

    public FluentAnimator<TElement> Animate<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to, Duration duration) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None(),
            duration: duration);

    public FluentAnimator<TElement> AnimateBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty by) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), Option<TProperty>.None(), by);

    public FluentAnimator<TElement> AnimateTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty to) =>
        EasingAnimate(propertyGetter, Option<TProperty>.None(), to, Option<TProperty>.None());

    public FluentAnimator<TElement> AnimateFromTo<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None());

    public FluentAnimator<TElement> AnimateFromBy<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty by) =>
        EasingAnimate(propertyGetter, from, Option<TProperty>.None(), by);

    public FluentAnimator<TElement> Animate<TProperty>(Expression<Func<TElement, TProperty>> propertyGetter,
        TProperty from, TProperty to) =>
        EasingAnimate(propertyGetter, from, to, Option<TProperty>.None());

    #endregion


    public FluentAnimator<TElement> SubAnimator(Action<FluentAnimator<TElement>> operation)
    {
        FluentAnimator<TElement> subAnimator =
            new FluentAnimator<TElement>(Target);

        operation.Invoke(subAnimator);

        foreach (var timeline in subAnimator.Storyboard.Children)
            Storyboard.Children.Add(timeline);

        return this;
    }

    public FluentAnimator<TElement> WithAdditive(bool isAdditive)
    {
        foreach (var timeline in Storyboard.Children)
            if (timeline is AnimationTimeline animationTimeline)
                animationTimeline.SetValue(AnimationTimeline.IsAdditiveProperty, isAdditive);

        return this;
    }

    public FluentAnimator<TElement> WithCumulative(bool isCumulative)
    {
        foreach (var timeline in Storyboard.Children)
            if (timeline is AnimationTimeline animationTimeline)
                animationTimeline.SetValue(AnimationTimeline.IsCumulativeProperty, isCumulative);

        return this;
    }

    public FluentAnimator<TElement> WithEasingFunction(IEasingFunction easingFunction)
    {
        foreach (var timeline in Storyboard.Children)
        {
            switch (timeline)
            {
                case ByteAnimation byteAnimation:
                    byteAnimation.SetValue(ByteAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case Int16Animation int16Animation:
                    int16Animation.SetValue(Int16Animation.EasingFunctionProperty, easingFunction);
                    break;
                case Int32Animation int32Animation:
                    int32Animation.SetValue(Int32Animation.EasingFunctionProperty, easingFunction);
                    break;
                case Int64Animation int64Animation:
                    int64Animation.SetValue(Int64Animation.EasingFunctionProperty, easingFunction);
                    break;
                case SingleAnimation singleAnimation:
                    singleAnimation.SetValue(SingleAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case DoubleAnimation doubleAnimation:
                    doubleAnimation.SetValue(DoubleAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case DecimalAnimation decimalAnimation:
                    decimalAnimation.SetValue(DecimalAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case ColorAnimation colorAnimation:
                    colorAnimation.SetValue(ColorAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case PointAnimation pointAnimation:
                    pointAnimation.SetValue(PointAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case Point3DAnimation point3DAnimation:
                    point3DAnimation.SetValue(Point3DAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case QuaternionAnimation quaternionAnimation:
                    quaternionAnimation.SetValue(QuaternionAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case RectAnimation rectAnimation:
                    rectAnimation.SetValue(RectAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case Rotation3DAnimation rotation3DAnimation:
                    rotation3DAnimation.SetValue(Rotation3DAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case SizeAnimation sizeAnimation:
                    sizeAnimation.SetValue(SizeAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case ThicknessAnimation thicknessAnimation:
                    thicknessAnimation.SetValue(ThicknessAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case VectorAnimation vectorAnimation:
                    vectorAnimation.SetValue(VectorAnimation.EasingFunctionProperty, easingFunction);
                    break;
                case Vector3DAnimation vector3DAnimation:
                    vector3DAnimation.SetValue(Vector3DAnimation.EasingFunctionProperty, easingFunction);
                    break;
            }
        }

        return this;
    }

    public FluentAnimator<TElement> WithSpeedRatio(double speedRatio)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.SpeedRatio = speedRatio;

        return this;
    }

    public FluentAnimator<TElement> WithAccelerationRatio(double accelerationRatio)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.AccelerationRatio = accelerationRatio;

        return this;
    }

    public FluentAnimator<TElement> WithDecelerationRatio(double decelerationRatio)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.DecelerationRatio = decelerationRatio;

        return this;
    }

    public FluentAnimator<TElement> WithBeginTime(TimeSpan beginTime)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.Duration = beginTime;

        return this;
    }

    public FluentAnimator<TElement> WithDuration(double durationInMilliseconds)
    {
        Duration duration = 
            new Duration(TimeSpan.FromMilliseconds(durationInMilliseconds));

        foreach (var timeline in Storyboard.Children)
            timeline.Duration = duration;

        return this;
    }

    public FluentAnimator<TElement> WithDuration(TimeSpan duration)
    {
        Duration _duration = new Duration(duration);

        foreach (var timeline in Storyboard.Children)
            timeline.Duration = _duration;

        return this;
    }

    public FluentAnimator<TElement> WithDuration(Duration duration)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.Duration = duration;

        return this;
    }

    public FluentAnimator<TElement> WithAutoReverse(bool autoReverse)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.AutoReverse = autoReverse;

        return this;
    }

    public FluentAnimator<TElement> WithRepeatBehavior(RepeatBehavior repeatBehavior)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.RepeatBehavior = repeatBehavior;

        return this;
    }

    public FluentAnimator<TElement> WithFillBehavior(FillBehavior fillBehavior)
    {
        foreach (var timeline in Storyboard.Children)
            timeline.FillBehavior = fillBehavior;

        return this;
    }

    public FluentAnimator<TElement> Delay(TimeSpan duration)
    {
        BeginTimeOffset += duration;

        return this;
    }

    public FluentAnimator<TElement> Continue()
    {
        Timeline? lastTimeline =
            Storyboard.Children.LastOrDefault();

        if (lastTimeline == null)
            throw new InvalidOperationException("There is no children of Storyboard");

        if (!lastTimeline.Duration.HasTimeSpan)
            throw new InvalidOperationException("The last timeline doesn't have a duration with time span");

        BeginTimeOffset =
            (lastTimeline.BeginTime ?? TimeSpan.Zero) + lastTimeline.Duration.TimeSpan;

        return this;
    }

    public FluentAnimator<TElement> RepeatForever()
    {
        Storyboard.RepeatBehavior =
            RepeatBehavior.Forever;

        return this;
    }


    public FluentAnimator<TElement> Start()
    {
        Storyboard.Begin(Target);

        return this;
    }

    public FluentAnimator<TElement> Stop()
    {
        Storyboard.Stop(Target);

        return this;
    }

    public FluentAnimator<TElement> Resume()
    {
        Storyboard.Resume();

        return this;
    }

    public FluentAnimator<TElement> Pause()
    {
        Storyboard.Pause();

        return this;
    }

    private void GetKeyFramesTimeline<TProperty>()
    {

    }
}