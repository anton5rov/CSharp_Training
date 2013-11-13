namespace AcademyPopcorn
{
    using System.Collections.Generic;

    public class GiftBlock : Block
    {
        public new const string CollisionGroupString = "GiftBlock";

        private char[,] myBody = { { 'G' } };

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = this.myBody;
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