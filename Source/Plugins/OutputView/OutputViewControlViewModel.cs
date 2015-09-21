using Editor.DockSystem.Dependencies;
using Editor.Logging.Dependencies;
using Editor.OutputView.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using OutputView.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace OutputView
{
    /// <summary>
    ///     ViewModel for the OutputView Control
    /// </summary>
    [Export(typeof(IOutputViewControlViewModel))]
    public class OutputViewControlViewModel : BaseViewModel, IOutputViewControlViewModel
    {
        private readonly Dictionary<string, string> logs = new Dictionary<string, string>();
        private string selectedCategory;

        /// <summary>
        ///     Gets a value indicating whether the categories selection is enabled
        /// </summary>
        /// <value>
        ///     <c>true</c> if the categories selection is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool AreCategoriesEnabled
        {
            get { return Categories.Any(); }
        }

        /// <summary>
        ///     Gets the log categories, used to organize the various logs.
        /// </summary>
        /// <value>
        ///     The log categories.
        /// </value>
        public ICollection<string> Categories
        {
            get { return new ObservableCollection<string>(logs.Keys); }
        }

        /// <summary>
        ///     Gets or sets the current logs message.
        /// </summary>
        /// <value> The logs message. </value>
        public string CurrentLog
        {
            get { return SelectedCategory == null ? string.Empty : logs[SelectedCategory]; }
            protected set
            {
                logs[SelectedCategory] = value;
                Notify();
            }
        }

        /// <summary>
        ///     Gets a value indicating whether is possible to clear the log displayed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the log could be cleaned; otherwise, <c>false</c>.
        /// </value>
        public bool IsLogCleanable
        {
            get { return !string.IsNullOrWhiteSpace(CurrentLog); }
        }

        /// <summary>
        ///     Gets or sets the currently selected category.
        /// </summary>
        /// <value>
        ///     The selected category.
        /// </value>
        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                SetProperty(ref selectedCategory, value);
                Notify(() => CurrentLog);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OutputViewControlViewModel" /> class.
        /// </summary>
        [ImportingConstructor]
        public OutputViewControlViewModel(IEditorLogger editorLogger)
        {
            Check.IfIsNull(editorLogger).Throw<ArgumentNullException>(() => editorLogger);

            editorLogger.MessageLogged += EditorLoggerMessageLogged;
        }

        /// <summary>
        ///     Clears the completely the current log.
        /// </summary>
        public void ClearLog()
        {
            CurrentLog = string.Empty;
        }

        /// <summary>
        ///     Logs the specified message.
        /// </summary>
        /// <param name="category"> The category group of the log message. </param>
        /// <param name="message"> The message to log. </param>
        public void Log(string category, string message)
        {
            Check.IfIsNullOrWhiteSpace(category).Throw<ArgumentException>(() => category);
            Check.IfIsNullOrWhiteSpace(message).Throw<ArgumentException>(() => message);

            InitializeCategoryIfDoesntExist(category);

            logs[category] += string.Format(CultureInfo.CurrentCulture, "{0} - {1}\n",
                DateTime.Now.ToString("hh:mm:ss:fff", CultureInfo.CurrentCulture),
                message);

            if (category.Equals(SelectedCategory))
            {
                Notify(() => CurrentLog);
            }
        }

        private void AddCategory(string category)
        {
            logs.Add(category, string.Empty);
            Notify(() => Categories);
            Notify(() => AreCategoriesEnabled);
        }

        /// <summary>
        ///     Called when the Logger notify a new logged message
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageLoggerEventArgs" /> instance containing the event data.</param>
        private void EditorLoggerMessageLogged(object sender, MessageLoggerEventArgs e)
        {
            Log(e.Category, e.Message);
        }

        /// <summary>
        ///     Initializes the category if doesnt exist.
        /// </summary>
        /// <param name="category">The category.</param>
        private void InitializeCategoryIfDoesntExist(string category)
        {
            if (logs.ContainsKey(category)) return;

            AddCategory(category);

            if (Categories.Count() == 1)
            {
                SelectedCategory = category;
            }
        }
    }
}