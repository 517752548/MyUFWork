using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NvNUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public Text panelTitle;
    public GridLayoutGroup paihanggrid;
    public NvNPaiHangListUI defaultPaihang;
    public NvNPaiHangListUI mypaihang;
    public Text myTeamJifen;
    public List<CommonItemUINoClick> myTeamList;
    public Text defenceLianSheng;
    public Text defenceJifen;
    public List<CommonItemUINoClick> defenceTeamList;
    public Text pipeidaojishi;
    public GameUUButton infoBtn;
    public ProgressBar progressbar;
    public GameUUButton zidongpipei;
    public GameUUButton quxiaopipei;

    public Text logText;
    
    public void Init()
     {
    closeBtn=transform.Find("closeBtn").GetComponent<GameUUButton>();
    panelTitle=transform.Find("title").GetComponent<Text>();
    paihanggrid=transform.Find("paihangbang/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
    defaultPaihang=transform.Find("paihangbang/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<NvNPaiHangListUI>();
    defaultPaihang.Init();
    mypaihang=transform.Find("paihangbang/myPaiMing").gameObject.AddComponent<NvNPaiHangListUI>();
    mypaihang.Init();
    myTeamJifen=transform.Find("myteam/duiwujifen").GetComponent<UnityEngine.UI.Text>();
    myTeamList=new List<CommonItemUINoClick>();
    CommonItemUINoClick mc1 = transform.Find("myteam/grid/CommonItemUINoClick70_70").gameObject.AddComponent<CommonItemUINoClick>();
    mc1.Init(
        mc1.transform.Find("Image").GetComponent<Image>(),
        mc1.transform.Find("Icon").GetComponent<Image>(),
        mc1.transform.Find("BianKuang").GetComponent<Image>(),
        mc1.transform.Find("Num").GetComponent<Text>(),
        mc1.transform.Find("Name").GetComponent<Text>(),
        null
    );
    CommonItemUINoClick mc2 = transform.Find("myteam/grid/CommonItemUINoClick70_70 (1)").gameObject.AddComponent<CommonItemUINoClick>();
    mc2.Init(
        mc2.transform.Find("Image").GetComponent<Image>(),
        mc2.transform.Find("Icon").GetComponent<Image>(),
        mc2.transform.Find("BianKuang").GetComponent<Image>(),
        mc2.transform.Find("Num").GetComponent<Text>(),
        mc2.transform.Find("Name").GetComponent<Text>(),
        null
    );
    CommonItemUINoClick mc3 = transform.Find("myteam/grid/CommonItemUINoClick70_70 (2)").gameObject.AddComponent<CommonItemUINoClick>();
    mc3.Init(
        mc3.transform.Find("Image").GetComponent<Image>(),
        mc3.transform.Find("Icon").GetComponent<Image>(),
        mc3.transform.Find("BianKuang").GetComponent<Image>(),
        mc3.transform.Find("Num").GetComponent<Text>(),
        mc3.transform.Find("Name").GetComponent<Text>(),
        null
    );
    CommonItemUINoClick mc4 = transform.Find("myteam/grid/CommonItemUINoClick70_70 (3)").gameObject.AddComponent<CommonItemUINoClick>();
    mc4.Init(
        mc4.transform.Find("Image").GetComponent<Image>(),
        mc4.transform.Find("Icon").GetComponent<Image>(),
        mc4.transform.Find("BianKuang").GetComponent<Image>(),
        mc4.transform.Find("Num").GetComponent<Text>(),
        mc4.transform.Find("Name").GetComponent<Text>(),
        null
    );
    CommonItemUINoClick mc5 = transform.Find("myteam/grid/CommonItemUINoClick70_70 (4)").gameObject.AddComponent<CommonItemUINoClick>();
    mc5.Init(
        mc5.transform.Find("Image").GetComponent<Image>(),
        mc5.transform.Find("Icon").GetComponent<Image>(),
        mc5.transform.Find("BianKuang").GetComponent<Image>(),
        mc5.transform.Find("Num").GetComponent<Text>(),
        mc5.transform.Find("Name").GetComponent<Text>(),
        null
    );
    myTeamList.Add(mc1);
    myTeamList.Add(mc2);
    myTeamList.Add(mc3);
    myTeamList.Add(mc4);
    myTeamList.Add(mc5);
    
    
    defenceJifen=transform.Find("pipeiteam/duiwujifen").GetComponent<UnityEngine.UI.Text>();
    
    defenceTeamList=new List<CommonItemUINoClick>();
    CommonItemUINoClick c1 = transform.Find("pipeiteam/grid/CommonItemUINoClick70_70").gameObject.AddComponent<CommonItemUINoClick>();
    c1.Init();
    CommonItemUINoClick c2 = transform.Find("pipeiteam/grid/CommonItemUINoClick70_70 (1)").gameObject.AddComponent<CommonItemUINoClick>();
    c2.Init();
    CommonItemUINoClick c3 = transform.Find("pipeiteam/grid/CommonItemUINoClick70_70 (2)").gameObject.AddComponent<CommonItemUINoClick>();
    c3.Init();
    CommonItemUINoClick c4 = transform.Find("pipeiteam/grid/CommonItemUINoClick70_70 (3)").gameObject.AddComponent<CommonItemUINoClick>();
    c4.Init();
    CommonItemUINoClick c5 = transform.Find("pipeiteam/grid/CommonItemUINoClick70_70 (4)").gameObject.AddComponent<CommonItemUINoClick>();
    c5.Init();
    defenceTeamList.Add(c1);
    defenceTeamList.Add(c2);
    defenceTeamList.Add(c3);
    defenceTeamList.Add(c4);
    defenceTeamList.Add(c5);

    
    pipeidaojishi=transform.Find("daojishi").GetComponent<Text>();
    infoBtn=transform.Find("infoBtn").GetComponent<GameUUButton>();
    progressbar=transform.Find("progressbar").gameObject.AddComponent<ProgressBar>();
    progressbar.Init
    (   
        progressbar.transform.Find("background").GetComponent<Image>(), 
        progressbar.transform.Find("background/foreground").GetComponent<Image>(),
        progressbar.transform.Find("Text").GetComponent<Text>(),
        201
    );
    zidongpipei=transform.Find("kaishipipei").GetComponent<GameUUButton>();
    quxiaopipei=transform.Find("quxiaopipei").GetComponent<GameUUButton>();
    logText=transform.Find("ScrollViewVertical/Text").GetComponent<UnityEngine.UI.Text>();

        }
    
}
