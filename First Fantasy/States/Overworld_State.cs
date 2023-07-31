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

namespace First_Fantasy.States
{
    internal class Overworld_State: Game_State
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        public GraphicsDeviceManager graphics;
		public static GraphicsDevice Graphics;
		public Desktop desktop;

		//Party
		private Party party = Game_State_Manager.party;

		//setup Sprites
		private Texture2D _partySprite;

		public Overworld_State(GraphicsDevice graphicsDevice)
      : base(graphicsDevice)
        {

		}

		public override void Initialize()
        {

		}

		public override void LoadContent(ContentManager _content)
        {
            //Load sprites
			_spriteBatch = new SpriteBatch(_graphicsDevice);
            //_partySprite = _content.Load<Texture2D>(party.Members[0].Sprite);

			// Setup the desktop
			desktop = new Desktop();
            GUI_Overworld overworldInit = new();

            // Add UI to the screen
            desktop.Widgets.Add(overworldInit.overworldGrid);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            party.ShowMembers(party.Members);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			desktop.Render();
			//spriteBatch.Draw(_partySprite, new Vector2(100, 100), Color.White);
		}
    }
}
