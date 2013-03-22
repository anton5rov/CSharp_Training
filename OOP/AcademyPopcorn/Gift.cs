using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";        
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { {'+'}}, new MatrixCoords(0, 0))
        {
            this.Speed.Row = 1;
            this.Speed.Col = 0;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }
        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
