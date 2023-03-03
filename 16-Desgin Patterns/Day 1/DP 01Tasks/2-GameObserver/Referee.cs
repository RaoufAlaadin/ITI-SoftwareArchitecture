using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GameObserver
{
    public class Referee : IObserver
    {
        private Position _ballPosition;

        public Position BallPosition
        {
            get { return _ballPosition; }
            set { _ballPosition = value; }
        }

        public void Update(Ball ball)
        {
            _ballPosition = ((Football)ball).GetBallPosition();
            Console.WriteLine("Referee updated: ball position is now ({0}, {1}, {2})",
                _ballPosition.X, _ballPosition.Y, _ballPosition.Z);
        }
    }
}
