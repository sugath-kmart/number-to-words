using System;

namespace NumberToWordsConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Price to convert to words");

            var convertedPrice = NumberToWords.ConvertToWords(Console.ReadLine());

            Console.WriteLine("Price in words is \n{0}", convertedPrice);
            Console.ReadKey();
        }
    }
}
