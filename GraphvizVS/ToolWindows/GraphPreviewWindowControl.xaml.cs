using Microsoft.VisualStudio.Imaging;
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
            var infoBar = await VS.InfoBar.CreateAsync(
                ToolWindowGuids80.SolutionExplorer,
                new InfoBarModel([new InfoBarTextSpan("Something went wrong while loading graph preview!")], KnownMonikers.DiagramError)
            );

            if (infoBar != null)
                await infoBar.TryShowInfoBarUIAsync();

            await ex.LogAsync();
        }
    }
}