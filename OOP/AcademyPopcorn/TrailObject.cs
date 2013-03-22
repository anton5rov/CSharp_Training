using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
	{
        protected uint LifeTime { get; private set; }
        public TrailObject(MatrixCoords topLeft, char[,] body, uint lifeTime) : base(topLeft, body)
        {
            this.LifeTime = lifeTime;            
        }

        public override void Update()
        {
            this.CheckLife();
        }
        private void CheckLife()
        {
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
            else this.LifeTime--;
        }

	}
}
