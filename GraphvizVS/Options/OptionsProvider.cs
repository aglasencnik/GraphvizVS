using System.Runtime.InteropServices;

namespace GraphvizVS.Options;

/// <summary>
/// Provides the provider to the options pages.
/// </summary>
internal partial class OptionsProvider
{
    /// <summary>
    /// Represents the general options page.
    /// </summary>
    [ComVisible(true)]
    public class GeneralOptionsProvider : BaseOptionPage<GeneralOptions> { }
}