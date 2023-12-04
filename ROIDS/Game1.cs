using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;


//CTRL + Double R 
namespace ROIDS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;



        Texture2D txrShip, txrAsteroids, txrParticle;

        string highscore, highScoreName, highscoreFile;
        int highScoreCount, currentScore;

        List<Sprite> spriteList = new List<Sprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            highscore = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ROIDS";
            highscoreFile = highscore + "\\highscore.sav";


            
            base.Initialize();

            LoadhighScore();

            highScoreCount = 99;
            highScoreName = "Dave";
            saveHighscore();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            txrShip = Content.Load<Texture2D>("SpriteShip");
            txrParticle = Content.Load<Texture2D>("SpriteParticle");
            txrAsteroids = Content.Load<Texture2D>("SpriteRocks");

            LoadhighScore();


        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentKeys = Keyboard.GetState();

            if (currentKeys.IsKeyDown(Keys.Space)) Exit();

            foreach(Sprite everySprite in spriteList) everySprite.Update(gameTime);
         

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSeaGreen);

            _spriteBatch.Begin();

            foreach (Sprite everySprite in spriteList) everySprite.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        //Void is the same as local in C#
        void saveHighscore()
        {
            //if the directory doesn't exist, then make it.
            if (!Directory.Exists(highscore)) Directory.CreateDirectory(highscore);
            File.WriteAllText(highscoreFile, highScoreName);
            File.AppendAllText(highscoreFile, "\n" + highScoreCount);
        }

        void LoadhighScore()
        {
            string[] fileStrings;

            if (File.Exists(highscoreFile))
            {
                fileStrings = File.ReadAllLines(highscoreFile);

                if (fileStrings.Length != 2)
                {
                    makeDefaultFile();
                }
                else
                {
                    if (fileStrings[0].Length > 3) highScoreName = fileStrings[0].Substring(0, 3);
                    else highScoreName = fileStrings[0];

                    if(highScoreName == "") highScoreName = "---"; 

                    if(int.TryParse(fileStrings[1], out highScoreCount)) highScoreCount = 0;
                }
            }
            else
            {
                makeDefaultFile();
            }

           
        }

        void makeDefaultFile()
        {
            highScoreName = "---";
            highScoreCount = 0;
            saveHighscore();

        }



    }

}