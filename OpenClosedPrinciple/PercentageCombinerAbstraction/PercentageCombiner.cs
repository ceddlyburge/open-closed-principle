using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombinerAbstraction
{
    public class PercentageCombiner : IPercentageCombiner
    {
        public double CombinePercentages(params double[] percentages)
        {
            double combination = 1;
            foreach (var percentage in percentages)
                combination *= 1 - percentage;
            return 1 - combination;
        }
    }
}
