namespace MathGame.NimrodNahir
{
    internal static class MathGameUI
    {
        internal static int ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my math game!");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. View Games History");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-----------------------------------");
            return ValidateUserChoice(1, 3);
        }

        internal static eGameType? ShowGameTypeMenu()
        {
            Console.Clear();
            Console.WriteLine("Game Setup - Select Game Type");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.WriteLine("6. Cancle (Main Menu)");
            Console.WriteLine("-----------------------------------");
            int choice = ValidateUserChoice(1, 6);
            eGameType? selectedGameType = choice switch
            {
                1 => eGameType.Addition,
                2 => eGameType.Subtraction,
                3 => eGameType.Multiplication,
                4 => eGameType.Division,
                5 => eGameType.Random,
                _ => null
            };

            return selectedGameType;
        }

        internal static eDifficulty? ShowGameDiffiucltyMenu()
        {
            Console.Clear();
            Console.WriteLine("Game Setup - Select Game Type");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Brutal");
            Console.WriteLine("5. Cancel (Main Menu)");
            Console.WriteLine("-----------------------------------");
            int choice = ValidateUserChoice(1, 5);
            eDifficulty? selectedGameDifficulty= choice switch
            {
                1 => eDifficulty.Easy,
                2 => eDifficulty.Normal,
                3 => eDifficulty.Hard,
                4 => eDifficulty.Brutal,
                _ => null
            };

            return selectedGameDifficulty;
        }

        internal static eGameLength? ShowGameLengthMenu()
        {
            Console.Clear();
            Console.WriteLine("Game Setup - Select Game Type");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Short");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Long");
            Console.WriteLine("4. Cancel (Main Menu)");
            Console.WriteLine("-----------------------------------");
            int choice = ValidateUserChoice(1, 4);
            eGameLength? selectedGameLength = choice switch
            {
                1 => eGameLength.Short,
                2 => eGameLength.Normal,
                3 => eGameLength.Long,
                _ => null
            };

            return selectedGameLength;
        }

        private static int ValidateUserChoice(int i_low, int i_high)
        {
            int choice;
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out choice) || choice < i_low || choice > i_high)
            {
                Console.WriteLine($"\nPlease enter the number of the menu item you wish to select ({i_low} to {i_high})");
                input = Console.ReadLine();
            }

            return choice;
        }

        internal static void ShowExitScreen()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing! (press the enter key to exit)");
            Console.WriteLine();
        }

        internal static void ShowGamesHistory(List<Game> i_GamesList)
        {
            Console.Clear();
            Console.WriteLine("History of played games!");
            Console.WriteLine("------------------------------------");
            foreach (Game game in i_GamesList)
            {
                Console.WriteLine($"{game.GameDate}: Difficulity - {game.GameDifficulty}, Length - {game.GameLength}, Type - {game.GameType}, Score - {game.Score} / {game.NumberOfQuestions}");

            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("(Press 'enter' to return to the main menu)");
            Console.ReadLine();
        }

        internal static int ShowRound(int i_QuestionNumber, string i_Question)
        {
            Console.Clear();
            Console.WriteLine($"Question number {i_QuestionNumber}");
            Console.WriteLine($"---------------------------------");
            Console.WriteLine(i_Question);
            Console.WriteLine("----------------------------------");
            int userAnswer;
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input) || !Int32.TryParse(input, out userAnswer))
            {
                Console.WriteLine("Answer must be an integer");
                input = Console.ReadLine();
            }

            return userAnswer;
        }

        internal static void PrintAnswerResponse(bool i_IsCorrect, int i_UserAnswer = 0, int i_CorrectAnswer =0)
        {
            if(i_IsCorrect)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect. Your answer: {i_UserAnswer}, Correct Answer {i_CorrectAnswer}");
            }
            Console.WriteLine("(Press the enter key to continue to the next quetion)");
            Console.ReadLine();
        }

        internal static void ShowEndGameScreen(int i_UserScore, int i_TotalQuestions)
        {

            Console.Clear();
            Console.WriteLine("Game Finished!");
            Console.WriteLine($"You solved {i_UserScore}/{i_TotalQuestions} questions correctly!");
            Console.WriteLine("(Press the enter key to return to main menu)");
            Console.ReadLine();
        }
    }
}
