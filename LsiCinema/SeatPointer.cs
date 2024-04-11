namespace LsiCinema
{
    public class SeatPointer
    {
        private readonly int _changeModifier;
        public int Number { get; set; }
        public SeatState PreviousState { get; private set; }
        public SeatState CurrentState { get; set; }

        public SeatPointer(int number, int changeModifier) 
        {
            Number = number;
            _changeModifier = changeModifier;
        }

        public void Next()
        {
            Number += _changeModifier;
            PreviousState = CurrentState;
        }

        public int GetPreviousNumber()
        {
            return Number - _changeModifier;
        }

        public bool IsTwoSeatsValid()
        {
            if (CurrentState == SeatState.SingleFree && PreviousState == SeatState.SingleFree)
            {
                return true;
            }
            else if (_changeModifier == -1 && CurrentState == SeatState.LeftFree && PreviousState == SeatState.RightFree)
            {
                return true;
            }
            else if (_changeModifier == 1 && CurrentState == SeatState.RightFree && PreviousState == SeatState.LeftFree)
            {
                return true;
            }

            return false;
        }
    }
}
