using System;
using System.Collections.Generic;
using UnityEngine;
using app.net;
using app.db;
using app.human;
using app.utils;
using app.pet;
using app.state;
using app.npc;

namespace app.zone
{
    public class ZoneModel : AbsModel
    {
        public const string MAP_CHANGE = "MAP_CHANGE";

        public float zoneTime { get; set; }
        public float fixedZoneTime { get; set; }
        public float viewportWidth { get; set; }
        public float viewportHeight { get; set; }
        public int mapPixelWidth { get; set; }
        public int mapPixelHeight { get; set; }

        private MapTemplate mMapTpl;
        public MapTemplate mapTpl
        {
            get
            {
                return mMapTpl;
            }
            set
            {
                mMapTpl = value;
                dispatchChangeEvent(MAP_CHANGE, value);
            }
        }
        public long playerUUID { get; set; }
        public int playerStartLeftTopPixelX { get; set; }
        public int playerStartLeftTopPixelY { get; set; }

        public int tryEnterZoneId { get; set; }

        public int characterChangedZoneId { get; set; }

        public bool isZoneLoaded { get; set; }
        //        public List<MapPlayerInfoData> characterChangedList { get; set; }
        public Dictionary<long, MapPlayerInfoData> characterChangedList { get; set; }

        public bool isCanMoveFreely { get; set; }

        public ZoneMap zoneMap { get; set; }

        public bool isTeamLeaderPosUpdatedBeforeZoneInited { get; set; }

        public Vector3 selfRot { get; set; }

        public GameObject selectedEffect { get; set; }

        private List<object[]> mLoadList = new List<object[]>();
        private List<string> mDisposeableResList = new List<string>();
        private List<string> mNeedInitMainAssetAfterLoadList = new List<string>();

        private int[] mTeamLeaderLTPixelPos = new int[2];

        private static ZoneModel mIns = null;
        private RTimer sendCGMapEnterTime;
        private bool sendCGMapEnterCD = false;

