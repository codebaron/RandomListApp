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
    // BELOW hack is to avoid errors
	// reference - https://bugzilla.xamarin.com/show_bug.cgi?id=58254
    FilePath msbuildPath = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Enterprise/MSBuild/15.0/Bin/msbuild.exe";
    StartProcess(msbuildPath, new ProcessSettings {
        Arguments = new ProcessArgumentBuilder()
			.Append("./RandomList.sln")
			.Append("/t:restore")
	});
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
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
