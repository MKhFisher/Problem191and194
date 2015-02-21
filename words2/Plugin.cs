using ApplicationPlugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace words2
{
    public class Plugin : ApplicationPlugins.Plugin
    {
        public Plugin()
        {
            //Debugging purposes
            //Console.WriteLine("Running words2.dll");
        }

        public override List<string> ExtractWords(string file)
        {
            List<string> data = new List<string>(Regex.Split(new StreamReader(file).ReadToEnd().ToLower().Replace('_', ' '), "\\W+").ToList());
            HashSet<string> stopwords = new HashSet<string>(new StreamReader("stop_words.txt").ReadToEnd().ToLower().Replace(",\n\n", "").Split(','));
            List<string> result = new List<string>();

            foreach (string word in data)
            {
                if (!stopwords.Contains(word) && word != "s")
                {
                    result.Add(word);
                }
            }

            return result;
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