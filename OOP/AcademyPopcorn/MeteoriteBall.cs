using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public new const string CollisionGroupString = "meteoriteBall";
        private bool isNew;
        
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.isNew = true;
        }
        public override void Update()
        {
            if (this.isNew == true)
            {
                this.isNew = false;
                UpdatePosition();
            }
            else
            {
                this.ProduceObjects();
                UpdatePosition();
            }
        }
        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            produceObjects.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, 2));
            return produceObjects;
        }
    }
}
