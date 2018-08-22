using SieveOfEratosthenes.Classes;
using System;
using System.Linq;

namespace SieveOfEratosthenes
{
	class Program
	{
		static long poczatekPrzedzialu = 33;
		static long koniecPrzedzialu = 17389;

		static void Main(string[] args)
		{
			while (true)
			{
				PobierzDane(ref poczatekPrzedzialu, ref koniecPrzedzialu);
				Calculations.SzukajSitemEratostenesaLP(poczatekPrzedzialu, koniecPrzedzialu);
				Calculations.SzukajRownolegleLP(poczatekPrzedzialu, koniecPrzedzialu);
				Calculations.SzukajSekwencyjnieLP(poczatekPrzedzialu, koniecPrzedzialu);
			}
		}

		static void PobierzDane(ref long poczatekPrzedzialu, ref long koniecPrzedzialu)
		{
			Console.WriteLine("\nWpisz początek i koniec przedziału, oddzielone spacją i wciśnij ENTER");
			long[] tab = Console.ReadLine().Split(' ').Select(n => Convert.ToInt64(n)).ToArray();
			poczatekPrzedzialu = tab[0];
			koniecPrzedzialu = tab[1];
			Console.WriteLine();
		}
	}
}
