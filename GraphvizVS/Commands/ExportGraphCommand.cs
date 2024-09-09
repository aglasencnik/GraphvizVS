using System.Collections.Generic;
using System.IO;
using CliWrap;
using GraphvizVS.Helpers;
using GraphvizVS.Options;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.Win32;

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
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        var docView = await VS.Documents.GetActiveDocumentViewAsync();
        if (docView?.TextView is null)
            return;

        try
        {
            var activeDocumentPath = DocumentHelper.GetActiveDocumentPath();
            var activeDocumentExtension = Path.GetExtension(activeDocumentPath);
            if (string.IsNullOrWhiteSpace(activeDocumentExtension) || activeDocumentExtension.ToLower() != ".dot")
                return;

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Select graph save location",
                Filter = OutputFormatHelper.GetFilter()
            };

            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult is null || !dialogResult.Value || string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                return;

            var fileName = saveFileDialog.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            var flags = new List<string>();

            if (!string.IsNullOrWhiteSpace(GeneralOptions.Instance.AdditionalFlags))
                flags.Add(GeneralOptions.Instance.AdditionalFlags);

            flags.Add(OutputFormatHelper.GetOutputFormatArgument());
            flags.Add(activeDocumentPath);
            flags.AddRange(["-o", fileName]);

            var result = await Cli.Wrap(CommandLineHelper.GetEnginePath())
                .WithArguments(flags)
                .ExecuteAsync();

            if (result.IsSuccess)
                await VS.MessageBox.ShowAsync("Graph export was successful!");
            else
                await VS.MessageBox.ShowErrorAsync("Graph export has failed!");
        }
        catch (Exception ex)
        {
            await VS.MessageBox.ShowAsync(
                "Something went wrong while loading the graph preview!",
                "There is probably a syntax error in your .dot file.\nFix the errors and try again.",
                OLEMSGICON.OLEMSGICON_CRITICAL,
                OLEMSGBUTTON.OLEMSGBUTTON_OK
            );

            await ex.LogAsync();
        }
    }

    /// <summary>
    /// Executes after the initialization of the command.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected override Task InitializeCompletedAsync()
    {
        Command.Supported = false;
        return base.InitializeCompletedAsync();
    }
}