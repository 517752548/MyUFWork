using System;
using System.Collections.Generic;
using app.fuben;
using app.gameloading;
using app.story;
using UnityEngine;
using UnityEngine.UI;
using app.db;
using app.net;
using app.state;
using app.battle;
using app.model;
using app.avatar;
using app.main;
using app.tongtianta;
using app.report;

namespace app.zone
{
    public class ZoneManager
    {
        public bool curZoneInited { get; private set; }

        private bool mFirstEnterZoneAfterLogin = false;

        private ZoneCharacter mTouchedPlayer = null;

        //private GameObject mClickGroundEffectContainer = null;
        //private GameObject mClickGroundEffect = null;

        /// <summary>
        /// 定时 检查 的时间间隔，单位:s
        /// </summary>
        private int checkInterval = 60;
        /// <summary>
        /// 上次检查的时间
        /// </summary>
        private float lastCheckTime = 0;

        private GameObject mScrShotContainer = null;
        private Vector2 mScrShotSize = Vector2.zero;
        private RawImage mScrShotImg = null;
        private float mHideScrShotContainerCD = 0.0f;
        private bool mIsLoadingScene = false;

        private static ZoneManager mIns = new ZoneManager();

        public static ZoneManager ins
        {
            get
            {
                return mIns;
            }
        }

        public ZoneManager()
        {
            if (ZoneManager.ins != null)
            {
                throw new Exception("ZoneManager instance already exists!");
            }

            //mPlayerModel = Singleton.getObj(typeof(PlayerModel)) as PlayerModel;
        }

        public void EnterZoneState()
        {
            if (ZoneModel.ins.mapTpl == null || ZoneModel.ins.mapTpl.Id != ZoneModel.ins.tryEnterZoneId)
            {
                if (mIsLoadingScene)
                {
                    return;
                }
                mIsLoadingScene = true;
                if (ZoneModel.ins.zoneMap != null)
                {
                    //ZoneModel.ins.zoneMap.Destroy();
                }
                else
                {
                    mFirstEnterZoneAfterLogin = true;
                }

                ZoneModel.ins.isZoneLoaded = false;
                ZoneModel.ins.ClearLoadedList();
                ZoneCharacterManager.ins.ClearCharacters();
                ZoneNPCManager.Ins.ClearNpc();

                if (ZoneModel.ins.mapTpl != null)
                {
                    //SceneModel.ins.Clear();
                    //SceneManager.UnloadScene(ZoneModel.ins.mapTpl.icon);
                    //Application.UnloadLevel(0);
                    SourceManager.Ins.ClearAllReference(PathUtil.Ins.GetZoneScenePath(ZoneModel.ins.mapTpl.icon));
                    //SourceManager.Ins.ClearAllReference(PathUtil.Ins.GetZoneSceneMapTilesPath(ZoneModel.ins.mapTpl.icon));
                    StateManager.Ins.ClearMemery();
                }

                ZoneModel.ins.mapTpl = MapTemplateDB.Instance.getTemplate(ZoneModel.ins.tryEnterZoneId);
                ZoneModel.ins.mapPixelWidth = ZoneModel.ins.mapTpl.width;
                ZoneModel.ins.mapPixelHeight = ZoneModel.ins.mapTpl.height;
                ZoneModel.ins.zoneTime = 0f;
                ZoneModel.ins.fixedZoneTime = 0f;
                List<object[]> loadingList = ZoneModel.ins.CreateLoadList(ZoneModel.ins.mapTpl);
                //PreLoadingView.Ins.startLoading(loadingList, "正在加载地图资源...", AllResLoadComplete, OneResLoadComplete, false);
                SourceLoader.Ins.loadList(loadingList, AllResLoadComplete, null);
                ZoneCharacterManager.ins.othersCountForFPS = 0;
                curZoneInited = false;

                if (mFirstEnterZoneAfterLogin)
                {
                    DataReport.Instance.ReportPlayerData(
                        human.Human.Instance.Id,
                        human.Human.Instance.getName(), 
                        human.Human.Instance.getLevel().ToString(), 
                        ZoneModel.ins.mapTpl.Id.ToString(), 
                        ZoneModel.ins.mapTpl.name,human.Human.Instance.CreateTime);
                }

                
            }
            else
            {
                if (BattleModel.ins.roundData.Count == 0)
                {
                    InitZone();
                    ///如果战报类型为竞技场则手动再次打开竞技场界面///
                    if (5 == BattleModel.ins.battleToBackType)
                    {
                        BattleModel.ins.LinkToBackType();
                    }
                }
                else
                {
                    StateManager.Ins.changeState(StateDef.battleState);
                }
            }

            lastCheckTime = Time.unscaledTime;
        }

