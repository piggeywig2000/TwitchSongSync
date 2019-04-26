using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Stuff I imported
using CsvHelper.Configuration;

namespace TwitchSongSync
{
    public class ScriptEntry
    {
        public double Time { get; set; }
        public string Content { get; set; }
        public int User { get; set; }
    }

    public sealed class ScriptEntryMap : ClassMap<ScriptEntry>
    {
        public ScriptEntryMap()
        {
            Map(m => m.Time).Index(0);
            Map(m => m.Content).Index(1);
        }
    }
}
