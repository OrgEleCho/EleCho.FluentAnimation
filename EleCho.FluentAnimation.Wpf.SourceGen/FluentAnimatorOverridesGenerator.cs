using System.Text;
using Microsoft.CodeAnalysis;

namespace EleCho.FluentAnimation.Wpf.SourceGen
{
    [Generator]
    public class FluentAnimatorOverridesGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            KeyValuePair<string, string>[] animatableProperties = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("Width", "Double"),
                new KeyValuePair<string, string>("Height", "Double"),
                new KeyValuePair<string, string>("MaxWidth", "Double"),
                new KeyValuePair<string, string>("MaxHeight", "Double"),
                new KeyValuePair<string, string>("Opacity", "Double"),
                new KeyValuePair<string, string>("Margin", "Thickness"),
            };

            string head =
                """
                using System.ComponentModel;
                using System.Linq.Expressions;
                using System.Reflection;
                using System.Windows;
                using System.Windows.Media.Animation;

                namespace EleCho.FluentAnimation.Wpf;

                public partial class FluentAnimator<TElement>
                {
                """;

            string tail =
                """
                }
                """;

            string difinition =
                """
                    public FluentAnimator<TElement> Animate{0}By({1} by, Duration duration, IEasingFunction easingFunction) =>
                        AnimateBy(ele => ele.{0}, by, duration, easingFunction);
                    public FluentAnimator<TElement> Animate{0}To({1} to, Duration duration, IEasingFunction easingFunction) =>
                        AnimateTo(ele => ele.{0}, to, duration, easingFunction);
                    public FluentAnimator<TElement> Animate{0}FromTo({1} from, {1} to, Duration duration, IEasingFunction easingFunction) =>
                        AnimateFromTo(ele => ele.{0}, from, to, duration, easingFunction);
                    public FluentAnimator<TElement> Animate{0}FromBy({1} from, {1} by, Duration duration, IEasingFunction easingFunction) =>
                        AnimateFromBy(ele => ele.{0}, from, by, duration, easingFunction);
                    public FluentAnimator<TElement> Animate{0}({1} from, {1} to, Duration duration, IEasingFunction easingFunction) =>
                        AnimateFromTo(ele => ele.{0}, from, to, duration, easingFunction);
                    public FluentAnimator<TElement> Animate{0}By({1} by, Duration duration) =>
                        AnimateBy(ele => ele.{0}, by, duration);
                    public FluentAnimator<TElement> Animate{0}To({1} to, Duration duration) =>
                        AnimateTo(ele => ele.{0}, to, duration);
                    public FluentAnimator<TElement> Animate{0}FromTo({1} from, {1} to, Duration duration) =>
                        AnimateFromTo(ele => ele.{0}, from, to, duration);
                    public FluentAnimator<TElement> Animate{0}FromBy({1} from, {1} by, Duration duration) =>
                        AnimateFromBy(ele => ele.{0}, from, by, duration);
                    public FluentAnimator<TElement> Animate{0}({1} from, {1} to, Duration duration) =>
                        AnimateFromTo(ele => ele.{0}, from, to, duration);
                    public FluentAnimator<TElement> Animate{0}By({1} by) =>
                        AnimateBy(ele => ele.{0}, by);
                    public FluentAnimator<TElement> Animate{0}To({1} to) =>
                        AnimateTo(ele => ele.{0}, to);
                    public FluentAnimator<TElement> Animate{0}FromTo({1} from, {1} to) =>
                        AnimateFromTo(ele => ele.{0}, from, to);
                    public FluentAnimator<TElement> Animate{0}FromBy({1} from, {1} by) =>
                        AnimateFromBy(ele => ele.{0}, from, by);
                    public FluentAnimator<TElement> Animate{0}({1} from, {1} to) =>
                        AnimateFromTo(ele => ele.{0}, from, to);
                """;

            StringBuilder sourceBuilder =
                new StringBuilder();

            sourceBuilder.AppendLine(head);

            foreach (var kv in animatableProperties)
                sourceBuilder.AppendLine(string.Format(difinition, kv.Key, kv.Value));

            sourceBuilder.AppendLine(tail);

            context.AddSource("FluentAnimator.g.cs", sourceBuilder.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {

        }
    }
}