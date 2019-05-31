using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace ProcedualGalaxyGame
{

    class Game
    {
        public static int fontSize = 8; //size of the terminal font size, which is 8x8

        public static int rootConsoleWidth = 50;
        public static int rootConsoleHeight = 50;
        private static RLRootConsole rootConsole;



        static void Main(string[] args)
        {
            rootConsole = new RLRootConsole("terminal8x8.png", rootConsoleWidth, rootConsoleHeight, fontSize, fontSize, 1.5f, "Test Console");

            for (int x = 0; x < rootConsoleWidth; x++)
            {
                for (int y = 0; y < rootConsoleHeight; y++)
                {
                    rootConsole.Print(x, y, " ", RLColor.White , RLColor.Black);
                }
            }




            rootConsole.Update += RootConsoleUpdate;
            rootConsole.Render += RootConsoleRender;

            rootConsole.Run();

        }

        private static void RootConsoleRender(object sender, UpdateEventArgs e)
        {
            rootConsole.Print(rootConsoleWidth/2, rootConsoleWidth/2, "O", RLColor.Yellow, RLColor.Black);
            rootConsole.Draw();
        }

        private static void RootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            ;
        }
    }
}
