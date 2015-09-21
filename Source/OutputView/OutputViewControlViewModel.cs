using Editor.OutputView.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using WpfCommonLibrary;

namespace OutputView
{
    [Export(typeof(IOutputViewControlViewModel))]
    public class OutputViewControlViewModel : BaseViewModel, IOutputViewControlViewModel
    {
        private readonly Dictionary<string, string> logs = new Dictionary<string, string>();
        private string selectedCategory;

        public bool AreCategoriesEnabled
        {
            get { return Categories.Any(); }
        }

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
            get
            {
                return SelectedCategory == null ? string.Empty : logs[SelectedCategory];
            }
            protected set
            {
                logs[SelectedCategory] = value;
                Notify();
            }
        }

        public bool IsLogCleanable
        {
            get { return !string.IsNullOrWhiteSpace(CurrentLog); }
        }

        public string SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                SetProperty(ref selectedCategory, value);
                Notify(() => CurrentLog);
            }
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