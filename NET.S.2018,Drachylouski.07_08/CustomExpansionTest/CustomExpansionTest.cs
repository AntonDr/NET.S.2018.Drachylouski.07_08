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
        [TestCase("Vladimir Putin", "+1 (354) 975-1188", 99999999,"W")]
        public void TestCase1(string name, string number, decimal money,string format)
        {
            IFormatProvider formatProvider = CultureInfo.CurrentCulture;
            Customer customer = new Customer(name, number, money);
            var customerExpansion = new CustomerExpansion.CustomerExpansion();

            string actual = customerExpansion.Format(format, customer, formatProvider);
            string expected = "plus one three five four nine seven five one one eight eight";
            Assert.True(actual==expected);
        }
    }
}
