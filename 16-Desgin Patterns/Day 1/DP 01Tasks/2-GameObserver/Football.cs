using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GameObserver
{
    public class Football : Ball
    {

        private Position _ballPosition;

        public Position GetBallPosition()
        {
            return _ballPosition;
        }

        public void SetBallPosition(Position position)
        {
            _ballPosition = position;
            NotifyObservers();
        }

    }

}
