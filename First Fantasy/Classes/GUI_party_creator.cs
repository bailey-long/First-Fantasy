using First_Fantasy.Classes.Charcter_Classes;
using Myra.Graphics2D.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace First_Fantasy.Classes
{
	 partial class GUI_party_creator : Grid
	{
		//Initialize the party
		private readonly Party_Factory _party_factory = new();
		private Party party = new();
		private List<Member> Members = new List<Member>();

		//UI
		public TextButton finishButton;
		public TextButton editButton;
		public ComboBox partyList;
		public Grid mainGrid;

		private void UI_LoadContent()
		{
			//Create the members in the factory and then assemble it into the party list of members
			Members = _party_factory.CreateParty();
			party.AssembleParty(Members);
			Members = party.Members;

			mainGrid = new Grid
			{
				RowSpacing = 20,
				ColumnSpacing = 8
			};

			mainGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			mainGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			mainGrid.RowsProportions.Add(new Proportion(ProportionType.Auto));
			mainGrid.RowsProportions.Add(new Proportion(ProportionType.Auto));

			var helloWorld = new Label
			{
				TextColor = Color.Black,
				Id = "label",
				Text = "Create a party: "
			};
			mainGrid.Widgets.Add(helloWorld);

			// ComboBox
			partyList = new ComboBox
			{
				GridColumn = 1,
				GridRow = 0
			};
			partyList.Items.Add(new ListItem($" {Members[0].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[1].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[2].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[3].Name}", Color.White));
			mainGrid.Widgets.Add(partyList);

			// Button
			editButton = new TextButton
			{
				GridColumn = 2,
				GridRow = 0,
				Text = "Edit/View Character "
			};

			mainGrid.Widgets.Add(editButton);

			finishButton = new TextButton
			{
				GridColumn = 0,
				GridRow = 2,
				Text = "Venture Forth "
			};

			mainGrid.Widgets.Add(finishButton);

		}
	}
}
