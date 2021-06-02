using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Racer.Core.Model
{
    public class EnemyCar : GameObject
    {
        public int Speed;

        public EnemyCar(string path, int x, int y)
        {
            Icon = Image.FromFile(path);
            X = x;
            Y = y;
            Width = Icon.Width;
            Height = Icon.Height;
            Speed = 5;
        }

        public void MoveEnemy(int step, int numberOfCar, EnemyCar neibor)
        {
            if (Y > 1000)
            {
                X = new Random().Next(100 * step, (100 * (step + 1)) - Width);
                Y = -new Random().Next(300, 700);
                Speed = new Random().Next(5, 10);
            }
            if (neibor != null && Y < 0 && numberOfCar % 2 == 0 && Math.Abs(Y - neibor.Y) < new Random().Next(150, 400)) return;
            Y = GameModel.Score > 5000 ? Y + Speed + 5 : Y + Speed + GameModel.Score / 1000;
            //Y += Speed;
        }
    }
}
