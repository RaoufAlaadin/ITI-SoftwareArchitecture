using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_GameObserver
{
    public interface IObserver
    {
        void Update(Ball ball);

    }

}
