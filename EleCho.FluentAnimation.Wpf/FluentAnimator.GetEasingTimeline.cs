using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace EleCho.FluentAnimation.Wpf;

public partial class FluentAnimator<TElement>
{
    private AnimationTimeline GetEasingTimeline<TProperty>(
        Option<TProperty> from, Option<TProperty> to, Option<TProperty> by,
        bool? isAdditive, bool? isCumulative, IEasingFunction? easingFunction,
        double? speedRatio, double? accelerationRatio, double? decelerationRatio,
        TimeSpan? beginTime, Duration? duration, bool? autoReverse,
        RepeatBehavior? repeatBehavior, FillBehavior? fillBehavior)
    {
        AnimationTimeline? timeline;


        if (typeof(Byte).IsAssignableFrom(typeof(TProperty)))
        {
            ByteAnimation animation =
                    new ByteAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Byte _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Byte _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Byte _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Int16).IsAssignableFrom(typeof(TProperty)))
        {
            Int16Animation animation =
                    new Int16Animation();
            timeline = animation;

            if (from.HasValue && from.Value is Int16 _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Int16 _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Int16 _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Int32).IsAssignableFrom(typeof(TProperty)))
        {
            Int32Animation animation =
                    new Int32Animation();
            timeline = animation;

            if (from.HasValue && from.Value is Int32 _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Int32 _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Int32 _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Int64).IsAssignableFrom(typeof(TProperty)))
        {
            Int64Animation animation =
                    new Int64Animation();
            timeline = animation;

            if (from.HasValue && from.Value is Int64 _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Int64 _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Int64 _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Single).IsAssignableFrom(typeof(TProperty)))
        {
            SingleAnimation animation =
                    new SingleAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Single _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Single _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Single _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Double).IsAssignableFrom(typeof(TProperty)))
        {
            DoubleAnimation animation =
                    new DoubleAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Double _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Double _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Double _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Decimal).IsAssignableFrom(typeof(TProperty)))
        {
            DecimalAnimation animation =
                    new DecimalAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Decimal _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Decimal _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Decimal _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Color).IsAssignableFrom(typeof(TProperty)))
        {
            ColorAnimation animation =
                    new ColorAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Color _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Color _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Color _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Point).IsAssignableFrom(typeof(TProperty)))
        {
            PointAnimation animation =
                    new PointAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Point _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Point _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Point _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Point3D).IsAssignableFrom(typeof(TProperty)))
        {
            Point3DAnimation animation =
                    new Point3DAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Point3D _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Point3D _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Point3D _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Quaternion).IsAssignableFrom(typeof(TProperty)))
        {
            QuaternionAnimation animation =
                    new QuaternionAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Quaternion _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Quaternion _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Quaternion _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Rect).IsAssignableFrom(typeof(TProperty)))
        {
            RectAnimation animation =
                    new RectAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Rect _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Rect _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Rect _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Rotation3D).IsAssignableFrom(typeof(TProperty)))
        {
            Rotation3DAnimation animation =
                    new Rotation3DAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Rotation3D _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Rotation3D _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Rotation3D _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Size).IsAssignableFrom(typeof(TProperty)))
        {
            SizeAnimation animation =
                    new SizeAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Size _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Size _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Size _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Thickness).IsAssignableFrom(typeof(TProperty)))
        {
            ThicknessAnimation animation =
                    new ThicknessAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Thickness _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Thickness _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Thickness _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Vector).IsAssignableFrom(typeof(TProperty)))
        {
            VectorAnimation animation =
                    new VectorAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Vector _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Vector _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Vector _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else if (typeof(Vector3D).IsAssignableFrom(typeof(TProperty)))
        {
            Vector3DAnimation animation =
                    new Vector3DAnimation();
            timeline = animation;

            if (from.HasValue && from.Value is Vector3D _from)
                animation.From = _from;
            if (to.HasValue && to.Value is Vector3D _to)
                animation.To = _to;
            if (by.HasValue && by.Value is Vector3D _by)
                animation.By = _by;

            // defaults:
            if (DefaultDuration is Duration defaultDuration)
                animation.Duration = defaultDuration;
            if (DefaultEasingFunction is IEasingFunction defaultEasingFunction)
                animation.EasingFunction = defaultEasingFunction;

            if (isAdditive is bool _isAdditive)
                animation.IsAdditive = _isAdditive;
            if (isCumulative is bool _isCumulative)
                animation.IsCumulative = _isCumulative;
            if (easingFunction is IEasingFunction _easingFunction)
                animation.EasingFunction = _easingFunction;
        }
        else
        {
            throw new ArgumentException("Cannot find AnimationTimeline for specified type", nameof(TProperty));
        }


        if (speedRatio is double _speedRatio)
            timeline.SpeedRatio = _speedRatio;
        if (accelerationRatio is double _accelerationRatio)
            timeline.AccelerationRatio = _accelerationRatio;
        if (decelerationRatio is double _decelerationRatio)
            timeline.DecelerationRatio = _decelerationRatio;
        if (beginTime is TimeSpan _beginTime)
            timeline.BeginTime = _beginTime;
        if (duration is Duration _duration)
            timeline.Duration = _duration;
        if (autoReverse is bool _autoReverse)
            timeline.AutoReverse = true;
        if (repeatBehavior is RepeatBehavior _repeatBehavior)
            timeline.RepeatBehavior = _repeatBehavior;
        if (fillBehavior is FillBehavior _fillBehavior)
            timeline.FillBehavior = _fillBehavior;

        return timeline;
    }

}
