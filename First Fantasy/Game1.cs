﻿using First_Fantasy.Classes;
using First_Fantasy.Classes.Charcter_Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;
using SharpDX.Direct2D1;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml;

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
				partyDesktop = desktop
			};
            
            // Add to the desktop
            MyraEnvironment.Game = this;

			partyInit.LoadContent();

		}

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here

            Key.GetState();

			//Shows party in debug TODO: Make into a gui menu.
			/*if (Key.HasBeenPressed(Keys.Escape))
            {
                party.ShowMembers(party.Members);
            };*/
			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw the Myra GUI
            MyraEnvironment.GraphicsDevice.Clear(Color.CornflowerBlue);
			partyInit.partyDesktop.Render();

            base.Draw(gameTime);
        }
    }
}