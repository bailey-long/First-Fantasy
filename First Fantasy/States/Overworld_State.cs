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
using SharpDX.Direct3D9;

namespace First_Fantasy.States
{
    internal class Overworld_State: Game_State
    {
        private ContentManager _content;

        public GraphicsDeviceManager graphics;
        public GraphicsDevice graphicsDevice;
		public Desktop desktop;
        public Party party = Game_State_Manager.party;

        //sprites
        public sprite_class _partySprite;

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
            GUI_Overworld overworldInit = new GUI_Overworld
            {
                graphicsDevice = graphicsDevice
            };


            // Add UI to the screen
            desktop.Widgets.Add(overworldInit.overworldGrid);

            //Load party sprite
            _partySprite = new sprite_class(party.Members[0].Sprite)
            {
                Position = new Vector2(640/2, 380/2),
            };
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

            _partySprite.Draw(spriteBatch);

            spriteBatch.End();
		}
    }
}
