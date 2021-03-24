using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �»��ߵ�����
/// </summary>
public class UnderLine : MonoBehaviour
{
    /// 
    /// �»����ı�
    /// 
    public GameObject UderLine;
    /// 
    /// �»���Image
    /// 
    public GameObject Line_Image;
    /// 
    /// ʵ���»��ߵķ�ʽ����
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
    /// �趨�ı����»���
    /// typeֵΪ0��ʾʹ�á�ƴ��Text��_����ʽʵ��,��ȱ��
    /// typeֵΪ1��ʾʹ�á�����Image����ʽʵ�֣��Ƚ�����
    /// 
    public void SetUnderLine()
    {
        Debug.Log((int)type);

        //�����ı��Ŀ��
        float width = transform.GetComponent<Text>().preferredWidth;
        switch (type)
        {
            case Types.text_line:
                //���㵥���»��߿��  
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