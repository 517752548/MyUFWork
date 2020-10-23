using System.Collections;
using System.Collections.Generic;
using app.human;
using app.net;
using app.tips;
using app.zone;
using UnityEngine;
using app.confirm;

namespace app.jingjichang
{
    public class JingJiChangView : BaseWnd
    {
        //[Inject(ui = "JingJiChangUI")]
        //public GameObject ui;

        public JingJiChangUI UI;

        public JingJiChangModel jingjichangModel;

        private MoneyItemScript rongyuValue;
        private MoneyItemScript clearCDCost;
        private RTimer waitTimer;
        private List<JingJiChangItemUI> tiaozhanList;
        private List<JingJiChangZhanBaoItemUI> zhanbaoList;
        
        private Coroutine mUpdateTiaoZhanListCoroutine = null;

        public JingJiChangView()
        {
            uiName = "JingJiChangUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            jingjichangModel = JingJiChangModel.Ins;
            jingjichangModel.addChangeEvent(JingJiChangModel.UpdateJingJiChangPanel, updatePanel);
            jingjichangModel.addChangeEvent(JingJiChangModel.UpdateChallengeTimes, updateChallengeTimes);
            jingjichangModel.addChangeEvent(JingJiChangModel.UpdateZhanBao, updateZhanBao);
            jingjichangModel.addChangeEvent(JingJiChangModel.RemoveCd, RemoveCd);

            UI = ui.AddComponent<JingJiChangUI>();
            UI.Init();
            UI.defaultItemUI.gameObject.SetActive(false);
            UI.zhanbaoGo.SetActive(false);
            UI.defaultZhanbaoItem.gameObject.SetActive(false);

            UI.closeBtn.SetClickCallBack(clickClose);
            rongyuValue = new MoneyItemScript(UI.rongyu);
            UI.addBtn.SetClickCallBack(addTiaozhanCishu);
            UI.guizeBtn.SetClickCallBack(clickGuize);
            UI.zhanbaoBtn.SetClickCallBack(clickZhanBao);
            UI.paimingJiangliBtn.SetClickCallBack(clickJiangli);
            UI.paihangbangBtn.SetClickCallBack(clickPaiHangBang);

            UI.qingchuBtn.SetClickCallBack(clickQingchuCD);
            clearCDCost = new MoneyItemScript(UI.qingchuCost);
            UI.shuxinBtn.SetClickCallBack(shuaxin);
            UI.zhanbaoClose.SetClickCallBack(closeZhanbao);
        }

        private void shuaxin()
        {
            ArenaCGHandler.sendCGArenaRefreshOpponent();
        }

        public void updateZhanBao(RMetaEvent e)
        {
            UI.zhanbaoGo.SetActive(true);
            if (zhanbaoList == null)
            {
                zhanbaoList = new List<JingJiChangZhanBaoItemUI>();
            }
            int zhanbaoLen = jingjichangModel.ZhanbaoInfo.getArenaReportHistoryList().Length;
            for (int i = 0; i < zhanbaoLen; i++)
            {
                if (i >= zhanbaoList.Count)
                {
                    JingJiChangZhanBaoItemUI item = GameObject.Instantiate(UI.defaultZhanbaoItem);
                    item.name = "zhanbaoItem_" + i;
                    item.gameObject.transform.SetParent(UI.zhanbaoGrid.transform);
                    item.gameObject.SetActive(true);
                    item.transform.localScale = Vector3.one;
                    zhanbaoList.Add(item);
                }
                ArenaReportHistoryData arenaData = jingjichangModel.ZhanbaoInfo.getArenaReportHistoryList()[i];
                if (arenaData.isWin == 1)
                {
                    zhanbaoList[i].shengli.gameObject.SetActive(true);
                    zhanbaoList[i].shibai.gameObject.SetActive(false);

                    zhanbaoList[i].shangsheng.gameObject.SetActive(true);
                    zhanbaoList[i].xiajiang.gameObject.SetActive(false);
                    zhanbaoList[i].bianhuaText.text = arenaData.rankDelta.ToString();
                }
                else
                {
                    zhanbaoList[i].shengli.gameObject.SetActive(false);
                    zhanbaoList[i].shibai.gameObject.SetActive(true);

                    zhanbaoList[i].shangsheng.gameObject.SetActive(false);
                    zhanbaoList[i].xiajiang.gameObject.SetActive(true);
                    zhanbaoList[i].bianhuaText.text = arenaData.rankDelta.ToString();
                }
                //排名变化
                if (arenaData.rankDelta == 0)
                {
                    zhanbaoList[i].shangsheng.gameObject.SetActive(false);
                    zhanbaoList[i].xiajiang.gameObject.SetActive(false);
                    zhanbaoList[i].bianhuaText.text = "";
                }
                zhanbaoList[i].dengji.text = "Lv." + arenaData.targetLevel;
                zhanbaoList[i].mingzi.text = arenaData.targetName;
                zhanbaoList[i].shijian.text = TimeString.getDayTimeString((int)((jingjichangModel.ZhanbaoInfo.getCurTime() - arenaData.reportTime) / 1000)) + " 前";
                //PathUtil.Ins.SetPetIconSource(zhanbaoList[i].headIcon,arenaData.targetTplId);
                PathUtil.Ins.SetHeadIcon(zhanbaoList[i].headIcon, arenaData.targetTplId);
            }
            //删除多余
            for (int i = zhanbaoLen; i < zhanbaoList.Count; i++)
            {
                GameObject.DestroyImmediate(zhanbaoList[i].gameObject, true);
                zhanbaoList[i] = null;
            }
            zhanbaoList.RemoveRange(zhanbaoLen, zhanbaoList.Count - zhanbaoLen);
        }

