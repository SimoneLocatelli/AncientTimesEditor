using Editor.PluginsTester.Properties;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Editor.PluginsTester
{
    internal static class AssemblyLoader
    {
        internal static IEnumerable<Assembly> LoadFromExecutingAssemblyFolder()
        {
            var executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Check.IfIsNullOrWhiteSpace(executingAssemblyPath)
                .Throw<InvalidOperationException>(
                    string.Format(CultureInfo.CurrentCulture,
                        Resources.ExecutingAssemblyPathNotRetrieved,
                        executingAssemblyPath));

            return Directory.GetFiles(executingAssemblyPath, "*.dll").Select(Assembly.LoadFile).ToList();
        }
    }
}