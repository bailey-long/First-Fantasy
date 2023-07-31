using Myra.Graphics2D.UI;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.TextureAtlases;
using SharpDX.Direct3D9;
using Microsoft.Xna.Framework.Content;
using First_Fantasy.States.Setup;

namespace First_Fantasy.Classes.Interface.Overworld
{
    partial class GUI_Overworld: Grid
    {

        public GUI_Overworld()
        {
            UI_LoadContent();

            //Add Widget Functionality
        }
    }
}
