using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Čtvereček___kolize_se_zdmi
{
    public class Player
    {
        public Vector2 Position;
        public int Size = 40;
        public float Speed = 200f;
        private Texture2D texture;

        public Player(GraphicsDevice graphics)
        {
            texture = new Texture2D(graphics, 1, 1);
            texture.SetData(new[] { Color.White });

            Position = new Vector2(60, 60);
        }

        public void Update(GameTime gameTime, Rectangle bounds, List<Wall> walls)
        {
            var keyboard = Keyboard.GetState();
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 move = Vector2.Zero;
            if (keyboard.IsKeyDown(Keys.W)) move.Y -= 1;
            if (keyboard.IsKeyDown(Keys.S)) move.Y += 1;
            if (keyboard.IsKeyDown(Keys.A)) move.X -= 1;
            if (keyboard.IsKeyDown(Keys.D)) move.X += 1;

            if (move != Vector2.Zero)
                move.Normalize();

            Vector2 newPos = Position + move * Speed * delta;
            Rectangle newRect = new Rectangle((int)newPos.X, (int)newPos.Y, Size, Size);

            // kolize se zdmi
            bool collide = false;
            foreach (var wall in walls)
            {
                if (newRect.Intersects(wall.Bounds))
                {
                    collide = true;
                    break;
                }
            }

            // pokud nekoliduje, tak posuň
            if (!collide)
                Position = newPos;

            // kolize s okraji okna
            if (Position.X < 0) Position.X = 0;
            if (Position.Y < 0) Position.Y = 0;
            if (Position.X + Size > bounds.Width) Position.X = bounds.Width - Size;
            if (Position.Y + Size > bounds.Height) Position.Y = bounds.Height - Size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, Size, Size), Color.Red);
        }
    }
}