namespace TestTask_TicTacToeApi.ViewModels
{
    public class CurrentCells
    {
        public string GameStatus { get; set; } = string.Empty;

        public JsonDocument? CurrentFealdJson { get; set; }
    }
}
