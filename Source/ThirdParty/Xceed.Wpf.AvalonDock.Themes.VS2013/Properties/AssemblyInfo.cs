using System.Reflection;
using System.Windows;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Xceed Extended WPF Toolkit - AvalonDock VS2013 Theme")]
[assembly: AssemblyDescription("This assembly implements the VS2013 Theme for the AvalonDock layout system.")]
[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page,
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page,
    // app, or any theme specific resource dictionaries)
    )]
[assembly: XmlnsDefinition("http://schemas.xceed.com/wpf/xaml/avalondock", "Xceed.Wpf.AvalonDock.Themes")]
#pragma warning disable 1699

[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile(@"..\..\sn.snk")]
[assembly: AssemblyKeyName("")]
#pragma warning restore 1699