using First_Fantasy.Classes.Charcter_Classes;
using First_Fantasy.States.Setup;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Fantasy.Classes.Interface.Overworld
{
    partial class GUI_Overworld: Grid
    {
        private Party _party = Game_State_Manager.party;
        public GraphicsDevice graphicsDevice { get; set; }

        public Grid overworldGrid;
        private void UI_LoadContent()
        {

            //TODO draw party with spritebatch rather than Myra in the state not the GUI
            _party.ShowMembers();
            overworldGrid = new Grid
            {
				RowSpacing = 10,
				ColumnSpacing = 3
			};

            var helloWorld = new Label
            {
				GridColumn = 0,
				GridRow = 0,
				TextColor = Color.Black,
				Id = "label",
				Text = "The Game: "
			};
            overworldGrid.Widgets.Add(helloWorld);
        }
    }
}
