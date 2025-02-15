using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static bool isPlayerXTurn = true;

    static void Main()
    {
        bool gameEnded = false;

        while (!gameEnded)
        {
            Console.Clear();
            PrintBoard();

            char currentPlayer = isPlayerXTurn ? 'X' : 'O';
            int move = GetPlayerMove(currentPlayer);

            board[move - 1] = currentPlayer;

            if (CheckWin(currentPlayer))
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameEnded = true;
            }
            else if (CheckDraw())
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("It's a draw!");
                gameEnded = true;
            }
            else
            {
                isPlayerXTurn = !isPlayerXTurn;
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("-----------");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static int GetPlayerMove(char player)
    {
        int move;
        while (true)
        {
            Console.Write($"Player {player}, enter a number (1-9): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out move))
            {
                Console.WriteLine("Invalid input. Please enter a number!");
                continue;
            }

            if (move < 1 || move > 9)
            {
                Console.WriteLine("Number out of range. Please try again!");
                continue;
            }

            if (board[move - 1] == 'X' || board[move - 1] == 'O')
            {
                Console.WriteLine("Position already taken. Choose another!");
                continue;
            }

            break;
        }
        return move;
    }

    static bool CheckWin(char player)
    {
        // Check rows
        if ((board[0] == player && board[1] == player && board[2] == player) ||
            (board[3] == player && board[4] == player && board[5] == player) ||
            (board[6] == player && board[7] == player && board[8] == player) ||
            // Check columns
            (board[0] == player && board[3] == player && board[6] == player) ||
            (board[1] == player && board[4] == player && board[7] == player) ||
            (board[2] == player && board[5] == player && board[8] == player) ||
            // Check diagonals
            (board[0] == player && board[4] == player && board[8] == player) ||
            (board[2] == player && board[4] == player && board[6] == player))
        {
            return true;
        }
        return false;
    }

    static bool CheckDraw()
    {
        foreach (char c in board)
        {
            if (char.IsDigit(c)) return false;
        }
        return true;
    }
}