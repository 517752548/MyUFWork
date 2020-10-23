﻿using System;
using app.avatar;
using app.fuben;
using app.human;
using app.role;
using app.state;
using app.story;
using UnityEngine;
using UnityEngine.Events;
using app.net;
using app.utils;
using app.db;
using app.model;
using app.team;
using app.yunliang;
using UnityEngine.UI;

namespace app.zone
{
    /// <summary>
    /// 地图上的角色。
    /// </summary>
    public class ZoneCharacter : ZoneCharacterBase
    {
        public UnityEngine.AI.NavMeshAgent navMeshAgent { get; private set; }
        public ZoneCharacterBehavType curBehavType { get; private set; }
        private Vector3 mMoveTarget;
        private Vector3 mNextMoveTarget;
        private bool mNextMoveIsForce;
        public ZoneRidingPet ridingPet { get; private set; }
        public bool isRiding { get; private set; }
        //public bool isInYunLiang { get; private set; }
        private int mLastRidePetTplId = 0;
        //private int mWearingFasionTplId = 0;
        private string defaultNameColor = ColorUtil.GREEN;
        private UnityEngine.AI.NavMeshPath mNavMeshPath = new UnityEngine.AI.NavMeshPath();

        private float mLastRequestMoveTime = 0f;
        private Vector3 mLastRequestPos;

        private float mMoveTargetOffsetDist = 0f;
        private UnityAction mMoveEndCallBack = null;

        private bool mIsLeader = false;
        private int vipLevel = 0;
        private GameObject mLeaderSign = null;

        private bool mHasRidePet = false;

        //private Transform mAss = null;
        private MapPlayerInfoData mapPlayerInfo = null;
        private bool mNeedUpdateShow = false;

        private GameObject VipSign = null;

        public ZoneCharacter()
        {
            mCharacterNameColor = new Color(71 / 255f, 1f, 57 / 255f, 1f);
        }

        public override void Init(long uuid, string displayModelId, string name, Vector3 pos, Vector3 angle, bool showShadow = true, bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true, bool particlesWritable = true)
        {
            UnRide(false);
            HideWing(false);
            HideWeapon(false);
            base.Init(uuid, displayModelId, name, pos, angle, showShadow, isEnableRidePet, isEnableWing, isEnableWeapon, particlesWritable);
            ResetNavMeshAgent();
        }

        public void ResetNavMeshAgent()
        {
            navMeshAgent = mDisplayModelContainer.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (navMeshAgent != null)
            {
                GameObject.DestroyImmediate(navMeshAgent, true);
            }
            navMeshAgent = mDisplayModelContainer.AddComponent<UnityEngine.AI.NavMeshAgent>();
            navMeshAgent.radius = 0.01f;
            navMeshAgent.height = 0.01f;
            navMeshAgent.angularSpeed = 1080f;
            navMeshAgent.acceleration = ZoneDef.CHARACTER_MOVE_SPEED * 10f;
            navMeshAgent.speed = ZoneDef.CHARACTER_MOVE_SPEED;
            navMeshAgent.stoppingDistance = 0;
            navMeshAgent.obstacleAvoidanceType = UnityEngine.AI.ObstacleAvoidanceType.NoObstacleAvoidance;
            navMeshAgent.autoBraking = true;

            if (uuid == ZoneModel.ins.playerUUID)
            {
                ResetMoveRequest();
            }
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);
            //mAss = GameObjectUtil.GetTransformByName(displayModel.avatar, "h_ass");

            if (curBehavType == ZoneCharacterBehavType.MOVE)
            {
                PlayAnimation(ANIM_NAME_MOVE, 1.0f, 0.2f, true);
                displayModel.avatar.transform.localEulerAngles = Vector3.zero;
            }
            else
            {
                if (isSelf)
                {
                    displayModel.avatar.transform.localEulerAngles = ZoneModel.ins.selfRot;
                }
                else
                {
                    displayModel.avatar.transform.localEulerAngles = new Vector3(0, UnityEngine.Random.Range(0, 360), 0);
                }
                Idle();
            }

            //判断这个模型是不是玩家自己
            if (isSelf)
            {
                if (isEnableWing)
                {
                    ShowWing(wingTpl);
                }
                if (mIsEnableRidePet)
                {
                    Ride(mLastRidePetTplId);
                }
                if (isEnableWeapon)
                {
                    if (this.weaponTpl != null)
                    {
                        ShowWeapon(this.weaponTpl);
                    }
                }

                //ChenckMyChenghao();
                //ShowVIPSign();
            }
            else
            {
                if (mNeedUpdateShow)
                {
                    UpdateShowAfterUpdateData();
                }
				/*
                //由于周围玩家信息列表来的时候 模型有可能还没创建 这里做了一下状态判断
                if (m_bneedCh)
                {
                    m_bneedCh = false;
                    UpdateChenghao(EChenghaoStatue.Chenghao, StrChengwei);
                }
                else
                {

                    UpdateChenghao(EChenghaoStatue.None, StrChengwei);
                }
				*/
            }
        }

