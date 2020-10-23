using System.Collections.Generic;
using app.config;
using app.guide;
using app.model;
using app.net;
using app.npc;
using app.tips;
using app.zone;
using UnityEngine;
using app.story;
using app.state;

/// <summary>
/// 新手引导规则：
/// 1.出引导的时候关闭所有与引导无关的界面
/// 2.正在引导的时候，不能打开与引导无关的界面
/// 3.开始引导后，停止自动寻路，停止跑动，停止自动做绿野
/// 4.新功能开启后触发的引导，必须有任务限制，即完成任务时触发 功能开启和引导，能保证在主城、主界面状态
/// 5.新功能开启带引导的，必须有新功能提示（需要新功能图片），然后再触发引导
/// 6.完成任务后触发事件顺序如下：交任务-》剧情、新功能提示、引导
/// </summary>
public class GuideManager:AbsMonoBehaviour
{
    public string StartGuideEvent = "StartGuideEvent";
    public string EndGuideEvent = "EndGuideEvent";
    /// <summary>
    /// 当前正在引导的目标对象
    /// </summary>
    public GameObject targetObject;
    private Canvas guideCanvas;
    private GuideIdDef currentGuideId;
    //字典，记录每个引导有多少步
    private Dictionary<GuideIdDef, int> stepDic;
    //字典，记录每个引导需要显示哪些面板
    private Dictionary<GuideIdDef, List<string>> panelDic;
    private int currentStep=1;
    private bool autoRunNext=true;

    public Vector2 targetSizeDelta=Vector2.zero;
    public Vector3 totalOffset = Vector3.zero;
    public Vector3 kuangOffset = Vector3.zero;
    public Vector3 maskOffset = Vector3.zero;
    /// <summary>
    /// 有引导的功能列表,值为功能id，FunctionIdDef
    /// </summary>
    private List<int> funcHasGuide = new List<int>();
    /// <summary>
    /// 正在等待显示引导的列表,值为GuideIdDef
    /// </summary>
    private List<GuideIdDef> waitingShowGuide = new List<GuideIdDef>();

    public GuideManager()
    {
        initGuideDic();
    }
    private static GuideManager _ins;

