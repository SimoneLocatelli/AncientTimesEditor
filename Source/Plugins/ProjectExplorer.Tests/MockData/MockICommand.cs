using System;
using System.Windows.Input;

namespace Editor.ProjectExplorer.Tests.MockData
{
    public class MockICommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}