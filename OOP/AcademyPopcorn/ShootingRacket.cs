namespace AcademyPopcorn
{
    using System.Collections.Generic;

    public class ShootingRacket : Racket
    {
        private ushort bulletsCount = 0;

        private bool isTriggered = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {         
        }

        public void Shoot()
        {
            this.isTriggered = true;            
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("gift"))
            {
                this.bulletsCount += 10;                
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> bullets = new List<GameObject>();

            if (this.bulletsCount > 0 && this.isTriggered)
            {
                int center = this.TopLeft.Col + (this.Width / 2);

                Bullet bullet = new Bullet(new MatrixCoords(this.TopLeft.Row, center));                

                bullets.Add(bullet);

                this.bulletsCount--;
                this.isTriggered = false;
            }

            return bullets;
        }

        public int GetBulletsCount()
        {
            return this.bulletsCount;
        }
    }
}