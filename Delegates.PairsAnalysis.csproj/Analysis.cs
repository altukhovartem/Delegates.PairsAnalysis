using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.PairsAnalysis
{
    public static class Analysis
    {
        public static int FindMaxPeriodIndex(params DateTime[] data)
        {
			data.MaxIndex();
			return new MaxPauseFinder().Analyze(data);
        }

        public static double FindAverageRelativeDifference(params double[] data)
        {
			data.Pairs();

			return new AverageDifferenceFinder().Analyze(data);
        }

		public static int MaxIndex<T>(this IEnumerable<T> inputCollection)
		{
			throw new NotImplementedException();
		}

		public static Tuple<T,T> Pairs<T>(this IEnumerable<T> inputCollection)
		{
			throw new NotImplementedException();
		}
	}

}
