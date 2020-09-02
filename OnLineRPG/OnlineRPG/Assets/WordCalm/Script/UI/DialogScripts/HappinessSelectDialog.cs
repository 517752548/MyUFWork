using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessSelectDialog : UIWindowBase
{
    public TextMeshProUGUI currentStars;
    public Image progressSlider;
    public GameObject[] rights;
    public GameObject[] locks;
    public GameObject[] rewardPanel;
    public TextMeshProUGUI[] targets;
    public HappinessDialogItem[] rewardItems;
    public HappinessItem[] Items;
    public TextMeshProUGUI subworldstars;
    private EliteWorld config;
    private int[] starTargets;
    private float[] imagetargets = new[] {0.4f, 0.68f, 1};
    private static int lastStars = 0;

    public override void OnOpen()
    {
        base.OnOpen();
        starTargets = new[]
        {
            AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock1,
            AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock2,
            AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock3
        };
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].text = starTargets[i].ToString();
        }
        config = AppEngine.SSystemManager.GetSystem<EliteSystem>().GetCurrentWorld();
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].SetDialog(this, i, config);
        }

        for (int i = 0; i < rewardItems.Length; i++)
        {
            rewardItems[i].Init(i);
        }
        RefreshUI();
    }


    private void RefreshUI()
    {
        if (lastStars > 0)
        {
            SetStars(lastStars);
        }
        else
        {
            int worldStar = AppEngine.SyncManager.Data.Elitedata.Value
                .GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).GetCurrentStar();
            lastStars = worldStar;
            SetStars(worldStar);
        }
    }

    private void SetStars(int stars)
    {
        currentStars.text = stars.ToString();
        float progress = GetTargetFloat(stars);
        progressSlider.fillAmount = progress;
        if (stars >= starTargets[0])
        {
            SetRewardStatus(0,true);
        }
        else
        {
            SetRewardStatus(0,false);
        }
        if (stars >= starTargets[1])
        {
            SetRewardStatus(1,true);
        }
        else
        {
            SetRewardStatus(1,false);
        }
        if (stars >= starTargets[2])
        {
            SetRewardStatus(2,true);
        }
        else
        {
            SetRewardStatus(2,false);
        }
    }

    private void SetRewardStatus(int index,bool can)
    {
        rights[index].SetActive(can);
        locks[index].SetActive(!can);
        rewardItems[index].SetStatus(can);
    }


    private float GetTargetFloat(int stars)
    {
        if (stars >= starTargets[2])
        {
            return 1;
        }
        else if (stars > starTargets[1])
        {
            float threearea = (1 - imagetargets[1]) * ((stars - starTargets[1])/ (float)(starTargets[2] -  starTargets[1])) + imagetargets[1];
            return threearea;
        }else if (stars == starTargets[1])
        {
            return imagetargets[1];
        }else if (stars > starTargets[0])
        {
            float threearea = (imagetargets[1] - imagetargets[0]) * ((stars - starTargets[0])/ (float)(starTargets[1] -  starTargets[0]))+ imagetargets[0];
            return threearea;
        }else if (stars == starTargets[0])
        {
            return imagetargets[0];
        }else if (stars > 0)
        {
            float threearea = (float)(imagetargets[0] ) * (((float)stars / starTargets[0]));
            return threearea;
        }
        else
        {
            return 0;
        }
    }


    public void CloseClick()
    {
        Close();
        UIManager.OpenUIAsync(ViewConst.prefab_MagazineListDialog);
    }
}