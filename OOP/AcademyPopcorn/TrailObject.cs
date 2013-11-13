namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        public TrailObject(MatrixCoords topLeft, char[,] body, uint lifeTime)
            : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        protected uint LifeTime { get; private set; }

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
            else
            {
                this.LifeTime--;
            }
        }
    }
}