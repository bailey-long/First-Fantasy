using First_Fantasy.Classes.Charcter_Classes;
using First_Fantasy.States.Setup;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Fantasy.Classes.Interface.Overworld
{
    partial class GUI_Overworld: Grid
    {
        private Party _party = Game_State_Manager.party;

        public Grid overworldGrid;
        private void UI_LoadContent()
        {
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

           /*var partyDisplay = new Image
            {
				GridColumn = 1,
				GridRow = 1,
				Renderable = new TextureRegion(_party.Members[0].Sprite)
            };
            overworldGrid.Widgets.Add(partyDisplay);*/
        }
    }
}
