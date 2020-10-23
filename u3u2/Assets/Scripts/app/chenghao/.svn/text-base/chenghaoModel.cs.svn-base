using System.Linq;
using app.net;
using app.zone;
using app.human;

namespace app.chenghao
{
    public class ChenghaoModel : AbsModel
    {
        public const string UPDATE_CHENGHAO = "UPDATE_CHENGHAO";

        private static ChenghaoModel mChenghaoModel;
        public static ChenghaoModel Ins
        {
            get
            {
                if (mChenghaoModel == null)
                {
                    mChenghaoModel = new ChenghaoModel();
                }
                return mChenghaoModel;
            }
        }

        private int m_nCHshow;
        private int m_nCHTepid = -1;
        private string m_chname;
        /// <summary>
        /// 称号信息
        /// </summary>
        private TitleInfo[] m_arrTitleInfo;
        public string chenghaoName
        {
            get
            {
                return m_chname;
            }
        }
        public int NCHTepid
        {
            get
            {
                return m_nCHTepid;
            }
            set
            {
                m_nCHTepid = value;
            }
        }

        public int NCHshow
        {
            get
            {
                return m_nCHshow;
            }
            set
            {
                m_nCHshow = value;
            }
        }

        public TitleInfo[] ArrTitleInfo
        {
            get
            {
                return m_arrTitleInfo;
            }
            set
            {
                m_arrTitleInfo = value;
            }
        }

        public void OpenChenghaoPanel()
        {
            TitleCGHandler.sendCGTitlePanel();
        }

        public void GCTitlePanelHandler(GCTitlePanel msg)
        {
            LinkParse.Ins.linkToFunc(FunctionIdDef.CHENGHAO);
            m_arrTitleInfo = msg.getTitleList();
            dispatchChangeEvent(UPDATE_CHENGHAO,m_arrTitleInfo);
        }


        /// <summary>
        /// 数值变化时候 更新状态
        /// </summary>
        public void UpdateState()
        {
            int show = Human.Instance.getShowChenghao();
            int id = Human.Instance.getChenghao();
            string name = Human.Instance.getChenghaoName();
            if (m_chname != name || NCHshow != show)
            {
                m_nCHTepid = id;
                NCHshow = show;
                m_chname = name;
                //值变化了 才需要更新界面 (更新场景中的名字)
                ZoneCharacter player = ZoneCharacterManager.ins.self;
                if (player != null)
                {
					//player.ChenckChenghao(show, name);
					if (show == 1)
                    {
						player.title = name;
					}
                    else
                    {
						player.title = "";
					}
                }
                dispatchChangeEvent(UPDATE_CHENGHAO, m_arrTitleInfo);
            }
        }

        public override void Destroy()
        {
            m_nCHshow=0;
            m_nCHTepid = -1;
            m_chname=null;

            if (m_arrTitleInfo!=null)
            {
                m_arrTitleInfo.ToList().Clear();
            }
            m_arrTitleInfo = null;
            if (ArrTitleInfo!=null)
            {
                ArrTitleInfo.ToList().Clear();
            }
            ArrTitleInfo = null;
            mChenghaoModel = null;
            
        }
    }

}