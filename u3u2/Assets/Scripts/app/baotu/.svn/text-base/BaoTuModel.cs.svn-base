using app.human;
using app.net;

namespace app.baotu
{
    public class BaoTuModel:AbsModel
    {
        private GCOpenTreasuremapPanel panelData;
        public QuestInfoData currentQuestData;
        public bool hasFinishedBaoTu;
        
        private static BaoTuModel _ins = null;
        
        public static BaoTuModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(BaoTuModel)) as BaoTuModel;
                    _ins = new BaoTuModel();
                }
                return _ins;
            }
        }

        public BaoTuModel()
        {
            addListener();
        }

        public GCOpenTreasuremapPanel PanelData
        {
            get { return panelData; }
        }

        private void addListener()
        {
        }

        public void GCOpenTreasuremapPanel(GCOpenTreasuremapPanel msg)
        {
            panelData = msg;
            hasFinishedBaoTu = (panelData.getFinishTimes() >= panelData.getTotalTimes());
            //ClientLog.LogError("更新宝图任务次数：" + msg.getFinishTimes() + " / " + msg.getTotalTimes());
        }

        public void GCTreasuremapDone(GCTreasuremapDone msg)
        {
            hasFinishedBaoTu = true;
            //ClientLog.LogError("宝图任务全部做完！");
        }

        public void GCTreasuremapUpdate(GCTreasuremapUpdate msg)
        {
            currentQuestData = msg.getQuestInfo();
            //if (currentQuestData.questStatus == (int)QuestDefine.QuestStatus.ACCEPTED)
            //{
            //    ClientLog.LogError("接受宝图任务：" + currentQuestData.questId);
            //}
            //else if (currentQuestData.questStatus == (int)QuestDefine.QuestStatus.CAN_FINISH)
            //{
            //    ClientLog.LogError("可提交宝图任务：" + currentQuestData.questId);
            //}
            //else if (currentQuestData.questStatus == (int)QuestDefine.QuestStatus.FINISHED)
            //{
            //    ClientLog.LogError("已完成宝图任务：" + currentQuestData.questId);
            //}
            Human.Instance.QuestModel.updateOneQuest(msg.getQuestInfo());
        }

        public override void Destroy()
        {
            panelData=null;
            currentQuestData=null;
            hasFinishedBaoTu=false;
            _ins = null;
        }
    }
}
