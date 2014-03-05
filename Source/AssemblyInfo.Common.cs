﻿using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

[assembly: AssemblyCompany(AssemblyDescription.Company)]
[assembly: AssemblyTrademark(AssemblyDescription.Trademark)]
[assembly: AssemblyCopyright(AssemblyDescription.Copyright)]

[assembly: AssemblyConfiguration(AssemblyDescription.Configuration)]

[assembly: AssemblyTitle(AssemblyDescription.Title)]
[assembly: AssemblyProduct(AssemblyDescription.Product)]
[assembly: AssemblyDescription(AssemblyDescription.Product)]

[assembly: AssemblyVersion(AssemblyDescription.Version)]
[assembly: AssemblyFileVersion(AssemblyDescription.FileVersion)]

[assembly: AssemblyCulture(AssemblyDescription.Culture)]
[assembly: NeutralResourcesLanguage("en-US")]


internal static partial class AssemblyDescription
{
    public const string Company = "Igor Rončević";
    public const string Trademark = "";
    public const string Copyright = "Copyright © 2014 " + Company;
    public const string Product = "SwissKnife";

    public const string Version = "0.2.*";
    public const string FileVersion = Version;

    public const string Culture = "";

    public const string Configuration =
#if DEBUG
 "Debug"
#else
 "Release"
#endif
;
}