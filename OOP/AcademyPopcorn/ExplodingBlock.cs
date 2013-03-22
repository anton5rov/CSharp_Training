using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        private UnstoppableBall[] bombPieces = new UnstoppableBall[8];
        private char[,] myBody = { { 'B' } };
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = myBody;
        }

        private class Piece : Ball
        {
            protected uint LifeTime { get; private set; }
            private char[,] pieceBody = { { ':' } };
            public Piece(MatrixCoords topLeft, uint lifeTime)
                : base(topLeft, new MatrixCoords(0, 0))
            {
                this.LifeTime = lifeTime;
                this.body = pieceBody;
            }
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
                else this.LifeTime--;
            }
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!(i == 0 && j == 0))
                            produceObjects.Add(new Piece(new MatrixCoords(this.topLeft.Row + i, this.topLeft.Col + j), 0));
                    }
                }
            }
            return produceObjects;
        }
    }
}
