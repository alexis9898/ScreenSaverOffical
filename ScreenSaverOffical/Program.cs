using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ScreenSaverOffical
{
    enum DrawShape { empty, HeightLine, WidthLine, Shap }
    enum ShapeMove { Up, Down, Right, Left }

    class Program
    {
        static void Main(string[] args)
        {
            ChangeShape();

            //ShapeMoving();
        }
        static ConsoleColor GetRandomColor()
        {
            int c;
            ConsoleColor[] RandomColor;
            do
            {
                RandomColor = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
                Random rnd = new Random();
                c = rnd.Next(RandomColor.Length);

            }
            while (c == (int)ConsoleColor.Black);
            return RandomColor[c];         
        }
        private static void ChangeShape()
        {
            while ((!Console.KeyAvailable))
            {
                int[,] ScreenBoard = Screen.InitScreen();
                Shape[] ShapeScreen = new Shape[5];
                ShapeScreen[0] = new Circle();
                ShapeScreen[1] = new Square();
                ShapeScreen[2] = new Rectangle();
                ShapeScreen[3] = new VerticalLine();
                ShapeScreen[4] = new HarizontalLine();
                Random rnd = new Random();
                int R = rnd.Next(ShapeScreen.Length);
                ShapeScreen[R].GetColor = GetRandomColor;
                ShapeScreen[R].InitWithRandomValues(ScreenBoard);
                //ShapeScreen[R].x = ScreenBoard.GetLength(1) / 2;
                //ShapeScreen[R].y = ScreenBoard.GetLength(0) / 2;
                Thread.Sleep(500);
                ShapeScreen[R].Draw(ScreenBoard);
                ShapeScreen[R].ShowDetails();
                Screen.DrawScreen(ScreenBoard,ShapeScreen[R]);
                ShapeScreen[R].User += CallBack;
                ShapeScreen[R].UserAction(ScreenBoard);
                Thread.Sleep(500);
                Console.Clear();
            }
        }

        private static void CallBack(object Sender, EventArgs e)
        {
            Console.Beep();
        }

        private static void ShapeMoving()
        {
            int[,] ScreenBoard = Screen.InitScreen();         

            Shape[] ShapeScreen = new Shape[3];
            ShapeScreen[0] = new Circle();
            ShapeScreen[1] = new Square();
            ShapeScreen[2] = new Rectangle();
            //ShapeScreen[3] = new VerticalLine();
            //ShapeScreen[4] = new HarizontalLine();

            Random rnd = new Random();
            int R = rnd.Next(ShapeScreen.Length);
            ShapeScreen[R].GetColor = GetRandomColor;
            ShapeScreen[R].InitWithRandomValues(ScreenBoard);
            while ((!Console.KeyAvailable))
            {
                //ShapeScreen[R].ShowDetails();
                //ShapeScreen[R].Draw(ScreenBoard);
                //Screen.DrawScreen(ScreenBoard);
                //Thread.Sleep(500);
                ShapeScreen[R].Draw(ScreenBoard);
                Thread.Sleep(25);
                Screen.DrawScreen(ScreenBoard,ShapeScreen[R]);
                ShapeScreen[R].ChangeDirection(ScreenBoard);
                ShapeScreen[R].ChangeColor(ScreenBoard);
                ShapeScreen[R].DoMove();
                ShapeScreen[R].User += CallBack;
                ShapeScreen[R].UserAction(ScreenBoard);
                ScreenBoard = Screen.InitScreen();
                Console.Clear();

                //r.Draw(ScreenBoard);
                //Screen.DrawScreen(ScreenBoard);
                //Thread.Sleep(50);
                //r.ChangeDirection(ScreenBoard);
                //r.DoMove();
                // ScreenBoard = Screen.InitScreen();
                //Console.Clear();
            }
        }

        
    }
}
