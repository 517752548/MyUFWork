using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QichongLeftInfoUI : MonoBehaviour {

    public GameUUButton petRenameBtn;
    public Text textName;
    public Text textLevel;
    public Transform tfQiCheng;
    public GridLayoutGroup qichongGrid;
    public CommonItemUI defaultQichongItem;
    public TabButtonGroup petListTBG;
    public ProgressBar expProgress;
    public GameObject shengjiEffect;
    public GameObject modelContainer;
    public GameObject objPutong;
    public GameObject objYouxiu;
    public GameObject objJiechu;
    public GameObject objZhuoyue;
    public GameObject objChaofan;
    public GameObject objWanmei;

    public GameObject bindtag;
    public GameObject nobindtag;

    public void Init()
    {
        petRenameBtn = transform.Find("changeNameBtn").GetComponent<GameUUButton>();
        textName = transform.Find("Image/Text").GetComponent<Text>();
        textLevel = transform.Find("Image/level").GetComponent<Text>();
        tfQiCheng = transform.Find("qicheng");
        qichongGrid = transform.Find("petList/Image/scrollRect/grid").GetComponent<GridLayoutGroup>();
        petListTBG = qichongGrid.gameObject.AddComponent<TabButtonGroup>();
        petListTBG.Init();
        defaultQichongItem = transform.Find("petList/Image/scrollRect/grid/CommonItemUIWithToggle70_70").gameObject.AddComponent<CommonItemUI>();
        defaultQichongItem.Init();
        expProgress = transform.Find("exp/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        expProgress.Init
        (
            expProgress.transform.Find("background").GetComponent<Image>(),
            expProgress.transform.Find("background/foreground").GetComponent<Image>(),
            expProgress.transform.Find("Text").GetComponent<Text>(),
            277
        );
        shengjiEffect = transform.Find("modelContainer/shengji_chongwu").gameObject;
        shengjiEffect.SetActive(false);
        modelContainer = transform.Find("modelContainer").gameObject;
        objPutong = transform.Find("qualitys/putong").gameObject;
        objYouxiu = transform.Find("qualitys/youxiu").gameObject;
        objJiechu = transform.Find("qualitys/jiechu").gameObject;
        objZhuoyue = transform.Find("qualitys/zhuoyue").gameObject;
        objChaofan = transform.Find("qualitys/chaofan").gameObject;
        objWanmei = transform.Find("qualitys/wanmei").gameObject;

        bindtag = transform.Find("bindTag").gameObject;
        nobindtag = transform.Find("nobindTag").gameObject;
    }
}
