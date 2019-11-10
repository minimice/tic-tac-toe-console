/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("TicTacToe.Tests")]
namespace TicTacToe
{
    internal interface IBoard
    {
        bool HasWon(State state, State[] board);
        bool Place(State state, int position, State[] boardState);
        bool IsFull(State[] boardState);
        bool IsGameOver(State[] boardState);
        public void PrintBoard(State[] boardState);
        int NextValidSpot(State[] boardState);
    }
}
