﻿using app.db;
using app.model;
using app.role;
using app.yunliang;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using app.net;
using app.chat;
using app.human;
using app.team;
using app.pet;
using app.utils;
using app.relation;
using app.system;

namespace app.zone
{
    public class ZoneCharacterManager
    {
        public ZoneCharacter self { get; private set; }
        /// <summary>
        /// 主角的移动速度 系数
        /// </summary>
        private float _mainRoleMoveSpeedRate = 1.0f;
        public int othersCountForFPS = 0;

        private List<ZoneCharacter> mOthers = new List<ZoneCharacter>();
        private int mOthersCount = 0;

        private Dictionary<long, MapPlayerInfoData> mQueueForCreate = new Dictionary<long, MapPlayerInfoData>();
        private int mQueueForCreateSize = 0;
        private int mCreateCDFrameLeft = 0;

        private bool mAllCharactersHidden = false;

        private Dictionary<long, MapPlayerInfoData> mOthersDataFromServer = new Dictionary<long, MapPlayerInfoData>();

        //private NavMeshPath mPlayerFollowLeaderPath = new NavMeshPath();
        //private NavMeshPath mTeamMemberFollowMePath = new NavMeshPath();

        private YunLiangModel mYunLiangModel = null;
        private ChiBangModel chibangModel = null;

        private static ZoneCharacterManager mIns = new ZoneCharacterManager();

        public static ZoneCharacterManager ins
        {
            get
            {
                return mIns;
            }
        }

        public ZoneCharacterManager()
        {
            if (ZoneCharacterManager.ins != null)
            {
                throw new Exception("ZoneCharacterManager instance already exists!");
            }

            //mYunLiangModel = Singleton.getObj(typeof(YunLiangModel)) as YunLiangModel;
            //chibangModel = Singleton.getObj(typeof(ChiBangModel)) as ChiBangModel;
            mYunLiangModel = YunLiangModel.Ins;
            chibangModel = ChiBangModel.Ins;
        }

        public void Init()
        {
            //ClearCharacters();
            int leftTopPixelX = ZoneModel.ins.playerStartLeftTopPixelX;
            int leftTopPixelY = ZoneModel.ins.playerStartLeftTopPixelY;

            if (self == null)
            {
                long uuid = ZoneModel.ins.playerUUID;
                string currentModelName = Human.Instance.get3DModel();
                bool isEnableRidePet = true;
                bool isEnableWing = true;
                bool isEnableWeapon = true;

                bool isYunLiang = mYunLiangModel.isYunLiangIng();
                if (isYunLiang)
                {
                    currentModelName = ClientConstantDef.YUNLIANGREN;
                    isEnableRidePet = isEnableWing = isEnableWeapon = false;
                }
                else
                {
                    isEnableWeapon = (Human.Instance.PetModel.getRidePet() == null);
                    int fashionId = Human.Instance.PetModel.GetFashionTplId();
                    string fashionModel = Human.Instance.PetModel.GetFashionModelString();
                    if (fashionId != -1 && fashionModel != null)
                    {
                        isEnableWeapon = false;
                        currentModelName = fashionModel;
                    }
                }
                self = CreateCharacter(uuid, currentModelName, Human.Instance.getName(), leftTopPixelX, leftTopPixelY, true, isEnableRidePet, isEnableWing, isEnableWeapon, true);
                //设置主角的移动速率
                self.SetSpeedRate(MainRoleMoveSpeedRate);
                self.isLeader = (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id);
                //player.isInBattle = Human.Instance.PetModel.getLeader().IsPetOnFight();
                self.isInBattle = Human.Instance.PetModel.getLeader().isOnFight ? HeadFlag.ZHAN_DOU : HeadFlag.NONE;
                self.VipLevel = PlayerModel.Ins.GetMyVipLevel();
				if (Human.Instance.getShowChenghao () == 1)
				{
					self.title = Human.Instance.getChenghaoName();
				}
				else
				{
					self.title = "";
				}
                updateSelfRide();
                updateSelfWing();
                //updateSelfVIP();
                Human.Instance.updateSelfWeapon(self);
                //bool isInYunLiang = (Singleton.getObj(typeof(YunLiangModel)) as YunLiangModel).isYunLiangIng();
                //player.WearingFashionTplId = Human.Instance.PetModel.GetFashionTplId();

                /*
                if (ZoneModel.ins.teamLeaderLTPixelPos != Vector2.zero)
                {
                    TeamLeaderPosUpdated();
                }
                */
            }
            else
            {
                self.Idle();
                self.localPosition = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));
                self.ResetNavMeshAgent();
                //self.ResetMoveRequest();
            }

