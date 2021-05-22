namespace DataCompany.Rules
{
    public class IsLengthValidRule
    {
        public static bool Check(string value, int maxLength, int minLength)
        {
            if (value == null) return false;
            return (value.Length >= minLength && value.Length <= maxLength);
        }
    }
}