using System.Text.RegularExpressions;

namespace DataCompany.Services
{
    public static class PhoneMask
    {
        public static string ApplyPhoneMask(string phone)
        {
            var newVal = Regex.Replace(phone, @"[^0-9]", "");
            
            phone = string.Empty;

                if (newVal.Length <= 1)
                {
                    phone = Regex.Replace(newVal, @"(\d{1})", "+$1");
                }
                else if (newVal.Length <= 4)
                {
                    phone = Regex.Replace(newVal, @"(\d{1})(\d{0,3})", "+$1($2)");
                }
                else if (newVal.Length <= 7)
                {
                    phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})", "+$1($2)$3");
                }
                else if (newVal.Length <= 9)
                {
                    phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})(\d{0,2})", "+$1($2)$3-$4");
                }
                else if (newVal.Length > 9)
                {
                    phone = Regex.Replace(newVal, @"(\d{1})(\d{3})(\d{0,3})(\d{0,2})(\d{0,2})", "+$1($2)$3-$4-$5");
                }

                return phone;
        }
    }
}