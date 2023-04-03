using System.Text;
using Microsoft.CodeAnalysis;

namespace EleCho.FluentAnimation.Wpf.SourceGen
{
    [Generator]
    public class FluentAnimatorExtensionsOverridesGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Tuple<string, string, string>[] animatableProperties = new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Padding", "Thickness", "Control")
            };

            string head =
                """
                using System.Windows;
                using System.Windows.Controls;
                using System.Windows.Media.Animation;

                namespace EleCho.FluentAnimation.Wpf;

                public static partial class FluentAnimatorExtensions
                {
                """;

            // args: name, type, element
            string difinition =
                """
                    public static FluentAnimator<TElement> Animate{0}By<TElement>(this FluentAnimator<TElement> animator, {1} by, Duration duration, IEasingFunction easingFunction) where TElement : {2} =>
                        animator.AnimateBy(ele => ele.{0}, by, duration, easingFunction);
                    public static FluentAnimator<TElement> Animate{0}To<TElement>(this FluentAnimator<TElement> animator, {1} to, Duration duration, IEasingFunction easingFunction) where TElement : {2} =>
                        animator.AnimateTo(ele => ele.{0}, to, duration, easingFunction);
                    public static FluentAnimator<TElement> Animate{0}FromBy<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} by, Duration duration, IEasingFunction easingFunction) where TElement : {2} =>
                        animator.AnimateFromBy(ele => ele.{0}, from, by, duration, easingFunction);
                    public static FluentAnimator<TElement> Animate{0}FromTo<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to, Duration duration, IEasingFunction easingFunction) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to, duration, easingFunction);
                    public static FluentAnimator<TElement> Animate{0}<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to, Duration duration, IEasingFunction easingFunction) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to, duration, easingFunction);
                    public static FluentAnimator<TElement> Animate{0}By<TElement>(this FluentAnimator<TElement> animator, {1} by, Duration duration) where TElement : {2} =>
                        animator.AnimateBy(ele => ele.{0}, by, duration);
                    public static FluentAnimator<TElement> Animate{0}To<TElement>(this FluentAnimator<TElement> animator, {1} to, Duration duration) where TElement : {2} =>
                        animator.AnimateTo(ele => ele.{0}, to, duration);
                    public static FluentAnimator<TElement> Animate{0}FromBy<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} by, Duration duration) where TElement : {2} =>
                        animator.AnimateFromBy(ele => ele.{0}, from, by, duration);
                    public static FluentAnimator<TElement> Animate{0}FromTo<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to, Duration duration) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to, duration);
                    public static FluentAnimator<TElement> Animate{0}<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to, Duration duration) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to, duration);
                    public static FluentAnimator<TElement> Animate{0}By<TElement>(this FluentAnimator<TElement> animator, {1} by) where TElement : {2} =>
                        animator.AnimateBy(ele => ele.{0}, by);
                    public static FluentAnimator<TElement> Animate{0}To<TElement>(this FluentAnimator<TElement> animator, {1} to) where TElement : {2} =>
                        animator.AnimateTo(ele => ele.{0}, to);
                    public static FluentAnimator<TElement> Animate{0}FromBy<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} by) where TElement : {2} =>
                        animator.AnimateFromBy(ele => ele.{0}, from, by);
                    public static FluentAnimator<TElement> Animate{0}FromTo<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to);
                    public static FluentAnimator<TElement> Animate{0}<TElement>(this FluentAnimator<TElement> animator, {1} from, {1} to) where TElement : {2} =>
                        animator.AnimateFromTo(ele => ele.{0}, from, to);
                """;

            string tail =
                """
                }
                """;

            StringBuilder sourceBuilder =
                new StringBuilder();

            sourceBuilder.AppendLine(head);

            foreach (var args in animatableProperties)
                sourceBuilder.AppendLine(string.Format(difinition, args.Item1, args.Item2, args.Item3));

            sourceBuilder.AppendLine(tail);

            context.AddSource("FluentAnimatorExtensions.g.cs", sourceBuilder.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            
        }
    }
}