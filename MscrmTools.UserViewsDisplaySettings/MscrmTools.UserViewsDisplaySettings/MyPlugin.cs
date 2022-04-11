using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.UserViewsDisplaySettings
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "User Views Display Settings"),
        ExportMetadata("Description", "Apply views display configuration to multiple users"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAHsUExURWBgYL1hYeVMTP8AAManp//MzL+/v//////Cwv+Zmf+Fhf8zM/f3/NHS7rm85rG047y/59nb8fv7/eXm9Zqe20VNvBEcqgsWqBYgrFdfw6mt4PDx+fcyNpImZiQZmwsWpzcbkqgoXNmEmzwwpBYgq1hfwoCBzI2M0Hp8y0lQvRIcql9DouiNms3P7So0s0ZPvcnM7P39/vj4/Lq95is0sz5Huuvs+P/g4NuxxiAlq/Lz+vPz+/7+/9ja8S85tUA9r+q9yfJhaUYQf7W45DI7tWBnxtPV76Oo3msNZYmP1Vhgw7a55BAbqiErr9TW8Pv7/ikyshwmroCF0YaM01BYwUZOvbu95o2S1jE7tVdewl5lxRkjrdze8igysnqAz5CV10pSvlZewqysrN/f35WYyw4ZqElRvvf3+9PV7iIsrzxFuejp9u/w+SAqrxIdqbu91V1dYSgvj7e649LU7YSK0U9Xu46T1efo9Y2S1DU7g1tcYxwlmSo0stbY77O34h0nrSsyjFVXaB0mmC84tKCl3Pn5/O3u9x0orVxdYiwyjA0YpSkysUlQuVRcvERLuA8apDk+gF5eYV9fYEhLcx0lmCYukE5QbjA2iBQdoBAaow4ZpBUfnh8nljc8glNUalhZZlRValJUa1RVaVlaZbK/U8AAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAF4SURBVDhPzZDVUgNBEEUXbSRACBKCBXcL7u7u7u7u7q4BgvuPMt0ZFijIK8V52WtVPbXC/0BPXzc00DfQzV8NDI10QwNj0A0fmJj+jjgwM/8dcSAisbC0klrLuGN8G9jY2tnLEQeFoxPP+ABPOLu4Ukso3dy/nWCP9PDEwsvbx9fPPwBlYNCXRwIEh2AYGqZiOjwiEk1U9OeJmNg46uMBVAmJAEnJaFNSxUFaOgYOYQAZisysbIAc9PJccZBHPl8FBYXsW1QMJaWUSPnAqYxsOagUJCoAKklUhWsH1eTkNZBQS6IOoJ5EQ6N2IGki2wyJWSRaAFpJtMlo0N7R2YW2uwd6+9i3fwAGhzAYHumggSCMjqEPGAeYmJyangGYRa+c4zVjfgGTxSX8/YzlFbSro7xF1tYx2tjcYvX27A6asV3eadnd28f04PDomO6fnJ7x5gP1+YUSG0J5qeHxV9Saq4vrm9ubu/uHRx794Ozp+eX1Tc0dQxDeAaTUU3g6loXaAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#606060"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "White")]
    public class MyPlugin : PluginBase, IPayPalPlugin
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        public string DonationDescription => "Donation for XrmToolBox tool User Views Display Settings";
        public string EmailAccount => "tanguy92@hotmail.com";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}