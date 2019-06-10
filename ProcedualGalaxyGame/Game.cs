using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Systems;
using ProcedualGalaxyGame.Systems.Generators;
using ProcedualGalaxyGame.Core;
using ProcedualGalaxyGame.Core.Lore;
using ProcedualGalaxyGame.Systems.View;

namespace ProcedualGalaxyGame
{

    class Game
    {
        private static readonly int _fontSize = 8; //size of the terminal font size, which is 8x8

        private static readonly int _rootConsoleWidth = 50;
        private static readonly int _rootConsoleHeight = 50;
        private static RLRootConsole _rootConsole;

        private static readonly int _starMapConsoleWidth = 50;
        private static readonly int _starMapConsoleHeight = 40;
        private static RLConsole _starMapConsole;

        private static readonly int _galaxyMapConsoleWidth = 50;
        private static readonly int _galaxyMapConsoleHeight = 50;
        private static RLConsole _galaxyMapConsole; // Galaxy Map will use same dimensions as Star Map

        private static readonly int _logConsoleWidth = 50;
        private static readonly int _logConsoleHeight = 10;
        private static RLConsole _logConsole;

        private static readonly int _loreLogConsoleWidth = 50;
        private static readonly int _loreLogConsoleHeight = 50;
        private static RLConsole _loreLogConsole; //Console for reading the lore

        public static CurrentView currentWindowView;

        public static bool isRenderRequired;

        private static LoreBox loreBox;

        //viewing maps
        public static Galaxy Galaxy;
        public static int currentSystem;

        static void Main(string[] args)
        {
            _rootConsole = new RLRootConsole("terminal8x8.png", _rootConsoleWidth, _rootConsoleHeight, _fontSize, _fontSize, 1.5f, "Test Console");

            _starMapConsole = new RLConsole(_starMapConsoleWidth, _starMapConsoleHeight);
            _logConsole = new RLConsole(_logConsoleWidth, _logConsoleHeight);
            _galaxyMapConsole = new RLConsole(_galaxyMapConsoleWidth, _galaxyMapConsoleHeight);
            _loreLogConsole = new RLConsole(_loreLogConsoleWidth, _loreLogConsoleHeight);

            loreBox = new LoreBox(null, 40, 30, "Genesis");

            Galaxy = GalaxyGenerator.Generate();
            currentSystem = 0;
            currentWindowView = CurrentView.Log;

            _rootConsole.Update += RootConsoleUpdate;
            _rootConsole.Render += RootConsoleRender;

            isRenderRequired = true;

            _rootConsole.Run();

        }

        private static void RootConsoleRender(object sender, UpdateEventArgs e)
        {

            if (isRenderRequired)
            {
                switch (currentWindowView)
                {
                    case CurrentView.MainMenu:
                        break;
                    case CurrentView.StarMap:
                        DisplayMap((SpaceSystem)Galaxy.Systems[currentSystem]);
                        break;
                    case CurrentView.GalaxyMap:
                        DisplayGalaxyLog();
                        break;
                    case CurrentView.Ship:
                        break;
                    case CurrentView.Weapons:
                        break;
                    case CurrentView.Planet:
                        break;
                    case CurrentView.Log:
                        DisplayLog();
                        break;
                }

                //DisplayMap();

                _rootConsole.Draw();
                DisplayLog();
                isRenderRequired = false;
            }

        }

