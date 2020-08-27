using BetaFramework;
using UnityEngine.UI;

public class WebDialog : UIWindowBase
{
    public Button contactBtn;
    public SampleWebView aWebView;

    public override void OnOpen()
    {
        base.OnOpen();
        aWebView.closeAction += CloseWeb;
        aWebView.hiddenContact += HidenContact;
        aWebView.showContact += ShowContact;
    }

    private void CloseWeb(int aArg)
    {
        Close();
    }

    protected override bool onBackPressed()
    {
        GoBack();
        return true;
    }

    public void GoBack()
    {
        if (aWebView.CanGoBack())
        {
            aWebView.UserClickGoBack();
        }
        else
        {
            Close();
        }
    }

    public void ContactUs()
    {
        if (PlatformUtil.GetNetReachAble())
        {
            if (contactBtn.gameObject.activeSelf)
            {
                aWebView.LoadContactUs();
            }
            contactBtn.gameObject.SetActive(false);
        }
    }

    // protected override void Update()
    // {
    //     base.Update();
    //     //backBtn.interactable = aWebView.CanGoBack();
    // }

    public void ShowContact()
    {
        contactBtn.gameObject.SetActive(true);
    }

    public void HidenContact()
    {
        contactBtn.gameObject.SetActive(false);
    }
}