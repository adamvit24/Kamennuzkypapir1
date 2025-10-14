using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Čtvereček___kolize_se_zdmi
{
    public class Wall
    {
        public Rectangle Bounds;
        private Texture2D texture;

        public Wall(GraphicsDevice graphics, Rectangle rect)
        {
            Bounds = rect;
            texture = new Texture2D(graphics, 1, 1);
            texture.SetData(new[] { Color.LimeGreen });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, Color.DarkSlateGray);
        }
    }
}