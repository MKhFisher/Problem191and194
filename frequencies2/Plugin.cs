using ApplicationPlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace frequencies2
{
    public class Plugin : ApplicationPlugins.Plugin
    {
        public Plugin()
        {
            //Debugging purposes
            //Console.WriteLine("Running frequencies2.dll");
        }

        public override List<Frequency> Top25(List<string> text)
        {
            Dictionary<string, int> duplicates = new Dictionary<string, int>();

            foreach (string word in text)
            {
                if (duplicates.ContainsKey(word))
                {
                    duplicates[word] += 1;
                }
                else
                {
                    duplicates[word] = 1;
                }
            }

            List<Frequency> result = new List<Frequency>();

            foreach (KeyValuePair<string, int> kvp in duplicates)
            {
                result.Add(new Frequency { term = kvp.Key, frequency = kvp.Value });
            }

            return result.OrderByDescending(x => x.frequency).Take(25).ToList();
        }

        public override List<string> ExtractWords(string file)
        {
            throw new NotImplementedException();
        }

        public override void Print(List<Frequency> freq)
        {
            throw new NotImplementedException();
        }
    }
}
