# EleCho.FluentAnimation

Use Fluent APIs to process animations in WPF.


## Usage

Add namespace using.

```cs
using EleCho.FluentAnimation.Wpf
```

Call the extension method `FluentAnimator`, it returns a `FluentAnimator` instance for processing animations.

```cs
element.FluentAnimator();
```

Call `AnimateBy`, `AnimateTo`, `AnimateFromBy`, `AnimateFromTo` methods to process an animation, then call `Start` method to start these animations.

```cs
element.FluentAnimator()
    .AnimateTo(ele => ele.Width, 100)
    .AnimateTo(ele => ele.Height, 100)
    .Start();
```

You can also directly use some wrapped methods for commonly used attributes, such as `AnimateWidthTo`, `AnimateHeightTo`.

```cs
element.FluentAnimator()
    .AnimateWidthTo(100)
    .AnimateHeightTo(100)
    .Start();
```

You can use methods such as `WithDuration`, `WithEasingFunction` to configure all animations.

```cs
element.FluentAnimator()
    .AnimateWidthTo(100)
    .AnimateHeightTo(100)
    .WithDuration(200)      // 200ms
    .WithEasingFunction(
        new CircleEase() { EasingMode = EasingMode.EaseOut })
    .Start();
```

You can use `Delay` or `Then` to control the order of execution of animations.

```cs
element.FluentAnimator()
    .AnimateWidthTo(100)
    .Delay(100)             // delay for 100ms
    .AnimateHeightTo(100)
    .WithDuration(200)      // 200ms
    .Start();

element.FluentAnimator()
    .AnimateWidthTo(100, TimeSpan.FromMilliseconds(200))     // to use continue, you must specify the duration
    .Then()                                                  // delay for the duration of the previous animation
    .AnimateHeightTo(100, TimeSpan.FromMilliseconds(200))    // run the current animation
    .Start();
```

Animation with attached property.

```cs
element.FluentAnimator()
    .AnimateTo(Canvas.LeftProperty, (double)200)
    .WithDuration(200)
    .Start();
```

Animation with nesting properties.

```cs
element.FluentAnimator()
    .AnimateTo(ele => ((SolidColorBrush)ele.Background).Color, Colors.Pink)
    .WithDuration(200)
    .Start();
```