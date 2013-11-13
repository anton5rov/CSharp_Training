namespace AcademyPopcorn
{
    using System.Collections.Generic;

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
                this.UpdatePosition();
            }
            else
            {
                this.ProduceObjects();
                this.UpdatePosition();
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            produceObjects.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, 2));

            return produceObjects;
        }

        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
    }
}