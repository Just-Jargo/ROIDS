using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ROIDS
{
    //Allows for other classes to use.
    public class Sprite
    {
        public Texture2D spriteTxr;
        public Vector2 spritePos, spriteVelocity, spriteOrigin;
        public float spriteRadius, spriteRotation;
        public bool canCollide;
        public Rectangle spriteDrawRect, spriteSourceRect;

        //Draws in sprites every frame currently
        //Also can be used to set up a spritesheet


        public Sprite(Texture2D newSpriteTxr, Vector2 startPos)
        { 
        
            spriteTxr = newSpriteTxr;
            spritePos = startPos;

            //Auto sets the speed of stuff to zero
            spriteVelocity = Vector2.Zero;
            spriteRadius =  spriteTxr.Width / 4.0f;
            spriteRotation = 0.0f;

            canCollide = true;
            spriteSourceRect = spriteTxr.Bounds;
            spriteOrigin = new Vector2(spriteTxr.Width  /2.0f, spriteTxr.Height / 2.0f);


        }

        public void Update(GameTime gameTime)
        {
            spritePos += spriteVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteDrawRect = new Rectangle((int)spritePos.X, (int)spritePos.Y, spriteTxr.Width, spriteTxr.Height);

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTxr, spriteDrawRect, spriteSourceRect, Color.White, spriteRotation, 
                spriteOrigin, SpriteEffects.None, 0.0f);
        }

    }
}
