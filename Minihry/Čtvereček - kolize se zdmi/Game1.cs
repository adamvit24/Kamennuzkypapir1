using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Čtvereček___kolize_se_zdmi
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private List<Wall> _walls;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player = new Player(GraphicsDevice);

            // vytvoříme jednoduché bludiště
            _walls = new List<Wall>()
            {
                new Wall(GraphicsDevice, new Rectangle(150, 0, 20, 400)),
                new Wall(GraphicsDevice, new Rectangle(300, 200, 20, 400)),
                new Wall(GraphicsDevice, new Rectangle(450, 0, 20, 300)),
                new Wall(GraphicsDevice, new Rectangle(600, 150, 20, 450)),
                new Wall(GraphicsDevice, new Rectangle(0, 500, 800, 20))
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var bounds = new Rectangle(0, 0,
                _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);

            _player.Update(gameTime, bounds, _walls);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            // vykreslení zdí
            foreach (var wall in _walls)
                wall.Draw(_spriteBatch);

            // vykreslení hráče
            _player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}