using First_Fantasy.Classes;
using Microsoft.Xna.Framework;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Diagnostics;

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
            base.LoadContent();

			MyraEnvironment.Game = this;

			// Setup the desktop
			desktop = new Desktop();

            //Setup party creator UI
			partyInit = new GUI_party_creator();
			partyInit.desktop = desktop;

            // Add party creator UI to the screen
			desktop.Widgets.Add(partyInit.mainGrid);

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
			GraphicsDevice.Clear(Color.CornflowerBlue);
			desktop.Render();


			base.Draw(gameTime);
        }
    }
}