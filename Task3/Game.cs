namespace Task3
{
    internal class Game
    {
        private readonly Rules rules = new();


        public Game(Rules rules)
        {
            this.rules = rules;
        }

        public void Start()
        {
            string command = "";
            do
            {
                drawMenu();
                command = Console.ReadLine() ?? "";

            } while (command != "0");
        }


        private void drawMenu()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < rules.Moves.Count; ++i)
            {
                Console.WriteLine($"{i + 1} - {rules.Moves[i].Current}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }
    }
}
