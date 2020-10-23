using System.Collections.Generic;
using app.human;
using app.net;
using app.pet;
using app.team;
using app.utils;
using app.zone;
using UnityEngine;

namespace app.nvsn
{
    public class NvsNView:BaseWnd
    {
        //[Inject(ui = "NvsNUI")]
        //public GameObject ui;
        public NvNUI UI;

        public NvsNModel nvsnModel;
        
        private List<NvNPaiHangListUI> paihangList;
        /// <summary>
        /// 计时器
        /// </summary>
        private RTimer rtimer;
        /// <summary>
        /// 正在匹配计时器间隔，100ms
        /// </summary>
        private const int pipeiIngJiange = 100;
        /// <summary>
        /// 匹配成功计时器间隔，1000ms
        /// </summary>
        private const int pipeiSuccessJiange = 1000;
        /// <summary>
        /// 总时间
        /// </summary>
        private const int totalTimer = 3500;
        
        public NvsNView()
        {
            uiName = "NvsNUI";
        }
        public override void initWnd()
        {
            base.initWnd();
            
            nvsnModel = NvsNModel.Ins;
            nvsnModel.addChangeEvent(NvsNModel.UPDATE_MYINFO, UpdateMyInfo);
            nvsnModel.addChangeEvent(NvsNModel.UPDATE_RANKLIST, UpdateRankList);
            nvsnModel.addChangeEvent(NvsNModel.UPDATE_MATCHEDTEAMINFO, UpdateMatchedTeamInfo);
            nvsnModel.addChangeEvent(NvsNModel.UPDATE_STATUS, UpdateStatus);
            
            UI = ui.AddComponent<NvNUI>();
            UI.Init();
            UI.zidongpipei.SetClickCallBack(startPiPei);
            UI.quxiaopipei.SetClickCallBack(stopPiPei);
            UI.infoBtn.SetClickCallBack(showinfo);
            UI.closeBtn.SetClickCallBack(clickclose);
            EventCore.addRMetaEventListener(TeamModel.UPDATE_TEAM_LIST, UpdateMyTeamList);
        }

        private void clickclose()
        {
            if (TeamModel.ins.hasTeam() && TeamModel.ins.GetLeaderUUID().Equals(Human.Instance.Id))
            {
                hide();
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("只有队长才能关闭！");
            }
        }

        public override void show(RMetaEvent e = null)
        {
 	        base.show(e);
            UpdateMyInfo();
            UpdateRankList();
            UpdateMatchedTeamInfo();
            UpdateStatus();
            app.main.GameClient.ins.OnBigWndShown();
        }

        /// <summary>
        /// 更新自己的信息
        /// </summary>
        /// <param name="e"></param>
        public void UpdateMyInfo(RMetaEvent e=null)
        {
            if (UI==null)
            {
                return;
            }
            //我的排名
            UI.mypaihang.paiming.text = (nvsnModel.MyInfo.getRank()==0)?"榜外":(nvsnModel.MyInfo.getRank().ToString());
            UI.mypaihang.rolename.text = Human.Instance.getName();
            UI.mypaihang.zhiye.text = PetJobType.GetJobName(Human.Instance.PetModel.getLeader().getJob());
            UI.mypaihang.jifen.text = nvsnModel.MyInfo.getScore().ToString();
            UI.mypaihang.liansheng.text = nvsnModel.MyInfo.getConWinNum().ToString();
            //队伍积分
            UI.myTeamJifen.text = "队伍积分: "+nvsnModel.MyInfo.getTeamScore();
            //活动事件列表
            string logtext = "";
            int logLen = nvsnModel.MyInfo.getMyLog().Length;
            for (int i = 0; i < logLen; i++)
            {
                logtext += nvsnModel.MyInfo.getMyLog()[i]+"\n";
            }
            UI.logText.text = logtext;
            //我的队伍 成员列表
            UpdateMyTeamList();
        }

