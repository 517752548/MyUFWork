using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleInfoUI : UIMonoBehaviour
{
    public GameObject RoleInfoLeftGo;
    public GameObject RoleInfoRightGo;

    public Text roleLevel;
    public Text roleName;
    public Text roleChengHao;
    public GameUUButton UpChengHaoBtn;

    public ProgressBar ShengMingPB;
    public ProgressBar FaLiPB;
    public ProgressBar NuQiPB;
    public ProgressBar HuoLiPB;
    //public GameUUButton useHuoli;
    public DropDownMenu huoliDropDown;
    public Text zhiye;
    public Text xingbie;
    public Text bangpai;
    public Text shengwang;

	public ProgressBar shengmingCunchu;
    public GameUUButton addShengMing;

	public ProgressBar faliCunchu;
    public GameUUButton addFaLi;

    public ProgressBar ShouMingChi;
    public GameUUButton addShouMing;
    public ProgressBar Exp;
    public GameUUButton expHelp;
    public GameObject modelContainer;

    //public GameObject objUseHuoli;
    //public Transform tfUseHuoliItemGrid;
    //public UseHuoliItemUI defaultUseHuoliItemUI;

    public override void Init()
    {
        base.Init();
        RoleInfoLeftGo = transform.Find("leftPanel").gameObject;
        RoleInfoRightGo = transform.Find("rightPanel").gameObject;
        roleLevel = transform.Find("leftPanel/Image 2/Level").GetComponent<Text>();
        roleName = transform.Find("leftPanel/Image 2/Name").GetComponent<Text>();
        roleChengHao = transform.Find("leftPanel/chenghao/ChengHao").GetComponent<Text>();
        UpChengHaoBtn = transform.Find("leftPanel/chenghao/UpChengHaoBtn").GetComponent<GameUUButton>();
        ShengMingPB = transform.Find("rightPanel/life").gameObject.AddComponent<ProgressBar>();
        ShengMingPB.Init
        (
            ShengMingPB.transform.Find("background").GetComponent<Image>(), 
            ShengMingPB.transform.Find("foreground").GetComponent<Image>(),
            ShengMingPB.transform.Find("Text").GetComponent<Text>(), 325
        );
        FaLiPB = transform.Find("rightPanel/fali").gameObject.AddComponent<ProgressBar>();
        FaLiPB.Init
        (
            FaLiPB.transform.Find("background").GetComponent<Image>(), 
            FaLiPB.transform.Find("foreground").GetComponent<Image>(),
            FaLiPB.transform.Find("Text").GetComponent<Text>(), 325
        );
        NuQiPB = transform.Find("rightPanel/nuqi").gameObject.AddComponent<ProgressBar>();
        NuQiPB.Init
        (
            NuQiPB.transform.Find("background").GetComponent<Image>(), 
            NuQiPB.transform.Find("foreground").GetComponent<Image>(),
            NuQiPB.transform.Find("Text").GetComponent<Text>(), 325
        );
        HuoLiPB = transform.Find("rightPanel/huoli").gameObject.AddComponent<ProgressBar>();
        HuoLiPB.Init
        (
            HuoLiPB.transform.Find("background").GetComponent<Image>(), 
            HuoLiPB.transform.Find("foreground").GetComponent<Image>(),
            HuoLiPB.transform.Find("Text").GetComponent<Text>(), 200, 1
        );

        bangpai = transform.Find("leftPanel/bangpai").GetComponent<Text>();
        shengwang = transform.Find("leftPanel/shengwang").GetComponent<Text>();

        shengmingCunchu = transform.Find("rightPanel/info/Image/lifeCunchu").gameObject.AddComponent<ProgressBar>();
        shengmingCunchu.Init
        (
            shengmingCunchu.transform.Find("background").GetComponent<Image>(), 
            shengmingCunchu.transform.Find("background/foreground").GetComponent<Image>(),
            shengmingCunchu.transform.Find("Text").GetComponent<Text>(), 266
        );
        addShengMing = transform.Find("rightPanel/info/Image/lifeCunchu/AddLife").GetComponent<GameUUButton>();
        faliCunchu = transform.Find("rightPanel/info/Image/faliCunchu").gameObject.AddComponent<ProgressBar>();
        faliCunchu.Init
        (
            faliCunchu.transform.Find("background").GetComponent<Image>(), 
            faliCunchu.transform.Find("background/foreground").GetComponent<Image>(),
            faliCunchu.transform.Find("Text").GetComponent<Text>(), 266
        );
        addFaLi = transform.Find("rightPanel/info/Image/faliCunchu/AddFali").GetComponent<GameUUButton>();
        ShouMingChi = transform.Find("rightPanel/info/Image/shoumingCunchu").gameObject.AddComponent<ProgressBar>();
        ShouMingChi.Init
        (
            ShouMingChi.transform.Find("background").GetComponent<Image>(), 
            ShouMingChi.transform.Find("background/foreground").GetComponent<Image>(),
            ShouMingChi.transform.Find("Text").GetComponent<Text>(), 266
        );
        addShouMing = transform.Find("rightPanel/info/Image/shoumingCunchu/AddShouming").GetComponent<GameUUButton>();
        Exp = transform.Find("rightPanel/exp/expBar").gameObject.AddComponent<ProgressBar>();
        Exp.Init
        (
            Exp.transform.Find("background").GetComponent<Image>(), 
            Exp.transform.Find("background/foreground").GetComponent<Image>(),
            Exp.transform.Find("Text").GetComponent<Text>(), 288
        );
        expHelp = transform.Find("rightPanel/exp/expShuoming").GetComponent<GameUUButton>();
        modelContainer = transform.Find("leftPanel/modelContainerBg/modelContainer").gameObject;

        //useHuoli = transform.Find("rightPanel/useBtn").GetComponent<GameUUButton>();
        //objUseHuoli = transform.Find("rightPanel/useHuoli").gameObject;
        huoliDropDown = transform.Find("rightPanel/useDropMenu").gameObject.AddComponent<DropDownMenu>();
        huoliDropDown.Init();

        //tfUseHuoliItemGrid = transform.Find("rightPanel/useHuoli/scrollRect/itemGrid");
        //defaultUseHuoliItemUI = transform.Find("rightPanel/useHuoli/scrollRect/itemGrid/RewardItem").gameObject.AddComponent<UseHuoliItemUI>();
        //defaultUseHuoliItemUI.Init();

        shengwang.gameObject.SetActive(false);

    }


}
