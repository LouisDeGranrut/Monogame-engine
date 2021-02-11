using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagsToRiches
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Player player)
        {
            Transform = Matrix.CreateTranslation(-(player.position.X - (8)) * .9f, -(player.position.Y - (8)) * .9f, 0) * Matrix.CreateTranslation(Globals.screenWidth / 4, Globals.screenHeight / 4, 0);
        }
    }
}
