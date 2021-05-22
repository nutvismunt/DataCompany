using System;

namespace DataCompany.Rules
{
    public class IsAgeValid
    {
        public static bool Check(string date)
        {
            if (string.IsNullOrWhiteSpace(date)) return false;
            var now = DateTime.Now;
            return now.Year - Convert.ToDateTime(date).Year <= 100 && now.Year - Convert.ToDateTime(date).Year >= 1;

        }
    }
}