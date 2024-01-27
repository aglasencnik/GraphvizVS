using System.IO;
using System.Reflection;
using GraphvizVS.Enums;
using GraphvizVS.Options;

namespace GraphvizVS.Helpers;

/// <summary>
/// Represents the command line helper.
/// </summary>
internal static class CommandLineHelper
{
    /// <summary>
    /// Gets the engine path.
    /// </summary>
    /// <returns>A string value.</returns>
    internal static string GetEnginePath()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var enginePath = Path.Combine(assemblyPath, "Graphviz");
        string layoutEngine;

        if (GeneralOptions.Instance.LayoutEngine == LayoutEngine.Custom)
        {
            if (!string.IsNullOrWhiteSpace(GeneralOptions.Instance.CustomLayoutEnginePath))
                return GeneralOptions.Instance.CustomLayoutEnginePath;

            layoutEngine = "dot";
        }
        else
            layoutEngine = GeneralOptions.Instance.LayoutEngine.ToString().ToLower();

        enginePath = GeneralOptions.Instance.RuntimeType switch
        {
            RuntimeType.Local => string.Empty,
            RuntimeType.Custom when !string.IsNullOrWhiteSpace(GeneralOptions.Instance.CustomRuntimePath) =>
                GeneralOptions.Instance.CustomRuntimePath,
            _ => enginePath
        };

        return Path.Combine(enginePath, layoutEngine);
    }
}