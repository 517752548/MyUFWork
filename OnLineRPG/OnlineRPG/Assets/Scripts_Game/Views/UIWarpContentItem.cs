using System.Collections;
using UnityEngine;

/***
 *@des:warp下Element对应标记
 */

[DisallowMultipleComponent]
public class UIWarpContentItem : MonoBehaviour
{
    private int index;
    private UIWarpContent warpContent;

    private void OnDestroy()
    {
        warpContent = null;
    }

    public UIWarpContent WarpContent
    {
        set
        {
            warpContent = value;
        }
    }

    public void ReInit()
    {
        if (warpContent.onItemChange != null)
            warpContent.onItemChange(gameObject, index);
    }

    public int Index
    {
        set
        {
            // ReInit();
            index = value;
            transform.localPosition = warpContent.getLocalPositionByIndex(index);
            gameObject.name = (index < 10) ? ("0" + index) : ("" + index);
            if (warpContent.onInitializeItem != null && index >= 0)
            {
                warpContent.onInitializeItem(gameObject, index);
            }
            // StartCoroutine(ChangeName());
        }
        get
        {
            return index;
        }
    }

    private IEnumerator ChangeName()
    {
        yield return new WaitForSeconds(0.04f);
        transform.localPosition = warpContent.getLocalPositionByIndex(index);
        gameObject.name = (index < 10) ? ("0" + index) : ("" + index);
    }
}