using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                if (i != 5 && i != 31)
                {
                    Block currBlock = new Block(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                }
            }

            // task 1 - make walls and ceiling
            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(leftWallBlock);
                engine.AddObject(rightWallBlock);
            }
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, i));                
                engine.AddObject(ceilingBlock);
            }
            //----------------------------------

            // task 7 - replace the ball
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2 - (RacketLength/2)), RacketLength);
            engine.AddObject(theRacket);

            //task 5 - added instance of the Trail object for 6 cycles            
            engine.AddObject(new TrailObject(new MatrixCoords(20, 17), new char[,] { { 'H','E','L','L','O'} }, 6));
            // task 6 - instance of Meteorite ball            
            engine.AddObject(new MeteoriteBall(new MatrixCoords(15, 0), new MatrixCoords(-1, 1)));
            // task 8 and 9 - UnpassableBlock (<>) and UnstoppableBall (@). 
            // Unstoppable ball walks through the walls and ceiling and bounces from the UnpassableBlock only
            // Uncomment line 30 in the UnstoppableBall class if needed to bounce from the walls and ceiling
            engine.AddObject(new UnpassableBlock(new MatrixCoords(12, 9)));            
            engine.AddObject(new UnstoppableBall(new MatrixCoords(22, 0), new MatrixCoords(-1, 1)));
            // task 10 - exploding block ("B" symbols)
            engine.AddObject(new ExplodingBlock(new MatrixCoords(3, 5)));
            engine.AddObject(new ExplodingBlock(new MatrixCoords(3, 31)));
            // task 11 - gift ("+" symbol)
            engine.AddObject(new Gift(new MatrixCoords(0, 19)));
            // task 12 - GiftBlock (hit the symbol "G")
            engine.AddObject(new GiftBlock(new MatrixCoords(7, 31)));
            //TODO task 13 - not fully implemented
       
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 300);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };            

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
                {
                    
                    (gameEngine as Engine1).ShootPlayerRacket();
                };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
