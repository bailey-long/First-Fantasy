using First_Fantasy.Classes.Charcter_Classes;
using Myra.Graphics2D.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using First_Fantasy;
using First_Fantasy.States.Setup;

namespace First_Fantasy.Classes
{
	 public partial class GUI_party_creator : Grid
	 {
		//Initialize the party
		private readonly Party_Factory _party_factory = new();
		public List<Member> Members = new List<Member>();
		public Party party = Game_State_Manager.party;

		//UI
		private TextButton finishButton;
		private TextButton editButton;
		private ComboBox partyList;
		public Grid partyCreatorGrid;

		private void UI_LoadContent()
		{
			//Create the members in the factory and then assemble it into the party list of members
			Members = _party_factory.CreateParty();
			party.AssembleParty(Members);
			Members = party.Members;

			partyCreatorGrid = new Grid
			{
				RowSpacing = 20,
				ColumnSpacing = 8
			};

			partyCreatorGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			partyCreatorGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			partyCreatorGrid.RowsProportions.Add(new Proportion(ProportionType.Auto));
			partyCreatorGrid.RowsProportions.Add(new Proportion(ProportionType.Auto));

			var helloWorld = new Label
			{
				TextColor = Color.Black,
				Id = "label",
				Text = "Create a party: "
			};
			partyCreatorGrid.Widgets.Add(helloWorld);

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
			partyCreatorGrid.Widgets.Add(partyList);

			// Button
			editButton = new TextButton
			{
				GridColumn = 2,
				GridRow = 0,
				Text = "Edit/View Character "
			};

			partyCreatorGrid.Widgets.Add(editButton);

			finishButton = new TextButton
			{
				GridColumn = 0,
				GridRow = 2,
				Text = "Venture Forth "
			};

			partyCreatorGrid.Widgets.Add(finishButton);

		}
	 }
}
