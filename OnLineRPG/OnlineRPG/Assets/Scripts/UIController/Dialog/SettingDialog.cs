using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class SettingDialog : UIWindowBase
{
    public GameObject ButtonList;
    public GameObject RestoreButton;
    public Text textinfo;
    public GameObject Button;

    private void Start()
    {
#if UNITY_ANDROID
        RestoreButton.SetActive(false);

#endif
    }

    public void TransGroup()
    {
        Record.SetInt("PlayerADGroup", Random.Range(1, 4));
        //Record.SetBool("remove_ads", false);
        textinfo.transform.parent.Find("Button").Find("Text").GetComponent<Text>().text = "Group" +
                                                                                                    XUtils
                                                                                                        .GetPlayerADGroup
                                                                                                        ().ToString();
    }

    public void OnClickEmail()
    {
        //string subject = "";
        //string body = "";
        //string to = Const.APP_EMAIL;
        //UnitySentEmail.Send(subject, body, to);
        XUtils.SendEmail();
    }

    public void OnClickFaceBook()
    {
    }
    

    public void RestoreButtonClick()
    {
    }
}