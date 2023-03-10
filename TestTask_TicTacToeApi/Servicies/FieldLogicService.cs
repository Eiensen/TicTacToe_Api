namespace TestTask_TicTacToeApi.Servicies
{
    public class FieldLogicService : IFieldLogicService
    {
        public GameResult GetGameResult(Cell[,] cells)
        {
            bool circleWin = CheckWin(cells, "o");
            bool crossWin = CheckWin(cells, "x");

            if (circleWin == crossWin) return GameResult.Draw;

            return circleWin ? GameResult.CircleWin : GameResult.CrossWin;
        }

        private bool CheckLines(Cell[,] field, string mark)
        {
            bool winner = false;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                var a = 0;
                for (int j = 0; j < field.GetLength(1); j++)
                    if (mark == field[i, j].Value)
                    {
                        a = a + 1;
                        if (a == 3)
                        {
                            winner = true;
                            break;
                        }
                    }
            }
            return winner;
        }

        private bool CheckColons(Cell[,] field, string mark)
        {
            bool winner = false;
            for (int nomerStroki = 0; nomerStroki < field.GetLength(0); nomerStroki++)
            {
                var a = 0;
                for (int nomerKolonki = 0; nomerKolonki < field.GetLength(1); nomerKolonki++)
                    if (mark == field[nomerKolonki, nomerStroki].Value)
                    {
                        a = a + 1;
                        if (a == 3)
                        {
                            winner = true;
                            break;
                        }
                    }
            }
            return winner;
        }

        private bool CheckDiagonals(Cell[,] field, string mark)
        {
            if ((mark == field[0, 0].Value && mark == field[1, 1].Value && mark == field[2, 2].Value) || (mark == field[2, 0].Value && mark == field[1, 1].Value && mark == field[0, 2].Value))
                return true;
            else return false;
        }

        private bool CheckWin(Cell[,] field, string mark)
        {
            bool diagonal = CheckDiagonals(field, mark);
            bool stroka = CheckLines(field, mark);
            bool kolonka = CheckColons(field, mark);
            return (diagonal || stroka || kolonka);
        }
    }
}
