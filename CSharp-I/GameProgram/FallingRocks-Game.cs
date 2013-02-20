// Implement the "Falling Rocks" game in the text console. 
// A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). 
// A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
// Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
// The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
// Implement collision detection and scoring system.

using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

class FallingRocks
{
    static string dwarf = "(0)";
    static int dwarfPosition = Console.WindowWidth / 2 - 1;
    static int GameScreenWidth = 60;
    static int GameScreenHeight = 29;
    static string GameScreenBase = new string(' ', GameScreenWidth);
    static char[] Symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    static ConsoleColor[] RockColors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };    

    class Rocks
    {
        public int Xpos = RandomGen.Next(0, GameScreenWidth);
        public int Ypos;
        public static Random RandomGen = new Random();
        public int width = RandomGen.Next(1, 4);
        private ConsoleColor color = RockColors[RandomGen.Next(RockColors.Length)];
        private char symbol = Symbols[RandomGen.Next(Symbols.Length)];

        public Rocks(int Yposition)
        {
            this.Ypos = Yposition;
        }

        public Rocks(int Xposition, int Yposition)
        {
            this.Xpos = Xposition;
            this.Ypos = Yposition;
        }

        public void Draw()
        {
            //----- reduce the width if the rock extends outside the game window
            width -= ((width + Xpos) / GameScreenWidth) * ((width + Xpos) % GameScreenWidth);
            //-----
            Console.SetCursorPosition(Xpos, Ypos);
            Console.ForegroundColor = color;
            Console.Write(new string(symbol, width));
            Console.ResetColor();
        }

        public void Erase()
        {
            Console.SetCursorPosition(Xpos, Ypos);
            Console.Write(new string(' ', width));
        }
    }

    static void SetConsoleWindow()
    {
        Console.Title = "Falling Rocks";
        Console.SetWindowSize(80, 30);
        Console.BufferWidth = 80;
        Console.BufferHeight = 30;
    }

    static void MoveDwarf(int move)
    {
        if (dwarfPosition + move <= 0) dwarfPosition = 0;
        else if (dwarfPosition + move >= GameScreenWidth - 3) dwarfPosition = GameScreenWidth - 3;
        else dwarfPosition += move;
        Console.SetCursorPosition(dwarfPosition, 28);
    }

    static void setInitialPosition()
    {
        dwarfPosition = GameScreenWidth / 2 - 1;
    }

    static void printBase()
    {
        Console.SetCursorPosition(0, 29);
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write(GameScreenBase);
        Console.ResetColor();
        Console.SetCursorPosition(65, 2);
        Console.WriteLine("FALLING ROCKS");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.SetCursorPosition(65, 4);
        Console.WriteLine("version 1.0");        
        Console.SetCursorPosition(65, 14);
        Console.WriteLine("Controls:");        
        Console.ForegroundColor = ConsoleColor.Magenta;        
        Console.SetCursorPosition(65, 16);
        Console.WriteLine("<- Left arrow");
        Console.SetCursorPosition(65, 17);
        Console.WriteLine("-> Right arrow");
        Console.SetCursorPosition(65, 18);
        Console.WriteLine("ESC for Pause");
        Console.ResetColor();
    }

    static char GameStop()
    {
        Console.SetCursorPosition(11, 2);
        Console.Write(@"Choose ""N"" for End Game or any key to Resume");

        ConsoleKeyInfo choise = Console.ReadKey(true);
        return (choise.KeyChar);
    }

    static void GameOver(int cycleCounter)
    {
        Console.SetCursorPosition(27, 8);
        Console.Write("!!!BANG!!!");
        Console.SetCursorPosition(27, 10);
        Console.Write("Game over!");
        Console.SetCursorPosition(20, 14);
        Console.Write("Your score is: {0} points", cycleCounter * 10);
        Console.SetCursorPosition(6, 16);
        Console.Write(@"Choose ""Y"" for New Game or ""N"" for Exit Program");
        Console.SetCursorPosition(16, 25);
        while (true)
        {
            ConsoleKeyInfo choise = Console.ReadKey(true);
            if (choise.KeyChar == 'Y' || choise.KeyChar == 'y') Main();
            else if (choise.KeyChar == 'N' || choise.KeyChar == 'n') return;
        }
    }

    static void Main()
    {
        SetConsoleWindow();
        setInitialPosition();
        Console.CursorVisible = false;
        Console.Clear();
        printBase();
        MoveDwarf(0);
        Console.Write(dwarf);
        int cycleCounter = 0;
        Queue<Rocks> RockQueue = new Queue<Rocks>();        

        while (true)
        {
            // MoveDwarf
            for (int i = 0; i < 5; i++) // Dwarf could moves five times faster than rocks falls
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.LeftArrow)
                    {
                        MoveDwarf(-1);
                        Console.Write(dwarf + " ");
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        MoveDwarf(1);
                        Console.SetCursorPosition(dwarfPosition-1, 28);
                        Console.Write(" " + dwarf);                        
                    }
                    else if (key == ConsoleKey.Escape) //Stop_Resume Game
                    {
                        char stopChoise = GameStop();
                        if ((stopChoise == 'N') || (stopChoise == 'n'))
                        {
                            GameOver(cycleCounter);
                            return;
                        }
                        Console.SetCursorPosition(11, 2);
                        Console.Write(new string(' ', 45));
                    }
                }
            }

            // clear the key buffer
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
            }

            if (RockQueue.Count > 0)
            {   // Delete rocks on row 28
                while (RockQueue.Peek().Ypos >= GameScreenHeight - 1)
                {
                    Rocks tempRock = RockQueue.Peek();
                    tempRock.Erase();
                    RockQueue.Dequeue();
                }

                // Move all remaining rocks
                foreach (Rocks tempRock in RockQueue)
                {
                    tempRock.Erase();
                    tempRock.Ypos++;
                    tempRock.Draw();
                }
            }
            RockQueue.TrimExcess(); //trim queue

            // Add rocks at row 0. For row to be added, cycle have to devides to random between 1 and 9.
            // Number of the rocks by row is random between 1 and X, where X starts at 2
            // and increases in every 100 cycles.
            if (cycleCounter % Rocks.RandomGen.Next(1, 10) == 0)
            {
                for (int i = 1; i <= 1 + Rocks.RandomGen.Next(1, (2 + (cycleCounter / 100))); i++)
                {
                    Rocks tempRock = new Rocks(0);
                    RockQueue.Enqueue(tempRock);
                    tempRock.Draw();
                }
            }

            // Check for collision            
            foreach (Rocks tempRock in RockQueue)
            {
                if ((tempRock.Ypos >= GameScreenHeight - 2) && (tempRock.Xpos + tempRock.width - 1 >= dwarfPosition) && (tempRock.Xpos <= dwarfPosition + 2))
                {
                    GameOver(cycleCounter);
                    return;
                }
            }

            // Count score
            cycleCounter++;
            Console.SetCursorPosition(65, 28);
            Console.WriteLine("LEVEL " + (cycleCounter / 100 + 1));
            Console.SetCursorPosition(65, 29);
            Console.Write("Score: " + cycleCounter * 10);

            Thread.Sleep(150);
        }
    }
}