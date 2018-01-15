//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories(string.Format("./**/obj/{0}",
      configuration));
    CleanDirectories(string.Format("./**/bin/{0}",
      configuration));
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    // TODO: fix so now warnings or errors emitted
	// reference - https://bugzilla.xamarin.com/show_bug.cgi?id=58254

	// HACK - this will nuget restore AND build
	// MSBuild("./RandomList.sln", new MSBuildSettings()
	//	{ ArgumentCustomization = args => args.Append("/t:restore") });

	// BELOW not resolving path
    //FilePath msbuildPath = Context.Tools.Resolve("msbuild.exe");
    //StartProcess(msbuildPath, new ProcessSettings {
    //    Arguments = new ProcessArgumentBuilder()
    //      .Append("./RandomList.sln")
	//		.Append("/t:restore")
	//});

	// BELOW emits error & warning but continues build
    DotNetCoreRestore("./RandomList.sln");

	// BELOW fails very badly
	// NuGetRestore("./RandomList.sln");
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
	// HACK - restore task will build
	MSBuild("./RandomList.sln", settings =>
		settings.SetConfiguration(configuration));
});

Task("Unit")
	.IsDependentOn("Build")
    .Does(() =>
{
    MSTest("./**/bin/" + configuration + "/*.Tests.dll", new MSTestSettings {
        ToolPath = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Enterprise/Common7/IDE/MSTest.exe",
		Category = "Unit"
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Unit");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
