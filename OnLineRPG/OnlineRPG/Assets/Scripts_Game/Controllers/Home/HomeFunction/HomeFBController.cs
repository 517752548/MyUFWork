using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using UnityEngine;
using UnityEngine.UI;

public class HomeFBController : MonoBehaviour
{
    public Image PlayerPic;

    public GameObject HeadUser;

    public GameObject FBButton;
    // Start is called before the first frame update
    void Start()
    {
        Sprite pic = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerFBPic();
        if (pic != null)
        {
            HeadUser.gameObject.SetActive(true);
            FBButton.gameObject.SetActive(false);
            PlayerPic.sprite = pic;
        }
        EventDispatcher.AddEventListener(GlobalEvents.HeadChanged,ChangePic);
        //EventDispatcher.AddEventListener(GlobalEvents.FBLoginOut,LoginOutFB);
    }
    
    private void LoginOutFB()
    {
        HeadUser.gameObject.SetActive(false);
        FBButton.gameObject.SetActive(true);
    }

    private void ChangePic()
    {
        Sprite pic = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerFBPic();
        if (pic != null)
        {
            HeadUser.gameObject.SetActive(true);
            FBButton.gameObject.SetActive(false);
            PlayerPic.sprite = pic;
        }
        else
        {
            //LoginOutFB();
        }
    }
    public void ClickFB()
    {
        if (AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value.Length > 0)
        {
            return;
        }
        GameAnalyze.SettingReport("Home","FB","1");
        UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog);
    }
}
