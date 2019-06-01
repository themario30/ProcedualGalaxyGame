using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Systems;
using ProcedualGalaxyGame.Core;

namespace ProcedualGalaxyGame
{

    class Game
    {
        private static readonly int _fontSize = 8; //size of the terminal font size, which is 8x8

        private static readonly int _rootConsoleWidth = 50;
        private static readonly int _rootConsoleHeight = 50;
        private static RLRootConsole _rootConsole;

        private static readonly int _mapConsoleWidth = 50;
        private static readonly int _mapConsoleHeight = 40;
        private static RLConsole _mapConsole;

        private static readonly int _logConsoleWidth = 50;
        private static readonly int _logConsoleHeight = 10;
        private static RLConsole _logConsole;


        public static bool isRenderRequired;

        static void Main(string[] args)
        {
            _rootConsole = new RLRootConsole("terminal8x8.png", _rootConsoleWidth, _rootConsoleHeight, _fontSize, _fontSize, 1.5f, "Test Console");

            _mapConsole = new RLConsole(_mapConsoleWidth, _mapConsoleHeight);
            _logConsole = new RLConsole(_logConsoleWidth, _logConsoleHeight);

            _rootConsole.Update += RootConsoleUpdate;
            _rootConsole.Render += RootConsoleRender;

            isRenderRequired = true;

            _rootConsole.Run();

        }

        private static void RootConsoleRender(object sender, UpdateEventArgs e)
        {
            if (isRenderRequired)
            {
                DisplayMap();
                _rootConsole.Draw();
                isRenderRequired = false;
            }


        }

        private static void RootConsoleUpdate(object sender, UpdateEventArgs e)
        {

        }


        //Displays a map with a message log below
        private static void DisplayMap()
        {
            //creates a box outline for the map
            for (int x = 0; x < _mapConsoleWidth; x++)
            {
                _mapConsole.Print(x, 0, "=", RLColor.White);
                _mapConsole.Print(x, _mapConsoleHeight - 1, "=", RLColor.White);

                if (x == 0 || x == _mapConsoleWidth - 1)
                {
                    for (int y = 0; y < _mapConsoleHeight; y++)
                    {
                        _mapConsole.Print(x, y, "|", RLColor.White);
                    }
                }
            }            

            _mapConsole.SetBackColor(0, 0, _mapConsoleWidth, _mapConsoleHeight, RLColor.Black);
            _logConsole.SetBackColor(0, 0, _logConsoleWidth, _logConsoleHeight, RLColor.Gray);

            SpaceSystem map = SystemGenerator.CreateSystem();
            map.Draw(_mapConsole, _mapConsoleWidth, _mapConsoleHeight);

            _mapConsole.Print(5, 5, "System Map", RLColor.White);
            _logConsole.Print(5, 2, "Log", RLColor.White);

            RLConsole.Blit(_mapConsole, 0, 0, _mapConsoleWidth, _mapConsoleHeight, _rootConsole, 0, 0);
            RLConsole.Blit(_logConsole, 0, 0, _logConsoleWidth, _logConsoleHeight, _rootConsole, 0, _mapConsoleHeight);
        }
    }
}
