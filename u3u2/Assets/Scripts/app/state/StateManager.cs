using app.battle;
using app.main;
using app.avatar;
using app.model;
using app.zone;
using app.gameloading;
using app.net;
using app.human;
using app.npc;
using app.tips;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace app.state
{
    /// <summary>
    /// 游戏全局状态管理器
    /// </summary>
    public class StateManager : AbsMonoBehaviour
    {
        private StateBase lastState = null;
        //当前状态
        private StateBase curState = null;
        //所有状态对象
        private Dictionary<StateDef, StateBase> stateDic = new Dictionary<StateDef, StateBase>();
        //转换状态字典，状态key可以转换到的状态set
        private Dictionary<StateDef, HashSet<StateDef>> changeDic = new Dictionary<StateDef, HashSet<StateDef>>();
        private float mLastCheckMemCacheLeakTime = 0.0f;

        private float mLastGCTime = 0.0f;
        //单例
        private static StateManager ins;
        public static StateManager Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new StateManager();
                }
                return ins;
            }
        }

        private StateManager()
        {
            init();
        }

        private void init()
        {
            //XXX 新增状态时，下面两个方法都需要添加
            //注册所有状态
            initStateDic();

            //初始化状态关系
            initChangeDic();
        }

        private void initStateDic()
        {
            //注册所有状态
            StateBase initState = new InitState();
            this.stateDic.Add(initState.state, initState);

            StateBase initUIState = new InitUIState();
            this.stateDic.Add(initUIState.state, initUIState);

            //StateBase verifyConfigState = new VerifyConfigState();
            //this.stateDic.Add(verifyConfigState.state, verifyConfigState);

            StateBase loginState = new LoginState();
            this.stateDic.Add(loginState.state, loginState);

            StateBase selAvatarState = new SelAvatarState();
            this.stateDic.Add(selAvatarState.state, selAvatarState);

            //StateBase mainSceneState = new MainSceneState();
            //this.stateDic.Add(mainSceneState.state, mainSceneState);

            StateBase battleState = new BattleState();
            this.stateDic.Add(battleState.state, battleState);

            //StateBase missionState = new MissionState();
            //this.stateDic.Add(missionState.state, missionState);

            StateBase zoneState = new ZoneState();
            this.stateDic.Add(zoneState.state, zoneState);

			StateBase storyState = new StoryState();
			this.stateDic.Add(storyState.state, storyState);
        }

        private void initChangeDic()
        {
            //初始化状态关系
            addChangeDic(StateDef.init, StateDef.initUI);

            //addChangeDic(StateDef.initUI, StateDef.verifyConfig);

            //addChangeDic(StateDef.verifyConfig, StateDef.login);
            addChangeDic(StateDef.initUI, StateDef.login);
            //addChangeDic(StateDef.verifyConfig, StateDef.init);
            //addChangeDic(StateDef.verifyConfig, StateDef.verifyConfig);//网络异常时，需要重新校验
            //addChangeDic(StateDef.verifyConfig, StateDef.zoneState);

            addChangeDic(StateDef.login, StateDef.selAvatar);
            //addChangeDic(StateDef.login, StateDef.mainScene);
            addChangeDic(StateDef.login, StateDef.login);//登录出错时，会从登录状态到登录状态
            addChangeDic(StateDef.login, StateDef.zoneState);

            //addChangeDic(StateDef.selAvatar, StateDef.mainScene);
            addChangeDic(StateDef.selAvatar, StateDef.login);

            //addChangeDic(StateDef.mainScene, StateDef.login);
            //addChangeDic(StateDef.mainScene, StateDef.battleState);
            //addChangeDic(StateDef.mainScene, StateDef.missionScene);
            //addChangeDic(StateDef.mainScene, StateDef.zoneState);

            //addChangeDic(StateDef.battleState, StateDef.mainScene);
            addChangeDic(StateDef.battleState, StateDef.login);
            //addChangeDic(StateDef.battleState, StateDef.missionScene);
            addChangeDic(StateDef.battleState, StateDef.zoneState);
            addChangeDic(StateDef.battleState, StateDef.init);

            //addChangeDic(StateDef.missionScene, StateDef.mainScene);
            //addChangeDic(StateDef.missionScene, StateDef.battleState);

            addChangeDic(StateDef.zoneState, StateDef.zoneState);
            addChangeDic(StateDef.zoneState, StateDef.battleState);
            addChangeDic(StateDef.zoneState, StateDef.init);
			addChangeDic(StateDef.zoneState, StateDef.storyState);

			addChangeDic(StateDef.storyState, StateDef.zoneState);
        }

        private void addChangeDic(StateDef k, StateDef v)
        {
            HashSet<StateDef> sSet = null;
            this.changeDic.TryGetValue(k, out sSet);
            if (null == sSet)
            {
                sSet = new HashSet<StateDef>();
                this.changeDic.Add(k, sSet);
            }
            sSet.Add(v);
        }

        /// <summary>
        /// 初始化当前状态，即第一个状态
        /// </summary>
        private void initCurState()
        {
            this.curState = getState(StateDef.init);
            this.curState.onEnter();
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="targetState">要切换到的状态枚举</param>
        /// <returns>是否成功切换状态</returns>
        public bool changeState(StateDef targetState, params object[] args)
        {
            //检查能否切换到目标状态
            if (this.curState != null)
            {
                if (this.curState.canLeave())
                {
                    StateBase targetStateBase = this.getState(targetState);
                    if (targetStateBase != null)
                    {
                        if (targetStateBase.canEnter())
                        {
                            HashSet<StateDef> sSet = null;
                            this.changeDic.TryGetValue(this.curState.state, out sSet);
                            if (sSet != null && sSet.Contains(targetState))
                            {
                                //合法，则离开当前状态，切换到目标状态
                                this.curState.onLeave(targetState);
                                if (this.curState.state == StateDef.login)
                                {
                                    GameObject.Find("InitCanvas").SetActive(false);
                                }
                                //ClearMemery();
                                this.lastState = this.curState;
                                this.curState = targetStateBase;
                                this.curState.onEnter();
                                return true;
                            }
                            else
                            {
                                ClientLog.LogWarning("#StateManager#changeState#changeDic set not contains!curState=" + this.curState.state +
                                    ";targetState=" + targetState);
                            }
                        }
                        else
                        {
                            ClientLog.LogWarning("#StateManager#changeState#target State not allow enter!curState=" + this.curState.state +
                                "targetState=" + targetState);
                        }
                    }
                    else
                    {
                        ClientLog.LogError("#StateManager#changeState#targetStateBase is null!curState=" + this.curState.state +
                                "targetState=" + targetState);
                    }
                }
                else
                {
                    ClientLog.LogWarning("#StateManager#changeState#curState not allow leave!curState=" + this.curState.state +
                        "targetState=" + targetState);
                }
            }
            else
            {
                ClientLog.LogError("#StateManager#changeState#curState is null!targetState=" + targetState);
            }
            return false;
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        public StateBase getCurState()
        {
            return this.curState;
        }

        public StateBase getLastState()
        {
            return this.lastState;
        }

        public StateBase getState(StateDef state)
        {
            StateBase stateV = null;
            this.stateDic.TryGetValue(state, out stateV);
            return stateV;
        }

        public bool hasState(StateDef state)
        {
            return this.stateDic.ContainsKey(state);
        }

        public override void Update()
        {
            if (this.curState != null)
            {
                this.curState.onUpdate();
            }

            if (Time.unscaledTime - mLastCheckMemCacheLeakTime >= 30.0f)
            {
                MemCache.CheckLeak();
                mLastCheckMemCacheLeakTime = Time.unscaledTime;
            }
        }

        public override void FixedUpdate()
        {
            if (this.curState != null)
            {
                this.curState.onFixedUpdate();
            }
        }

        public override void LateUpdate()
        {
            if (this.curState != null)
            {
                this.curState.onLateUpdate();
            }
        }

        public override void DoUpdate(float deltaTime)
        {
            if (this.curState != null)
            {
                this.curState.DoUpdate(deltaTime);
            }
        }

        public override void Start()
        {
            //初始化当前状态
            initCurState();
        }

        public string stateToString()
        {
            return this.curState.state.ToString();
        }

        public void ClearMemery()
        {
            ClientLog.LogWarning("ClearMemery");
            MemCache.DestroyAllFreeCaches();
            SourceManager.Ins.CheckForUnusedBundles();
            //Resources.UnloadUnusedAssets();

            if (Time.unscaledTime - mLastGCTime >= 300.0f)
            {
                //GC.Collect();
                mLastGCTime = Time.unscaledTime;
            }

            //SourceManager.Ins.LogAssetBundles();
        }

        public void SwitchAccount()
        {
            PlayerModel.Ins.IsFirstLogin = true;
            if (GameObject.Find("accountSwitched") == null)
            {
                GameObject accountSwitchedGo = new GameObject("accountSwitched");
                GameObject.DontDestroyOnLoad(accountSwitchedGo);
            }
            
            GameObject.DestroyImmediate(GameObject.Find("EventSystem"));

            GameConnection.Instance.onBackToLogin();
            ZoneCharacterManager.ins.RemoveAll();
            ZoneNPCManager.Ins.Clear();
            //ZoneUI.ins.Destroy();
            //BattleUI.ins.Destroy();
            //PreLoadingView.Ins.Destroy();
            //NpcChatView.Ins.Destroy();
            GuideManager.Ins.Destroy();
            //PopUseWnd.Ins.Destroy();
            UICreator.ins.ClearPreCachedUI();
            AvatarTextManager.Ins.Clear();
            MemCache.DestroyAllPools();
            AudioManager.Ins.DestroyAll();
            EffectUtil.Ins.Clear();

            changeState(StateDef.init);

            Singleton.DestroyAll();
            UGUIConfig.Destroy();
            ConstantModel.Ins.Clear();
            InputManager.Ins.Clear();
            AbsModel.DestroyAllModel();
            EventCore.Clear();
            MsgHandlerRegister.Clear();
            Human.Instance.onBackToLogin();

            //GameClient.ins.initViewCanvas.SetActive(true);
            //GameClient.ins.initViewServerSelecter.SetActive(true);

            GameObject.DestroyImmediate(GameObject.Find("ScriptsRoot").GetComponent<GameClient>(), true);
            //GameObject.DestroyImmediate(GameObject.Find("cachedDisplayModels"), true);
            Application.UnloadLevel(0);

            SourceManager.Ins.Clear();

            Application.LoadLevel("GameClient");

            GC.Collect();

        }
    }
}