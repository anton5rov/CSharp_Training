namespace AcademyPopcorn
{
    public class Bullet : Ball
    {   
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new MatrixCoords(-1, 0))
        {
            this.body = new char[,] { { '!' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }        
    }
}