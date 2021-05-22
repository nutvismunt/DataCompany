using DataCompany.Rules;

namespace DataCompany.Services
{
    public static class Validation
    {
        public static string ValidateAge(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "Введите возраст сотрудника";
            return !IsAgeValid.Check(value) ? "Возраст сотрудника не может быть больше 100 лет или меньше 16 года" : "";
        }

        public static string ValidateLength(this string value, int Max, int Min)
        {
            var length = new IsLengthValidRule();
            return !IsLengthValidRule.Check(value, Max, Min) ? $"Некорректная длина(от {Min} до {Max} символов)" : "";
        }
    }
}