        private void closeZhanbao()
        {
            UI.zhanbaoGo.SetActive(false);
        }

        private void clickGuize()
        {
            PopInfoWnd.Ins.ShowInfo("1.每晚21点整,根据竞技场的排名发放奖励,通过邮件发放\n" +
                "2.若战斗胜利,且防守方排名高于进攻方,则将双方的排名对调\n" +
                "3.若进攻方超过规定回合数战斗,则防守方胜利\n" +
                "4.每天可以免费发起战斗10次,每日24点重置挑战次数\n" +
                "5.挑战对手失败,将有5分钟的冷却时间\n" +
                "6.正在进行战斗的敌人,无法被选作对手", LangConstant.TISHI, TextAnchor.MiddleLeft, 550);
        }

        private void clickZhanBao()
        {
            ArenaCGHandler.sendCGArenaBattleRecord();
        }

        private void clickJiangli()
        {
            ArenaCGHandler.sendCGArenaRankRewardList();
        }

        private void clickPaiHangBang()
        {
            WndManager.open(GlobalConstDefine.PaiHangBangView_Name, WndParam.CreateWndParam(WndParam.SelectTab, PaiHangBangType.JINGJICHANG));
        }

        private void clickQingchuCD()
        {
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,jingjichangModel.PanelInfo.getKillCdCost(),sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {
            ArenaCGHandler.sendCGArenaKillCd();
        }

        private void addTiaozhanCishu()
        {
            //购买挑战次数
            if (jingjichangModel.PanelInfo.getCanBuyChallengeTimes() == 1)
            {
                ConfirmWnd.Ins.ShowConfirm("购买挑战次数", "是否花费" +
                    jingjichangModel.PanelInfo.getBuyChallengeTimesCost() +
                    "金子 增加5次挑战\n", sureBuyCiShu);
                //今日还有N次购买机会
                //可购买
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("不可购买挑战次数!");
            }
        }

        private void sureBuyCiShu(RMetaEvent e)
        {
            MoneyCheck.Ins.Check(CurrencyTypeDef.BOND, jingjichangModel.PanelInfo.getBuyChallengeTimesCost(), (RMetaEvent ) =>
            {
                ArenaCGHandler.sendCGArenaBuyChallengeTime();    
            });
        }


        private void clickClose()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            updatePanel();
            updateChallengeTimes();
            app.main.GameClient.ins.OnBigWndShown();
        }

        public void RemoveCd(RMetaEvent e = null)
        {
            //能挑战
            UI.dengdaiObj.SetActive(false);
            UI.qingchuBtn.gameObject.SetActive(false);
            UI.shuxinBtn.gameObject.SetActive(true);
            if (waitTimer != null)
            {
                waitTimer.stop();
            }
        }

        public void updatePanel(RMetaEvent e = null)
        {
            UI.roleName.text = Human.Instance.getName();
            UI.levelText.text = "Lv." + Human.Instance.getLevel();
            UI.zhanliText.text = "战斗力：" + Human.Instance.PetModel.getLeader().getFightPower();

            //TODO:荣誉值
            UI.rongyu.gameObject.SetActive(false);
            //rongyuValue.SetData();
            if (avatarBase == null)
            {
                AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), UI.modelContainer);
            }
            ShowAvatarModel();
            Human.Instance.updateSelfWeapon(avatarBase);
            //我的排名
            UI.paiming.text = "当前排名: " + jingjichangModel.PanelInfo.getRank();
            //等待cd
            if (jingjichangModel.PanelInfo.getCanChallenge() == 1)
            {
                //能挑战
                RemoveCd();
            }
            else
            {
                //不能挑战
                if (jingjichangModel.PanelInfo.getChallengeCdTime() > 0)
                {
                    //有cd
                    UI.dengdaiObj.SetActive(true);
                    UI.qingchuBtn.gameObject.SetActive(true);
                    UI.shuxinBtn.gameObject.SetActive(false);
                    clearCDCost.SetMoney(CurrencyTypeDef.GOLD, jingjichangModel.PanelInfo.getKillCdCost(), true, false);
                    if (waitTimer == null)
                    {
                        waitTimer = TimerManager.Ins.createTimer(1000, jingjichangModel.PanelInfo.getChallengeCdTime(),
                            onDoTimer, onTimerEnd);
                        waitTimer.start();
                    }
                    else
                    {
                        waitTimer.Reset(1000, jingjichangModel.PanelInfo.getChallengeCdTime());
                        waitTimer.Restart();
                    }
                }
                else
                {
                    //无cd
                    UI.dengdaiObj.SetActive(false);
                    UI.qingchuBtn.gameObject.SetActive(false);
                    UI.shuxinBtn.gameObject.SetActive(true);
                    if (waitTimer != null)
                    {
                        waitTimer.stop();
                    }
                }
            }
            //刷新挑战列表
            if (mUpdateTiaoZhanListCoroutine != null)
            {
                UI.StopCoroutine(mUpdateTiaoZhanListCoroutine);
                mUpdateTiaoZhanListCoroutine = null;
            }
            
