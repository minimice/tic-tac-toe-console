/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

[assembly: InternalsVisibleTo("TicTacToe.Tests")]
namespace TicTacToe
{
    internal class Board : IBoard
    {
        // Winning states of the array
        // 0,1,2
        // 0,3,6
        // 0,4,8
        // 2,5,8
        // 2,4,6
        // 6,7,8
        // 3,4,5
        // 1,4,7

        private readonly int[][] winningStates = 
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 },
            new int[] { 2, 4, 6 },
        };

        public bool HasWon(State state, State[] board)
        {
            foreach (var winningState in winningStates)
            {
                int pos1 = winningState[0];
                int pos2 = winningState[1];
                int pos3 = winningState[2];

                if (board[pos1] == state && board[pos2] == state && board[pos3] == state)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFull(State[] boardState)
        {
            return boardState.Count(state => state == State.Empty) == 0;
        }

        public bool IsGameOver(State[] boardState)
        {
            return (IsFull(boardState) || HasWon(State.X, boardState) || HasWon(State.O, boardState));
        }

        public int NextValidSpot(State[] boardState)
        {
            Random rnd = new Random();
            int spot = rnd.Next(0, 9);
            while (boardState[spot] != State.Empty)
            {
                spot = rnd.Next(0, 9);
            }
            return spot;
        }

        public bool Place(State state, int position, State[] boardState)
        {
            // Valid positions are 0 to 8
            if (position < boardState.Length && position >= 0)
            {
                if (boardState[position] == State.Empty)
                {
                    boardState[position] = state;
                    return true;
                }
            }

            return false;
        }

        public void PrintBoard(State[] boardState)
        {
            for (int i = 0; i < 3; i++)
            {
                // 0 - 0
                // 1 - 3
                // 2 - 6
                Console.Write("|");
                for (int j = i * 3; j < (i * 3) + 3; j++)
                {
                    string letter = "-";
                    if (boardState[j] == State.X)
                    {
                        letter = "X";
                    }
                    if (boardState[j] == State.O)
                    {
                        letter = "O";
                    }
                    Console.Write(letter);
                    if (j != (i * 3) + 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("|");
                Console.WriteLine("");
                Console.WriteLine("-------");
            }
        }
    }
}
