using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1Logic
{

    /// <summary>
    /// Custom class
    /// </summary>
    /// <seealso cref="System.IFormattable" />
    public sealed class Customer : IFormattable
    {        
        private static readonly string patternPhoneNumber = @"\((?<AreaCode>\d{3})\)\s*(?<Number>\d{3}(?:-|\s*)\d{4})";
        private static readonly string patternName = @"^[\p{L}\p{M}' \.\-]+$";

        private string name;
        private string contactPhone;
        private decimal revenue;

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get => name;

            set
            {
                ValidateOfRegularExpressions(patternName, value);

                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact phone.
        /// </summary>
        /// <value>
        /// The contact phone.
        /// </value>
        public string ContactPhone
        {
            get => contactPhone;

            set
            {
                ValidateOfRegularExpressions(patternPhoneNumber, value);

                contactPhone = value;
            }
        }

        /// <summary>
        /// Gets or sets the revenue.
        /// </summary>
        /// <value>
        /// The revenue.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">revenue</exception>
        public decimal Revenue
        {
            get => revenue;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(revenue)} can't be negative");
                }

                revenue = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(format, null))
            {
                format = "G";
            }

            if (ReferenceEquals(formatProvider, null))
            { 
                formatProvider = CultureInfo.CurrentCulture;
            }

            string temp = format.ToUpperInvariant();

            string result = string.Empty;

            for (int i = 0; i < temp.Length; i++)
            {
                switch (temp[i])
                {
                    case 'N':
                    {
                        result += Name.ToString(formatProvider);
                        break;
                    }
                    case 'P':
                    {
                        result += ContactPhone.ToString(formatProvider);
                        break;
                    }
                    case 'R':
                    {
                        result += Revenue.ToString("G",formatProvider);
                        break;
                    }
                }
            
                if (i<temp.Length-1)
                {
                    result += ",";
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name+"," + ContactPhone+"," + Revenue.ToString("G");
        }

        /// <summary>
        /// Validates the of regular expressions.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">value</exception>
        private static void ValidateOfRegularExpressions(string pattern, string value)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new ArgumentException(nameof(value));
            }
        }
    }
}
