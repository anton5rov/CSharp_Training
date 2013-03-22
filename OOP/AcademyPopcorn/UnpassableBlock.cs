using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassableBlock";
        private char[,] myBody = {{'<','>'}};
        public UnpassableBlock(MatrixCoords topLeft):base(topLeft)
        {
            this.body = myBody;            
        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }        
    }
}
