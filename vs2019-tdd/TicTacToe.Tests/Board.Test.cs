/* Tic tac toe by Lim Chooi Guan */
/* https://linkedin.com/in/cgl88 */

using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineDataAttribute(State.X, new State[]
            {
                State.X, State.X, State.X,             // X X X 
                State.Empty, State.Empty, State.Empty, // - - -
                State.Empty, State.Empty, State.Empty  // - - -
            },
            "Crosses did not win scenario 1")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.Empty, State.Empty, State.Empty, // - - -
                State.X, State.X, State.X,             // X X X
                State.Empty, State.Empty, State.Empty  // - - -
            },
            "Crosses did not win scenario 2")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.Empty, State.Empty, State.Empty, // - - -
                State.Empty, State.Empty, State.Empty, // - - -
                State.X, State.X, State.X              // X X X
            },
            "Crosses did not win scenario 3")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.X, State.Empty, State.Empty, // X - -
                State.X, State.Empty, State.Empty, // X - -
                State.X, State.Empty, State.Empty  // X - -
            },
            "Crosses did not win scenario 4")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.Empty, State.X, State.Empty, // - X -
                State.Empty, State.X, State.Empty, // - X -
                State.Empty, State.X, State.Empty  // - X -
            },
            "Crosses did not win scenario 5")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.Empty, State.Empty, State.X, // - - X
                State.Empty, State.Empty, State.X, // - - X
                State.Empty, State.Empty, State.X  // - - X
            },
            "Crosses did not win scenario 6")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.X, State.Empty, State.Empty, // X - -
                State.Empty, State.X, State.Empty, // - X -
                State.Empty, State.Empty, State.X  // - - X
            },
            "Crosses did not win scenario 7")]
        [InlineDataAttribute(State.X, new State[]
            {
                State.Empty, State.Empty, State.X, // - - X
                State.Empty, State.X, State.Empty, // - X -
                State.X, State.Empty, State.Empty  // X - -
            },
            "Crosses did not win scenario 8")]
        [InlineDataAttribute(State.O, new State[]
            {
                State.O, State.O, State.O,                // O O O 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            },
            "Noughts did not win scenario 9")]

        public void GivenStateAndBoardInWinningState_ExpectStateWin(State state, State[] boardState, String errorMsg)
        {
            IBoard board = new Board();
            Assert.True(board.HasWon(state, boardState), errorMsg);
        }

        [Fact]
        public void GivenPlaceCrossOnEmptySpotOnBoard_ExpectCrossToBePlaced()
        {
            IBoard board = new Board();
            var state = State.X;
            var position = 0;
            var boardState = new State[] {
                State.Empty, State.Empty, State.Empty,    // - - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };
            Assert.True(board.Place(state, position, boardState), "Cross NOT placed on board");
        }

        [Fact]
        public void GivenPlaceCrossOnNotEmptySpotOnBoard_ExpectCrossNotToBePlaced()
        {
            IBoard board = new Board();
            var state = State.X;
            var position = 0;
            var boardState = new State[] {
                State.X, State.Empty, State.Empty,        // X - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };
            Assert.False(board.Place(state, position, boardState), "Cross was placed on board incorrectly");
        }

        [Fact]
        public void GivenPlaceCrossOnInvalidSpotOnBoard_ExpectCrossNotToBePlaced()
        {
            IBoard board = new Board();
            var state = State.X;
            var position = -1;
            var boardState = new State[] {
                State.Empty, State.Empty, State.Empty,    // - - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };
            Assert.False(board.Place(state, position, boardState), "Cross placed on board when position was invalid!");
        }

        [Fact]
        public void GivenPlaceCrossOnAnotherInvalidSpotOnBoard_ExpectCrossNotToBePlaced()
        {
            IBoard board = new Board();
            var state = State.X;
            var position = 9;
            var boardState = new State[] {
                State.Empty, State.Empty, State.Empty,    // - - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };
            Assert.False(board.Place(state, position, boardState), "Cross placed on board when position was invalid!");
        }

        [Fact]
        public void GivenBoardStillHasEmptySpots_ExpectBoardFullReturnFalse()
        {
            IBoard board = new Board();
            var boardState = new State[] {
                State.Empty, State.Empty, State.Empty,    // - - - 
                State.Empty, State.Empty, State.Empty,    // - - -
                State.Empty, State.Empty, State.Empty     // - - -
            };
            Assert.False(board.IsFull(boardState), "Board returning full when it still has empty spots!");
        }

        [Fact]
        public void GivenBoardIsGameOverDueToCrossWin_ExpectBoardGameOverReturnTrue()
        {
            IBoard board = new Board();
            var boardState = new State[] {
                State.X, State.O, State.Empty,    // X O - 
                State.X, State.O, State.Empty,    // X O -
                State.X, State.Empty, State.Empty // X - -
            };
            Assert.True(board.IsGameOver(boardState), "Board returning not game over when the game is over due to X win!");
        }

        [Fact]
        public void GivenBoardIsGameOverDueToNoughtsWin_ExpectBoardGameOverReturnTrue()
        {
            IBoard board = new Board();
            var boardState = new State[] {
                State.X, State.O, State.Empty,    // X O - 
                State.X, State.O, State.Empty,    // X O -
                State.Empty, State.O, State.Empty // - O -
            };
            Assert.True(board.IsGameOver(boardState), "Board returning not game over when the game is over due to O win!");
        }

        [Fact]
        public void GivenBoardIsGameOverDueToDraw_ExpectBoardGameOverReturnTrue()
        {
            IBoard board = new Board();
            var boardState = new State[] {
                State.X, State.O, State.X,    // X O X 
                State.X, State.O, State.X,    // X O X
                State.O, State.X, State.O     // O X O
            };
            Assert.True(board.IsGameOver(boardState), "Board returning not game over when the game has drawn!");
        }
    }
}
