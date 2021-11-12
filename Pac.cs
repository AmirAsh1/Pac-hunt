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
    class  Pac : Obj
    {
        public int score =0;
        private Boolean alive;
        private int[] colliSide = new int[] {0,0,0,0} ; 


        public Pac(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
            float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            : base(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {
            this.alive = true;
            

        }

        public void Move()
        {
            this.lastPos = this.Position;
            KeyboardState ks = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            float x = this.Position.X;
            float y = this.Position.Y;

            if (ks.IsKeyDown(Keys.Left))
            {
                this.Rotation = (float)(Math.PI);
                if (x > 20)
                {
                    direction = new Vector2(-1, 0);
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                this.Rotation = 0;
                if (x < 534)
                {
                    direction = new Vector2(1, 0);
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                this.Rotation = (float)(-0.5 * Math.PI);
                if (y > 20)
                {
                    direction = new Vector2(0, -1);
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                this.Rotation = (float)(0.5 * Math.PI);
                if (y < 686)
                {
                    direction = new Vector2(0, 1);
                }
            }


            if (this.isAlive())
            {
                Position += direction * 3;
            }
            
        }
        public void Move2()
        {
            this.lastPos = this.Position;
            KeyboardState ks = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            float x = this.Position.X;
            float y = this.Position.Y;

            if (ks.IsKeyDown(Keys.A))
            {
                this.Rotation = (float)(Math.PI);
                if (x > 20)
                {
                    direction = new Vector2(-1, 0);
                }
            }
            if (ks.IsKeyDown(Keys.D))
            {
                this.Rotation = 0;
                if (x < 534)
                {
                    direction = new Vector2(1, 0);
                }
            }
            if (ks.IsKeyDown(Keys.W))
            {
                this.Rotation = (float)(-0.5 * Math.PI);
                if (y > 20)
                {
                    direction = new Vector2(0, -1);
                }
            }
            if (ks.IsKeyDown(Keys.S))
            {
                this.Rotation = (float)(0.5 * Math.PI);
                if (y < 686)
                {
                    direction = new Vector2(0, 1);
                }
            }


            if (this.isAlive())
            {
                Position += direction * 3;
            }

        }
        public int distance(Obj o)
        {
            int x = (int) Math.Abs(o.Position.X - this.Position.X);
            int y = (int)Math.Abs(o.Position.Y - this.Position.Y);

            int distance = (int)Math.Sqrt(x * x + y * y);
            return distance;
        }

        public void collision(Ghost gogo)
        {
            //checks if player pac was caught by a ghost
            if( this.distance(gogo) < 35)
            {
                //death by a ghost reduces score by 500 (counts towards victory result)
                this.alive = false;
                
            }
            //else
            //{
             //   this.alive = true;
            //}
            
        }

        public void collision(orbsofpower orb, Obj score)
            //checks if pac touched orb
        {
            if (this.distance(orb) < 20)
            {
                //increases score for orb collect, increases the spawn number (for total orbs spawned in game)
                orb.status = false;
                this.score += 100;
                orb.spawnnum++;
                //places 100 score pop up at the location of the orb 
                score.Position = orb.Position;
                //activates score pop up and saves first position (where the orb was) for distance calculation as to how far it goes up
                score.active = true;
                score.lastPos = orb.Position;
            }
           

        }



        public void teleport()
        //teleports pacman when he hits on of the two teleport edges in the map (working)
        {
            if (this.Position.X <= 28)
            {
                if(this.Position.Y>= 325 && this.Position.Y <= 378)
                {
                    this.Position = new Vector2(530, 351);
                }
            }

            if (this.Position.X >= 533)
            {
                if (this.Position.Y >= 325 && this.Position.Y <= 378)
                {
                    this.Position = new Vector2(29, 351);
                }
            }
            
        }

        public Boolean isAlive()
        //returns true if pac is alive, false if not
        {
            return this.alive;
        }

        public void drawDeath(int counter, SpriteBatch spriteBatch, Color color)
        {
            if (counter > 1)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death1"), color);
            }
            if (counter > 10)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death2"), color);
            }
            if (counter > 20)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death3"), color);
            }
            if (counter > 30)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death4"), color);
            }
            if (counter > 40)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death5"), color);
            }
            if (counter > 50)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death6"), color);
            }
            if (counter > 60)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death7"), color);
            }
            if (counter > 70)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death8"), color);
            }
            if (counter > 80)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death9"), color);
            }
            if (counter > 90)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death10"), color);
            }
            if (counter > 100)
            {
                this.DrawDeath(spriteBatch, Content.Load<Texture2D>("death11"), color);
            }
            
        }

    }
}
