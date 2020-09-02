using UnityEngine.UI;
using BetaFramework ;
using EventUtil;

public class FBSignInDialog : UIWindowBase
{
    public Text value;

    public override void OnOpen()
    {
        base.OnOpen();
        EventDispatcher.AddEventListener(GlobalEvents.FaceBookUserInfoLoaded,FBLogined);
        //value.text = "+"+DataManager.SourceData.FileInit.FacebookLoginReward;
//        DataManager.FireBaseData.FacebookPanelShowTimes += 1;
    }

    private void FBLogined()
    {
        
    }

    public override void OnClose()
    {
        base.OnClose();
        EventDispatcher.RemoveEventListener(GlobalEvents.FaceBookUserInfoLoaded,FBLogined);
    }

    public void Login()
    {
        if (!ResponseClick)
        {
            return;
        }
        Close();
        AppEngine.SSDKManager.facebookSdk.OnLoginClick();
    }
}