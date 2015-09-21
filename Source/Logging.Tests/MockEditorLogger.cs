#region Usings

using Editor.Logging.Dependencies;
using System;

#endregion Usings

namespace Editor.Logging.Tests
{
    internal class MockEditorLogger : IEditorLogger
    {
        public bool HasBeenCalled { get; private set; }

        public MockEditorLogger()
        {
            HasBeenCalled = false;
        }

        public event EventHandler<MessageLoggerEventArgs> MessageLogged;

        public void Log(string category, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(string category, string message, params object[] placeholderValues)
        {
            throw new NotImplementedException();
        }

        public void Log(char value)
        {
            HasBeenCalled = true;
        }

        public string RetrieveLog()
        {
            throw new NotImplementedException();
        }
    }
}