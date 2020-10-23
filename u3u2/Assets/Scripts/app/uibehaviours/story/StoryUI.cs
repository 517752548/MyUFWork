using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour 
{
    public GameUUButton m_SkipStoryBtn;
    public RectTransform m_image_top;
    public RectTransform m_image_bottom;

    public GameObject roundNumContainer;
    public GameObject waitTimeContainer;

    public GameObject blackbg;
    public GameObject textContainer;
    public RectTransform textRTF;
    public Text defaultText;

    public void Init()
    {
        //RectTransform temp = transform.GetComponent<RectTransform>();
        //temp.sizeDelta = new Vector2(UGUIConfig.UISpaceWidth,UGUIConfig.UISpaceHeight);
        m_SkipStoryBtn = transform.Find("tiaoguoBtn").GetComponent<GameUUButton>();
        m_image_top = transform.Find("Image_top").GetComponent<RectTransform>();
        
        //m_image_top.sizeDelta = new Vector2(UGUIConfig.UISpaceWidth+20, 50);
        m_image_bottom = transform.Find("Image_bottom").GetComponent<RectTransform>();
        
        //m_image_bottom.sizeDelta = new Vector2(UGUIConfig.UISpaceWidth+20, 50);

        roundNumContainer = transform.Find("roundNumContainer").gameObject;
        waitTimeContainer = transform.Find("waitTimeContainer").gameObject;

        blackbg = transform.Find("blackbg").gameObject;
        textContainer = transform.Find("blackbg/Image/container").gameObject;
        textRTF = transform.Find("blackbg/Image/container").gameObject.GetComponent<RectTransform>();

        defaultText = transform.Find("blackbg/Image/container/Text").GetComponent<Text>();
        defaultText.gameObject.SetActive(false);
        blackbg.gameObject.SetActive(false);
        roundNumContainer.gameObject.SetActive(false);
        waitTimeContainer.gameObject.SetActive(false);
    }
}
