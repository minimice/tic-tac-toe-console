using System;

namespace tictactoe
{
	public class MyClass
	{
		public MyClass()
		{
			State[] boardstate = new State[] {
											State.Cross,State.Cross,State.Cross,
											State.Empty,State.Empty,State.Empty,
											State.Empty,State.Empty,State.Empty
										};
			Board board = new Board();

			bool hasCrossesWon = board.HasWon(State.Cross, boardstate);

			System.Diagnostics.Debug.WriteLine(hasCrossesWon);

		}
	}
}
