/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board();

            var boardState = new State[] {
                State.Empty, State.Empty, State.Empty,    // - - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };

            bool playerTurn = true;
            while (!board.IsGameOver(boardState))
            {
                Console.WriteLine();
                board.PrintBoard(boardState);

                if (playerTurn)
                {
                    Console.WriteLine();
                    Console.WriteLine("> Your turn");
                    Console.Write("> Enter 0 to 8 to place your X: ");
                    char c = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    int spot;
                    var validMove = false;
                    if (Int32.TryParse(c.ToString(), out spot))
                    {
                        if (spot < 0 || spot > 8)
                        {
                            Console.WriteLine();
                            Console.WriteLine("> You must place your X in a valid position");
                        }
                        else
                        {
                            validMove = board.Place(State.X, spot, boardState);
                            if (!validMove)
                            {
                                Console.WriteLine();
                                Console.WriteLine("> You must place your X in an empty spot");
                            }
                        }
                    }

                    if (!validMove)
                    {
                        playerTurn = true; // Player tries again
                        continue;
                    }

                    playerTurn = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("> Computer's turn");
                    // Computer's turn, generate random place
                    int computerSpot = board.NextValidSpot(boardState);
                    board.Place(State.O, computerSpot, boardState);
                    playerTurn = true;
                }
            }

            // Print out result			
            var playerOne = board.HasWon(State.X, boardState);
            var playerTwo = board.HasWon(State.O, boardState);
            Console.WriteLine();
            Console.WriteLine("> Final state of board");
            board.PrintBoard(boardState);
            Console.WriteLine();
            Console.WriteLine(playerOne ? "> Crosses (YOU!) won" : "> Crosses did not win");
            Console.WriteLine(playerTwo ? "> Noughts (COMPUTER) won" : "> Noughts did not win");
            Console.WriteLine(!playerOne && !playerTwo ? "> Draw" : "> Not a draw");

        }
    }
}
