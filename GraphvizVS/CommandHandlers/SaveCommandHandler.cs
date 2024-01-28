using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.IO;
using GraphvizVS.ToolWindows;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using Microsoft.VisualStudio.Text;

namespace GraphvizVS.CommandHandlers;

/// <summary>
/// Represents the command handler for save command.
/// </summary>
[Export(typeof(ICommandHandler))]
[Name(nameof(TypeCharCommandHandler))]
[ContentType(ContentTypes.Text)]
[TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
internal sealed class SaveCommandHandler : ICommandHandler<SaveCommandArgs>
{
    /// <summary>
    /// Gets the display name of the command handler.
    /// </summary>
    public string DisplayName => Vsix.Name;

    /// <summary>
    /// Determines whether command handler is enabled.
    /// </summary>
    /// <param name="args">SaveCommandArgs object.</param>
    /// <returns>CommandState object.</returns>
    public CommandState GetCommandState(SaveCommandArgs args) => CommandState.Available;

    /// <summary>
    /// Executes command handler.
    /// </summary>
    /// <param name="args">TypeCharCommandArgs object.</param>
    /// <param name="executionContext">CommandExecutionContext object.</param>
    /// <returns>Whether key was overriden successfully.</returns>
    public bool ExecuteCommand(SaveCommandArgs args, CommandExecutionContext executionContext)
    {
        try
        {
            var fileName = args.SubjectBuffer.GetFileName();
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var fileExtension = Path.GetExtension(fileName);
            if (string.IsNullOrWhiteSpace(fileExtension) || fileExtension.ToLower() != ".dot")
                return false;

            ThreadHelper.ThrowIfNotOnUIThread();
            var package = ServiceProvider.GlobalProvider.GetService(typeof(GraphvizVSPackage)) as GraphvizVSPackage;
            if (package is null)
                return false;

            var window = package.FindToolWindow(typeof(GraphPreviewWindow.Pane), 0, false);
            if (window is null)
                return false;

            var control = window.Content as GraphPreviewWindowControl;
            if (control is null)
                return false;

            control.UpdatePreviewWindow(fileName).GetAwaiter();

            return false;
        }
        catch (Exception ex)
        {
            ex.Log();
            return false;
        }
    }
}