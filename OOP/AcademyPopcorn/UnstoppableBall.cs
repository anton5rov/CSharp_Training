using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed ): base(topLeft,speed)
        {
            this.body[0, 0] = '@';
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassableBlock" || 
                otherCollisionGroupString == "indestructibleBlock" || otherCollisionGroupString == "block" ||
                otherCollisionGroupString == "GiftBlock";
        }
        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var item in collisionData.hitObjectsCollisionGroupStrings)
            {
                //uncomment line 30 if needed to bounce from the walls and ceiling
                if (item == "unpassableBlock" || item == "racket" //|| item == "indestructibleBlock" 
                        ) 
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }
        
        
    }
}
