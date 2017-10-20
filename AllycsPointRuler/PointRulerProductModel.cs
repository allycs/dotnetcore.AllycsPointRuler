using System;
using System.Collections.Generic;
using System.Text;

namespace AllycsPointRuler
{
    public class PointRulerProductModel
    {
        public Int64 TotalProducePoints { get; set; } = 0;
        public Int64 TotalProduceAmounts { get; set; } = 0;
        public List<CalMethodModel> CalMethods { get; set; } = new List<CalMethodModel>();
    }
}
