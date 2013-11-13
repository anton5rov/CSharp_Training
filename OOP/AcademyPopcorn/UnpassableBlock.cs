namespace AcademyPopcorn
{
    public class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassableBlock";

        private char[,] myBody = { { '<', '>' } };

        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = this.myBody;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}