using UnityEngine;
using System.Collections;
using app.danrenfuben;
using System.Collections.Generic;
using app.db;
using app.net;

public class FubenJiangliView : BaseUI 
{
    FubenJiangliUI UI;
    List<PlotDungeonTemplate> normalChapters = new List<PlotDungeonTemplate>();
    List<PlotDungeonTemplate> harderChapters = new List<PlotDungeonTemplate>();
    PlotDungeonInfo[] infos;
    List<FubenJiangliItemScript> itemScripts = new List<FubenJiangliItemScript>();

    public FubenJiangliView(FubenJiangliUI UI)
    {
        this.UI = UI;
        ui = UI.gameObject;
        DanrenFubenModel.Instance.addChangeEvent(DanrenFubenModel.GET_REWARDINFO,GetRewardInfo);
        InitItems();
        UI.defaultItemUI.gameObject.SetActive(false);
        UI.tabButtonGroup.TabChangeHandler = TabHandler;
    }

    public void OnShow()
    {
        PlotdungeonCGHandler.sendCGDailyPlotDungeonInfo();
    }

    private void TabHandler(int index)
    {
        List<PlotDungeonTemplate> tpls;
        if (index == 0)
        {
            tpls = normalChapters;
        }
        else
        {
            tpls = harderChapters;
        }

        for (int i = 0; i < tpls.Count; i++)
        {
            if (i == itemScripts.Count)
            {
                GameObject obj = GameObject.Instantiate(UI.defaultItemUI.gameObject);
                obj.SetActive(true);
                obj.transform.SetParent(UI.tfGrid);
                obj.transform.localScale = Vector3.one;
                QiRiMuBiaoItemUI mUI = obj.GetComponent<QiRiMuBiaoItemUI>();
                mUI.Init();
                FubenJiangliItemScript script = new FubenJiangliItemScript(mUI, this);
                itemScripts.Add(script);
            }
            itemScripts[i].SetTemplate(tpls[i]);
        }

        for (int i = tpls.Count; i < itemScripts.Count; i++)
        {
            itemScripts[i].UI.gameObject.SetActive(false);
        }

        if (infos != null)
        {
            for (int i = 0; i < itemScripts.Count; i++)
            {
                itemScripts[i].RefreshData();
            }
        }
    }

    private void InitItems()
    {
        Dictionary<int, PlotDungeonTemplate> tpls = PlotDungeonTemplateDB.Instance.getIdKeyDic();
        List<PlotDungeonTemplate> normalTpls = new List<PlotDungeonTemplate>();
        List<PlotDungeonTemplate> harderTpls = new List<PlotDungeonTemplate>();

        foreach (var item in tpls)
        {
            if (item.Value.hardFlag == 0)
            {
                normalTpls.Add(item.Value);
            }
            else
            {
                harderTpls.Add(item.Value);
            }
        }

        normalTpls.Sort(delegate(PlotDungeonTemplate x, PlotDungeonTemplate y)
        {
            return x.plotDungeonLevel.CompareTo(y.plotDungeonLevel);
        });



        harderTpls.Sort(delegate(PlotDungeonTemplate x, PlotDungeonTemplate y)
        {
            return x.plotDungeonLevel.CompareTo(y.plotDungeonLevel);
               
        });

        for (int i = 0; i < normalTpls.Count; i+= DanrenFubenView.LEVELS_PER_LEVEL)
        {
            normalChapters.Add(normalTpls[i]);
        }

        for (int i = 0; i < harderTpls.Count; i+= DanrenFubenView.LEVELS_PER_LEVEL)
        {
            harderChapters.Add(harderTpls[i]);
        }


    
    }

    private void GetRewardInfo(RMetaEvent e = null)
    {
        GCDailyPlotDungeonInfo info = DanrenFubenModel.Instance.GCDailyPlotDungeonInfo;
        UI.tabButtonGroup.SetIndexWithCallBack(UI.tabButtonGroup.index);
        infos = info.getPlotDungeonInfoList();
        for (int i = 0; i < itemScripts.Count; i++)
        {
            itemScripts[i].RefreshData();
        }
    }

    public PlotDungeonInfo GetDungeonInfo(int hardFlag, int level)
    {
        int chapter = (level / DanrenFubenView.LEVELS_PER_LEVEL) + 1;
        PlotDungeonInfo info = null;
        for (int i = 0; i < infos.Length; i++)
        {
            if (infos[i].plotDungeonChapter == chapter&&infos[i].plotDungeonType == hardFlag)
            {
                info = infos[i];
            }
        }
        return info;
    }

    public override void Destroy()
    {

        DanrenFubenModel.Instance.removeChangeEvent(DanrenFubenModel.GET_REWARDINFO, GetRewardInfo);
        if (itemScripts != null)
        {
            for (int i = 0; i < itemScripts.Count; i++)
            {
                itemScripts[i].Destroy();
            }
        }
        if (infos != null)
        {
            infos = null;
        }
        base.Destroy();
    }


}
