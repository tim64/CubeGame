namespace MathExtension
{
    public static class MathExtension
    {
        public static bool IsWithin(this float value, float minimum, float maximum)
        {
            return value >= minimum && value <= maximum;
        }

        public static bool IsWithin(this int value, int minimum, float maximum)
        {
            return value >= minimum && value <= maximum;
        }
    }  
}

