using Spectre.Console;
using Task3.Data;

namespace Task3.Utils
{
    internal static class Painter
    {
        public static readonly Color UserColor = Color.DarkOrange;
        public static readonly Color ComputerColor = Color.Purple_1;
        public static readonly Color WinColor = Color.GreenYellow;
        public static readonly Color LoseColor = Color.Red1;
        public static readonly Color DrawColor = Color.Yellow;

        public static string ChangeColor(string str, Color color) => $"[{color}]{str}[/]";

        public static Color GetGameResultColor(GameResult gameResult) =>
            gameResult switch
            {
                GameResult.Win => WinColor,
                GameResult.Lose => LoseColor,
                _ => DrawColor
            };
    }
}