        /// <summary>
        /// 变身
        /// </summary>
        /// <param name="displayModelId"></param>
        /// <param name="showShadow"></param>
        public void ShiftDisplayModel(string displayModelId, bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true)
        {
            Init(this.uuid, displayModelId, this.name, this.localPosition, this.localEulerAngles, true, isEnableRidePet, isEnableWing, isEnableWeapon);
        }

        public bool isLeader
        {
            get
            {
                return mIsLeader;
            }
            set
            {
                mIsLeader = value;
                if (mIsLeader)
                {
                    if (HeadFlag.NONE == isInBattle)
                    {
                        ShowLeaderSign();
                    }
                }
                else
                {
                    HideLeaderSign();
                }
            }
        }

        public override HeadFlag isInBattle
        {
            get
            {
                return base.isInBattle;
            }
            set
            {
                base.isInBattle = value;
                if (HeadFlag.NONE == value)
                {
                    HideLeaderSign();
                }
                else
                {
                    if (isLeader)
                    {
                        ShowLeaderSign();
                    }
                }
            }
        }

        public override bool Update()
        {
            if (base.Update())
            {
                if (mMoveTarget != mNextMoveTarget)
                {
                    TryMove();
                }

                if (curBehavType == ZoneCharacterBehavType.MOVE)
                {
                    if ((localPosition.x == mMoveTarget.x && localPosition.z == mMoveTarget.z) ||
                        Vector2.Distance(new Vector2(localPosition.x, localPosition.z), new Vector2(mMoveTarget.x, mMoveTarget.z)) <= mMoveTargetOffsetDist)
                    {
                        MoveFinished();
                    }
                }

                if (this == ZoneCharacterManager.ins.self)
                {
                    if (StateManager.Ins.getCurState().state == StateDef.storyState
                        && StoryManager.ins.IsStoryBattle)
                    {
                    }
                    else
                    {
                        ZoneModel.ins.zoneMap.Update(localPosition);
                    }
                }

                FixSignPosition(mLeaderSign);
                FixSignPosition(mBattleSign);

                return true;
            }
            return false;
        }

        private void FixSignPosition(GameObject sign)
        {
            if (sign != null && sign.activeSelf)
            {
                Vector3 pos = Vector3.zero;
                if (displayModelForLoc != null && displayModelForLoc.avatar != null)
                {
                    pos = displayModelForLoc.avatar.transform.localPosition;
                    pos.y = displayModelForLoc.totalHeight + 0.5f;
                }
                if (isRiding)
                {
                    /*
                    if (ridingPet != null && ridingPet.displayModel != null && ridingPet.displayModel.avatar != null)
                    {
                        
                    }
                    */
                    pos.y += 1;
                }
                sign.transform.localPosition = pos;
            }
        }

        protected override void UpdateChatBubblePos()
        {
            if (mChatBubbleGo != null && mChatBubbleGo.activeSelf)
            {
                Vector3 v3 = Vector3.zero;
                if (displayModelForLoc != null && displayModelForLoc.avatar != null)
                {
                    v3 = displayModelForLoc.avatar.transform.position;
                    v3.y += (displayModelForLoc.totalHeight + 0.2f);
                }

                if (isRiding)
                {
                    v3.y += 1.0f;
                }
                
                if (this.mIsInBattleWhenChat)
                {
                    v3.y += 0.8f;
                }
                else if (this.mIsTeamLeaderWhenChat)
                {
                    v3.y += 0.8f;
                }
                
                v3.z -= 0.05f;
                mChatBubbleGo.transform.position = v3;
                if (mLastFixedChatContentPos != v3)
                {
                    mChatBubbleGo.transform.position = v3;
                    mLastFixedChatContentPos = v3;
                }
            }
        }

        protected override void FixBattleSignPosition()
        {
            if (mBattleSignParetn != null && mBattleSignParetn.activeSelf)
            {
                Vector3 v3 = Vector3.zero;
                if (displayModelForLoc != null && displayModelForLoc.avatar != null)
                {
                    v3 = displayModelForLoc.avatar.transform.position;
                    if (null != mBattleSign)
                    {
                        v3.x -= mBattleSign.transform.localPosition.x;
                        v3.y -= mBattleSign.transform.localPosition.y - 0.4f;
                        v3.z -= mBattleSign.transform.localPosition.z;
                    }
                    v3.y += (displayModelForLoc.totalHeight + 0.1f);
                }

                if (isRiding)
                {
                    v3.y += 0.8f;
                }

                v3.z -= 0.05f;
                mBattleSignParetn.transform.position = v3;
                if (mLastFixedBattleSignPos != v3)
                {
                    mBattleSignParetn.transform.position = v3;
                    mLastFixedBattleSignPos = v3;
                }
            }
        }

