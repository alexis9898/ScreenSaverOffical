using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    class HarizontalLine:Shape
    {
        public override void Draw(int[,] matrix)
        {
            for (int i = -width; i <= width; i++)
            {
                matrix[y , x+i] = (int)DrawShape.Shap;
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
            name = "HarizontalLine";
            Random rnd = new Random();
            y = rnd.Next(1, matrix.GetLength(0) - 2);
            x = rnd.Next(1, matrix.GetLength(1) - 2);
            int wwidthMax;
            if ((matrix.GetLength(1) - 2) - x< x - 1)
                wwidthMax = (matrix.GetLength(1) - 2) - x;
            else
                wwidthMax = x - 1;
            width = rnd.Next(1, wwidthMax);
            height = 0;
            RandomColor();
        }
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("HeightLength:{0}, WidthLength:{1} Area:{2}, Perimeter:{3}", height, width, GetArea(), GetPerimeter());
        }
    }
}

