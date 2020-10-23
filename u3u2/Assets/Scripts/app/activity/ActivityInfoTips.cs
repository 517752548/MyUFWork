using System.Collections.Generic;
using app.db;
using app.model;
using app.net;
using app.reward;
using UnityEngine;
using app.human;

public class ActivityInfoTips : BaseTips
{
    private static ActivityInfoTips _ins;

    //[Inject(ui = "ActivityTipsUI")]
    //public GameObject ui;

    public ActivityTipsUI UI;

    public List<RewardItem> rewardItemList;
    public ActivityUITemplate activityTpl;
    public ActivityUIInfo activityInfo;

    public static ActivityInfoTips Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(ActivityInfoTips)) as ActivityInfoTips;
                //_ins = new ActivityInfoTips();
            }
            return _ins;
        }
    }
    
    public ActivityInfoTips()
    {
        uiName = "ActivityTipsUI";
    }

    public void ShowTips(ActivityUITemplate tpl, ActivityUIInfo activityinfo)
    {
        if (tpl == null || activityinfo == null)
        {
            return;
        }
        activityTpl = tpl;
        activityInfo = activityinfo;
        preLoadUI();
    }

    public override void initWnd()
    {
        base.initWnd();
        UI = ui.AddComponent<ActivityTipsUI>();
        UI.Init();
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        //showBgImage();
        setData();
    }

    private void setData()
    {
        if (rewardItemList == null)
        {
            rewardItemList = new List<RewardItem>();
        }
        UI.defaultRewardItem.gameObject.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            if (i >= rewardItemList.Count)
            {
                CommonItemUI commonitemui = GameObject.Instantiate(UI.defaultRewardItem);
                commonitemui.gameObject.transform.SetParent(UI.rewardGrid.transform);
                commonitemui.gameObject.SetActive(true);
                commonitemui.transform.localScale = Vector3.one;
                RewardItem rewarditem = new RewardItem(commonitemui);
                rewardItemList.Add(rewarditem);
            }
        }

        RewardData rewardData = new RewardData();
        rewardData.Parse(activityInfo.rewardInfo.rewardStr, rewardItemList);

        UI.activityname.text = activityTpl.name;
        UI.cishu.text = (activityTpl.activityTotalTime == 0 ? LangConstant.NOLIMIT : activityInfo.activityTimes + " / " + activityTpl.activityTotalTime);
        UI.timeText.text = activityTpl.activityTimeDesc;
        UI.typeText.text = activityTpl.taskMemberDesc;
        UI.huoyueduText.text = (activityTpl.activityTotalTime * activityTpl.activityNumPerTime).ToString();
        string str = /*"Lv " + activityTpl.openLevel + " " +*/ activityTpl.openConditionDesc;
        bool isopen = true;
        if (activityTpl.funcId>0)
        {
            isopen = FunctionModel.Ins.IsFuncOpen(activityTpl.funcId);
        }
        if (!isopen)
        {
            UI.xianzhiText.text = "<color=#FF0000>" + str + "</color>";
        }
        else
        {
            UI.xianzhiText.text = str;
        }
        
        UI.descText.text = activityTpl.desc;
        if (!string.IsNullOrEmpty(activityTpl.icon))
        {
            /*
            SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(activityTpl.icon, PathUtil.TEXTURE_ACTIVITY_ICON),
                OnIconLoaded);
            */
            PathUtil.Ins.SetActivityIcon(UI.icon, activityTpl.icon);
        }
        else
        {
            UI.icon.gameObject.SetActive(false);
        }
    }

    public override void Destroy()
    {
        for (int i=0;i<rewardItemList.Count;i++)
        {
            rewardItemList[i].Destroy();
        }
        rewardItemList.Clear();
        rewardItemList = null;
        activityTpl = null;
        activityInfo = null;

        base.Destroy();
        UI = null;
    }

}
