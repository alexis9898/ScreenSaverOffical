using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ScreenSaverOffical
{
    class Screen
    {
        //for (int i = 0; i<matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j<matrix.GetLength(1); j++)
        //        {

        //        }
        //    }

        public static int[,] InitScreen()
        {
            int[,] matrix = new int[29, 119];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 || i == matrix.GetLength(0) - 1)
                        matrix[i, j] = (int)DrawShape.WidthLine;
                    else if (j == 0 || j == matrix.GetLength(1) - 1)
                        matrix[i, j] = (int)DrawShape.HeightLine;
                    else
                        matrix[i, j] = (int)DrawShape.empty;
                }
            }
            return matrix;
        }
        public static void PrintDraw(string[,] matrix,ConsoleColor color)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "*")
                        Console.ForegroundColor = color;
                    Console.Write(matrix[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public static void DrawScreen(int[,] matrix,Shape shape)
        {
            string[,] screen = new string[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case (int)DrawShape.empty:
                            screen[i, j] = " ";
                            break;
                        case (int)DrawShape.HeightLine:
                            screen[i, j] = "|";
                            break;
                        case (int)DrawShape.WidthLine:
                            screen[i, j] = "-";
                            break;
                        case (int)DrawShape.Shap:
                            screen[i, j] = "*";
                            break;
                    }
                }
            }
            PrintDraw(screen,color(shape));
        }
        public static ConsoleColor color(Shape Shape)
        {
            return Shape.color;
        }
    }
}
