using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 下划线的制作
/// </summary>
public class UnderLine : MonoBehaviour
{
    /// 
    /// 下划线文本
    /// 
    public GameObject UderLine;
    /// 
    /// 下划线Image
    /// 
    public GameObject Line_Image;
    /// 
    /// 实现下划线的方式类型
    /// 
    public bool staticText = true;
    public enum Types
    {
        text_line = 0,
        image_line
    }

    public Types type;

    void Awake()
    {
        if (staticText)
        {
            SetUnderLine();

        }
    }


    /// 
    /// 设定文本的下划线
    /// type值为0表示使用“拼接Text：_”方式实现,有缺点
    /// type值为1表示使用“拉伸Image”方式实现，比较完美
    /// 
    public void SetUnderLine()
    {
        Debug.Log((int)type);

        //计算文本的宽度
        float width = transform.GetComponent<Text>().preferredWidth;
        switch (type)
        {
            case Types.text_line:
                //计算单个下划线宽度  
                Text underLineText = UderLine.GetComponent<Text>();
                underLineText.text = "_";
                float perlineWidth = underLineText.preferredWidth;

                int lineCount = (int)Mathf.Round(width / perlineWidth);
                for (int i = 1; i < lineCount; i++)
                {
                    underLineText.text += "_";
                }
                break;
            case Types.image_line:
                Vector2 curSizeDelta = Line_Image.GetComponent<RectTransform>().sizeDelta;
                //  Line_Image.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                Line_Image.GetComponent<RectTransform>().sizeDelta = new Vector2(width + 1, curSizeDelta.y);
                break;
        }
    }
}