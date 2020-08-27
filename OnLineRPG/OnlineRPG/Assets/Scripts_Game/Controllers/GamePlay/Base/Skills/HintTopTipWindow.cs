using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintTopTipWindow : BaseSideFloatWindow
{
    public Image iconImage;
    public Text titleText, desText;
    public Sprite hint1, hint2, hint4;

    public override void OnOpen()
    {
        base.OnOpen();
        if (objs[0] is SpecificCellHint)
        {
            iconImage.sprite = hint1;
            titleText.text = (objs[0] as BaseHint).GetHintTitle();
            desText.text = "Reveal a single letter of your choosing";
        }
        else if (objs[0] is KeyboardHint)
        {
            iconImage.sprite = hint2;
            titleText.text = (objs[0] as BaseHint).GetHintTitle();
            desText.text = "Reveal several random letters";
        }
        else if (objs[0] is SpecificWordHint)
        {
            iconImage.sprite = hint4;
            titleText.text = (objs[0] as BaseHint).GetHintTitle();
            desText.text = "Reveal an entire word";
        }        
    }
}
