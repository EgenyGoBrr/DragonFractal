// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System;
using System.Drawing;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            /*
			Начните с точки (1, 0)
			Создайте генератор рандомных чисел с сидом seed
			
			На каждой итерации:

			1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

				Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
				x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
				y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

				Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
				x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
				y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
		
			2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

			*/
            double x0 = 1;
            double y0 = 0;
            pixels.SetPixel(x0, y0);

            DoFractal(pixels, seed, iterationsCount, x0, y0);
          
        }

        public static void DoFractal(Pixels pixels, int seed, int iterationsCount, double x0, double y0)
        {
            var random = new Random(seed);

            while (iterationsCount > 0)
            {
                double x, y;
                var nextNumber = random.Next(5);
                if (nextNumber == 0)
                {
                    x = (x0 - y0) / 2;
                    y = (x0 + y0) / 2;
                }
                else
                {
                    x = (-x0 - y0) / 2 + 1;
                    y = (x0 - y0) / 2;
                }
                pixels.SetPixel(x, y);

                x0 = x;
                y0 = y;

                iterationsCount--;
            }
        }
	}
}