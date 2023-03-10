namespace TestTask_TicTacToeApi.Servicies
{
    public interface IFieldLogicService
    {
        GameResult GetGameResult(Cell[,] cells);
    }
}
