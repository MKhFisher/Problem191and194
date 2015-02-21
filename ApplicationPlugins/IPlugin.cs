using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPlugins
{
    public interface IPlugin
    {
        List<string> ExtractWords(string file);
        List<Frequency> Top25(List<string> words);
        void Print(List<Frequency> freqs);
    }
}
