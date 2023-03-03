using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_GameBuilder
{
    public abstract class GroundBuilder
    {
        protected Ground ground;

        public void CreateGround()
        {
            ground = new Ground();
        }

        public abstract void BuildGallery();
        public abstract void BuildGroundSurface();
        public abstract void BuildAudience();

        public Ground GetGround()
        {
            return ground;
        }
    }

    // this is one of the settings available. 
    public class ConcreteGroundBuilder : GroundBuilder
    {
        public override void BuildGallery()
        {
            ground.Gallery = "Concrete Gallery";
        }

        public override void BuildGroundSurface()
        {
            ground.GroundSurface = "Grass Ground Surface";
        }

        public override void BuildAudience()
        {
            ground.Audience = "Large Audience";
        }
    }
}
