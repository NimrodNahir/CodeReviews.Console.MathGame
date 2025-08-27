namespace MathGame.NimrodNahir
{
    internal class MathGame
    {
        private List<Game> m_PreviousGames = new();
        internal MathGame()
        {
        }

        internal void Init()
        {
            bool isActive = true;
            while (isActive)
            {
                int actionIndex = MathGameUI.showMainMenu();
                switch (actionIndex)
                {
                    case 1:
                        startNewGame();
                        break;
                    case 2:
                        viewHistory();
                        break;
                    case 3:
                        isActive = false;
                        MathGameUI.ShowExitScreen();
                        break;

                }
            }
        }

        private void startNewGame()
        {
            Game? currGame = createGame();
            if(currGame is not null)
            {
                currGame.Start();
                m_PreviousGames.Add(currGame);
            }
        }

        private Game? createGame()
        {
            eGameType? type = MathGameUI.showGameTypeMenu();
            if(type is null)
            {
                return null;
            }
            eDifficulty? difficulty = MathGameUI.showGameDiffiucltyMenu();
            if(difficulty is null)
            {
                return null;
            }
            eGameLength? length = MathGameUI.showGameLengthMenu();

            if (length is null)
            {
                return null;
            }

            return new Game((eGameType)type, (eDifficulty)difficulty, (eGameLength)length);
        }
        private void viewHistory()
        {
            MathGameUI.ShowGamesHistory(m_PreviousGames);
        }
    }

}
