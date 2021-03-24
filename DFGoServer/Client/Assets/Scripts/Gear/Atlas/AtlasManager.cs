using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AtlasManager
{
	public delegate void OnGetAtlasComplete(AtlasInfo atlas);

	private Dictionary<string, AtlasInfo> atlasDict;

	private static AtlasManager _instance;

	public static AtlasManager GetInstance()
	{
		if (_instance == null)
		{
			_instance = new AtlasManager();

		}
		return _instance;
	}

	public void Init()
	{
		atlasDict = new Dictionary<string, AtlasInfo>();
	}

	public void AddAtlas(string texturePath, AtlasInfo atlasInfo)
	{
		AtlasInfo atlas;
		if (!atlasDict.TryGetValue(texturePath, out atlas))
		{
			atlasDict.Add(texturePath, atlasInfo);
		}
	}

	public AtlasInfo GetAtlas(string texturePath)
	{
		AtlasInfo atlas;
		if (atlasDict.TryGetValue(texturePath, out atlas))
		{
			return atlas;
		}
		return null;
	}

	public AtlasInfo LoadAtlas(string texturePath)
	{
		AtlasInfo atlas = GetAtlas(texturePath);
		if (atlas != null)
		{
			return atlas;
		}
		return GResManager.GetInstance().LoadAllSpriteInAtlas(texturePath);
	}

	public void LoadAtlasAsync(string texturePath, OnGetAtlasComplete callback = null)
	{
		AtlasInfo atlas = GetAtlas(texturePath);
		if (atlas != null)
		{
			if (callback != null)
			{
				callback(atlas);
			}
			return;
		}
		GResManager.GetInstance().LoadAllSpriteInAtlasAsync(texturePath, delegate (AtlasInfo atlasInfo)
		{
			if (callback != null)
			{
				callback(atlasInfo);
			}
		});
	}

	public void RemoveAtlas(string texturePath)
	{
		AtlasInfo atlas;
		if (atlasDict.TryGetValue(texturePath, out atlas))
		{
			atlasDict.Remove(texturePath);
		}
	}

	public AtlasInfo LoadTextureWithAtlasInfo(string texturePath)
	{
		AtlasInfo atlas = GetAtlas(texturePath);
		if (atlas != null)
		{
			return atlas;
		}
		Texture2D tex = GResManager.GetInstance().LoadTexture2D(texturePath);
		atlas = new AtlasInfo();
		atlas.texturePath = texturePath;
		atlas.texture = tex;
		Sprite[] sps = new Sprite[1];
		Sprite s = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
		sps[0] = s;
		atlas.AddSprites(sps);
		AddAtlas(texturePath, atlas);
		return atlas;
	}
}

public class AtlasInfo
{
	public string texturePath;
	public Texture2D texture;
	private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
	private Sprite[] sprites;
	public void AddSprites(Sprite[] sps)
	{
		for (int i = 0; i < sps.Length; i++)
		{
			Sprite sprite = sps[i];
			if (sprite != null)
			{
				Sprite s = null;
				if (!spriteDict.TryGetValue(sprite.name, out s))
				{
					spriteDict.Add(sprite.name, sprite);
				}
			}
		}
		sprites = sps;
	}

	public Dictionary<string, Sprite> GetSpriteMap()
	{
		return spriteDict;
	}

	public Sprite[] GetSprites()
	{
		return sprites;
	}


	public int GetSpriteNum()
	{
		if (sprites == null)
		{
			return 0;
		}
		return sprites.Length;
	}

	public Sprite GetSprite(string name)
	{
		Sprite sprite;
		if (spriteDict.TryGetValue(name, out sprite))
		{
			return sprite;
		}
		return null;
	}
}