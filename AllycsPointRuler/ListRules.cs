using System;
using System.Collections.Generic;
using System.Text;

namespace AllycsPointRuler
{
    public class ListRules
    {
        public List<KeyValuePair<string, PointRuler>> OnlyRules { get; set; }
        public List<KeyValuePair<string, PointRuler>> MultiRules { get; set; }
    }
}
