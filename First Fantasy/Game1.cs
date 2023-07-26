using First_Fantasy.Classes;
using First_Fantasy.Classes.Charcter_Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;
using SharpDX.Direct2D1;
using System;
using System.Diagnostics;
using System.Reflection;

namespace First_Fantasy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch;
        private Desktop _desktop;

        //Initialize the party
        private Party_Factory party_factory = new Party_Factory();
        private Party party = new Party();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);

            //Create the members in the factory and then assemble it into the party list of members
            var Members = party_factory.CreateParty();
            party.AssembleParty(Members);
            Members = party.Members;

            // Draw the GUI
            MyraEnvironment.Game = this;

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
                        charClass.Items.Add(new ListItem("Astral Weaver"));
                        charClass.Items.Add(new ListItem("Verdant Sentinal"));
                        charClass.Items.Add(new ListItem("Steam Enforcer"));
                        charClass.Items.Add(new ListItem("Echoblade"));

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

					    charCreator.ShowModal(_desktop);
                    }
                    else
                    {
					    var messageBox = Dialog.CreateMessageBox(displayed.Name, $" Level: {displayed.Level}\n Race: {displayed.Race}\n Class: {displayed.Class}");
                        messageBox.ShowModal(_desktop);
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


            // Add it to the desktop
            _desktop = new Desktop();
            _desktop.Root = grid;
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            Key.GetState();

            //Shows party in debug TODO: Make into a gui menu.
            if (Key.HasBeenPressed(Keys.Escape))
            {
                party.ShowMembers(party.Members);
            };

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // Draw the Myra GUI
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _desktop.Render();

            base.Draw(gameTime);
        }
    }
}