        private static void RootConsoleUpdate(object sender, UpdateEventArgs e)
        {

            RLKeyPress keyPress = _rootConsole.Keyboard.GetKeyPress();

            if(keyPress != null)
            {
                if(keyPress.Key == RLKey.KeypadPlus)
                {
                    if (loreBox != null)
                        loreBox.ScrollUp();
                    isRenderRequired = true;
                }

                if (keyPress.Key == RLKey.KeypadMinus)
                {
                    if (loreBox != null)
                        loreBox.ScrollDown();
                    isRenderRequired = true;
                }

                if(keyPress.Key == RLKey.R)
                {
                    isRenderRequired = true;
                }

                if(keyPress.Key == RLKey.G)
                {
                    currentWindowView = CurrentView.GalaxyMap;
                    isRenderRequired = true;
                }

                if(keyPress.Key == RLKey.S)
                {
                    currentWindowView = CurrentView.StarMap;
                    isRenderRequired = true;
                }

                if(currentWindowView == CurrentView.StarMap)
                {
                    if(keyPress.Key == RLKey.BracketLeft)
                    {
                        currentSystem = currentSystem - 1;
                        if(currentSystem < 0)
                        {
                            currentSystem = Galaxy.Systems.Length - 1;
                        }
                        isRenderRequired = true;
                    }

                    if(keyPress.Key == RLKey.BracketRight)
                    {
                        currentSystem = currentSystem + 1;
                        if(currentSystem == Galaxy.Systems.Length)
                        {
                            currentSystem = 0;
                        }
                        isRenderRequired = true;
                    }
                }
            }

        }

        private static void DisplayBorder(RLConsole console)
        {

           
            for (int x = 0; x < console.Width; x++)
            {
                console.Print(x, 0, "=", RLColor.White);
                console.Print(x, console.Height - 1, "=", RLColor.White);

                if (x == 0 || x == console.Width - 1)
                {
                    for (int y = 0; y < console.Height; y++)
                    {
                        console.Print(x, y, "|", RLColor.White);
                    }
                }
            }
        }

        private static void DisplayGalaxyLog()
        {
            _galaxyMapConsole.SetBackColor(0, 0, _galaxyMapConsole.Width, _galaxyMapConsole.Height, RLColor.Black);

            DisplayBorder(_galaxyMapConsole);

            Galaxy g = GalaxyGenerator.Generate();

            _galaxyMapConsole.Print( 2, 2, "Galaxy Logs", RLColor.White);

            _galaxyMapConsole.Print(5, 5, g.Name, RLColor.White);
            
            for(int i = 0; i < 8; i++)
            {
                SpaceSystem temp = (SpaceSystem)g.Systems[i];
                string NoP = $"Number of Planets - {temp.Bodies.Length}";

                _galaxyMapConsole.Print( 5, 7 + 2*i, temp.Name, temp.Star.Color);
                _galaxyMapConsole.Print( 12, 7 + 2*i, NoP, temp.Star.Color);
            }


            RLConsole.Blit(_galaxyMapConsole, 0, 0, _galaxyMapConsole.Width, _galaxyMapConsole.Height, _rootConsole, 0, 0);

        }

        private static void DisplayLog()
        {

            RLRootConsole.Blit(loreBox.Draw(), 0, 0, loreBox.width, loreBox.height, _rootConsole, 5, 10);
        }

        //Displays a map with a message log below
        private static void DisplayMap(SpaceSystem map)
        {

            _starMapConsole.Clear();
            //creates a box outline for the map
            DisplayBorder(_starMapConsole);

            _starMapConsole.SetBackColor(0, 0, _starMapConsoleWidth, _starMapConsoleHeight, RLColor.Black);
            _logConsole.SetBackColor(0, 0, _logConsoleWidth, _logConsoleHeight, RLColor.Gray);

            map.Draw(_starMapConsole, _starMapConsoleWidth, _starMapConsoleHeight);

            _starMapConsole.Print(5, 5, "System Map", RLColor.White);
            _starMapConsole.Print(5, 7, map.Name, map.Star.Color);
            _starMapConsole.Print(5, 9, map.Star.Type, RLColor.White);
            _starMapConsole.Print(2, 2, $"{currentSystem + 1}", RLColor.White);
            _logConsole.Print(5, 2, "Log", RLColor.White);

            RLConsole.Blit(_starMapConsole, 0, 0, _starMapConsoleWidth, _starMapConsoleHeight, _rootConsole, 0, 0);
            RLConsole.Blit(_logConsole, 0, 0, _logConsoleWidth, _logConsoleHeight, _rootConsole, 0, _starMapConsoleHeight);
        }
    }
}
