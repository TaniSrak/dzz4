using System.ComponentModel.Design;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game ticTacToe = new Game();
            ticTacToe.Play();
        }

    }

    public class Game
    {
        private char[,] board;
        private char currentPlayer;

        public Game()
        {
            board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
            currentPlayer = 'X'; // начальный ход за игроком 'X'
        }

        public void Play() //начало игры
        {
            while (true)
            {
                PrintBoard();
                PlayerMove();
                if (CheckWin())
                {
                    PrintBoard();
                    Console.WriteLine($"Игрок {currentPlayer} победил!");
                    break;
                }
                if (CheckDraw())
                {
                    PrintBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }
                SwitchPlayer();
            }
        }

        private void PrintBoard() //вывод игрового поля
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----");
            }
        }

        private void PlayerMove() //обработка хода игрока
        {
            while (true)
            {
                Console.WriteLine($"Игрок {currentPlayer}, введите ваш ход (номер строки и столбца через пробел): ");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int row) &&
                    int.TryParse(parts[1], out int col) &&
                    row >= 1 && row <= 3 &&
                    col >= 1 && col <= 3 &&
                    board[row - 1, col - 1] == ' ')
                {
                    board[row - 1, col - 1] = currentPlayer;
                    break;
                }
                Console.WriteLine("Некорректный ход, попробуйте снова.");
            }
        }

        private bool CheckWin() //проверка победы
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }
            return false;
        }

        private bool CheckDraw() //ничья
        {
            foreach (char spot in board)
            {
                if (spot == ' ') return false;
            }
            return true;
        }

        private void SwitchPlayer() //смена игрока
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}
