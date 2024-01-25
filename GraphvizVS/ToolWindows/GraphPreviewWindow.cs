using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GraphvizVS.ToolWindows;

/// <summary>
/// Represents the tool window that shows the graph preview.
/// </summary>
public class GraphPreviewWindow : BaseToolWindow<GraphPreviewWindow>
{
    /// <summary>
    /// Gets the tool window's title.
    /// </summary>
    /// <param name="toolWindowId">Tool window id.</param>
    /// <returns>Tool window title.</returns>
    public override string GetTitle(int toolWindowId) => "Graph Preview";

    /// <summary>
    /// Gets the tool window's type.
    /// </summary>
    public override Type PaneType => typeof(Pane);

    /// <summary>
    /// Creates the tool window's content.
    /// </summary>
    /// <param name="toolWindowId">Tool window id.</param>
    /// <param name="cancellationToken">CancellationToken object.</param>
    /// <returns>FrameworkElement object.</returns>
    public override Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
    {
        return Task.FromResult<FrameworkElement>(new GraphPreviewWindowControl());
    }

    /// <summary>
    /// Represents the tool window pane.
    /// </summary>
    [Guid("28641f17-c696-4cc8-b23e-27910d1fbb2b")]
    internal class Pane : ToolWindowPane
    {
        public Pane()
        {
            BitmapImageMoniker = KnownMonikers.DependancyGraphAncestor;
        }
    }
}