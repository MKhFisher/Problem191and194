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
            //Console.WriteLine("Running print2.dll");
        }

        public override void Print(List<Frequency> freqs)
        {
            freqs.ForEach(x => Console.WriteLine("{0}  -  {1}", x.term, x.frequency));
        }

        public override List<string> ExtractWords(string file)
        {
            throw new NotImplementedException();
        }

        public override List<Frequency> Top25(List<string> text)
        {
            throw new NotImplementedException();
        }
    }
}