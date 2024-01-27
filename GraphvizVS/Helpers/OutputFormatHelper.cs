using System.Collections.Generic;
using System.Linq;
using GraphvizVS.Enums;
using GraphvizVS.Models;
using GraphvizVS.Options;

namespace GraphvizVS.Helpers;

/// <summary>
/// Represents the output format helper.
/// </summary>
internal static class OutputFormatHelper
{
    /// <summary>
    /// Gets the output formats.
    /// </summary>
    internal static Dictionary<OutputFormat, OutputFormatModel> OutputFormats = new()
    {
        { OutputFormat.BMP, new OutputFormatModel("BMP", "bmp", "BMP - Windows Bitmap") },
        { OutputFormat.CGIMAGE, new OutputFormatModel("CGImage", "cgimage", "CGImage - Apple Core Graphics") },
        { OutputFormat.DOT, new OutputFormatModel("DOT", "dot", "DOT - Graphviz Language") },
        { OutputFormat.GV, new OutputFormatModel("GV", "gv", "GV - Graphviz Language") },
        { OutputFormat.XDOT, new OutputFormatModel("XDOT", "dot", "XDOT - Graphviz Language") },
        { OutputFormat.XDOT12, new OutputFormatModel("XDOT1.2", "dot", "XDOT1.2 - Graphviz Language") },
        { OutputFormat.XDOT14, new OutputFormatModel("XDOT1.4", "dot", "XDOT1.4 - Graphviz Language") },
        { OutputFormat.EPS, new OutputFormatModel("EPS", "eps", "EPS - Encapsulated PostScript") },
        { OutputFormat.EXR, new OutputFormatModel("EXR", "exr", "EXR - OpenEXR") },
        { OutputFormat.FIG, new OutputFormatModel("FIG", "fig", "FIG - Xfig") },
        { OutputFormat.GD, new OutputFormatModel("GD", "gd", "GD - LibGD") },
        { OutputFormat.GD2, new OutputFormatModel("GD2", "gd2", "GD2 - LibGD") },
        { OutputFormat.GIF, new OutputFormatModel("GIF", "gif", "GIF - Graphics Interchange Format") },
        { OutputFormat.GTK, new OutputFormatModel("GTK", "gtk", "GTK - Formerly GTK+ / GIMP ToolKit") },
        { OutputFormat.ICO, new OutputFormatModel("ICO", "ico", "ICO - Windows Icon") },
        { OutputFormat.IMAP, new OutputFormatModel("IMAP", "imap", "IMAP - Image Map: Server-side and client-side") },
        { OutputFormat.IMAP_NP, new OutputFormatModel("IMAP_NP", "imap_np", "IMAP_NP - Image Map: Server-side and client-side") },
        { OutputFormat.ISMAP, new OutputFormatModel("ISMAP", "ismap", "ISMAP - Image Map: Server-side and client-side") },
        { OutputFormat.CMAP, new OutputFormatModel("CMAP", "cmap", "CMAP - Image Map: Server-side and client-side") },
        { OutputFormat.CMAPX, new OutputFormatModel("CMAPX", "cmapx", "CMAPX - Image Map: Server-side and client-side") },
        { OutputFormat.CMAPX_NP, new OutputFormatModel("CMAPX_NP", "cmapx_np", "CMAPX_NP - Image Map: Server-side and client-side") },
        { OutputFormat.JPG, new OutputFormatModel("JPEG", "jpg", "JPEG - Joint Photographic Experts Group") },
        { OutputFormat.JPEG, new OutputFormatModel("JPEG", "jpeg", "JPEG - Joint Photographic Experts Group") },
        { OutputFormat.JPE, new OutputFormatModel("JPEG", "jpe", "JPEG - Joint Photographic Experts Group") },
        { OutputFormat.JP2, new OutputFormatModel("JPEG 2000", "jp2", "JPEG 2000") },
        { OutputFormat.JSON, new OutputFormatModel("JSON", "json", "JSON - JavaScript Object Notation") },
        { OutputFormat.JSON0, new OutputFormatModel("JSON0", "json", "JSON0 - JavaScript Object Notation") },
        { OutputFormat.DOT_JSON, new OutputFormatModel("DOT_JSON", "json", "DOT_JSON - JavaScript Object Notation") },
        { OutputFormat.XDOT_JSON, new OutputFormatModel("XDOT_JSON", "json", "XDOT_JSON - JavaScript Object Notation") },
        { OutputFormat.PDF, new OutputFormatModel("PDF", "pdf", "PDF - Portable Document Format") },
        { OutputFormat.PIC, new OutputFormatModel("PIC", "pic", "PIC - Brian Kernighan's Diagram Language") },
        { OutputFormat.PCT, new OutputFormatModel("PICT", "pct", "PICT - Apple PICT") },
        { OutputFormat.PICT, new OutputFormatModel("PICT", "pict", "PICT - Apple PICT") },
        { OutputFormat.PLAIN, new OutputFormatModel("Plain Text", "txt", "Plain Text - Simple, line-based language") },
        { OutputFormat.PLAIN_EXT, new OutputFormatModel("Plain Text", "txt", "PLAIN-EXT - Simple, line-based language") },
        { OutputFormat.PNG, new OutputFormatModel("PNG", "png", "PNG - Portable Network Graphics") },
        { OutputFormat.POV, new OutputFormatModel("POV-Ray", "pov", "POV-Ray - Persistence of Vision Raytracer (prototype)") },
        { OutputFormat.PS, new OutputFormatModel("PS", "ps", "PS - Adobe PostScript") },
        { OutputFormat.PS2, new OutputFormatModel("PS/PDF", "ps2", "PS/PDF - Adobe PostScript for Portable Document Format") },
        { OutputFormat.PSD, new OutputFormatModel("PSD", "psd", "PSD - Photoshop") },
        { OutputFormat.SGI, new OutputFormatModel("SGI", "sgi", "SGI - Silicon Graphics Image") },
        { OutputFormat.SVG, new OutputFormatModel("SVG", "svg", "SVG - Scalable Vector Graphics") },
        { OutputFormat.SVGZ, new OutputFormatModel("SVGZ", "svgz", "SVGZ - Scalable Vector Graphics") },
        { OutputFormat.TGA, new OutputFormatModel("TGA", "tga", "TGA - Truevision TARGA") },
        { OutputFormat.TIF, new OutputFormatModel("TIFF", "tif", "TIFF - Tag Image File Format") },
        { OutputFormat.TIFF, new OutputFormatModel("TIFF", "tiff", "TIFF - Tag Image File Format") },
        { OutputFormat.TK, new OutputFormatModel("Tk", "tk", "Tk - Tcl/Tk") },
        { OutputFormat.VML, new OutputFormatModel("VML", "vml", "VML - Vector Markup Language") },
        { OutputFormat.VMLZ, new OutputFormatModel("VMLZ", "vmlz", "VMLZ - Vector Markup Language") },
        { OutputFormat.VRML, new OutputFormatModel("VRML", "vrml", "VRML - Virtual Reality Modeling Language") },
        { OutputFormat.WBMP, new OutputFormatModel("WBMP", "wbmp", "WBMP - Wireless Bitmap") },
        { OutputFormat.WEBP, new OutputFormatModel("WebP", "webp", "WebP - WebP") },
        { OutputFormat.XLIB, new OutputFormatModel("X11", "xlib", "XLIB - X11 Window") },
        { OutputFormat.X11, new OutputFormatModel("X11", "x11", "X11 - X11 Window") }
    };

    /// <summary>
    /// Gets the filter.
    /// </summary>
    /// <returns>A string value.</returns>
    internal static string GetFilter()
    {
        var outputFormat = OutputFormats.FirstOrDefault(x => x.Key == GeneralOptions.Instance.ExportOutputFormat);
        return outputFormat.Value is null ?
            "All files (*.*)|*.*" :
            $"{outputFormat.Value.Description} (*.{outputFormat.Value.Extension})|*.{outputFormat.Value.Extension}|All files (*.*)|*.*";
    }

    /// <summary>
    /// Gets the output format arguments.
    /// </summary>
    /// <returns>A string value.</returns>
    internal static string GetOutputFormatArgument()
    {
        var outputFormat = OutputFormats.FirstOrDefault(x => x.Key == GeneralOptions.Instance.ExportOutputFormat);
        return outputFormat.Value is null ?
            string.Empty :
            $"-T{outputFormat.Value.Extension}";
    }
}