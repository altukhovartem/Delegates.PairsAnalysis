using System;
using System.Collections.Generic;
using System.Linq;
using NUnitLite;

class Program
{
	public static void Method<Tin,Tout>(Func<Tin,Tin,Tout> todo)
	{
		Console.WriteLine(todo);
	}

	static void Main(string[] args)
	{
		new AutoRun().Execute(args);
	}
}
