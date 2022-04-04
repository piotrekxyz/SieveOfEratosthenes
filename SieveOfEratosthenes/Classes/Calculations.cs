using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SieveOfEratosthenes.Classes
{
	public static class Calculations
	{
		public static void SzukajRownolegleLP(long poczatekPrzedzialu, long koniecPrzedzialu)
		{
			long licznik = 0;
			Stopwatch timer = new Stopwatch();
			timer.Start();
			Parallel.For(poczatekPrzedzialu, koniecPrzedzialu + 1, i =>
			{
				if (CzyLiczbaJestPierwsza(i))
					Interlocked.Increment(ref licznik);
			});
			Console.WriteLine(string.Format(CultureInfo.InvariantCulture,
				"W przedziale {0:0,0} - {1:0,0} jest\n{2:0,0} liczb pierwszych, policzono Równolegle w {3} s\n", poczatekPrzedzialu, koniecPrzedzialu, licznik, (double)timer.ElapsedMilliseconds / 1000));
		}

		public static void SzukajSekwencyjnieLP(long poczatekPrzedzialu, long koniecPrzedzialu)
		{
			long licznik = 0;
			Stopwatch timer = new Stopwatch();
			timer.Start();
			for (long i = poczatekPrzedzialu; i <= koniecPrzedzialu; i++)
				if (CzyLiczbaJestPierwsza(i))
					licznik++;
			Console.WriteLine(string.Format(CultureInfo.InvariantCulture,
				"W przedziale {0:0,0} - {1:0,0} jest\n{2:0,0} liczb pierwszych, policzono Sekwencyjnie w {3} s\n", poczatekPrzedzialu, koniecPrzedzialu, licznik, (double)timer.ElapsedMilliseconds / 1000));
		}

		public static long SzukajSitemEratostenesaLP(long poczatek, long koniec)
		{
			Stopwatch timer = new Stopwatch();
			timer.Start();
			bool[] tablica = new bool[koniec + 1];  // żeby się indeksy zgadzały z prawdziwymi liczbami
			WykreslajSitem(ref tablica, koniec);
			long iloscLP = PoliczLiczbyPierwszeWTablicy(poczatek, ref tablica);
			Console.WriteLine(string.Format(CultureInfo.InvariantCulture,
				"W przedziale {0:0,0} - {1:0,0} jest\n{2:0,0} liczb pierwszych, policzono Sitem Eratostenesa w {3} s\n", poczatek, koniec, iloscLP, (double)timer.ElapsedMilliseconds / 1000));

			return iloscLP;
		}

		static void WykreslajSitem(ref bool[] tablica, long koniecPrzedzialu)
		{
			tablica[0] = tablica[1] = true; // pierwsze dwa elementy olewamy
			for (long i = 2; i <= Math.Sqrt(tablica.Length - 1); i++)
			{
				if (tablica[i] == false)
				{
					long j = i + i;
					while (j <= koniecPrzedzialu)
					{
						tablica[j] = true;
						j += i;
					}
				}
			}
		}

		static long PoliczLiczbyPierwszeWTablicy(long poczatekPrzedzialu, ref bool[] tablica)
		{
			if (poczatekPrzedzialu == 2)
				return tablica.Count(n => n == false);

			long licznik = 0;
			for (long i = poczatekPrzedzialu; i < tablica.Length; i++)
				if (tablica[i] == false)
					licznik++;
			return licznik;
		}

		static bool CzyLiczbaJestPierwsza(long liczba)
		{
			if (liczba < 2)
				return false;
			if (liczba == 2 || liczba == 3)
				return true;
			for (long i = 2; i <= Math.Sqrt(liczba); i++)
				if (liczba % i == 0)
					return false;
			return true;
		}
	}
}
