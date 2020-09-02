using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.AddressableAssets.ResourceProviders;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Scripts_Game.Controllers.GameInit.fsm
{
    public class LoadResState : BaseState
    {
        private float currentProgress = 0;
        private bool finished = false;
        private AsyncOperationHandle<IResourceLocator> init;
        private bool inited = false;

        public override void Enter()
        {
            base.Enter();
            GameAnalyze.Init();
            if (Record.GetInt("AFBack",0) == 0)
            {
                FTDSdk.getInstance().setOnAttributeListener(new AFBack());
            }
            init = Addressables.InitializeAsync();
            InitBundle();
        }

        private async void CheckUpdate()
        {
            //var catelog = Addressables.UpdateCatalogs();
            var updatelist = Addressables.CheckForCatalogUpdates();
            await updatelist;
            if (updatelist.Status == AsyncOperationStatus.Succeeded && updatelist.Result.Count > 0)
            {
                Debug.LogError("更新项:" + updatelist.Result.Count);
                for (int i = 0; i < updatelist.Result.Count; i++)
                {
                    Debug.Log(updatelist.Result[i]);
                }

                var catalogs = Addressables.UpdateCatalogs(updatelist.Result);
                await catalogs;
                LoadRes();
            }
            else
            {
                Debug.Log("没有更新项");
                LoadRes();
            }
        }

        private async void InitBundle()
        {
            this.init.Completed += (op) =>
            {
                InitBI();
                GameAnalyze.LogLoading("3", Time.realtimeSinceStartup.ToString());
                if (op.IsValid() && op.Status == AsyncOperationStatus.Succeeded)
                {
                    LoadRes();
                    // TimersManager.SetTimer(5, () =>
                    // {
                    //     CheckUpdate();
                    // });
                    //CheckUpdate();
                    //TimersManager.SetTimer(5, () => { LoadRes(); });
                }
                else
                {
                    Debug.LogError("bundle 初始化失败");
                    LoadRes();
                }
                IFixMgr.Init(() => { GameAnalyze.LogLoading("33", Time.realtimeSinceStartup.ToString()); });
            };
        }

        private void InitBI()
        {
            AdManager.InitAD();
        }


        private void LoadRes()
        {
            if (inited)
                return;
            inited = true;
            Debug.Log("开始加载资源");
            //游戏启动的第一时间加载，不可更改位置
            GameInitLoadBar.CurMaxProgress = 0.45f;
            Record.Init();
            GameInitLoadBar.ShowLoadBar = true;
            GameAnalyze.LogLoading("4", Time.realtimeSinceStartup.ToString());
            GameInitLoadBar.CurMaxProgress = 0.65f;
            PreLoadManager.PreLoadScriptableObject(PreLoadConst.preload_Asset,
                GameMain.preloadAsset,
                () =>
                {
                    GameAnalyze.LogLoading("5", Time.realtimeSinceStartup.ToString());
                    GameInitLoadBar.CurMaxProgress = 0.75f;
                    PreLoadManager.PreLoadGameObject(PreLoadConst.preload_Prefab,
                        GameMain.preloadGameObject,
                        () =>
                        {
                            GameAnalyze.LogLoading("6", Time.realtimeSinceStartup.ToString());
                            GameInitLoadBar.CurMaxProgress = 0.85f;
                            PreLoadManager.PreLoadTextAsset(PreLoadConst.preload_TextAsset,
                                GameMain.preloadTextAsset,
                                () =>
                                {
                                    GameAnalyze.LogLoading("7", Time.realtimeSinceStartup.ToString());
                                    GameInitLoadBar.CurMaxProgress = 0.95f;
                                    OnCompleted();
                                });
                        });
                });
            // WikiController.Instance.Preload();
        }
    }
}