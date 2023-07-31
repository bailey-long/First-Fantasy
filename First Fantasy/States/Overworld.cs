using First_Fantasy.Classes;
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

namespace First_Fantasy.States
{
    internal class Overworld: Game_State
    {
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        public GraphicsDeviceManager graphics;
        public Desktop desktop;


        public Overworld(GraphicsDevice graphicsDevice)
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


            // Add UI to the screen
            //desktop.Widgets.Add(partyInit.mainGrid);
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
