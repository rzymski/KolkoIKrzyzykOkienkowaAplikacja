using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public static class Check
    {
        public static List<int> checkHorizontal(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int right = 0, left = 0, positionColumn = currentPositionColumn;
            while (positionColumn + 1 < chessSize && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn + 1])
            {
                right++;
                positionColumn++;
                result.Add(currentPositionRow);
                result.Add(positionColumn);
            }
            positionColumn = currentPositionColumn;
            while (positionColumn - 1 >= 0 && board2D[currentPositionRow, positionColumn] == board2D[currentPositionRow, positionColumn - 1])
            {
                left++;
                positionColumn--;
                result.Add(currentPositionRow);
                result.Add(positionColumn);
            }

            if (right + left + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkVertical(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int down = 0, up = 0, positionRow = currentPositionRow;
            while (positionRow + 1 < chessSize && board2D[positionRow, currentPositionColumn] == board2D[positionRow + 1, currentPositionColumn])
            {
                down++;
                positionRow++;
                result.Add(positionRow);
                result.Add(currentPositionColumn);
            }
            positionRow = currentPositionRow;
            while (positionRow - 1 >= 0 && board2D[positionRow, currentPositionColumn] == board2D[positionRow - 1, currentPositionColumn])
            {
                up++;
                positionRow--;
                result.Add(positionRow);
                result.Add(currentPositionColumn);
            }

            if (down + up + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkDiagonalUpDown(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int rightDown = 0, leftUp = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn + 1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow + 1, positionColumn + 1])
            {
                rightDown++;
                positionRow++;
                positionColumn++;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow - 1 >= 0 && positionColumn - 1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn - 1])
            {
                leftUp++;
                positionRow--;
                positionColumn--;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            if (rightDown + leftUp + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static List<int> checkDiagonalDownUp(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin)
        {
            List<int> result = new List<int>();
            int rightUp = 0, leftDown = 0;
            int positionRow = currentPositionRow, positionColumn = currentPositionColumn;
            while (positionRow - 1 >= 0 && positionColumn + 1 < chessSize && board2D[positionRow, positionColumn] == board2D[positionRow - 1, positionColumn + 1])
            {
                rightUp++;
                positionRow--;
                positionColumn++;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            positionRow = currentPositionRow;
            positionColumn = currentPositionColumn;
            while (positionRow + 1 < chessSize && positionColumn - 1 >= 0 && board2D[positionRow, positionColumn] == board2D[positionRow + 1, positionColumn - 1])
            {
                leftDown++;
                positionRow++;
                positionColumn--;
                result.Add(positionRow);
                result.Add(positionColumn);
            }
            if (rightUp + leftDown + 1 >= howMuchToWin)
            {
                result.Add(currentPositionRow);
                result.Add(currentPositionColumn);
                return result;
            }
            else
                return null;
        }

        public static int checkWin(int[,] board2D, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin, ref List<int> listWinnerPositions)
        {
            if (checkHorizontal(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkHorizontal(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 1; //zwycieztwo poziome
            }
            else if (checkVertical(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkVertical(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 2; //zwycieztwo pionowe
            }
            else if (checkDiagonalUpDown(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkDiagonalUpDown(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 3; //zwycieztwo \
            }
            else if (checkDiagonalDownUp(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin) != null)
            {
                listWinnerPositions = checkDiagonalDownUp(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin);
                return 4; //zwycieztwo /
            }
            return 0; //nie bylo wygranej
        }

        public static int checkIfEndGame(int[,] board2D, int moveCount, int chessSize, int currentPositionColumn, int currentPositionRow, int howMuchToWin, ref List<int> listWinnerPositions)
        {
            int indexBoard = currentPositionRow * chessSize + currentPositionColumn;
            int winner = checkWin(board2D, chessSize, currentPositionColumn, currentPositionRow, howMuchToWin, ref listWinnerPositions);
            if (moveCount == board2D.Length && winner == 0)
                return -1; //remis
            return winner;
        }
    }
}
