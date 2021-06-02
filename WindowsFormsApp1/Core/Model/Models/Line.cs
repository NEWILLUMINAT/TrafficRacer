using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_Racer.Helpers;

namespace Traffic_Racer.Core.Model
{
    public class Line : GameObject
    {
        public Line(int x, int y)
        {
            Icon = Image.FromFile(Paths.PathToLineImage);
            X = x;
            Y = y;
            Width = Icon.Width-20;
            Height = Icon.Height;
        }

        public void MoveLine()
        {
            if (Y > 1000)
                Y = -200;
            Y = GameModel.Score > 5000 ? Y - GameModel.Car.Speed + 5 : Y - GameModel.Car.Speed + GameModel.Score / 1000;
            //Y -= GameModel.Car.Speed - (int)GameModel.Score / 500;
        }
    }
}
