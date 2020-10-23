using app.human;
using app.net;

namespace app.jiuguan
{
    public class JiuGuanRenWuModel:AbsModel
    {
        public const string updateJiuGuanRenWuPanel = "updateJiuGuanRenWuPanel";
        public const string updateOneJiuGuanRenWu = "updateOneJiuGuanRenWu";

        private GCOpenPubtaskPanel panelData;
        public QuestInfoData currentQuestData;
        private int _curMaxPubStar;

        public JiuGuanRenWuModel()
        {
            addListener();
        }
        private static JiuGuanRenWuModel _ins;
        public static JiuGuanRenWuModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new JiuGuanRenWuModel();
                }
                return _ins;
            }
        }
        public GCOpenPubtaskPanel PanelData
        {
            get { return panelData; }
        }

        public int CurMaxPubStar
        {
            get { return _curMaxPubStar; }
            set { _curMaxPubStar = value; }
        }

        private void addListener()
        {
        }
        
        public void GCOpenPubtaskPanel(GCOpenPubtaskPanel msg)
        {
            panelData = msg;
            if(WndManager.Ins.IsWndShowing(typeof(JiuGuanRenWuView)))
            {
                dispatchChangeEvent(updateJiuGuanRenWuPanel, null);
            }
            else
            {
                if (Human.Instance.PlayerModel.isLoginFinished)
                {
                    WndManager.open(GlobalConstDefine.JiuGuanRenWuView_Name);
                }
            }
        }
        public void GCPubtaskDone(GCPubtaskDone msg)
        {
            
        }
        public void GCPubtaskUpdate(GCPubtaskUpdate msg)
        {
            if (panelData!=null)
            {
                foreach (BackupPubTaskInfo info in panelData.getBackupPubTaskInfos())
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
            dispatchChangeEvent(updateOneJiuGuanRenWu,msg);
        }
        
        public override void Destroy()
        {
            panelData = null;
            currentQuestData = null;
            _ins = null;
        }
    }
}
