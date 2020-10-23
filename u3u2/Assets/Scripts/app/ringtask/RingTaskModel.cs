using app.net;
using app.human;
using app.confirm;

namespace app.ringtask
{
    public class RingTaskModel : AbsModel
    {
        public const string UPDATERING = "UPDATERING";
        public const string UPDATERINGTASKINFO = "UPDATERINGTASKINFO";
        public const int g_onehuancount = 10;

        private static RingTaskModel ins;
        public static RingTaskModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new RingTaskModel();
                }
                return ins;
            }
        }

        private GCOpenRingtaskPanel m_ringtaskinfo;
        public GCOpenRingtaskPanel RingTaskInfo
        {
            get
            {
                return m_ringtaskinfo;
            }
            set
            {
                m_ringtaskinfo = value;
                dispatchChangeEvent(UPDATERING, value);
            }
        }

        private QuestInfoData m_questinfo;
        public QuestInfoData QuestInfo
        {
            get
            {
                return m_questinfo;
            }
            set
            {
                m_questinfo = value;
                Human.Instance.QuestModel.updateOneQuest(m_questinfo);
                dispatchChangeEvent(UPDATERINGTASKINFO, value);
            }
        }

        public void LinkParse()
        {
            if (null != m_questinfo)
            {
                switch (m_questinfo.questStatus)
                {
                    case (int)QuestDefine.QuestStatus.CAN_ACCEPT:
                        ClickAccept();
                        break;
                    case (int)QuestDefine.QuestStatus.ACCEPTED:
                        //str = "马上去做" + npcdata.questIdList[i];
                        QuestModel.Ins.StartAutoQuest(m_questinfo);
                        break;
                    case (int)QuestDefine.QuestStatus.CAN_FINISH:
                        //完成环任务
                        RingtaskCGHandler.sendCGFinishRingtask();
                        break;
                    case (int)QuestDefine.QuestStatus.CAN_NOT_ACCEPT:
                        //str = "不可接" + npcdata.questIdList[i].ToString();
                        break;
                    case (int) QuestDefine.QuestStatus.GIVEUP:
                        ClickAccept();
                        break;
                }
            }
            else
            {
                ClickAccept();
            }
        }

        public void ClickAccept()
        {
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.HUANKAIQI, OKAccept, null);
        }

        public void OKAccept(RMetaEvent e)
        {
            //接受环任务
            RingtaskCGHandler.sendCGRingtaskAccept();
        }

        public override void Destroy()
        {
            ins = null;
        }
    }
}
