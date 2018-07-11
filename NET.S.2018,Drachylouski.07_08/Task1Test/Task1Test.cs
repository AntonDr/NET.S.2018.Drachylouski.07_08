using NUnit.Framework;
using System;
using System.Globalization;
using Task1Logic;
using System.Threading;

namespace Task1Test
{

    [TestFixture]
    public class Task1Test
    {
        [TestCase("Vladimir Putin", "+1 (354) 975-1188", 99999999)]
        [TestCase("Anton Drachylouski", "+37 (525) 775-7834", 10000000)]
        [TestCase("Vova Sidorov", "+7 (926) 123-4567",150)]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 14141414)]
        public void TestCase(string name, string number, decimal money)
        {
            Customer obj = new Customer(name,number,money);

            string actual = obj.ToString("NPR", CultureInfo.InvariantCulture);

            string expected = obj.ToString();

            Assert.True(actual==expected);
        }

        [TestCase("Vladimir Putin", "+1 (354) 975-1188", 99999999)]
        [TestCase("Anton Drachylouski", "+37 (525) 775-7834", 10000000)]
        [TestCase("Vova Sidorov", "+7 (926) 123-4567", 150)]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 14141414)]
        public void TestCase2(string name, string number, decimal money)
        {
            Customer obj = new Customer(name, number, money);

            string actual = obj.ToString("NP", CultureInfo.InvariantCulture);

            string expected = $"{obj.Name}{obj.ContactPhone}";

            Assert.True(actual == expected);
        }

        [TestCase("Vladimir Putin", "+1 (354) 975-1188", 99999999)]
        [TestCase("Anton Drachylouski", "+37 (525) 775-7834", 10000000)]
        [TestCase("Vova Sidorov", "+7 (926) 123-4567", 150)]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 14141414)]
        public void TestCase3(string name, string number, decimal money)
        {
            Customer obj = new Customer(name, number, money);

            string actual = obj.ToString("R", CultureInfo.InvariantCulture);

            string expected = $"{obj.Revenue}";

            Assert.True(actual == expected);
        }

        [TestCase("dakdk1k 999dzm", "+1 (354) 975-1188", 99999999)]
        [TestCase("Anton Drachylouski", "adadadadadada", 10000000)]
        public void TestCaseException(string name, string number, decimal money)
        {
            Assert.Throws<ArgumentException>(() => new Customer(name, number, money));
        }



    }
}
