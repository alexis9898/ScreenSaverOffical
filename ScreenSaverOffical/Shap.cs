using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaverOffical
{
    delegate ConsoleColor GetRandomColor();
    delegate void UserActionHandler(object Sender, EventArgs e);
    abstract class Shape
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public ConsoleColor color;
        public string name;
        public ShapeMove MoveX;
        public ShapeMove moveY;

        public Shape()
        {

        }

        protected Shape(int x, int y, int width, int height, ConsoleColor color, string name, ShapeMove moveX, ShapeMove moveY)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
            this.name = name;
            MoveX = moveX;
            this.moveY = moveY;
        }

        public virtual void ShowDetails()
        {
            Console.Write("Shape:{0}, Location:(x={1}, y={2}), Color={3}, ", name, x, y, color);
        }
        public virtual void DoMove()
        {
            if ( moveY == ShapeMove.Down && MoveX ==ShapeMove.Right )
            {
                x++;
                y++;

            }
            if (moveY == ShapeMove.Down && MoveX == ShapeMove.Left)
            {
                x--;
                y++;
            }
            if (MoveX == ShapeMove.Left && moveY == ShapeMove.Up)
            {
                x--;
                y--;
            }
            if (MoveX == ShapeMove.Right && moveY == ShapeMove.Up)
            {
                x++;
                y--; 
            }
        }
        public void ChangeDirection(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==3)
                    {
                        if(i == matrix.GetLength(0) - 2)
                            moveY = ShapeMove.Up;
                        if (j == matrix.GetLength(1) - 2)
                            MoveX = ShapeMove.Left;
                        if (i == 1)
                            moveY = ShapeMove.Down;
                        if (j == 1)
                            MoveX = ShapeMove.Right;
                    }
                }
            }
        }
        
        public event UserActionHandler User;
        public void UserAction(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i==y && j==x)
                      if (y == matrix.GetLength(0) / 2 && x == matrix.GetLength(1) / 2)
                        if (User != null)
                            User(this,EventArgs.Empty);
                }
            }
        }
        public GetRandomColor GetColor;
        public void RandomColor()
        {
            if (GetColor != null)
               color= GetColor();
        }
        public void ChangeColor(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 3)
                        if (i == 1 || j == 1 || i == matrix.GetLength(0) - 2 | j == matrix.GetLength(1) - 2)
                            RandomColor();
                }
            }
        }
        public abstract void InitWithRandomValues(int[,] matrix);
        public abstract void Draw(int[,] matrix);
        public abstract int GetArea();
        public abstract int GetPerimeter();




    }
}
