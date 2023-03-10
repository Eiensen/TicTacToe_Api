﻿namespace TestTask_TicTacToeApi.Models
{
    public class Feald
    {
        public Cell[,] FealdArray { get; set; }

        public Feald()
        {
            FealdArray = new Cell[,]
        {
            {
                new Cell(){Key = "A1", Value = "", IsAble= true},
                new Cell(){Key = "A2", Value = "", IsAble= true},
                new Cell(){Key = "A3", Value = "", IsAble= true}
            },
            {
                new Cell(){Key = "B1", Value = "", IsAble= true},
                new Cell(){Key = "B2", Value = "", IsAble= true},
                new Cell(){Key = "B3", Value = "", IsAble= true}
            },
            {
                new Cell(){Key = "C1", Value = "", IsAble= true},
                new Cell(){Key = "C2", Value = "", IsAble= true},
                new Cell(){Key = "C3", Value = "", IsAble= true}
            }
        };
        }
    }
}
