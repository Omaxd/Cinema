namespace LsiCinema
{
    public class SeatPointer
    {
        private readonly int _changeModifier;
        public int Number { get; set; }
        public bool PreviousIsFree { get; private set; }
        public bool CurrentIsFree { get; set; }
        public bool IsFree { get; set; }

        public SeatPointer(int number, int changeModifier) 
        {
            Number = number;
            _changeModifier = changeModifier;
        }

        public void Next()
        {
            Number += _changeModifier;
            PreviousIsFree = CurrentIsFree;
        }

        public int GetPreviousNumber()
        {
            return Number - _changeModifier;
        }
    }
}
