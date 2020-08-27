using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class FansRewardDialog : UIWindowBase
{
    public Text desText;

    public TextMeshProUGUI webText;

    public Slider progressImage;

	// Start is called before the first frame update
	public override void OnOpen()
	{
		base.OnOpen();
        ShowFans();
	}

	private void SetWebText(int current, int max)
    {
        if (max == -1 || max == 0) {
            webText.text = string.Format("MAX", current, current);
        } else {
            webText.text = string.Format("{0}/{1}", XUtils.GetFormatFans(current), XUtils.GetFormatFans(max));
        }
        
    }

    /// <summary>
    /// 展示现在的进度
    /// </summary>
    private void ShowFans()
    {
        int lastFans = AppEngine.SyncManager.Data.fansNumber.LastValue;
        int lastNestFans = AppEngine.SSystemManager.GetSystem<WebSystem>().GetNextTarget(lastFans);
        int lastRegion = AppEngine.SSystemManager.GetSystem<WebSystem>().GetCurrentTargetRegion(lastFans);
        int currentFans = AppEngine.SyncManager.Data.fansNumber.Value;
        int lastTarget = AppEngine.SSystemManager.GetSystem<WebSystem>().GetLastTarget(lastFans);
        if (lastNestFans > 0) {
            float progress = (lastFans - lastTarget) / (float)lastRegion;
            progressImage.value = progress;
            SetWebText(lastFans - lastTarget, lastRegion);
        } else {
            SetWebText(lastFans - lastTarget, -1);
            progressImage.value = 1;
        }
        desText.text = string.Format("Reach <color=#81191C><size=100>{0} FANS</size></color>  to open!", XUtils.GetFormatFans(lastRegion));
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
