using BetaFramework;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickFB : MonoBehaviour
{
    public static ButtonClickFB Instance = null;
    public Image selfImage;
    public Sprite[] ButtonSpriteList;
    public Button btn_friend;
    public Button btn_email;
    public GameObject btn_Login;
    public GameObject reward;

    private void Start()
    {
        Instance = this;
        if (FB.IsLoggedIn)
        {
            SetFaceBookButton(false);
            reward.SetActive(false);
        }
        else
        {
            SetFaceBookButton(true);
//            if (!DataManager.PlayerData.FbLoginGiftClaimed)
//            {
//                reward.SetActive(true);
//            }
//            else
//            {
//                reward.SetActive(false);
//            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (FB.IsLoggedIn)
            {
                SetFaceBookButton(false);
            }
            else
            {
                SetFaceBookButton(true);
            }
        }
    }

    public void OnButtonClick()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
    }

    public void SetFaceBookButton(bool isfbbutton)
    {
        if (isfbbutton)
        {
            selfImage.sprite = ButtonSpriteList[0];
        }
        else
        {
            selfImage.gameObject.SetActive(false);
            reward.SetActive(false);
            //  selfImage.sprite = ButtonSpriteList [1];
        }
    }

    public void SetLogin()
    {
        //		btn_friend.interactable = false;
        //		btn_email.interactable = false;
        //		btn_Login.SetActive (true);
        reward.SetActive(false);
    }
}