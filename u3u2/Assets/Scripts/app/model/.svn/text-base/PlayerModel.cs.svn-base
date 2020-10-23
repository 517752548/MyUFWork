using app.battle;
using app.human;
using app.net;
using app.config;
using app.state;
using app.system;
using app.zone;
using app.db;
using app.gameloading;
using app.report;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.model
{
    public class PlayerModel : AbsModel
    {
        /***
         * CGPlayerLogin
         * GCRoleListEvent
         * CGPlayerEnter
         * GCSceneInfoEvent
         * sendCGEnterScene
         * ****
         * GCPopupPanelEndEvent
         */
        public const string ENTER_SCENE = "ENTER_SCENE";
        public const string GCROLENAME = "GCROLENAME";
        public const string UPDATE_VIP_INFO = "UPDATE_VIP_INFO";
        public const string UPDATE_LOGIN_DAYS = "UPDATE_LOGIN_DAYS";
        public bool isLoginFinished { get; set; }
        public int battlePlaySpeed { get; set; }
        public int canBattlePlayFastForward { get; set; }
        private bool isFirstLogin = true;
        private bool needPlayerUpgradeEffect = false;
        private GCRoleList _roleList;
        private GCVipInfo myVipInfo;
        private GCBehaviorInfo behaviorInfoList;
        private GCChargeRecord chargetRecord;
        /// <summary>
        /// 已经登陆的天数
        /// </summary>
        private int hasLoginDays;
        /// <summary>
        /// 登陆后需要弹出的面板 信息
        /// </summary>
        private GCLoginPopPanel loginPopPanel;

        private CreatePetInfoData[] _roleTemplate;
        public CreatePetInfoData[] RoleTemplate
        {
            get { return _roleTemplate; }
            set { _roleTemplate = value; }
        }

        public GCRoleList RoleList
        {
            get { return _roleList; }
            set { _roleList = value; }
        }

        public string DefaultCreateRoleName
        {
            get { return defaultCreateRoleName; }
        }

        public bool NeedPlayerUpgradeEffect
        {
            get { return needPlayerUpgradeEffect; }
            set { needPlayerUpgradeEffect = value; }
        }

        private string defaultCreateRoleName;

        private bool mIsLoadingPreloadRes = false;
        private bool mIsAllPreloadResLoaded = false;

        public PlayerModel()
        {
        }
        private static PlayerModel _ins;
        public static PlayerModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    // _ins = Singleton.getObj(typeof(PlayerModel)) as PlayerModel;
                    _ins = new PlayerModel();
                }
                return _ins;
            }
        }

        public GCVipInfo MyVipInfo
        {
            get { return myVipInfo; }
            set
            {
                myVipInfo = value;
                if (ZoneCharacterManager.ins.self != null)
                {
                    ZoneCharacterManager.ins.self.VipLevel = GetMyVipLevel();
                }
                //ZoneCharacterManager.ins.updateSelfVIP();
                dispatchChangeEvent(UPDATE_VIP_INFO,myVipInfo);
            }
        }

        public GCBehaviorInfo BehaviorInfoList
        {
            get { return behaviorInfoList; }
            set { behaviorInfoList = value; }
        }

        public GCChargeRecord ChargetRecord
        {
            get { return chargetRecord; }
            set
            {
                chargetRecord = value; 
            }
        }

        /// <summary>
        /// 已经登陆的天数
        /// </summary>
        public int HasLoginDays
        {
            get { return hasLoginDays; }
            set
            {
                int lastlogindays = hasLoginDays;
                hasLoginDays = value;
                if (lastlogindays != hasLoginDays)
                {
                    dispatchChangeEvent(UPDATE_LOGIN_DAYS,hasLoginDays);
                }
            }
        }

        /// <summary>
        /// 登陆后需要弹出的面板 信息
        /// </summary>
        public GCLoginPopPanel LoginPopPanel
        {
            get { return loginPopPanel; }
            set { loginPopPanel = value; }
        }

        public bool IsFirstLogin
        {
            get { return isFirstLogin; }
            set { isFirstLogin = value; }
        }

        /// <summary>
        /// 获得活动行为的可执行的上限次数
        /// </summary>
        /// <param name="behaviorId"></param>
        /// <returns></returns>
        public int GetBehaviorMaxCount(int behaviorId)
        {
            for (int i = 0; i < BehaviorInfoList.getBehaviorInfos().Length; i++)
            {
                if (behaviorInfoList.getBehaviorInfos()[i].bIndex==behaviorId)
                {
                    return behaviorInfoList.getBehaviorInfos()[i].max;
                }
            }
            return -1;
        }

        public int GetMyVipLevel()
        {
            if (myVipInfo==null)
            {
                return 0;
            }
            if (myVipInfo.getLevel() > ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.VIP_MAX_LEVEL))
            {
                return ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.VIP_MAX_LEVEL);
            }
            return myVipInfo.getLevel();
        }

        public int GetMyVipEXP()
        {
            if (myVipInfo == null)
            {
                return 0;
            }
            return myVipInfo.getExp();
        }

        public bool IsMyVipMax()
        {
            if (myVipInfo == null)
            {
                return false;
            }
            return myVipInfo.getLevel()==ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.VIP_MAX_LEVEL);
        }

        public void handleGCEnterScene()
        {
            isLoginFinished = true;
            GameConnection.Instance.HasConnected = true;
            dispatchChangeEvent(ENTER_SCENE, null);
            enterGame();
            //登陆汇报热云
            ClientLog.LogWarning("Call ReYun.Game_Login with param:" + Human.Instance.Pid + "," + ServerConfig.instance.serverId + "," + Human.Instance.PetModel.getLeader().getLevel());
            //ReYun.Instance.Game_Login(Human.Instance.Pid, ServerConfig.instance.SelectServerId, Human.Instance.PetModel.getLeader().getLevel());
            DataReport.Instance.Game_Login(Human.Instance.Pid, ServerConfig.instance.serverId, Human.Instance.PetModel.getLeader().getLevel());
        }

        public void handleGCRoleName(string name)
        {
            defaultCreateRoleName = name;
            dispatchChangeEvent(GCROLENAME, name);
        }

        public void loginGame()
        {
            SetupDB();
            
            //string passportId = RoleList.getPassportId();
            if (RoleList.getRoleList().Length > 0)
            {
                long uuid = RoleList.getRoleList()[RoleList.getSelectedIndex()].roleUUID;
                Human.Instance.Id = uuid;
                PlayerCGHandler.sendCGPlayerEnter(uuid);
                PlayerDataManager.Ins.CheckRoleChange();
				if(RoleList.getRoleList()[RoleList.getSelectedIndex()].firstLogin==1)
                {
					DataReport.Instance.Game_Regiester(RoleList.getRoleList()[RoleList.getSelectedIndex()].name);
				}
                if (WndManager.Ins.IsWndShowing(GlobalConstDefine.CreateRoleView_Name))
                {
                    WndManager.Ins.close(GlobalConstDefine.CreateRoleView_Name);
                }
            }
            else
            {
                PlayerCGHandler.sendCGRoleTemplate();
            }

            BattleModel.ins.canUpdate = false;
        }

        public override void Destroy()
        {
            isLoginFinished = false;
            needPlayerUpgradeEffect = false;
            _roleList = null;
            _roleTemplate = null;
            defaultCreateRoleName = null;
            mIsLoadingPreloadRes = false;
            mIsAllPreloadResLoaded = false;
            _ins = null;
        }

        public void enterGame()
        {
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.LoginView_Name))
            {
                WndManager.Ins.close(GlobalConstDefine.LoginView_Name);
            }
            else if (WndManager.Ins.IsWndShowing(GlobalConstDefine.CreateRoleView_Name))
            {
                WndManager.Ins.close(GlobalConstDefine.CreateRoleView_Name);
            }
            ClientLog.Log("enter game!!");
            //  DCEvent.onEvent("login_enter_game_scene");
            if (!mIsLoadingPreloadRes && !mIsAllPreloadResLoaded)
            {
                LoadResources();
            }
            else
            {
                OnAllResourcesLoadComplete(null);
            }
        }

        private void LoadResources()
        {
            mIsLoadingPreloadRes = true;
            List<object[]> loadingList = new List<object[]>();
            loadingList.Add(new object[]{PathUtil.Ins.activityIconAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.headAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.itemAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.skillAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.xinfaAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.chongzhiAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.skillNameAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.skillEffectNameAtlasPath, LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetUIPath("Scrollbar"), LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("shadow_shadow"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_lingpai"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_miaozhun"), LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_zhandou"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{"battleGroundMask.abl", LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_kaishizhandou"), LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_xuanzhong02"), LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_tanhao"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_wenhao"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath("common_SelectedEffect"), LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetUIPath("mainUIPanel"), LoadArgs.NONE, LoadContentType.ABL});
            loadingList.Add(new object[]{PathUtil.Ins.GetEffectPath(ClientConstantDef.CLICK_GROUND_EFFECT_NAME), LoadArgs.SLIMABLE, LoadContentType.ABL});
            for (int i = 0; i < PathUtil.Ins.RoleModelNameList.Count; i++)
            {
                string[] roleModelPathes = PathUtil.Ins.GetCharacterDisplayModelPath(PathUtil.Ins.RoleModelNameList[i]);
                loadingList.Add(new object[]{roleModelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
                loadingList.Add(new object[]{roleModelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            }

            string[] shizhuangNanModelPathes = PathUtil.Ins.GetCharacterDisplayModelPath("shizhuang_nan");
            loadingList.Add(new object[]{shizhuangNanModelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{shizhuangNanModelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});

            string[] shizhuangNvModelPathes = PathUtil.Ins.GetCharacterDisplayModelPath("shizhuang_nv");
            loadingList.Add(new object[]{shizhuangNvModelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
            loadingList.Add(new object[]{shizhuangNvModelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});

            for (int i = 0; i < PathUtil.Ins.NpcModelNameList.Count; i++)
            {
                if (PathUtil.Ins.NpcModelNameList[i] == "chuansongdian")
                {
                    string[] npcModelPathes = PathUtil.Ins.GetCharacterDisplayModelPath(PathUtil.Ins.NpcModelNameList[i], false);
                    loadingList.Add(new object[]{npcModelPathes[0], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
                }
                else
                {
                    string[] npcModelPathes = PathUtil.Ins.GetCharacterDisplayModelPath(PathUtil.Ins.NpcModelNameList[i]);
                    loadingList.Add(new object[]{npcModelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
                    loadingList.Add(new object[]{npcModelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
                }
            }

            Dictionary<int, WingTemplate> wingTpls = WingTemplateDB.Instance.getIdKeyDic();
            IDictionaryEnumerator enumerator = wingTpls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                WingTemplate wingTpl = (WingTemplate)enumerator.Value;
                string[] wingModelPathes = PathUtil.Ins.GetWingPath(wingTpl.modelId);
                loadingList.Add(new object[]{wingModelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
                loadingList.Add(new object[]{wingModelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            }

            //四大神兽
            string[] shenshou = new string[]{"bp_qinglong", "baihu", "zhuque", "bp_xuanwu"};
            for (int i = 0; i < 4; i++)
            {
                string[] modelPathes = PathUtil.Ins.GetCharacterDisplayModelPath(shenshou[i]);
                loadingList.Add(new object[]{modelPathes[0], LoadArgs.SLIMABLE, LoadContentType.ABL});
                loadingList.Add(new object[]{modelPathes[1], LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});
            }

            string battleBGM = PathUtil.Ins.GetMusicPath(ClientConstantDef.BATTLE_BG_MUSIC_NAME, AudioEnumType.BackGround);
            loadingList.Add(new object[]{battleBGM, LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});

            string battleUIPath = PathUtil.Ins.GetUIPath("battleUI");
            loadingList.Add(new object[]{battleUIPath, LoadArgs.SLIMABLE_INIT_MAIN_ASSET, LoadContentType.ABL});

            PreLoadingView.Ins.startLoading(loadingList, "正在处理本地资源", OnAllResourcesLoadComplete, OnOneResourcesLoadComplete, false);
        }

        private void OnOneResourcesLoadComplete(RMetaEvent e)
        {
            LoadInfo loadInfo = (e.data as List<object>)[2] as LoadInfo;
            SourceManager.Ins.ignoreDispose(loadInfo.urlPath);
            /*
            if (loadInfo.urlPath == PathUtil.Ins.headAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.itemAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.skillAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.xinfaAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.chongzhiAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.skillNameAtlasPath || 
                loadInfo.urlPath == PathUtil.Ins.skillEffectNameAtlasPath)
            {
                loadInfo.bundleContainer.SlimableNow();
            }
            */
        }

        private void OnAllResourcesLoadComplete(RMetaEvent e)
        {
            CacheCustomFonts();
            mIsLoadingPreloadRes = false;
            mIsAllPreloadResLoaded = true;
            //SetupDB();
            //进入主场景
            StateManager.Ins.changeState(StateDef.zoneState);
            //进入场景后，给服务器发送最后一次失败的消息
            GameConnection.Instance.onReloginFinished();
            BattleModel.ins.canUpdate = true;
            AudioManager.Ins.SetYinYueMute(!SystemSettings.ins.isPlayBackgroundSound);
            AudioManager.Ins.SetYinXiaoMute(!SystemSettings.ins.isPlayEffectSound);
        }

        private void CacheCustomFonts()
        {
            int[] chineseFontSizes = new int[]{20, 22, 24};
            int[] englishFontSizes = new int[]{14, 16, 18, 20, 22, 24};
            Font font = SourceManager.Ins.defaultFont;
            for (int i = 0; i < 3; i++)
            {
                font.RequestCharactersInTexture(LangConstant.ALL_CHINESE, chineseFontSizes[i], FontStyle.Normal);
            }

            for (int i = 0; i < 6; i++)
            {
                font.RequestCharactersInTexture(LangConstant.ALL_ENGLISH, englishFontSizes[i], FontStyle.Normal);
            }
        }
        
        /// <summary>
        /// 处理登陆弹出框，有弹出返回true，无弹出 返回false
        /// </summary>
        /// <returns></returns>
        public bool PopLoginPanel()
        {
            if (IsFirstLogin)
            {
                IsFirstLogin = false;
                //有引导的时候不弹框
                bool isShowingGuide = GuideManager.Ins.isShowingGuide();
                bool hasGuideWaitingShow = GuideManager.Ins.hasGuideWaitingShow();
                if (loginPopPanel != null && !isShowingGuide && !hasGuideWaitingShow)
                {
                    LinkParse.Ins.linkToFunc(loginPopPanel.getFuncId());
                    return true;
                }
            }
            return false;
        }

        private void SetupDB()
        {
            string dbFile = PathUtil.Ins.extFilesRoot + "/db";
            // 连接db
            DbAccess.Instance.connDB("URI=file:" + dbFile);

            // 从db中获取数据，初始化所有的配置文件对象*DB.cs
            LoadCfg loader = new LoadCfg();
            loader.initAllCfg();

            // XXX 如果不断开链接，再次运行时，db文件删除不掉，会报错
            DbAccess.Instance.CloseSqlConnection();
        }
    }
}
