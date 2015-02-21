using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPlugins
{
    public abstract class Plugin : IPlugin
    {
        public abstract List<string> ExtractWords(string file);
        public abstract List<Frequency> Top25(List<string> text);
        public abstract void Print(List<Frequency> freqs);
    }
}
