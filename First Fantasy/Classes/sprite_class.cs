using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;

namespace First_Fantasy.Classes
{
	internal class sprite_class
	{
		public Vector2 Position { get; set; }
		public Texture2D Texture { get; set; }

		// Constructor
		public sprite_class(Texture2D Texture)
		{
			this.Texture = Texture;
		}

		public void Draw(SpriteBatch sp)
		{
			sp.Draw(Texture, Position, Color.White);
		}
	}

}
