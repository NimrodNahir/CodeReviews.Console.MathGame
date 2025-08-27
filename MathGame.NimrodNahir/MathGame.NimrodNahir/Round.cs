namespace MathGame.NimrodNahir
{
    internal class Round
    {
        private string m_RoundPrint;
        private int m_RoundResult;

        public string RoundPrint
        {
            get => m_RoundPrint;
        }
        public int Answer
        {
            get => m_RoundResult;
        }

        private Dictionary<eGameType, char> m_TypeToSymbol = new Dictionary<eGameType, char>()
        {
            {eGameType.Addition, '+'},
            {eGameType.Subtraction, '-' },
            { eGameType.Multiplication, '*'},
            { eGameType.Division, '/'},
        };

        internal Round(eGameType i_RoundType, int i_LowerLimit, int i_HigherLimit, Random i_NumberGen)
        {
            create(i_RoundType,i_LowerLimit,i_HigherLimit, i_NumberGen);
        }
        internal void create(eGameType i_RoundType, int i_LowerLimit, int i_HigherLimit, Random i_NumberGen)
        {
            
            int firstNumber = i_NumberGen.Next(i_LowerLimit, i_HigherLimit);
            int secondNumber = i_NumberGen.Next(i_LowerLimit, i_HigherLimit);
            if (i_RoundType == eGameType.Division)
            {
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = i_NumberGen.Next(i_LowerLimit, i_HigherLimit);
                    secondNumber = i_NumberGen.Next(i_LowerLimit, i_HigherLimit);
                }
            }
            m_RoundPrint = $"{firstNumber} {m_TypeToSymbol[i_RoundType]} {secondNumber}";
            m_RoundResult = i_RoundType switch
            {
                eGameType.Addition => firstNumber + secondNumber,
                eGameType.Subtraction => firstNumber - secondNumber,
                eGameType.Multiplication => firstNumber * secondNumber,
                eGameType.Division => firstNumber / secondNumber,
            };
        }
    }
}
