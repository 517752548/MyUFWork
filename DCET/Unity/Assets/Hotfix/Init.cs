using BehaviorDesigner.Runtime;
using DCETRuntime;
using System;
using UnityEngine;

namespace DCET
{
	public static class Init
	{
		public async static void Start()
		{
			try
			{
				TypeHelper.Init();
				Game.EventSystem.Init();

				// 注册热更层回调
				GameLoop.onUpdate += Update;
				GameLoop.onLateUpdate += LateUpdate;
				GameLoop.onApplicationQuit += OnApplicationQuit;

				Game.Scene = EntityFactory.CreateScene();
				Game.Scene.AddComponent<NetOuterComponent>();
				Game.Scene.AddComponent<OpcodeTypeComponent>();
				Game.Scene.AddComponent<MessageDispatcherComponent>();
				Game.Scene.AddComponent<SessionComponent>();
				Game.Scene.AddComponent<PlayerComponent>();
				Game.Scene.AddComponent<UnitComponent>();

				// 加载热更配置
				Game.Scene.AddComponent<ResourcesComponent>().LoadBundle("config.unity3d");
				Game.Scene.AddComponent<ConfigComponent>();
				Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");

				Game.Scene.AddComponent<FUIPackageComponent>();
				Game.Scene.AddComponent<FUIComponent>();
				await Game.Scene.AddComponent<FUIInitComponent>().Init();
				Game.EventSystem.Run(EventIdType.InitSceneStart);

				// 演示行为树用法
				//TestBehaviorTree();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		/// <summary>
		/// 演示行为树用法，使用时可以删除
		/// </summary>
		private static void TestBehaviorTree()
		{
			// 全局共享变量用法
			Game.Scene.AddComponent<BehaviorTreeVariableComponent>().SetVariable("全局变量", 1);

			var runtimeBehaivorTree = UnityEngine.Object.Instantiate(ResourcesHelper.Load("Cube") as GameObject).GetComponent<BehaviorDesigner.Runtime.BehaviorTree>();

			if (runtimeBehaivorTree)
			{
				//建议在资源预加载时进行初始化，以免游戏对局中反序列化GC卡顿
				BehaviorTreeHelper.Init(runtimeBehaivorTree.gameObject);

				//动态加载外部行为树用法
				//UnityEngine.Object externalBehavior = 加载("外部行为树资源");
				//BehaviorTreeHelper.Init(externalBehavior);
				//runtimeBehaivorTree.Ensure<BehaviorTreeController>().SetExternalBehavior(externalBehavior);

				(GameObjectHelper.Ensure(runtimeBehaivorTree.gameObject, typeof(BehaviorTreeController)) as BehaviorTreeController).Init();
			}

			var behaviorTree = BehaviorTreeFactory.Create(Game.Scene, runtimeBehaivorTree);

			// 新增行为树共享变量用法
			var p1 = behaviorTree.GetComponent<BehaviorTreeVariableComponent>().GetVariable<int>("变量1");

			Log.Info($"行为树变量：{p1}");

			behaviorTree.GetComponent<BehaviorTreeVariableComponent>().SetVariable("变量1", 2);

			p1 = behaviorTree.GetComponent<BehaviorTreeVariableComponent>().GetVariable<int>("变量1");

			Log.Info($"行为树变量：{p1}");

			behaviorTree.GetComponent<BehaviorTreeVariableComponent>().SetVariable("变量2", "");
			behaviorTree.GetComponent<BehaviorTreeVariableComponent>().SetVariable("变量3", behaviorTree);
			behaviorTree.GetComponent<BehaviorTreeVariableComponent>().SetVariable("变量4", runtimeBehaivorTree);

		}

		public static void Update()
		{
			Game.EventSystem.Update();
		}

		public static void LateUpdate()
		{
			Game.EventSystem.LateUpdate();
		}

		public static void OnApplicationQuit()
		{
			GameLoop.onUpdate -= Update;
			GameLoop.onLateUpdate -= LateUpdate;
			GameLoop.onApplicationQuit -= OnApplicationQuit;
			Game.Close();
		}
	}
}