using UnityEngine;

public class DisplayQualitySettingUI : MonoBehaviour
{
	public TabButtonGroup toggleGroup;
	public GameUUButton okBtn;
	public GameUUButton cancelBtn;
	public GameObject infoTips;

    public void Init()
    {
        toggleGroup = transform.Find("Image").gameObject.AddComponent<TabButtonGroup>();
        okBtn = transform.Find("Image/btns/ZZButton0").GetComponent<GameUUButton>();
        cancelBtn = transform.Find("Image/btns/ZZButton1").GetComponent<GameUUButton>();
        infoTips = transform.Find("Image/infoText").gameObject;

        GameUUToggle toggle1 = transform.Find("Image/Toggle").GetComponent<GameUUToggle>();
        toggleGroup.AddToggle(toggle1);
        GameUUToggle toggle2 = transform.Find("Image/Toggle (1)").GetComponent<GameUUToggle>();
        toggleGroup.AddToggle(toggle2);
        GameUUToggle toggle3 = transform.Find("Image/Toggle (2)").GetComponent<GameUUToggle>();
        toggleGroup.AddToggle(toggle3);


    }
}
