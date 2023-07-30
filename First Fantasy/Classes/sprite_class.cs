using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;

namespace First_Fantasy.Classes
{
	internal class sprite_class
	{
		public Vector2 Position;
		private Texture2D texture { get; set; }

		// Constructor
		public sprite_class(Texture2D texture)
		{
			this.texture = texture;
		}

		public void Draw(SpriteBatch sp)
		{
			sp.Draw(texture, Position, Color.White);
		}
	}

}
