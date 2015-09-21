using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#endif

#if !DEBUG

[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("BadaSquall")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]
[assembly: NeutralResourcesLanguage("en-GB")]