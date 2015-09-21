using Editor.OutputView.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace OutputView
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    [Export]
    public partial class OutputViewControl : IOutputViewControl
    {
        private IOutputViewControlViewModel ViewModel { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OutputViewControl" /> class.
        /// </summary>
        /// <param name="bindingErrorListener">The binding error listener.</param>
        /// <param name="viewModel">The view model.</param>
        [ImportingConstructor]
        public OutputViewControl(IBindingErrorListener bindingErrorListener, IOutputViewControlViewModel viewModel)
        {
            Check.IfIsNull(bindingErrorListener).Throw<ArgumentNullException>(() => bindingErrorListener);

            DataContext = ViewModel = viewModel;

            InitializeComponent();

            bindingErrorListener.Listen(
                message => Log(Properties.Resources.OutputViewControlBindingErrorsCategory, message));
        }

        /// <summary>
        ///     Logs the specified message.
        /// </summary>
        /// <param name="category"> The category group of the log message. </param>
        /// <param name="message"> The message to log. </param>
        public void Log(string category, string message)
        {
            ViewModel.Log(category, message);
        }

        /// <summary>
        ///     Logs a message under the General Information category.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogGeneralInfo(string message)
        {
            Log(Properties.Resources.OutputViewControlGeneralInformationCategory, message);
        }

        /// <summary>
        ///     Handler raised when the Clear Contents Button is clicked
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        ///     The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        [ExcludeFromCodeCoverage]
        private void ClearContentsButtonClick(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearLog();
        }
    }
}