        public void UpdateMyTeamList(RMetaEvent e=null)
        {
            List<TeamMemberInfo> teamMemberList = TeamModel.ins.GetTeamListExceptZanLi();
            for (int i = 0; i < UI.myTeamList.Count; i++)
            {
                if (i < teamMemberList.Count)
                {
                    UI.myTeamList[i].icon.gameObject.SetActive(true);
                    UI.myTeamList[i].biangkuang.gameObject.SetActive(true);
                    UI.myTeamList[i].num.gameObject.SetActive(true);
                    PathUtil.Ins.SetHeadIcon(UI.myTeamList[i].icon, teamMemberList[i].tplId);                    
                    /*
                    PathUtil.Ins.SetPetIconSource(UI.myTeamList[i].icon,
                        teamMemberList[i].tplId);
                    */
                    //string jobiconname = PetJobType.GetJobIconName(teamMemberList[i].jobTypeId);
                    //UI.myTeamList[i].biangkuang.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, jobiconname);
                    UI.myTeamList[i].biangkuang.gameObject.SetActive(false);
                    UI.myTeamList[i].num.text = "Lv." + teamMemberList[i].level;
                }
                else
                {
                    UI.myTeamList[i].icon.gameObject.SetActive(false);
                    UI.myTeamList[i].biangkuang.gameObject.SetActive(false);
                    UI.myTeamList[i].num.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// 更新排行列表
        /// </summary>
        /// <param name="e"></param>
        public void UpdateRankList(RMetaEvent e = null)
        {
            if (UI == null)
            {
                return;
            }
            if (nvsnModel.RankList == null)
            {
                return;
            }
            if (paihangList==null)
            {
                paihangList = new List<NvNPaiHangListUI>();
            }
            UI.defaultPaihang.gameObject.SetActive(false);
            for (int i=0;i<nvsnModel.RankList.Length;i++)
            {
                if (i<=paihangList.Count)
                {
                    NvNPaiHangListUI listui = GameObject.Instantiate(UI.defaultPaihang);
                    listui.transform.SetParent(UI.paihanggrid.transform);
                    listui.transform.localScale = Vector3.one;
                    listui.gameObject.SetActive(true);
                    //listui.toggle.isOn = false;
                    //UI.daleiTBG.AddToggle(twa.toggle);
                    paihangList.Add(listui);
                }
                paihangList[i].danshuBG.gameObject.SetActive(i%2!=0);
                paihangList[i].shuangshuBG.gameObject.SetActive(i % 2 == 0);
                paihangList[i].paiming.text = nvsnModel.RankList[i].rank.ToString();
                paihangList[i].rolename.text = nvsnModel.RankList[i].name.ToString();
                paihangList[i].zhiye.text = PetJobType.GetJobNameByRoleTplId(nvsnModel.RankList[i].tplId);
                paihangList[i].jifen.text = nvsnModel.RankList[i].score.ToString();
                paihangList[i].liansheng.text = nvsnModel.RankList[i].conWinNum.ToString();
            }
            //多余的隐藏
            for (int i = nvsnModel.RankList.Length; i < paihangList.Count; i++)
            {
                paihangList[i].gameObject.SetActive(false);
            }
        }

        public void UpdateMatchedTeamInfo(RMetaEvent e = null)
        {
            if (UI == null)
            {
                return;
            }
            if (nvsnModel.CurrentNvsNStatus != (int)NvsNStatusDef.MATCHED)
            {
                for (int i = 0; i < UI.defenceTeamList.Count; i++)
                {
                    UI.defenceTeamList[i].icon.gameObject.SetActive(false);
                    UI.defenceTeamList[i].biangkuang.gameObject.SetActive(false);
                    UI.defenceTeamList[i].num.gameObject.SetActive(false);
                }
                UI.defenceJifen.text = "队伍积分: 0";
                return;
            }
            //队伍积分
            UI.defenceJifen.text = "队伍积分: " + ((nvsnModel.MatchedTeamInfo!=null)?nvsnModel.MatchedTeamInfo.getTeamScore().ToString():"0");
            //匹配到的 队伍的 成员列表
            for (int i=0;i<UI.defenceTeamList.Count;i++)
            {
                if (nvsnModel.MatchedTeamInfo!=null
                    &&i < nvsnModel.MatchedTeamInfo.getTeamMemberInfos().Length)
                {
                    UI.defenceTeamList[i].icon.gameObject.SetActive(true);
                    UI.defenceTeamList[i].biangkuang.gameObject.SetActive(true);
                    UI.defenceTeamList[i].num.gameObject.SetActive(true);
                    PathUtil.Ins.SetHeadIcon(UI.defenceTeamList[i].icon, nvsnModel.MatchedTeamInfo.getTeamMemberInfos()[i].tplId);
                    /*
                    PathUtil.Ins.SetPetIconSource(UI.defenceTeamList[i].icon,
                        nvsnModel.MatchedTeamInfo.getTeamMemberInfos()[i].tplId);
                    */
                    string jobiconname = PetJobType.GetJobIconName(nvsnModel.MatchedTeamInfo.getTeamMemberInfos()[i].jobTypeId);
                    UI.defenceTeamList[i].biangkuang.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, jobiconname);
                    UI.defenceTeamList[i].num.text = "Lv."+nvsnModel.MatchedTeamInfo.getTeamMemberInfos()[i].level;
                }
                else
                {
                    UI.defenceTeamList[i].icon.gameObject.SetActive(false);
                    UI.defenceTeamList[i].biangkuang.gameObject.SetActive(false);
                    UI.defenceTeamList[i].num.gameObject.SetActive(false);
                }
            }
        }

        public void UpdateStatus(RMetaEvent e = null)
        {
            if (UI==null)
            {
                return;
            }
            switch (nvsnModel.CurrentNvsNStatus)
            {
                case (int)NvsNStatusDef.IDLE:
                    UI.pipeidaojishi.text = "空闲";
                    UI.zidongpipei.gameObject.SetActive(true);
                    UI.quxiaopipei.gameObject.SetActive(false);
                    UI.progressbar.MaxValue = totalTimer;
                    UI.progressbar.Value = 0;
                break;
                case (int)NvsNStatusDef.MATCHING:
                    UI.pipeidaojishi.text = "正在匹配";
                    if (rtimer==null)
                    {
                        rtimer = TimerManager.Ins.createTimer(pipeiIngJiange, totalTimer, onTimer, onEnd);
                        rtimer.start();
                    }
                    else
                    {
                        rtimer.Reset(pipeiIngJiange, totalTimer);
                        rtimer.Restart();
                    }
                    UI.zidongpipei.gameObject.SetActive(false);
                    UI.quxiaopipei.gameObject.SetActive(true);
                    UI.quxiaopipei.SetClickCallBack(stopPiPei);
                    if (!UI.quxiaopipei.IsInteractable())
                    {
                        ColorUtil.DeGray(UI.quxiaopipei);
                        UI.quxiaopipei.interactable = true;
                    }
                break;
                case (int)NvsNStatusDef.MATCHED:
                    UI.progressbar.MaxValue = totalTimer;
                    UI.progressbar.Value = totalTimer;
                    UI.pipeidaojishi.text = "倒计时" + totalTimer /1000+ "s";
                    if (rtimer == null)
                    {
                        rtimer = TimerManager.Ins.createTimer(pipeiSuccessJiange, totalTimer, onTimer, onEnd);
                        rtimer.start();
                    }
                    else
                    {
                        rtimer.Reset(pipeiSuccessJiange, totalTimer);
                        rtimer.Restart();
                    }
                    UI.zidongpipei.gameObject.SetActive(false);
                    UI.quxiaopipei.gameObject.SetActive(true);
                    UI.quxiaopipei.ClearClickCallBack();
                    if (UI.quxiaopipei.IsInteractable())
                    {
                        UI.quxiaopipei.interactable = false;
                        ColorUtil.Gray(UI.quxiaopipei);
                    }
                    
                break;
                case (int)NvsNStatusDef.NO_MATCHED:
                    UI.pipeidaojishi.text = "轮空";
                    UI.zidongpipei.gameObject.SetActive(false);
                    UI.quxiaopipei.gameObject.SetActive(false);
                    UI.progressbar.MaxValue = totalTimer;
                    UI.progressbar.Value = totalTimer;
                break;
            }
        }

        private void onTimer(RTimer r)
        {
            switch (nvsnModel.CurrentNvsNStatus)
            {
                case (int)NvsNStatusDef.IDLE:
                    UI.pipeidaojishi.text = "空闲";
                    break;
                case (int)NvsNStatusDef.MATCHING:
                    UI.pipeidaojishi.text = "正在匹配";
                    UI.progressbar.MaxValue = totalTimer;
                    UI.progressbar.Value = totalTimer-rtimer.getLeftTime();
                    break;
                case (int)NvsNStatusDef.MATCHED:
                    UI.pipeidaojishi.text = "倒计时" + TimeString.getTimeString(rtimer.getLeftTime() / 1000);
                    break;
                case (int)NvsNStatusDef.NO_MATCHED:
                    UI.pipeidaojishi.text = "轮空";
                    break;
            }
        }

        private void onEnd(RTimer r)
        {
            switch (nvsnModel.CurrentNvsNStatus)
            {
                case (int)NvsNStatusDef.IDLE:
                    UI.pipeidaojishi.text = "空闲";
                    break;
                case (int)NvsNStatusDef.MATCHING:
                    UI.pipeidaojishi.text = "正在匹配";
                    rtimer.Reset(pipeiIngJiange, totalTimer);
                    rtimer.Restart();
                    break;
                case (int)NvsNStatusDef.MATCHED:
                    UI.pipeidaojishi.text = "倒计时结束";
                    break;
                case (int)NvsNStatusDef.NO_MATCHED:
                    UI.pipeidaojishi.text = "轮空";
                    break;
            }
        }

        private void startPiPei()
        {
            NvnCGHandler.sendCGNvnStartMatch();
        }

        private void stopPiPei()
        {
            NvnCGHandler.sendCGNvnCancleMatch();
        }

        private void showinfo()
        {
            nvsnModel.OpenRuleWnd();
        }

        protected override void clickSpaceArea(UnityEngine.GameObject go)
        {
            //if (TeamModel.ins.hasTeam()&&TeamModel.ins.GetLeaderUUID().Equals(Human.Instance.Id))
            //{
            //    base.clickSpaceArea(go);
            //}
        }

        public override void hide(RMetaEvent e = null)
        {
            if (rtimer!=null)
            {
                rtimer.stop();
            }
            app.main.GameClient.ins.OnBigWndHidden();
            base.hide(e);
        }
        
        public override void Destroy()
        {
            nvsnModel.removeChangeEvent(NvsNModel.UPDATE_MYINFO, UpdateMyInfo);
            nvsnModel.removeChangeEvent(NvsNModel.UPDATE_RANKLIST, UpdateRankList);
            nvsnModel.removeChangeEvent(NvsNModel.UPDATE_MATCHEDTEAMINFO, UpdateMatchedTeamInfo);
            nvsnModel.removeChangeEvent(NvsNModel.UPDATE_STATUS, UpdateStatus);
            EventCore.removeRMetaEventListener(TeamModel.UPDATE_TEAM_LIST, UpdateMyTeamList);
            if (rtimer != null)
            {
                rtimer.stop();
                rtimer = null;
            }
            for (int i=0;paihangList!=null&&i<paihangList.Count;i++)
            {
                GameObject.DestroyImmediate(paihangList[i],true);
            }
            if(paihangList!=null)paihangList.Clear();
            paihangList = null;
            base.Destroy();
            UI = null;
        }
    }
}
