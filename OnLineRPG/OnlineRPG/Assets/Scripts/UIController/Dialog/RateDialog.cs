using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class RateDialog : UIWindowBase
{

    
    private const int toggleNoselectState = -1;
    public const int goodCount = 4;
    private int starCount = 0;
    public Toggle[] toggles;
    private int CurrentToggleIndex = toggleNoselectState;
    public Text rateMessage;

    public override void OnOpen()
    {
        canClose = false;
        base.OnOpen();
        
    }

    public void OnClickRate()
    {
        Application.OpenURL(Const.APPSTORE_URL);
        base.Close();
    }

    private void RateToEmail()
    {
        //PlayButton();
        //UIManager.OpenUIAsync(ViewConst.prefab_CommentDialog, null, new DialogParams().putExtraInt("rateStarCount", starCount));
        //DialogController.instance.ShowDialog(DialogType.CommentText, DialogShow.REPLACE_CURRENT, new DialogParams().putExtraInt("rateStarCount", starCount));
//        ReportDataManager.Ratepopup_close();
    }
    


}