using System.Windows;
using System.Windows.Controls;

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

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        VS.MessageBox.Show("GraphPreviewWindowControl", "Button clicked");
    }
}