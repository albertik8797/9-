using System;
using System.Threading; //Именно это пространство имен поддерживает многопоточность

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            Snake sn = new Snake(5, 5,20);

            
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);




            while (sn.end==false)
            {
                sn.direction();
            }
            
        }
    }

    //1-голов -1-рамка -2- еда >0 тело
    internal class Snake
    {
        int[,] snake;     //массив для игры
        int w;            //направление
        int hx, hy;       //координаты головы
        int size;
        public bool end;
        public Snake(int x, int y,int s)
        {
            end = false;
            size = s;    
            snake = new int[size,size];
            //заполняем игровое поле
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    snake[i, j] = 0;
                    if (i == 0 || j == 0 || i == (size - 1) || j == (size - 1))
                        snake[i, j] = -1;
                }
            }
            //стартовая позиция змеи
            hx = x;
            hy = y;
            snake[hx, hy] = 1;
            //стартовое направление змеи
            w = 1;

            
            food();

           Thread myThread = new Thread(move); //Создаем новый объект потока (Thread)

            myThread.Start(); //запускаем поток
        }

        //добавляем еду на поле, клетка должна быть пуской
        private void food()
        {
            bool fl = false;
            while (fl == false)
            {
                Random rnd = new Random();
                int n = rnd.Next(1, 18);
                int m = rnd.Next(1, 18);
                if (snake[n, m] == 0)
                {
                    snake[n, m] = -2;
                    fl = true;
                }
            }

        }

        //ход на пустую клетку
        private void step0()
        {
            int max = 1;
            int m1 = 0;
            int m2 = 0;
            //если клетка пустая, к телу змеи прибавляем по 1, на место головы записываем 1 и удаляем максимальный элемент, 
            //так как змея не растет
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (snake[i, j] > 0)
                        snake[i, j] = snake[i, j] + 1;
                    if (snake[i, j] == -10)
                        snake[i, j] = 1;
                    if (snake[i, j] > max)
                    {
                        max = snake[i, j];
                        m1 = i;
                        m2 = j;
                    }
                }
            }
            snake[m1, m2] = 0;
        }
        //ход на клетку с едой
        private void stepf()
        {
            //тоже самое что на пустую клетку, только без удаления макс
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (snake[i, j] > 0)
                        snake[i, j] = snake[i, j] + 1;
                    if (snake[i, j] == -10)
                        snake[i, j] = 1;

                }
            }
            
            food();
        }
        public void move()
        {
            while(true)
            { 
            bool fl = true;
            switch (w)
            {
                case 0:
                    if (snake[hx, hy - 1] == 0)
                    {

                        snake[hx, hy - 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy - 1;
                        step0();
                    }
                    else
                    if (snake[hx, hy - 1] == -2)
                    {

                        snake[hx, hy - 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy - 1;
                        stepf();
                    }
                    else
                    {
                        snake[hx, hy - 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy - 1;
                        step0();
                        fl = false;
                    }
                    break;
                case 1:
                    if (snake[hx + 1, hy] == 0)
                    {

                        snake[hx + 1, hy] = -10;//будущая голова змеи
                        hx = hx + 1;
                        hy = hy;
                        step0();
                    }
                    else
                    if (snake[hx + 1, hy] == -2)
                    {

                        snake[hx + 1, hy] = -10;//будущая голова змеи
                        hx = hx + 1;
                        hy = hy;
                        stepf();
                    }
                    else
                    {
                        snake[hx + 1, hy] = -10;//будущая голова змеи
                        hx = hx + 1;
                        hy = hy;
                        step0();
                        fl = false;
                    }
                    break;
                case 2:
                    if (snake[hx, hy + 1] == 0)
                    {

                        snake[hx, hy + 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy + 1;
                        step0();
                    }
                    else
                    if (snake[hx, hy + 1] == -2)
                    {

                        snake[hx, hy + 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy + 1;
                        stepf();
                    }
                    else
                    {
                        snake[hx, hy + 1] = -10;//будущая голова змеи
                        hx = hx;
                        hy = hy + 1;
                        step0();
                        fl = false;
                    }
                    break;
                case 3:
                    if (snake[hx - 1, hy] == 0)
                    {

                        snake[hx - 1, hy] = -10;//будущая голова змеи
                        hx = hx - 1;
                        hy = hy;
                        step0();
                    }
                    else
                    if (snake[hx - 1, hy] == -2)
                    {

                        snake[hx - 1, hy] = -10;//будущая голова змеи
                        hx = hx - 1;
                        hy = hy;
                        stepf();
                    }
                    else
                    {
                        snake[hx - 1, hy] = -10;//будущая голова змеи
                        hx = hx - 1;
                        hy = hy;
                        step0();
                        fl = false;
                    }
                    break;



            }

            show();
                if (fl == false)
                {     
                    gameover();
                    break;
                }
                Thread.Sleep(500);
            }
            

        }

        private void gameover()
        {
            end = true;
            Console.WriteLine("Вы проиграли!");
        }

            public void direction()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            switch (key.Key)
            {

                case ConsoleKey.UpArrow:
                    if (snake[hx - 1, hy] != 1)
                        w = 3;
                    break;

                case ConsoleKey.DownArrow:
                    if (snake[hx + 1, hy] != 1)
                        w = 1;
                    break;

                case ConsoleKey.RightArrow:
                    if (snake[hx, hy + 1] != 1)
                        w = 2;
                    break;
                    
                case ConsoleKey.LeftArrow:
                    if (snake[hx, hy - 1] != 1)
                        w = 0;
                    break;
                    
            }


        }

        public void show()
        {
            Console.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //тело змеи
                    if (snake[i, j] > 1)
                    {     
                        Console.Write("*");
                    }

                    if (snake[i, j] == 0)
                    {
                        Console.Write(" ");
                    }

                    if (snake[i,j]==-1)
                    {
                        Console.Write("|");
                    }
                    if (snake[i, j] == -2)
                    {
                        Console.Write("#");
                    }
                    if (snake[i, j] == 1)
                    {
                        Console.Write("@");
                    }

                }
                Console.WriteLine("");
            }

        }



    }
}
