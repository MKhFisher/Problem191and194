using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Xml;
using ApplicationPlugins;

namespace PluginHost
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument config = new XmlDocument();
            config.Load("config.xml");

            string words = config.DocumentElement.SelectSingleNode("/plugins/words").InnerText.ToString();
            string frequencies = config.DocumentElement.SelectSingleNode("/plugins/frequencies").InnerText.ToString();
            string print = config.DocumentElement.SelectSingleNode("/plugins/print").InnerText.ToString();

            List<string> text = new List<string>();
            List<Frequency> top25 = new List<Frequency>();

            // This piece runs the plugin for extracting words
            string pluginsFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Plugins");
            foreach (string pluginPath in Directory.GetFiles(pluginsFolder, words + ".dll", SearchOption.TopDirectoryOnly))
            {
                Assembly newAssembly = Assembly.LoadFile(pluginPath);
                Type[] types = newAssembly.GetExportedTypes();
                foreach (var type in types)
                {
                    //If Type is a class and implements IPlugin interface
                    if (type.IsClass && (type.GetInterface(typeof(ApplicationPlugins.IPlugin).FullName) != null))
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        var plugin = ctor.Invoke(new object[] { }) as ApplicationPlugins.IPlugin;

                        text = plugin.ExtractWords(args[0]);
                    }
                }
            }

            // This piece runs the plugin for top25 frequencies
            foreach (string pluginPath in Directory.GetFiles(pluginsFolder, frequencies + ".dll", SearchOption.TopDirectoryOnly))
            {
                Assembly newAssembly = Assembly.LoadFile(pluginPath);
                Type[] types = newAssembly.GetExportedTypes();
                foreach (var type in types)
                {
                    //If Type is a class and implements IPlugin interface
                    if (type.IsClass && (type.GetInterface(typeof(ApplicationPlugins.IPlugin).FullName) != null))
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        var plugin = ctor.Invoke(new object[] { }) as ApplicationPlugins.IPlugin;

                        top25 = plugin.Top25(text);
                    }
                }
            }

            // This piece runs the plugin for print
            foreach (string pluginPath in Directory.GetFiles(pluginsFolder, print + ".dll", SearchOption.TopDirectoryOnly))
            {
                Assembly newAssembly = Assembly.LoadFile(pluginPath);
                Type[] types = newAssembly.GetExportedTypes();
                foreach (var type in types)
                {
                    //If Type is a class and implements IPlugin interface
                    if (type.IsClass && (type.GetInterface(typeof(ApplicationPlugins.IPlugin).FullName) != null))
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        var plugin = ctor.Invoke(new object[] { }) as ApplicationPlugins.IPlugin;

                        plugin.Print(top25);
                    }
                }
            }
        }
    }
}
