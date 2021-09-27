using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    class VerticalLine : Shape
    {
        public override void Draw(int[,] matrix)
        {
            for (int i = -height; i <= height; i++)
            {
                 matrix[y + i, x ] = (int)DrawShape.Shap;
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

        public override void InitWithRandomValues(int[,] matrix)
        {
            name = "VerticalLine";
            Random rnd = new Random();
            y = rnd.Next(1, matrix.GetLength(0) - 2);
            x = rnd.Next(1, matrix.GetLength(1) - 2);
            int heightMax;
            if ((matrix.GetLength(0) - 2) - y < y - 1)
                heightMax = (matrix.GetLength(0) - 2) - y;
            else
                heightMax = y - 1;
            height = rnd.Next(1, heightMax);
            width = 0;
            RandomColor();
        }
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("HeightLength:{0}, WidthLength:{1} Area:{2}, Perimeter:{3}", height, width, GetArea(), GetPerimeter());
        }
    }
}
