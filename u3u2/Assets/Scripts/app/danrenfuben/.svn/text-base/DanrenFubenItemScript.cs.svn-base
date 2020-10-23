using UnityEngine;
using System.Collections;
using app.danrenfuben;
using app.db;
using app.reward;
using System.Collections.Generic;
using app.net;
using app.zone;

public class DanrenFubenItemScript : BaseUI 
{
    DanrenFubenView fubenView;
    public DanrenFubenItemUI UI;
    public PlotDungeonTemplate template;
    GCPlotDungeonInfo dungeonInfo;
    private bool showMask;

    public DanrenFubenItemScript(DanrenFubenItemUI UI,DanrenFubenView fubenView)
    {
        this.UI = UI;
        this.fubenView = fubenView;
        UI.btnSelect.SetClickCallBack(Onclick);
        ignorePositionShow = true;
        ui = UI.gameObject;
    }

    public void SetData(PlotDungeonTemplate template,GCPlotDungeonInfo dungeonInfo)
    {
        this.template = template;

        EnemyArmyTemplate enemyTpl = EnemyArmyTemplateDB.Instance.getTemplate(template.enemyArmyId);
        UI.textTitle.text = enemyTpl.name;

        AddAvatarModelToUI(Vector3.zero,Vector3.zero,Vector3.one,template.model3DId,UI.tfModelContainer.gameObject);
        RewardData rewardData = new RewardData();
        List<RewardItem> rewardItems = new List<RewardItem>();
        RewardItem itemLeft = new RewardItem(UI.commonItemUI_left);
        RewardItem itemRight = new RewardItem(UI.commonItemUI_right);
        rewardItems.Add(itemLeft);
        rewardItems.Add(itemRight);
        ShowRewardTemplate rewardTpl = ShowRewardTemplateDB.Instance.getTemplate(template.showEnemyRewardId);
        rewardData.Parse (rewardTpl,rewardItems);
        this.dungeonInfo = dungeonInfo;
        showMask = template.plotDungeonLevel > (dungeonInfo.getCurPlotDungeonLevel() + 1) || dungeonInfo.getPlotDungeonChapter() * DanrenFubenView.LEVELS_PER_LEVEL < template.plotDungeonLevel;
        UI.tfMask.gameObject.SetActive(showMask);
        UI.tfYitongguo.gameObject.SetActive(dungeonInfo.getCurPlotDungeonLevel()>=template.plotDungeonLevel);
    }

    public void SetScale(Vector3 scale)
    {
        UI.tfItem.localScale = scale;
        
        if (showMask)
        {
            UI.tfMask.localScale = scale;
            UI.tfMask.gameObject.SetActive(false);
            UI.tfMask.gameObject.SetActive(true);
        }
    }

    private void Onclick()
    {
        if (!showMask)
        {
            fubenView.OnClickItem(this);
        }
        else
        {
            if (dungeonInfo.getPlotDungeonChapter() * DanrenFubenView.LEVELS_PER_LEVEL < template.plotDungeonLevel)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("前置任务未完成");
            }
        }
    }

    public void Destroy()
    {
        fubenView = null;
        template = null;
        dungeonInfo = null;
        if (UI != null)
        {
            GameObject.DestroyImmediate(UI.gameObject);
            UI = null;
        }

    }
    
   

}
