using UnityEngine;
using UnityEngine.UI;

public class GuideUI:UIMonoBehaviour
{
    public Image highLightImage;
    public GameUUImageIgnoreRaycast biankuangImage;
    public GameObject xiaoshouObj;
    public GameUUImageIgnoreRaycast zhiImage;
    public GameUUButton tiaoguoBtn;

    public GameObject maskObj;

    public GameObject container;
    public Image upImage;
    public Image leftImage;
    public Image rightImage;
    public Image bottomImage;

    public LayoutElement upLayout;
    public LayoutElement leftLayout;
    public LayoutElement containerLayout;
    public LayoutElement rightLayout;
    public LayoutElement bottomLayout;

    public override void Init()
    {
        base.Init();

        highLightImage = transform.GetComponent<Image>();
        highLightImage.enabled = false;
        maskObj = transform.Find("verticalLayout").gameObject;

        biankuangImage = transform.Find("biankuang").GetComponent<GameUUImageIgnoreRaycast>();
        xiaoshouObj = transform.Find("xiaoshou").gameObject;
        zhiImage = transform.Find("xiaoshou/zhi").GetComponent<GameUUImageIgnoreRaycast>();
        tiaoguoBtn = transform.Find("tiaoguoBtn").GetComponent<GameUUButton>();

        container = transform.Find("verticalLayout/mid/content").gameObject;

        upImage = transform.Find("verticalLayout/up").GetComponent<Image>();
        leftImage = transform.Find("verticalLayout/mid/left").GetComponent<Image>();
        rightImage = transform.Find("verticalLayout/mid/right").GetComponent<Image>();
        bottomImage = transform.Find("verticalLayout/bottom").GetComponent<Image>();

        containerLayout = transform.Find("verticalLayout/mid/content").GetComponent<LayoutElement>();

        upLayout = transform.Find("verticalLayout/up").GetComponent<LayoutElement>();
        leftLayout = transform.Find("verticalLayout/mid/left").GetComponent<LayoutElement>();
        rightLayout = transform.Find("verticalLayout/mid/right").GetComponent<LayoutElement>();
        bottomLayout = transform.Find("verticalLayout/bottom").GetComponent<LayoutElement>();

        if (upLayout!=null)
        {
            upLayout.gameObject.SetActive(false);
        }
        if (leftLayout != null)
        {
            leftLayout.gameObject.SetActive(false);
        }
        if (rightLayout != null)
        {
            rightLayout.gameObject.SetActive(false);
        }
        if (bottomLayout != null)
        {
            bottomLayout.gameObject.SetActive(false);
        }
    }

}


