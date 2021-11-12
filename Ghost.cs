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
    class Ghost : Obj
    {
        int dirA { get; set; }

        public Ghost(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
            float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            : base(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth)
        {

            this.dirA = 1;

        }

        public void Move(Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            
            this.lastPos = this.Position;
            KeyboardState ks = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            float x = this.Position.X;
            float y = this.Position.Y;

            if (this.wasImpact)
            {
                Random rnd = new Random();
                int dir = rnd.Next(1, 5);  // creates a number between 1 and 4
                if (dir == this.wallCol)
                {
                    this.dirA = dir + 1;

                }
                else
                {
                    this.dirA = dir;
                }
                this.wasImpact = false;
            }
           
            #region AI
            if (dirA % 4 == 1)
            {
                this.texture = textureUP;
                if (y > 20)
                {
                    direction = new Vector2(0, -1);
                }
            }
            if (dirA % 4 == 2)
            {
                this.texture = textureR;
                if (x < 534)
                {
                    direction = new Vector2(1, 0);
                }
            }
            if (dirA % 4 == 3)
            {
                this.texture = textureDOWN;
                if (y < 686)
                {
                    direction = new Vector2(0, 1);
                }
            }
            if (dirA % 4 == 0)
            {
                this.texture = textureL;
                if (x > 20)
                {
                    direction = new Vector2(-1, 0);
                }
            }
            #endregion
            Position += direction * 2;

            

        }

        public void movecommit(Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {

                this.lastPos = this.Position;
                KeyboardState ks = Keyboard.GetState();
                Vector2 direction = Vector2.Zero;
                float x = this.Position.X;
                float y = this.Position.Y;

                if (this.wasImpact)
                {
                    Random rnd = new Random();
                    int dir = rnd.Next(1, 5);  // creates a number between 1 and 4
                    if (dir == this.wallCol)
                    {
                        this.dirA = dir + 1;

                    }
                    else
                    {
                        this.dirA = dir;
                    }
                    this.wasImpact = false;
                }
                #region control
                if (ks.IsKeyDown(Keys.A))
                {
                    this.texture = textureL;
                    if (x > 20)
                    {
                        direction = new Vector2(-1, 0);
                    }
                }
                if (ks.IsKeyDown(Keys.D))
                {
                    this.texture = textureR;
                    if (x < 534)
                    {
                        direction = new Vector2(1, 0);
                    }
                }
                if (ks.IsKeyDown(Keys.W))
                {
                    this.texture = textureUP;
                    if (y > 20)
                    {
                        direction = new Vector2(0, -1);
                    }
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    this.texture = textureDOWN;
                    if (y < 686)
                    {
                        direction = new Vector2(0, 1);
                    }
                }
                else
                {
                    #endregion

                    #region AI
                    if (dirA % 4 == 1)
                    {
                        this.texture = textureUP;
                        if (y > 20)
                        {
                            direction = new Vector2(0, -1);
                        }
                    }
                    if (dirA % 4 == 2)
                    {
                        this.texture = textureR;
                        if (x < 534)
                        {
                            direction = new Vector2(1, 0);
                        }
                    }
                    if (dirA % 4 == 3)
                    {
                        this.texture = textureDOWN;
                        if (y < 686)
                        {
                            direction = new Vector2(0, 1);
                        }
                    }
                    if (dirA % 4 == 0)
                    {
                        this.texture = textureL;
                        if (x > 20)
                        {
                            direction = new Vector2(-1, 0);
                        }
                    }
                    #endregion

                }

                Position += direction * 5;



            

        }

        public void moveGogo(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN, List<Wall> wallList)
        {
            this.lastPos = this.Position;
            KeyboardState ks = Keyboard.GetState();
            
            float x = this.Position.X;
            float y = this.Position.Y;
            float xp = p.Position.X;
            float yp = p.Position.Y;
            if (this.wasImpact)
            {
                this.wasImpact = false;
                if (this.dirAI == new Vector2(0, -1)|| this.dirAI == new Vector2(0, 1))
                    //ghost was moving along y axis and hit a wall so it should turn left or right (towards pac)
                {
                    if (xp >x)
                    {
                        this.dirAI = new Vector2(1, 0);
                        Position += this.dirAI * 11;
                        foreach (var w in wallList)
                        {
                            this.collision(w);
                        }
                        if (this.wasImpact)
                        {
                            this.wasImpact = false;
                            this.dirAI = new Vector2(-1, 0);
                        }
                    }
                    else
                    {
                        this.dirAI = new Vector2(-1, 0);
                        Position += this.dirAI * 11;
                        foreach (var w in wallList)
                        {
                            this.collision(w);
                        }
                        if (wasImpact)
                        {
                            this.wasImpact = false;
                            this.dirAI = new Vector2(1, 0);
                        }
                    }
                }
                else
                {
                    if (this.dirAI == new Vector2(1, 0)|| this.dirAI == new Vector2(-1, 0))
                        //ghost was moving an x axis and hit a wall now must turn up or down (towards pac)
                    {
                        if (yp > y)
                            //if pac is below ghost then it goes down
                        {
                            this.dirAI = new Vector2(0, 1);
                            Position += this.dirAI * 11;
                            foreach (var w in wallList)
                            {
                                this.collision(w);
                            }
                            if (this.wasImpact)
                            {
                                this.wasImpact = false;
                                this.dirAI = new Vector2(0, -1);
                            }
                        }
                        //if pac is not below ghost (above) ghost goes up
                        else
                        {
                            this.dirAI = new Vector2(0, -1);
                            Position += this.dirAI * 11;
                            foreach (var w in wallList)
                            {
                                this.collision(w);
                            }
                            if (this.wasImpact)
                            {
                                this.wasImpact = false;
                                this.dirAI = new Vector2(0, 1);
                            }
                        }
                    }
                }
                this.wasImpact = false;
            }
           
            Position += this.dirAI * 2;

            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;
                
            }
            #endregion


        }

        public void MoveAI(Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN, Pac p)
        {

            this.lastPos = this.Position;
            KeyboardState ks = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            float x = this.Position.X;
            float y = this.Position.Y;

            if (wasImpact)
            {
                
               if (p.Position.Y > this.Position.Y)
                {
                    this.dirA = 3;
                    if (this.wallCol == this.dirA)
                    {
                        if (p.Position.X < this.Position.X)
                        {
                            this.dirA++;
                        }
                        if (p.Position.X > this.Position.X)
                        {
                            this.dirA--;
                        }
                    }
                }
               else if (p.Position.Y < this.Position.Y)
                {
                    this.dirA = 1;
                    if (this.wallCol == this.dirA)
                    {
                        if (p.Position.X < this.Position.X)
                        {
                            this.dirA--;
                        }
                        if (p.Position.X > this.Position.X)
                        {
                            this.dirA++;
                        }
                    }
                }
               else if (p.Position.X > this.Position.X)
                {
                    this.dirA = 2;
                    if (this.wallCol == this.dirA)
                    //once movment hits wall
                    {
                        if (p.Position.Y < this.Position.Y)
                        {
                            this.dirA--;      //turns left if pac is to its left
                        }
                        if (p.Position.Y > this.Position.Y)
                        {
                            this.dirA++;   //turns right if pac is to it's right
                        }
                    }
                }
               else if (p.Position.X < this.Position.X)
                {
                    this.dirA = 4;
                    if (this.wallCol == this.dirA)
                    {
                        if (p.Position.Y < this.Position.Y)
                        {
                            this.dirA++; //turns right if pac is to it's right
                        }
                        if (p.Position.Y > this.Position.Y)
                        {
                            this.dirA--; //turns left if pac is to its left
                        }
                    }
                }
                this.wasImpact = false;
            }
            
            if (dirA % 4 == 1)
            {
                this.texture = textureUP;
                if (y > 20)
                {
                    direction = new Vector2(0, -1);
                }
            }
            if (dirA % 4 == 2)
            {
                this.texture = textureR;
                if (x < 534)
                {
                    direction = new Vector2(1, 0);
                }
            }
            if (dirA % 4 == 3)
            {
                this.texture = textureDOWN;
                if (y < 686)
                {
                    direction = new Vector2(0, 1);
                }
            }
            if (dirA % 4 == 0)
            {
                this.texture = textureL;
                if (x > 20)
                {
                    direction = new Vector2(-1, 0);
                }
            }

            Position += direction * 5;
            this.lastDir = this.dirA;

        }

        public void checkBar(int x, int y, int width, int length)
        {
            if(this.Position.X == x )
            {

            }
        }

        public void moveControl(Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            KeyboardState ks = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            this.lastPos = this.Position;
            if (ks.IsKeyDown(Keys.A))
            {
                this.texture = textureL;
                direction = new Vector2(-1, 0);
                
            }
            if (ks.IsKeyDown(Keys.D))
            {
                this.texture = textureR;
                
                    direction = new Vector2(1, 0);
                
            }
            if (ks.IsKeyDown(Keys.W))
            {
                this.texture = textureUP;
               
                    direction = new Vector2(0, -1);
                
            }
            if (ks.IsKeyDown(Keys.S))
            {
                this.texture = textureDOWN;
                
                    direction = new Vector2(0, 1);
                
            }

            Position += direction * 3;

        }

        public void isAtCrossroad(int botx, int topx, int boty, int topy, int cdir)
        {
            if(this.Position.X <topx && this.Position.X > botx)
            {
                if(this.Position.Y < topy && this.Position.Y >boty)
                {
                    this.atCrossroads = true;
                    Console.WriteLine("yesssss");
                    this.Cdir = cdir;
                }
                

            }
            
        }
        
        public void moveAtCrossDown(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            this.atCrossroads = false;
            Vector2 direction = Vector2.Zero;


           
            if (this.Position.Y < p.Position.Y -25 && this.dirAI != new Vector2(0, -1))
            {
                this.dirAI = new Vector2(0, 1);
                this.Position += this.dirAI * 5;
            }
            else
            {
                this.Position += this.dirAI * 2;

            }




            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;

            }
            #endregion

        }

        public void moveAtCrossUp(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            this.atCrossroads = false;
            Vector2 direction = Vector2.Zero;



            if (this.Position.Y > p.Position.Y + 25 && this.dirAI != new Vector2(0,1))
            {
                this.dirAI = new Vector2(0, -1);
                this.Position += this.dirAI * 5;
            }
            else
            {
                this.Position += this.dirAI * 2;

            }




            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;

            }
            #endregion

        }


        public void moveAtCrossRight(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            this.atCrossroads = false;
            Vector2 direction = Vector2.Zero;



            if (this.Position.X < p.Position.X - 50 && this.dirAI != new Vector2(-1, 0))
            {
                this.dirAI = new Vector2(1, 0);
                this.Position += this.dirAI * 5;
            }
            else
            {
                this.Position += this.dirAI * 2;

            }




            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;

            }
            #endregion

        }

        public void moveAtCrossLeft(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            this.atCrossroads = false;
            Vector2 direction = Vector2.Zero;



            if (this.Position.X > p.Position.X + 25 && this.dirAI != new Vector2(1, 0))
            {
                this.dirAI = new Vector2(-1, 0);
                this.Position += this.dirAI * 5;
            }
            else
            {
                this.Position += this.dirAI * 2;

            }




            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;

            }
            #endregion

        }

        public void moveAtCrossLR(Pac p, Texture2D textureL, Texture2D textureR, Texture2D textureUP, Texture2D textureDOWN)
        {
            this.atCrossroads = false;
            Vector2 direction = Vector2.Zero;

            if(this.dirAI == new Vector2 (0,1) || this.dirAI == new Vector2(0, -1))
            {
                if (this.Position.X > p.Position.X + 25 && Math.Abs(p.Position.Y - this.Position.Y) < 340)
                {
                    this.dirAI = new Vector2(-1, 0);
                    this.Position += this.dirAI * 5;
                }
                else
                {
                    if (this.Position.X < p.Position.X - 25 && Math.Abs(p.Position.Y - this.Position.Y) < 340)
                    {
                        this.dirAI = new Vector2(1, 0);
                        this.Position += this.dirAI * 5;
                    }
                    else
                    {
                        this.Position += this.dirAI * 2;

                    }
                }
                

            }

            




            #region texture
            if (dirAI == new Vector2(0, -1))
            {
                this.texture = textureUP;

            }
            if (dirAI == new Vector2(0, 1))
            {
                this.texture = textureDOWN;

            }
            if (dirAI == new Vector2(1, 0))
            {
                this.texture = textureR;

            }
            if (dirAI == new Vector2(-1, 0))
            {
                this.texture = textureL;

            }
            #endregion

        }

        public void printLoc()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.X))
            {
                Console.WriteLine(this.Position.X + ", " + this.Position.Y);
            }
        }
    }
}
