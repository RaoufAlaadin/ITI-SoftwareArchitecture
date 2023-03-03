using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GameStrategy 
{
    public class Team
    {
        private TeamStrategy strategy;

        public void SetStrategy(TeamStrategy s)
        {
            this.strategy = s;
        }

        public void PlayGame()
        {
            this.strategy.Play();
        }
    }

}