    public static GuideManager Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new GuideManager();
            }
            return _ins;
        }
    }

    public GuideIdDef CurrentGuideId
    {
        get { return currentGuideId; }
    }

    public bool AutoRunNext
    {
        get { return autoRunNext; }
    }

    private void initGuideDic()
    {
        if (stepDic==null)
        {
            stepDic = new Dictionary<GuideIdDef, int>();
            stepDic.Add(GuideIdDef.QuestNavigat, 1);
            stepDic.Add(GuideIdDef.UseEquip, 1);
            stepDic.Add(GuideIdDef.UsePet, 4);
            stepDic.Add(GuideIdDef.FirstBattle, 6);
            stepDic.Add(GuideIdDef.QianDao, 2);
            stepDic.Add(GuideIdDef.KeJu,3);
            stepDic.Add(GuideIdDef.JingJiChang, 3);
            stepDic.Add(GuideIdDef.LvYeXianZong, 3);
            stepDic.Add(GuideIdDef.ShengXing, 3);
            stepDic.Add(GuideIdDef.LevelReward, 3);
            stepDic.Add(GuideIdDef.JiuGuan, 3);
            stepDic.Add(GuideIdDef.TongTianTa, 2);
            stepDic.Add(GuideIdDef.CangBaoTu, 3);
            stepDic.Add(GuideIdDef.YunLiang, 3);
            stepDic.Add(GuideIdDef.ChuBao, 3);
            stepDic.Add(GuideIdDef.DaZao, 10);
            stepDic.Add(GuideIdDef.PetTalent, 3);
            stepDic.Add(GuideIdDef.Gem, 15);
            stepDic.Add(GuideIdDef.SkillShuLian, 7);
            stepDic.Add(GuideIdDef.XinFaShengJi, 4);
            stepDic.Add(GuideIdDef.SkillShengJi, 3);
            stepDic.Add(GuideIdDef.RingTask, 3);
            stepDic.Add(GuideIdDef.AddFriend, 2);
        }
        if (panelDic == null)
        {
            panelDic = new Dictionary<GuideIdDef, List<string>>();
            panelDic.Add(GuideIdDef.QuestNavigat,null);
            panelDic.Add(GuideIdDef.UseEquip, new List<string>() { GlobalConstDefine.PopUseWnd_Name });
            panelDic.Add(GuideIdDef.UsePet, new List<string>() { GlobalConstDefine.PopUseWnd_Name,
                GlobalConstDefine.PetInfoView_Name });
            panelDic.Add(GuideIdDef.FirstBattle,null);
            panelDic.Add(GuideIdDef.QianDao, new List<string>() { GlobalConstDefine.JiangLiView });
            panelDic.Add(GuideIdDef.KeJu, new List<string>() { GlobalConstDefine.ActivityListView_Name,
                GlobalConstDefine.KeJuView_Name });
            panelDic.Add(GuideIdDef.JingJiChang, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.JingJiChangView });
            panelDic.Add(GuideIdDef.LvYeXianZong, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.NpcChatView_Name });
            panelDic.Add(GuideIdDef.ShengXing, new List<string>() { GlobalConstDefine.DaZaoViewView_Name});
            panelDic.Add(GuideIdDef.LevelReward, new List<string>() { GlobalConstDefine.JiangLiView});
            panelDic.Add(GuideIdDef.JiuGuan, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.NpcChatView_Name, GlobalConstDefine.JiuGuanRenWuView_Name });
            panelDic.Add(GuideIdDef.TongTianTa, new List<string>() { GlobalConstDefine.TongTianTaView_Name });
            panelDic.Add(GuideIdDef.CangBaoTu, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.NpcChatView_Name });
            panelDic.Add(GuideIdDef.YunLiang, new List<string>() { GlobalConstDefine.ActivityListView_Name,
                GlobalConstDefine.NpcChatView_Name });
            panelDic.Add(GuideIdDef.ChuBao, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.NpcChatView_Name });
            panelDic.Add(GuideIdDef.DaZao, new List<string>() { GlobalConstDefine.DaZaoViewView_Name });
            panelDic.Add(GuideIdDef.PetTalent, new List<string>() { GlobalConstDefine.PetInfoView_Name });
            panelDic.Add(GuideIdDef.Gem, new List<string>() { GlobalConstDefine.DaZaoViewView_Name });
            panelDic.Add(GuideIdDef.SkillShuLian, new List<string>() { GlobalConstDefine.XinFaView_Name });
            panelDic.Add(GuideIdDef.XinFaShengJi, new List<string>() { GlobalConstDefine.XinFaView_Name });
            panelDic.Add(GuideIdDef.SkillShengJi, new List<string>() { GlobalConstDefine.BagView_Name });
            panelDic.Add(GuideIdDef.RingTask, new List<string>() { GlobalConstDefine.ActivityListView_Name, 
                GlobalConstDefine.ConFirmWndView });
            panelDic.Add(GuideIdDef.AddFriend, new List<string>() { GlobalConstDefine.RelationView_Name,
                GlobalConstDefine.PopUseWnd_Name});
        }
    }

    /// <summary>
    /// 是否 功能的引导
    /// </summary>
    /// <param name="guideid">功能id</param>
    public bool IsFuncGuide(GuideIdDef guideId)
    {
        int funcid=0;
        switch (guideId)
        {
            case GuideIdDef.QianDao:
                funcid = FunctionIdDef.QIANDAO;
                break;
            case GuideIdDef.KeJu:
                funcid = FunctionIdDef.KEJU;
                break;
            case GuideIdDef.JingJiChang:
                funcid = FunctionIdDef.JINGJICHANG;
                break;
            case GuideIdDef.LvYeXianZong:
                funcid = FunctionIdDef.LVYEXIANZONG;
                break;
            case GuideIdDef.ShengXing:
                funcid = FunctionIdDef.SHENGXING;
                break;
            case GuideIdDef.JiuGuan:
                funcid = FunctionIdDef.JIUGUAN;
                break;
            case GuideIdDef.TongTianTa:
                funcid = FunctionIdDef.TOWER;
                break;
            case GuideIdDef.CangBaoTu:
                funcid = FunctionIdDef.BAOTU;
                break;
            case GuideIdDef.YunLiang:
                funcid = FunctionIdDef.YUNLIANG;
                break;
            case GuideIdDef.ChuBao:
                funcid = FunctionIdDef.CHUBAOANLIANG;
                break;
            case GuideIdDef.DaZao:
                funcid = FunctionIdDef.DAZAO;
                break;
            case GuideIdDef.Gem:
                funcid = FunctionIdDef.XIANGQIAN;
                break;
            case GuideIdDef.RingTask:
                funcid = FunctionIdDef.RINGTASK;
                break;
        }
        return (funcid != 0);
    }

    /// <summary>
    /// 获得功能的引导
    /// </summary>
    /// <param name="guideid">功能id</param>
    public GuideIdDef GetFuncGuide(int funcid)
    {
        GuideIdDef guideId=GuideIdDef.NONE;
        switch (funcid)
        {
            case FunctionIdDef.QIANDAO:
                guideId = GuideIdDef.QianDao;
                break;
            case FunctionIdDef.KEJU:
                guideId = GuideIdDef.KeJu;
                break;
            case FunctionIdDef.JINGJICHANG:
                guideId = GuideIdDef.JingJiChang;
                break;
            case FunctionIdDef.LVYEXIANZONG:
                guideId = GuideIdDef.LvYeXianZong;
                break;
            case FunctionIdDef.SHENGXING:
                guideId = GuideIdDef.ShengXing;
                break;
            case FunctionIdDef.JIUGUAN:
                guideId = GuideIdDef.JiuGuan;
                break;
            case FunctionIdDef.TOWER:
                guideId = GuideIdDef.TongTianTa;
                break;
            case FunctionIdDef.BAOTU:
                guideId = GuideIdDef.CangBaoTu;
                break;
            case FunctionIdDef.YUNLIANG:
                guideId = GuideIdDef.YunLiang;
                break;
            case FunctionIdDef.CHUBAOANLIANG:
                guideId = GuideIdDef.ChuBao;
                break;
            case FunctionIdDef.DAZAO:
                guideId = GuideIdDef.DaZao;
                break;
            case FunctionIdDef.XIANGQIAN:
                guideId = GuideIdDef.Gem;
                break;
            case FunctionIdDef.RINGTASK:
                guideId = GuideIdDef.RingTask;
                break;
        }
        return guideId;
    }

    /// <summary>
    /// 开始触发引导
    /// </summary>
    /// <param name="guideid">引导id</param>
    /// <param name="CanDoImmediate">是否立即能做</param>
    public void StartGuide(GuideIdDef guideid,bool CanDoImmediate=true)
    {
        if (!ServerConfig.instance.IsPassedCheck)
        {
            return;
        }
        if (currentGuideId != GuideIdDef.NONE)
        {
            //有正在做的新手引导
            return;
        }
        if (JuQingManager.Ins.IsPlayingJuQing || !CanDoImmediate)
        {
            //正在播放剧情，等待
            //ClientLog.LogError("StartGuide:" + guideid + "   等待," + JuQingManager.Ins.IsPlayingJuQing + " " + CanDoImmediate);
            waitingShowGuide.Add(guideid);
        }
        else
        {
            if (panelDic.ContainsKey(guideid))
            {
                if (panelDic[guideid] != null)
                {
                    WndManager.Ins.HideAllCurrentShowWndExcept(panelDic[guideid]);
                }
                else
                {
                    WndManager.Ins.HideAllCurrentShowWnd();
                }
            }
            showGuide(guideid);
        }
    }
    /// <summary>
    /// 显示引导
    /// </summary>
    /// <param name="guideid"></param>
    private void showGuide(GuideIdDef guideid)
    {
        if (CurrentGuideId == guideid)
        {
            //正在进行中
            return;
        }
        if (waitingShowGuide.Contains(guideid))
        {
            waitingShowGuide.Remove(guideid);
        }
        currentStep = 1;
        currentGuideId = guideid;
        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        if (maskwnd!=null)
        {
            maskwnd.switchMask();
        }
        WndManager.Ins.AddIgnoreDestroyWnd(GlobalConstDefine.GuideMaskWnd);
        EventCore.dispathRMetaEventByParms(StartGuideEvent,CurrentGuideId);
        //ClientLog.LogError("StartGuideEvent：guideid:  " + CurrentGuideId);
    }

    private bool check(GuideIdDef guideid, int step, GameObject targetObj)
    {
        if (CurrentGuideId != guideid)
        {
            //非当前引导，非当前步骤
            return false;
        }
        if (targetObj == null || targetObj == targetObject)
        {
            //ClientLog.LogError("*********************************"+"同一个目标");
            return false;
        }
        //战斗 特殊处理
        if (guideid==GuideIdDef.FirstBattle&&step==6)
        {
            currentStep = 5;
            return true;
        }
        if (autoRunNext && currentStep != step)
        {
            //ClientLog.LogError("*********************************" + "autoRunNext && currentStep != step");
            return false;
        }
        else if (!autoRunNext && (currentStep + 1) != step)
        {
            //ClientLog.LogError("*********************************" + "!autoRunNext && (currentStep + 1) != step");
            return false;
        }
        //ClientLog.LogError("showGuide" + guideid + " 步骤：" + step + " 当前步骤：" + currentStep);
        return true;
    }

    public void ShowGuide(GuideIdDef guideid, int step, GameObject targetObj, Vector3 totalOffsetv,Vector3 kuangOffsetv,Vector3 maskOffsetv,Vector2 sizeDelta,bool autoRunNextv = true, int delayMultiSeconds = 0)
    {
        if (!check(guideid, step, targetObj))
        {
            return;
        }
        targetSizeDelta = sizeDelta;
        totalOffset = totalOffsetv;
        kuangOffset = kuangOffsetv;
        maskOffset = maskOffsetv;

        doGuide(guideid, step, targetObj, autoRunNextv, delayMultiSeconds);
    }

    /// <summary>
    /// 显示引导
    /// </summary>
    /// <param name="guideid">引导id</param>
    /// <param name="step">第几步</param>
    /// <param name="targetObj">引导的目标对象</param>
    public void ShowGuide(GuideIdDef guideid, int step, GameObject targetObj, bool autoRunNextv = true,int delayMultiSeconds=0)
    {
        if (!check(guideid,step,targetObj))
        {
            return;
        }
        targetSizeDelta = Vector2.zero;
        totalOffset = Vector3.zero;
        kuangOffset = Vector3.zero;
        maskOffset = Vector3.zero;

        doGuide(guideid, step, targetObj, autoRunNextv, delayMultiSeconds);
    }

    public void switchMask(bool hightLight = false)
    {
        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        if (maskwnd.isShown)
        {
            maskwnd.switchMask(hightLight);
        }
    }

    public void switchMask(GuideIdDef guideid,bool hightLight = false)
    {
        if (CurrentGuideId != guideid)
        {
            //非当前引导，非当前步骤
            return;
        }
        //ClientLog.LogError("------切换到高亮状态");
        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        if (hightLight==maskwnd.isCurHighLight())
        {
            //已经设置了
            return;
        }
        if (maskwnd.isShown)
        {
            maskwnd.switchMask(hightLight);
        }
    }

    /// <summary>
    /// 显示引导
    /// </summary>
    /// <param name="guideid">引导id</param>
    /// <param name="step">第几步</param>
    /// <param name="targetObj">引导的目标对象</param>
    private void doGuide(GuideIdDef guideid, int step, GameObject targetObj, bool autoRunNextv = true, int delayMultiSeconds = 0)
    {
        if (step==1)
        {
            //开启新手引导第一步，停止 自动
            AutoMaticManager.Ins.StopAutoMatic();
        }

        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        if (targetObject != null && !autoRunNext)
        {
            if (maskwnd!=null) maskwnd.clickTarget();
        }
        targetObject = null;
        if (delayMultiSeconds != 0)
        {
            RTimer r = TimerManager.Ins.createTimer(100, delayMultiSeconds, null, (RTimer rr) =>
            {
                setGuide(targetObj, autoRunNextv);
            });
            r.start();
            maskwnd.switchMask(true);
        }
        else
        {
            setGuide(targetObj, autoRunNextv);
        }
    }

    private void setGuide(GameObject targetObj, bool autoRunNextv = true)
    {
        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        //if (maskwnd != null && maskwnd.isShown)
        //{
        //    maskwnd.switchMask();
        //}
        autoRunNext = autoRunNextv;
        //ClientLog.LogError("---------------------显示引导 " + currentGuideId + " 步骤：" + currentStep);
        targetObject = targetObj;
        if (guideCanvas == null)
        {
            guideCanvas = UGUIConfig.GetCanvasByWndType(WndType.GUIDE);
        }
        guideCanvas.gameObject.SetActive(true);

        if (!maskwnd.isShown)
        {
            WndManager.Ins.AddIgnoreDestroyWnd(GlobalConstDefine.GuideMaskWnd);
            WndManager.open(GlobalConstDefine.GuideMaskWnd);
        }
        else
        {
            maskwnd.reshow();
        }
        if (maskwnd != null && maskwnd.isShown)
        {
            maskwnd.switchMask();
        }
    }
    /// <summary>
    /// 进行下一步
    /// </summary>
    public void DoNext()
    {
        int totalStep=0;
        if (stepDic!=null) stepDic.TryGetValue(CurrentGuideId, out totalStep);
        if (currentStep >= totalStep)
        {
            RemoveGuide();
        }
        else
        {
            //targetObject = null;
            currentStep++;
            //ClientLog.LogError("1111111111下一步到：引导：" + CurrentGuideId + " 步骤：" + currentStep);
        }
    }
    /// <summary>
    /// 移除引导
    /// </summary>
    public void RemoveGuide(GuideIdDef guidid=GuideIdDef.NONE)
    {
        if (guidid != GuideIdDef.NONE)
        {
            if (currentGuideId!=guidid)
            {
                return;
            }
        }
        GuideIdDef tmp = currentGuideId;
        currentGuideId = GuideIdDef.NONE;
        currentStep = 1;
        autoRunNext = true;
        //guideCanvas.gameObject.SetActive(false);
        WndManager.Ins.close(GlobalConstDefine.GuideMaskWnd);
        WndManager.Ins.RemoveIgnoreDestroyWnd(GlobalConstDefine.GuideMaskWnd);
        targetObject = null;
        EventCore.dispathRMetaEventByParms(EndGuideEvent, tmp);
        if (tmp == GuideIdDef.UseEquip || tmp == GuideIdDef.UsePet)
        {
            //使用物品和使用宠物 后 继续引导任务
            StartGuide(GuideIdDef.QuestNavigat);
        }
        StoryManager.ins.EnterWaiteStory();
        //ClientLog.LogError("End GuideEvent：guideid:  " + tmp);
    }
    /// <summary>
    /// 更新 功能引导列表
    /// </summary>
    /// <param name="funcGuideDic"></param>
    public void updateFuncHasGuide(Dictionary<int,bool> funcGuideDic)
    {        
        foreach (KeyValuePair<int, bool> pair in funcGuideDic)
        {
            if (pair.Value)
            {
                if (pair.Key==FunctionIdDef.QIANDAO)
                {
                    continue;
                }
                //有引导
                if (!funcHasGuide.Contains(pair.Key))
                {
                    funcHasGuide.Add(pair.Key);
                }
            }
            else
            {
                //移除引导
                if (funcHasGuide.Contains(pair.Key))
                {
                    funcHasGuide.Remove(pair.Key);
                }
            }
        }
    }

    public bool checkFuncGuide()
    {
        if (funcHasGuide.Count>0)
        {
            RequestNewFuncGuide(funcHasGuide[0]);
            return true;
        }
        return false;
    }

    private void RequestNewFuncGuide(int functype)
    {
        if (funcHasGuide.Contains(functype))
        {
            funcHasGuide.Remove(functype);
            GuideCGHandler.sendCGShowGuideByFunc(functype);
            GuideIdDef guideid = GuideManager.Ins.GetFuncGuide(functype);
            if (guideid!=GuideIdDef.NONE)
            {
                StartGuide(guideid);
            }
        }
    }

    public bool checkWaitingGuide()
    {
        if (currentGuideId!=GuideIdDef.NONE)
        {
            //正在做新手引导
            return true;
        }
        if (waitingShowGuide.Count>0)
        {
            for (int i=0;i<waitingShowGuide.Count;i++)
            {
                bool canStart = false;
                switch (waitingShowGuide[i])
                {
                    case GuideIdDef.QuestNavigat:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.questUI != null && ZoneUI.ins.UI.questUI.isActiveAndEnabled
                            && QuestModel.Ins.HasMainOrSubQuest())
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.UseEquip:
                        if (PopUseWnd.Ins.isShown&&PopUseWnd.Ins.CanStartEquipGuide())
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.UsePet:
                        if (PopUseWnd.Ins.isShown && PopUseWnd.Ins.CanStartPetGuide())
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.FirstBattle:
                        canStart = true;
                        break;
                    case GuideIdDef.QianDao:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null && ZoneUI.ins.UI.mainuiButton.leftBtns != null && ZoneUI.ins.UI.mainuiButton.leftBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.KeJu:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null && ZoneUI.ins.UI.mainuiButton.topBtns != null && ZoneUI.ins.UI.mainuiButton.topBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.JingJiChang:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null && 
                            ZoneUI.ins.UI.mainuiButton.topBtns != null && ZoneUI.ins.UI.mainuiButton.topBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.LvYeXianZong:
                    case GuideIdDef.JiuGuan:
                    case GuideIdDef.TongTianTa:
                    case GuideIdDef.CangBaoTu:
                    case GuideIdDef.YunLiang:
                    case GuideIdDef.ChuBao:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null &&
                            ZoneUI.ins.UI.mainuiButton.topBtns != null && ZoneUI.ins.UI.mainuiButton.topBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.ShengXing:
                    case GuideIdDef.DaZao:
                    case GuideIdDef.Gem:
                    case GuideIdDef.SkillShuLian:
                    case GuideIdDef.XinFaShengJi:
                    case GuideIdDef.SkillShengJi:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null &&
                            ZoneUI.ins.UI.mainuiButton.gameObject.activeInHierarchy&&
                            ZoneUI.ins.UI.mainuiButton.downBtns != null && ZoneUI.ins.UI.mainuiButton.downBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.LevelReward:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null &&
                            ZoneUI.ins.UI.mainuiButton.leftBtns != null && ZoneUI.ins.UI.mainuiButton.leftBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.PetTalent:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.userInfo != null &&
                            ZoneUI.ins.UI.userInfo.petInfo != null && ZoneUI.ins.UI.userInfo.petInfo.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.RingTask:
                        if (ZoneUI.ins.isShown && ZoneUI.ins.UI != null && ZoneUI.ins.UI.mainuiButton != null && ZoneUI.ins.UI.mainuiButton.topBtns != null && ZoneUI.ins.UI.mainuiButton.topBtns.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                    case GuideIdDef.AddFriend:
                        if (ZoneUI.ins.isShown && StateManager.Ins.getCurState().state == StateDef.zoneState && ZoneUI.ins.UI != null && ZoneUI.ins.UI.friendBtn != null && ZoneUI.ins.UI.friendBtn.gameObject.activeInHierarchy)
                        {
                            canStart = true;
                        }
                        break;
                }
                if (canStart)
                {
                    StartGuide(waitingShowGuide[i]);
                    break;
                }
            }
            return true;
        }
        else
        {
            return false;   
        }
    }

    public bool hasWaitigGuide()
    {
        return (waitingShowGuide.Count > 0 || funcHasGuide.Count > 0)?true:false;
    }

    private bool isGuideNeedAllWndHide(GuideIdDef guideid)
    {
        bool need = !(guideid == GuideIdDef.UsePet || guideid == GuideIdDef.UseEquip);
        return need;
    }

    public bool isCurHightLight()
    {
        GuideMaskWnd maskwnd = GuideMaskWnd.Ins;
        if (maskwnd!=null)
        {
            return maskwnd.isCurHighLight();
        }
        return true;
    }
    /// <summary>
    /// 是否正在显示引导
    /// </summary>
    /// <returns></returns>
    public bool isShowingGuide()
    {
        return GuideManager.Ins.CurrentGuideId != GuideIdDef.NONE;
    }
    /// <summary>
    /// 是否 有 等待显示的引导
    /// </summary>
    /// <returns></returns>
    public bool hasGuideWaitingShow()
    {
        //检查有没有新功能开启
        if (FunctionModel.Ins.hasNewFuncOpen())
        {
            return true;
        }
        //没有功能开启，检查有没有可以做的新手引导
        if (waitingShowGuide.Count > 0)
        {
            return true;
        }
        if (funcHasGuide.Count > 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// wnd是否可以打开，正在引导的时候，只有引导需要的面板可以打开，其他的打不开
    /// </summary>
    /// <param name="wndname"></param>
    /// <returns></returns>
    public bool IsWndCanShow(string wndname)
    {
        if (currentGuideId==GuideIdDef.NONE)
        {
            return true;
        }
        if (wndname==GlobalConstDefine.GuideMaskWnd)
        {
            return true;
        }
        if (panelDic!=null&&panelDic.ContainsKey(currentGuideId))
        {
            List<string> wndlist =null;
            panelDic.TryGetValue(currentGuideId, out wndlist);
            if (wndlist==null||(wndlist!=null&&!wndlist.Contains(wndname)))
            {
                return false;
            }
        }
        return true;
    }

    public void Destroy()
    {
        RemoveGuide();
        if(funcHasGuide!=null)funcHasGuide.Clear();
        if(waitingShowGuide!=null)waitingShowGuide.Clear();

    }
}