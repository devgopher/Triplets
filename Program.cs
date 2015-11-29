/*
 * User: Igor
 * Date: 29.11.2015
 * Time: 22:04
 */
using System;
using System.Text;

namespace Triplets
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Триплеты! ");
			Console.WriteLine("Введите исходный текст: ");
			
			var input = String.Empty;
			input = Console.ReadLine();
			
			Console.WriteLine("Наша \"статистика\": ");
			TripletAnalysis.MostFrequentTriplet( input );
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}