        /*
        private void createClickGroundEffect()
        {
            if (mClickGroundEffect == null)
            {
                mClickGroundEffectContainer = new GameObject("ClickGroundEffectContainer");
                mClickGroundEffect =
                    SourceManager.Ins.createObjectFromAssetBundle(
                        PathUtil.Ins.GetEffectPath(ClientConstantDef.CLICK_GROUND_EFFECT_NAME));
                mClickGroundEffectContainer.transform.SetParent(SceneModel.ins.zoneModelContainer.transform);
                mClickGroundEffectContainer.transform.localPosition = Vector3.zero;
                mClickGroundEffectContainer.transform.position = Vector3.zero;

                mClickGroundEffect.transform.SetParent(mClickGroundEffectContainer.transform);
                GameObjectUtil.SetLayer(mClickGroundEffectContainer, SceneModel.ins.zoneModelContainer.layer);
                mClickGroundEffect.transform.localPosition = Vector3.zero;
                mClickGroundEffect.transform.position = Vector3.zero;
                mClickGroundEffect.transform.localEulerAngles = Vector3.zero;
                mClickGroundEffect.SetActive(false);
            }
        }
        */

        /*
        public void OneResLoadComplete(RMetaEvent e)
        {
            LoadInfo _info = (LoadInfo)((e.data as List<object>)[2]);
            string _path = _info.urlPath;
            SourceManager.Ins.ignoreDispose(_path);

            if (ZoneModel.ins.IsNeedInitMainAsset(_path))
            {
                if (_info != null && _info.bundleContainer != null) _info.bundleContainer.InitMainAsset();
            }
        }
        */

        public void AllResLoadComplete(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                GameSceneManager.Ins.LoadUnityScene(ZoneModel.ins.mapTpl.icon, ZoneSceneLoadProcess, ZoneSceneLoadComplete, false);
            }
        }

        private void ZoneSceneLoadProcess()
        {

        }

