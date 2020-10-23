using UnityEngine;
using UnityEngine.UI;

namespace app.utils
{
	public static class ExtensionMethods
	{
		public static void SetTexture(this Image image, Texture2D texture)
		{
			Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
			image.sprite = sp;
		}
	}
}