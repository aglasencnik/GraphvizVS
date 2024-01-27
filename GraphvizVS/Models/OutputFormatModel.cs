namespace GraphvizVS.Models;

/// <summary>
/// Represents the output format model.
/// </summary>
internal class OutputFormatModel
{
    /// <summary>
    /// Gets or sets the format.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// Gets or sets the extension.
    /// </summary>
    public string Extension { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    public OutputFormatModel()
    {
    }

    public OutputFormatModel(string format, string extension, string description)
    {
        Format = format;
        Extension = extension;
        Description = description;
    }
}