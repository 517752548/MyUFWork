using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintLockTipWindow : BaseSideFloatWindow
{
    public Image iconImage;
    public Text titleText, desText;
    public Sprite hint1, hint2, hint3, hint4;

    public override void OnOpen()
    {
        autoClose = true;
        base.OnOpen();
        desText.text = "LEVEL " + objs[1];
        //titleText.text = (objs[0] as BaseHint).GetHintTitle();
        if (objs[0] is SpecificCellHint)
        {
            iconImage.sprite = hint1;
        }
        else if (objs[0] is KeyboardHint)
        {
            iconImage.sprite = hint2;
        }
        else if (objs[0] is MultiCellsHint)
        {
            iconImage.sprite = hint3;
        }
        else if (objs[0] is SpecificWordHint)
        {
            iconImage.sprite = hint4;
        }
    }
}
