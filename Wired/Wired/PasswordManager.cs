using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wired
{
    public class PasswordManager
    {
        public static string GetAdmPassword()
        {
            var date = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

            var month = date.Month.ToString().PadLeft(2, '0');
            var hour = date.Hour.ToString().PadLeft(2, '0');

            return $"adm{month}{hour}";
        }

        public static string CalculateSha1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSha1 =
            new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }
}
