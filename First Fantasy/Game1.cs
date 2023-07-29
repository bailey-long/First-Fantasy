using First_Fantasy.Classes;
using Microsoft.Xna.Framework;
using Myra;
using Myra.Graphics2D.UI;
using System;

namespace First_Fantasy
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
		public Desktop desktop;
        GUI_party_creator partyInit;

		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
		}

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
		}

        protected override void LoadContent()
        {

			partyInit = new GUI_party_creator
			{
				partyGraphicsManager = graphics,
			};
            
            // Add to the desktop
            MyraEnvironment.Game = this;
			desktop = new Desktop();

			partyInit.LoadContent(desktop);
			partyInit.SubscribeEvents();

		}

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Key.GetState();

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw the Myra GUI
            MyraEnvironment.GraphicsDevice.Clear(Color.CornflowerBlue);
			desktop.Render();

            base.Draw(gameTime);
        }
    }
}