        public static ZoneModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new ZoneModel();
                }
                return mIns;
            }
        }

        public ZoneModel()
        {
            if (mIns != null)
            {
                throw new Exception("ZoneModel instance already exists!");
            }
            isCanMoveFreely = true;
        }

        public void MapChanged()
        {
            mTeamLeaderLTPixelPos[0] = 0;
            mTeamLeaderLTPixelPos[1] = 0;
        }

        public int[] teamLeaderLTPixelPos
        {
            get
            {
                return mTeamLeaderLTPixelPos;
            }
            set
            {
                mTeamLeaderLTPixelPos[0] = value[0];
                mTeamLeaderLTPixelPos[1] = value[1];
                //ZoneCharacterManager.ins.TeamLeaderPosUpdated();
            }
        }

        public void ClearLoadedList()
        {
            int count = mLoadList.Count;
            for (int i = 0; i < count; i++)
            {
                //SourceManager.Ins.ClearAllReference(mLoadList[i]);
                if (mDisposeableResList.Contains((string)mLoadList[i][0]))
                {
                    SourceManager.Ins.unignoreDispose((string)mLoadList[i][0]);
                }
                //SourceManager.Ins.ClearAllReference(mLoadList[i]);
            }
            mLoadList.Clear();
            mDisposeableResList.Clear();
            mNeedInitMainAssetAfterLoadList.Clear();
        }

        public List<object[]> GetMapMonstersLoadList(MapTemplate mapTpl)
        {
            List<object[]> res = new List<object[]>();

            Pet pet = Human.Instance.PetModel.getChongWu();
            if (pet != null)
            {
                //PushCharacterPathToLoadList(PathUtil.Ins.GetCharacterDisplayModelPath(pet.getTpl().modelId), true);
                string[] pathes = PathUtil.Ins.GetCharacterDisplayModelPath(pet.getTpl().modelId, true);
                int pathesLen = pathes.Length;
                for (int j = 0; j < pathesLen; j++)
                {
                    res.Add(new object[]{pathes[j], LoadArgs.SLIMABLE, LoadContentType.ABL});
                }
            }

            if (PropertyUtil.IsLegalID(mapTpl.meetMonsterPlanId))
            {
                //本地图所有敌人。
                List<MapMeetMonsterTemplate> meetMpnsterpls = MapMeetMonsterTemplateDB.Instance.GetTemplatesByPlanId(mapTpl.meetMonsterPlanId);
                int planLen = meetMpnsterpls.Count;
                for (int i = 0; i < planLen; i++)
                {
                    MapMeetMonsterTemplate meetMpnsterpl = meetMpnsterpls[i];
                    if (meetMpnsterpl != null)
                    {
                        EnemyArmyTemplate enemyArmyTpl = EnemyArmyTemplateDB.Instance.getTemplate(meetMpnsterpl.enemyArmyId);
                        if (enemyArmyTpl != null)
                        {
                            List<string> modelIds = new List<string>();
                            int len = enemyArmyTpl.enemyIdAndProbList.Count;
                            for (int j = 0; j < len; j++)
                            {
                                if (PropertyUtil.IsLegalID(enemyArmyTpl.enemyIdAndProbList[j].enemyId))
                                {
                                    EnemyTemplate enemyTpl = EnemyTemplateDB.Instance.getTemplate(enemyArmyTpl.enemyIdAndProbList[j].enemyId);
                                    if (!modelIds.Contains(enemyTpl.modelId))
                                    {
                                        modelIds.Add(enemyTpl.modelId);
                                        string[] pathes = PathUtil.Ins.GetCharacterDisplayModelPath(enemyTpl.modelId, true);
                                        int pathesLen = pathes.Length;
                                        for (int k = 0; k < pathesLen; k++)
                                        {
                                            res.Add(new object[]{pathes[k], LoadArgs.SLIMABLE, LoadContentType.ABL});
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }

        public List<object[]> CreateLoadList(MapTemplate mapTpl)
        {
            PushPathToLoadList(PathUtil.Ins.GetZoneScenePath(mapTpl.icon), LoadArgs.NONE, LoadContentType.ABL, true);
            return mLoadList;
         //   PushPathToLoadList(PathUtil.Ins.GetZoneSceneMapTilesPath(mapTpl.icon), false, true);
         //   PushPathToLoadList(PathUtil.Ins.GetMusicPath(mapTpl.music, AudioEnumType.BackGround), false, true);
            //res.Add(PathUtil.Ins.GetEffectPath(ZoneDef.ZONE_PORTAL_MODEL_NAME));
            //本地图npc。
            //#if UNITY_EDITOR||!UNITY_ANDROID
            Dictionary<int, MapNpcTemplate> mapNpcs = MapNpcTemplateDB.Instance.GetMapNpcDicByMapId(mapTpl.Id);
            if (mapNpcs != null)
            {
                foreach (KeyValuePair<int, MapNpcTemplate> pair in mapNpcs)
                {
                    NpcTemplate npcTpl = NpcTemplateDB.Instance.getTemplate(pair.Value.npcId);
                    NPCType npcType = (NPCType)npcTpl.type;
                    bool needDependence = ((npcType == NPCType.TRANSFER_POINT ||npcType == NPCType.MAP_EFFECT)? false : true);
                    if (npcType != NPCType.MAP_EFFECT)
                    {
                        PushCharacterPathToLoadList(
                            PathUtil.Ins.GetCharacterDisplayModelPath(npcTpl.model3DId, needDependence), true);
                    }
                    else
                    {
                        PushCharacterPathToLoadList(new string[] { PathUtil.Ins.GetMapEffectPath(npcTpl.model3DId) }, true);
                    }
                    if (!string.IsNullOrEmpty(npcTpl.model2DId))
                    {
                        //PushPathToLoadList(PathUtil.Ins.GetSpineNPCDisplayModelPath(npcTpl.model2DId), false);
                    }
                }
            }
            //#endif

            if (PropertyUtil.IsLegalID(mapTpl.meetMonsterPlanId))
            {
                //出战宠物。
                Pet pet = Human.Instance.PetModel.getChongWu();
                if (pet != null)
                {
                    PushCharacterPathToLoadList(PathUtil.Ins.GetCharacterDisplayModelPath(pet.getTpl().modelId), true);
                }

                //所有伙伴。
                foreach (KeyValuePair<int, PetFriendTemplate> pair in PetFriendTemplateDB.Instance.getIdKeyDic())
                {
                    PushCharacterPathToLoadList(PathUtil.Ins.GetCharacterDisplayModelPath(PetTemplateDB.Instance.getTemplate(pair.Value.Id).modelId), true);
                }

                //本地图所有敌人。
                List<MapMeetMonsterTemplate> meetMpnsterpls = MapMeetMonsterTemplateDB.Instance.GetTemplatesByPlanId(mapTpl.meetMonsterPlanId);
                int planLen = meetMpnsterpls.Count;
                for (int i = 0; i < planLen; i++)
                {
                    MapMeetMonsterTemplate meetMpnsterpl = meetMpnsterpls[i];
                    if (meetMpnsterpl != null)
                    {
                        EnemyArmyTemplate enemyArmyTpl = EnemyArmyTemplateDB.Instance.getTemplate(meetMpnsterpl.enemyArmyId);
                        if (enemyArmyTpl != null)
                        {
                            if (PropertyUtil.IsLegalID(enemyArmyTpl.enemyIdAndProbList[i].enemyId))
                            {
                                int len = enemyArmyTpl.enemyIdAndProbList.Count;
                                for (int j = 0; j < len; j++)
                                {
                                    EnemyTemplate enemyTpl = EnemyTemplateDB.Instance.getTemplate(enemyArmyTpl.enemyIdAndProbList[j].enemyId);
                                    PushCharacterPathToLoadList(PathUtil.Ins.GetCharacterDisplayModelPath(enemyTpl.modelId), true);
                                }
                            }
                        }
                    }
                }
                
            }
            
            StateBase lastState = StateManager.Ins.getLastState();
            if (lastState != null && lastState.state == StateDef.login)
            {
                List<Pet> pets = PetModel.Ins.getPetListByType(PetType.PET_FOR_RIDE);
                int len = pets.Count;
                for (int i = 0; i < len; i++)
                {
                    PushCharacterPathToLoadList(PathUtil.Ins.GetCharacterDisplayModelPath(pets[i].getTpl().modelId), false);
                }
            }

#if UNITY_EDITOR||!UNITY_ANDROID
            if (lastState != null && lastState.state == StateDef.login)
            {
                /*
                //背包内所有物品
                List<ItemBag> itemBags = Human.Instance.BagModel.getAll();
                int bagCount = itemBags.Count;
                for (int i = 0; i < bagCount; i++)
                {
                    List<ItemDetailData> items = itemBags[i].itemList;
                    int itemCount = items.Count;
                    for (int j = 0; j < itemCount; j++)
                    {
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(items[j].itemTemplate.icon, PathUtil.TEXTUER_ITEM));
                    }
                }
                */
                /*
                //主角身上的所有装备
                ItemBag leaderEquipItemBag = Human.Instance.PetModel.getLeaderEquipItemBag();
                if (leaderEquipItemBag!=null)
                {
                    int leaderEquipCount = leaderEquipItemBag.itemList.Count;
                    for (int i = 0; i < leaderEquipCount; i++)
                    {
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(leaderEquipItemBag.itemList[i].itemTemplate.icon, PathUtil.TEXTUER_ITEM));
                    }
                }
                
                //主角身上的所有宝石
                ItemBag leaderGemItemBag = Human.Instance.PetModel.getLeaderGemItemBag();
                if (leaderGemItemBag != null)
                {
                    int leaderGemCount = leaderGemItemBag.itemList.Count;
                    for (int i = 0; i < leaderGemCount; i++)
                    {
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(leaderGemItemBag.itemList[i].itemTemplate.icon, PathUtil.TEXTUER_ITEM));
                    }
                }
                */

                /*
                //主角的心法
                List<HumanMainSkillTemplate> xinfaTemplateList = HumanMainSkillTemplateDB.Instance.GetXinFaListByJobType(Human.Instance.PetModel.getLeader().getTpl().jobId);
                int xinfaCount = xinfaTemplateList.Count;
                for (int i = 0; i < xinfaCount; i++)
                {
                    PushPathToLoadList(PathUtil.Ins.GetUITexturePath(xinfaTemplateList[i].Id.ToString(), PathUtil.XINFA_ICON));
                }
                
                //主角的技能
                PetSkillInfo[] leaderSkillList = Human.Instance.PetModel.GetLeaderSkillInfo();
                if (leaderSkillList!=null)
                {
                    int leaderSkillCount = leaderSkillList.Length;
                    for (int i = 0; i < leaderSkillCount; i++)
                    {
                        SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(leaderSkillList[i].skillId);
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL));
                    }
                }
                
                //现有宠物列表
                List<Pet> allPet = Human.Instance.PetModel.getAllPet();
                int petCount = allPet.Count;
                for (int i = 0; i < petCount; i++)
                {
                    if (allPet[i] != null && allPet[i].getTpl() != null)
                    {
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(allPet[i].getTpl().modelId,
                            PathUtil.TEXTUER_HEAD));
                    }
                    //每个宠物的技能
                    PetSkillInfo[] petSkillList = allPet[i].PetInfo.skillList;
                    int petSkillCount = petSkillList.Length;
                    for (int j = 0; j < petSkillCount; j++)
                    {
                        SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(petSkillList[j].skillId);
                        PushPathToLoadList(PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL));
                    }
                }
                */
            }
#endif
            return mLoadList;
        }

        private void PushPathToLoadList(string path, LoadArgs loadArgs, LoadContentType contentType, bool disposeable)
        {
            /*
            if (!mLoadList.Contains(path))
            {
                mLoadList.Add(path);
                if (needInitMainAsset && !mNeedInitMainAssetAfterLoadList.Contains(path))
                {
                    mNeedInitMainAssetAfterLoadList.Add(path);
                }
                
                if (disposeable)
                {
                    mDisposeableResList.Add(path);
                }
            }
            */
            mLoadList.Add(new object[]{path, loadArgs, contentType});
            if (disposeable)
            {
                mDisposeableResList.Add(path);
            }
        }

        private void PushCharacterPathToLoadList(string[] pathes, bool disposeable)
        {
            /*
            int len = pathes.Length;
            for (int i = 0; i < len; i++)
            {
                PushPathToLoadList(pathes[i], (i == len - 1), disposeable);
            }
            */
        }

        public bool CheckCanMoveFreely()
        {
            if (isCanMoveFreely)
            {
                if (HeadFlag.NONE != ZoneCharacterManager.ins.self.isInBattle)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("正在采集，不能自由移动！");
                    return false;
                }
                return true;
            }
            ZoneBubbleManager.ins.BubbleSysMsg("正在组队状态，不能自由移动！");
            return false;
        }
        /// <summary>
        /// 检查地图类型
        /// </summary>
        /// <param name="maptype"></param>
        /// <param name="mapid"></param>
        /// <returns></returns>
        public bool CheckMapType(MapType maptype, int mapid)
        {
            if (mapid == 0)
            {
                return false;
            }
            MapTemplate mt = MapTemplateDB.Instance.getTemplate(mapid);
            if (mt != null)
            {
                if (mt.mapTypeId == (int)maptype)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 进入地图
        /// </summary>
        /// <param name="mapid"></param>
        public void sendCGMapPlayerEnter(int mapid)
        {
            if (sendCGMapEnterCD)
            {
                return;
            }
            if (AutoMaticManager.Ins.CurAutoMaticType != AutoMaticManager.AutoMaticType.None)
            {
                if (sendCGMapEnterTime == null)
                {
                    sendCGMapEnterTime = TimerManager.Ins.createTimer(1000, 2000, null, entermapTimeEnd);
                    sendCGMapEnterTime.start();
                }
                else
                {
                    sendCGMapEnterTime.Reset(1000, 2000);
                    sendCGMapEnterTime.Restart();
                }
                sendCGMapEnterCD = true;
            }
            MapCGHandler.sendCGMapPlayerEnter(mapid);
        }

        public void entermapTimeEnd(RTimer r = null)
        {
            if (r == null)
            {
                if (sendCGMapEnterTime != null)
                {
                    sendCGMapEnterTime.stop();
                }
            }
            sendCGMapEnterCD = false;
        }

        public bool IsNeedInitMainAsset(string path)
        {
            return mNeedInitMainAssetAfterLoadList.Contains(path);
        }

        public override void Destroy()
        {
            zoneTime = 0.0f;
            fixedZoneTime = 0.0f;
            viewportWidth = 0.0f;
            viewportHeight = 0.0f;
            mapPixelWidth = 0;
            mapPixelHeight = 0;

            mapTpl = null;
            playerUUID = 0;
            playerStartLeftTopPixelX = 0;
            playerStartLeftTopPixelY = 0;

            tryEnterZoneId = 0;

            characterChangedZoneId = 0;

            isZoneLoaded = false;

            if (characterChangedList != null)
            {
                characterChangedList.Clear();
                characterChangedList = null;
            }

            isCanMoveFreely = false;
            if (zoneMap != null)
            {
                zoneMap.Destroy();
                zoneMap = null;
            }

            isTeamLeaderPosUpdatedBeforeZoneInited = false;
            /*
            if (mLoadList != null)
            {
                mLoadList.Clear();
                mLoadList = null;
            }

            if (mNeedInitMainAssetAfterLoadList != null)
            {
                mNeedInitMainAssetAfterLoadList.Clear();
                mNeedInitMainAssetAfterLoadList = null;
            }
            */
            mLoadList.Clear();
            mDisposeableResList.Clear();
            mNeedInitMainAssetAfterLoadList.Clear();

            mTeamLeaderLTPixelPos[0] = 0;
            mTeamLeaderLTPixelPos[1] = 0;

            if (sendCGMapEnterTime != null)
            {
                sendCGMapEnterTime.stop();
                sendCGMapEnterTime = null;
            }
            sendCGMapEnterCD = false;

            mIns = null;
        }
    }
}