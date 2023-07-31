using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First_Fantasy.Classes;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Myra.Graphics2D.UI;
using First_Fantasy.States.Setup;
using First_Fantasy.Classes.Charcter_Classes;

namespace First_Fantasy.States
{
    public class Party_Create_State : Game_State
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        public GraphicsDeviceManager graphics;
        public static GraphicsDevice Graphics;
        public Desktop desktop;

		public Party_Create_State(GraphicsDevice graphicsDevice)
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

            //Setup party creator UI
            GUI_party_creator partyInit = new()
            {
                desktop = desktop,
                contentManager = _content,
                startGame = _content.Load<SoundEffect>("Sounds/Unique/venture_forth"),
                classSpriteOne = _content.Load<Texture2D>("Sprites/Classes/astral_weaver"),
                classSpriteTwo = _content.Load<Texture2D>("Sprites/Classes/verdant_sentinal"),
                classSpriteThree = _content.Load<Texture2D>("Sprites/Classes/steam_enforcer"),
                classSpriteFour = _content.Load<Texture2D>("Sprites/Classes/echoblade"),
                classSpriteFive = _content.Load<Texture2D>("Sprites/Classes/charlatan")
            };

            Song menuTheme = _content.Load<Song>("Sounds/Unique/beggining");
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(menuTheme);
            MediaPlayer.IsRepeating = true;

			// Add UI to the screen
			desktop.Widgets.Add(partyInit.partyCreatorGrid);
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
        }
    }
}
