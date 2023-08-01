using ConsoleTables;

namespace Task3.Utils
{
    internal class Helper
    {
        private Rules rules = new();


        public Helper(Rules rules)
        {
            this.rules = rules;
        }

        public void PrintTable()
        {
            Dictionary<string, Dictionary<string, object>> data = new Dictionary<string, Dictionary<string, object>>();
            foreach (var computerMove in rules.Moves)
            {
                Dictionary<string, object> row = new();
                foreach (var userMove in rules.Moves)
                {
                    row.Add(userMove.Name, userMove.GetResult(computerMove).ToString());
                }
                data.Add(computerMove.Name, row);
            }

            var table = ConsoleTable.FromDictionary(data);
            table.Configure(a => a.EnableCount = false);
            table.Columns[0] = $"mv PC\\USER >";

            table.Write();
        }
    }
}
