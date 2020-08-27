using System;
using System.Collections.Generic;
using BetaFramework;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using SRF;
using UnityEngine;

namespace Scripts_Game.Controllers.GameInit
{
    public class GameMain : MonoBehaviour
    {
        private bool _gameInitSuccess = false;
        private CommQueueStateMachine startTaskQueue;

        public static List<string> preloadGameObject = new List<string>()
        {
            ViewConst.prefab_ClassicCell, ViewConst.prefab_CrossCell,
            ViewConst.prefab_DailyNotice, ViewConst.prefab_HintNotice,
            ViewConst.prefab_KnowledgeCardItem,
            ViewConst.prefab_DailyCell,
            ViewConst.prefab_OneWordCell,
            ViewConst.prefab_CardPieces_One, ViewConst.prefab_CardPieces_Two,
            ViewConst.prefab_CardPieces_Three, ViewConst.prefab_CardPieces_Four, ViewConst.prefab_CardPieces_CircleFour,
            ViewConst.prefab_CardPieces_Five, ViewConst.prefab_CardPieces_Six,
             ViewConst.prefab_WordSpit
        };

        public static List<string> preloadAsset = new List<string>()
        {
            ViewConst.asset_AnswerTips_AnswerTip, ViewConst.asset_BagItems_ItemReward,
#if UNITY_IOS
            ViewConst.asset_IapProductConfig_IosA,    
#else
            ViewConst.asset_IapProductConfig_AndroidA,
#endif
            
             ViewConst.asset_LanguageConfig_EnConfig,
            ViewConst.asset_Pets_Pet,
            ViewConst.asset_PlayerSign_Sign, ViewConst.asset_ProbabilityPool_ProbabilityPool, ViewConst.asset_RateConfig_RateConfig, ViewConst.asset_RateReward_rate,
            ViewConst.asset_UserGuide_Guide,
            ViewConst.asset_WebBox_ProbabilityPool,
            ViewConst.asset_SubwordRewardTable_Table,
            ViewConst.asset_CommConfig_config, ViewConst.asset_PetTipsList_TipList
        };

        public static List<string> preloadTextAsset = new List<string>()
        {
            ViewConst.txt_AddressablesRules
        };

        private void Awake()
        {
            AsyncPlayFabInit();
        }

        private string playfabid;
        public void AsyncPlayFabInit()
        {
            //var request = new LoginWithAndroidDeviceIDRequest();
            var request = new LoginWithCustomIDRequest { CustomId = "myidididid", CreateAccount = true};
            //PlayFabClientAPI.LoginWithAndroidDeviceID(id, loginresule =>
            PlayFabClientAPI.LoginWithCustomID(request, loginresule =>
            {
                playfabid = loginresule.PlayFabId;
                Debug.LogError("登录成功");
                UpdateUserInternalData();
            }, loginerror =>
            {
                Debug.LogError("登录失败");
            });
        }
        public void UpdateUserInternalData() {
            PlayFabServerAPI.UpdateUserInternalData(new UpdateUserInternalDataRequest() {
                    PlayFabId = playfabid,
                    Data = new Dictionary<string, string>() {
                        {"game", "Fighter"},
                        {"Race", "Human"},
                    },
                },
                result => Debug.Log("Set internal user data successful"),
                error => {
                    Debug.Log("Got error updating internal user data:");
                    Debug.Log(error.GenerateErrorReport());
                });
        }
        public void RunGame()
        {
            startTaskQueue = gameObject.AddComponent<CommQueueStateMachine>();
            startTaskQueue.AddQueueState(startTaskQueue.CreateState<fsm.LoadResState>());
            startTaskQueue.AddQueueState(startTaskQueue.CreateState<fsm.LoadingDataState>());
            startTaskQueue.AddQueueState(startTaskQueue.CreateState<fsm.LoginState>());
            startTaskQueue.OnLastStateCompleted(() =>
            {
                // OnlinePara();
                _gameInitSuccess = true;
                gameObject.RemoveComponentIfExists<CommQueueStateMachine>();
            });
            startTaskQueue.StartRun();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            bool release = PlatformUtil.GetAppIsRelease();
            if (!release)
            {
#if !UNITY_EDITOR
                SRDebug.Init();
#endif
            }
            else
            {
                Debug.unityLogger.logEnabled = false;
            }

        }

        private int timecd = 0;

        protected virtual void Update()
        {
            AppEngine.Update();
        }

        protected virtual void OnDestroy()
        {
            Record.SaveCacheKey();
            AppEngine.Destroy();
        }

        protected void OnApplicationPause(bool pause)
        {
            if (!_gameInitSuccess)
            {
                return;
            }

            // OnlinePara();
            Record.SaveCacheKey();
            AppEngine.ApplicationPause(pause);
        }

        // private void OnlinePara()
        // {
        //     GameAnalyze.LogusersActive(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId(),
        //         AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(), "");
        // }
    }
}