using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    class Circle : Shape
    {
        double radius;
        double Pai = 3.14;


        public override void Draw(int[,] matrix)
        {

           
            for (int i = -height; i <= height; i++)
            {
                for (int j = -width; j <= width; j++)
                {
                    if ((j==i*i-width && j<=0) || (j==-(i*i-width) && j>=0))
                        matrix[y + i, x + j] = (int)DrawShape.Shap;
                }
            }
        }

        public override int GetArea()
        {
            return (int)(Pai * radius * radius);
        }

        public override int GetPerimeter()
        {
            return (int)(2*Pai*radius);
        }

        public override void InitWithRandomValues(int[,] matrix)
        {
            Random rnd = new Random();
            y = rnd.Next(3, matrix.GetLength(0) - 4);
            x = rnd.Next(3, matrix.GetLength(1) - 4);
            name = "Circle";
            int heightMax;
            int widthMax;

            if ((matrix.GetLength(1) - 3) - x < x - 2)
                widthMax = (matrix.GetLength(1) - 3) - x;
            else
                widthMax = x - 2;
            int heightLenth = (int)(Math.Sqrt(widthMax));
          
            if (y-2<heightLenth)
                widthMax = (y-2) * (y-2);
            if ((matrix.GetLength(0) - 3) - y < heightLenth)
                widthMax = ((matrix.GetLength(0) - 3) - y) * ((matrix.GetLength(0) - 3) - y);
            width =rnd.Next(1, widthMax);
            height = heightLenth;
            radius = width;
            moveY = ShapeMove.Down;
            MoveX = ShapeMove.Right;
            RandomColor();
        }
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("Radius:{0}, Area:{1}, Perimeter:{2}", radius, GetArea(), GetPerimeter());
        }
    }
}
