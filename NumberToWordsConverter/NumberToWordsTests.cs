using System;
using Shouldly;
using Xunit;

namespace NumberToWordsConverter
{
    public class NumberToWordsTests
    {
        [Theory]
        [InlineData("0", "Zero Dollars")]
        [InlineData("2.52", "Two Dollars And Fifty Two Cents")]
        [InlineData("7", "Seven Dollars")]
        [InlineData("13.76", "Thirteen Dollars And Seventy Six Cents")]
        [InlineData("463.27", "Four Hundred And Sixty Three Dollars And Twenty Seven Cents")]
        [InlineData("1048", "One Thousand  Forty Eight Dollars")]
        [InlineData("17345.91", "Seventeen Thousand  Three Hundred And Forty Five Dollars And Ninety One Cents")]
        [InlineData("99999.99", "Ninety Nine Thousand  Nine Hundred And Ninety Nine Dollars And Ninety Nine Cents")]
        public void ConvertToWords_Success(string number, string convertedNumber)
        {
            var numberInWords = NumberToWords.ConvertToWords(number);
            numberInWords.ShouldBe(convertedNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("bla bla")]
        [InlineData("123.456")]
        [InlineData("123 .456")]
        [InlineData("123. 456")]
        [InlineData("abc.12")]
        public void ConvertToWords_InvalidPrice(string number)
        {
            Assert.Throws<ArgumentException>(() => NumberToWords.ConvertToWords(number));
        }

        [Theory]
        [InlineData("-0.01")]
        [InlineData("-100")]
        [InlineData("10000001")]
        public void ConvertToWords_InvalidRange(string number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberToWords.ConvertToWords(number));
        }
    }
}
