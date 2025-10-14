using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čtvereček___kolize_se_zdmi
{
    public class Player
{
    public Vector2 Position;
    public int Size = 50;
    public float Speed = 200f; // pixely za sekundu
    private Texture2D texture;

    public Player(GraphicsDevice graphics)
    {
        // vytvoříme jednoduchou texturu 1x1 a vybarvíme ji bíle
        texture = new Texture2D(graphics, 1, 1);
        texture.SetData(new[] { Color.White });

        // počáteční pozice
        Position = new Vector2(100, 100);
    }

    public void Update(GameTime gameTime, Rectangle bounds)
    {
        var keyboard = Keyboard.GetState();
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        Vector2 direction = Vector2.Zero;

        if (keyboard.IsKeyDown(Keys.W)) direction.Y -= 1;
        if (keyboard.IsKeyDown(Keys.S)) direction.Y += 1;
        if (keyboard.IsKeyDown(Keys.A)) direction.X -= 1;
        if (keyboard.IsKeyDown(Keys.D)) direction.X += 1;

        if (direction != Vector2.Zero)
            direction.Normalize();

        Position += direction * Speed * delta;

        // kolize s hranami okna
        if (Position.X < 0) Position.X = 0;
        if (Position.Y < 0) Position.Y = 0;
        if (Position.X + Size > bounds.Width) Position.X = bounds.Width - Size;
        if (Position.Y + Size > bounds.Height) Position.Y = bounds.Height - Size;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, Size, Size), Color.RoyalBlue);
    }
}
}