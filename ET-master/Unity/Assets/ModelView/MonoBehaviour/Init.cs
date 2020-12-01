using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace ET
{
	public class Init : MonoBehaviour
	{
		private void Start()
		{
			InitAsync();
		}

		private async void  InitAsync()
		{
			
			try
			{
				SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
				
				DontDestroyOnLoad(gameObject);

				string[] assemblyNames = { "Unity.Model", "Unity.Hotfix", "Unity.ModelView", "Unity.HotfixView" };
				
				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				{
					bool assemblyHotDll = false;
					string assemblyName = assembly.FullName;
					for (int i = 0; i < assemblyNames.Length; i++)
					{
						if (assemblyName.StartsWith(assemblyNames[i]))
						{
							assemblyHotDll = true;
						}
					}

					if (assemblyHotDll)
					{
						Game.EventSystem.Add(assembly.FullName,assembly);	
					}
					
				}
				// 加载配置
				Game.Scene.AddComponent<ResourcesComponent>();
				await Game.Hotfix.LoadHotfixAssembly();
				Game.Hotfix.GotoHotfix();
				
				//Game.EventSystem.Publish(new EventType.AppStart());
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
			
		}

		private void Update()
		{
			OneThreadSynchronizationContext.Instance.Update();
			Game.EventSystem.Update();
		}

		private void LateUpdate()
		{
			Game.EventSystem.LateUpdate();
		}

		private void OnApplicationQuit()
		{
			Game.Close();
		}
	}
}