            mUpdateTiaoZhanListCoroutine = UI.StartCoroutine(UpdateTiaoZhanList());
        }

        private void onDoTimer(RTimer r)
        {
            UI.dengdaiText.text = TimeString.getTimeFormat(r.getLeftTime() / 1000);
        }

        public override void hide(RMetaEvent e = null)
        {
            if (waitTimer != null)
            {
                waitTimer.stop();
            }
            HideAvatarModel();
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private void onTimerEnd(RTimer r)
        {
            ArenaCGHandler.sendCGShowArenaPanel();
        }

        public void updateChallengeTimes(RMetaEvent e = null)
        {
            //挑战次数
            UI.cishuText.text = jingjichangModel.CurChallengeTimes.ToString();
        }

        private IEnumerator UpdateTiaoZhanList()
        {
            if (tiaozhanList == null)
            {
                tiaozhanList = new List<JingJiChangItemUI>();
            }
            int challengeLen = jingjichangModel.PanelInfo.getArenaChallengeList().Length;
            for (int i = 0; i < challengeLen; i++)
            {
                if (i >= tiaozhanList.Count)
                {
                    JingJiChangItemUI item = GameObject.Instantiate(UI.defaultItemUI);
                    item.name = "tiaozhanItem_" + i;
                    item.gameObject.transform.SetParent(UI.memberGrid.transform);
                    item.gameObject.SetActive(true);
                    item.transform.localScale = Vector3.one;
                    tiaozhanList.Add(item);
                }
                ArenaMemberData arenaData = jingjichangModel.PanelInfo.getArenaChallengeList()[i];
                tiaozhanList[i].paimingText.text = arenaData.rank.ToString();
                //PathUtil.Ins.SetPetIconSource(tiaozhanList[i].headIcon,arenaData.tplId);
                PathUtil.Ins.SetHeadIcon(tiaozhanList[i].headIcon, arenaData.tplId);
                tiaozhanList[i].roleName.text = arenaData.name;
                tiaozhanList[i].dengji.text = "Lv." + arenaData.level;
                //if (arenaData.isRobot == 1)
                //{
                //    //机器人
                //    tiaozhanList[i].zhanli.text = "我是机器人";
                //}
                //else
                //{
                //    //玩家
                    tiaozhanList[i].zhanli.text = "战力：" + arenaData.fightPower;
                //}
                tiaozhanList[i].tiaozhanBtn.SetClickCallBack(clickTiaoZhanBtn);
                yield return 0;
            }
            //删除多余
            for (int i = challengeLen; i < tiaozhanList.Count; i++)
            {
                GameObject.DestroyImmediate(tiaozhanList[i].gameObject, true);
                tiaozhanList[i] = null;
            }
            tiaozhanList.RemoveRange(challengeLen, tiaozhanList.Count - challengeLen);

            GuideManager.Ins.ShowGuide(GuideIdDef.JingJiChang,3,tiaozhanList[0].tiaozhanBtn.gameObject);
            
            mUpdateTiaoZhanListCoroutine = null;
        }

        private void clickTiaoZhanBtn(GameObject go)
        {
            for (int i = 0; tiaozhanList != null && i < tiaozhanList.Count; i++)
            {
                if (tiaozhanList[i].tiaozhanBtn.gameObject == go)
                {
                    ArenaCGHandler.sendCGArenaAttackOpponent(i + 1);
                    return;
                }
            }
            ClientLog.LogError("cannot find tiaozhanBtn in List:" + go.name);
        }

        public override void Destroy()
        {
            RemoveAvatarModel();
            
            jingjichangModel.removeChangeEvent(JingJiChangModel.UpdateJingJiChangPanel, updatePanel);
            jingjichangModel.removeChangeEvent(JingJiChangModel.UpdateChallengeTimes, updateChallengeTimes);
            jingjichangModel.removeChangeEvent(JingJiChangModel.UpdateZhanBao, updateZhanBao);
            jingjichangModel.removeChangeEvent(JingJiChangModel.RemoveCd, RemoveCd);
            if (rongyuValue != null)
            {
                rongyuValue.Destroy();
                rongyuValue = null;
            }

            if (clearCDCost != null)
            {
                clearCDCost.Destroy();
                clearCDCost = null;
            }

            if (waitTimer != null)
            {
                waitTimer.stop();
                waitTimer = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}
