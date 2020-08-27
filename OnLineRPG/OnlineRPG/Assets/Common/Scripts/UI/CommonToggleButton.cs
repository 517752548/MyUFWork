using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.Events;

public class CommonToggleButton : AnimationToggle
{
    public string From;
    public string ReportName;
    public UnityEvent clickDelegate;
    public RecordExtra.BoolPrefData currentBool;

    public void SetBoolData(RecordExtra.BoolPrefData currentBool)
    {
        this.currentBool = currentBool;
        SetStatus(currentBool.Value);
        if (currentBool.Value)
        {
            IsOn = true;
        }
        else
        {
            IsOn = false;
        }
    }


    public void Click()
    {
        currentBool.Value = !currentBool.Value;
        m_inited = true;
        IsOn = currentBool.Value;
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        clickDelegate?.Invoke();

    }
}