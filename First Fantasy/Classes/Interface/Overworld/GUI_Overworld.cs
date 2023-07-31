using First_Fantasy.Classes.Charcter_Classes;
using Microsoft.Xna.Framework;
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
        private Party _party { get; set; }

        public Grid overworldGrid;
        private void UI_LoadContent()
        {
            overworldGrid = new Grid
            {
				RowSpacing = 20,
				ColumnSpacing = 8
			};

            var helloWorld = new Label
            {
				TextColor = Color.Black,
				Id = "label",
				Text = "The Game "
			};

            overworldGrid.Widgets.Add(helloWorld);
        }
    }
}
