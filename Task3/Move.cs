namespace Task3
{
    internal class Move
    {
        public string Current { get; init; } = "";

        public List<string> Strongers { get; init; } = new();
        public List<string> Weakers { get; init; } = new();
    }
}
