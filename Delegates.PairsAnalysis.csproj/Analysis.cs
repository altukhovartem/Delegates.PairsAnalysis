using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates.PairsAnalysis
{
    public static class Analysis
    {
        public static int FindMaxPeriodIndex(params DateTime[] data)
        {
			//var x = data.ToPairs((date1, date2) => (date2 - date1).TotalSeconds);
			//var y = data.ToPairs1((date1, date2) => (date2 - date1).TotalSeconds);

			return data
				.ToPairs((date1, date2) => (date2 - date1).TotalSeconds)
				.MaxIndex();
		}

		public static double FindAverageRelativeDifference(params double[] data)
		{
			return data
				.ToPairs((numb1, numb2) => (numb2 - numb1) / numb1)
				.AverageDifference(
					(sum,nextNumb) => sum + nextNumb, 
					(sum,count) => sum / count);
		}

		//public static IEnumerable<Tout> ToPairs1<Tin, Tout>(this IEnumerable<Tin> inputCollection, Func<Tin, Tin, Tout> process)
		//{
		//	List<Tin> inputCollectionToList = inputCollection.ToList();
		//	if (inputCollectionToList.Count < 2)
		//		throw new ArgumentException();
		//	List<Tout> resultCollection = new List<Tout>();
		//	for (int i = 0; i < inputCollectionToList.Count - 1; i++)
		//		resultCollection.Add(process(inputCollectionToList[i], inputCollectionToList[i + 1]));
		//	return resultCollection;
		//}

		//public static int MaxIndex<Tin>(this IEnumerable<Tin> inputCollection)
		//	where Tin : IComparable
		//{
		//	List<Tin> inputCollectionToList = inputCollection.ToList();
		//	if (inputCollectionToList.Count == 0) throw new ArgumentException();
		//	var max = inputCollectionToList[0];
		//	var bestIndex = 0;
		//	for (int i = 0; i < inputCollectionToList.Count; i++)
		//		if (inputCollectionToList[i].CompareTo(max) == 1)
		//		{
		//			max = inputCollectionToList[i];
		//			bestIndex = i;
		//		}
		//	return bestIndex;
		//}

		//public static Tin AverageDifference<Tin>(this IEnumerable<Tin> inputCollection, Func<Tin, Tin, Tin> sumup, Func<Tin, int, Tin> average)
		//{
		//	List<Tin> inputCollectionToList = inputCollection.ToList();
		//	Tin sum = default(Tin);
		//	for (int i = 0; i < inputCollectionToList.Count; i++)
		//		sum = sumup(sum, inputCollectionToList[i]);
		//	return average(sum, inputCollectionToList.Count);
		//}

		//public static IEnumerable<Tuple<T, T>> Pairs<T>(this IEnumerable<T> inputCollection)
		//{
		//	List<T> inputCollectionToList = inputCollection.ToList();
		//	if (inputCollectionToList.Count < 2)
		//		throw new ArgumentException();
		//	List<Tuple<T, T>> resultCollectionOfTuples = new List<Tuple<T, T>>();
		//	for (int i = 0; i < inputCollectionToList.Count - 1; i++)
		//	{
		//		Tuple<T, T> currentTuple = Tuple.Create(inputCollectionToList[i], inputCollectionToList[i + 1]);
		//		resultCollectionOfTuples.Add(currentTuple);
		//	}
		//	return resultCollectionOfTuples;
		//}

		public static IEnumerable<Tout> ToPairs<Tin, Tout>(this IEnumerable<Tin> inputCollection, Func<Tin, Tin, Tout> process)
		{
			Tin previousItem = default(Tin);
			bool isFirstItem = true;
			bool emptyCollection = true;

			foreach (var item in inputCollection)
			{
				if (isFirstItem)
				{
					previousItem = item;
					isFirstItem = false;
				}
				else
				{
					yield return process(previousItem, item);
					previousItem = item;
					emptyCollection = false;
				}
			}

			if (emptyCollection) throw new ArgumentException();


		}

		public static int MaxIndex<Tin>(this IEnumerable<Tin> inputCollection)
			where Tin : IComparable
		{
			bool isFirstItem = true;
			bool emptyCollection = true;
			Tin maxItem = default(Tin);
			int currentIndex = 0;
			int maxIndex = 0;

			foreach (var item in inputCollection)
			{
				if (isFirstItem)
				{
					maxItem = item;
					maxIndex = currentIndex;
					isFirstItem = false;
					emptyCollection = false;
				}
				else
				{
					if (item.CompareTo(maxItem) == 1)
					{
						maxItem = item;
						maxIndex = currentIndex;
					}
				}
				currentIndex++;
			}
			if (emptyCollection) throw new ArgumentException();
			return maxIndex;
		}



		public static Tin AverageDifference<Tin>(this IEnumerable<Tin> inputCollection, Func<Tin,Tin,Tin> sumup, Func<Tin,int,Tin> average)
		{
			Tin sum = default(Tin);
			int count = 0;
			foreach (var item in inputCollection)
			{
				sum = sumup(sum, item);
				count++;
			}
			return average(sum, count);
		}

		public static IEnumerable<Tuple<T, T>> Pairs<T>(this IEnumerable<T> inputCollection)
		{
			T previousItem = default(T);
			bool isFirstItem = true;
			bool emptyCollection = true;

			foreach (var item in inputCollection)
			{
				if (isFirstItem)
				{
					previousItem = item;
				}
				else
				{
					yield return Tuple.Create(previousItem, item);
					emptyCollection = false;
				}
			}
			if (emptyCollection) throw new ArgumentException();
		}
	}

}
