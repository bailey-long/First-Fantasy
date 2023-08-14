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
using First_Fantasy.States;
using First_Fantasy.States.Setup;
using First_Fantasy.Classes.Charcter_Classes;

namespace First_Fantasy
{
	public class Game1 : Game
    {
        private SpriteBatch spriteBatch;
        private ContentManager content;

        public GraphicsDeviceManager graphics;
        public Desktop desktop;

        public Party party = new();

		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 380;
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

            //Setup game state manager
            Game_State_Manager.Instance.SetContent(content);

            //Load States
            Game_State_Manager.Instance.ChangeScreen(new Party_Create_State(GraphicsDevice));
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Game_State_Manager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            Game_State_Manager.Instance.Update(gameTime);
            // Gets keyboard state; detects input
            Key.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw the GUI
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Game_State_Manager.Instance.Draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}