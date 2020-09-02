using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CupRewardDialog : UIWindowBase
{
    public Text desText;

    public TextMeshProUGUI webText;

    public Slider progressImage;
    private CupSystem sys => AppEngine.SSystemManager.GetSystem<CupSystem>();
    private SyncDataAccesser data => AppEngine.SyncManager.Data;
    // Start is called before the first frame update
    public override void OnOpen()
    {
        base.OnOpen();
        ShowCup();
        transform.Find("Content/UI/BG_Common/UI").GetComponentInChildren<Button>().onClick.AddListener(ClickOK);
    }

    private void SetWebText(int current, int max)
    {
        if (max == -1 || max == 0)
        {
            webText.text = "MAX";
        }
        else
        {
            webText.text = string.Format("{0}/{1}", XUtils.GetFormatFans(current), XUtils.GetFormatFans(max));
        }

    }

    /// <summary>
    /// 展示现在的进度
    /// </summary>
    private void ShowCup()
    {
        int rewardTarget = data.RewardCup.Value;//已经领奖
        int currentCup = data.Cup.Value;
        int nextRewardTarget = sys.GetCurTarget(rewardTarget);//下一个该领奖的目标值
        if (nextRewardTarget > 0)
        {
            if (currentCup < nextRewardTarget)
            {//不满
                progressImage.value = (currentCup - rewardTarget) / (float)(nextRewardTarget - rewardTarget);
                SetWebText(currentCup - rewardTarget, nextRewardTarget - rewardTarget);
            }
            desText.text = string.Format("Reach <color=#81191C><size=100>{0} TROPHYS</size></color>  to open!", XUtils.GetFormatFans(nextRewardTarget - rewardTarget));
        }
        else
        {//到任务的最后一关了
            SetWebText(0, -1);
            progressImage.value = 1;
            desText.SetActive(false);
        }
    }


    //public override IEnumerator EnterAnim(params object[] objs)
    //{
    //    if (anim != null && hidingAnimation != null)
    //    {
    //        anim.SetTrigger("show");
    //    }

    //    yield return new WaitForSeconds(0.2f);

    //    OpenSuccess();
    //}



    public void ClickOK()
    {
        UIManager.CloseUIWindow(this);
    }
}
