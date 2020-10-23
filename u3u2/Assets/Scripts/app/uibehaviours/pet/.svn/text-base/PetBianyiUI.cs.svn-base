using UnityEngine;
using UnityEngine.UI;

public class PetBianyiUI : UIMonoBehaviour
{
    public Text zhuangtai;
    public CommonItemUINoClick xiaohaoItem;
    public Image xiaohaoImg1;
    public Text xiaohaoNum1;
    public Image xiaohaoImg2;
    public Text xiaohaoNum2;
    public GameUUButton bianyiBtn;
    public GameUUButton bianyi10Btn;
    public GameObject weibianyidis;
    public GameObject yibianyidis;
    //public GameObject yibianyi1dis;
    public override void Init()
    {
        base.Init();
        GameUIBase uiBase = GetComponent<GameUIBase>();
        xiaohaoItem = uiBase.gameObjects[0].AddComponent<CommonItemUINoClick>();
        //xiaohaoItem=transform.Find("weibianyi/xiaohao").gameObject.AddComponent<CommonItemUINoClick>();
        xiaohaoItem.Init(uiBase.images[0], uiBase.images[1], uiBase.images[2], uiBase.texts[0], uiBase.texts[1], null);
        /*
        xiaohaoItem.transform.Find("Image").GetComponent<Image>(),
        xiaohaoItem.transform.Find("Icon").GetComponent<Image>(),
        xiaohaoItem.transform.Find("BianKuang").GetComponent<Image>(),
        xiaohaoItem.transform.Find("Num").GetComponent<Text>(),
        xiaohaoItem.transform.Find("Name").GetComponent<Text>(),
        null
        */
        //bianyiBtn = transform.Find("weibianyi/bianyiBtn").GetComponent<GameUUButton>();
        bianyiBtn = uiBase.buttons[0];
        //bianyi10Btn = transform.Find("weibianyi/bianyi10Btn").GetComponent<GameUUButton>();
        bianyi10Btn = uiBase.buttons[1];
        //weibianyidis = transform.Find("weibianyi").gameObject;
        weibianyidis = uiBase.gameObjects[1];
        //yibianyidis = transform.Find("yibianyi").gameObject;
        yibianyidis = uiBase.gameObjects[2];

    }

}
