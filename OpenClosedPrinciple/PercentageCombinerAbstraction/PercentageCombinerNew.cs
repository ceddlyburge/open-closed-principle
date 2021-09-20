using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombinerAbstraction
{
    public class PercentageCombinerNew: IPercentageCombiner
    {
        public double CombinePercentages(params double[] percentages) =>
            percentages.Sum();
    }
}
