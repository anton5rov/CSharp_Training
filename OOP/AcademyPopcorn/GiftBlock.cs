using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public new const string CollisionGroupString = "GiftBlock";
        private char[,] myBody = {{'G'}};
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = myBody;            
        }
        public override string GetCollisionGroupString()
        {
            return GiftBlock.CollisionGroupString;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Gift> gifts = new List<Gift>();            
            if (this.IsDestroyed)
            {
                gifts.Add(new Gift(this.TopLeft));

            }
            return gifts;
        }
    }
}
