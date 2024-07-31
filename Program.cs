using System;
using System.Collections.Generic;

namespace TicTacToeApp
{
    internal class Program
    {
        static List<char> board = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';
        static int choice;
        static int match = 0;

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            do
            {
                DisplayPlayer();
                GetPlayerChoice();
                UpdateBoard();
                match = CheckWin();
            }
            while (match != 1 && match != -1);
            DisplayResult();
        }

        static void DisplayResult()
        {
            Console.Clear();
            GetBoard();
            if (match == 1)
            {
                Console.WriteLine("Player {0} has won!", player == 'X' ? 2 : 1);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadLine();
        }

        static void DisplayPlayer()
        {
            Console.Clear();
            Console.WriteLine("X : Player 1 \nO : Player 2\n");
            Console.WriteLine($"{(player == 'X' ? "Player 1" : "Player 2")} Turn\n");
            GetBoard();
        }

        static void GetBoard()
        {
            Console.WriteLine("      |    |    \n" +
                $"   {board[0]}  | {board[1]}  | {board[2]}\n" +
                $"  ____|____|____\n" +
                $"      |    |    \n" +
                $"   {board[3]}  | {board[4]}  | {board[5]}\n" +
                $"  ____|____|____\n" +
                $"      |    |    \n" +
                $"   {board[6]}  | {board[7]}  | {board[8]}\n" +
                $"      |    |    ");
   
        }

        static void GetPlayerChoice()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input or position already taken. Try again.");
                }
            }
        }

        static void UpdateBoard()
        {
            board[choice - 1] = player;
            player = player == 'X' ? 'O' : 'X';
        }

        static int CheckWin()
        {
            if (GetWinLine(0, 1, 2) || GetWinLine(3, 4, 5) || GetWinLine(6, 7, 8) ||
                GetWinLine(0, 3, 6) || GetWinLine(1, 4, 7) || GetWinLine(2, 5, 8) ||
                GetWinLine(0, 4, 8) || GetWinLine(2, 4, 6))
            {
                return 1;
            }
            else if (IsBoardFull())
            {
                return -1;
            }
            return 0;
        }

        static bool GetWinLine(int a, int b, int c)
        {
            return board[a] == board[b] && board[b] == board[c];
        }

        static bool IsBoardFull()
        {
            foreach (char slot in board)
            {
                if (slot != 'X' && slot != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
