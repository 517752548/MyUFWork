using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using app.role;
using app.zone;
using app.pet;

namespace app.model
{
    public class ShengChanModel : AbsModel
    {
        //我能开采的矿
        private List<LifeSkillMineTemplate> myKuang;
        private int myCaiKuangLevel = -1;

        private List<LifeSkillMineMinerTemplate> AIList;
        /// <summary>
        /// 采矿时间段 列表
        /// </summary>
        private List<LifeSkillMineCostTemplate> timeList;
        /// <summary>
        /// 我的当前的矿 信息
        /// </summary>
        private GCLsMineGetPannel currentKuangs;

        public const string UPDATE_KUANG = "UPDATE_KUANG";
        public static int MAX_KUANG_DIAN_NUM = 4;

        private PlayerDataList kuangdianDataList;

        public ShengChanModel()
        {
            init();
        }
        private static ShengChanModel _ins;
        public static ShengChanModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ShengChanModel();
                }
                return _ins;
            }
        }
        private void init()
        {
            kuangdianDataList = PlayerDataManager.Ins.GetPlayerDataList(PlayerDataKeyDef.KUANGDIAN_DATA);
        }
        /// <summary>
        /// 我的当前的矿 信息
        /// </summary>
        public GCLsMineGetPannel CurrentKuangs
        {
            get { return currentKuangs; }
            set
            {
                currentKuangs = value;
                if (!WndManager.Ins.IsWndShowing(GlobalConstDefine.ShengChanView_Name))
                {
                    WndManager.open(GlobalConstDefine.ShengChanView_Name);
                }
                else
                {
                    dispatchChangeEvent(UPDATE_KUANG, null);
                }
            }
        }

        /// <summary>
        /// 获得我的采矿等级
        /// </summary>
        /// <returns></returns>
        public int GetMyCaiKuangLevel()
        {
            Pet leader = Human.Instance.PetModel.getLeader();
            int caikuangLevel = leader.PropertyManager.getPetIntProp(RoleBaseIntProperties.CAIKUANG_LEVEL);
            caikuangLevel = 1;
            return caikuangLevel;
        }
        /// <summary>
        /// 获得我能开采的矿
        /// </summary>
        /// <returns></returns>
        public List<LifeSkillMineTemplate> GetMyKuang()
        {
            int currentKuangLevel = GetMyCaiKuangLevel();
            if (myKuang == null || myCaiKuangLevel != currentKuangLevel)
            {
                myCaiKuangLevel = currentKuangLevel;
                if (myKuang != null) myKuang.Clear();
                //更新我能挖的矿列表
                myKuang = LifeSkillMineTemplateDB.Instance.GetMyKuangList(myCaiKuangLevel);
            }
            return myKuang;
        }
        /// <summary>
        /// 获得我开启的矿点数
        /// </summary>
        /// <returns></returns>
        public int GetMyKuangDianNum()
        {
            int mylevel = GetMyCaiKuangLevel();
            return LifeSkillMinePitTemplateDB.Instance.GetOpenKuangDianNum(mylevel);
        }
        /// <summary>
        /// 获得所有的采矿时间段 列表
        /// </summary>
        /// <returns></returns>
        public List<LifeSkillMineCostTemplate> GetTimeList()
        {
            if (timeList == null)
            {
                timeList = new List<LifeSkillMineCostTemplate>();
                Dictionary<int, LifeSkillMineCostTemplate> dic = LifeSkillMineCostTemplateDB.Instance.getIdKeyDic();
                foreach (KeyValuePair<int, LifeSkillMineCostTemplate> pair in dic)
                {
                    timeList.Add(pair.Value);
                }
            }
            return timeList;
        }

        public bool IsKuangGongUsed(long kuanggonguuid)
        {
            int len = CurrentKuangs.getPitList().Length;
            for (int i = 0; i < len; i++)
            {
                if (currentKuangs.getPitList()[i].endTime > currentKuangs.getServerTime())
                {
                    //正在进行
                    if (currentKuangs.getPitList()[i].minerId == kuanggonguuid)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获得所有的AI
        /// </summary>
        /// <returns></returns>
        public List<LifeSkillMineMinerTemplate> GetAIList()
        {
            if (AIList == null)
            {
                AIList = LifeSkillMineMinerTemplateDB.Instance.GetAllAI();
            }
            return AIList;
        }

        public void GCLsMineStartHandler(GCLsMineStart msg)
        {
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("挖矿开始!");
            }
        }

        public void GCLsMineGainHandler(GCLsMineGain msg)
        {
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("收取成功!");
            }
        }

        /// <summary>
        /// 保存矿点信息
        /// </summary>
        /// <param name="kuangdianId"></param>
        /// <param name="selectLeiBieId"></param>
        /// <param name="selectTimeId"></param>
        /// <param name="selectKuangGongId"></param>
        public void SaveKuangDianData(int kuangdianId, int selectLeiBieId, int selectTimeId, long selectKuangGongId)
        {
            if ((kuangdianDataList.List == null) || (kuangdianDataList.List != null && kuangdianDataList.List.Count == 0))
            {
                foreach (KeyValuePair<int, LifeSkillMinePitTemplate> pair in LifeSkillMinePitTemplateDB.Instance.getIdKeyDic())
                {
                    PlayerData playerdata = new PlayerData();
                    playerdata.addData(PlayerDataKeyDef.KUANGDIAN_DATA_ID, pair.Key.ToString());
                    playerdata.addData(PlayerDataKeyDef.KUANGDIAN_DATA_KUANGGONG, "");
                    playerdata.addData(PlayerDataKeyDef.KUANGDIAN_DATA_LEIBIE, "");
                    playerdata.addData(PlayerDataKeyDef.KUANGDIAN_DATA_TIME, "");
                    kuangdianDataList.addData(playerdata);
                }
            }
            bool find = false;
            for (int i = 0; i < MAX_KUANG_DIAN_NUM; i++)
            {
                PlayerData pd = kuangdianDataList.List[i];
                if (int.Parse(pd.getData(PlayerDataKeyDef.KUANGDIAN_DATA_ID)) == kuangdianId)
                {
                    pd.addData(PlayerDataKeyDef.KUANGDIAN_DATA_KUANGGONG, selectKuangGongId.ToString());
                    pd.addData(PlayerDataKeyDef.KUANGDIAN_DATA_LEIBIE, selectLeiBieId.ToString());
                    pd.addData(PlayerDataKeyDef.KUANGDIAN_DATA_TIME, selectTimeId.ToString());
                    PlayerDataManager.Ins.SaveDataList(PlayerDataKeyDef.KUANGDIAN_DATA, kuangdianDataList);
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                ClientLog.LogError("矿点id不存在！ " + kuangdianId + "  最大矿点数 MAX_KUANG_DIAN_NUM：" + MAX_KUANG_DIAN_NUM);
            }
        }
        /// <summary>
        /// 获得矿点的缓存记录
        /// </summary>
        /// <param name="kuangDianId"></param>
        /// <returns></returns>
        public PlayerData GetSavedKuangDianData(int kuangDianId)
        {
            for (int i = 0; kuangdianDataList != null && kuangdianDataList.List != null && i < kuangdianDataList.List.Count; i++)
            {
                PlayerData pd = kuangdianDataList.List[i];
                if (int.Parse(pd.getData(PlayerDataKeyDef.KUANGDIAN_DATA_ID)) == kuangDianId)
                {
                    return pd;
                }
            }
            return null;
        }

        public override void Destroy()
        {
            if (myKuang != null)
            {
                //数据库引用不能清空
                //myKuang.Clear();
                myKuang = null;
            }
            myCaiKuangLevel = -1;
            if (AIList != null)
            {
                //数据库 引用不能清空
                //AIList.Clear();
                AIList = null;
            }
            if (timeList != null)
            {
                timeList.Clear();
                timeList = null;
            }
            currentKuangs = null;
            kuangdianDataList = null;
            init();
            _ins = null;
        }
    }
}
