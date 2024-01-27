using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.IO;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;

namespace GraphvizVS.CommandHandlers;

/// <summary>
/// Represents the command handler for char commands.
/// </summary>
[Export(typeof(ICommandHandler))]
[Name(nameof(TypeCharCommandHandler))]
[ContentType(ContentTypes.Text)]
[TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
internal sealed class TypeCharCommandHandler : ICommandHandler<TypeCharCommandArgs>
{
    /// <summary>
    /// Gets the display name of the command handler.
    /// </summary>
    public string DisplayName => Vsix.Name;

    /// <summary>
    /// Executes command handler.
    /// </summary>
    /// <param name="args">TypeCharCommandArgs object</param>
    /// <param name="executionContext">CommandExecutionContext object</param>
    /// <returns>Whether key was overriden successfully.</returns>
    public bool ExecuteCommand(TypeCharCommandArgs args, CommandExecutionContext executionContext)
    {
        var typedChar = args.TypedChar;
        var fileExtension = Path.GetExtension(args.SubjectBuffer.GetFileName() ?? "");
        if (!string.IsNullOrWhiteSpace(fileExtension) && (fileExtension == ".dot" || fileExtension == ".DOT") && (typedChar == '/' || typedChar == '-'))
        {
            args.TextView.TextBuffer.Insert(args.TextView.Caret.Position.BufferPosition, typedChar == '/' ? "//" : "->");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Determines whether command handler is enabled.
    /// </summary>
    /// <param name="args">TypeCharCommandArgs object</param>
    /// <returns>CommandState object</returns>
    public CommandState GetCommandState(TypeCharCommandArgs args) => CommandState.Available;
}