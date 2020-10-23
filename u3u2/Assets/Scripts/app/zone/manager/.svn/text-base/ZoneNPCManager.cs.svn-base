using System;
using System.Collections.Generic;
using app.config;
using app.db;
using app.human;
using app.model;
using app.net;
using app.state;
using app.utils;
using UnityEngine;
using app.npc;
using app.xinfa;

namespace app.zone
{
    public class ZoneNPCManager
    {
        /// <summary>
        /// 当前显示的所有npc 的 显示对象 字典，按照ZoneNpcType分类
        /// </summary>
        private Dictionary<ZoneNpcType, List<ZoneNPC>> mNpcDic;
        private List<ZoneNpcType> mNpcDicKeys = null;
        private int mNpcDicKeysLen = 0;
        /// <summary>
        /// 当前显示的所有npc的 数据 字典，按照ZoneNpcType分类
        /// </summary>
        private Dictionary<ZoneNpcType, List<NpcInfoData>> mNpcDataDic;
        /// <summary>
        /// 当前 等待创建的npc的 数据 字典，按照ZoneNpcType分类
        /// </summary>
        private Dictionary<ZoneNpcType, List<NpcInfoData>> mQueueForCreateDic;
        /// <summary>
        /// 当前地图id
        /// </summary>
        private int mMapId = 0;
        /// <summary>
        /// 地图上的角色创建间隔帧数
        /// </summary>
        private int mCreateCDFrameLeft = 0;
        /// <summary>
        /// 当前选中的npc
        /// </summary>
        private ZoneNPC _currentSelectedNpc;

        private int mCountForCreate = 0;

        private static ZoneNPCManager mIns;
        public static ZoneNPCManager Ins
        {
            get
            {
                if (mIns == null) mIns = new ZoneNPCManager();
                return mIns;
            }
        }
        public ZoneNPCManager()
        {
            if (mIns != null)
            {
                throw new Exception("ZoneNPCManager instance already exists!");
            }
            else
            {
                //初始化列表
                mNpcDic = new Dictionary<ZoneNpcType, List<ZoneNPC>>();
                mNpcDataDic = new Dictionary<ZoneNpcType, List<NpcInfoData>>();
                mQueueForCreateDic = new Dictionary<ZoneNpcType, List<NpcInfoData>>();
                for (int i = 0; i <= (int)ZoneNpcType.NpcMonster; i++)
                {
                    mNpcDic.Add((ZoneNpcType)(i), new List<ZoneNPC>());
                    mNpcDataDic.Add((ZoneNpcType)(i), new List<NpcInfoData>());
                    mQueueForCreateDic.Add((ZoneNpcType)(i), new List<NpcInfoData>());
                }

                mNpcDicKeys = new List<ZoneNpcType>(mNpcDic.Keys);
                mNpcDicKeysLen = mNpcDicKeys.Count;
            }
        }

        public void Init()
        {
            if (mMapId != ZoneModel.ins.mapTpl.Id)
            {
                //切换了地图
                mMapId = ZoneModel.ins.mapTpl.Id;
                ClearNpc();
                Dictionary<int, MapNpcTemplate> mapNpcs = MapNpcTemplateDB.Instance.GetMapNpcDicByMapId(mMapId);
                if (mapNpcs != null)
                {
                    //配置表中 ，该地图上有 的 npc
                    foreach (KeyValuePair<int, MapNpcTemplate> pair in mapNpcs)
                    {
                        List<int> limitquestList = ZoneNPC.initLimitQuestList(pair.Value.npcId);
                        if (limitquestList == null)
                        {
                            NpcInfoData npcinfodata = createNpcInfoData(pair.Value);
                            NpcTemplate npcinfo = NpcTemplateDB.Instance.getTemplate(pair.Value.npcId);
                            if ((int)NPCType.RESOURCE_POINT == npcinfo.type)
                            {
                                LifeSkillMapTemplate res = LifeSkillMapTemplateDB.Instance.GetMapResByMapidAndNpcid(mMapId, pair.Value.npcId);
                                if (null == res || 0 == res.showFlag)
                                {
                                    continue;
                                }
                            }
//                            if (!ServerConfig.instance.IsPassedCheck&&npcinfodata.npcId == 1007)
//                            {
//                                continue;
//                            }
                            //添加数据
                            mNpcDataDic[ZoneNpcType.Normal].Add(npcinfodata);
                            AddNpc(ZoneNpcType.Normal, npcinfodata);
                        }
                        if (limitquestList != null)
                        {
                            NpcInfoData npcinfodata = createNpcInfoData(pair.Value);
                            //添加数据
                            mNpcDataDic[ZoneNpcType.QuestNpc].Add(npcinfodata);

                            if (ZoneNPC.CanNpcVisibleByLimitQuest(limitquestList))
                            {
                                AddNpc(ZoneNpcType.QuestNpc, npcinfodata);
                            }
                        }
                    }
                }
                //该地图的npc怪
                for (int i = 0; i < mNpcDataDic[ZoneNpcType.NpcMonster].Count; i++)
                {
                    AddNpc(ZoneNpcType.NpcMonster, mNpcDataDic[ZoneNpcType.NpcMonster][i]);
                }
            }
            else
            {
                //ShowNPCs();
            }
            //更新npc身上的任务
            Human.Instance.QuestModel.UpdateNpcQuest();
        }

