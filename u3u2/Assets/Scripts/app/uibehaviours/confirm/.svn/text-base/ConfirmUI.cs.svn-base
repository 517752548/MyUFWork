using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfirmUI : MonoBehaviour
{

    public InputField inputText;
    public Toggle toggle;
    public Text title;
    public Text infoText;
    public GameUUButton sureBtn;
    public GameUUButton cancelBtn;
    public GameUUButton middleBtn;
	public Text surBtnLabel;
	public Text cancelBtnLabel;
    public RectTransform layout;
    public Text toggolText;

    public void Init()
    {

        layout = transform.Find("Image").GetComponent<UnityEngine.RectTransform>();
        Transform transform1 = transform.Find("Image/InputField");
        if (transform1)
        {
            inputText = transform1.GetComponent<UnityEngine.UI.InputField>();
        }

        Transform transform2 = transform.Find("Image/Toggle");
        if (transform1)
        {
           toggle=transform2.GetComponent<UnityEngine.UI.Toggle>();
        }

        Transform transform3 = transform.Find("Image/title");
        if (transform3)
        {
            title = transform3.GetComponent<UnityEngine.UI.Text>();
        }

        Transform transform4 = transform.Find("Image/infoText");
        if (transform4)
        {
              infoText=transform4.GetComponent<UnityEngine.UI.Text>();
        }

        Transform transform5 = transform.Find("Image/btns/ZZButton0");
        if (transform5)
        {
             sureBtn = transform5.GetComponent<GameUUButton>();
        }

        Transform transform6 = transform.Find("Image/btns/ZZButton1");
        if (transform6)
        {
             cancelBtn = transform6.GetComponent<GameUUButton>();
        }


        Transform transform7 = transform.Find("Image/btns/ZZButton2");
        if (transform7)
        {
             middleBtn = transform7.GetComponent<GameUUButton>();
        }

        Transform transform8 = transform.Find("Image/btns/ZZButton0/name");
        if (transform8)
        {
            surBtnLabel = transform8.GetComponent<UnityEngine.UI.Text>();
        }

        Transform transform9 = transform.Find("Image/btns/ZZButton1/name");
        if (transform9)
        {
             cancelBtnLabel=transform9.GetComponent<UnityEngine.UI.Text>();
        }


        Transform transform10 = transform.Find("Image/InputField/Text");
        if (transform10)
        {
            toggolText = transform10.GetComponent<UnityEngine.UI.Text>();
        }
    }

    public void Init1()
    {
        Init();

        Transform transform4 = transform.Find("Image/Image/infoText");
        if (transform4)
        {
            infoText = transform4.GetComponent<UnityEngine.UI.Text>();
        }
    }

}
