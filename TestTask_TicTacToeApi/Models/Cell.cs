using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestTask_TicTacToeApi.Models
{
    public class Cell
    {     
        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public bool IsAble { get; set; } = true;
    }
}
