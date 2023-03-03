using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_GameDecorator
{
    // Component interface
    public class Player
    {
        public virtual void PassBall()
        {
            Console.WriteLine("Pass the ball");
        }
    }

    // Concrete component class
    public class FieldPlayer : Player
    {
        public override void PassBall()
        {
            Console.WriteLine("Field player passes the ball");
        }
    }

    // Decorator class
    public class PlayerRole : Player
    {
        private Player _player;

        public PlayerRole(Player player)
        {
            _player = player;
        }

        public override void PassBall()
        {
            _player.PassBall();
        }

        public void AssignPlayer(Player player)
        {
            _player = player;
        }
    }

    // Concrete decorator class
    public class Forward : PlayerRole
    {
        public Forward(Player player) : base(player)
        {

        }

        public void ShootGoal()
        {
            Console.WriteLine("Forward shoots a goal");
        }
    }

    // Concrete decorator class
    public class Midfielder : PlayerRole
    {
        public Midfielder(Player player) : base(player)
        {
        }

        public void Dribble()
        {
            Console.WriteLine("Midfielder dribbles");
        }
    }




}
