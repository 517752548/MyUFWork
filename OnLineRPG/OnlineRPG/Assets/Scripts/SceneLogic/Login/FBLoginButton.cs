using BetaFramework;
using EventUtil;
using UnityEngine;

public class FBLoginButton : MonoBehaviour
{
    public GameObject reward;

    // Use this for initialization
    private void Start()
    {
#if UNITY_AMAZON
        gameObject.SetActive(false);
        enabled = false;
        return;
#endif
        EventDispatcher.AddEventListener(GlobalEvents.FaceBookLoginedSuccessful, OnFBLogined);
        UpdateButton();
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.FaceBookLoginedSuccessful, OnFBLogined);
    }

    private void OnFBLogined()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (FaceBookSDK.IsFacebookLoggedIn())
        {
            gameObject.SetActive(false);
            enabled = false;
        }
        else
        {
            enabled = true;
            gameObject.SetActive(true);
//            if (!DataManager.PlayerData.FbLoginGiftClaimed)
//            {
//                if (reward)
//                    reward.SetActive(true);
//            }
//            else
//            {
//                if (reward)
//                    reward.SetActive(false);
//            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            UpdateButton();
        }
    }

    public void OnButtonClick()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
    }
}