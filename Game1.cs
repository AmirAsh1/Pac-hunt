#region using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace pacman
{
  

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static GraphicsDevice gd;
        SpriteBatch spriteBatch;
        Boolean gamestart = false;
        Boolean pause = false;
        Pac pac;
        Pac pac2;
        Ghost GC;
        Ghost gogo;
        Ghost bogo;
        Obj mapp;
        int counter = 0;
        int buffer = 0;
        Obj gameover;
        Obj pauseScreen;
        Obj startScreen;
        orbsofpower orb;
        Obj scorePic;
        Obj scorePic2;
        #region wall
        Wall w1;
        Wall w2;
        Wall w3;
        Wall w4;
        Wall w5;
        Wall w6;
        Wall w7;
        Wall w8;
        Wall w9;
        Wall w10;
        Wall w11;
        Wall w12;
        Wall w13;
        Wall w14;
        Wall w15;
        Wall w16;
        Wall w17;
        Wall w18;
        Wall w19;
        Wall w20;
        Wall w21;
        Wall w22;
        Wall w23;
        Wall w24;
        Wall w25;
        Wall w26;
        Wall w27;
        Wall w28;
        Wall w29;
        Wall w30;
        Wall w31;
        Wall w32;
        Wall w33;
        Wall w34;
        Wall w35;
        Wall w36;
        Wall w37;
        Wall w38;
        Wall w39;
        Wall w40;
        Wall w41;
        Wall w42;
        Wall w43;
        Wall w44;
        Wall w45;
        Wall w46;
        Wall w47;
        Wall w48;
        Wall w49;
        Wall w50;
        Wall w51;
        Wall w52;
        Wall w53;
        Wall w54;
        Wall w55;
        Wall w56;
        Wall w57;
        List<Wall> wallList = new List<Wall>();

        #endregion
        Vector2 Loc1;
        Vector2 Loc2;
        Vector2 Loc3;
        Vector2 Loc4;
        Vector2 Loc5;
        Vector2 Loc6;
        Vector2 Loc7;
        Vector2 Loc8;
        Vector2 Loc9;
        Vector2 Loc10;
        Vector2 Loc11;

        List<Vector2> orbLocs = new List<Vector2>();


        Vector2 pos = new Vector2(0, 0);


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 752;
            graphics.PreferredBackBufferWidth = 554;
            graphics.ApplyChanges();
            IsMouseVisible = true;



           base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mapp = new Obj(Content.Load<Texture2D>("map-no points"), new Vector2(0), null, Color.White,
                0, new Vector2(0,0), new Vector2(1f), SpriteEffects.None, 0);

            gameover = new Obj(Content.Load<Texture2D>("gameover"), new Vector2(200), null, Color.White,
                0, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0);

            pauseScreen = new Obj(Content.Load<Texture2D>("pause"), new Vector2(0,200), null, Color.White,
               0, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0);

            startScreen = new Obj(Content.Load<Texture2D>("startscreen"), new Vector2(0), null, Color.White,
               0, new Vector2(0, 0), new Vector2(1f), SpriteEffects.None, 0);

            pac = new Pac(Content.Load<Texture2D>("pac2"), new Vector2(281,539), null, Color.White,
                0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);


            pac2 = new Pac(Content.Load<Texture2D>("pac2"), new Vector2(281, 139), null, Color.Red,
                0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            GC = new Ghost(Content.Load<Texture2D>("ghostyR"), new Vector2(284, 343), null, Color.Aqua,
               0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            //pac = new Pac(Content.Load<Texture2D>("pac2"), new Vector2(200), null, Color.White,
            //0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            gogo = new Ghost(Content.Load<Texture2D>("ghostyR"), new Vector2(284,343), null, Color.White,
                0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            // bogo = new Ghost(Content.Load<Texture2D>("ghostyR"), new Vector2(284, 333), null, Color.Green,
            //     0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);
            //510, 138

            bogo = new Ghost(Content.Load<Texture2D>("ghostyR"), new Vector2(284, 343), null, Color.Green,
                 0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            orb = new orbsofpower(Content.Load<Texture2D>("orbs"), new Vector2(200), null, Color.White,
               0, new Vector2(14, 14), new Vector2(1f), SpriteEffects.None, 0);

            scorePic = new Obj(Content.Load<Texture2D>("100score"), new Vector2(200,200), null, Color.Yellow,
               0, new Vector2(8, 5), new Vector2(1f), SpriteEffects.None, 0);

            scorePic2 = new Obj(Content.Load<Texture2D>("100score"), new Vector2(200, 200), null, Color.Red,
               0, new Vector2(8, 5), new Vector2(1f), SpriteEffects.None, 0);

            #region walls
            w1 = new Wall(new Vector2(0,0), 554, 30);
            w2 = new Wall(new Vector2(0,0), 36, 255);
            w3 = new Wall(new Vector2(254, 15), 46, 121);
            w4 = new Wall(new Vector2(44, 40), 95, 97);
            w5 = new Wall(new Vector2(151, 40), 95, 97);
            w6 = new Wall(new Vector2(309, 40), 95, 97);
            w7 = new Wall(new Vector2(416, 40), 97, 97);
            w8 = new Wall(new Vector2(519, 0), 20, 254);
            w9 = new Wall(new Vector2(44, 148), 95, 67);
            w10 = new Wall(new Vector2(150, 148), 43, 199);
            w11 = new Wall(new Vector2(191, 225), 53, 44);    //            w11 = new Wall(new Vector2(191, 225), 53, 45);

            w12 = new Wall(new Vector2(206, 148), 141, 68);
            w13 = new Wall(new Vector2(255, 200), 44, 69);
            w14 = new Wall(new Vector2(312, 225), 78, 45);
            w15 = new Wall(new Vector2(361, 148), 43, 200);
            w16 = new Wall(new Vector2(416, 148), 97, 67);
            w17 = new Wall(new Vector2(19, 228), 110, 40);
            w18 = new Wall(new Vector2(100, 228), 40, 111);   //            w18 = new Wall(new Vector2(100, 228), 37, 111);
            w19 = new Wall(new Vector2(9, 320), 123, 27);
            w20 = new Wall(new Vector2(416, 228), 124, 43);
            w21 = new Wall(new Vector2(416, 228), 37, 111);
            w22 = new Wall(new Vector2(416, 320), 123, 27);
            w23 = new Wall(new Vector2(9, 359), 131, 41);
            w24 = new Wall(new Vector2(100, 359), 40, 120);   //            w24 = new Wall(new Vector2(100, 359), 37, 111);
            w25 = new Wall(new Vector2(9, 438), 131, 41);
            w26 = new Wall(new Vector2(150, 359), 43, 120);
            w27 = new Wall(new Vector2(361, 359), 43, 120);
            w28 = new Wall(new Vector2(416, 359), 123, 41);
            w29 = new Wall(new Vector2(416, 359), 42, 120);
            w30 = new Wall(new Vector2(416, 438), 123, 41);
            w31 = new Wall(new Vector2(206, 411), 141, 68);
            w32 = new Wall(new Vector2(255, 464), 43, 69);
            w33 = new Wall(new Vector2(0, 438), 36, 255);
            w34 = new Wall(new Vector2(0, 544), 88, 68);
            w35 = new Wall(new Vector2(50, 490), 90, 43);
            w36 = new Wall(new Vector2(97, 490), 43, 121);
            w37 = new Wall(new Vector2(150, 490), 89, 43);     //           not og dk what for w37 = new Wall(new Vector2(150, 490), 89, 41);

            w38 = new Wall(new Vector2(312, 490), 92, 43);
            w39 = new Wall(new Vector2(416, 490), 89, 43);
            w40 = new Wall(new Vector2(150, 544), 43, 115);
            w41 = new Wall(new Vector2(206, 544), 142, 68);
            w42 = new Wall(new Vector2(361, 544), 43, 115);
            w43 = new Wall(new Vector2(416, 490), 42, 122);
            w44 = new Wall(new Vector2(466, 544), 88, 68);
            w45 = new Wall(new Vector2(50, 620), 192 , 45);
            w46 = new Wall(new Vector2(255, 597), 44, 68);
            w47 = new Wall(new Vector2(312, 620), 195, 45);
            w48 = new Wall(new Vector2(519, 438), 20, 254);
            w49 = new Wall(new Vector2(0, 674), 554, 30);
            w50 = new Wall(new Vector2(205, 280), 60, 40);
            w51 = new Wall(new Vector2(288, 280), 60, 40);
            w52 = new Wall(new Vector2(205, 280), 40, 120);
            w53 = new Wall(new Vector2(311, 280), 40, 120);
            w54 = new Wall(new Vector2(205, 359), 120, 41);

            w56 = new Wall(new Vector2(0, 320), 20, 100);
            w57 = new Wall(new Vector2(534, 320), 10, 100);


            //List<Wall> wallList = new List<Wall>();
            wallList.Add(w1);
            wallList.Add(w2);
            wallList.Add(w3);
            wallList.Add(w4);
            wallList.Add(w5);
            wallList.Add(w6);
            wallList.Add(w7);
            wallList.Add(w8);
            wallList.Add(w9);
            wallList.Add(w10);
            wallList.Add(w11);
            wallList.Add(w12);
            wallList.Add(w13);
            wallList.Add(w14);
            wallList.Add(w15);
            wallList.Add(w16);
            wallList.Add(w17);
            wallList.Add(w18);
            wallList.Add(w19);
            wallList.Add(w20);
            wallList.Add(w21);
            wallList.Add(w22);
            wallList.Add(w23);
            wallList.Add(w24);
            wallList.Add(w25);
            wallList.Add(w26);
            wallList.Add(w27);
            wallList.Add(w28);
            wallList.Add(w29);
            wallList.Add(w30);
            wallList.Add(w31);
            wallList.Add(w32);
            wallList.Add(w33);
            wallList.Add(w34);
            wallList.Add(w35);
            wallList.Add(w36);
            wallList.Add(w37);
            wallList.Add(w38);
            wallList.Add(w39);
            wallList.Add(w40);
            wallList.Add(w41);
            wallList.Add(w42);
            wallList.Add(w43);
            wallList.Add(w44);
            wallList.Add(w45);
            wallList.Add(w46);
            wallList.Add(w47);
            wallList.Add(w48);
            wallList.Add(w49);
            wallList.Add(w50);
            wallList.Add(w51);
            wallList.Add(w52);
            wallList.Add(w53);
            wallList.Add(w54);

            wallList.Add(w56);
            wallList.Add(w57);


            //Wall w5 = new Wall(new Vector2(165, 56), 67, 67);
            //Wall w6 = new Wall(new Vector2(323, 56), 67, 67);
            //Wall w7 = new Wall(new Vector2(429, 56), 67, 67);
            //Wall w8 = new Wall(new Vector2(533, 0), 20, 254);
            //Wall w9 = new Wall(new Vector2(60,163), 95,40);




            #endregion

            Loc1 = new Vector2(38, 91);
            Loc2 = new Vector2(144, 87);
            Loc3 = new Vector2(277, 142);
            Loc4 = new Vector2(408, 87);
            Loc5 = new Vector2(514, 87);
            Loc6 = new Vector2(40, 534);
            Loc7 = new Vector2(141, 482);
            Loc8 = new Vector2(272, 533);
            Loc9 = new Vector2(411, 483);
            Loc10 = new Vector2(511, 540);
            Loc11 = new Vector2(273, 668);

            orbLocs.Add(Loc1);
            orbLocs.Add(Loc2);
            orbLocs.Add(Loc3);
            orbLocs.Add(Loc4);
            orbLocs.Add(Loc5);
            orbLocs.Add(Loc6);
            orbLocs.Add(Loc7);
            orbLocs.Add(Loc8);
            orbLocs.Add(Loc9);
            orbLocs.Add(Loc10);
            orbLocs.Add(Loc11);


            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {   
                    gamestart = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P) )
            {
                    pause = true;

            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                pause = false;
            }

            //cdir = 3 means cross road that goes down
            gogo.isAtCrossroad(350, 359,135,149, 3);
            gogo.isAtCrossroad(194, 203, 135, 149, 3);
            gogo.isAtCrossroad(194, 203, 533, 544, 3);
            gogo.isAtCrossroad(350, 359, 531, 545, 3);
            gogo.isAtCrossroad(142, 149,27,40, 3);
            gogo.isAtCrossroad(407, 412, 27, 39, 3);

            //cdir = 1 means cross road that goes up
            gogo.isAtCrossroad(245, 254, 268, 278, 1);
            gogo.isAtCrossroad(302, 311, 267, 281, 1);       //the only one that isn't 9 x diffrence might need fix
            gogo.isAtCrossroad(245, 254, 663, 677, 1);
            gogo.isAtCrossroad(302, 311, 663, 677, 1);
            gogo.isAtCrossroad(89, 95, 609, 623, 1);
            gogo.isAtCrossroad(461, 464, 609, 623, 1);

            //cdir = 2 means cross road that goes right
            gogo.isAtCrossroad(141, 150,533,545, 2);
            gogo.isAtCrossroad(406, 416, 214, 228, 2);  //gogo.isAtCrossroad(404, 416, 214, 226, 2);   407 413 217 226

            //cdir = 4 means cross road that goes left
            gogo.isAtCrossroad(407, 413, 533, 544, 4);
            gogo.isAtCrossroad(140, 148, 214, 228, 4);


            //cdir means cross road that goes left and right
           
            
            //1
            if (pac.Position.X > gogo.Position.X)
            {
                gogo.isAtCrossroad(137, 152, 137, 148, 2);
            }

            if (pac.Position.X < gogo.Position.X)
            {
                gogo.isAtCrossroad(137, 152, 137, 148, 4);
            }


            //2
            if (pac.Position.X > gogo.Position.X)
            {
                gogo.isAtCrossroad(402, 416, 137, 148, 2);
            }

            if (pac.Position.X < gogo.Position.X)
            {
                gogo.isAtCrossroad(402, 416, 137, 148, 4);
            }

            //cdir means cross road that goes up and down

            //1
            if (pac.Position.Y > gogo.Position.Y)
            {
                gogo.isAtCrossroad(140, 150,477,491, 3);
            }

            if (pac.Position.Y < gogo.Position.Y)
            {
                gogo.isAtCrossroad(140, 150,477,491, 1);
            }

            //2
            if (pac.Position.Y > gogo.Position.Y)
            {
                gogo.isAtCrossroad(407, 412, 477, 491, 3);
            }

            if (pac.Position.Y < gogo.Position.Y)
            {
                gogo.isAtCrossroad(407, 412, 477, 491, 1);
            }

            //            gogo.isAtCrossroad(350, 359,139,145);
            //            gogo.isAtCrossroad(194, 203,139,145);
            //            gogo.isAtCrossroad(194, 203,535,541);
            //            gogo.isAtCrossroad(350, 359,535,541);
            //            gogo.isAtCrossroad(140, 149,31,37);
            //            gogo.isAtCrossroad(245, 254,271,277);
            //            gogo.isAtCrossroad(299, 311,271,277);
            //            gogo.isAtCrossroad(245, 254,667,673);
            //            gogo.isAtCrossroad(299, 311,667,673);
            //            gogo.isAtCrossroad(143, 149,535,541);
            //            gogo.isAtCrossroad(89, 95,613,619);
            //            gogo.isAtCrossroad(407, 413,535,541);
            //            gogo.isAtCrossroad(140, 149,217,226);
            //            gogo.isAtCrossroad(461, 464,613,619);
            //            gogo.isAtCrossroad(407, 413,217,223);
            //            gogo.isAtCrossroad(140, 149,139,145);
            //            gogo.isAtCrossroad(407, 413,139,145);
            //            gogo.isAtCrossroad(143, 149,481,487);
            //            gogo.isAtCrossroad(407, 413,481,487);
            //            gogo.isAtCrossroad(140, 149,31,37);
            //            gogo.isAtCrossroad(407, 413,31,37);
            //cdir = 3 means cross road that goes down
            bogo.isAtCrossroad(350, 359, 135, 149, 3);
            bogo.isAtCrossroad(194, 203, 135, 147, 3);
            bogo.isAtCrossroad(194, 203, 533, 544, 3);
            bogo.isAtCrossroad(350, 359, 531, 545, 3);
            bogo.isAtCrossroad(142, 149, 27, 40, 3);
            bogo.isAtCrossroad(407, 412, 27, 39, 3);

            //cdir = 1 means cross road that goes up
            bogo.isAtCrossroad(245, 254, 268, 278, 1);
            bogo.isAtCrossroad(302, 311, 267, 281, 1);       //the only one that isn't 9 x diffrence might need fix
            bogo.isAtCrossroad(245, 254, 663, 677, 1);
            bogo.isAtCrossroad(302, 311, 663, 677, 1);
            bogo.isAtCrossroad(89, 95, 609, 623, 1);
            bogo.isAtCrossroad(461, 464, 609, 623, 1);

            //cdir = 2 means cross road that goes right
            bogo.isAtCrossroad(141, 150, 533, 545, 2);
            bogo.isAtCrossroad(406, 416, 214, 228, 2);  //gogo.isAtCrossroad(404, 416, 214, 226, 2);   407 413 217 226

            //cdir = 4 means cross road that goes left
            bogo.isAtCrossroad(407, 413, 533, 544, 4);
            bogo.isAtCrossroad(140, 148, 214, 228, 4);


            //cdir means cross road that goes left and right


            //1
            if (pac.Position.X > gogo.Position.X)
            {
                bogo.isAtCrossroad(137, 152, 137, 148, 2);
            }

            if (pac.Position.X < gogo.Position.X)
            {
                bogo.isAtCrossroad(137, 152, 137, 148, 4);
            }


            //2
            if (pac.Position.X > gogo.Position.X)
            {
                bogo.isAtCrossroad(402, 416, 137, 148, 2);
            }

            if (pac.Position.X < gogo.Position.X)
            {
                bogo.isAtCrossroad(402, 416, 137, 148, 4);
            }

            //cdir means cross road that goes up and down

            //1
            if (pac.Position.Y > gogo.Position.Y)
            {
                bogo.isAtCrossroad(140, 150, 477, 491, 3);
            }

            if (pac.Position.Y < gogo.Position.Y)
            {
                bogo.isAtCrossroad(140, 150, 477, 491, 1);
            }

            //2
            if (pac.Position.Y > gogo.Position.Y)
            {
                bogo.isAtCrossroad(407, 412, 477, 491, 3);
            }

            if (pac.Position.Y < gogo.Position.Y)
            {
                bogo.isAtCrossroad(407, 412, 477, 491, 1);
            }


            GC.printLoc();


            if (gamestart && !pause)
            {
                if (pac.isAlive())
                {
                    pac.Move();
                    pac2.Move2();
                    //GC.MoveAI(Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"), pac);
                    //gogo.Move(Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                    if (!gogo.atCrossroads)
                    {
                        gogo.moveGogo(pac, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"), wallList);
                    }
                    else
                    {
                        if (gogo.Cdir == 1)
                        {
                            gogo.moveAtCrossUp(pac, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (gogo.Cdir == 2)
                        {
                            gogo.moveAtCrossRight(pac, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (gogo.Cdir == 3)
                        {
                            gogo.moveAtCrossDown(pac, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (gogo.Cdir == 4)
                        {
                            gogo.moveAtCrossLeft(pac, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                    }
                    //bogo.moveGogo(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"), wallList);
                    if (!bogo.atCrossroads)
                    {
                        bogo.moveGogo(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"), wallList);
                    }
                    else
                    {
                        if (bogo.Cdir == 1)
                        {
                            bogo.moveAtCrossUp(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (bogo.Cdir == 2)
                        {
                            bogo.moveAtCrossRight(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (bogo.Cdir == 3)
                        {
                            bogo.moveAtCrossDown(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                        if (bogo.Cdir == 4)
                        {
                            bogo.moveAtCrossLeft(pac2, Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"));
                        }
                    }
                    //bogo.MoveAI(Content.Load<Texture2D>("ghostyL"), Content.Load<Texture2D>("ghostyR"), Content.Load<Texture2D>("ghostyUP"), Content.Load<Texture2D>("ghostyDOWN"), pac);
                }
                if (!orb.status)
                {
                    //respawns orb when it's eaten
                    Random rnd = new Random();
                    int num = rnd.Next(0, 11);  // creates a number between 1 and 11
                    orb.Position = orbLocs[num];
                    orb.status = true;
                }

                //pac.collision(gogo);
                //pac.collision(bogo);
                //pac2.collision(bogo);
              // pac2.collision(gogo);
                //pac.collision(GC);
               // pac2.collision(GC);

                if (!pac.isAlive() && buffer == 0)
                {             
                    //reduces score by 500 for death
                    pac.score = pac.score - 500;
                    buffer++;
                }
                if (!pac2.isAlive() && buffer == 0)
                {
                    //reduces score by 500 for death
                    pac2.score = pac.score - 500;
                    buffer++;
                }
                pac.teleport();
                pac2.teleport();
                foreach (var w in wallList)
                {
                    pac.collision(w);
                    pac2.collision(w);
                    gogo.collision(w);
                    bogo.collision(w);
                    GC.collision(w);
                }
                pac.collision(orb, scorePic);
                pac2.collision(orb, scorePic2);
                //new Vector2(197,142)|| gogo.Position == new Vector2(358, 145)


                if (scorePic.lastPos.Y - scorePic.Position.Y > 30)
                {
                    scorePic.active = false;
                }

                if (scorePic.active)
                {
                    scorePic.Position = new Vector2(scorePic.Position.X, scorePic.Position.Y - 1);
                }
                //
                if (scorePic2.lastPos.Y - scorePic2.Position.Y > 30)
                {
                    scorePic2.active = false;
                }

                if (scorePic2.active)
                {
                    scorePic2.Position = new Vector2(scorePic2.Position.X, scorePic2.Position.Y - 1);
                }
                // TODO: Add your update logic here
            }
                base.Update(gameTime);
            
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            mapp.Draw(spriteBatch);
            if (orb.status)
            {
                orb.Draw(spriteBatch);
            }
            
            gogo.Draw(spriteBatch);
            bogo.Draw(spriteBatch);
            GC.Draw(spriteBatch);

            if (!pac.isAlive())
            {
                if (counter > 1)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death1"), Color.White);
                }
                if (counter > 10)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death2"), Color.White);
                }
                if (counter > 20)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death3"), Color.White);
                }
                if (counter > 30)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death4"), Color.White);
                }
                if (counter > 40)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death5"), Color.White);
                }
                if (counter > 50)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death6"), Color.White);
                }
                if (counter > 60)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death7"), Color.White);
                }
                if (counter > 70)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death8"), Color.White);
                }
                if (counter > 80)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death9"), Color.White);
                }
                if (counter > 90)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death10"), Color.White);
                }
                if (counter > 100)
                {
                    pac.DrawDeath(spriteBatch, Content.Load<Texture2D>("death11"), Color.White);
                }

                gameover.DrawGameOver(spriteBatch);
                if (pac.score < pac2.score)
                {
                    spriteBatch.DrawString(Content.Load<SpriteFont>("scoreFont"), "Player(2) Red wins!", new Vector2(190,450), Color.Red);
                }
                counter++;

            }
            else
            {
                if (pac.Position != pac.lastPos)
                {
                    pac.Draw(spriteBatch, Content.Load<Texture2D>("pac1"), Content.Load<Texture2D>("pac3"));

                }
                else
                {
                    pac.Draw(spriteBatch);

                }
            }



            if (!pac2.isAlive())
            {
                if (counter > 1)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death1"), Color.Red);
                }
                if (counter > 10)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death2"), Color.Red);
                }
                if (counter > 20)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death3"), Color.Red);
                }
                if (counter > 30)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death4"), Color.Red);
                }
                if (counter > 40)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death5"), Color.Red);
                }
                if (counter > 50)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death6"), Color.Red);
                }
                if (counter > 60)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death7"), Color.Red);
                }
                if (counter > 70)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death8"), Color.Red);
                }
                if (counter > 80)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death9"), Color.Red);
                }
                if (counter > 90)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death10"), Color.Red);
                }
                if (counter > 100)
                {
                    pac2.DrawDeath(spriteBatch, Content.Load<Texture2D>("death11"), Color.Red);
                }
                gameover.DrawGameOver(spriteBatch);
                
                counter++;
            }
            else
            {
                if (pac2.Position != pac2.lastPos)
                {
                    pac2.Draw(spriteBatch, Content.Load<Texture2D>("pac1"), Content.Load<Texture2D>("pac3"));

                }
                else
                {
                    pac2.Draw(spriteBatch);

                }
            }



            spriteBatch.DrawString(Content.Load<SpriteFont> ("scoreFont"), "P1 SCORE:"+pac.score.ToString(), new Vector2(10, 720), Color.Yellow);
            spriteBatch.DrawString(Content.Load<SpriteFont>("scoreFont"), "P2 SCORE:" + pac2.score.ToString(), new Vector2(350, 720), Color.Red);
            
            if (scorePic.active)
            {
                scorePic.Draw(spriteBatch);
            }
            if (scorePic2.active)
            {
                scorePic2.Draw(spriteBatch);
            }
            if (!pac.isAlive() || !pac2.isAlive())
            {
                gameover.DrawGameOver(spriteBatch);
                if (pac.score > pac2.score)
                {
                    spriteBatch.DrawString(Content.Load<SpriteFont>("scoreFont"), "Player(1) Yellow wins!", new Vector2(190, 450), Color.Yellow);
                }
                if (pac.score < pac2.score)
                {
                    spriteBatch.DrawString(Content.Load<SpriteFont>("scoreFont"), "Player(2) Red wins!", new Vector2(190, 450), Color.Red);
                }
            }
            if (pause)
            {
                pauseScreen.Draw(spriteBatch);
            }
            if (!gamestart)
            {
                startScreen.Draw(spriteBatch);
                //loading screen, press space bar button to begin
                //draw small overlay loading screen
            }
            spriteBatch.End();

            base.Draw(gameTime);
            
        }
    }
}
