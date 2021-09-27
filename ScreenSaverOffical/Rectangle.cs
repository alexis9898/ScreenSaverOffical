using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    class Rectangle : Shape
    {
        public override void Draw(int[,] matrix)
        {
            for (int i = -height; i <= height; i++)
            {
                for (int j = -width; j <= width; j++)
                {
                    if (i == height || i == -height || j == width || j == -width)
                        matrix[y + i, x + j] = (int)DrawShape.Shap;
                }
            }
        }
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("HeightLength:{0}, WidthLength:{1} Area:{2}, Perimeter:{3}", height, width, GetArea(), GetPerimeter());
        }

        public override int GetArea()
        {
            return width * height;
        }

        public override int GetPerimeter()
        {
            return 2 * width + 2 * height;
        }

        public override void InitWithRandomValues(int[,] matrix)
        {
            name = "Rectangle";
            Random rnd = new Random();
            y = rnd.Next(3, matrix.GetLength(0) - 3);
            x = rnd.Next(3, matrix.GetLength(1) - 3);
            int heightMax;
            int widthMax;
            
            if ((matrix.GetLength(0) - 3) - y < y - 2)
                heightMax = (matrix.GetLength(0) - 3) - y;
            else
                heightMax = y - 2;

            if ((matrix.GetLength(1) - 3) - x < x - 2)
                widthMax = (matrix.GetLength(1) - 3) - x;
            else
                widthMax = x - 2;
            height = heightMax;
            width = widthMax;

            height = rnd.Next(1, heightMax);
            width = rnd.Next(1, widthMax);
            RandomColor();
            moveY = ShapeMove.Down;
            MoveX = ShapeMove.Right;
        }
    }
}
