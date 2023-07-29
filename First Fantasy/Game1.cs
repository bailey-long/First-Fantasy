using First_Fantasy.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
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
			MyraEnvironment.Game = this;

			// Setup the desktop
			desktop = new Desktop();

            //Setup party creator UI
			GUI_party_creator partyInit = new() {
				desktop = desktop,
                startGame = Content.Load<SoundEffect>("Sounds/Unique/venture_forth"),
			};

            Song menuTheme = Content.Load<Song>("Sounds/Unique/beggining");
			MediaPlayer.Play(menuTheme);
			MediaPlayer.IsRepeating = true;

			// Add UI to the screen
			desktop.Widgets.Add(partyInit.mainGrid);
		}

        protected override void Update(GameTime gameTime)
        {
            // Gets keyboard state; detects input
            Key.GetState();

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			// Draw the GUI
			GraphicsDevice.Clear(Color.CornflowerBlue);
			desktop.Render();


			base.Draw(gameTime);
        }
    }
}