        private NpcInfoData createNpcInfoData(MapNpcTemplate tpl)
        {
            NpcInfoData npcinfodata = new NpcInfoData();
            npcinfodata.mapId = tpl.mapId;
            npcinfodata.npcId = tpl.npcId;
            npcinfodata.x = tpl.x;
            npcinfodata.y = tpl.y;
            //uuid 默认为null，只有npc类型的怪 有uuid
            npcinfodata.uuid = null;
            npcinfodata.isInBattle = 0;
            return npcinfodata;
        }

        /// <summary>
        /// 添加npc
        /// </summary>
        private void AddNpc(ZoneNpcType zoneNpcType, NpcInfoData npcinfo)
        {
            //加入等待列表
            mQueueForCreateDic[zoneNpcType].Add(npcinfo);
            mCountForCreate++;
        }

        public void ClearNpc()
        {
            //清空当前的显示对象
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].Destroy();
                }
                pair.Value.Clear();
            }
            //ClientLog.LogWarning("ClearNpc清空MNpcDic");
            //清空 普通npc和任务npc 的数据
            foreach (KeyValuePair<ZoneNpcType, List<NpcInfoData>> pair in mNpcDataDic)
            {
                if (pair.Key == ZoneNpcType.Normal || pair.Key == ZoneNpcType.QuestNpc)
                {
                    pair.Value.Clear();
                }
            }
            //清空正在等待创建的列表
            foreach (KeyValuePair<ZoneNpcType, List<NpcInfoData>> pair in mQueueForCreateDic)
            {
                pair.Value.Clear();
            }
        }

        #region npc 怪 添加、更新、删除、清空 逻辑
        /// <summary>
        /// 添加npc怪
        /// </summary>
        /// <param name="npcmonster"></param>
        public void AddNpcMonster(NpcInfoData npcmonster)
        {
            //添加数据
            mNpcDataDic[ZoneNpcType.NpcMonster].Add(npcmonster);
            AddNpc(ZoneNpcType.NpcMonster, npcmonster);
            //if (StateManager.Ins.getCurState().state == StateDef.zoneState)
            //{
            //    mQueueForCreate.Add(npcmonster);
            //}
        }

        public void UpdateNpcMonster(NpcInfoData npcmonster)
        {
            ZoneNPC zonenpc = GetNpc(npcmonster.npcId, npcmonster.uuid);
            if (zonenpc != null)
            {
                zonenpc.NpcInfoData = npcmonster;
            }
            for (int i = 0; i < mQueueForCreateDic[ZoneNpcType.NpcMonster].Count; i++)
            {
                if (mQueueForCreateDic[ZoneNpcType.NpcMonster][i].npcId == npcmonster.npcId
                    && mQueueForCreateDic[ZoneNpcType.NpcMonster][i].uuid == npcmonster.uuid)
                {
                    mQueueForCreateDic[ZoneNpcType.NpcMonster][i] = npcmonster;
                    break;
                }
            }
        }

        public void RemoveNpcMonster(string uuid)
        {
            //已经显示，从显示列表中移除
            for (int i = 0; i < mNpcDic[ZoneNpcType.NpcMonster].Count; i++)
            {
                if (mNpcDic[ZoneNpcType.NpcMonster][i].NpcInfoData.uuid == uuid)
                {
                    mNpcDic[ZoneNpcType.NpcMonster][i].Destroy();
                    mNpcDic[ZoneNpcType.NpcMonster].RemoveAt(i);
                    break;
                }
            }
            //ClientLog.LogWarning("RemoveNpcMonster删除Npc  " + uuid);
            //从等待列表中清除
            for (int i = 0; i < mQueueForCreateDic[ZoneNpcType.NpcMonster].Count; i++)
            {
                if (mQueueForCreateDic[ZoneNpcType.NpcMonster][i].uuid == uuid)
                {
                    mQueueForCreateDic[ZoneNpcType.NpcMonster].RemoveAt(i);
                    break;
                }
            }
            //移除数据
            for (int i = 0; i < mNpcDataDic[ZoneNpcType.NpcMonster].Count; i++)
            {
                if (mNpcDataDic[ZoneNpcType.NpcMonster][i].uuid == uuid)
                {
                    mNpcDataDic[ZoneNpcType.NpcMonster].RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveNpc(ZoneNpcType zoneNpcType, int npcTplId)
        {
            //已经显示，从显示列表中移除
            for (int i = 0; i < mNpcDic[zoneNpcType].Count; i++)
            {
                if (mNpcDic[zoneNpcType][i].NpcInfoData.npcId == npcTplId)
                {
                    mNpcDic[zoneNpcType][i].Destroy();
                    mNpcDic[zoneNpcType].RemoveAt(i);
                    break;
                }
            }
            //ClientLog.LogWarning("RemoveNpc删除Npc  type:" + zoneNpcType+"    tplid: " + npcTplId);
            //从等待列表中清除
            for (int i = 0; i < mQueueForCreateDic[zoneNpcType].Count; i++)
            {
                if (mQueueForCreateDic[zoneNpcType][i].npcId == npcTplId)
                {
                    mQueueForCreateDic[zoneNpcType].RemoveAt(i);
                    break;
                }
            }
            //移除数据
            if (zoneNpcType == ZoneNpcType.NpcMonster)
            {
                for (int i = 0; i < mNpcDataDic[zoneNpcType].Count; i++)
                {
                    if (mNpcDataDic[zoneNpcType][i].npcId == npcTplId)
                    {
                        mNpcDataDic[zoneNpcType].RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void ClearNpcMonster()
        {
            //已经显示，从显示列表中移除
            for (int i = 0; i < mNpcDic[ZoneNpcType.NpcMonster].Count; i++)
            {
                mNpcDic[ZoneNpcType.NpcMonster][i].Destroy();
            }
            mNpcDic[ZoneNpcType.NpcMonster].Clear();
            //ClientLog.LogWarning("ClearNpcMonster删除Npc");
            //从等待列表中清除
            mQueueForCreateDic[ZoneNpcType.NpcMonster].Clear();
            //移除数据
            mNpcDataDic[ZoneNpcType.NpcMonster].Clear();
        }

        #endregion

        /// <summary>
        /// 获得一个npc
        /// </summary>
        /// <param name="npcId"></param>
        /// <returns></returns>
        public ZoneNPC GetNpc(int npcTplId, string npcuuid = null)
        {
            int flag = 0;
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (pair.Value[i].NpcInfoData.npcId == npcTplId)
                    {
                        flag = 1;
                        if (npcuuid == null || (npcuuid == pair.Value[i].NpcInfoData.uuid))
                        {
                            return pair.Value[i];
                        }
                    }
                }
            }
            foreach (KeyValuePair<ZoneNpcType, List<NpcInfoData>> pair in mQueueForCreateDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    if (pair.Value[i].npcId == npcTplId)
                    {
                        flag = 1;
                        if(npcuuid == null || (npcuuid == pair.Value[i].uuid))
                        {
                            return CreateNPCFromQueue(pair.Key, i);
                        }
                    }
                }
            }

            string errMsg = "当前地图没有找到npc npcTplId:" + npcTplId + " npcuuid:" + npcuuid;

            if (ZoneModel.ins.mapTpl != null)
            {
                errMsg += " mapid:" + ZoneModel.ins.mapTpl.Id;
            }
            else
            {
                errMsg += "当前尚未进入地图";
            }

            if (flag == 0)
            {
                errMsg += " 没有匹配的tplId";
            }
            else if (flag == 1)
            {
                errMsg += " 没有匹配的uuid";
            }

            return null;
        }

        /// <summary>
        /// 根据npc的模型对象，获得一个npc
        /// </summary>
        /// <param name="npcId"></param>
        /// <returns></returns>
        public ZoneNPC GetNpc(GameObject go)
        {
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; pair.Value!=null&&i < pair.Value.Count; i++)
                {
                    if (pair.Value[i] != null && pair.Value[i].displayModel!=null
                        &&pair.Value[i].displayModel.avatar == go
                        && pair.Value[i].NpcTpl.type!=(int)NPCType.MAP_EFFECT)
                    {//过滤掉 地图特效
                        return pair.Value[i];
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 按照npc类型 获得 一个npc对象
        /// </summary>
        /// <param name="zonenpctype"></param>
        /// <returns></returns>
        public List<ZoneNPC> GetNpcListByNpcType(ZoneNpcType zonenpctype,NPCType npctype)
        {
            List<ZoneNPC> list = mNpcDic[zonenpctype];
            List<ZoneNPC> resultList=null;
            if (list!=null&&list.Count>0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].NpcTpl!=null&&list[i].NpcTpl.type==(int)npctype)
                    {
                        if (resultList==null)
                        {
                            resultList = new List<ZoneNPC>();
                        }
                        resultList.Add(list[i]);
                    }
                }
            }
            if (resultList != null)
            {
                return resultList;
            }
            return null;
        }

        private ZoneNPC CreateNPCFromQueue(ZoneNpcType zonenpctype, int index)
        {
            NpcInfoData npcinfodata = mQueueForCreateDic[zonenpctype][index];
            ZoneNPC cha = CreateNPC(npcinfodata);
            mNpcDic[zonenpctype].Add(cha);
            mQueueForCreateDic[zonenpctype].RemoveAt(index);
            mCountForCreate--;
            //测试代码，自动打副本
            //NpcTemplate tpl = NpcTemplateDB.Instance.getTemplate(cha.NpcTplId);
            //NPCType npcType = (NPCType)(tpl.type);
            //if (npcType == NPCType.FUBEN_BATTLE)
            //{
            //    MapCGHandler.sendCGMapFightNpc(cha.NpcTplId, npcinfodata.uuid);
            //}
            return cha;
        }

        private ZoneNPC CreateNPC(NpcInfoData mapNpcTpl)
        {
            ZoneNPC npc = null;
            NpcTemplate tpl = NpcTemplateDB.Instance.getTemplate(mapNpcTpl.npcId);
            MapNpcTemplate mapnpcTpl = MapNpcTemplateDB.Instance.GetMapNpcTmpByMapIdNpcId(mapNpcTpl.mapId,mapNpcTpl.npcId);
            NPCType npcType = (NPCType)(tpl.type);
            bool showShadow = true;
            switch (npcType)
            {
                case NPCType.NORMAL:
                    npc = new ZoneNPC();
                    break;
                case NPCType.TASKTARGET_BATTLE:
                    npc = new ZoneNPC();
                    break;
                case NPCType.TRANSFER_POINT:
                    npc = new ZonePortal();
                    break;
                case NPCType.FUBEN_BATTLE:
                    npc = new ZoneNPC();
                    break;
                case NPCType.MAP_EFFECT:
                    npc = new ZoneMapEffect();
                    break;
                case NPCType.RESOURCE_POINT:
                    npc = new ZoneNPC(false);
                    showShadow = false;
                    break;
                default:
                    break;
            }
            if (npc != null)
            {
                if (mapnpcTpl!=null&&mapnpcTpl.pixelFlag == 1)
                {
                    npc.InitNpc(mapNpcTpl, tpl, mapnpcTpl, ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(mapNpcTpl.x, mapNpcTpl.y)), showShadow);
                }
                else
                {
                    npc.InitNpc(mapNpcTpl, tpl, mapnpcTpl, ZoneUtil.ConvertMapPathTilePos2UnityPos(mapNpcTpl.x, mapNpcTpl.y), showShadow);
                }
            }
            return npc;
        }

        public void Update()
        {
            if (mCountForCreate > 0)
            {
                foreach (KeyValuePair<ZoneNpcType, List<NpcInfoData>> pair in mQueueForCreateDic)
                {
                    if (pair.Value.Count > 0)
                    {
                        if (--mCreateCDFrameLeft <= 0)
                        {
                            CreateNPCFromQueue(pair.Key, 0);
                            mCreateCDFrameLeft = ZoneDef.MAP_CHARACTER_CREATE_CD_FRAME;
                            break;
                        }
                    }
                }
            }

            //调用ZoneNpc的Update
            for (int i = 0; i < mNpcDicKeysLen; i++)
            {
                List<ZoneNPC> npcList = mNpcDic[mNpcDicKeys[i]];
                int count = npcList.Count;
                for (int j = 0; j < count; j++)
                {
                    npcList[j].Update();
                }
            }
            /*
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                int count = pair.Value.Count;
                for (int i = 0; i < count; i++)
                {
                    pair.Value[i].Update();
                }
            }
            */
        }

        public void LateUpdate()
        {
            //调用ZoneNpc的LateUpdate
            for (int i = 0; i < mNpcDicKeysLen; i++)
            {
                List<ZoneNPC> npcList = mNpcDic[mNpcDicKeys[i]];
                int count = npcList.Count;
                for (int j = 0; j < count; j++)
                {
                    npcList[j].LateUpdate();
                }
            }
        }

        public void ClickNpc(ZoneNPC npc)
        {
            npc.ShowSelectedEffect();
            gotoNpc(ZoneModel.ins.mapTpl.Id, npc.NpcTplId, npc.NpcInfoData.uuid, false);
        }

        public void gotoNpc(int mapId, int npcId, string uuid = null, bool showXunlu = true)
        {
            if (PropertyUtil.IsLegalID(mapId) && PropertyUtil.IsLegalID(npcId))
            {
                if (ZoneModel.ins.mapTpl != null && ZoneModel.ins.mapTpl.Id == mapId)
                {//当前地图
                    //如果已经打开面板，则直接返回
                    if (WndManager.Ins.IsWndShowing(GlobalConstDefine.NpcChatView_Name) && CurrentSelectedNpc != null
                        && CurrentSelectedNpc.NpcTplId == npcId)
                    {
                        return;
                    }
                    ZoneNPC selectedNPC = GetNpc(npcId, uuid);
                    CurrentSelectedNpc = selectedNPC;
                    if (selectedNPC != null)
                    {
                        Vector3 npcPos = selectedNPC.localPosition;
                        float offset = selectedNPC.displayModel!=null?selectedNPC.displayModel.radiusMin:0.5f;
                        ZoneCharacter player = ZoneCharacterManager.ins.self;
						if (player != null){
                            if (player.isRiding && player.ridingPet != null && (int)NPCType.RESOURCE_POINT != CurrentSelectedNpc.NpcTpl.type)
                            {
                                offset = (offset + player.ridingPet.displayModel.radiusMax) + 0.5f;
                            }
                            else
                            {
                                offset = (offset + player.displayModel.radiusMin) + 0.5f;
                            }
                            if ((NPCType)selectedNPC.NpcTpl.type == NPCType.TRANSFER_POINT)
                            {
                                //传送点
                                offset = 0.5f;
                            }
                            Vector3 playerPos = player.localPosition;
                            if (Vector2.Distance(new Vector2(npcPos.x, npcPos.z), new Vector2(playerPos.x, playerPos.z)) <= offset)
                            {
                                player.Idle();
                                HandleClickNpc();
                            }
                            else
                            {
                                if (player.MoveTo(npcPos, offset, true, HandleClickNpc))
                                {
                                    if (showXunlu)
                                    {
                                        EffectUtil.Ins.PlayEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME, LayerConfig.MainUI, false, null, new Vector3(0, 150, 0));
                                    }
                                }
                            }
                        }
                        else
                        {
                            ClientLog.LogError("gotoNpc的时候，玩家角色还没有初始化!");
                        }
                        LinkParse.Ins.ClearLink();
                    }
                }
                else
                {//npc不在当前地图
                    ZoneModel.ins.sendCGMapPlayerEnter(mapId);
                    //MapCGHandler.sendCGMapPlayerEnter(mapId);
                }
            }
        }

        public void HandleClickNpc()
        {
            XinFaModel.instance.StopAutoFindResPoint();
            EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
            if (StateManager.Ins.getCurState() != null && StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                //正在战斗场景，直接返回
                return;
            }
            ZoneNPC selectedNPC = CurrentSelectedNpc;
            if (selectedNPC != null)
            {
                NPCType npcType = (NPCType)(selectedNPC.NpcTpl.type);
                //selectedNPC.displayModel.avatar.transform.LookAt(ZoneCharacterManager.ins.player.displayModel.avatar.transform.position);
                //ZoneCharacterManager.ins.player.displayModel.avatar.transform.LookAt(selectedNPC.displayModel.avatar.transform.position);
                switch (npcType)
                {
                    case NPCType.NORMAL:
                        NpcChatView.Ins.showNpcChat(selectedNPC.NpcInfoData);
                        break;
                    case NPCType.TASKTARGET_BATTLE:
                    case NPCType.FUBEN_BATTLE:
                        if (selectedNPC.NpcTpl.notShowPanelInt == 1)
                        {
                            MapCGHandler.sendCGMapFightNpc(selectedNPC.NpcTplId, selectedNPC.NpcInfoData.uuid);
                        }
                        else
                        {
                            NpcChatView.Ins.showNpcChat(selectedNPC.NpcInfoData);
                        }
                        break;
                    case NPCType.RESOURCE_POINT:
                        LinkParse.Ins.linkToFunc(FunctionIdDef.SHENGHUOJINENG);
                        break;
                    default:
                        break;
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].FixedUpdate();
                }
            }
        }

        /// <summary>
        /// 清空所有npc身上的任务
        /// </summary>
        public void ClearAllNpcQuest()
        {
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].ClearQuest();
                }
            }
        }

        public void ShowNPCs()
        {
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].SetActive(true);
                }
            }
        }

        public void HideNPCs()
        {
            foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    pair.Value[i].SetActive(false);
                }
            }
        }

        public int NpcCount
        {
            get
            {
                int len = 0;
                foreach (KeyValuePair<ZoneNpcType, List<ZoneNPC>> pair in mNpcDic)
                {
                    len += pair.Value.Count;
                }
                return len;
            }
        }

        /// <summary>
        /// 当前选中的npc
        /// </summary>
        public ZoneNPC CurrentSelectedNpc
        {
            get { return _currentSelectedNpc; }
            set { _currentSelectedNpc = value; }
        }

        /// <summary>
        /// 更新任务时检查有没有要创建的npc
        /// </summary>
        public void UpdateNpcVisible()
        {
            for (int i = 0; i < mNpcDataDic[ZoneNpcType.QuestNpc].Count; i++)
            {
                int npcid = mNpcDataDic[ZoneNpcType.QuestNpc][i].npcId;
                List<int> questidList = ZoneNPC.initLimitQuestList(npcid);
                if (ZoneNPC.CanNpcVisibleByLimitQuest(questidList))
                {
                    if (!hasNpcCreated(ZoneNpcType.QuestNpc, npcid) && !hasNpcInCreateQueue(ZoneNpcType.QuestNpc, npcid))
                    {
                        AddNpc(ZoneNpcType.QuestNpc, mNpcDataDic[ZoneNpcType.QuestNpc][i]);
                    }
                }
                else
                {
                    RemoveNpc(ZoneNpcType.QuestNpc, mNpcDataDic[ZoneNpcType.QuestNpc][i].npcId);
                }
            }
        }

        private bool hasNpcCreated(ZoneNpcType zonenpcType, int npcid)
        {
            for (int i = 0; i < mNpcDic[zonenpcType].Count; i++)
            {
                if (mNpcDic[zonenpcType][i].NpcTplId == npcid)
                {
                    return true;
                }
            }
            return false;
        }

        private bool hasNpcInCreateQueue(ZoneNpcType zonenpcType, int npcid)
        {
            for (int i = 0; i < mQueueForCreateDic[zonenpcType].Count; i++)
            {
                if (mQueueForCreateDic[zonenpcType][i].npcId == npcid)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获得附近半径范围内的最近的一个npc，半径为0，则返回最近的一个npc
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public ZoneNPC GetNearNpc(ZoneNpcType zonenpctype,NPCType npctype,int radius = 0)
        {
            //绿野仙踪 自动打怪，就近遇怪
            List<ZoneNPC> zonenpc = GetNpcListByNpcType(zonenpctype,npctype);
            float maxdistance = float.MaxValue;
            int selectIndex = -1;
            if (zonenpc != null)
            {
                int[] pixPos = ZoneUtil.ConvertUnityPos2PathTilePos(ZoneCharacterManager.ins.self.localPosition);
                for (int i = 0; i < zonenpc.Count; i++)
                {
                    float distance = ZoneUtil.GetDistance(zonenpc[i].NpcInfoData.x, zonenpc[i].NpcInfoData.y,pixPos[0], pixPos[1]);
                    if (distance < maxdistance)
                    {
                        maxdistance = distance;
                        selectIndex = i;
                    }
                }
                if (selectIndex != -1&&zonenpc[selectIndex].NpcInfoData != null &&
                SceneModel.ins.IsMapTileCanWalk(zonenpc[selectIndex].NpcInfoData.x, zonenpc[selectIndex].NpcInfoData.y))
                {
                    if (radius == 0 || maxdistance<=radius)
                    {
                        return zonenpc[selectIndex];
                    }
                }
            }
            return null;
        }

        public void Clear()
        {
            ClearAllNpcQuest();
            ClearNpc();
            mMapId = 0;
        }
    }
}

