namespace TestTask_TicTacToeApi.Servicies
{
    public interface IFealdLogicService
    {
        GameResult GetGameResult(Cell[,] cells);
    }
}
