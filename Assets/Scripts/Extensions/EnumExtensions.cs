using System;

namespace MergeMansion.Extensions
{
    public static class EnumExtensions
    {
        public static T GetRandomValue<T>(this T enumValue) where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            
            if (values.Length <= 1)
            {
                throw new InvalidOperationException("Enum должен содержать более одного значения.");
            }

            Random random = new Random();
            int randomIndex = random.Next(1, values.Length);
            
            return (T)values.GetValue(randomIndex);
        }
    }
}