namespace Task3.Data
{
    internal static class ConsoleColors
    {
        public static readonly string RedColor = "\x1b[31m";
        public static readonly string GreenColor = "\x1b[32m";
        public static readonly string YellowColor = "\x1b[33m";
        public static readonly string BlueColor = "\x1b[36m";
        public static readonly string DefaultColor = "\x1b[0m";

        public static string ChoseColor(string str, string color)
        {
            return $"{color}{str}{DefaultColor}";
        }
    }
}
