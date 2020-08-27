using BetaFramework;
using UnityEngine;

public class PrivacyPolicyDialog : UIWindowBase
{
    private readonly string LinkUrl = "https://sites.google.com/view/word-craze";
    
    public void OnClickLink()
    {
        Application.OpenURL(LinkUrl);
    }

    public void OnClickContinue()
    {
        if (windowStatus != WindowStatus.Opened)
        {
            return;
        }
        if (!Record.GetBool(PrefKeys.PrivacyPolicyShown, false))
        {
            Record.SetBool(PrefKeys.PrivacyPolicyShown, true);
//            ReportDataManager.PrivacyPolicyDialogAgree();
        }
        Close();
    }
}