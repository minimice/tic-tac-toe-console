/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;

namespace tictactoeconsole
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// Set up initial state of the board
			var boardstate = new State[] {
											State.Empty, State.Empty, State.Empty,
				                            State.Empty, State.Empty, State.Empty,
											State.Empty, State.Empty, State.Empty
										};

			// Set up the board
			var board = new Board();
			Console.WriteLine("**** Welcome to TIC-TAC-TOE Console version ****");
			Console.WriteLine("Created by Lim Chooi Guan");
			Console.WriteLine("As the first player, you are CROSSES");
			Console.WriteLine("Enter 0 to 8 to place your CROSS");
			Console.WriteLine("Row 1 has values 0 to 2 i.e. 0,1,2");
			Console.WriteLine("Row 2 has values 0 to 2 i.e. 3,4,5");
			Console.WriteLine("Row 3 has values 0 to 2 i.e. 6,7,8");
			Console.WriteLine("Empty spots are denoted by dashes");

			while (board.HasEmptySpot(boardstate))
			{
				Console.WriteLine("********");
				board.PrintBoard(boardstate);
				Console.WriteLine();
				Console.WriteLine("Your turn");
				Console.WriteLine("Enter 0 to 8 to place your X");
				char c = Console.ReadKey().KeyChar;

				int spot;
				var validMove = false;
				if (Int32.TryParse(c.ToString(), out spot))
				{
					if (spot < 0 || spot > 8)
					{
						Console.WriteLine("You must place your X in a valid position");
					}
					else
					{
						validMove = board.UpdateBoard(State.X, boardstate, spot);
						if (!validMove)
						{
							Console.WriteLine("You must place your X in an empty spot");
						}
					}
				}

				if (!validMove)
				{
					continue;
				}

				Console.WriteLine();
				Console.WriteLine("You placed at {0}, here is the board now", spot);
				board.PrintBoard(boardstate);
				var hasCrossesWon = board.HasWon(State.X, boardstate);
				if (hasCrossesWon)
				{
					Console.WriteLine(hasCrossesWon ? "Crosses won" : "Crosses did not win");
					return;
				}

				if (board.HasEmptySpot(boardstate))
				{
					// Computer's turn, generate random place
					int computerSpot = board.NextValidSpot(boardstate);
					board.UpdateBoard(State.O, boardstate, computerSpot);
					Console.WriteLine("");
					Console.WriteLine("Computer's turn");
					board.PrintBoard(boardstate);
					Console.WriteLine("");
					var hasNoughtsWon = board.HasWon(State.O, boardstate);
					if (hasNoughtsWon)
					{
						Console.WriteLine(hasNoughtsWon ? "Noughts won" : "Noughts did not win");
						return;
					}
				}
			}

			var playerOne = board.HasWon(State.X, boardstate);
			var playerTwo = board.HasWon(State.O, boardstate);

			Console.WriteLine(playerOne ? "Crosses won" : "Crosses did not win");
			Console.WriteLine(playerTwo ? "Noughts won" : "Noughts did not win");
			Console.WriteLine(!playerOne && !playerTwo ? "Draw" : "Not a draw");
		}
	}
}
