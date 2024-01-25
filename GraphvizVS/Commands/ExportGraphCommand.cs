namespace GraphvizVS.Commands;

/// <summary>
/// Represents the command to export the graph to a file.
/// </summary>
[Command(PackageIds.ExportGraphCommand)]
internal sealed class ExportGraphCommand : BaseCommand<ExportGraphCommand>
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="e">OleMenuCmdEventArgs object.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected override Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        VS.MessageBox.Show("", "Export graph");

        return Task.CompletedTask;
    }
}