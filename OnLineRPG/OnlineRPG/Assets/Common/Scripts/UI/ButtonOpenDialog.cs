using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BetaFramework;

public class ButtonOpenDialog : MyButton
{
    public Text textText;

    protected override void Start()
    {
        base.Start();
        if (textText != null)
        {
            textText.text = LanguageManager.Get("ExtraWordsAlreadyHave");
        }
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();
        Record.SetBool("shop_open_hint", false);
        if (MainSceneDirector.Instance.IsInGame())
        {
            UIManager.OpenUIAsync(ViewConst.prefab_StoreDialog, OpenType.Replace, null);
        }
        else
        {
            HomeRootFsmManager.CheckRefresh(HomeRootTab.shop);
        }
    }
}