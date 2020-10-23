﻿using System;
using System.Collections.Generic;
using app.baotu;
using app.chubao;
using app.db;
using app.human;
using app.keju;
using app.model;
using app.mozufuben;
using app.net;
using app.nvsn;
using app.role;
using app.state;
using app.yunliang;
using app.zone;
using app.jiuguan;
using app.relation;
using app.fuben;
using UnityEngine;
using app.team;
using app.ringtask;

public class LinkParse : AbsModel
{
    private static LinkParse _ins;

    public static LinkParse Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new LinkParse();
            }
            return _ins;
        }
    }
    /// <summary>
    /// 当前 超链接的 类型
    /// </summary>
    public int CurLinkType
    {
        get { return _curLinkType; }
        set { _curLinkType = value; }
    }
    /// <summary>
    /// 当前 超链接的 参数列表
    /// </summary>
    public List<string> CurLinkParam
    {
        get { return _curLinkParam; }
    }

    private int _curLinkType;
    private List<string> _curLinkParam = new List<string>();
    private bool mIsChangedToYunliangren = false;
    private JiuGuanRenWuModel jiuguanModel = null;
    private YunLiangModel yunliangModel = null;
    private RelationModel relationModel = null;
    private ChuBaoModel chubaoModel = null;
    private BaoTuModel baotuModel = null;
    private ShiTuModel shituModel = null;
    private HunYinModel hunyinModel = null;
    private NvsNModel nvnModel = null;

    /// <summary>
    /// 解析 + 校验，正确返回解析完的数组，错误返回null
    /// </summary>
    /// <param name="linkContent"></param>
    /// <returns></returns>
    public string[] Parse(string linkContent)
    {
        if (string.IsNullOrEmpty(linkContent))
        {
            return null;
        }
        string[] pathArr = linkContent.Split('-');
        try
        {
            int linktype = int.Parse(pathArr[0]);
            switch (linktype)
            {
                case LinkTypeDef.FindMonster:
                case LinkTypeDef.LinkToFunc:
                    if (pathArr.Length == 2)
                    {
                        int.Parse(pathArr[1]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    break;
                case LinkTypeDef.FindNPC:
                    if (pathArr.Length == 3)
                    {
                        int.Parse(pathArr[1]);
                        int.Parse(pathArr[2]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    break;
                case LinkTypeDef.UseItem:
                    //使用道具
                    if (pathArr.Length == 3 || pathArr.Length == 4)
                    {
                        int.Parse(pathArr[1]);
                        int.Parse(pathArr[2]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    break;
            }
            return pathArr;
        }
        catch (Exception)
        {
            ClientLog.LogError("超链接 解析 报错：linkContent：" + linkContent);
        }
        return null;
    }

    /// <summary>
    /// 开始执行一个超链接的功能，
    /// 每一个超连接 做完之后  都要清空
    /// </summary>
    /// <param name="linkContent"></param>
    public void doLink(string linkContent)
    {
        string[] pathArr = Parse(linkContent);
        if (pathArr != null && pathArr.Length > 1)
        {
            if (CurLinkType != 0)
            {
                //如果当前有数据说明正在做，则返回
                //ClientLog.LogError("如果当前有数据说明正在做，则返回:" + CurLinkType + " : " + _curLinkParam[0]);
                //return;
            }
            CurLinkType = int.Parse(pathArr[0]);
            _curLinkParam.Clear();
            switch (int.Parse(pathArr[0]))
            {
                case LinkTypeDef.FindMonster:
                case LinkTypeDef.GuaJI:
                    if (!ZoneModel.ins.CheckCanMoveFreely())
                    {
                        CurLinkType = 0;
                        return;
                    }
                    int targetMapId = int.Parse(pathArr[1]);
                    _curLinkParam.Add(targetMapId.ToString());
                    if (ZoneModel.ins.mapTpl.Id == targetMapId)
                    {//当前地图
                    }
                    else
                    {//非当前地图
                        ZoneModel.ins.sendCGMapPlayerEnter(targetMapId);
                        //MapCGHandler.sendCGMapPlayerEnter(targetMapId);
                    }
                    break;
                case LinkTypeDef.FindNPC:
                    if (!ZoneModel.ins.CheckCanMoveFreely())
                    {
                        CurLinkType = 0;
                        return;
                    }
                    int npcMapId = int.Parse(pathArr[1]);
                    int npcid = int.Parse(pathArr[2]);
                    linkToNpc(npcMapId, npcid);
                    break;
                case LinkTypeDef.LinkToFunc:
                    ClearLink();
                    linkToFunc(int.Parse(pathArr[1]));
                    break;
                case LinkTypeDef.UseItem:
                    if (!ZoneModel.ins.CheckCanMoveFreely())
                    {
                        CurLinkType = 0;
                        return;
                    }
                    //使用道具
                    int useItemMapId = int.Parse(pathArr[1]);
                    int itemId = int.Parse(pathArr[2]);
                    _curLinkParam.Add(useItemMapId.ToString());
                    _curLinkParam.Add(itemId.ToString());
                    if (pathArr.Length == 4)
                    {
                        //物品uuid
                        _curLinkParam.Add(pathArr[3]);
                        Human.Instance.BagModel.GoToUseItem(itemId, pathArr[3]);
                    }
                    else
                    {
                        Human.Instance.BagModel.GoToUseItem(itemId);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void linkToNpc(int mapId, int npcId, string uuid = null, bool showXunlu = true)
    {
        _curLinkParam.Clear();
        _curLinkParam.Add(mapId.ToString());
        _curLinkParam.Add(npcId.ToString());
        ZoneNPCManager.Ins.gotoNpc(mapId, npcId, uuid, showXunlu);
    }
    /// <summary>
    /// 每一种超连接 做完之后都会清空
    /// 清除超链接
    /// </summary>
    public void ClearLink()
    {
        CurLinkType = 0;
        _curLinkParam.Clear();
    }

    /// <summary>
    /// update 超链接
    /// </summary>
    public void updateLink()
    {
        if (LinkParse.Ins.CurLinkType != 0)
        {
            ZoneCharacter player = ZoneCharacterManager.ins.self;
            if (player != null && player.displayModel != null
                && (LinkParse.Ins.CurLinkParam.Count > 0 && ZoneModel.ins.mapTpl.Id == int.Parse(LinkParse.Ins.CurLinkParam[0]))
                && ZoneManager.ins.curZoneInited
                && (player.curBehavType == ZoneCharacterBehavType.NONE || player.curBehavType == ZoneCharacterBehavType.IDLE)
                && StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                switch (LinkParse.Ins.CurLinkType)
                {
                    case LinkTypeDef.FindMonster:
                        //在当前地图，自动寻路遇怪
                        AutoQuestWalk();
                        break;
                    case LinkTypeDef.GuaJI:
                        AutoQuestWalk();
                        break;
                    case LinkTypeDef.FindNPC:
                        //在当前地图，寻路到npc
                        ZoneNPCManager.Ins.gotoNpc(int.Parse(LinkParse.Ins.CurLinkParam[0]), int.Parse(LinkParse.Ins.CurLinkParam[1]),null,true);
                        break;
                    case LinkTypeDef.LinkToFunc:
                        break;
                    case LinkTypeDef.UseItem:
                        //在当前地图，到指定位置使用物品
                        if (LinkParse.Ins.CurLinkParam.Count > 2)
                        {
                            Human.Instance.BagModel.GoToUseItem(int.Parse(LinkParse.Ins.CurLinkParam[1]), LinkParse.Ins.CurLinkParam[2]);
                        }
                        else
                        {
                            Human.Instance.BagModel.GoToUseItem(int.Parse(LinkParse.Ins.CurLinkParam[1]));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 自动寻路 遇怪
    /// </summary>
    private void AutoQuestWalk()
    {
        EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
        EffectUtil.Ins.RemoveEffect(ClientConstantDef.GUAJI_EFFECT_NAME);

        if (Human.Instance.QuestModel.AutoQuestId != 0 || CurLinkType == LinkTypeDef.GuaJI)
        {
            //正在自动做任务
            ZoneCharacter player = ZoneCharacterManager.ins.self;
            Vector3 currentPos = player.localPosition;
            UnityEngine.AI.NavMeshHit hit;
            Vector2 v2 = UnityEngine.Random.insideUnitCircle * ClientConstantDef.AutoQuestWalkRadius;
            currentPos.x += v2.x;
            currentPos.z += v2.y;
            bool success = UnityEngine.AI.NavMesh.SamplePosition(currentPos, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas);
            if (success)
            {
                bool res = player.navMeshAgent.CalculatePath(hit.position, new UnityEngine.AI.NavMeshPath());
                if (res)
                {
                    if (player.MoveTo(hit.position, 0, false, moveEndCallBack))
                    {
                        if (CurLinkType == LinkTypeDef.FindMonster || CurLinkType == LinkTypeDef.FindNPC)
                        {
                            EffectUtil.Ins.PlayEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME, LayerConfig.MainUI, true, null, new Vector3(0, 150, 0));
                        }
                        else if(CurLinkType == LinkTypeDef.GuaJI)
                        {
                            EffectUtil.Ins.PlayEffect(ClientConstantDef.GUAJI_EFFECT_NAME, LayerConfig.MainUI, true, null, new Vector3(0, 150, 0));
                        }
                    }
                }
            }
        }
    }

    private void moveEndCallBack()
    {
        AutoQuestWalk();
    }

    public void linkToFunc(int funcid)
    {
        switch (funcid)
        {
            case FunctionIdDef.RENWU://任务
                WndManager.open(GlobalConstDefine.QuestView_Name);               
                break;
            case FunctionIdDef.DUIWU:
                if (TeamModel.ins.teamApplyAuto != null && TeamModel.ins.teamApplyAuto.getIsAuto() != 0)
                {
                    WndManager.open(GlobalConstDefine.TeamApplyView_Name);
                }
                else
                {
                    WndManager.open(GlobalConstDefine.TeamMainView_Name);
                }
                break;//队伍
            case FunctionIdDef.TOWER://通天塔
                WndManager.open(GlobalConstDefine.TongTianTaView_Name);
                break;
            case FunctionIdDef.HUODONG://活动
                ActivityModel.Ins.requestActivityList();
                break;
            case FunctionIdDef.JINGJICHANG://竞技场
                ArenaCGHandler.sendCGShowArenaPanel();              
                break;
            case FunctionIdDef.JIUGUAN://酒馆任务
                if (jiuguanModel == null)
                {
                    jiuguanModel = JiuGuanRenWuModel.Ins;
                }
                QuestInfoData jiuguanQuestData = jiuguanModel.currentQuestData;
                if (jiuguanQuestData != null && (jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                         jiuguanQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("当前酒馆任务未完成");
                }
                else
                {
                    PubtaskCGHandler.sendCGOpenPubtaskPanel();
                }
                break;
            case FunctionIdDef.YUNLIANG://运粮任务
                if (yunliangModel == null)
                {
                    yunliangModel = YunLiangModel.Ins;
                }
                QuestInfoData yunliangQuestData = yunliangModel.currentQuestData;
                if (yunliangQuestData != null && (yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                         yunliangQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("当前护送粮草任务未完成");
                }
                else
                {
                    ForagetaskCGHandler.sendCGOpenForagetaskPanel();
                }
                break;

            case FunctionIdDef.CORPSTASK://帮派任务
                QuestInfoData infoData = CorpsTaskModel.instance.corpsTaskUpdate == null ? null : CorpsTaskModel.instance.corpsTaskUpdate.getQuestInfo();
                if (infoData != null && (infoData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                    infoData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("当前帮派任务未完成");
                }
                else
                {
                    CorpstaskCGHandler.sendCGCorpstaskAccept();
                }
                break;

            case FunctionIdDef.KEJU://朝云科举
                KeJuModel.Ins.CanOpen(KeJuType.PROVINCIAL);
                break;
            case FunctionIdDef.XITONG://系统
                WndManager.open(GlobalConstDefine.SystemSettingView_Name);
                //ZoneBubbleManager.ins.BubbleSysMsg("此功能尚未开放，敬请期待");
                /*
                ZoneCharacter player = ZoneCharacterManager.ins.player;
                if (mIsChangedToYunliangren)
                {
                    ZoneCharacterManager.ins.player.ShiftDisplayModel(Human.Instance.PetModel.getLeader().getTpl().modelId);
                    mIsChangedToYunliangren = false;
                }
                else
                {
                    ZoneCharacterManager.ins.player.ShiftDisplayModel("yunliangren", false, false);
                    mIsChangedToYunliangren = true;
                }
                */
                break;
            case FunctionIdDef.PETSTORE://宠物商店 
                WndManager.open(GlobalConstDefine.PetStoreView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, funcid));
                break;
            case FunctionIdDef.SHANGHUI://商会
                WndManager.open(GlobalConstDefine.ShopView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                break;
            case FunctionIdDef.PAIMAIHANG://拍卖行
                WndManager.open(GlobalConstDefine.ShopView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                break;
            case FunctionIdDef.CHONGZHI://充值
                WndManager.open(GlobalConstDefine.ShopView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 3));
                break;
            case FunctionIdDef.JINGJICHANGSHOP://竞技场商店
                WndManager.open(GlobalConstDefine.ShopView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.JINGJICHANGSHOP));
                break;
            case FunctionIdDef.WUXING://悟性
                ZoneBubbleManager.ins.BubbleSysMsg("此功能尚未开放，敬请期待");
                break;
            case FunctionIdDef.BEIBAO://背包
                WndManager.open(GlobalConstDefine.BagView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.BEIBAO));
                break;
            case FunctionIdDef.CANGKU://仓库
                WndManager.open(GlobalConstDefine.BagView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.CANGKU));
                break;
            case FunctionIdDef.XINFAJINENG://心法技能
                WndManager.open(GlobalConstDefine.XinFaView_Name);                                
                break;
            case FunctionIdDef.JINENGSHENGJI://技能升级
            case FunctionIdDef.ROLESKILL:
                WndManager.open(GlobalConstDefine.XinFaView_Name);
                break;
            case FunctionIdDef.XINFASHENGJI://心法升级
                WndManager.open(GlobalConstDefine.XinFaView_Name,WndParam.CreateWndParam(WndParam.SelectTab,1));
                break;
            case FunctionIdDef.BANGPAI://帮派
                int hasCorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
                if (hasCorp > 0)
                {
                    CorpsCGHandler.sendCGOpenCorpsMemberList();
                    CorpsCGHandler.sendCGOpenCorpsPanel();
                }
                else
                {
                    CorpsCGHandler.sendCGClickCorpsPanel();
                }
                break;
            case FunctionIdDef.HUOBAN://伙伴
                //WndManager.open(GlobalConstDefine.PartnerFormationView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                break;
            case FunctionIdDef.ZHENXING://阵型
                ZoneBubbleManager.ins.BubbleSysMsg("此功能尚未开放，敬请期待");
                break;
            case FunctionIdDef.PAIHANG://排行
                WndManager.open(GlobalConstDefine.PaiHangBangView_Name);
                break;
            case FunctionIdDef.DAZAO://打造
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.DAZAO))
                {
                    WndManager.open(GlobalConstDefine.DaZaoViewView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                }
                break;
            case FunctionIdDef.SHENGXING://升星
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.DAZAO, FunctionIdDef.SHENGXING))
                {
                    WndManager.open(GlobalConstDefine.DaZaoViewView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 1));
                }
                break;
            case FunctionIdDef.XIANGQIAN://宝石镶嵌
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.DAZAO, FunctionIdDef.XIANGQIAN))
                {
                    WndManager.open(GlobalConstDefine.DaZaoViewView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 2));
                }
                break;
            case FunctionIdDef.HECHENG://宝石合成
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.DAZAO, FunctionIdDef.HECHENG))
                {
                    WndManager.open(GlobalConstDefine.DaZaoViewView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 3));
                }
                break;
            case FunctionIdDef.QIANGHUA://强化
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name);
                }
                break;
            case FunctionIdDef.FENJIE://分解
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA, FunctionIdDef.FENJIE))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                }
                break;
            case FunctionIdDef.CHONGZHU://重铸
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA, FunctionIdDef.CHONGZHU))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 2));
                }
                break;
            case FunctionIdDef.XILIAN://炼化
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA, FunctionIdDef.XILIAN))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 4));
                }
                break;
            case FunctionIdDef.GUANZHU://灌注
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA, FunctionIdDef.GUANZHU))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 1));
                }
                break;
            case FunctionIdDef.CHUANCHENG://传承
                if (FunctionModel.Ins.checkFuncOpen(FunctionIdDef.QIANGHUA, FunctionIdDef.CHUANCHENG))
                {
                    WndManager.open(GlobalConstDefine.QiangHuaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 3));
                }
                break;
            case FunctionIdDef.JIANGLI://奖励
                WndManager.open(GlobalConstDefine.JiangLiView, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                break;
            case FunctionIdDef.QIANDAO://每日签到
                WndManager.open(GlobalConstDefine.JiangLiView, WndParam.CreateWndParam(WndParam.SelectTab, 0));
                break;
            case FunctionIdDef.DENGLUJIANGLI://登陆奖励
                WndManager.open(GlobalConstDefine.JiangLiView, WndParam.CreateWndParam(WndParam.SelectTab, 1));
                break;
            case FunctionIdDef.ZAIXIANJIANGLI://在线奖励
                OnlinegiftCGHandler.sendCGGetOnlinegiftInfo();
                break;
            case FunctionIdDef.QIRIMUBIAO://七日目标
                WndManager.open(GlobalConstDefine.JiangLiView, WndParam.CreateWndParam(WndParam.SelectTab, 2));
                break;
            case FunctionIdDef.YOUJIAN://邮件
                if (relationModel == null)
                {
                    relationModel = RelationModel.Ins;
                }
                relationModel.openRelationView(true);
                break;
            case FunctionIdDef.HAOYOU://好友
                if (relationModel == null)
                {
                    relationModel = RelationModel.Ins;
                }
                relationModel.openRelationView(true);
                break;
            case FunctionIdDef.CHENGJIU://成就 
                ZoneBubbleManager.ins.BubbleSysMsg("此功能尚未开放，敬请期待");
                //StateManager.Ins.SwitchAccount();
                break;
            case FunctionIdDef.TISHENG://提升
                TiShengModel.instance.OnClick();
                break;
            case FunctionIdDef.QICHONG://骑宠
                WndManager.open(GlobalConstDefine.PetInfoView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.QICHONG));
                break;
            case FunctionIdDef.CAIKUANG://采矿
                //LifeskillCGHandler.sendCGLsMineGetPannel();
                break;
            case FunctionIdDef.CHUBAOANLIANG://除暴安良
                if (chubaoModel == null)
                {
                    chubaoModel = ChuBaoModel.Ins;
                }
                QuestInfoData chubaoQuestData = chubaoModel.currentQuestData;
                if (chubaoQuestData != null && (chubaoQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                         chubaoQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                {

                    ZoneBubbleManager.ins.BubbleSysMsg("当前除暴任务未完成");
                }
                else
                {
                    ThesweeneytaskCGHandler.sendCGThesweeneytaskAccept();
                }
                break;
            case FunctionIdDef.BAOTU://宝图任务
                if (baotuModel == null)
                {
                    baotuModel = BaoTuModel.Ins;
                }
                QuestInfoData baotuQuestData = baotuModel.currentQuestData;
                if (baotuQuestData != null && (baotuQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED ||
                         baotuQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("当前宝图任务未完成");
                }
                else
                {
                    TreasuremapCGHandler.sendCGTreasuremapAccept();
                }
                break;
            case FunctionIdDef.LVYEXIANZONG_DANREN://绿野仙踪单人
                FubenlyxzModel.ins.EnterLyxzSingle();
                break;
            case FunctionIdDef.LVYEXIANZONG_ZUDUI://绿野仙踪组队
                FubenlyxzModel.ins.EnterLyxzTeam();
                break;
            case FunctionIdDef.CHENGHAO://称号
                WndManager.open(GlobalConstDefine.Chenghao_Name);
                break;
            case FunctionIdDef.BPJS_Enter:
                FubenbpjsModel.ins.EnterBpjs();
                break;
            case FunctionIdDef.BPJS_Paihang: // 帮派排行
                FubenbpjsModel.ins.OpenBpph();
                break;
            case FunctionIdDef.SHITU_SHOUTU: // 收徒
                if (shituModel == null)
                {
                    shituModel = ShiTuModel.Ins;
                }
                shituModel.ShouTu();
                break;
            case FunctionIdDef.SHITU_CHUSHI: // 出师
                if (shituModel == null)
                {
                    shituModel = ShiTuModel.Ins;
                }
                shituModel.ChuShi();
                break;
            case FunctionIdDef.SHITU_JIECHU: // 解除师徒关系
                if (shituModel == null)
                {
                    shituModel = ShiTuModel.Ins;
                }
                shituModel.JieChuShiTu();
                break;
            case FunctionIdDef.JIEHUN_WE: //我要结婚
                if (hunyinModel == null)
                {
                    hunyinModel = HunYinModel.Ins;
                }
                hunyinModel.JieHun();
                break;
            case FunctionIdDef.LIHUN_WE: //我要离婚
                if (hunyinModel == null)
                {
                    hunyinModel = HunYinModel.Ins;
                }
                hunyinModel.LiHun();
                break;
            case FunctionIdDef.CHONGWUDAO_YI://宠物岛一层
                List<MapTemplate> maplist1 = MapTemplateDB.Instance.GetMapListByMapType(MapType.PET_ISLAND);
                if (maplist1 != null && maplist1.Count > 0) { MapCGHandler.sendCGMapPlayerEnter(maplist1[0].Id); }
                break;
            case FunctionIdDef.CHONGWUDAO_ER://宠物岛二层
                List<MapTemplate> maplist2 = MapTemplateDB.Instance.GetMapListByMapType(MapType.PET_ISLAND);
                if (maplist2 != null && maplist2.Count > 0) { MapCGHandler.sendCGMapPlayerEnter(maplist2[1].Id); }
                break;
            case FunctionIdDef.CHONGWUDAO_SAN://宠物岛三层
                List<MapTemplate> maplist3 = MapTemplateDB.Instance.GetMapListByMapType(MapType.PET_ISLAND);
                if (maplist3 != null && maplist3.Count > 0) { MapCGHandler.sendCGMapPlayerEnter(maplist3[2].Id); }
                break;
            case FunctionIdDef.CHONGWUDAO_SI://宠物岛四层
                List<MapTemplate> maplist4 = MapTemplateDB.Instance.GetMapListByMapType(MapType.PET_ISLAND);
                if (maplist4 != null && maplist4.Count > 0) { MapCGHandler.sendCGMapPlayerEnter(maplist4[3].Id); }
                break;
            case FunctionIdDef.NVSN: //NvsN
                if (nvnModel == null)
                {
                    nvnModel = NvsNModel.Ins;
                }
                nvnModel.EnterNvsNScene();
                break;
            case FunctionIdDef.JUESEJIADIAN://角色加点
            case FunctionIdDef.ROLE_ADDPOINT:
                WndManager.open(GlobalConstDefine.RoleInfoView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 1));
                break;
            case FunctionIdDef.CHONGWU://宠物
                WndManager.open(GlobalConstDefine.PetInfoView_Name);
                break;
            case FunctionIdDef.CHONGWU_JIADIAN://宠物加点
                WndManager.open(GlobalConstDefine.PetInfoView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.CHONGWU_JIADIAN));
                break;
            case FunctionIdDef.PETTALENTSKILL://宠物天赋技能
                WndManager.open(GlobalConstDefine.PetInfoView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.PETTALENTSKILL));
                break;
            case FunctionIdDef.CHIBANG://翅膀
                WndManager.open(GlobalConstDefine.BagView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.BEIBAO));
                break;
            case FunctionIdDef.DUIHUANJIANGLI://兑换奖励
                WndManager.open(GlobalConstDefine.DuiHuanJiangLiView);
                break;
            case FunctionIdDef.VIP:
                WndManager.open(GlobalConstDefine.VIPView);
                break;
            case FunctionIdDef.TOWER_BEAST://通天塔最优击杀
                Dictionary<int,TowerMapTemplate> templates = TowerMapTemplateDB.Instance.getIdKeyDic();
                int level = -1;
                foreach (var item in templates)
	            {
                    if (item.Value.mapId == ZoneModel.ins.tryEnterZoneId)
                    {
                        level = item.Value.towerLevelId;
                    }
            	}
                if (level == -1)
                {
                    ClientLog.LogError("towerLevel is not exist");
                }
                else
                {
                    TowerCGHandler.sendCGWatchBestKillerReplay(level);
                }
                break;
            case FunctionIdDef.TOWER_EARLIEST://通天塔 最先击杀
                 Dictionary<int,TowerMapTemplate> mtemplates = TowerMapTemplateDB.Instance.getIdKeyDic();
                int mlevel = -1;
                foreach (var item in mtemplates)
	            {
                    if (item.Value.mapId == ZoneModel.ins.tryEnterZoneId)
                    {
                        mlevel = item.Value.towerLevelId;
                    }
            	}
                if (mlevel == -1)
                {
                    ClientLog.LogError("towerLevel is not exist");
                }
                else
                {
                    TowerCGHandler.sendCGWatchFirstKillerReplay(mlevel);
                }
                break;

            case FunctionIdDef.CORPSBOSS_CHANLLGE://挑战帮派Boss
                WndManager.open(GlobalConstDefine.BangpaiBossView_name);
                break;
            case FunctionIdDef.CORPSBOSS_BEAST://查看帮派boss最优击杀
                CorpsbossCGHandler.sendCGWatchCorpsBoss();
                break;
            case FunctionIdDef.FENGYAO_MOWANG://封妖 妖魔
            case FunctionIdDef.FENGYAO_XIAOYAO://封妖 妖王
            case FunctionIdDef.HUNSHIMOWANG://混世魔王
                if (TeamModel.ins.hasTeam())
                {
                    if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
                    {
                        WndManager.open(GlobalConstDefine.TeamMainView_Name);
                    }
                    else
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("已在队伍中");
                    }
                }
                else
                {
                    WndManager.open(GlobalConstDefine.TeamApplyView_Name,WndParam.CreateWndParam(WndParam.LINK_TO_FUNC,funcid));
                }               
                break;
            case FunctionIdDef.XIANSHI_DATI:
                KeJuModel.Ins.CanOpen(KeJuType.XIANSHIDATI);
                break;
            case FunctionIdDef.XIANSHI_SHAGUAI:
                TimelimitCGHandler.sendCGTlMonsterAccept();
                break;
            case FunctionIdDef.XIANSHI_NPC:
                TimelimitCGHandler.sendCGTlNpcAccept();
                break;
            case FunctionIdDef.BANGPAIXIULIAN:
                WndManager.open(GlobalConstDefine.XinFaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 2));
                break;
            case FunctionIdDef.BANGPAIFUZHU:
                WndManager.open(GlobalConstDefine.XinFaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 3));
                break;
            case FunctionIdDef.BANGPAIHONGBAO:
                WndManager.open(GlobalConstDefine.BANGPAIHONGBAOVIEW);
                break;
            case FunctionIdDef.DANRENFUBEN:
                WndManager.open(GlobalConstDefine.DANRENFUBENVIEW);
                break;
            case FunctionIdDef.JINGCAIHUODONG2:
                GoodActivityModel.Ins.IsWaitingShowPanel = true;
                GoodactivityCGHandler.sendCGGoodActivityList(FunctionIdDef.JINGCAIHUODONG2);
                break;
            case FunctionIdDef.STORY_VIDEO:
                WndManager.open(GlobalConstDefine.StoryView);
                break;
            case FunctionIdDef.PUTONGMOZU:
            case FunctionIdDef.KUNNANMOZU:
                WndManager.open(GlobalConstDefine.MoZuFuBenViewName);
                break;
            case FunctionIdDef.XIANHU:
                WndManager.open(GlobalConstDefine.XianHuViewName);
                break;
            case FunctionIdDef.XIAN_HU_ZUORI:
                HumanCGHandler.sendCGXianhuRankReward((int)XianhuRankType.QIFU_XIANHU_ZUORI);
                break;
            case FunctionIdDef.LING_XI_XIANHU_ZUORI:
                HumanCGHandler.sendCGXianhuRankReward((int)XianhuRankType.LINGXI_XIANHU_ZUORI);
                break;
            case FunctionIdDef.LING_XI_XIANHU_SHANGZHOU:
                HumanCGHandler.sendCGXianhuRankReward((int)XianhuRankType.LINGXI_XIANHU_LASTWEEK);
                break;
            case FunctionIdDef.NEWGUAJI:
                WndManager.open(GlobalConstDefine.NewGuaJiViewName);
                break;
            case FunctionIdDef.SHENGHUOJINENG:
                WndManager.open(GlobalConstDefine.XinFaView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 5));
                break;
            case FunctionIdDef.SHENGHUOJINENG_STORE://生活技能书商店
                WndManager.open(GlobalConstDefine.PetStoreView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, funcid));
                break;
            case FunctionIdDef.YUEKA://月卡
                WndManager.open(GlobalConstDefine.YueKaViewName);
                break;
            case FunctionIdDef.RINGTASK://环任务
                RingTaskModel.Ins.LinkParse();
                break;
            case FunctionIdDef.QICHONGJIADIAN://骑宠加点
                WndManager.open(GlobalConstDefine.PetInfoView_Name, WndParam.CreateWndParam(WndParam.LINK_TO_FUNC, FunctionIdDef.QICHONGJIADIAN));
                break;
            default:
                ZoneBubbleManager.ins.BubbleSysMsg("此功能尚未开放，敬请期待");
                ClientLog.LogError("链接到功能id，功能没有定义：funcid:" + funcid);
                break;
        }
    }

    public override void Destroy()
    {
        _curLinkType = 0;
        if (_curLinkParam!=null) _curLinkParam.Clear();
        mIsChangedToYunliangren = false;
        jiuguanModel = null;
        yunliangModel = null;
        relationModel = null;
        chubaoModel = null;
        baotuModel = null;
        shituModel = null;
        hunyinModel = null;
        nvnModel = null;
        _ins = null;
    }
}
