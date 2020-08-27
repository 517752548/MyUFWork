using UnityEngine;
using System.Collections;

public class CommHintUseGuide : AdjustBoardArrowGuide
{
    public GameObject desHint1, desHint2, desHint3, desHint4;

    private BaseHint hint;

    public override void OnOpen()
    {
        base.OnOpen();
        MainSceneDirector.Instance.GetUIRoot(GameUI.Game)._imageMask.Show();
        desHint1.SetActive(false);
        desHint2.SetActive(false);
        desHint3.SetActive(false);
        desHint4.SetActive(false);
        hint = objs[1] as BaseHint;
        if (hint is SpecificCellHint)
        {
            desHint1.SetActive(true);
        }
        else if (hint is KeyboardHint)
        {
            desHint2.SetActive(true);
        }
        else if (hint is MultiCellsHint)
        {
            desHint3.SetActive(true);
        }
        else if (hint is SpecificWordHint)
        {
            desHint4.SetActive(true);
        }
    }

    public override void Close()
    {
        base.Close();
        MainSceneDirector.Instance.GetUIRoot(GameUI.Game)._imageMask.Hide();
    }
}

