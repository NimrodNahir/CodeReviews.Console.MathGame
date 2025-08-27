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
                int actionIndex = MathGameUI.ShowMainMenu();
                switch (actionIndex)
                {
                    case 1:
                        StartNewGame();
                        break;
                    case 2:
                        ViewHistory();
                        break;
                    case 3:
                        isActive = false;
                        MathGameUI.ShowExitScreen();
                        break;

                }
            }
        }

        private void StartNewGame()
        {
            Game? currGame = CreateGame();
            if(currGame is not null)
            {
                currGame.Start();
                m_PreviousGames.Add(currGame);
            }
        }

        private Game? CreateGame()
        {
            eGameType? type = MathGameUI.ShowGameTypeMenu();
            if(type is null)
            {
                return null;
            }
            eDifficulty? difficulty = MathGameUI.ShowGameDiffiucltyMenu();
            if(difficulty is null)
            {
                return null;
            }
            eGameLength? length = MathGameUI.ShowGameLengthMenu();

            if (length is null)
            {
                return null;
            }

            return new Game((eGameType)type, (eDifficulty)difficulty, (eGameLength)length);
        }
        private void ViewHistory()
        {
            MathGameUI.ShowGamesHistory(m_PreviousGames);
        }
    }

}
