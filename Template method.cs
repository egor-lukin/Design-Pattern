/**
 * An abstract class that is common to several games in
 * which players play against the others, but only one is
 * playing at a given time.
 */

namespace Design_Patterns
{
    class TemplateMethodPattern
    {
        internal abstract class GameObject
        {
            protected int PlayersCount;

            abstract protected bool EndOfGame();

            abstract protected void InitializeGame();

            abstract protected void MakePlay(int player);

            abstract protected void PrintWinner();

            /* A template method : */
            public void PlayOneGame(int playersCount)
            {
                PlayersCount = playersCount;
                InitializeGame();
                
                var j = 0;

                while (!EndOfGame())
                {
                    MakePlay(j);
                    j = (j + 1) % playersCount;
                }

                PrintWinner();
            }
        }

        //Now we can extend this class in order to implement actual games:

        public class Monopoly : GameObject
        {
            /* Implementation of necessary concrete methods */

            protected override void InitializeGame()
            {
                // Initialize money
            }

            protected override void MakePlay(int player)
            {
                // Process one turn of player
            }

            protected override bool EndOfGame()
            {
                return true;
            }

            protected override void PrintWinner()
            {
                // Display who won
            }

            /* Specific declarations for the Monopoly game. */

            // ...

        }

        public class Chess : GameObject
        {

            /* Implementation of necessary concrete methods */

            protected override void InitializeGame()
            {
                // Put the pieces on the board
            }

            protected override void MakePlay(int player)
            {
                // Process a turn for the player
            }

            protected override bool EndOfGame()
            {
                return true;
                // Return true if in Checkmate or Stalemate has been reached
            }

            protected override void PrintWinner()
            {
                // Display the winning player
            }

            /* Specific declarations for the chess game. */

            // ...

        }

        public static void Test()
        {
            GameObject game = new Monopoly();

            game.PlayOneGame(2);
        }
    }
}