using System;
using app.battle;
using app.model;
using app.npc;
using app.state;
using app.utils;
using app.team;
using app.net;
using app.db;
using System.Collections.Generic;
using app.human;
using app.tips;
using app.zone;
using UnityEngine;
using app.confirm;

namespace app.fuben
{
    public class FubenlyxzModel : AbsModel
    {
        private static FubenlyxzModel mIns = null;

        private CFubenlyxz m_lvxz = new CFubenlyxz();
        private bool isFirstStart = false;

        public static FubenlyxzModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new FubenlyxzModel();
                }
                return mIns;
            }
        }
        private int m_nTimes;  //副本次数
        public enum EStatue
        {
            PerIn, //可以进入副本 但还未进入 需等界面加载完成
            In, // 在副本里面
            Out,  //在副本外面
            UpdateView, //更新界面
        }

        public EStatue m_eStatue = EStatue.Out;
        /// <summary>
        /// 自动打绿野等待时间
        /// </summary>
        private RTimer waitingTimer;

        public void DoUpdate()
        {
            if (m_eStatue == EStatue.In && AutoMaticManager.Ins.CurAutoMaticType==AutoMaticManager.AutoMaticType.AutoLvYe)
            {
                if (StateManager.Ins.getCurState() != null && StateManager.Ins.getCurState().state == StateDef.zoneState&&
                    ((ZoneCharacterManager.ins.self != null && ZoneCharacterManager.ins.self.curBehavType == ZoneCharacterBehavType.IDLE))&&
                      GuideManager.Ins.CurrentGuideId == GuideIdDef.NONE&&
                      !JuQingManager.Ins.IsPlayingJuQing)//(!WndManager.Ins.hasWndShowing())&&
                {
                    if (BattleModel.ins.BattleResult == 1 || isFirstStart)
                    {
                        //上次战斗胜利，继续
                        if (waitingTimer == null)
                        {
                            waitingTimer = TimerManager.Ins.createTimer(1000, 3000, null, onTimerEnd);
                            waitingTimer.start();
                            //ClientLog.LogError("开始倒计时!");
                        }
                        isFirstStart = false;
                    }
                    else if (BattleModel.ins.BattleResult == 2)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("战斗失败，停止绿野仙踪自动打怪！");
                        AutoMaticManager.Ins.StopAutoMatic();
                    }
                }
            }
        }

        private void onTimerEnd(RTimer rtimer)
        {
            doAutoBattle();
        }

        private void doAutoBattle()
        {
            //继续 自动打怪
            //绿野仙踪 自动打怪，就近遇怪
            ZoneNPC zonenpc = ZoneNPCManager.Ins.GetNearNpc(ZoneNpcType.NpcMonster, NPCType.FUBEN_BATTLE);
            if (zonenpc != null)
            {
                ZoneNPCManager.Ins.gotoNpc(zonenpc.NpcInfoData.mapId, zonenpc.NpcInfoData.npcId, zonenpc.NpcInfoData.uuid, true);
            }
        }

        private void stopWaitTimer()
        {
            if (waitingTimer != null)
            {
                waitingTimer.stop();
                waitingTimer = null;
            }
        }

        public void startAutoBattle()
        {
            if (m_eStatue == EStatue.In&&((!TeamModel.ins.hasTeam()) ||
                (TeamModel.ins.hasTeam() && (TeamModel.ins.GetTeamMemberInfo(Human.Instance.Id).isLeader == 1))))
            {
                stopWaitTimer();
                isFirstStart = true;
                AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.AutoLvYe;
            }
        }

        public void stopAutoBattle()
        {
            isFirstStart = false;
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.None;
            stopWaitTimer();
        }

        /// <summary>
        /// 进入绿野仙踪单人
        /// </summary>
        public void EnterLyxzSingle()
        {
            int curfubenID = -1;
            if (!TeamModel.ins.hasTeam())
            {
                int level = Human.Instance.getLevel();
                curfubenID = WizardRaidTemplateDB.Instance.GetFubenID(level, level, 1);
                if (curfubenID == -1)
                    ClientLog.LogError("绿野仙踪副本等级条件不匹配");
                //没有队 进入单人副本
                if (m_nTimes <= 0)
                {
                    int itemtplid = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.WIZARD_RAID_ENTER_ITEMID);
                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(itemtplid);
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, 
                        StringUtil.Assemble(LangConstant.LVYE_COST_ITEM, new string[1] { (it!=null?it.name:"") }),
                        sureCanJia =>
                    {
                        WizardraidCGHandler.sendCGWizardraidEnterSingle(curfubenID);
                    });
                }
                else
                {
                    WizardraidCGHandler.sendCGWizardraidEnterSingle(curfubenID);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.TEAM_CANNOT_ENTER_SINGLE);
            }
        }

        /// <summary>
        /// 进入绿野仙踪组队副本
        /// </summary>
        public void EnterLyxzTeam()
        {
            int curfubenID = -1;
            if (TeamModel.ins.hasTeam())
            {
                //有队 
                TeamMemberInfo[] teaminfo = TeamModel.ins.myTeamMemberList;
                if (teaminfo == null && teaminfo.Length == 0) return;
                int[] levels = GetTeamsMaxAndMinLevel(teaminfo);
                curfubenID = WizardRaidTemplateDB.Instance.GetFubenID(levels[0], levels[1], 2);
                if (curfubenID == -1)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("队伍成员所在等级段不匹配");
                    //ClientLog.LogError("绿野仙踪副本等级条件不匹配");
                }
                if (m_nTimes <= 0)
                {
                    int itemtplid = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.WIZARD_RAID_ENTER_ITEMID);
                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(itemtplid);
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI,
                        StringUtil.Assemble(LangConstant.LVYE_COST_ITEM, new string[1] { (it!=null?it.name:"") }),
                        sureCanJia =>
                        {
                            WizardraidCGHandler.sendCGWizardraidAskEnterTeam(curfubenID);
                        });
                }
                else
                {

                    WizardraidCGHandler.sendCGWizardraidAskEnterTeam(curfubenID);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.SINGLE_CANNOT_ENTER_TEAM);
            }
        }

        /// <summary>
        /// 获得队内最大最小等级  数组第一位是最小等级 第二位是最大等级
        /// </summary>
        private int[] GetTeamsMaxAndMinLevel(TeamMemberInfo[] _teaminfo)
        {
            int[] arr = new int[2];
            bool flat = false;
            int minlevel = -1;
            int maxlevel = -1;
            for (int i = 0; i < _teaminfo.Length; i++)
            {
                if (!flat)
                {
                    //初始化
                    flat = true;
                    minlevel = _teaminfo[i].level;
                    maxlevel = _teaminfo[i].level;
                }
                //更新最大最小等级
                if (_teaminfo[i].level > maxlevel)
                    maxlevel = _teaminfo[i].level;
                if (_teaminfo[i].level < minlevel)
                    minlevel = _teaminfo[i].level;
            }
            arr[0] = minlevel;
            arr[1] = maxlevel;
            return arr;
        }

        //单人进入副本成功后的返回
        public void GCWizardraidEnterSingleHandler(GCWizardraidEnterSingle msg)
        {
            //PopInfoWnd.Ins.ShowInfo("开始挑战绿野仙踪");
        }

        //队长请求进入副本的返回
        public void GCWizardraidAskEnterTeamHandler(GCWizardraidAskEnterTeam msg)
        {
            if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
            {
                //本人是队长
                PopInfoWnd.Ins.ShowInfo(LangConstant.WAIT_MEMBER_AGREE);
                WizardraidCGHandler.sendCGWizardraidAnswerEnterTeam(1);
            }
            else
            {
                ConfirmWndParam param = new ConfirmWndParam()
                {
                    _isSingleBtn = false,
                    _secondsLeftForHide = 10,
                    cancelHandler = CancelEnter,
                    hideHandlerFlag = ConfirmWndCancleEnum.CANCEL,
                    title = LangConstant.TISHI,
                    info = LangConstant.SURE_ENTER_LVYE,
                    confirmHandler = ConfirmEnter
                };
                ConfirmWnd.Ins.ShowConfirmByParam(param);
                //ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_ENTER_LVYE, ConfirmEnter, CancelEnter);
            }
        }

        private void ConfirmEnter(RMetaEvent e)
        {
            //同意进入
            WizardraidCGHandler.sendCGWizardraidAnswerEnterTeam(1);
        }

        private void CancelEnter(RMetaEvent e)
        {
            //不同意进入
            WizardraidCGHandler.sendCGWizardraidAnswerEnterTeam(0);
        }

        //组队进入副本成功后的返回
        public void GCWizardraidEnterTeamHandler(GCWizardraidEnterTeam msg)
        {
            PopInfoWnd.Ins.hide();
        }

        //副本信息的返回
        public void GCWizardraidInfoHandler(GCWizardraidInfo msg)
        {
            m_lvxz.SetEmpty();
            long lon = msg.getLeftTime();
            m_lvxz.m_lTotolMiliSec = (int)lon;
            m_lvxz.m_tex_boshu = msg.getWave().ToString();
            m_lvxz.m_tex_mosnum = msg.getWinNum().ToString();

            if (m_eStatue == EStatue.Out)
            {
                //刚进入副本
                m_eStatue = EStatue.PerIn;
                FubenlyxzWnd.Ins.EnterFuben();
            }

            ChaneStatue(EStatue.UpdateView);
        }

        //剩余次数的返回
        public void GCWizardraidLeftTimesHandler(GCWizardraidLeftTimes msg)
        {
            int time = msg.getLeftFreeTimes();
            m_nTimes = time;

        }

        /// <summary>
        /// 更新界面
        /// </summary>
        public void ChaneStatue(EStatue statue)
        {
            switch (statue)
            {
                case EStatue.In:
                    //进入副本时
                    List<string> list = new List<string>();
                    list.Add(ZoneUI.USER_INFO);
                    list.Add(ZoneUI.CHAT_INFO);
                    list.Add(ZoneUI.QUEST_INFO);
                    list.Add(ZoneUI.EXP_BAR);
                    list.Add(ZoneUI.MAIN_BUTTONS);
                    ZoneUI.ins.showPart(list);
                    FubenlyxzWnd.Ins.UpdateView(m_lvxz);
                    //PopInfoWnd.Ins.ShowInfo("副本挑战剩余次数：" + m_nTimes, LangConstant.TISHI, TextAnchor.MiddleCenter);
                    m_eStatue = statue;
                    //进入副本的时候 清除等待时间，重新开始等待
                    stopWaitTimer();
                    break;
                case EStatue.Out:
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_LEAVE_LVYE,
                                        delegate(RMetaEvent e)
                                        { //退出副本时
                                            WizardraidCGHandler.sendCGWizardraidLeave();
                                        });
                    stopAutoBattle();
                    break;
                case EStatue.UpdateView:
                    if (m_eStatue == EStatue.In)
                    {
                        //如果已经在副本里了 才更新界面
                        FubenlyxzWnd.Ins.UpdateView(m_lvxz);
                    }
                    break;
            }
        }

        public void Enter()
        {
            if (m_eStatue == EStatue.PerIn || m_eStatue == EStatue.In)
            {
                ChaneStatue(EStatue.In);
            }
        }

        public void ExitMap()
        {
            if (m_eStatue != EStatue.Out)
            {
                FubenlyxzWnd.Ins.hide();
                m_eStatue = EStatue.Out;
            }
        }

        /// <summary>
        /// 是否在副本里 true在里面 false不在里面
        /// </summary>
        public bool IsInLyxz()
        {
            if (m_eStatue == EStatue.In)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public override void Destroy()
        {
            m_lvxz.SetEmpty();
            m_eStatue = EStatue.Out;
            m_nTimes = 0;
            mIns = null;
            stopWaitTimer();
        }


    }
}
