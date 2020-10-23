using app.human;
using app.net;
using app.zone;

namespace app.yunliang
{
    public class YunLiangModel:AbsModel
    {
        public const string updateYunLiangPanel = "updateYunLiangPanel";
        public const string updateOneYunLiang = "updateOneYunLiang";

        private GCOpenForagetaskPanel panelData;
        public QuestInfoData currentQuestData;

        public YunLiangModel()
        {
            addListener();
        }
        private static YunLiangModel _ins;
        public static YunLiangModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(YunLiangModel)) as YunLiangModel;
                    _ins = new YunLiangModel();
                }
                return _ins;
            }
        }
        public GCOpenForagetaskPanel PanelData
        {
            get { return panelData; }
        }

        private void addListener()
        {

        }

        public void GCOpenForagetaskPanelHandler(GCOpenForagetaskPanel msg)
        {
            panelData = msg;
            if(WndManager.Ins.IsWndShowing(typeof(YunLiangView)))
            {
                dispatchChangeEvent(updateYunLiangPanel, null);
            }
            else
            {
                if (Human.Instance.PlayerModel.isLoginFinished)
                {
                    WndManager.open(GlobalConstDefine.YunLiangView_Name);
                }
            }
        }

        public void GCForagetaskDoneHandler(GCForagetaskDone msg)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("今日运粮任务已完成，请明日再来！");
        }

        public void GCForagetaskUpdateHandler(GCForagetaskUpdate msg)
        {
            if (panelData!=null)
            {
                foreach (BackupForageTaskInfoData info in panelData.getBackupForageTaskInfos())
                {
                    if (info.questId == msg.getQuestInfo().questId)
                    {
                        info.status = msg.getQuestInfo().questStatus;
                        break;
                    }
                }
            }
            currentQuestData = msg.getQuestInfo();
            Human.Instance.QuestModel.updateOneQuest(msg.getQuestInfo());
            dispatchChangeEvent(updateOneYunLiang, msg);
            Human.Instance.UpdatePlayerModel();
        }

        public bool isYunLiangIng()
        {
            QuestInfoData yunliangQuest = currentQuestData;
            if (yunliangQuest != null && ((yunliangQuest.questStatus == (int) QuestDefine.QuestStatus.CAN_FINISH)
                ||(yunliangQuest.questStatus == (int) QuestDefine.QuestStatus.ACCEPTED)))
            {
                return true;
            }
            return false;
        }
        
        public override void Destroy()
        {
            panelData = null;
            currentQuestData = null;
            _ins = null;
        }
    }
}

