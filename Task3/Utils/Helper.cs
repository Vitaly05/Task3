using Spectre.Console;
using Task3.Data;

namespace Task3.Utils
{
    internal class Helper
    {
        private Rules rules;

        private Table gameResultsTable;

        public Helper(Rules rules)
        {
            this.rules = rules;
            gameResultsTable = new Table();
            fillTable();
        }

        public void PrintHelpInformation()
        {
            AnsiConsole.MarkupLine($"You can look at table below to see what the result of the game would be with [{Painter.UserColor}]your[/] and [{Painter.ComputerColor}]PC's[/] moves.");
            AnsiConsole.MarkupLine($"The result is described from the [{Painter.UserColor}]user's[/] point of view.");
            AnsiConsole.Write(gameResultsTable);
        } 

        private void fillTable()
        {
            addColumns();
            addRows();
            configureTable();
        }

        private void addColumns()
        {
            gameResultsTable.AddColumn($"{Painter.ChangeColor("v PC", Painter.ComputerColor)}[bold]\\[/]{Painter.ChangeColor("USER >", Painter.UserColor)}");
            gameResultsTable.AddColumns(rules.Moves.Select(m => Painter.ChangeColor(m.Name, Painter.UserColor)).ToArray());
        }

        private void addRows()
        {
            foreach (var computerMove in rules.Moves)
            {
                List<string> row = new List<string>()
                {
                    Painter.ChangeColor(computerMove.Name, Painter.ComputerColor)
                };
                row.AddRange(getGameResults(computerMove));
                gameResultsTable.AddRow(row.ToArray());
            }
        }

        private IEnumerable<string> getGameResults(Move computerMove)
        {
            foreach (var userMove in rules.Moves)
            {
                GameResult result = userMove.GetResult(computerMove);
                yield return Painter.ChangeColor(result.ToString(), Painter.GetGameResultColor(result));
            }
        }

        private void configureTable()
        {
            gameResultsTable.BorderStyle(new Style(decoration: Decoration.Bold));
            gameResultsTable.Title(Painter.ChangeColor("Game results table", Color.Yellow), new Style(decoration: Decoration.Bold));
        }
    }
}