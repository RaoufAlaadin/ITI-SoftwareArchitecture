using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_GameBuilder
{
    public class Director
    {
        private GroundBuilder groundBuilder;

        public Director(GroundBuilder builder)
        {
            groundBuilder = builder;
        }

        public void ConstructGround()
        {
            groundBuilder.CreateGround();
            groundBuilder.BuildGallery();
            groundBuilder.BuildGroundSurface();
            groundBuilder.BuildAudience();
        }
    }
}
