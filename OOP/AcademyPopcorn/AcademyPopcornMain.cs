// Some extra work added. Read the comments at the end.
// Catching the gift loads 10 bullets to shooting racket.

namespace AcademyPopcorn
{
    using System;
    using System.Threading;

    public class AcademyPopcornMain
    {
        public const int worldRows = 23;
        public const int worldCols = 40;
        public const int racketLength = 7;

        private static Random rnd = new Random();

        public static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = worldCols - 2;

            // Added extra legend.            
            PrintLegend();

            // Add blocks line except at postions 5 and 31, reserved for exploding blocks.
            for (int i = startCol; i < endCol; i++)
            {
                if (i != 5 && i != 31)
                {
                    Block currBlock = new Block(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                }
            }

            // Task 1 - Make walls and ceiling.
            for (int i = 1; i < worldRows; i++)
            {
                IndestructibleBlock leftWallBlock =
                    new IndestructibleBlock(new MatrixCoords(i, 0));

                IndestructibleBlock rightWallBlock =
                    new IndestructibleBlock(new MatrixCoords(i, worldCols - 1));

                engine.AddObject(leftWallBlock);

                engine.AddObject(rightWallBlock);
            }

            for (int i = 0; i < worldCols; i++)
            {
                IndestructibleBlock ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(ceilingBlock);
            }

            Racket theRacket = new Racket(
                new MatrixCoords(worldRows - 1, (worldCols / 2) - (racketLength / 2)),
                racketLength);

            engine.AddObject(theRacket);

            // Task 5 - Added instance of the Trail object for 6 cycles.
            engine.AddObject(new TrailObject(
                new MatrixCoords(20, 17),
                new char[,] { { 'H', 'E', 'L', 'L', 'O' } },
                6));

            // Task 6 - Instance of the Meteorite ball.
            engine.AddObject(new MeteoriteBall(new MatrixCoords(15, 0), new MatrixCoords(-1, 1)));

            // Task 7 - Replace the ball. Uncomment if you want to see the original ball too.
            // Ball theBall = new Ball(new MatrixCoords(worldRows / 2, 0), new MatrixCoords(-1, 1));
            // engine.AddObject(theBall);

            // Task 8 and 9 - UnpassableBlock (<>) and UnstoppableBall (@).
            // Unstoppable ball walks through the walls and ceiling and bounces from the UnpassableBlock only.
            // Uncomment line 30 in the UnstoppableBall class if needed to bounce from the walls and ceiling.
            engine.AddObject(new UnpassableBlock(new MatrixCoords(12, 9)));
            engine.AddObject(new UnstoppableBall(new MatrixCoords(22, 0), new MatrixCoords(-1, 1)));

            // Task 10 - Exploding block ("B" symbols).
            engine.AddObject(new ExplodingBlock(new MatrixCoords(3, 5)));
            engine.AddObject(new ExplodingBlock(new MatrixCoords(3, 31)));

            // Task 11 - Gift ("+" symbol).
            engine.AddObject(new Gift(new MatrixCoords(0, 19)));

            // Task 12 - GiftBlock (hit the symbol "G").
            engine.AddObject(new GiftBlock(new MatrixCoords(7, 31)));

            // Task 13 - Change racket to shooting racket
            ShootingRacket shootingRacket = new ShootingRacket(
                new MatrixCoords(worldRows - 1, (worldCols / 2) - (racketLength / 2)),
                racketLength);
            engine.AddObject(shootingRacket);
        }

        public static Gift RandomGifts()
        {
            int giftPositionX = rnd.Next(1, worldCols);
            int giftPositionY = rnd.Next(1, worldRows - 5);
            Gift newGift = new Gift(new MatrixCoords(giftPositionX, giftPositionY));
            return newGift;
        }

        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer(worldRows, worldCols);

            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new ShootingEngine(renderer, keyboard, 300);

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
                    (gameEngine as ShootingEngine).ShootPlayerRacket();
                };

            Initialize(gameEngine);

            // Extra work:
            // Added drop gifts with random start position in separate thread.
            DropGifts(gameEngine);

            // Extra work:
            // Bullets counter added in separate thread.
            StartCounter(gameEngine);            

            gameEngine.Run();
        }

        // Extra work methods: Legend, drop gifts, bullets counter.
        private static void PrintLegend()
        {
            Console.SetCursorPosition(worldCols + 2, 0);
            Console.WriteLine("Legend:");
            Console.SetCursorPosition(worldCols + 2, 1);
            Console.WriteLine(@"# - Normal block");
            Console.SetCursorPosition(worldCols + 2, 2);
            Console.WriteLine(@"G - Gift block");
            Console.SetCursorPosition(worldCols + 2, 3);
            Console.WriteLine(@"+ - Gift ");
            Console.SetCursorPosition(worldCols + 2, 4);
            Console.WriteLine(@"B - Exploding block");
            Console.SetCursorPosition(worldCols + 2, 5);
            Console.WriteLine(@"<> - Unpassable Block");
            Console.SetCursorPosition(worldCols + 2, 6);
            Console.WriteLine(@"@ - UnstoppableBall ");
            Console.SetCursorPosition(worldCols + 2, 8);
            Console.WriteLine(@"A - move left | move right - D");
            Console.SetCursorPosition(worldCols + 2, 9);
            Console.WriteLine(@"Space - Fire");
            Console.SetCursorPosition(worldCols + 2, 11);
            Console.WriteLine(@"Pause - Stop the game");
            Console.SetCursorPosition(worldCols + 2, 12);
            Console.WriteLine(@"any key - Resume the game");
            Console.SetCursorPosition(0, worldRows + 2);
            Console.WriteLine(@"Hint: Every gift (+) adds 10 bullets!");
        }

        // Drop gifts threading.
        private static void DropGifts(Engine gameEngine)
        {
            Thread giftsThread = new Thread(() =>
            {
                while (true)
                {
                    AddGift(gameEngine);
                    Thread.Sleep(50000);
                }
            });

            giftsThread.Start();
        }
                        
        private static void AddGift(Engine engine)
        {
            int giftPositionX = rnd.Next(5, worldCols - 5);
            int giftPositionY = rnd.Next(4, worldRows - 10);
            Gift newGift = new Gift(new MatrixCoords(giftPositionY, giftPositionX));
            engine.AddObject(newGift);            
        }

        // Counter threading.
        private static void StartCounter(Engine gameEngine)
        {
            Counter counter = new Counter(new MatrixCoords(1, 1));
            gameEngine.AddObject(counter);
            Thread counterThread = new Thread(() =>
            {
                while (true)
                {
                    UpdateCounter(gameEngine, counter);
                    Thread.Sleep(10);
                }
            });

            counterThread.Start();
        }
        
        private static void UpdateCounter(Engine engine, Counter counter)
        {
            counter.UpdateValue((engine as ShootingEngine).CheckBullets()); 
        }
    }
}