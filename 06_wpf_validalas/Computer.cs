using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_wpf_validalas
{
    public class Computer : IDataErrorInfo
    {
        public string name { get; set; }
        public int? age { get; set; }
        public string ipAddress { get; set; }


        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "name":
                        if (string.IsNullOrEmpty(name))
                        {
                            return "Kötelező kitölteni!";
                        }
                        break;
                    case "age":
                        if (age<=0)
                        {
                            return "Hibás életkor!";
                        }
                        break;
                    case "ipAddress":
                        if (string.IsNullOrEmpty(ipAddress))
                        {
                            return "Kötelező kitölteni!";
                        }
                        var ipParts = ipAddress.Split('.');
                        if (ipParts.Length != 4)
                        {
                            return "Az IP címnek tartalmazni kell 4 számot ponttal elválasztva.";
                        }
                        foreach (var part in  ipParts)
                        {
                            int intPart;
                            if (!int.TryParse(part, out intPart) || intPart <= 0 || intPart >=255 )
                            {
                                return "Az IP címben s azámok 0 és 255 között kell, hogy legyenek!";
                            }
                        }
                        break;
                    default:
                        break;
                }

                return null; // minden OK
            }
        }
        public string Error => throw new NotImplementedException();
    }
}
