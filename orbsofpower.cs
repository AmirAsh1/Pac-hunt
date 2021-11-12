using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pacman
{
    class orbsofpower : Obj
    {
        public Boolean status { get; set; }
        public int spawnnum = 0;
        public orbsofpower(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
            float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            : base(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {
            this.status = false;
        
        }

        
    }
}
