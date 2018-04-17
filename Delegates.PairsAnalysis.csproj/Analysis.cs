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
			
			return new MaxPauseFinder().Analyze(data);
        }

        public static double FindAverageRelativeDifference(params double[] data)
        {
			//data.Pairs();
			return new AverageDifferenceFinder().Analyze(data);
        }

		public static Tout MaxIndex<Tin, TInter, Tout>(this IEnumerable<Tin> inputCollection, Func<Tin,Tin,TInter> process, Func<List<TInter>, Tout> aggregate)
		{

			if (inputCollection.Count() < 2)
				throw new ArgumentException();
			var temp = new List<TInter>();
			for (int i = 0; i < inputCollection.Count() - 1; i++)
				temp.Add(process(inputCollection.ElementAt(i), inputCollection.ElementAt(i)));
			return aggregate(temp);
		}

		public static Tuple<T,T> Pairs<T>(this IEnumerable<T> inputCollection)
		{
			throw new NotImplementedException();
		}
	}

}
