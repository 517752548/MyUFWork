using UnityEngine;
using UnityEngine.UI;

public class PetHuantongUI : UIMonoBehaviour
{
    public ProgressBar qiangzhuang;
    public ProgressBar minjie;
    public ProgressBar zhili;
    public ProgressBar xinyang;
    public ProgressBar naili;

    public CommonItemUINoClick xiaohaoItem;

    public Image xiaohaoIcon1;
    public Text xiaohaoNum1;
    public Image xiahaoIcon2;
    public Text xiaohaoNum2;
    public Text chengzhanglv;

    public GameUUButton huantongBtn;
    public override void Init()
    {
        base.Init();
        GameUIBase uiBase = GetComponent<GameUIBase>();
        //qiangzhuang = transform.Find("GameObject/qiangzhuang/expBar").gameObject.AddComponent<ProgressBar>();
        qiangzhuang = uiBase.gameObjects[0].AddComponent<ProgressBar>();
        qiangzhuang.Init
        (
            //qiangzhuang.transform.Find("background").GetComponent<Image>(),
            //qiangzhuang.transform.Find("background/foreground").GetComponent<Image>(),
            //qiangzhuang.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[0],
            uiBase.images[1],
            uiBase.texts[0],
           324
        );
        //minjie = transform.Find("GameObject/minjie/expBar").gameObject.AddComponent<ProgressBar>();
        minjie = uiBase.gameObjects[1].AddComponent<ProgressBar>();
        minjie.Init
        (
            //minjie.transform.Find("background").GetComponent<Image>(),
            //minjie.transform.Find("background/foreground").GetComponent<Image>(),
            //minjie.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[2],
            uiBase.images[3],
            uiBase.texts[1],
             324
        );
        //zhili = transform.Find("GameObject/zhili/expBar").gameObject.AddComponent<ProgressBar>();
        zhili = uiBase.gameObjects[2].AddComponent<ProgressBar>();
        zhili.Init
        (
            //zhili.transform.Find("background").GetComponent<Image>(),
            //zhili.transform.Find("background/foreground").GetComponent<Image>(),
            //zhili.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[4],
            uiBase.images[5],
            uiBase.texts[2],
            324
        );
        //xinyang = transform.Find("GameObject/xinyang/expBar").gameObject.AddComponent<ProgressBar>();
        xinyang = uiBase.gameObjects[3].AddComponent<ProgressBar>();
        xinyang.Init
        (
            //xinyang.transform.Find("background").GetComponent<Image>(),
            //xinyang.transform.Find("background/foreground").GetComponent<Image>(),
            //xinyang.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[6],
            uiBase.images[7],
            uiBase.texts[3],
           324
        );
        //naili = transform.Find("GameObject/naili/expBar").gameObject.AddComponent<ProgressBar>();
        naili = uiBase.gameObjects[4].AddComponent<ProgressBar>();
        naili.Init
        (
            //naili.transform.Find("background").GetComponent<Image>(),
            //naili.transform.Find("background/foreground").GetComponent<Image>(),
            //naili.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[8],
            uiBase.images[9],
            uiBase.texts[4],
            324
        );
        //xiaohaoItem = transform.Find("ZZCommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        xiaohaoItem = uiBase.gameObjects[5].AddComponent<CommonItemUINoClick>();
        xiaohaoItem.Init
        (
            //xiaohaoItem.transform.Find("Image").GetComponent<Image>(),
            //xiaohaoItem.transform.Find("Icon").GetComponent<Image>(),
            //xiaohaoItem.transform.Find("BianKuang").GetComponent<Image>(),
            //xiaohaoItem.transform.Find("Num").GetComponent<Text>(),
            //xiaohaoItem.transform.Find("Name").GetComponent<Text>(),
            uiBase.images[10],
            uiBase.images[11],
            uiBase.images[12],
            uiBase.texts[5],
            uiBase.texts[6],
            null
        );
        huantongBtn = uiBase.buttons[0];
        //huantongBtn = transform.Find("huantongBtn").GetComponent<GameUUButton>();

        chengzhanglv = uiBase.texts[6];
    }

}
