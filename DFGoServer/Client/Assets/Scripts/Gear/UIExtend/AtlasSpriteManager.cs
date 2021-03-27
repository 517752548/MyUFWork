using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 贴图图集管理。
/// </summary>
public class AtlasSpriteManager
{
	/// <summary>
	/// 图集贴图缓存。
	/// </summary>
	private Dictionary<string, Dictionary<string, Sprite>> m_AtlasSprites = new Dictionary<string, Dictionary<string, Sprite>>();

	/// <summary>
	/// 单例对象。
	/// </summary>
	public static AtlasSpriteManager _instance = null;


	/// <summary>
	/// 获取单例。
	/// </summary>
	public static AtlasSpriteManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AtlasSpriteManager();
			}
			return _instance;
		}
	}


	/// <summary>
	/// 获取贴图。
	/// </summary>
	/// <param name="path">贴图的路径。</param>
	/// <returns>贴图对象</returns>
	public Sprite GetSprite(string path)
	{
		//UI/Texture/Face/BQ-dfkfk.png
		//ui_texture_face, BQ-dfkfk.png

		string[] paths = path.Split('/');
		String atlasPath = "";
		String spriteName = paths[paths.Length - 1];
		for (int i = 0; i < paths.Length - 1; i++)
		{
			if (i == 0)
			{
				atlasPath = paths[i];
			}
			else
			{
				atlasPath = atlasPath + "_" + paths[i];
			}
		}

		return GResManager.GetInstance().LoadSprite(path);
	}

	/// <summary>
	/// 移除某个图集。
	/// </summary>
	/// <param name="prefab">图集名称。</param>
	public void RemoveCache(string prefab)
	{
		Dictionary<string, Sprite> cache;
		if (m_AtlasSprites.TryGetValue(prefab, out cache))
		{
			cache.Clear();
			m_AtlasSprites.Remove(prefab);
		}
	}

	/// <summary>
	/// 清除缓存。
	/// </summary>
	public void ClearCache()
	{
		var e = m_AtlasSprites.GetEnumerator();
		while (e.MoveNext())
		{
			var kvp = e.Current;
			kvp.Value.Clear();
		}
		e.Dispose();
		m_AtlasSprites.Clear();
	}
}
