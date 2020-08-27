using BetaFramework;
using UnityEngine;

public class SettingButtonScript : MonoBehaviour
{
    public Transform ParenTransform;
    private bool clickHome = false;
    public void SettingButtonClick()
    {
        TimersManager.SetTimer(0.5f, () =>
        {
            clickHome = false;
        });
		UIManager.OpenUIAsync(ViewConst.prefab_CrazeSettingPanel);
//        ReportDataManager.ClickSetting();
    }
}