using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSpit : MonoBehaviour
{
    public RectTransform top;

    public RectTransform bottom;

    private float cellnativeSize = 144;

    private float nativesizex = 60;

    private float nativesizey = 50;
    // Start is called before the first frame update
    public void SetSize(float cellsize)
    {
        float rate = cellsize / 144;
        top.sizeDelta = new Vector2(nativesizex * rate * 0.75f,nativesizey * rate);
        bottom.sizeDelta = new Vector2(nativesizex * rate * 0.75f,nativesizey * rate);
    }

}
