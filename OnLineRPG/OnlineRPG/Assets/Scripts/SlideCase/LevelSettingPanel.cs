using System;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSettingPanel : UIWindowBase
{

    public GameObject highlightBtn;
    public CommonToggleButton Sound, Music, SkipFilled, EraWrongWord, Slot,highLightFreeLetters;

    private void Start()
    {
        InitToggleButton();
    }

    private void OnEnable()
    {
        InitToggleButton();
    }

    public override void OnOpen()
    {
        base.OnOpen();
        highlightBtn.SetActive(AppEngine.SSystemManager.GetSystem<CellTipABSystem>().CellTipEnable);
        GameAnalyze.SettingReport("Level");
    }

    private void InitToggleButton()
    {
        Sound.SetBoolData(AppEngine.SGameSettingManager.Sound);
        Music.SetBoolData(AppEngine.SGameSettingManager.Music);
        SkipFilled.SetBoolData(AppEngine.SGameSettingManager.SkipFilledSquares);
        EraWrongWord.SetBoolData(AppEngine.SGameSettingManager.EraseWrongWord);
        Slot.SetBoolData(AppEngine.SGameSettingManager.SelectFirstSolt);
        highLightFreeLetters.SetBoolData(AppEngine.SGameSettingManager.MarkFlyCell);
    }

    public void OnMusicClick()
    {
    }
    

    public void CloseSetting()
    {
        Close();
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    protected override void OnHide()
    {
        base.OnHide();
    }

    public void OnClickShop()
    {
        if (!ResponseClick) return;
        UIManager.OpenUIAsync(ViewConst.prefab_StoreDialog);
    }

    public void OnClickFAQ()
    {
        if (!ResponseClick) return;
        //buttonlist.GetComponent<HelpShiftController>().ShowHelpShift();
        CloseSetting();
    }
    
    public void ClickTestAdBtn()
    {
        if (!ResponseClick) return;
    }

    private bool canOpenMap = true;

    
    public override IEnumerator EnterAnim(params object[] objs)
    {
        //m_settingUserImage.LoadFbUserPicture();
        return base.EnterAnim(objs);
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        return base.ExitAnim(l_callBack, objs);
    }
}