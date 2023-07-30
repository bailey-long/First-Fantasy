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

namespace First_Fantasy.Classes
{
	public partial class GUI_party_creator: Grid
	{
		public Desktop desktop { get; set; }
		public SoundEffect startGame { get; set; }
		public ContentManager contentManager { get; set; }
		
		//Sprites
		public Texture2D classSpriteOne { get; set; }
		public Texture2D classSpriteTwo { get; set; }
		public Texture2D classSpriteThree { get; set; }
		public Texture2D classSpriteFour { get; set; }
		public Texture2D classSpriteFive { get; set; }

		private TextureRegion displayClass;

		public GUI_party_creator()
		{
			UI_LoadContent();
			this.contentManager = contentManager;

			finishButton.Click += (object sender, EventArgs e) =>
			{
				Debug.WriteLine("Clicked");

				var messageBox = Dialog.CreateMessageBox("Finished?", "Are you ready to enter the game?");
				messageBox.ShowModal(desktop);

				messageBox.ButtonOk.Click += (object sender, EventArgs e) =>
				{
					//Change screen
					desktop.Widgets.Remove(mainGrid);
					startGame.Play();
					MediaPlayer.Stop();					
				};
			};
			editButton.Click += (object sender, EventArgs e) =>
			{

				int memberShown = partyList.SelectedIndex.GetValueOrDefault();
				var displayed = Members[memberShown];

				//If there is no character present display creation screen
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

						//Must be trimmed or nothing works dont know why
						switch (displayed.Class.Trim())
						{
							case "Astral Weaver":
								displayed.Sprite = classSpriteOne;
								break;
							case "Verdant Sentinal":
								displayed.Sprite = classSpriteTwo;
								break;
							case "Steam Enforcer":
								displayed.Sprite = classSpriteThree;
								break;
							case "Echoblade":
								displayed.Sprite = classSpriteFour;
								break;
							case "Charlatan":
								displayed.Sprite = classSpriteFive;
								break;
							default:
								Debug.WriteLine("Uh Oh");
								Debug.WriteLine(displayed.Class);
								break;
						};
						//Debug.WriteLine(displayed.Sprite);
						partyList.Items.Clear();
						party.AddMember(displayed, memberShown);

						partyList.Items.Add(new ListItem($" {Members[0].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[1].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[2].Name}", Color.White));
						partyList.Items.Add(new ListItem($" {Members[3].Name}", Color.White));
						mainGrid.Widgets.Add(partyList);

					};

					charCreator.ShowModal(desktop);
				}
				else
				{
					displayClass =  new TextureRegion(displayed.Sprite);

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

					var playerSprite = new Image
					{
						GridColumn = 1,
						GridRow = 1,
						Renderable = displayClass
					};

					//Create window content
					var stackPanel = new VerticalStackPanel
					{
						Spacing = 8
					};
					stackPanel.Widgets.Add(raceLabel);
					stackPanel.Widgets.Add(levelLabel);
					stackPanel.Widgets.Add(classLabel);
					stackPanel.Widgets.Add(playerSprite);

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
						mainGrid.Widgets.Add(partyList);
					};
					charViewer.ShowModal(desktop);
				}
			};
		}
	}
}