        private void ZoneSceneLoadComplete()
        {
            ClientLog.Log("==========ZoneSceneLoadComplete==========");

            mIsLoadingScene = false;

            if (ZoneModel.ins.mapTpl.Id != ZoneModel.ins.tryEnterZoneId)
            {
                EnterZoneState();
                return;
            }
            /*
            if (ZoneCharacterManager.ins.self != null)
            {
                return;
            }
            */
            SceneModel.ins.InitScene();
            Camera cam = SceneModel.ins.zoneGroundCam.GetComponent<Camera>();
            ZoneModel.ins.viewportHeight = cam.orthographicSize * 2;
            //ZoneModel.ins.viewportWidth = ZoneModel.ins.viewportHeight * Screen.width / Screen.height;
            ZoneModel.ins.viewportWidth = ZoneModel.ins.viewportHeight * UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight;

            int leftTopPixelX = ZoneModel.ins.playerStartLeftTopPixelX;
            int leftTopPixelY = ZoneModel.ins.playerStartLeftTopPixelY;
            Vector3 playerPos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));
            ZoneCameraManager.ins.Update(playerPos, false);
            
            if (ZoneCharacterManager.ins.self != null)
            {
                ZoneCharacterManager.ins.self.SetActive(false);
            }

            if (ZoneModel.ins.zoneMap != null)
            {
                ZoneModel.ins.zoneMap.Destroy();
            }
            ZoneModel.ins.zoneMap = new ZoneMap();
            ZoneModel.ins.zoneMap.Init(ZoneModel.ins.mapTpl.icon);
            ZoneModel.ins.zoneMap.InitMapTiles(playerPos, OnMapTilesInited);
            ZonePlayerTrackPointManager.ins.Init();
            //createClickGroundEffect();
            /*
            if (PropertyUtil.IsLegalID(ZoneModel.ins.mapTpl.meetMonsterPlanId))
            {
                BattleManager.ins.CreateBattleStartEffect();
            }
            */
            if (BattleModel.ins.roundData.Count > 0)
            {
                /*
                ClientLog.Log("登录后直接进战斗");
                //登录后直接进战斗。
                //ZoneUI.ins.Init();
                //int leftTopPixelX = ZoneModel.ins.playerStartLeftTopPixelX;
                //int leftTopPixelY = ZoneModel.ins.playerStartLeftTopPixelY;
                Camera cam = SceneModel.ins.zoneGroundCam.GetComponent<Camera>();
                float viewportHeight = cam.orthographicSize * 2;
                //float viewportWidth = viewportHeight * Screen.width / Screen.height;
                float viewportWidth = viewportHeight * UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight;

                float camHalfW = viewportWidth / 2f;
                float camHalfH = viewportHeight / 2f;
                float mapHalfW = (float)ZoneModel.ins.mapPixelWidth / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;
                float mapHalfH = (float)ZoneModel.ins.mapPixelHeight / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;

                //GameObject camera = SceneModel.ins.zoneCamsContainer;
                //Vector3 camPos = camera.transform.localPosition;
                //Vector3 playerPos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));
                //camPos = ZoneCameraManager.ins.GetCamPos(camHalfW, camHalfH, mapHalfW, mapHalfH, camPos, playerPos);
                //camera.transform.localPosition = camPos;
                //ZoneCameraManager.ins.Update(playerPos, false);
                */
                //ZoneModel.ins.zoneMap.InitMapTiles(playerPos, OnMapTilesInited);
                StateManager.Ins.changeState(StateDef.battleState);
                //WndManager.Ins.close(GlobalConstDefine.PreLoadingView_Name);

            }
            else
            {
                //ZoneModel.ins.zoneMap.InitMapTiles(playerPos, OnMapTilesInited);
                //InitZone();
                //WndManager.Ins.close(GlobalConstDefine.PreLoadingView_Name);
                //PreLoadingView.Ins.hide(null);
            }

            ZoneModel.ins.isZoneLoaded = true;

            /*
            if (mScrShotContainer != null)
            {
                mScrShotContainer.SetActive(false);
            }
            */
        }

        private void OnMapTilesInited()
        {
            if (mScrShotImg != null)
            {
                mScrShotImg.CrossFadeAlpha(0, 0.5f, false);
                mHideScrShotContainerCD = 0.5f;
            }

            if (mFirstEnterZoneAfterLogin)
            {
                DataReport.Instance.Game_SetEvent("c_shown", "view", "main");
                mFirstEnterZoneAfterLogin = false;
                //WndManager.Ins.close(GlobalConstDefine.LoginView_Name);
            }

            if (StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                InitZone();
            }

            //SourceLoader.Ins.loadList(ZoneModel.ins.GetMapMonstersLoadList(ZoneModel.ins.mapTpl));
        }

        public void InitZone()
        {
            ClientLog.Log("InitZone");
            ZoneUI.ins.Init();
            ZoneUI.ins.showAll();
            SceneModel.ins.InitZoneScene();
            /*
            if (ZoneCharacterManager.ins.self != null)
            {
                ZoneCharacterManager.ins.self.SetActive(true);
            }
            */
            /*  
            Camera cam = SceneModel.ins.zoneGroundCam.GetComponent<Camera>();
            ZoneModel.ins.viewportHeight = cam.orthographicSize * 2;
            //ZoneModel.ins.viewportWidth = ZoneModel.ins.viewportHeight * Screen.width / Screen.height;
            ZoneModel.ins.viewportWidth = ZoneModel.ins.viewportHeight * UGUIConfig.ScreenWidth / UGUIConfig.ScreenHeight;
            */
            //AvatarTextManager.Ins.avatarCam = SceneModel.ins.zone3DModelCam.GetComponent<Camera>();
            //AvatarTextManager.Ins.SetActive(true);
            //ZoneCharacterManager.ins.ShowCharacters();
            /*
            if (ZoneCharacterManager.ins.self != null)
            {
                StateBase lastState = StateManager.Ins.getLastState();
                if (lastState != null && lastState.state != StateDef.battleState && lastState.state != StateDef.storyState)
                {
                    ZoneCharacterManager.ins.ClearCharacters();
                }
            }
            */

            if (ZoneCharacterManager.ins.self != null)
            {
                StateBase lastState = StateManager.Ins.getLastState();
                if (lastState != null && lastState.state != StateDef.battleState && lastState.state != StateDef.storyState)
                {
                    ZoneCharacterManager.ins.Init();
                }

                ZoneCharacterManager.ins.self.SetActive(true);
            }
            else
            {
                ZoneCharacterManager.ins.Init();
            }
            ZoneNPCManager.Ins.Init();
            AvatarTextManager.Ins.SetActive(true);
            
            //检查是否首次登陆，播放第一个战斗剧情
            if (PlayerModel.Ins.RoleList.getRoleList()[PlayerModel.Ins.RoleList.getSelectedIndex()].firstLogin == 1
                &&!StoryManager.ins.HasPlayVideo)
            {
                ClientLog.LogWarning("进入战斗剧情！");
                StoryManager.ins.HasPlayVideo = true;
                StoryManager.ins.EnterStory(1, true);
            }
            else
            {
                //检查是否有引导显示
                ZoneUI.ins.checkNewFuncAndGuide();
            }
            ZoneBubbleManager.ins.isCanBubble = true;
            PlayMapBgMusic();
            GameClient.ins.DoShortcut();
            
            ZoneCharacter self = ZoneCharacterManager.ins.self;
            if (self != null)
            {
                ZoneCameraManager.ins.Update(self.localPosition, false);
            }
            

            //SourceLoader.Ins.loadList(ZoneModel.ins.GetMapMonstersLoadList(ZoneModel.ins.mapTpl));

            curZoneInited = true;

            //if (StateManager.Ins.getLastState().state == StateDef.battleState)
            //{
            //    BattleModel.ins.LinkToBackType();
            //}
            //进入副本条件判断
            app.fuben.FubenManager.Instance.FubenEnter();

            PreLoadingView.Ins.hide(null);
        }

        public void ExitZoneState(StateDef nextState)
        {
            ZoneCharacter self = ZoneCharacterManager.ins.self;
            if (self != null)
            {
                if (self.displayModel != null && self.displayModel.avatar != null)
                {
                    ZoneModel.ins.selfRot = ZoneCharacterManager.ins.self.localEulerAngles;
                }

                if (self.curBehavType == ZoneCharacterBehavType.MOVE)
                {
                    self.Idle();
                }
            }

            if (nextState == StateDef.zoneState)
            {
                /*
                if (ZoneModel.ins.tryEnterZoneId != ZoneModel.ins.mapTpl.Id)
                {e
                    if (SceneModel.ins.zoneCamsContainer != null)
                    {
                        if (mScrShotContainer == null)
                        {
                            Canvas cav = UGUIConfig.GetCanvasByWndType(WndType.MAINUI);
                            mScrShotContainer = new GameObject("screenShotContainer");
                            mScrShotContainer.layer = cav.gameObject.layer;
                            mScrShotContainer.transform.SetParent(cav.transform);
                            mScrShotContainer.transform.localScale = Vector3.one;
                            mScrShotContainer.AddComponent<RectTransform>();
                            Canvas screenShotCanvas = mScrShotContainer.AddComponent<Canvas>();
                            screenShotCanvas.overrideSorting = true;
                            screenShotCanvas.sortingOrder = -1;
                            mScrShotContainer.AddComponent<CanvasRenderer>();
                            mScrShotImg = mScrShotContainer.AddComponent<RawImage>();
                            mScrShotContainer.SetActive(false);
                            mScrShotSize = cav.GetComponent<RectTransform>().sizeDelta;
                        }

                        //ZoneCharacterManager.ins.self.SetActive(false);
                        //GameClient.ins.StartCoroutine(ZoneCameraManager.ins.ScreenShot(new Camera[]{SceneModel.ins.zoneGroundCam.GetComponent<Camera>(), SceneModel.ins.zone3DModelCam.GetComponent<Camera>()}, UGUIConfig.ScreenWidth, UGUIConfig.ScreenHeight));
                        mScrShotImg.color = new Color(1, 1, 1, 1);
                        mScrShotImg.texture = ZoneCameraManager.ins.ScreenShot(new Camera[]{ SceneModel.ins.zoneGroundCam.GetComponent<Camera>(), SceneModel.ins.zone3DModelCam.GetComponent<Camera>()}, (int)mScrShotSize.x, (int)mScrShotSize.y);
                        mScrShotImg.SetNativeSize();
                        mScrShotContainer.SetActive(true);
                        //ZoneCharacterManager.ins.self.SetActive(true);
                    }
                }
                */
            }
            else
            {
                if (nextState != StateDef.battleState)
                {
                    ZoneUI.ins.hide();
                }

                if (nextState == StateDef.battleState || nextState == StateDef.storyState)
                {
                    if (self != null)
                    {
                        ZoneCameraManager.ins.Update(self.localPosition, false);
                    }
                    ZoneCharacterManager.ins.Update();
                    ZoneNPCManager.Ins.Update();
                }

                //AvatarTextManager.Ins.SetActive(false);
                //ZoneCharacterManager.ins.HideCharacters();
                //ZoneNPCManager.Ins.HideNPCs();
            }

            /*
            if (nextState == StateDef.battleState)
            {
                if (self != null)
                {
                    ZoneCameraManager.ins.Update(self.localPosition, false);
                }
            }
            */
            
            ZoneBubbleManager.ins.Clear();
            ZoneBubbleManager.ins.isCanBubble = false;
            ZonePlayerTrackPointManager.ins.HideAll();
            curZoneInited = false;
        }

        public void Update()
        {
            if (!curZoneInited)
            {
                return;
            }

            ZoneModel.ins.zoneTime += Time.deltaTime / Time.timeScale;

            if (Input.GetMouseButtonDown(0))
            {
                ZoneNPC touchedNPC = GetTouchedNPC();
                if (touchedNPC != null)
                {
                    ClientLog.Log("======点到NPC了======");
                    mTouchedPlayer = null;
                    if (ZoneModel.ins.CheckCanMoveFreely())
                    {
                        //停止自动寻路
                        AutoMaticManager.Ins.StopAutoMatic();
                        //绿野仙踪开启自动打怪
                        FubenlyxzModel.ins.startAutoBattle();

                        ZoneNPCManager.Ins.ClickNpc(touchedNPC);
                        ClientLog.LogWarning("点击的npc" + touchedNPC.NpcInfoData.uuid);
                    }
                }
                else
                {
                    ZoneCharacter touchedPlayer = GetTouchedPlayer();
                    if (touchedPlayer != null)
                    {
                        ClientLog.Log("======点到别的玩家了======");
                        mTouchedPlayer = touchedPlayer;
                        //ZoneBubbleManager.ins.BubbleSysMsg("<color=#00FF00>点到其他玩家，显示玩家信息面板:" + touchedPlayer.name + "</color>");
                        if (ZoneModel.ins.CheckCanMoveFreely())
                        {
                            //停止自动寻路
                            AutoMaticManager.Ins.StopAutoMatic();
                            //跑到对方角色身边
                            //ZoneCharacter me = ZoneCharacterManager.ins.player;
                            //float myRadius = me.isRiding ? me.ridingPet.displayModel.radiusMax : me.displayModel.radiusMax;
                            //float touchedPlayerRadius = touchedPlayer.isRiding ? touchedPlayer.ridingPet.displayModel.radiusMax : touchedPlayer.displayModel.radiusMax;
                            //ZoneCharacterManager.ins.player.MoveTo(touchedPlayer.localPosition, (myRadius + touchedPlayerRadius) + 0.5f, false, OnMoveToOtherPlayerByClickComplete);
                            //不需要跑到对方角色身边
                            OnMoveToOtherPlayerByClickComplete();
                        }
                    }
                    else
                    {
                        Vector3 touchedPosition;
                        if (CheckTouchedGround(out touchedPosition))
                        {
                            ClientLog.Log("======点到地面了======");
                            mTouchedPlayer = null;
                            if (ZoneModel.ins.CheckCanMoveFreely())
                            {
                                //点击地面时候 停止任务的自动寻怪
                                //停止自动寻路
                                AutoMaticManager.Ins.StopAutoMatic();
                                ZoneCharacterManager.ins.self.MoveTo(touchedPosition, 0, false);
                                ZonePlayerTrackPointManager.ins.ShowOne(touchedPosition);
                            }
                        }
                    }
                }
            }

            ZoneCameraManager.ins.Update(ZoneCharacterManager.ins.self.localPosition);
            ZoneCharacterManager.ins.Update();
            ZoneNPCManager.Ins.Update();
            //ZoneBubbleManager.ins.Update();
            ZoneUI.ins.Update();
            ZonePlayerTrackPointManager.ins.Update();

            if (mScrShotContainer != null)
            {
                if (mHideScrShotContainerCD > 0)
                {
                    mHideScrShotContainerCD -= Time.deltaTime;
                    if (mHideScrShotContainerCD < 0)
                    {
                        mScrShotContainer.SetActive(false);
                    }
                }
            }

            /*
            if (mClickGroundEffectContainer != null && mClickGroundEffect != null)
            {
                Vector3 v3 = ZoneUtil.GetFixedPosition(mClickGroundEffectContainer.transform);
                mClickGroundEffect.transform.localPosition = v3;
            }
            */
        }

        public void DoUpdate(float deltaTime)
        {
            if (Time.unscaledTime - lastCheckTime > checkInterval)
            {//固定时间间隔 检测
                WndManager.Ins.DestroyUnusedWnds();
                //MemCache.DestroyAllFreeCaches();
                //SourceManager.Ins.CheckForUnusedBundles();
                lastCheckTime = Time.unscaledTime;
            }
            ZoneUI.ins.DoUpdate(Time.unscaledTime);
        }

        private void OnMoveToOtherPlayerByClickComplete()
        {
            //如果在帮派竞赛里 直接发生战斗
            if (fuben.FubenbpjsModel.ins.IsInBpjs())
            {
                BattleCGHandler.sendCGBattleStartTeampvp(mTouchedPlayer.uuid);
            }
            else
            {
                PopRoleInfoWnd.Ins.ShowInfo(mTouchedPlayer.uuid, PopRoleInfoWnd.EStatue.Normal);
            }
        }

        private bool CheckTouchedGround(out Vector3 touchedPosition)
        {
            //获取屏幕坐标
            Vector3 mScreenPos = Input.mousePosition;
            Camera cam = SceneModel.ins.zoneGroundCam.GetComponent<Camera>();
            Ray mRay = cam.ScreenPointToRay(mScreenPos);
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {
                GameObject hitGameObj = mHit.transform.gameObject;
                if (hitGameObj != null && !UGUIConfig.IsPointUI())
                {
                    if (hitGameObj.name == GlobalConstDefine.SCENE_GROUND_MODEL_NAME)
                    {
                        Vector3 pos = mHit.point;
                        pos.y = 0;
                        //点到地面了。
                        /*
                        if (ZoneModel.ins.CheckCanMoveFreely())
                        {
                            ZoneCharacterManager.ins.player.MoveTo(pos, 0, false);
                        }
                        if (mClickGroundEffect != null)
                        {
                            mClickGroundEffectContainer.transform.localPosition = new Vector3(mHit.point.x, 0, mHit.point.z);
                            mClickGroundEffect.SetActive(false);
                            mClickGroundEffect.SetActive(true);
                        }
                        */
                        touchedPosition = pos;
                        return true;
                    }
                }
            }
            touchedPosition = Vector3.zero;
            return false;
        }

        private ZoneNPC GetTouchedNPC()
        {
            //获取屏幕坐标
            Vector3 mScreenPos = Input.mousePosition;
            Camera cam = SceneModel.ins.zone3DModelCam.GetComponent<Camera>();
            Ray mRay = cam.ScreenPointToRay(mScreenPos);
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {
                GameObject hitGameObj = mHit.transform.gameObject;
                if (hitGameObj != null && hitGameObj.transform.parent != null && !UGUIConfig.IsPointUI())
                {
                    return ZoneNPCManager.Ins.GetNpc(hitGameObj);
                }
            }
            return null;
        }

        private ZoneCharacter GetTouchedPlayer()
        {
            //获取屏幕坐标
            Vector3 mScreenPos = Input.mousePosition;
            Camera cam = SceneModel.ins.zone3DModelCam.GetComponent<Camera>();

            if (cam == null)
            {
                ClientLog.LogError("GetTouchedPlayer:cam is null!");
                return null;
            }

            Ray mRay = cam.ScreenPointToRay(mScreenPos);
            RaycastHit mHit;

            try
            {
                if (Physics.Raycast(mRay, out mHit))
                {
                    GameObject hitGameObj = mHit.transform.gameObject;
                    if (hitGameObj != null && hitGameObj.transform.parent != null && !UGUIConfig.IsPointUI())
                    {
                        int othersCount = ZoneCharacterManager.ins.othersCount;
                        for (int i = 0; i < othersCount; i++)
                        {
                            ZoneCharacter other = ZoneCharacterManager.ins.others[i];
                            if (other.displayModel == null)
                            {
                                ClientLog.LogError("GetTouchedPlayer:other.displayModel is null!");
                                return null;
                            }

                            if (other.displayModel.avatar == null)
                            {
                                ClientLog.LogError("GetTouchedPlayer:other.displayModel.avatar is null!");
                                return null;
                            }

                            if (other.displayModel.avatar == hitGameObj)
                            {
                                return other;
                            }
                            /*
                            if (other.isRiding && other.ridingPet != null)
                            {
                                if (other.ridingPet.displayModel == null)
                                {
                                    ClientLog.LogError("GetTouchedPlayer:other.ridingPet.displayModel is null!");
                                    return null;
                                }

                                if (other.ridingPet.displayModel.avatar == null)
                                {
                                    ClientLog.LogError("GetTouchedPlayer:other.ridingPet.displayModel.avatar is null!");
                                    return null;
                                }
                                
                                if (other.ridingPet.displayModel.avatar == hitGameObj)
                                {
                                    return other;
                                }
                            }
                            */
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ClientLog.LogError(e.Message);
            }

            return null;
        }

        private void PlayMapBgMusic()
        {
            MapTemplate mt = MapTemplateDB.Instance.getTemplate(ZoneModel.ins.mapTpl.Id);
            if (mt != null)
            {
                AudioManager.Ins.PlayAudio(mt.music, AudioEnumType.BackGround);
            }
        }


        public void FixedUpdate()
        {
            if (!curZoneInited)
            {
                return;
            }

            ZoneModel.ins.fixedZoneTime += Time.fixedDeltaTime / Time.timeScale;

            ZoneCameraManager.ins.FixedUpdate();
            ZoneCharacterManager.ins.FixedUpdate();
            ZoneNPCManager.Ins.FixedUpdate();
            ZoneUI.ins.FixedUpdate();
        }

        public void LateUpdate()
        {
            if (!curZoneInited)
            {
                return;
            }

            ZoneCharacterManager.ins.LateUpdate();
            ZoneNPCManager.Ins.LateUpdate();
        }

        public void SetPlayerEnterZoneInfo(int zoneId, long uuid, int leftTopPixelX, int leftTopPixelY)
        {
            //if (ZoneModel.ins.mapTpl == null || zoneId != ZoneModel.ins.mapTpl.Id)
            //{
            ZoneModel.ins.MapChanged();
            ZoneModel.ins.tryEnterZoneId = zoneId;
            ZoneModel.ins.playerUUID = uuid;
            ZoneModel.ins.playerStartLeftTopPixelX = leftTopPixelX;
            ZoneModel.ins.playerStartLeftTopPixelY = leftTopPixelY;
        }
        
        public void SetZoneCharacterChangedList(int mapId, MapPlayerInfoData[] changedList)
        {
            ZoneModel.ins.characterChangedZoneId = mapId;
            
            if (ZoneModel.ins.characterChangedList == null)
            {
                ZoneModel.ins.characterChangedList = new Dictionary<long, MapPlayerInfoData>();
            }
            int newLen = changedList.Length;
            for (int i = 0; i < newLen; i++)
            {
                MapPlayerInfoData oldData = null;
                MapPlayerInfoData newData = changedList[i];
                ZoneModel.ins.characterChangedList.TryGetValue(newData.uuid, out oldData);
                if (oldData == null)
                {
                    ZoneModel.ins.characterChangedList.Add(newData.uuid, newData);
                }
                else
                {
                    ZoneModel.ins.characterChangedList[newData.uuid] = newData;
                    /*
                    //// 1删除，2移动，3添加，4更新
                    if (newData.msgType == 1)
                    {
                        //ZoneModel.ins.characterChangedList.Remove(newData.uuid);
                        oldData.msgType = 1;
                    }
                    else if (newData.msgType == 3)
                    {
                        ZoneModel.ins.characterChangedList[newData.uuid] = newData;
                    }
                    else
                    {
                        if (oldData.msgType == 3)
                        {
                            newData.msgType = 3;
                        }
                        ZoneModel.ins.characterChangedList[newData.uuid] = newData;
                    }
                    */
                }
            }
        }
    }
}