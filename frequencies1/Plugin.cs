using ApplicationPlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace frequencies1
{
    public class Plugin : ApplicationPlugins.Plugin
    {
        public Plugin()
        {
            //Debugging purposes
            //Console.WriteLine("Running frequencies1.dll");
        }

        public override List<Frequency> Top25(List<string> text)
        {
            Dictionary<string, int> duplicates = new Dictionary<string, int>();
            text.ForEach(word => duplicates[word] = (duplicates.ContainsKey(word) ? (int)(duplicates[word]) + 1 : 1));

            List<Frequency> result = new List<Frequency>();

            duplicates.OrderByDescending(x => x.Value).Take(25).ToList().ForEach(x => result.Add(new Frequency { term = x.Key, frequency = x.Value }));
            return result;
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