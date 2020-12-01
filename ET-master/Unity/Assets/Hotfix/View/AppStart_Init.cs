namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        public override async ETTask Run(EventType.AppStart args)
        {
            Game.Scene.AddComponent<TimerComponent>();
            Log.Info("run");
            // 下载ab包
            //await BundleHelper.DownloadBundle("1111");

            // 加载配置
            //Game.Scene.AddComponent<ResourcesComponent>();

            await ResourcesComponent.Instance.LoadAllConfig();
            Log.Info("run1");
            Game.Scene.AddComponent<ConfigComponent>();

            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            Game.Scene.AddComponent<UIEventComponent>();
            Game.Scene.AddComponent<UIManagerComponent>();
            Game.Scene.AddComponent<MapManagerComponent>();

            //ResourcesComponent.Instance.LoadBundle("unit.unity3d");

            Scene zoneScene = await SceneFactory.CreateZoneScene(0, 0, "Game");
            Log.Info("run2");
            await Game.EventSystem.Publish(new EventType.AppStartInitFinish() { ZoneScene = zoneScene });
        }
    }
}