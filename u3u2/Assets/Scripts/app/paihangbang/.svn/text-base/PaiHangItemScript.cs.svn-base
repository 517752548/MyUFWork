using app.battle;
using app.net;
using app.pet;
using UnityEngine;
using UnityEngine.UI;
using app.zone;

public class PaiHangItemScript
{
    /// <summary>
    /// 帮派列表、帮派成员列表 中的一行元素
    /// </summary>
    public PaiHangItemUI UI;

    private RankInfo rankInfo;
    private long humanId;

    private PopRoleInfoWnd.EStatue m_Estatue;

    CorpsBossRankInfo info;

    public PaiHangItemScript(PaiHangItemUI ui, ScrollRect scrollrect, PopRoleInfoWnd.EStatue statue = PopRoleInfoWnd.EStatue.NoQiecuo)
    {
        UI = ui;
        UI.scrollRect = scrollrect;
        m_Estatue = statue;
        //if(UI.showinfoBtn!=null)
        //    UI.showinfoBtn.SetClickCallBack(ItemOnClick);
        //EventTriggerListener.Get(UI.gameObject).onClick = ItemOnClick;
    }

    public RankInfo RankInfo
    {
        get { return rankInfo; }
    }

    public void setRankInfo(RankInfo rankinfo, int rankType)
    {
        if (UI.showinfoBtn != null)
        {
            UI.showinfoBtn.SetClickCallBack(ItemOnClick);
        }
        if (rankinfo == null || UI == null)
        {
            return;
        }
        this.rankInfo = rankinfo;
        if (UI.paiming != null)
        {
            UI.paiming.text = rankInfo.rank > ClientConstantDef.PAIHANGBANG_MAX_MEMBER ? "榜外" : (rankInfo.rank.ToString());
        }
        switch (rankType)
        {
            case PaiHangBangType.ROLE_LEVEL:
                if (UI.jueseming != null) UI.jueseming.text = rankInfo.humanName;
                if (UI.zhiye != null) UI.zhiye.text = PetJobType.GetJobName(rankInfo.humanJob);
                if (UI.dengji != null) UI.dengji.text = rankInfo.level.ToString();
                if (UI.bangpai != null) UI.bangpai.text = rankInfo.corpsName == "" ? "无" : rankInfo.corpsName;
                break;
            case PaiHangBangType.ROLE_ZHANLI:
            case PaiHangBangType.XIAKE_ZHANLI:
            case PaiHangBangType.CIKE_ZHANLI:
            case PaiHangBangType.SHUSHI_ZHANLI:
            case PaiHangBangType.XIUZHEN_ZHANLI:
                if (UI.jueseming != null) UI.jueseming.text = rankInfo.humanName;
                if (UI.zhiye != null) UI.zhiye.text = PetJobType.GetJobName(rankInfo.humanJob);
                if (UI.zhanli != null) UI.zhanli.text = rankInfo.fightPower.ToString();
                if (UI.bangpai != null) UI.bangpai.text = rankInfo.corpsName == "" ? "无" : rankInfo.corpsName;
                break;
            case PaiHangBangType.PET_PINGFEN:
                if (UI.chongwuming != null) UI.chongwuming.text = rankInfo.petName;
                if (UI.yongyouzhe != null) UI.yongyouzhe.text = rankInfo.humanName;
                if (UI.pingfen != null) UI.pingfen.text = rankInfo.score.ToString();
                break;
        }
    }


    public void setRankInfo(ArenaMemberData rankinfo)
    {
        if (rankinfo == null || UI == null)
        {
            return;
        }

        if (UI.showinfoBtn != null)
            UI.showinfoBtn.SetClickCallBack(ItemOnClick);
        rankInfo = null;
        humanId = rankinfo.memberId;
        UI.paiming.text = rankinfo.rank == 0 ? "榜外" : (rankinfo.rank.ToString());
        UI.jueseming.text = rankinfo.name;
        UI.zhiye.text = PetJobType.GetJobNameByRoleTplId(rankinfo.tplId);
        UI.zhanli.text = rankinfo.fightPower.ToString();
        UI.bangpai.text = rankinfo.corpsName == "" ? "无" : rankinfo.corpsName;
    }