        public override bool FixedUpdate()
        {
            if (base.FixedUpdate())
            {
                if (isSelf)
                {
                    if (ZoneModel.ins.fixedZoneTime - mLastRequestMoveTime >= ZoneDef.SYNC_POSITION_DELTA_SECONDS)
                    {
                        if (mLastRequestPos != localPosition)
                        {
                            int[] curLtPixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(localPosition);
                            int[] tarLtPixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(mMoveTarget);
                            MapCGHandler.sendCGMapPlayerMove(ZoneModel.ins.mapTpl.Id, curLtPixelPos[0], curLtPixelPos[1], tarLtPixelPos[0], tarLtPixelPos[1]);
                            //Debug.LogWarning("CGMapPlayerMove 当前点所在格子号(从0开始)：" + ZoneUtil.ConvertUnityPos2PathTilePos(localPosition) + " 目标点所在格子号(从0开始)：" + ZoneUtil.ConvertUnityPos2PathTilePos(mMoveTarget));
                            mLastRequestPos = localPosition;
                            mLastRequestMoveTime = ZoneModel.ins.fixedZoneTime;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public void ResetMoveRequest()
        {
            mLastRequestMoveTime = ZoneModel.ins.fixedZoneTime;
            mLastRequestPos = localPosition;
        }

        public void UpdateData(MapPlayerInfoData data)
        {
            mapPlayerInfo = data;
            isLeader = (data.isLeader != 0);
            if (data.isFighting != 0)
            {
                isInBattle = (data.isFighting != 0 ? HeadFlag.ZHAN_DOU : HeadFlag.NONE);
            }
            else
            {
                isInBattle = (HeadFlag)data.lifeSkillFlag;
            }
            VipLevel = data.vipLevel;
			title = data.titleName;
            //isInYunLiang = (data.isForaging != 0);
            //mWearingFasionTplId = data.fashionTplId;
            mIsEnableRidePet = (data.isForaging == 0);
            isEnableWing = (data.isForaging == 0);
            isEnableWeapon = (data.isForaging == 0 && data.rideHorseTplId == 0 && data.fashionTplId == -1);
            if (displayModel != null && displayModel.avatar != null)
            {
                UpdateShowAfterUpdateData();
            }
            else
            {
                mNeedUpdateShow = true;
            }
        }

        private void UpdateShowAfterUpdateData()
        {
            mNeedUpdateShow = false;
            string newDisplayModelId = ZoneCharacterManager.ins.GetDisplayModelId(mapPlayerInfo);
            if (displayModelId != newDisplayModelId)
            {
                ShiftDisplayModel(newDisplayModelId, mIsEnableRidePet, isEnableWing, isEnableWeapon);
            }

            if (isEnableWing && PropertyUtil.IsLegalID(mapPlayerInfo.wingTplId))
            {
                if (wing == null || wing.isDestroied || wing.tpl.Id != mapPlayerInfo.wingTplId)
                {
                    WingTemplate wt = WingTemplateDB.Instance.getTemplate(mapPlayerInfo.wingTplId);
                    if (wt != null)
                    {
                        ShowWing(wt);
                    }
                }
            }
            else
            {
                if (wing != null)
                {
                    HideWing(true);
                }
            }

            if (mIsEnableRidePet && PropertyUtil.IsLegalID(mapPlayerInfo.rideHorseTplId))
            {
                if (ridingPet == null || ridingPet.isDestroied || ridingPet.tpl.Id != mapPlayerInfo.rideHorseTplId)
                {
                    Ride(mapPlayerInfo.rideHorseTplId);
                }
            }
            else
            {
                if (isRiding)
                {
                    UnRide(true);
                }
            }
            
            
            if(isEnableWeapon && PropertyUtil.IsLegalID(mapPlayerInfo.equipWeaponId))
            {
                if (this.weaponTpl == null || this.weaponTpl.Id != mapPlayerInfo.equipWeaponId)
                {
                    ShowWeapon(EquipItemTemplateDB.Instance.getTemplate(mapPlayerInfo.equipWeaponId));
                }
            }
            else
            {
                if (isShowingWeapon)
                {
                    HideWeapon(true);
                }
            }

            //UpdateOtherChenghao(mapPlayerInfo.titleName);
            //ShowVIPSign();
        }

        public override Vector3 localPosition
        {
            get
            {
                return base.localPosition;
            }
            set
            {
                base.localPosition = value;
                this.Idle();
                if (this == ZoneCharacterManager.ins.self)
                {
                    if (TeamModel.ins.GetLeaderUUID() == uuid)
                    {
                        ZoneCharacterManager.ins.TeamMembersFollowMe(mNextMoveTarget);
                    }
                }
            }
        }

        public void SetSpeedRate(float rate)
        {
            if (navMeshAgent != null)
            {
                navMeshAgent.acceleration = ZoneDef.CHARACTER_MOVE_SPEED * 10f * rate;
                navMeshAgent.speed = ZoneDef.CHARACTER_MOVE_SPEED * rate;
            }
        }

        /// <summary>
        /// 移动到目标点。在强制移动状态下，一旦目标点无法到达，如果成功设置了通往附近点的路径，则沿着此路径移动到附近点，如果没有成功设置任何路径则瞬移到附近点。
        /// </summary>
        /// <param name="targetPos">目标点。</param>
        /// <param name="targetPosOffsetDist">距目标点多远的时候停止移动。</param>
        /// <param name="force">是否强制移动。</param>
        /// <param name="moveEndCallBack">移动完成后的回调。</param>
        public bool MoveTo(Vector3 targetPos, float targetPosOffsetDist = 0f, bool force = false, UnityAction moveEndCallBack = null)
        {
            targetPos.y = localPosition.y;
            mMoveTargetOffsetDist = targetPosOffsetDist;
            mMoveEndCallBack = moveEndCallBack;
            mNextMoveTarget = targetPos;
            mNextMoveIsForce = force;

            if (localPosition.x == targetPos.x && localPosition.z == targetPos.z)
            {
                if (moveEndCallBack != null)
                {
                    moveEndCallBack();
                }
                return false;
            }

            if (mMoveTarget != mNextMoveTarget)
            {
                return TryMove();
            }

            return true;
        }

        private bool TryMove()
        {
            if (CreateMovePath())
            {
                if (curBehavType == ZoneCharacterBehavType.MOVE)
                {
                    ContinueMove();
                }
                else
                {
                    StartMove();
                }
                if (this == ZoneCharacterManager.ins.self)
                {
                    if (TeamModel.ins.GetLeaderUUID() == uuid)
                    {
                        ZoneCharacterManager.ins.TeamMembersFollowMe(mNextMoveTarget);
                    }
                }
                return true;
            }
            else
            {
                ClientLog.LogWarning("cannot create movepath from " + localPosition.ToString("f5") + " to " + mNextMoveTarget.ToString("f5"));
                /*
                if (mNextMoveIsForce)
                {
                    localPosition = mNextMoveTarget;
                }
                else
                {
                    mNextMoveTarget = localPosition;
                    mMoveTarget = mNextMoveTarget;
                }
                */
                mNextMoveTarget = localPosition;
                mMoveTarget = mNextMoveTarget;
                //ZoneBubbleManager.ins.BubbleSysMsg("目标位置不可到达");
            }
            return false;
        }

        private bool CreateMovePath()
        {
            if (navMeshAgent != null)
            {
                if (!navMeshAgent.isActiveAndEnabled || !navMeshAgent.isOnNavMesh)
                {
                    //localPosition = mNextMoveTarget;
                    return false;
                }

                int[] pathTilePos = ZoneUtil.ConvertUnityPos2PathTilePos(mNextMoveTarget);

                if (SceneModel.ins.IsMapTileCanWalk(pathTilePos[0], pathTilePos[1]))
                {
                    bool res = navMeshAgent.CalculatePath(mNextMoveTarget, mNavMeshPath);
                    if (res)
                    {
                        Vector3 dest = mNavMeshPath.corners[mNavMeshPath.corners.Length - 1];

                        if (mNextMoveIsForce)
                        {
                            mNextMoveTarget = dest;
                            return true;
                        }

                        if (dest.x == mNextMoveTarget.x && dest.z == mNextMoveTarget.z)
                        {
                            return true;
                        }
                    }
                }

                //Debug.LogError(pathTilePos + " 不可走");

                if (!mNextMoveIsForce)
                {
                    //Debug.LogError("找一个附近的可走的点");
                    //目标点不可走，并且此次移动非强制性，则移动到距离目标点最近的一个可走的点。
                    ZoneMapConfig mapCfg = SceneModel.ins.zoneMapConfig;
                    int[] moveTargetTile = ZoneUtil.ConvertUnityPos2PathTilePos(mNextMoveTarget);
                    int delta = 0;

                    for (int i = 0; i < 50; i++)
                    {
                        delta += 1;

                        int minCol = moveTargetTile[0] - delta;
                        int minRow = moveTargetTile[1] - delta;
                        int maxCol = moveTargetTile[0] + delta;
                        int maxRow = moveTargetTile[1] + delta;

                        for (int col = minCol; col <= maxCol; col++)
                        {
                            for (int row = minRow; row <= maxRow; row++)
                            {
                                if (col == moveTargetTile[0] && row == moveTargetTile[1])
                                {
                                    continue;
                                }

                                if (col >= 0 && col < mapCfg.pathTileColCount && row >= 0 && row < mapCfg.pathTileRowCount)
                                {
                                    if (mapCfg.pathTilesMarix[col][row] == 'O' || mapCfg.pathTilesMarix[col][row] == 'o')
                                    {
                                        //找到一个可走的点。
                                        Vector3 pos = ZoneUtil.ConvertMapPathTilePos2UnityPos(col, row);
                                        Vector3 direct = mNextMoveTarget - pos;
                                        direct.Normalize();
                                        pos += direct * (float)Math.Min(mapCfg.pathTileWidth, mapCfg.pathTileHeight) / (float)ZoneDef.MAP_PIXEL_ONE_UNIT * 0.3f;
                                        bool flag = navMeshAgent.CalculatePath(pos, mNavMeshPath);
                                        if (flag)
                                        {
                                            mNextMoveTarget = pos;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    /*
                    float delta = Math.Min(SceneModel.ins.zoneMapConfig.pathTileWidth, SceneModel.ins.zoneMapConfig.pathTileHeight);
                    delta = delta / (float)ZoneDef.MAP_PIXEL_ONE_UNIT;
                    float sampleRadius = 0.0f;
                    NavMeshHit hit;
                    bool success = false;

                    while (!success)
                    {
                        sampleRadius += delta;
                        success = NavMesh.SamplePosition(mNextMoveTarget, out hit, sampleRadius, NavMesh.AllAreas);
                        if (success)
                        {
                            success = navMeshAgent.CalculatePath(hit.position, mNavMeshPath);
                            if (success)
                            {
                                ClientLog.LogError("curPosition:" + localPosition + "  mNextMoveTarget:" + mNextMoveTarget + "  hit.position:" + hit.position.ToString("f5"));
                                mNextMoveTarget = hit.position;
                                return true;
                            }
                        }
                    }
                    */
                }
                else
                {
                    if (isSelf)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("目标位置无法到达");
                    }
                }
            }
            else
            {
                ClientLog.LogError("ZoneCharacter CreateMovePath时没取到寻路组件！");
            }

            return false;
        }

        private void StartMove()
        {
            if (isRiding)
            {
                PlayAnimation(ANIM_NAME_RIDE_MOVE);
                ridingPet.PlayAnimation(ANIM_NAME_MOVE);
                /*
                if (ridingPet != null && ridingPet.displayModel != null && ridingPet.displayModel.avatar != null)
                {
                    ridingPet.displayModel.avatar.transform.localEulerAngles = Vector3.zero;
                }
                */
            }
            else
            {
                PlayAnimation(ANIM_NAME_MOVE);
                /*
                if (displayModel != null && displayModel.avatar != null)
                {
                    displayModel.avatar.transform.localEulerAngles = Vector3.zero;
                }
                */
            }
            
            if (displayModelForLoc != null && displayModelForLoc.avatar != null)
            {
                displayModelForLoc.avatar.transform.localEulerAngles = Vector3.zero;
            }

            mMoveTarget = mNextMoveTarget;
            bool setPathFlag = navMeshAgent.SetPath(mNavMeshPath);

            if (setPathFlag)
            {
                curBehavType = ZoneCharacterBehavType.MOVE;
            }
            else
            {
                if (mNextMoveIsForce)
                {
                    localPosition = mMoveTarget;
                }
                else
                {
                    localPosition = localPosition;
                }

                MoveFinished();
            }
        }

        private void ContinueMove()
        {
            mMoveTarget = mNextMoveTarget;
            bool b = navMeshAgent.SetPath(mNavMeshPath);
            if (!b)
            {
                if (mNextMoveIsForce)
                {
                    localPosition = mMoveTarget;
                }
                else
                {
                    localPosition = localPosition;
                }

                MoveFinished();
            }
        }

        private void MoveFinished()
        {
            Idle();
            if (mMoveEndCallBack != null)
            {
                mMoveEndCallBack();
            }
        }

        public void Idle()
        {
            if (isRiding)
            {
                PlayAnimation(ANIM_NAME_RIDE_IDLE);
                ridingPet.PlayAnimation(ANIM_NAME_IDLE);
            }
            else
            {
                PlayAnimation(ANIM_NAME_IDLE);
            }

            if (navMeshAgent != null && navMeshAgent.hasPath)
            {
                try
                {
                    navMeshAgent.Stop();
                    navMeshAgent.ResetPath();
                    navMeshAgent.enabled = false;
                    navMeshAgent.enabled = true;
                }
                catch (Exception e)
                {
                    //ClientLog.LogError(e.Message);
                }
            }
            if (mNavMeshPath != null)
            {
                mNavMeshPath.ClearCorners();
            }

            mMoveTarget = localPosition;
            mNextMoveTarget = localPosition;
            curBehavType = ZoneCharacterBehavType.IDLE;

            if (this == ZoneCharacterManager.ins.self)
            {
                ResetMoveRequest();
            }
        }

        private void ShowLeaderSign()
        {
            if (mLeaderSign == null)
            {
                SourceLoader.Ins.load(PathUtil.Ins.GetEffectPath("common_lingpai"), OnLeaderSignLoaded);
            }
            else
            {
                mLeaderSign.SetActive(true);
            }
        }

        private void OnLeaderSignLoaded(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                string path = PathUtil.Ins.GetEffectPath("common_lingpai");
                mLeaderSign = SourceManager.Ins.createObjectFromAssetBundle(path);
                if (mLeaderSign != null)
                {
                    mLeaderSign.transform.SetParent(mDisplayModelContainer.transform);
                    GameObjectUtil.SetLayer(mLeaderSign, mDisplayModelContainer.layer);
                    if (isLeader)
                    {
                        ShowLeaderSign();
                    }
                    else
                    {
                        HideLeaderSign();
                    }
                }
            }
        }

        private void HideLeaderSign()
        {
            if (mLeaderSign != null)
            {
                mLeaderSign.SetActive(false);
            }
        }

    

        private void ShowVIPSign()
        {
            if (vipLevel<=0)
            {
                return;
            }
            if (VipSign == null)
            {
                VipSign = AvatarTextManager.Ins.CreateAvatarImage("vipsign", GetLayer());
                VipSign.transform.SetParent(mAvatarText.transform);
                VipSign.transform.localScale = Vector3.one;
                VipSign.transform.localPosition = new Vector3(-100,-15,0);
                VipSign.transform.localRotation = new Quaternion(0, 0, 0, 0);
                VipSign.AddComponent<Image>();
                //if (StateManager.Ins.getCurState().state == StateDef.battleState)
                //{
                //    Vector3 cavRot = SceneModel.ins.battleCam.GetComponent<Camera>().transform.localEulerAngles;
                //    vipimage.transform.eulerAngles = new Vector3(cavRot.x, cavRot.y, 0);
                //}
                //else if (StateManager.Ins.getCurState().state == StateDef.zoneState)
                //{
                //    vipimage.transform.localRotation = SceneModel.ins.zone3DModelCam.transform.localRotation;
                //}
            }
            else
            {
                if (VipSign!=null) VipSign.SetActive(true);
            }
            if (VipSign != null)
            {
                Image vipimage = VipSign.GetComponent<Image>();
                Sprite t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.chongzhiAtlasPath, "V" + vipLevel);
                vipimage.sprite = t;
                vipimage.SetNativeSize();
            }
        }
        
        private void HideVipSign()
        {
            if (VipSign != null)
            {
                VipSign.SetActive(false);
            }
        }

        public void Ride(int ridePetTplId)
        {
            mLastRidePetTplId = ridePetTplId;
            
            if (mIsEnableRidePet && PropertyUtil.IsLegalID(ridePetTplId))
            {
                isEnableWeapon = false;
                HideWeapon(false);
            }
            if (displayModel != null && displayModel.avatar != null)
            {
                UnRide(false);

                if (mIsEnableRidePet)
                {
                    if (PropertyUtil.IsLegalID(mLastRidePetTplId))
                    {
                        {
                            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(ridePetTplId);
                            if (petTpl != null)
                            {
                                mHasRidePet = true;
                                if (ridingPet == null)
                                {
                                    ridingPet = new ZoneRidingPet(RideOnPet);
                                }

                                ridingPet.Init(petTpl, displayModel.avatar.transform.localPosition, displayModel.avatar.transform.localEulerAngles, mDisplayModelContainer.transform);
                                //ridingPet.Init(petTpl.modelId);
                                return;
                            }
                        }
                    }
                }
            }

            if (this == ZoneCharacterManager.ins.self)
            {
                CheckUgradeEffectShow();
            }
        }

        private void RideOnPet()
        {
            if (isDestroied || !mHasRidePet)
            {
                ridingPet.Destroy();
            }
            else
            {
                if (mHasRidePet && ridingPet != null && ridingPet.displayModel != null && ridingPet.displayModel.avatar != null)
                {
                    //ridingPet.SetActive(false);
                    //GameObjectUtil.SetLayer(ridingPet.displayModel.avatar, displayModel.avatar.layer);

                    //ridingPet.displayModel.avatar.transform.SetParent(mDisplayModelContainer.transform);
                    //ridingPet.displayModel.avatar.transform.localPosition = displayModel.avatar.transform.localPosition;
                    //ridingPet.displayModel.avatar.transform.localEulerAngles = displayModel.avatar.transform.localEulerAngles;
                    //ridingPet.SetActive(true);

                    if (curAnimName == ANIM_NAME_MOVE)
                    {
                        ridingPet.displayModel.avatar.transform.localEulerAngles = Vector3.zero;
                    }

                    GameObjectUtil.Bind(displayModel.avatar.transform, ridingPet.back);
                    //displayModel.avatar.transform.SetParent(ridingPet.back);
                    displayModel.HideShadow();

                    if (curBehavType == ZoneCharacterBehavType.NONE || curBehavType == ZoneCharacterBehavType.IDLE)
                    {
                        PlayAnimation(ANIM_NAME_RIDE_IDLE, 1, 0);
                        ridingPet.PlayAnimation(ANIM_NAME_IDLE, 1, 0);
                    }
                    else if (curBehavType == ZoneCharacterBehavType.MOVE)
                    {
                        PlayAnimation(ANIM_NAME_RIDE_MOVE, 1, 0);
                        ridingPet.PlayAnimation(ANIM_NAME_MOVE, 1, 0);
                    }

                    //footHeight += (displayModel.avatar.transform.localPosition.y + displayModel.avatar.transform.parent.position.y);
                    //totalHeight = footHeight + bodyHeight;

                    displayModelForLoc = ridingPet.displayModel;

                    //ClientLog.LogError(mAss.position.ToString("f5") + "  " + ridingPet.back.position.ToString("f5"));

                    ridingPet.SetIsHalfOpaque(isHalfOpaque);

                    isRiding = true;
                }

                if (this == ZoneCharacterManager.ins.self)
                {
                    CheckUgradeEffectShow();
                }
            }
        }

        public void UnRide(bool isUnrideByServer)
        {
            if (isRiding)
            {
                //footHeight -= (displayModel.avatar.transform.localPosition.y + displayModel.avatar.transform.parent.position.y);
                //totalHeight = footHeight + bodyHeight;
                displayModel.avatar.transform.SetParent(mDisplayModelContainer.transform);
                displayModel.avatar.transform.localPosition = ridingPet.displayModel.avatar.transform.localPosition;
                displayModel.avatar.transform.localEulerAngles = ridingPet.displayModel.avatar.transform.localEulerAngles;
                displayModel.ShowShadow();

                if (curBehavType == ZoneCharacterBehavType.IDLE)
                {
                    PlayAnimation(ANIM_NAME_IDLE, 1, 0);
                }
                else if (curBehavType == ZoneCharacterBehavType.MOVE)
                {
                    PlayAnimation(ANIM_NAME_MOVE, 1, 0);
                }

                ridingPet.Destroy();
                ridingPet = null;
                isRiding = false;

                displayModelForLoc = displayModel;
            }
            mHasRidePet = false;
            if (isUnrideByServer)
            {
                mLastRidePetTplId = 0;
            }

            if (isSelf)
            {
                if (isUnrideByServer && !YunLiangModel.Ins.isYunLiangIng() && Human.Instance.PetModel.GetFashionTplId() <= 0)
                {
                    isEnableWeapon = true;
                    if (this.weaponTpl != null)
                    {
                        ShowWeapon(this.weaponTpl);
                    }
                }
            }
            else
            {
                if (isUnrideByServer && mapPlayerInfo.isForaging == 0 && mapPlayerInfo.fashionTplId <= 0)
                {
                    isEnableWeapon = true;
                    if (this.weaponTpl != null)
                    {
                        ShowWeapon(this.weaponTpl);
                    }
                }
            }
        }

        public override void Destroy()
        {
            if (!isDestroied)
            {
                if (navMeshAgent != null && navMeshAgent.hasPath)
                {
                    try
                    {
                        navMeshAgent.ResetPath();
                    }
                    catch (Exception e)
                    {
                        ClientLog.LogError(e.Message);
                    }
                }

                navMeshAgent = null;

                if (mNavMeshPath != null)
                {
                    mNavMeshPath.ClearCorners();
                    mNavMeshPath = null;
                }

                if (displayModel != null && displayModel.avatar != null && mDisplayModelContainer != null && displayModel.avatar.transform.parent != mDisplayModelContainer.transform)
                {
                    displayModel.avatar.transform.SetParent(mDisplayModelContainer.transform);
                }

                if (ridingPet != null)
                {
                    ridingPet.Destroy();
                    ridingPet = null;
                }

                isRiding = false;

                if (mLeaderSign != null)
                {
                    SourceManager.Ins.removeReference(PathUtil.Ins.GetEffectPath("common_lingpai"), mLeaderSign);
                    mLeaderSign = null;
                }

                if (mBattleSign != null)
                {
                    SourceManager.Ins.removeReference(PathUtil.Ins.GetEffectPath("common_zhandou"), mBattleSign);
                    mBattleSign = null;
                }

                if (VipSign != null)
                {
                    SourceManager.Ins.removeReference(PathUtil.Ins.uiDependenciesPath, VipSign);
                    VipSign = null;
                }

                base.Destroy();
            }
        }

        public override void SetIsHalfOpaque(bool value)
        {
            base.SetIsHalfOpaque(value);
            if (isRiding)
            {
                ridingPet.displayModel.SetIsHalfOpaque(value);
            }
        }

        public override void SetActive(bool value)
        {
            if (isActive != value)
            {
                if (!isActive && value && curBehavType == ZoneCharacterBehavType.MOVE)
                {
                    //localPosition = mNextMoveTarget;
                    Idle();
                    //TryMove();
                }
                base.SetActive(value);
            }
        }

        #region 称号

		private string mTitle = "";  //当前的称号

        public string title
        {
            get
            {
                return mTitle;
            }

            set
            {
				if (mTitle != value)
				{
					mTitle = value;
					UpdateTitle();
				}
            }
        }

        public int VipLevel
        {
            get { return vipLevel; }
            set
            {
                if (vipLevel != value)
                {
                    vipLevel = value;
                    if (vipLevel > 0)
                    {
                        ShowVIPSign();
                    }
                    else
                    {
                        HideVipSign();
                    }
                }
            }
        }
		/*
        public void ChenckMyChenghao()
        {
            int show = Human.Instance.getShowChenghao();
            string name = Human.Instance.getChenghaoName();
            ChenckChenghao(show, name);
        }
        /// <summary>
        /// 检查当前是否有称号 有的话显示
        /// </summary>
        public void ChenckChenghao(int isshow, string chenghaoName)
        {
            m_nshow = isshow;
            if (isshow == 0)
            {
                //隐藏称谓
                UpdateChenghao(EChenghaoStatue.None);
            }
            else
            {
                m_strChenghao = chenghaoName;
                UpdateChenghao(EChenghaoStatue.Chenghao);
            }
        }

        public void UpdateCurrentChenghao()
        {
            UpdateChenghao(m_echStatue, m_strChenghao);
        }

        public void UpdateChenghao(EChenghaoStatue namestatue)
        {
            UpdateChenghao(namestatue, m_strChenghao);
        }
        */

        /// <summary>
        /// 更新称号状态
        /// </summary>
		private void UpdateTitle()
        {
            //m_echStatue = namestatue;
            string colorName = name;
            string namecolor = defaultNameColor;
            if (FubenbpjsModel.ins.IsInBpjs())
            {
                if (!isSelf)
                {
                    long corpId = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.MY_CORP_ID);
                    if (mapPlayerInfo != null && corpId != mapPlayerInfo.corpsId)
                    {
                        namecolor = ColorUtil.RED;
                    }
                    else
                    {
                        namecolor = ColorUtil.GREEN;
                    }
                }
                else
                {
                    namecolor = ColorUtil.GREEN;
                }
            }
            colorName = ColorUtil.getColorText(namecolor, name);
			if (string.IsNullOrEmpty (title))
            {
				UpdateNameDisplay (colorName);
				//m_texname.text = colorName;
			}
            else
            {
				UpdateNameDisplay (title + "\n" + colorName);
				// /m_texname.text = chenghao + "\n" + colorName;
			}
			/*
            switch (namestatue)
            {
				
                case EChenghaoStatue.None:
                    //if (m_texname != null)
                    //{
                    UpdateNameDisplay(colorName);
                    //m_texname.text = colorName;
                    //}
                    break;
                case EChenghaoStatue.Chenghao:
                    if (string.IsNullOrEmpty(chenghao))
                    {
                        UpdateNameDisplay(colorName);
                        //m_texname.text = colorName;
                    }
                    else
                    {
                        UpdateNameDisplay(chenghao + "\n" + colorName);
                        // /m_texname.text = chenghao + "\n" + colorName;
                    }

                    //if (m_texch == null)
                    //{
                    //    m_texch = AvatarTextManager.Ins.GetText(chenghao, mCharacterNameColor, fontSize).GetComponent<Text>();
                    //}
                    //if (!string.IsNullOrEmpty(chenghao))
                    //{
                    //    m_texch.transform.SetParent(mAvatarText.transform);
                    //    m_texch.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    //    m_texch.transform.localPosition = Vector3.zero;
                    //    m_texch.transform.localEulerAngles = Vector3.zero;
                    //    m_texname.transform.localPosition -= new Vector3(0, .3f, 0);
                    //    m_texch.gameObject.SetActive(true);
                    //}
                    break;
            }
            */
        }
		/*
        /// <summary>
        /// 更新其他人称号
        /// </summary>
        public void UpdateOtherChenghao(string chenghao)
        {
            if (m_strChenghao != chenghao)
            {
                m_strChenghao = chenghao;

                //if (string.IsNullOrEmpty(chenghao))
                //{
                    //m_bneedCh = false;
                    //if (mAvatarText != null)
                        //UpdateChenghao(EChenghaoStatue.None);
                //}
                //else
                //{
                    //m_bneedCh = true;
                    //if (mAvatarText != null)
                        //UpdateChenghao(EChenghaoStatue.Chenghao, chenghao);
                //}

				if (string.IsNullOrEmpty (chenghao))
				{
					UpdateChenghao (EChenghaoStatue.None);
				}
				else
				{
					UpdateChenghao (EChenghaoStatue.Chenghao, chenghao);
				}
            }
        }
		*/
        /*
        /// <summary>
        /// 更新称号颜色
        /// </summary>
        public void UpdateChenghaoCor(Color _color)
        {
            if (m_texch != null)
                m_texch.color = _color;
        }
        */
        /// <summary>
        /// 当前称号的UUID
        /// </summary>
        //private int m_nchtepid;
        //private int m_nshow;  //是否显示称号
                              //private Text m_texch; //称号的text

        #endregion

        private void CheckUgradeEffectShow()
        {
            //检查播放升级动画
            if (!isDestroied && Human.Instance.PlayerModel.NeedPlayerUpgradeEffect)
            {
                Human.Instance.PlayerModel.NeedPlayerUpgradeEffect = false;
                EffectUtil.Ins.PlayEffect("common_shengji", LayerConfig.MainUI, false, null);
                //EffectUtil.Ins.PlayEffect("common_shengji_renwu", LayerConfig.Layer_ZoneModel, false, ZoneCharacterManager.ins.player.displayModel.avatar.transform.parent.gameObject);
                ZoneCharacterManager.ins.self.ShowUpgradeEffect();
            }
            else
            {
                //EffectUtil.Ins.RemoveEffect("common_shengji_renwu");
            }
        }

        public void ShowUpgradeEffect()
        {
            if (isRiding)
            {
                if (ridingPet != null && ridingPet.displayModel != null && ridingPet.displayModel.avatar != null)
                {
                    //EffectUtil.Ins.PlayEffect("common_shengji_renwu", LayerConfig.Layer_ZoneModel, false, ridingPet.displayModel.avatar);
                }
            }
            else
            {
                if (displayModel != null && displayModel.avatar != null)
                {
                    //EffectUtil.Ins.PlayEffect("common_shengji_renwu", LayerConfig.Layer_ZoneModel, false, displayModel.avatar);
                }
            }
        }
        
        public MapPlayerInfoData playerInfo
        {
            get
            {
                return mapPlayerInfo;
            }
        }
    }
}