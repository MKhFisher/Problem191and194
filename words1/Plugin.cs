using ApplicationPlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace words1
{
    public class Plugin : ApplicationPlugins.Plugin
    {
        public Plugin()
        {
            //Debugging purposes
            //Console.WriteLine("Running words1.dll");
        }

        public override List<string> ExtractWords(string file)
        {
            List<string> text = Regex.Split(new StreamReader(file).ReadToEnd().ToLower().Replace('_', ' '), "\\W+").ToList();
            List<string> stopwords = new StreamReader("stop_words.txt").ReadToEnd().ToLower().Replace(",\n\n", "").Split(',').ToList();

            text.RemoveAll(x => stopwords.Any(y => y == x) || x == "s");

            return text;
        }

        public override List<Frequency> Top25(List<string> text)
        {
            throw new NotImplementedException();
        }

        public override void Print(List<Frequency> freq)
        {
            throw new NotImplementedException();
        }
    }
}
