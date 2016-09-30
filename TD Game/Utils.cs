namespace TD_Game
{
    public static class Utils
    {
        public static void ClampMax(ref int value,int max)
        {
            if (value > max)
            {
                value = max;
            }
        }

        public static void ClampMax(ref float value, float max)
        {
            if (value > max)
            {
                value = max;
            }
        }

        public static void ClampMin(ref int value, int min)
        {
            if (value < min)
            {
                value = min;
            }
        }

        public static void ClampMin(ref float value, float min)
        {
            if (value < min)
            {
                value = min;
            }
        }
    }
}