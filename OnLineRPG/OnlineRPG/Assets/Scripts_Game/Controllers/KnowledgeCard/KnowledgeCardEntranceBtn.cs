using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class KnowledgeCardEntranceBtn : MonoBehaviour
{
    private bool clickHome = false;
    public void KnowledgeCardEntranceButtonClick()
    {
        TimersManager.SetTimer(0.5f, () =>
        {
            clickHome = false;
        });
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        UIManager.OpenUIAsync(ViewConst.prefab_KnowledgeCardDialog);
        //        ReportDataManager.ClickSetting();
    }
}
