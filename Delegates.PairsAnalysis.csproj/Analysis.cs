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
			return data.MaxIndex();
			//return new MaxPauseFinder().Analyze(data);
        }

		public static int MaxIndex<Tin>(this IEnumerable<Tin> inputCollection)
		{
			if (inputCollection.Count() < 2)
				throw new ArgumentException();
			var temp = new List<double>();
			for (int i = 0; i < inputCollection.Count() - 1; i++)
				temp.Add(Process(inputCollection.ElementAt(i), inputCollection.ElementAt(i + 1)));
			return Aggregate(temp);
		}

		private static int Aggregate(List<double> temp)
		{
			if (temp.Count == 0) throw new ArgumentException();
			var max = temp[0];
			var bestIndex = 0;
			for (int i = 1; i < temp.Count; i++)
				if (temp[i] > max)
				{
					max = temp[i];
					bestIndex = i;
				}
			return bestIndex;
		}

		private static double Process<Tin>(Tin source1, Tin source2)
		{
			DateTime s1 = Convert.ToDateTime(source1);
			DateTime s2 = Convert.ToDateTime(source2);
			return (s2 - s1).TotalSeconds;
		}

		//public static double FindAverageRelativeDifference(params double[] data)
  //      {
		//	//data.Pairs();
		//	return new AverageDifferenceFinder().Analyze(data);
  //      }

		
		

		


		//public static Tuple<T,T> Pairs<T>(this IEnumerable<T> inputCollection)
		//{
		//	throw new NotImplementedException();
		//}
	}

}
