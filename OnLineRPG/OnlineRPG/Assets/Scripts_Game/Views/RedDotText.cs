using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDotText : MonoBehaviour
{
    public Text countText;
    public RectTransform content;

    private Vector2 originalSize;

    private int timecd = 0;

    public void SetText(string text)
    {
        countText.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = content.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        timecd++;
        if (timecd < 8)
        {
            return;
        }

        timecd = 0;
        float textWidth = countText.preferredWidth + 29;
        if (textWidth > originalSize.x)
        {
            content.sizeDelta = new Vector2(textWidth, originalSize.y);
        }
        else
        {
            content.sizeDelta = originalSize;
        }
    }
}