            if (!ZoneModel.ins.isCanMoveFreely)
            {
                long leaderUUID = TeamModel.ins.GetLeaderUUID();
                ZoneCharacter leader = GetCharacter(leaderUUID);
                if (leader != null)
                {
                    ZoneModel.ins.teamLeaderLTPixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(leader.localPosition);
                    TeamLeaderPosUpdated(leader);
                    ZoneModel.ins.isTeamLeaderPosUpdatedBeforeZoneInited = false;
                }
                else
                {
                    if (ZoneModel.ins.isTeamLeaderPosUpdatedBeforeZoneInited)
                    {
                        TeamLeaderPosUpdated(leader);
                        ZoneModel.ins.isTeamLeaderPosUpdatedBeforeZoneInited = false;
                    }
                }
            }
        }

        public void updateSelfRide()
        {
            /*
            List<Pet> ridePets = Human.Instance.PetModel.getPetListByType(PetType.PET_FOR_RIDE);
            int ridePetTplId = 0;
            for (int i = 0; i < ridePets.Count; i++)
            {
                //if (ridePets[i] != null && ridePets[i].IsPetOnFight())
                if (ridePets[i] != null && ridePets[i].isOnFight)
                {
                    ridePetTplId = ridePets[i].getTplId();
                    break;
                }
            }
            */
            Pet ridePet = Human.Instance.PetModel.getRidePet();
            int ridePetTplId = 0;
            if (ridePet != null)
            {
                ridePetTplId = ridePet.getTplId();
            }
            if (PropertyUtil.IsLegalID(ridePetTplId))
            {
                //if (!mYunLiangModel.isYunLiangIng())
                //{
                self.Ride(ridePetTplId);
                //}
                //else
                //{
                //    self.UnRide(false);
                //}
            }
            else
            {
                self.UnRide(true);
            }
        }

        public void updateSelfWing()
        {
            chibangModel.updateMyWingWear();
        }
        /*
        public void updateSelfVIP()
        {
            int myviplevel = PlayerModel.Ins.GetMyVipLevel();
            if (myviplevel>0)
            {
                if (self != null)
                {
                    self.VipLevel = myviplevel;
                }
                if (self != null && self.displayModel != null && self.displayModel.avatar!=null)
                {
                    self.ShowVIPSign();
                }
            }
            else
            {
                if (self != null) self.HideVipSign();
            }
        }
        */

        private ZoneCharacter CreateCharacter(long uuid, string displayModelId, string name, int leftTopPixelX, int leftTopPixelY, bool showShadow = true, bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true, bool isSelf = false)
        {
            Vector3 pos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));
            ZoneCharacter cha = new ZoneCharacter();
            //name += ":"+uuid;
            cha.isSelf = isSelf;
            cha.Init(uuid, displayModelId, name, pos, Vector3.zero, showShadow, isEnableRidePet, isEnableWing, isEnableWeapon);
            if (mAllCharactersHidden)
            {
                cha.SetActive(false);
            }
            return cha;
        }

        public void Update()
        {
            if (mQueueForCreateSize > 0)
            {
                if (--mCreateCDFrameLeft <= 0)
                {
                    AddCharacterFromQueue();
                    mCreateCDFrameLeft = ZoneDef.MAP_CHARACTER_CREATE_CD_FRAME;
                }
            }

            if (self != null)
            {
                self.Update();
            }

            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].Update();
            }

            if (ZoneModel.ins.characterChangedList != null &&
                ZoneManager.ins.curZoneInited &&
                ZoneModel.ins.characterChangedZoneId == ZoneModel.ins.mapTpl.Id)
            {
                List<MapPlayerInfoData> t = new List<MapPlayerInfoData>(ZoneModel.ins.characterChangedList.Values);
                MapCharacterUpdated(t);
                ZoneModel.ins.characterChangedList = null;
            }
        }

        private void AddCharacterFromQueue()
        {
            IDictionaryEnumerator enumerator = mQueueForCreate.GetEnumerator();
            long uuid = 0;
            while(enumerator.MoveNext())
            {
                uuid = (long)enumerator.Key;
                break;
            }

            if (uuid > 0)
            {
                //ClientLog.Log("Add:" + data.uuid + " name:" + data.name + " modelId:" + data.model + " x:" + data.x + " y:" + data.y);
                MapPlayerInfoData data = mQueueForCreate[uuid];
                if (self.uuid == data.uuid)
                {
                    ClientLog.LogWarning("uuid:" + data.uuid + " name:" + data.name + " already exists!");
                    self.UpdateData(data);
                    mQueueForCreate.Remove(uuid);
                    mQueueForCreateSize--;
                    return;
                }
                for (int i = 0; i < mOthersCount; i++)
                {
                    if (mOthers[i].uuid == data.uuid)
                    {
                        mOthers[i].UpdateData(data);
                        ClientLog.LogWarning("uuid:" + data.uuid + " name:" + data.name + " already exists!");
                        mQueueForCreate.Remove(uuid);
                        mQueueForCreateSize--;
                        return;
                    }
                }

                if (mOthersCount < CommonDefines.MAX_CHARACTERS_ON_SCENE - 1)
                {

                    ZoneCharacter cha = CreateCharacter(data.uuid, GetDisplayModelId(data), data.name, data.x, data.y);
                    cha.UpdateData(data);
                    mOthers.Add(cha);
                    mOthersCount++;
                    if (!ZoneModel.ins.isCanMoveFreely)
                    {
                        long leaderUUID = TeamModel.ins.GetLeaderUUID();
                        if (leaderUUID == cha.uuid)
                        {
                            ZoneModel.ins.teamLeaderLTPixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(cha.localPosition);
                            TeamLeaderPosUpdated(cha);
                        }
                    }
                }
                else
                {
                    ClientLog.LogWarning("同屏玩家人数已达上限!");
                }
                mQueueForCreate.Remove(uuid);
                mQueueForCreateSize--;
            }
        }

        public string GetDisplayModelId(MapPlayerInfoData data)
        {
            string displayModelId = data.model;
            if (data.isForaging == 1)
            {
                displayModelId = ClientConstantDef.YUNLIANGREN;
            }
            else
            {
                if (PropertyUtil.IsLegalID(data.fashionTplId))
                {
                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(data.fashionTplId);
                    if (it != null)
                    {
                        displayModelId = it.modelId;
                    }
                }
            }
            return displayModelId;
        }

        public void FixedUpdate()
        {
            if (self != null)
            {
                self.FixedUpdate();
            }

            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].FixedUpdate();
            }
        }

        public void LateUpdate()
        {
            if (self != null)
            {
                self.LateUpdate();
            }

            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].LateUpdate();
            }
        }

        public ZoneCharacter GetCharacter(long uuid)
        {
            if (!PropertyUtil.IsLegalID(uuid))
            {
                return null;
            }
            if (self != null && self.uuid == uuid)
            {
                return self;
            }

            for (int i = 0; i < mOthersCount; i++)
            {
                if (mOthers[i].uuid == uuid)
                {
                    return mOthers[i];
                }
            }

            return null;
        }
        
        public void MapCharacterUpdated(List<MapPlayerInfoData> list)
        {
            bool isHideOthers = SystemSettings.ins.isHideOthers;
            int len = list.Count;
            ClientLog.LogWarning("MapCharacterUpdated  size:" + len);
            for (int i = 0; i < len; i++)
            {
                MapPlayerInfoData data = list[i];
                if (mOthersDataFromServer.ContainsKey(data.uuid))
                {
                    if (data.msgType == 1)
                    {
                        mOthersDataFromServer.Remove(data.uuid);
                        othersCountForFPS--;
                    }
                    else
                    {
                        mOthersDataFromServer[data.uuid] = data;
                    }
                }
                else
                {
                    if (data.msgType != 1)
                    {
                        mOthersDataFromServer.Add(data.uuid, data);
                        othersCountForFPS++;
                    }
                }

                switch (data.msgType)
                {
                    case 1:
                        RemoveCharacter(data);
                        break;
                    case 2:
                        CharacterMoved(data);
                        break;
                    case 3:
                        AddCharacter(data);
                        break;
                    case 4:
                        CharacterUpdated(data);
                        break;
                    default:
                        ClientLog.LogError(data.uuid + " Unknown message type:" + data.msgType);
                        break;
                }

                long leaderUUID = TeamModel.ins.GetLeaderUUID();
                if (leaderUUID == data.uuid)
                {
                    if (data.msgType != 1)
                    {
                        ZoneModel.ins.teamLeaderLTPixelPos = new int[]{data.x, data.y};
                        TeamLeaderPosUpdated(GetCharacter(leaderUUID));
                    }
                }
            }
        }

        private void AddCharacter(MapPlayerInfoData data)
        {
            if (SystemSettings.ins.isHideOthers)
            {
                if (TeamModel.ins.GetTeamMemberInfo(data.uuid) == null)
                {
                    return;
                }
            }

            if (mQueueForCreate.ContainsKey(data.uuid))
            {
                mQueueForCreate[data.uuid] = data;
            }
            else
            {
                mQueueForCreate.Add(data.uuid, data);
                mQueueForCreateSize++;
            }
        }

        private void RemoveCharacter(MapPlayerInfoData data)
        {
            //ClientLog.Log("Remove:" + data.uuid + " name:" + data.name);
            for (int i = 0; i < mOthersCount; i++)
            {
                if (mOthers[i].uuid == data.uuid)
                {
                    mOthers[i].Destroy();
                    mOthers.RemoveAt(i);
                    mOthersCount--;
                    break;
                }
            }

            if (mQueueForCreate.ContainsKey(data.uuid))
            {
                mQueueForCreate.Remove(data.uuid);
                mQueueForCreateSize--;
            }
            //ClientLog.LogWarning("not exists!");
        }

        private void CharacterMoved(MapPlayerInfoData data)
        {
            //ClientLog.Log("Move:" + data.uuid + " name:" + data.name);
            for (int i = 0; i < mOthersCount; i++)
            {
                if (mOthers[i].uuid == data.uuid)
                {
                    if ((TeamModel.ins.GetTeamMemberInfo(data.uuid) == null || TeamModel.ins.GetTeamMemberInfo(data.uuid).status == 2) || TeamModel.ins.GetLeaderUUID() == data.uuid)
                    {
                        int leftTopPixelX = data.x;
                        int leftTopPixelY = data.y;
                        Vector3 pos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));
                        //ClientLog.Log("Move:" + data.uuid + " name:" + data.name + " pixelx:" + data.x + " pixely:" + data.y + "unityPos:" + pos);
                        mOthers[i].MoveTo(pos, 0, true);
                        return;
                    }
                }
            }

            IDictionaryEnumerator enumerator = mQueueForCreate.GetEnumerator();
            while(enumerator.MoveNext())
            {
                MapPlayerInfoData queueData = (MapPlayerInfoData)enumerator.Value;
                if (queueData.uuid == data.uuid)
                {
                    queueData.x = data.x;
                    queueData.y = data.y;
                    return;
                }
            }

            AddCharacter(data);


            //			CharacterUpdated(data);
            //ClientLog.LogWarning("not exists!");
        }

        private void CharacterUpdated(MapPlayerInfoData data)
        {
            //ClientLog.Log("Update:" + data.uuid + " name:" + data.name + " isFight:" + data.isFighting + " isLeader:" + data.isLeader);

            for (int i = 0; i < mOthersCount; i++)
            {
                if (mOthers[i].uuid == data.uuid)
                {
                    mOthers[i].UpdateData(data);
                    break;
                }
            }

            if (mQueueForCreate.ContainsKey(data.uuid))
            {
                mQueueForCreate[data.uuid] = data;
            }
            
            //ClientLog.LogWarning("not exists!");
        }

        public void SetCharacterPosition(int zoneId, long uuid, int leftTopPixelX, int leftTopPixelY)
        {
            Vector3 pos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(leftTopPixelX, leftTopPixelY));

            if (self.uuid == uuid)
            {
                self.localPosition = pos;
            }
            else
            {
                for (int i = 0; i < mOthersCount; i++)
                {
                    if (mOthers[i].uuid == uuid)
                    {
                        mOthers[i].localPosition = pos;
                        break;
                    }
                }

                MapPlayerInfoData queueData = null;
                mQueueForCreate.TryGetValue(uuid, out queueData);
                if (queueData != null)
                {
                    queueData.x = leftTopPixelX;
                    queueData.y = leftTopPixelY;
                }
            }
        }

        public void ClearCharacters(bool includeSelf = false)
        {
            if (includeSelf)
            {
                if (self != null)
                {
                    self.Destroy();
                    self = null;
                }
            }
            ClearOthers();

            mOthersDataFromServer.Clear();
        }

        private void ClearOthers()
        {
            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].Destroy();
            }

            mOthers.Clear();
            mOthersCount = 0;

            mQueueForCreate.Clear();
            mQueueForCreateSize = 0;
        }

        public void ShowCharacters()
        {
            if (self != null)
            {
                self.SetActive(true);
            }
            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].SetActive(true);
            }

            mAllCharactersHidden = false;
        }

        public void showChatBubble(ChatMsgData msg)
        {
            if (msg == null)
            {
                return;
            }
            if (self != null && msg.getFromRoleUUID() == self.uuid.ToString())
            {
                self.ShowChatBubble(RelationChatItemScript.getContentText(msg), TeamModel.ins.GetLeaderUUID() == self.uuid, self.isInBattle!=HeadFlag.NONE);
            }
            else
            {
                for (int i = 0; mOthers != null && i < mOthers.Count; i++)
                {
                    ZoneCharacter cha = mOthers[i];
                    if (cha.uuid.ToString() == msg.getFromRoleUUID())
                    {
                        cha.ShowChatBubble(RelationChatItemScript.getContentText(msg), cha.playerInfo.isLeader == 1, cha.playerInfo.isFighting == 1);
                        break;
                    }
                }
            }
        }

        public void HideCharacters()
        {
            if (self != null)
            {
                self.SetActive(false);
            }
            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].SetActive(false);
            }

            mAllCharactersHidden = true;
        }

        public List<ZoneCharacter> others
        {
            get
            {
                return this.mOthers;
            }
        }

        public int othersCount
        {
            get
            {
                return this.mOthersCount;
            }
        }

        /// <summary>
        /// 主角的移动速度 系数
        /// </summary>
        public float MainRoleMoveSpeedRate
        {
            get { return _mainRoleMoveSpeedRate; }
            set
            {
                _mainRoleMoveSpeedRate = value;
                self.SetSpeedRate(_mainRoleMoveSpeedRate);
            }
        }

        public void TeamLeaderPosUpdated(ZoneCharacter leader)
        {
            if (!ZoneModel.ins.isCanMoveFreely)
            {
                bool success = false;
                int[] pos = ZoneModel.ins.teamLeaderLTPixelPos;
                Vector3 targetUnityPos = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(pos[0], pos[1]));

                if (leader != null)
                {
                    if (leader.localPosition.x == targetUnityPos.x && leader.localPosition.z == targetUnityPos.z)
                    {
                        targetUnityPos = leader.localPosition - leader.forward * 1.5f;
                    }
                    else
                    {
                        targetUnityPos = targetUnityPos - (targetUnityPos - leader.localPosition).normalized * 1.5f;
                    }
                }

                int teamMembersLen = TeamModel.ins.myTeamMemberList.Length;

                for (int i = 0; i < teamMembersLen; i++)
                {
                    TeamMemberInfo memberInfo = TeamModel.ins.myTeamMemberList[i];
                    if (memberInfo.status != 1)
                    {
                        continue;
                    }
                    long teamMemberUUID = memberInfo.uuid;
                    if (teamMemberUUID != TeamModel.ins.GetLeaderUUID())
                    {
                        ZoneCharacter teamMember = GetCharacter(teamMemberUUID);
                        if (teamMember != null)
                        {
                            if (teamMember.navMeshAgent.isOnNavMesh && teamMember.navMeshAgent.isActiveAndEnabled)
                            {
                                UnityEngine.AI.NavMeshHit hit;
                                Vector2 randomRange = UnityEngine.Random.insideUnitCircle * 0.5f;
                                targetUnityPos.x += randomRange.x;
                                targetUnityPos.z += randomRange.y;

                                success = UnityEngine.AI.NavMesh.SamplePosition(targetUnityPos * (1.0f + (float)i / 20.0f), out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas);

                                if (success)
                                {
                                    UnityEngine.AI.NavMeshPath playerFollowLeaderPath = new UnityEngine.AI.NavMeshPath();
                                    success = teamMember.navMeshAgent.CalculatePath(hit.position, playerFollowLeaderPath);
                                    if (success)
                                    {
                                        teamMember.MoveTo(hit.position, 0, false);
                                    }
                                    else
                                    {
                                        //player.MoveTo(currentPos, 0, true);
                                        //player.localPosition = targetUnityPos;
                                        teamMember.MoveTo(targetUnityPos, 0, false);
                                    }
                                }
                                else
                                {
                                    //player.MoveTo(currentPos, 0, true);
                                    //player.localPosition = targetUnityPos;
                                    teamMember.MoveTo(targetUnityPos, 0, false);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void TeamMembersFollowMe(Vector3 targetPos)
        {
            if (TeamModel.ins.hasTeam())
            {
                int teamMembersLen = TeamModel.ins.myTeamMemberList.Length;
                for (int i = 0; i < teamMembersLen; i++)
                {
                    TeamMemberInfo memberInfo = TeamModel.ins.myTeamMemberList[i];
                    if (memberInfo.status != 1)
                    {
                        continue;
                    }
                    
                    ZoneCharacter teamMember = GetCharacter(memberInfo.uuid);
                    if (teamMember != null && teamMember != self)
                    {
                        if (teamMember.navMeshAgent.isOnNavMesh && teamMember.navMeshAgent.isActiveAndEnabled)
                        {
                            bool success = false;
                            Vector3 targetUnityPos = targetPos - (targetPos - self.localPosition).normalized * 1.5f;

                            Vector2 randomRange = UnityEngine.Random.insideUnitCircle * 0.5f;
                            targetUnityPos.x += randomRange.x;
                            targetUnityPos.z += randomRange.y;

                            UnityEngine.AI.NavMeshHit hit;
                            success = UnityEngine.AI.NavMesh.SamplePosition(targetUnityPos, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas);

                            if (success)
                            {
                                UnityEngine.AI.NavMeshPath playerFollowLeaderPath = new UnityEngine.AI.NavMeshPath();
                                success = teamMember.navMeshAgent.CalculatePath(hit.position, playerFollowLeaderPath);
                                if (success)
                                {
                                    teamMember.MoveTo(hit.position, 0, true);
                                }
                                else
                                {
                                    //player.MoveTo(currentPos, 0, true);
                                    //player.localPosition = targetUnityPos;
                                    teamMember.MoveTo(targetUnityPos, 0, false);
                                }
                            }
                            else
                            {
                                teamMember.MoveTo(targetUnityPos, 0, false);
                            }
                        }
                    }
                }
            }
        }

        /**
         *玩家选择“显示其他玩家”时调用此方法。
         */
        public void AddOthers()
        {
            foreach (KeyValuePair<long, MapPlayerInfoData> kv in mOthersDataFromServer)
            {
                if (GetCharacter(kv.Key) == null)
                {
                    AddCharacter(kv.Value);
                }
            }
        }

        /**
         *玩家选择“隐藏其他玩家”时调用此方法。
         */
        public void RemoveOthers()
        {
            for (int i = 0; i < mOthersCount; i++)
            {
                if (TeamModel.ins.GetTeamMemberInfo(mOthers[i].uuid) == null)
                {
                    mOthers[i].Destroy();
                    mOthers.RemoveAt(i);
                    i--;
                    mOthersCount--;
                }
            }

            List<long> uuids = new List<long>();
            IDictionaryEnumerator enumerator = mQueueForCreate.GetEnumerator();
            while (enumerator.MoveNext())
            {
                long uuid = (long)enumerator.Key;
                if (TeamModel.ins.GetTeamMemberInfo(uuid) == null)
                {
                    uuids.Add(uuid);
                }
            }

            int uuidsLen = uuids.Count;
            for (int i = 0; i < uuidsLen; i++)
            {
                mQueueForCreate.Remove(uuids[i]);
            }
            mQueueForCreateSize -= uuidsLen;
        }

        public void RemoveAll()
        {
            if (self != null)
            {
                self.Destroy();
                self = null;
            }

            for (int i = 0; i < mOthersCount; i++)
            {
                mOthers[i].Destroy();
            }

            mOthers.Clear();
            mOthersCount = 0;
            mQueueForCreate.Clear();
            mQueueForCreateSize = 0;
        }
    }
}