using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _06_wpf_validalas
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           if (int.TryParse(value.ToString() , out int i))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Csak szám lehet!");
        }
    }
}
