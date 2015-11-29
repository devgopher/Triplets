/*
 * User: Igor
 * Date: 29.11.2015
 * Time: 22:05
 */
using System;
using System.Linq;
using System.Collections.Generic;

namespace Triplets
{
	/// <summary>
	/// Анализатор триплетов
	/// </summary>
	public static class TripletAnalysis
	{
		static readonly Dictionary< string, int > triplets = new Dictionary< string, int >();

		static char[] specials = new char[] {
			'\r',
			'\n',
			'\t',
			'\0',
			' '
		};
		
		
		/// <summary>
		/// Исключаем спецсимволы
		/// </summary>
		/// <param name="input">Текст</param>
		/// <returns></returns>
		private static string ExcludeSpecial( string input ) {
			var ret = input;
			
			foreach ( var chr in specials ) {
				ret = ret.Replace( chr.ToString(), String.Empty );
			}

			return ret;
		}

		/// <summary>
		/// Выявляем наиболее часто встречающиеся триплеты
		/// </summary>
		/// <param name="input">Текст</param>
		public static void MostFrequentTriplet( string input ) {
			Console.WriteLine("Производим подсчет комбинаций...");
			
			Analyse( input );
			
			// Сортировка по убыванию частоты использования (quicksort)
			var sorted = triplets.OrderByDescending( x => x.Value ).ToArray();
			
			// Отбираем самые "частые"
			var most_frequent =
				from srt in sorted
				where srt.Value == sorted[0].Value
				select srt;
			
			// ... и выводим их на экран
			Console.WriteLine( "Наиболее часто встречаются: " );
			
			var mfa = most_frequent.ToArray();
			string output_string = String.Empty;
			
			if ( mfa.Any() ) {
				for ( int i = 0; i < mfa.Count(); ++i ) {
					if ( i == 0 ) {
						output_string = mfa[i].Key;
					} else {
						output_string += ","+mfa[i].Key;
					}
				}
				Console.WriteLine(String.Format("{0}\t{1}",
				                                output_string,
				                                mfa[0].Value));
			}
		}
		
		/// <summary>
		/// Выявление триплетов и подсчет статистики их использования
		/// </summary>
		/// <param name="input"></param>
		public static void Analyse( string input ) {
			var arr = input.Split( ',' );
			
			foreach ( var strg in arr ) {
				AnalyseWord( strg );
			}
		}
		
		public static void AnalyseWord( string word ) {
			word = word.Trim().ToLower();
			word = ExcludeSpecial( word );
			
			string tmp = String.Empty;

			for ( int pos = 0; pos < word.Length-2; ++pos ) {
				tmp = word.Substring( pos, 3 );
				if ( !triplets.ContainsKey(tmp) )
					triplets[tmp] = 1;
				else
					++(triplets[tmp]);
				
			}
		}
	}
}
