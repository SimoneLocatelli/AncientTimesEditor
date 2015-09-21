﻿using FluentChecker;
using System;
using System.Windows.Input;

namespace WpfCommonLibrary
{
    /// <summary>
    /// Basic implementation for the ICommand interface. 
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Gets the function that determine if is it possible to execute the command. 
        /// </summary>
        /// <value> The can execute function. </value>
        public Func<object, bool> CanExecuteFunc { get; private set; }

        /// <summary>
        /// Gets the action to execute. 
        /// </summary>
        /// <value> The execute action. </value>
        public Action<object> ExecuteAction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class. 
        /// </summary>
        /// <param name="executeAction"> The execute action. </param>
        public Command(Action<object> executeAction)
            : this(executeAction, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class. 
        /// </summary>
        /// <param name="executeAction">  The execute action. </param>
        /// <param name="canExecuteFunc"> The can execute function. </param>
        public Command(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            Check.IfIsNull(executeAction).Throw<ArgumentNullException>(() => executeAction);

            ExecuteAction = executeAction;
            CanExecuteFunc = canExecuteFunc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class. 
        /// </summary>
        /// <param name="executeAction"> The execute action. </param>
        public Command(Action executeAction)
            : this(_ => executeAction(), null)
        {
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute. 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state. 
        /// </summary>
        /// <returns> true if this command can be executed; otherwise, false. </returns>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked. 
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            ExecuteAction(parameter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class. 
        /// </summary>
        /// <param name="executeAction">  The execute action. </param>
        /// <param name="canExecuteFunc"> The can execute function. </param>
        public Command(Action executeAction, Func<bool> canExecuteFunc)
            : this(_ => executeAction(), _ => canExecuteFunc())
        {
        }
    }
}