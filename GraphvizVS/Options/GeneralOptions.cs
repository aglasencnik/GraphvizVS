using System.ComponentModel;
using GraphvizVS.Enums;

namespace GraphvizVS.Options;

/// <summary>
/// Represents the general options page.
/// </summary>
public class GeneralOptions : BaseOptionModel<GeneralOptions>
{
    /// <summary>
    /// Gets or sets the runtime type setting.
    /// </summary>
    [Category("Runtime Settings")]
    [DisplayName("Runtime Type")]
    [Description("Select the runtime type you want to use.")]
    [DefaultValue(RuntimeType.Ebedded)]
    [TypeConverter(typeof(EnumConverter))]
    public RuntimeType RuntimeType { get; set; } = RuntimeType.Ebedded;

    /// <summary>
    /// Gets or sets the custom runtime path setting.
    /// </summary>
    [Category("Runtime Settings")]
    [DisplayName("Custom Runtime Path")]
    [Description("Insert the custom runtime folder path (path where binaries of Graphviz are located).")]
    [DefaultValue("")]
    public string CustomRuntimePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the additional flags.
    /// </summary>
    [Category("Runtime settings")]
    [DisplayName("Additional flags")]
    [Description("Insert any additional flags you want to use, such as -Gname, -Nname and more.")]
    [DefaultValue("")]
    public string AdditionalFlags { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the layout engine setting.
    /// </summary>
    [Category("Layout Engine Settings")]
    [DisplayName("Layout Engine")]
    [Description("Select the layout engine you want to use.")]
    [DefaultValue(LayoutEngine.Dot)]
    [TypeConverter(typeof(EnumConverter))]
    public LayoutEngine LayoutEngine { get; set; } = LayoutEngine.Dot;

    /// <summary>
    /// Gets or sets the custom layout engine path setting.
    /// </summary>
    [Category("Layout Engine Settings")]
    [DisplayName("Custom Layout Engine Path")]
    [Description("Insert the custom layout engine path (path of the .exe file).")]
    [DefaultValue("")]
    public string CustomLayoutEnginePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the layout engine setting.
    /// </summary>
    [Category("Export Settings")]
    [DisplayName("Export Output Format")]
    [Description("Select the export output file format.")]
    [DefaultValue(OutputFormat.SVG)]
    [TypeConverter(typeof(EnumConverter))]
    public OutputFormat ExportOutputFormat { get; set; } = OutputFormat.SVG;
}