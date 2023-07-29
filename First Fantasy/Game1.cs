using First_Fantasy.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Diagnostics;
using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Graphics;

namespace First_Fantasy
{
    public class Game1 : Game
    {
        private SpriteBatch spriteBatch;
		private ContentManager content;

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
			spriteBatch = new SpriteBatch(GraphicsDevice);
			content = new ContentManager(Content.ServiceProvider, Content.RootDirectory);

			// Setup the desktop
			desktop = new Desktop();

            //Setup party creator UI
            GUI_party_creator partyInit = new() {
                desktop = desktop,
                contentManager = content,
                startGame = Content.Load<SoundEffect>("Sounds/Unique/venture_forth"),
                classSpriteOne = Content.Load<Texture2D>("Sprites/Classes/astral_weaver"),
				classSpriteTwo = Content.Load<Texture2D>("Sprites/Classes/verdant_sentinal"),
				classSpriteThree = Content.Load<Texture2D>("Sprites/Classes/steam_enforcer"),
				classSpriteFour = Content.Load<Texture2D>("Sprites/Classes/echoblade"),
				classSpriteFive = Content.Load<Texture2D>("Sprites/Classes/charlatan")
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

            spriteBatch.Begin();
            //Draw here
            //sprite.Draw(spriteBatch);

            spriteBatch.End();


			base.Draw(gameTime);
        }
    }
}