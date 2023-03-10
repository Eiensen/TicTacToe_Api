namespace TestTask_TicTacToeApi.Repositories
{
    public class DatabaseRepository : IRepository
    {
        public GameResult GameResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetCurrentFeald()
        {
            throw new NotImplementedException();
        }

        public string GetSavedFeald()
        {
            throw new NotImplementedException();
        }

        public string UpdateFealdAfterTurn(string cellKey, string cellValue)
        {
            throw new NotImplementedException();
        }
    }
}
