using System.Collections.Generic;
using System.Linq;
using app.net;
using app.paihang;

public class PaiHangModel:AbsModel
{
    public const string UPDATE_PAIHANG_lIST = "UPDATE_PAIHANG_lIST";

    private Dictionary<int, GCRankApply> rankDic;
    private static PaiHangModel _ins;
    public static PaiHangModel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new PaiHangModel();
            }
            return _ins;
        }
    }
    public void updateRankDic(GCRankApply rankData)
    {
        if (rankDic==null)
        {
            rankDic = new Dictionary<int, GCRankApply>();
        }
        if (rankDic.ContainsKey(rankData.getRankType()))
        {
            GCRankApply hasRank=null;
            rankDic.TryGetValue(rankData.getRankType(),out hasRank);
            if (hasRank!=null)
            {
                if (hasRank.getTimeId()==rankData.getTimeId())
                {
                    //用老的数据
                }
                else
                {
                    rankDic[rankData.getRankType()] = rankData;   
                }
            }
            else
            {
                rankDic.Add(rankData.getRankType(), rankData);
            }
        }
        else
        {
            rankDic.Add(rankData.getRankType(),rankData);
        }
        if (WndManager.Ins.IsWndShowing(typeof(PaiHangBangView)))
        {
            //更新界面
            dispatchChangeEvent(UPDATE_PAIHANG_lIST,rankData.getRankType());
        }
    }

    public void dispatchUpdateEvent()
    {
        dispatchChangeEvent(UPDATE_PAIHANG_lIST,null);
    }

    public List<RankInfo> GetRankListByType(int rankType)
    {
        GCRankApply rankdata=null;
        if (rankDic == null)
        {
            ClientLog.LogError("PaiHangModel:GetRankListByType时rankDic尚未实例化！");
            return null;
        }
        if (rankDic.ContainsKey(rankType))
        {
            rankDic.TryGetValue(rankType, out rankdata);
        }
        if (rankdata!=null)
        {
            if (rankdata.getRankInfoList() == null)
            {
                ClientLog.LogError("PaiHangModel:GetRankListByType时GCRankApply.rankInfoList为空");
                return null;
            }
            return rankdata.getRankInfoList().ToList();    
        }
        return null;
    }

    public RankInfo GetMyRankByType(int rankType)
    {
        GCRankApply rankdata = null;
        if (rankDic == null)
        {
            return null;
        }
        if (rankDic.ContainsKey(rankType))
        {
            rankDic.TryGetValue(rankType, out rankdata);
        }
        if (rankdata != null)
        {
            RankInfo[] list = rankdata.getRankInfoList();
            if (list.Length>0)
            {
                return list[list.Length-1];
            }
        }
        return null;
    }

    /// <summary>
    /// 获得一个排行榜的时间戳
    /// </summary>
    /// <param name="rankType"></param>
    /// <returns></returns>
    public long GetRankTimeyType(int rankType)
    {
        GCRankApply rankdata = null;
        if (rankDic!=null&&rankDic.ContainsKey(rankType))
        {
            rankDic.TryGetValue(rankType, out rankdata);
        }
        if (rankdata != null)
        {
            return rankdata.getTimeId();
        }
        return 0;
    }
    
    public override void Destroy()
    {
        if (rankDic != null)
        {
            rankDic.Clear();
        }
        _ins = null;
    }

}
