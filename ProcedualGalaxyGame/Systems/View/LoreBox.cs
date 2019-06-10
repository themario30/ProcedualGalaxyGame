using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Core.Lore;

namespace ProcedualGalaxyGame.Systems.View
{
    public class LoreBox
    {

        public int width { get; private set; }
        public int height { get; private set; }

        public string Subject { get; private set; }
        public List<string> Description { get { return Logs; } }

        private List<string> Logs;
        private List<string> DisplayLogs;
        private List<RLColor> ColorDisplay;

        //Margins
        private int marginX;
        private int marginY;

        private int subjectY = 3;

        private int scrollX;
        private int scrollY;

        private int pageView;
        private int currentPageView;
        private int maxPageView;


        public LoreBox(List<string> Logs, int Width, int Height, string subject, int MarginX = 1, int MarginY = 1)
        {
            //this.Logs = Logs;
            this.marginX = MarginX;
            this.marginY = MarginX;

            this.width = Width;
            this.height = Height;

            this.Logs = new List<string>();
            this.DisplayLogs = new List<string>();
            this.ColorDisplay = new List<RLColor>();

            this.Subject = subject;


            Generate();

        }

        public void Generate()
        {
            StreamReader sr = new StreamReader(new FileStream("Genesis.txt", FileMode.Open, FileAccess.Read));

            //read everyline
            while (!sr.EndOfStream)
            {
                Logs.Add(sr.ReadLine());
            }


            scrollX = width - 3;
            scrollY = height - (subjectY - 1);

            int cutoffLength = width - (width - scrollX) - (2 * marginX);

            for (int i = 0; i < Logs.Count; i++)
            {
                string remaining = Logs[i];

                RLColor currentColor = LoreColors.Colors[RandomNumberGenerator.Range(0, LoreColors.Colors.Length - 1)];

                while (remaining.Length > cutoffLength)
                {
                    //Console.WriteLine($"{remaining} {remaining.Length}");
                    DisplayLogs.Add(remaining.Substring(0, cutoffLength));
                    remaining = remaining.Substring(cutoffLength);
                    ColorDisplay.Add(currentColor);
                }

                DisplayLogs.Add(remaining);
                ColorDisplay.Add(currentColor);

                DisplayLogs.Add(" ");
                ColorDisplay.Add(currentColor);

            }

            pageView = (height - 1) - subjectY - (2 * marginY);
            currentPageView = 0;
            maxPageView = DisplayLogs.Count - pageView;
        }

        public RLConsole Draw()
        {

            RLConsole console = new RLConsole(width, height);
            console.SetBackColor(0, 0, width, height, RLColor.Black);


            for(int x = 0; x < width; x++)
            {
                console.Print(x, 0, "=", RLColor.White);
                console.Print(x, height - 1, "=", RLColor.White);

                if(x != 0 || x != width - 1)
                {
                    console.Print(x, subjectY - 1, "=", RLColor.White);
                }

                int subjectCenterX = width / 2 - Subject.Length / 2;

                console.Print(subjectCenterX, 1, Subject, RLColor.White);

                if(x == 0 || x == width - 1)
                {
                    for(int y = 1; y < height - 1; y++)
                    {
                        if(y < subjectY)
                            console.Print(x, y, "=", RLColor.White);
                        else
                            console.Print(x, y, "|", RLColor.White);
                        
                    }
                }

                if(x == scrollX)
                {
                    for(int y = subjectY; y < height - 1; y++)
                    {
                        console.Print(x, y, "|", RLColor.White);
                    }
                }
            }

            int currentScrollBarY = (int)GameLogic.Lerp(subjectY, height - 1, currentPageView / (float)maxPageView);

            console.Print(scrollX + 1, currentScrollBarY, "+", RLColor.White);

            for(int i = 0; i < pageView; i++)
            {
                console.Print(1 + marginX, subjectY + marginY + i, DisplayLogs[i + currentPageView], ColorDisplay[i + currentPageView]);
            }

            return console;
        }

        public void ScrollUp()
        {
            currentPageView = Math.Max(currentPageView - 1, 0);
        }

        public void ScrollDown()
        {
            currentPageView = Math.Min(maxPageView, currentPageView + 1);
        }

    }
}
