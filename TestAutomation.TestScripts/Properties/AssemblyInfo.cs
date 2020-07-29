﻿using NUnit.Framework;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TestAutomation")]
[assembly: AssemblyDescription("This is a sample description")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Beta Highdeas Tech Co.")]
[assembly: AssemblyProduct("TestAutomation.TestScripts")]
[assembly: AssemblyCopyright("Copyright @ 2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e0108a73-bc5f-4fa8-a2dd-a3642bc9efd6")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Defining Test attributes
[assembly: Parallelizable(ParallelScope.Children)]

// Number of browsers
[assembly: LevelOfParallelism(1)] 