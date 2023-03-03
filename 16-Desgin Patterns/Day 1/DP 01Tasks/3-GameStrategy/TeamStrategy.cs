using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GameStrategy
{
    public abstract class TeamStrategy
    {
        public abstract void Play();
    }

    public class AttackStrategy : TeamStrategy
    {
        public override void Play()
        {
            Console.WriteLine("Attacking!");
        }
    }

    public class DefendStrategy : TeamStrategy
    {
        public override void Play()
        {
            Console.WriteLine("Defending!");
        }
    }
}