    public void setRankInfo(NvnRankInfo rankinfo)
    {
        if (rankinfo == null || UI == null)
        {
            ClientLog.LogError("setRankInfo:Error!");
            return;
        }

        if (UI.showinfoBtn != null)
            UI.showinfoBtn.SetClickCallBack(ItemOnClick);
        rankInfo = null;
        humanId = rankinfo.roleId;
        UI.paiming.text = rankinfo.rank > ClientConstantDef.PAIHANGBANG_MAX_MEMBER ? "榜外" : (rankinfo.rank.ToString());
        UI.jueseming.text = rankinfo.name;
        UI.zhiye.text = PetJobType.GetJobNameByRoleTplId(rankinfo.tplId);
        UI.liansheng.text = rankinfo.conWinNum.ToString();
        UI.jifen.text = rankinfo.score.ToString();
    }

    public void setRankInfo(CorpsBossRankInfo info)
    {
        if (info == null)
        {
            UI.gameObject.SetActive(false);
            return;
        }
        UI.gameObject.SetActive(true);
        this.info = info;
        UI.suoshubangpai_jindu.text = info.name;
        UI.zhanbaoluxiang.SetClickCallBack(PlayBattleReport);
        if (info.bossLevel % 5 == 0 && info.bossLevel != 0)
        {
            UI.zuigaojilu.text = string.Format("{0}-{1}", info.bossLevel / 5, 5);
        }
        else
        {
            UI.zuigaojilu.text = string.Format("{0}-{1}", (info.bossLevel / 5) + 1, info.bossLevel % 5);
        }
        UI.zhandouhuiheshu.text = info.round.ToString();
        SetRank(info.rank);
    }

    public void setRankInfo(CorpsBossCountRankInfo info)
    {
        if (info == null)
        {
            UI.gameObject.SetActive(false);
            return;
        }
        UI.gameObject.SetActive(true);
        UI.youxiaocishu.text = info.count.ToString();
        UI.suoshubangpai_cishu.text = info.name;
        UI.bangzhu.text = info.presidentName;
        UI.bangpaichengyuan.text = string.Format("{0}/{1}", info.curMemberCount, info.maxMemberCount);
        SetRank(info.rank);
    }

    public void setRankInfo(XianhuRankInfo rankinfo)
    {
        if (rankinfo == null || UI == null)
        {
            return;
        }

        if (UI.showinfoBtn != null)
            UI.showinfoBtn.SetClickCallBack(ItemOnClick);
        rankInfo = null;
        humanId = rankinfo.roleId;
        UI.paiming.text = rankinfo.rank == 0 ? "榜外" : (rankinfo.rank.ToString());
        UI.jueseming.text = rankinfo.name;
        UI.zhiye.text = PetJobType.GetJobNameByRoleTplId(rankinfo.tplId);
        UI.xianhu.text = rankinfo.num.ToString();
        UI.bangpai.text = rankinfo.corpsName == "" ? "无" : rankinfo.corpsName;
    }

    private void SetRank(int rank)
    {

        UI.paiming.gameObject.SetActive(true);
        if (rank > 0 && rank <= 10)
        {
            UI.paiming.text = rank.ToString();
        }
        else
        {
            UI.paiming.text = "未上榜";
        }
        //switch (rank)
        //{
            //case 1:
            //    UI.qiansan.gameObject.SetActive(true);
            //    UI.paiming.gameObject.SetActive(false);
            //    UI.qiansan.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "1st");
            //    break;
            //case 2:
            //    UI.qiansan.gameObject.SetActive(true);
            //    UI.paiming.gameObject.SetActive(false);
            //    UI.qiansan.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "2nd");
            //    break;
            //case 3:
            //    UI.qiansan.gameObject.SetActive(true);
            //    UI.paiming.gameObject.SetActive(false);
            //    UI.qiansan.sprite = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "3rd");
            //    break;
           // default:
               // UI.qiansan.gameObject.SetActive(false);
           //     UI.paiming.gameObject.SetActive(true);
           //     UI.paiming.text = rank.ToString(); ;
          //      break;

       // }
    }

    private void ItemOnClick(GameObject go)
    {
        if (rankInfo != null)
        {
            PopRoleInfoWnd.Ins.ShowInfo(rankInfo);
        }
        else
        {
            PopRoleInfoWnd.Ins.ShowInfo(humanId);
        }
    }

    private void PlayBattleReport()
    {
        //BattleManager.ins.PlayBattleReport(info.replay);
        //CorpsbossCGHandler.sendCGCorpsbossRankReplay(info.rank);
        BattleCGHandler.sendCGPlayBattleReportByStrId(info.replay,0);

    }

    public void Destroy()
    {
        if (UI != null) GameObject.DestroyImmediate(UI.gameObject, true);
        rankInfo = null;
    }
}
