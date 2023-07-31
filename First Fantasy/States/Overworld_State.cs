using First_Fantasy.Classes;
using First_Fantasy.Classes.Charcter_Classes;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First_Fantasy.States.Setup;
using First_Fantasy.Classes.Interface.Overworld;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace First_Fantasy.States
{
    internal class Overworld_State: Game_State
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        public GraphicsDeviceManager graphics;
		public Desktop desktop;
        public Party party = Game_State_Manager.party;

        //Sprites
        private Texture2D _partySprite;
        private string _testString;

		public Overworld_State(GraphicsDevice graphicsDevice)
      : base(graphicsDevice)
        {

		}

		public override void Initialize()
        {

		}

		public override void LoadContent(ContentManager _content)
        {
			// Setup the desktop
			desktop = new Desktop();
            GUI_Overworld overworldInit = new();

            //Load Sprites
            _partySprite = _content.Load<Texture2D>("Sprites/Classes/echoblade");

            // Add UI to the screen
            desktop.Widgets.Add(overworldInit.overworldGrid);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

		}

        public override void Draw(SpriteBatch spriteBatch)
        {
			desktop.Render();

            spriteBatch.Begin();

            spriteBatch.Draw(_partySprite, new Vector2(100, 100), Color.White);

            spriteBatch.End();
		}
    }
}
