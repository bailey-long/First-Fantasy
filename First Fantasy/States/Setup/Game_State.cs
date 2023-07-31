using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First_Fantasy.Classes.Charcter_Classes;
using System.IO;

namespace First_Fantasy.States.Setup
{
    public abstract class Game_State : IGame_State
    {
		protected GraphicsDevice _graphicsDevice;

		public Game_State(GraphicsDevice graphicsDevice)
        {

			_graphicsDevice = graphicsDevice;
        }
        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
