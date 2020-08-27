using System;
using Bag;
using BetaFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Scripts_Game.Controllers.GameInit.fsm
{
    public class LoadingDataState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            //float widthRatio = 1080 / (float) Screen.width;
            //Screen.SetResolution(1080,(int)(Screen.height * widthRatio),true);

            AppEngine.SyncManager = AppEngine.Modules.Registered<DataSyncManager>();
            AppEngine.SyncManager.Init();
            //AppEngine.Modules.Registered<>();
            AppEngine.SSystemManager.InstallSystem<PlayerInfoSystem>();
            AppEngine.SSystemManager.InstallSystem<CellTipABSystem>();
            AppEngine.SSystemManager.InstallSystem<UiLayerSystem>();
            AppEngine.SSystemManager.InstallSystem<EmailSystem>();
            AppEngine.SSystemManager.InstallSystem<TestABSystem>();
            AppEngine.SSystemManager.InstallSystem<TestABWordLibSystem>();
            AppEngine.SSystemManager.InstallSystem<RewardABSystem>();
            AppEngine.SSystemManager.InstallSystem<PlayerLoginSystem>();
            AppEngine.SSystemManager.InstallSystem<ClassicGameSystem>();
            AppEngine.SSystemManager.InstallSystem<ProbabilitySystem>();
            AppEngine.SSystemManager.InstallSystem<WordCategorySystem>();
            AppEngine.SSystemManager.InstallSystem<DailySystem>();
            AppEngine.SSystemManager.InstallSystem<WorLibrarySystem>();
            AppEngine.SSystemManager.InstallSystem<GuideSystem>();
            AppEngine.SSystemManager.InstallSystem<PlayerSignSystem>();
            AppEngine.SSystemManager.InstallSystem<DailyOneWordSystem>();
            AppEngine.SSystemManager.InstallSystem<WebSystem>();
            AppEngine.SSystemManager.InstallSystem<FastRacePlaySystem>();
            AppEngine.SSystemManager.InstallSystem<DownLoadResSystem>();
            AppEngine.SSystemManager.InstallSystem<EliteSystem>();

            AppEngine.Init(() =>
            {
                //由于网络配置管理依赖PlayerLoginSystem初始化完成，所以放到这里
                WebConfigMgr.Init();
                CheckFirstLogin((first) =>
                {
                    Object.FindObjectOfType<GameInitLoadBar>().LoadScene(first);
                    AppEngine.SSystemManager.GetSystem<TestABSystem>().UserEnterGame();
                    OnCompleted();
                });
            });
        }

        private void CheckFirstLogin(Action<bool> back)
        {
            if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value == 0)
            {
                //DataManager.ProcessData.FirstGoToGame = true;
                var cnfig = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserPropConfig();
                for (int i = 0; i < cnfig.dataList.Count; i++)
                {
                    if (cnfig.dataList[i].ID == "Coin")
                    {
                        AppEngine.SyncManager.Data.Coin.Value = cnfig.dataList[i].DefaultCount;
                    }
                }

                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value = 1;
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.ResetLastValue();
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadClassicLevel(
                    AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value,
                    (ok) =>
                    {
                        if (ok)
                        {
                            LoggerHelper.Log("加载第一关成功");
                            back.Invoke(true);
                            DataManager.ProcessData._GameMode = GameMode.Classic;
                        }
                        else
                        {
                            LoggerHelper.Error("第一关加载失败");
                            back.Invoke(false);
                        }
                    }
                );
            }
            else
            {
                //PreloadBG(null);
                LoggerHelper.Log("进入home");
                back.Invoke(false);
            }
        }

        private async void PreloadBG(Action callback)
        {
            ClassicWorldEntity classicWorldEntity = null;
            try
            {
                classicWorldEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetCurClassicWorld();
            }
            catch (Exception e)
            {
                Debug.LogError(e.StackTrace);
                callback.Invoke();
            }

            if (classicWorldEntity != null)
            {
                var preload = Addressables.LoadAssetAsync<Sprite>(classicWorldEntity.HomeImage);
                await preload.Task;
                callback.Invoke();
            }
            else
            {
                callback.Invoke();
            }

        }
    }


}

namespace BetaFramework
{
    public static partial class AppEngine
    {
        public static DataSyncManager SyncManager;
    }
}