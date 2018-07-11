using System;
using System.Globalization;
using NUnit.Framework;
using CustomerExpansion;
using Task1Logic;

namespace CustomExpansionTest
{
    [TestFixture]
    public class CustomExpansionTest
    {
        [TestCase("Vladimir Putin", "+1 (354) 975-1188", 99999999,"W",ExpectedResult = "plus one three five four nine seven five one one eight eight")]
        [TestCase("Anton Drachylouski", "+37 (525) 775-7834", 10000000,"W",ExpectedResult = "plus three seven five two five seven seven five seven eight three four")]
        [TestCase("Vova Sidorov", "+7 (926) 123-4567", 150,"W",ExpectedResult = "plus seven nine two six one two three four five six seven")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 14141414,"W",ExpectedResult = "plus one four two five five five five zero one zero zero")]
        public string TestCase1(string name, string number, decimal money,string format)
        {
            IFormatProvider formatProvider = CultureInfo.CurrentCulture;
            Customer customer = new Customer(name, number, money);
            var customerExpansion = new CustomerExpansion.CustomerExpansion();

            return customerExpansion.Format(format, customer, formatProvider);
        }
    }
}
