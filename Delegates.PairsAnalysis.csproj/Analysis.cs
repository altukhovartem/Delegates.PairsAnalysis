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

			return data
				.ToPairs((date1, date2) => (date2 - date1).TotalSeconds)
				.MaxIndex();
		}

		public static double FindAverageRelativeDifference(params double[] data)
		{
			return data
				.ToPairs<double, double>((numb1, numb2) => (numb2 - numb1) / numb1)
				.AverageDifference<double>(
					(sum,nextNumb) => sum + nextNumb, 
					(sum,count) => sum / count);
		}

		public static IEnumerable<Tout> ToPairs<Tin, Tout>(this IEnumerable<Tin> inputCollection, Func<Tin,Tin,Tout> process)
		{
			if (inputCollection.Count() < 2)
				throw new ArgumentException();
			List<Tin> inputCollectionToList = inputCollection.ToList();
			List<Tout> resultCollection = new List<Tout>();
			for (int i = 0; i < inputCollection.Count() - 1; i++)
				resultCollection.Add(process(inputCollectionToList[i], inputCollectionToList[i + 1]));
			return resultCollection;
		}

		public static int MaxIndex<Tin>(this IEnumerable<Tin> inputCollection)
			where Tin : IComparable
		{
			
			if (inputCollection.Count() == 0) throw new ArgumentException();
			var max = inputCollection.ElementAt(0);
			var bestIndex = 0;
			for (int i = 0; i < inputCollection.Count(); i++)
				if (inputCollection.ElementAt(i).CompareTo(max) == 1)
				{
					max = inputCollection.ElementAt(i);
					bestIndex = i;
				}
			return bestIndex;
		}

		public static Tin AverageDifference<Tin>(this IEnumerable<Tin> inputCollection, Func<Tin,Tin,Tin> sumup, Func<Tin,int,Tin> average)
		{
			Tin sum = default(Tin);
			for (int i = 0; i < inputCollection.Count(); i++)
				sum = sumup(sum, inputCollection.ElementAt(i));
			return average(sum, inputCollection.Count());
		}

		//public static Tuple<T, T> Pairs<T>(this IEnumerable<T> inputCollection)
		//{
		//	return new Tuple<T, T>(inputCollection.ElementAt(1), inputCollection.ElementAt(2));
		//}
	}

}
