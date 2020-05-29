using System;

namespace CIPSA.M_XI.Domain.Extension.Exercise.Shop
{
    public static class DateTimeExtension
    {
        public static bool IsAdult(this DateTime bornDate) {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
                age--;
            return age > 18;
        }
    }
}
