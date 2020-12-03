using FairyGUI;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DCETRuntime
{
	public class Init : MonoBehaviour
	{
		private async void Awake()
		{
			try
			{
				Debug.Log("");
				SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);

				DontDestroyOnLoad(gameObject);

				GRoot.inst.SetContentScaleFactor(1920, 1080);

				var result = await DownloadBundle();

				if (result)
				{
					HotfixHelper.StartHotfix();
				}
				else
				{
					Log.Error("资源下载失败，请检查资源服务器是否正常运行(点击“Tools/web资源服务器”启动)");
				}
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private async Task<bool> DownloadBundle()
		{
			if (Define.IsAsync)
			{
				RuntimeBinder.BindAll();

				using (FUIPackage fuiPackage = new FUIPackage("FUI/Runtime"))
				{
					using (FUIDownloader fuiDownloader = new FUIDownloader())
					{
						return await fuiDownloader.DownloadAsync();
					}
				}
			}

			return true;
		}

		private void Start()
		{
			try
			{
				GameLoop.onStart?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnEnable()
		{
			try
			{
				GameLoop.onEnable?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnDisable()
		{
			try
			{
				GameLoop.onDisable?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void Update()
		{
			try
			{
				OneThreadSynchronizationContext.Instance.Update();
				GameLoop.onUpdate?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void LateUpdate()
		{
			try
			{
				GameLoop.onLateUpdate?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void FixedUpdate()
		{
			try
			{
				GameLoop.onFixedUpdate?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnDestroy()
		{
			try
			{
				GameLoop.onDestroy?.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnApplicationPause(bool isPause)
		{
			try
			{
				GameLoop.onApplicationPause?.Invoke(isPause);
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnApplicationFocus(bool isFocus)
		{
			try
			{
				GameLoop.onApplicationFocus?.Invoke(isFocus);
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		private void OnApplicationQuit()
		{
			try
			{
				GameLoop.onApplicationQuit?.Invoke();

				OneThreadSynchronizationContext.Instance.Clear();

				AssetBundles.Default.Dispose();

				if (Define.IsLua)
				{
#if XLUA
					Lua.Default.Dispose();
#endif
				}
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}
	}
}