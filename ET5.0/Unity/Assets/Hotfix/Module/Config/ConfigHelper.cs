using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
	public static class ConfigHelper
	{
		public static string GetText(string key)
		{
			try
			{
				Log.Error(key);
				TextAsset config = ETModel.Game.Scene.GetComponent<ResourcesComponent>().GetAsset<TextAsset>($"{key}.txt");
				return config.text;
			}
			catch (Exception e)
			{
				throw new Exception($"load config file fail, key: {key}", e);
			}
		}

		public static T ToObject<T>(string str)
		{
			return JsonHelper.FromJson<T>(str);
		}
	}
}