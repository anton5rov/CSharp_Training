namespace AcademyPopcorn
{
    using System.Collections.Generic;

    public class ExplodingBlock : Block
    {
        private UnstoppableBall[] bombPieces = new UnstoppableBall[8];

        private char[,] myBody = { { 'B' } };

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = this.myBody;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!(i == 0 && j == 0))
                        {
                            producedObjects.Add(
                                new Piece(new MatrixCoords(this.topLeft.Row + i, this.topLeft.Col + j), 0)
                                );
                        }
                    }
                }
            }

            return producedObjects;
        }

        private class Piece : Ball
        {
            private char[,] pieceBody = { { ':' } };

            public Piece(MatrixCoords topLeft, uint lifeTime)
                : base(topLeft, new MatrixCoords(0, 0))
            {
                this.LifeTime = lifeTime;
                this.body = this.pieceBody;
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
}