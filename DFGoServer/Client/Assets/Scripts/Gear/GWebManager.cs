using UnityEngine;
using UnityEngine.Networking;

namespace Gear
{
	public class GWebManager
	{
		public delegate void OnRequestTextCompleteDelegate(string data);
		public delegate void OnRequestTextErrorDelegate(GBaseLoader loader);
		private static GWebManager _instance;
		public static GWebManager GetInstance()
		{
			if (_instance == null)
			{
				_instance = new GWebManager();

			}
			return _instance;
		}

		private GTextLoader GetTextLoader(OnRequestTextCompleteDelegate onComplete = null, OnRequestTextErrorDelegate onError = null)
		{
			GTextLoader loader = new GTextLoader();
			loader.OnLoadComplete = delegate (GBaseLoader _loader)
			{
				if (onComplete != null)
				{
					onComplete(loader.Text);
				}
			};
			loader.OnLoadError = delegate (GBaseLoader _loader)
			{
				if (onError != null)
				{
					onError(_loader);
				}
			};
			return loader;
		}

		public void RequestTextAsyncByPost(string url, WWWForm form, OnRequestTextCompleteDelegate onComplete = null, OnRequestTextErrorDelegate onError = null)
		{
			GTextLoader loader = GetTextLoader(onComplete, onError);
			loader.Url = url;
			loader.Load(UnityWebRequest.kHttpVerbPOST, form);
		}

		public void RequestTextAsync(string url, OnRequestTextCompleteDelegate onComplete = null, OnRequestTextErrorDelegate onError = null)
		{
			GTextLoader loader = GetTextLoader(onComplete, onError);
			loader.Url = url;
			loader.Load();
		}
	}
}