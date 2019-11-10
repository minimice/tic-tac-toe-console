/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;
using System.Linq;

namespace tictactoeconsole
{
	public enum State
	{
		Empty,
		O,
		X
	}

	public class Board
	{
		public Board()
		{
		}

		public bool UpdateBoard(State state, State[] boardstate, int spot)
		{
			if (boardstate[spot] == State.Empty)
			{
				boardstate[spot] = state;
				return true;
			}
			return false;
		}

		public int NextValidSpot(State[] boardstate)
		{
			Random rnd = new Random();
			int spot = rnd.Next(0, 9);
			while (boardstate[spot] != State.Empty)
			{
				spot = rnd.Next(0, 9);
			}
			return spot;
		}

		public void PrintBoard(State[] boardstate)
		{
			for (int i = 0; i < 3; i++)
			{
				// 0 - 0
				// 1 - 3
				// 2 - 6
				for (int j = i * 3; j < (i * 3) + 3; j++)
				{
					string letter = "-";
					if (boardstate[j] == State.X)
					{
						letter = "X";
					}
					if (boardstate[j] == State.O)
					{
						letter = "O";
					}
					Console.Write(letter);
					if (j != (i * 3) + 2)
					{
						Console.Write("|");
					}
				}
				Console.WriteLine("");
				Console.WriteLine("-----");
			}			
		}

		public bool HasEmptySpot(State[] board)
		{
			return board.Count(spot => spot == State.Empty) > 0;
		}

		public bool HasWon(State state, State[] board)
		{
			// Board array of 9
			// 0 1 2
			// 3 4 5
			// 6 7 8

			// Winning states of the array
			// 0,1,2
			// 0,3,6
			// 0,4,8
			// 2,5,8
			// 2,4,6
			// 6,7,8
			// 3,4,5
			// 1,4,7

			int[][] winningStates = {
						new int[] {0, 1, 2},
						new int[] {0, 3, 6},
					    new int[] {0, 4, 8},
					    new int[] {2, 5, 8},
				        new int[] {2, 4, 6},
					    new int[] {6, 7, 8},
					    new int[] {3, 4, 5},
				        new int[] {1, 4, 7},
					};

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
	}
}
