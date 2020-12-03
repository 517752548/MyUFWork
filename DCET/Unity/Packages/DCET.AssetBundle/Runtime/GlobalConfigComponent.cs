using System;
using UnityEngine;

namespace DCETRuntime
{
	public class GlobalConfigComponent
	{
		public static GlobalConfigComponent Instance { get; private set; } = new GlobalConfigComponent();

		public GlobalProto GlobalProto;

		public GlobalConfigComponent()
		{
			Instance = this;
			string configStr = GetGlobal();
			this.GlobalProto = MongoHelper.FromJson<GlobalProto>(configStr);
		}

		public static string GetGlobal()
		{
			try
			{
				GameObject config = (GameObject)ResourcesHelper.Load("KV");
				string configStr = GameObjectHelper.GetTextAsset(config, "GlobalProto").text;
				return configStr;
			}
			catch (Exception e)
			{
				throw new Exception($"load global config file fail", e);
			}
		}
	}
}