using System;

namespace LsiCinema
{
    internal class FoundResultException : Exception
    {
        public int Row { get; private set; }
        public int Number1 { get; private set; }
        public int Number2 { get; private set; }

        public FoundResultException(int row, int number1, int number2)
        {
            Row = row + 1;
            Number1 = number1 + 1;
            Number2 = number2 + 1;
        }
    }
}
