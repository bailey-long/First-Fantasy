using First_Fantasy.Classes.Charcter_Classes;
using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace First_Fantasy.Classes
{

	internal class GUI_party_creator : Game1
	{
		public GraphicsDeviceManager partyGraphicsManager { get; set; }
		public Desktop partyDesktop { get; set; }

		//Initialize the party
		private readonly Party_Factory _party_factory = new Party_Factory();
		public Party party = new();

		public void LoadContent()
		{
			partyDesktop = new Desktop();
			//Create the members in the factory and then assemble it into the party list of members
			var Members = _party_factory.CreateParty();
			party.AssembleParty(Members);
			Members = party.Members;

			var grid = new Grid
			{
				RowSpacing = 20,
				ColumnSpacing = 8
			};

			grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
			grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
			grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

			var helloWorld = new Label
			{
				TextColor = Color.Black,
				Id = "label",
				Text = "Create a party: "
			};
			grid.Widgets.Add(helloWorld);

			// ComboBox
			var partyList = new ComboBox
			{
				GridColumn = 1,
				GridRow = 0
			};
			partyList.Items.Add(new ListItem($" {Members[0].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[1].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[2].Name}", Color.White));
			partyList.Items.Add(new ListItem($" {Members[3].Name}", Color.White));
			grid.Widgets.Add(partyList);

			// Button
			var editButton = new TextButton
			{
				GridColumn = 2,
				GridRow = 0,
				Text = "Edit/View Character "
			};

			editButton.Click += (s, a) =>
			{
				int memberShown = partyList.SelectedIndex.GetValueOrDefault();
				var displayed = Members[memberShown];

				if (displayed.Name == "EMPTY" || displayed.Class == "EMPTY")
				{
					//Fields for charatcer creator
					//Name Stuff
					var charName = new TextBox
					{
						GridColumn = 0,
						GridRow = 1,
						Text = "",
					};

					var nameLabel = new Label
					{
						GridColumn = 0,
						GridRow = 1,
						Text = "Name: ",
					};

					var randomize = new TextButton
					{
						GridColumn = 0,
						GridRow = 1,
						Text = "Random Name",
					};

					//Race stuff
					var charRace = new ComboBox
					{
						GridColumn = 0,
						GridRow = 1,
					};
					charRace.Items.Add(new ListItem("Human"));
					charRace.Items.Add(new ListItem("Dwarf"));
					charRace.Items.Add(new ListItem("Elf"));
					charRace.Items.Add(new ListItem("Clockborn"));
					charRace.Items.Add(new ListItem("Emberforged"));
					charRace.Items.Add(new ListItem("Gloomkin"));

					var raceLabel = new Label
					{
						GridColumn = 0,
						GridRow = 3,
						Text = "Race: "
					};

					//Class stuff
					var charClass = new ComboBox
					{
						GridColumn = 0,
						GridRow = 1
					};
					charClass.Items.Add(new ListItem("Astral Weaver")); //Astral wizard
					charClass.Items.Add(new ListItem("Verdant Sentinal")); //Druid
					charClass.Items.Add(new ListItem("Steam Enforcer")); //Engineer/Robot
					charClass.Items.Add(new ListItem("Echoblade")); //Eldritch knight
					charClass.Items.Add(new ListItem("Charlatan")); //Trickster/Rogue

					var classLabel = new Label
					{
						GridColumn = 0,
						GridRow = 2,
						Text = "Class: "
					};

					//Create window
					Dialog charCreator = new Dialog
					{
						Title = "Create a character",
					};
					//Create window content
					var stackPanel = new VerticalStackPanel
					{
						Spacing = 8
					};
					stackPanel.Widgets.Add(nameLabel);
					stackPanel.Widgets.Add(charName);
					stackPanel.Widgets.Add(raceLabel);
					stackPanel.Widgets.Add(charRace);
					stackPanel.Widgets.Add(classLabel);
					stackPanel.Widgets.Add(charClass);

					//Populate window
					charCreator.Content = stackPanel;

					charCreator.ButtonOk.Click += delegate (object sender, EventArgs e)
					{
						//Setup party member based on inputs
						displayed.Name = charName.Text;
						displayed.Race = charRace.SelectedItem.ToString();
						displayed.Class = charClass.SelectedItem.ToString();
						partyList.Items.Clear();
						party.AddMember(displayed, memberShown);

						partyList.Items.Add(new ListItem($" {Members[0].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[1].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[2].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[3].Name}", Color.White));
						grid.Widgets.Add(partyList);

					};

					charCreator.ShowModal(desktop);
				}
				else
				{
					var raceLabel = new Label
					{
						GridColumn = 0,
						GridRow = 0,
						Text = $"Race: {displayed.Race}"
					};

					var levelLabel = new Label
					{
						GridColumn = 0,
						GridRow = 1,
						Text = $"Level: {displayed.Level.ToString()}"
					};

					var classLabel = new Label
					{
						GridColumn = 0,
						GridRow = 2,
						Text = $"Class: {displayed.Class}"
					};

					//Create window content
					var stackPanel = new VerticalStackPanel
					{
						Spacing = 8
					};
					stackPanel.Widgets.Add(raceLabel);
					stackPanel.Widgets.Add(levelLabel);
					stackPanel.Widgets.Add(classLabel);

					Dialog charViewer = new Dialog
					{
						Title = displayed.Name,
					};
					charViewer.Content = stackPanel;

					charViewer.ButtonCancel.Text = "Remove";
					charViewer.ButtonCancel.Click += delegate (object sender, EventArgs e)
					{
						partyList.Items.Clear();
						party.RemoveMember(displayed);

						partyList.Items.Add(new ListItem($" {Members[0].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[1].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[2].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[3].Name}", Color.White));
						grid.Widgets.Add(partyList);
					};
					charViewer.ShowModal(desktop);
				}
			};

			grid.Widgets.Add(editButton);

			var finishButton = new TextButton
			{
				GridColumn = 0,
				GridRow = 2,
				Text = "Venture Forth "
			};

			finishButton.Click += (s, a) =>
			{
				grid.Widgets.Clear();
			};

			grid.Widgets.Add(finishButton);

			partyDesktop.Root = grid;

		}
	}
}
