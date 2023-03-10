using TestTask_TicTacToeApi.Models;
using TestTask_TicTacToeApi.ViewModels;

namespace TestTask_TicTacToeApi.Repositories
{
    public interface IRepository
    {
        GameResult GameResult { get; set; }

        string GetCurrentFeald();

        string UpdateFieldAfterTurn(string cellKey, string cellValue);

        string GetSavedField();
    }
}
