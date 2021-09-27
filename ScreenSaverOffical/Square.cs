using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    class Square : Shape
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
        public override int GetArea()
        {
            return width * height;
        }

        public override int GetPerimeter()
        {
            return 2 * width + 2 * height;
        }

        //public override void InitWithRandomValues(int[,] matrix)
        //{
        //    Random rnd = new Random();
        //    y = rnd.Next(1, matrix.GetLength(0) - 2);
        //    x = rnd.Next(1, matrix.GetLength(1) - 2);
        //    if (matrix.GetLength(0) - y > matrix.GetLength(1) - x)
        //    {
        //        if (x < matrix.GetLength(1) / 2 + 1)
        //            width = rnd.Next(1, x);
        //        else
        //            width = rnd.Next(1, (matrix.GetLength(1) - 1) - x);
        //        height = width;
        //    }
        //    else
        //    {
        //        if (y < matrix.GetLength(0) / 2 + 1)
        //            height = rnd.Next(1, y);
        //        else
        //            height = rnd.Next(1, (matrix.GetLength(0) - 1) - y);
        //        width = height;
        //    }
        //}

        public override void InitWithRandomValues(int[,] matrix)
        {
            name = "Square";
            Random rnd = new Random();
            y = rnd.Next(2, matrix.GetLength(0) - 3);
            x = rnd.Next(2, matrix.GetLength(1) - 3);
            int heightMax;
            int widthMax;
            //x = matrix.GetLength(1) / 2;
            //y = matrix.GetLength(0) / 2;
            x = 2;
            y = 2;
            

            if ((matrix.GetLength(0) - 2) - y < y - 1)
                heightMax = (matrix.GetLength(0) - 2) - y;
            else
                heightMax = y - 1;

            if ((matrix.GetLength(1) - 2) - x < x - 1)
                widthMax = (matrix.GetLength(1) - 2) - x;
            else
                widthMax = x - 1;

            //if (heightMax > widthMax)
            //    width = rnd.Next(1, widthMax);
            //else
            //    width = rnd.Next(1, heightMax);
            //ColorShap(this,EventArgs.Empty);
            if (heightMax > widthMax)
                width = widthMax;
            else
                width = heightMax;
            height = width;
            moveY = ShapeMove.Down;
            MoveX = ShapeMove.Right;
            RandomColor();
        }
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("Length:{0}, Area:{1}, Perimeter:{2}", height, GetArea(), GetPerimeter());
        }

    }
}
