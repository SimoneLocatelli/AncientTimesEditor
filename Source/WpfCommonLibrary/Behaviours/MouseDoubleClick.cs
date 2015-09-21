using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCommonLibrary.Behaviours
{
    /// <summary>
    ///     Attached behaviour used to enable the binding with
    ///     a control when the Double Click event is raised.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors",
        Justification = "This is the standard implementations forn the Attached Behaviours patterns")]
    public class MouseDoubleClick
    {
        /// <summary>
        ///     The parameter passed to the command
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                typeof (object),
                typeof (MouseDoubleClick),
                new UIPropertyMetadata(null));

        /// <summary>
        ///     The command binded to the double click event
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command",
                typeof (ICommand),
                typeof (MouseDoubleClick),
                new UIPropertyMetadata(CommandChanged));

        /// <summary>
        ///     Gets the command parameter.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static object GetCommandParameter(DependencyObject target)
        {
            return target == null ? null : target.GetValue(CommandParameterProperty);
        }

        /// <summary>
        ///     Sets the command.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        public static void SetCommand(DependencyObject target, ICommand value)
        {
            if (target == null) return;

            target.SetValue(CommandProperty, value);
        }

        /// <summary>
        ///     Sets the command parameter.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        public static void SetCommandParameter(DependencyObject target, object value)
        {
            if (target == null) return;

            target.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        ///     Raised when the command property is set to a different value.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var control = target as Control;
            if (control == null) return;

            if (NewValueIsNotValid(e))
            {
                control.MouseDoubleClick += OnMouseDoubleClick;
            }
            else if (OldValueWasNotValid(e))
            {
                control.MouseDoubleClick -= OnMouseDoubleClick;
            }
        }

        private static bool NewValueIsNotValid(DependencyPropertyChangedEventArgs e)
        {
            return (e.NewValue != null) && (e.OldValue == null);
        }

        private static bool OldValueWasNotValid(DependencyPropertyChangedEventArgs e)
        {
            return (e.NewValue == null) && (e.OldValue != null);
        }

        private static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var control = sender as Control;

            if (control == null) return;

            var command = (ICommand) control.GetValue(CommandProperty);
            var commandParameter = control.GetValue(CommandParameterProperty);
            command.Execute(commandParameter);
        }
    }
}