global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using System.Runtime.InteropServices;
using System.Threading;
using GraphvizVS.Options;
using GraphvizVS.ToolWindows;

namespace GraphvizVS;

/// <summary>
/// Represents the Visual Studio package.
/// </summary>
[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
[ProvideMenuResource("Menus.ctmenu", 1)]
[Guid(PackageGuids.GraphvizVSString)]
[ProvideOptionPage(typeof(OptionsProvider.GeneralOptionsProvider), "GraphvizVS", "General", 0, 0, true)]
[ProvideProfile(typeof(OptionsProvider.GeneralOptionsProvider), "GraphvizVS", "General", 0, 0, true)]
[ProvideToolWindow(typeof(GraphPreviewWindow.Pane), Style = VsDockStyle.Linked, Window = WindowGuids.Toolbox)]
[ProvideUIContextRule(PackageGuids.uiContextSupportedFilesString, name: "Supported Files", expression: "DOT", termNames: ["DOT", "DOT"], termValues: ["HierSingleSelectionName:.dot$", "HierSingleSelectionName:.DOT$"])]
[ProvideService(typeof(GraphvizVSPackage), IsAsyncQueryable = true)]
public sealed class GraphvizVSPackage : ToolkitPackage
{
    /// <summary>
    /// Initializes package.
    /// </summary>
    /// <param name="cancellationToken">CancellationToken object.</param>
    /// <param name="progress">ServiceProgressData object.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
    {
        await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        await this.RegisterCommandsAsync();
        this.RegisterToolWindows();
        AddService(typeof(GraphvizVSPackage), (_, _, _) => Task.FromResult<object>(this), promote: true);
    }
}