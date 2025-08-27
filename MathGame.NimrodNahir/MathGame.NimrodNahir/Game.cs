namespace MathGame.NimrodNahir
{
    internal class Game
    {
        private eGameType m_GameType;
        private eDifficulty m_GameDifficulty;
        private int m_Score = 0;
        private eGameLength m_GameLength;
        private int m_NumbersLowerLimit;
        private int m_NumbersHigherLimit = 100;
        private int m_NumberOfQuestions = 5;
        private DateTime m_GameDate = DateTime.Now;

        internal eGameType GameType
        {
            get => m_GameType;
        }

        internal eDifficulty GameDifficulty
        {
            get => m_GameDifficulty;
        }

        internal eGameLength GameLength
        {
            get => m_GameLength;
        }

        internal DateTime GameDate
        {
            get => m_GameDate;
        }

        internal int Score
        {
            get => m_Score;
        }

        internal int NumberOfQuestions
        {
            get => m_NumberOfQuestions;
        }

        internal Game(eGameType i_Type, eDifficulty i_Difficulty, eGameLength i_Length)
        {
            m_GameType = i_Type;
            m_GameDifficulty = i_Difficulty;
            m_GameLength = i_Length;
        }

        internal void Start()
        {
            InitGameSettings();
            m_GameDate = DateTime.Now;
            Random randNumGenerator = new();
            Round currRound;
            eGameType roundType;
            for (int i = 0; i < m_NumberOfQuestions; i++)
            {

                if(m_GameType == eGameType.Random)
                {

                    int roundTypeIdx = randNumGenerator.Next(4);
                    roundType = roundTypeIdx switch
                    {
                        0 => eGameType.Addition,
                        1 => eGameType.Subtraction,
                        2 => eGameType.Multiplication,
                        3 => eGameType.Division,
                    };
                }
                else
                {
                    roundType = m_GameType;
                }
                currRound = new Round(roundType, m_NumbersLowerLimit, m_NumbersHigherLimit, randNumGenerator);

                int userAnswer = MathGameUI.ShowRound(i + 1, currRound.RoundPrint);
                if (userAnswer == currRound.Answer)
                {
                    
                    m_Score++;
                    MathGameUI.PrintAnswerResponse(true);
                }
                else
                {
                    MathGameUI.PrintAnswerResponse(false, userAnswer, currRound.Answer);
                }

            }
            MathGameUI.ShowEndGameScreen(m_Score, m_NumberOfQuestions);
        }

        private void InitGameSettings()
        {
            m_Score = 0;
            switch(m_GameDifficulty)
            {
                case eDifficulty.Easy:
                    m_NumbersLowerLimit = 1;
                    m_NumbersHigherLimit = 20;
                    break;
                case eDifficulty.Normal:
                    m_NumbersLowerLimit = 1;
                    m_NumbersHigherLimit = 50;
                    break;
                case eDifficulty.Hard:
                    m_NumbersLowerLimit = 1;
                    m_NumbersHigherLimit = 100;
                    break;
                case eDifficulty.Brutal:
                    m_NumbersLowerLimit = 50;
                    m_NumbersHigherLimit = 100;
                    break;
            }
            switch (m_GameLength)
            {
                case eGameLength.Short:
                    m_NumberOfQuestions = 3;
                    break;
                case eGameLength.Normal:
                    m_NumberOfQuestions = 5;
                    break;
                case eGameLength.Long:
                    m_NumberOfQuestions = 10;
                    break;
            }
        }
        
    }
}
