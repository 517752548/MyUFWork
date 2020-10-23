using app.db;
using app.net;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.yunliang
{
    public class YunLiangItemScript:BaseUI
    {
        public YunLiangItemUI UI;
        private BackupForageTaskInfoData infodata;
        private MoneyItemScript yajin;
        private MoneyItemScript jiangli;

        private bool hasAddModel;

        public YunLiangItemScript(YunLiangItemUI ui)
        {
            //initUILayer();
            UI = ui;
            mShowPos = ui.transform.localPosition;
            base.ui = ui.gameObject;
            UI.renwuBtn.SetClickCallBack(clickRenWuBtn);
            yajin = new MoneyItemScript(UI.yajin);
            jiangli = new MoneyItemScript(UI.jiangli);
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.FirstWND);
        }
        */
        public void setQuestData(BackupForageTaskInfoData questdatav)
        {
            infodata = questdatav;
            QuestTemplate qt = QuestTemplateDB.Instance.getTemplate(infodata.questId);
            UI.title.text = ColorUtil.getColorText(infodata.star,qt.title);
            UI.content.text = qt.desc;
            UI.gameObject.SetActive(true);

            ForageTaskRewardTemplate tpl = ForageTaskRewardTemplateDB.Instance.getTplByStar(infodata.star);
            //押金
            if (tpl != null)
            {
                yajin.SetMoney(tpl.depositType, tpl.deposit, true, false);
            }
            else
            {
                yajin.setEmpty();
            }
            //奖励
            if (tpl != null)
            {
                jiangli.SetMoney(tpl.rewardType1, tpl.rewardNum1, false, false);
            }
            else
            {
                jiangli.setEmpty();
            }
            //运粮车模型
            if (tpl != null)
            {
                if (!hasAddModel)
                {
                    hasAddModel = true;
                    AddAvatarModelToUI(new Vector3(22, -47, -105), new Vector3(12, 120, -30), Vector3.one*64, ClientConstantDef.YUNLIANGREN, UI.modelParent);
                }
                
                ShowAvatarModel();
            }
            //任务状态
            string str = "";
            switch (infodata.status)
            {
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                    str = "接受任务";
                    UI.renwuBtn.gameObject.SetActive(true);
                    UI.yifangqiTip.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    str = "放弃任务";
                    UI.renwuBtn.gameObject.SetActive(true);
                    UI.yifangqiTip.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    str = "完成任务";
                    UI.renwuBtn.gameObject.SetActive(true);
                    UI.yifangqiTip.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    str = "不可接";
                    UI.renwuBtn.gameObject.SetActive(true);
                    UI.yifangqiTip.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.FINISHED:
                    str = "已完成";
                    UI.renwuBtn.gameObject.SetActive(true);
                    UI.yifangqiTip.SetActive(false);
                    break;
                case (int)QuestDefine.QuestStatus.GIVEUP:
                    str = "已放弃";
                    UI.renwuBtn.gameObject.SetActive(false);
                    UI.yifangqiTip.SetActive(true);
                    break;
                default:
                    str = "";
                    UI.renwuBtn.gameObject.SetActive(false);
                    UI.yifangqiTip.SetActive(false);
                    break;
            }
            Text text = UI.renwuBtn.GetComponentInChildren<Text>();
            if (text != null) text.text = str;
        }

        private void clickRenWuBtn(GameObject go)
        {
            if (infodata == null)
            {
                return;
            }
            //任务状态
            switch (infodata.status)
            {
                case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                    //"接受任务";
                    ForageTaskRewardTemplate tpl = ForageTaskRewardTemplateDB.Instance.getTplByStar(infodata.star);
                    MoneyCheck.Ins.Check(tpl.depositType, tpl.deposit, sureAccept);
                    break;
                case (int)QuestDefine.QuestStatus.ACCEPTED:
                    //"放弃任务";
                    ForagetaskCGHandler.sendCGGiveUpForagetask();
                    break;
                case (int)QuestDefine.QuestStatus.CAN_FINISH:
                    //"完成任务";
                    ForagetaskCGHandler.sendCGFinishForagetask();
                    break;
                case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                    //"不可接";
                    break;
                default:
                    break;
            }
        }

        private void sureAccept(RMetaEvent e)
        {
            ForagetaskCGHandler.sendCGForagetaskAccept(infodata.questId);
            WndManager.Ins.close(GlobalConstDefine.YunLiangView_Name);
        }

        public override void Destroy()
        {
            infodata = null;
            RemoveAvatarModel();
            if (yajin != null)
            {
                yajin.Destroy();
                yajin = null;
            }
            if (jiangli != null)
            {
                jiangli.Destroy();
                jiangli = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}
