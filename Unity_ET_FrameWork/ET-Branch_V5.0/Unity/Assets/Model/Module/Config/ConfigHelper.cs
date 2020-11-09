using System;
using UnityEngine;

namespace ETModel
{
	public static class ConfigHelper
	{

		public static string GetGlobal()
		{
			try
			{
				GameObject config = (GameObject)ResourcesHelper.Load("KV");
				string configStr = config.Get<TextAsset>("GlobalProto").text;
				return configStr;
			}
			catch (Exception e)
			{
				throw new Exception($"load global config file fail", e);
			}
		}

		public static string GetText(string key)
		{
			try
			{
				TextAsset config = (TextAsset)ETModel.Game.Scene.GetComponent<ResourcesComponent>().GetPreloadObject<TextAsset>($"{key}.txt");
				return config.text;
			}
			catch (Exception e)
			{
				throw new Exception($"load config file fail, key: {key}", e);
			}
		}
		
		public static T ToObject<T>(string str)
		{
			try
			{
				return JsonHelper.FromJson<T>(str);
			}
			catch (Exception e)
			{
				Log.Error(str);
				Console.WriteLine(e);
				throw;
			}
			
		}
	}
}