using System.IO;
using System.Windows.Controls;
using Microsoft.VisualStudio.Shell.Interop;
using CliWrap;
using GraphvizVS.Helpers;
using GraphvizVS.Options;
using System.Collections.Generic;
using System.Windows.Media;
using CliWrap.Buffered;
using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;

namespace GraphvizVS.ToolWindows;

/// <summary>
/// Represents the graph preview window control.
/// </summary>
public partial class GraphPreviewWindowControl : UserControl
{
    public GraphPreviewWindowControl()
    {
        InitializeComponent();
    }

    public async Task UpdatePreviewWindow(string documentPath)
    {
        try
        {
            if (!File.Exists(documentPath))
                return;

            var flags = new List<string>();

            if (!string.IsNullOrWhiteSpace(GeneralOptions.Instance.AdditionalFlags))
                flags.Add(GeneralOptions.Instance.AdditionalFlags);

            flags.Add("-Tsvg");
            flags.Add(documentPath);

            var result = await Cli.Wrap(CommandLineHelper.GetEnginePath())
                .WithArguments(flags)
                .ExecuteBufferedAsync();

            if (!result.IsSuccess)
                return;

            var tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, result.StandardOutput);

            var settings = new WpfDrawingSettings
            {
                IncludeRuntime = true
            };
            var converter = new FileSvgReader(settings);
            var drawing = converter.Read(tempFileName);
            PreviewImage.Source = new DrawingImage(drawing);

            File.Delete(tempFileName);
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
}