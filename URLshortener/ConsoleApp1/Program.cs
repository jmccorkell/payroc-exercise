using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    public class ShortURL
    {
		public static readonly string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ-_";
		public static readonly int Base = Alphabet.Length;

		public static string Encode(int num)
		{
			if (num == 0) return Alphabet[0].ToString();
			
			var s = string.Empty;
			
			while (num > 0)
			{
				s += Alphabet[num % Base];
				num = num / Base;
			}
			return string.Join(string.Empty, s.Reverse());
		}

		public static int Decode(string str)
		{
			var num = 0;
			foreach (var i in str)
			{
				num = (num * Base) + Alphabet.IndexOf(i);
			}
			return num;
		}

		static void Main(string[] args)
        {
			string url;
			int decodedURL;
			string encodedURL;

			Console.WriteLine("Please enter the URL you want shortened: ");
			url=Console.ReadLine();
			decodedURL = Decode(url);
			encodedURL = Encode(decodedURL);
			Console.WriteLine(encodedURL);
        }
    }
}
