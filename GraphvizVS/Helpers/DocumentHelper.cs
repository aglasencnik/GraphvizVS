using EnvDTE;

namespace GraphvizVS.Helpers;

/// <summary>
/// Represents the document helper.
/// </summary>
internal static class DocumentHelper
{
    /// <summary>
    /// Gets the active document path.
    /// </summary>
    /// <returns>Active document path</returns>
    internal static string GetActiveDocumentPath()
    {
        ThreadHelper.ThrowIfNotOnUIThread();

        var dte = (DTE)ServiceProvider.GlobalProvider.GetService(typeof(DTE));
        return dte?.ActiveDocument?.FullName;
    }

}