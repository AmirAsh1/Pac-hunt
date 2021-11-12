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
    class Obj : Game1
    {
        #region Data
        public int lastDir = 0;
        public Boolean wasImpact = false;
        public Boolean atCrossroads = false;
        public int Cdir = 0;
        public Boolean active = false;
        public Vector2 dirAI = new Vector2(0, -1);
        public int wallCol { get; set; }
        public int animState { get; set; }
        public Texture2D texture { get; set; }
        public Vector2 lastPos { get; set; }
        public Vector2 Position { get; set; }
        Rectangle? sourceRectangle;
        Color color;
        public float Rotation { get; set; }
        Vector2 origin;
        Vector2 scale;
        SpriteEffects effects;
        float layerDepth;
        #endregion

        #region ctor
        public Obj(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
            float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.texture = texture;
            this.Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.Rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.layerDepth = layerDepth;
            this.lastPos = position;
            this.animState = 0;
            

        }
        #endregion

        public int distance(Obj o)
        {
            int x = (int)Math.Abs(o.Position.X - this.Position.X);
            int y = (int)Math.Abs(o.Position.Y - this.Position.Y);

            int distance = (int)Math.Sqrt(x * x + y * y);
            return distance;
        }

        public void DrawGameOver(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(0,100), sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);

        }
        public void Draw(SpriteBatch spritebatch, Texture2D texture3, Texture2D texture2)
        {
            if (this.animState%15 <=5)
            {
                spritebatch.Draw(this.texture, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
                animState++;
            }
            else
            {
                if (this.animState%15 >= 5 && this.animState%15 <=10)
                {
                    spritebatch.Draw(texture2, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
                    animState ++;
                }
                else
                {
                    if (this.animState % 15 >= 10)
                    {
                        spritebatch.Draw(texture3, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
                        animState++;
                    }
                }
            }

        }
        public void Draw(SpriteBatch spritebatch, Texture2D texture2)
        {
            if (this.animState % 10 <= 5)
            {
                spritebatch.Draw(this.texture, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
                animState++;
            }
            else
            {
                if (this.animState % 10 >= 5 )
                {
                    spritebatch.Draw(texture2, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
                    animState++;
                }
               
            }

        }
        public void DrawDeath(SpriteBatch spritebatch, Texture2D texture, Color color)
        {
            spritebatch.Draw(texture, Position, sourceRectangle, color, Rotation, origin, scale, effects, layerDepth);
        }

        public int findImpactDir(Vector2 lastPos) 
        {
            //returns the side from which the Obj has hit the wall. 1 - wall is above Obj  2- wall is to the right of obj  3- wall is below Obj
            //4- wall is to the left of Obj
            //compares the pos which is inside the wall (hit) to the last pos which is outside of it and thus returns the side from which the Obj hit
            //the wall
            if (this.Position.X < lastPos.X)
            {
                return 4;
            }
            if (this.Position.X > lastPos.X)
            {
                return 2;
            }
            if (this.Position.Y < lastPos.Y)
            {
                return 1;
            }

            if (this.Position.Y > lastPos.Y)
            {
                return 3;
            }
            return 0;

        }


        public void collision(Wall w)
        {
            //checks if the Obj has entered a wall, if so it changes it's position to the position before it moved into the wall
            if (this.Position.X >= w.Position.X && this.Position.X <= w.Position.X + w.Width)
            {
                if (this.Position.Y >= w.Position.Y && this.Position.Y <= w.Position.Y + w.Length)
                {
                    //remembers the side from which it hit the wall
                    this.wallCol = this.findImpactDir(lastPos);
                    this.wasImpact = true;
                    this.Position = this.lastPos;
                    
                }
            }
        }

        public int checkFurtherAxis(Pac p)
        {
            if (Math.Abs(this.Position.X - p.Position.X) < Math.Abs(this.Position.Y - p.Position.Y))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

    }
}
