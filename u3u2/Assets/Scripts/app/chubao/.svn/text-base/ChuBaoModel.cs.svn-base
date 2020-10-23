using app.human;
using app.net;

namespace app.chubao
{
    public class ChuBaoModel:AbsModel
    {
        private GCOpenThesweeneytaskPanel panelData;
        public QuestInfoData currentQuestData;
        public bool hasFinishedChuBao;

        private static ChuBaoModel _ins;
        public static ChuBaoModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ChuBaoModel();
                }
                return _ins;
            }
        }

        public GCOpenThesweeneytaskPanel PanelData
        {
            get { return panelData; }
        }

        public void GCOpenThesweeneytaskPanel(GCOpenThesweeneytaskPanel msg)
        {
            panelData = msg;
            hasFinishedChuBao = (panelData.getFinishTimes() >= panelData.getTotalTimes());
            //ClientLog.LogError("更新除暴任务次数："+msg.getFinishTimes()+" / "+msg.getTotalTimes());
        }

        public void GCThesweeneytaskDone(GCThesweeneytaskDone msg)
        {
            hasFinishedChuBao = true;
            //ClientLog.LogError("除暴任务全部做完！");
        }

        public void GCThesweeneytaskUpdate(GCThesweeneytaskUpdate msg)
        {
            currentQuestData = msg.getQuestInfo();
            //if (currentQuestData.questStatus==(int)QuestDefine.QuestStatus.ACCEPTED)
            //{
            //    ClientLog.LogError("接受除暴任务：" + currentQuestData.questId);
            //}
            //else if (currentQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
            //{
            //    ClientLog.LogError("可提交除暴任务：" + currentQuestData.questId);
            //}
            //else if (currentQuestData.questStatus == (int)QuestDefine.QuestStatus.FINISHED)
            //{
            //    ClientLog.LogError("已完成除暴任务：" + currentQuestData.questId);
            //}
            Human.Instance.QuestModel.updateOneQuest(msg.getQuestInfo());
        }

        public override void Destroy()
        {
            panelData=null;
            currentQuestData=null;
            hasFinishedChuBao=false;
            _ins = null;
        }
    }
}
