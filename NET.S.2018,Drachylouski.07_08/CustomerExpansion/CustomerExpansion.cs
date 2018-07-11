using System;
using System.Globalization;
using System.Text;
using Task1Logic;

namespace CustomerExpansion
{
    /// <summary>
    /// Expansion for customer class
    /// </summary>
    /// <seealso cref="System.ICustomFormatter" />
    /// <seealso cref="System.IFormatProvider" />
    public sealed class CustomerExpansion : ICustomFormatter, IFormatProvider
    {
        private static readonly string[] numberWords =
            "zero one two three four five six seven eight nine plus".Split();

        public IFormatProvider Parent { get; private set; }

        public CustomerExpansion() : this(CultureInfo.CurrentCulture) {}

        public CustomerExpansion(IFormatProvider parent)
        {
            Parent = parent ?? CultureInfo.CurrentCulture;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "W")
            {
                return string.Format(Parent, "{0:" + format + "}", arg);
            }

            StringBuilder result = new StringBuilder();

            var customer = arg as Customer;

            if (!ReferenceEquals(customer, null))
            {
                string digitList = string.Format(CultureInfo.InvariantCulture, "{0}", customer.ContactPhone);
                foreach (char digit in digitList)
                {
                    int i = "0123456789+".IndexOf(digit);
                    if (i == -1) continue;
                    if (result.Length > 0) result.Append(' ');
                    result.Append(numberWords[i]);
                }

                return result.ToString();
            }

            return arg.ToString();
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
}
