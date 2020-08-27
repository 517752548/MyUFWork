using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class SignEnter : BaseHomeUI
{
    public Text timeText;

    public override void OnShow()
    {
        base.OnShow();
    }

    public void OnClick()
    {
        UIManager.OpenUIAsync("");
    }
}