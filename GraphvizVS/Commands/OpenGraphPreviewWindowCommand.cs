using GraphvizVS.ToolWindows;

namespace GraphvizVS.Commands;

/// <summary>
/// Represents the command to open the graph preview window.
/// </summary>
[Command(PackageIds.OpenGraphPreviewWindowCommand)]
internal sealed class OpenGraphPreviewWindowCommand : BaseCommand<OpenGraphPreviewWindowCommand>
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="e">OleMenuCmdEventArgs object.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        await GraphPreviewWindow.ShowAsync();
    }
}