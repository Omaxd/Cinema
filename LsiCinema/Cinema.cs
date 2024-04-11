using System;

namespace LsiCinema
{
    public class Cinema
    {
        private ushort _maxRow = 11;
        private ushort _maxNumber = 18;
        private int _centerRow;

        private ushort[][] _cinema;

        private SeatPointer[][] _pointerToSeats;

        public Cinema() 
        {
            _cinema = SeatFiller.FillSeats();
            FillSeatPointer();
        }

        public void FindBestPlaces()
        {
            _centerRow = _maxRow / 2;

            int minRow = 0;
            int maxRow = 1;

            try
            {
                // Pierwszy obieg
                CreateFirstIterationInRow(0);

                while (maxRow > minRow)
                {
                    for (int i = minRow; i < maxRow; i++)
                    {
                        if (_pointerToSeats[_centerRow - i][(int)Side.Left].Number < 0)
                        {
                            minRow++;
                            continue;
                        }

                        GoToNext(i, Side.Left, Side.Up);
                        GoToNext(i, Side.Right, Side.Up);

                        if (i != 0)
                        {
                            GoToNext(i, Side.Left, Side.Down);
                            GoToNext(i, Side.Right, Side.Down);
                        }
                    }

                    if (maxRow <= _centerRow)
                    {                       
                        CreateFirstIterationInRow(maxRow * (int)Side.Up);
                        CreateFirstIterationInRow(maxRow * (int)Side.Down);
                        maxRow++;
                    }
                }

                Console.WriteLine("Nie znaleziono żadnych miejsc");
            }
            catch(FoundResultException e)
            {
                Console.WriteLine(string.Format("Znaleziono dwa miejsca w rzędzie {0}: {1}, {2}",
                    e.Row,
                    e.Number1,
                    e.Number2));
            }
        }

        private void CreateFirstIterationInRow(int row)
        {
            row += _centerRow;
            _pointerToSeats[row][(int)Side.Left].CurrentIsFree =
                _cinema[row][_pointerToSeats[row][(int)Side.Left].Number] == 1;

            _pointerToSeats[row][(int)Side.Right].CurrentIsFree =
                _cinema[row][_pointerToSeats[row][(int)Side.Right].Number] == 1;

            if (_pointerToSeats[row][(int)Side.Left].CurrentIsFree == true &&
                _pointerToSeats[row][(int)Side.Right].CurrentIsFree == true)
            {
                throw new FoundResultException(
                    row,
                    _pointerToSeats[row][(int)Side.Left].Number,
                    _pointerToSeats[row][(int)Side.Right].Number);
            }

            _pointerToSeats[row][(int)Side.Left].Next();
            _pointerToSeats[row][(int)Side.Right].Next();
        }

        private void GoToNext(int rowDistance, Side horizontal, Side vertical)
        {
            int row = _centerRow + rowDistance * (int)vertical;
            int side = (int)horizontal;

            _pointerToSeats[row][side].CurrentIsFree =
                _cinema[row][_pointerToSeats[row][side].Number] == 1;

            if (_pointerToSeats[row][side].CurrentIsFree &&
                _pointerToSeats[row][side].PreviousIsFree)
            {
                throw new FoundResultException(
                    row,
                    _pointerToSeats[row][side].Number,
                    _pointerToSeats[row][side].GetPreviousNumber());
            }

            _pointerToSeats[row][side].Next();
        }

        private void FillSeatPointer()
        {
            _pointerToSeats = new SeatPointer[_maxRow][];
            int centerNumber = _maxNumber / 2;

            for (int i = 0; i < _maxRow; i++)
            {
                _pointerToSeats[i] = new SeatPointer[]
                {
                    new SeatPointer(centerNumber - 1, -1),
                    new SeatPointer(centerNumber, 1)
                };
            }
        }
    }
}
