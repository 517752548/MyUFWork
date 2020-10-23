using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaiMaiHangSellUI : UIMonoBehaviour
{
    public Text myTanWeiLeft;
    public GridLayoutGroup sellList;
    public PaiMaiHangItemUI defaultSellItemUI;

    public ScrollRect rightScrollRect;
    public RectTransform petGrid;
    public PaiMaiHangItemUI defaultPetItemUI;

    public RectTransform daojuGrid;
    public CommonItemUI defaultDaoJuItemUI;

    public TabButtonGroup daojuchongwuTBG;

    public CanvasRenderer leftPanelRenderer;
    public CanvasRenderer rightPanelRenderer;

    public override void Init()
    {
        base.Init();

        leftPanelRenderer = transform.Find("leftPanel/scrollRectCanvas").GetComponent<CanvasRenderer>();
        rightPanelRenderer = transform.Find("rightPanel/scrollRectCanvas").GetComponent<CanvasRenderer>();

        myTanWeiLeft = transform.Find("leftPanel/up/Text").GetComponent<UnityEngine.UI.Text>();
        sellList = transform.Find("leftPanel/scrollRectCanvas/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();

        defaultSellItemUI = transform.Find("leftPanel/scrollRectCanvas/scrollRect/grid/equipItem").gameObject.AddComponent<PaiMaiHangItemUI>();
        MoneyItemUI m1 = defaultSellItemUI.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m1.Init
        (
            m1.transform.Find("Image").GetComponent<Image>(),
            m1.transform.Find("Text").GetComponent<Text>(),
            null
        );

        CommonItemUINoClick c1 = defaultSellItemUI.transform.Find("CommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        c1.Init
        (
            c1.transform.Find("Image").GetComponent<Image>(),
            c1.transform.Find("Icon").GetComponent<Image>(),
            c1.transform.Find("BianKuang").GetComponent<Image>(),
            c1.transform.Find("Num").GetComponent<Text>(),
            //c1.transform.Find("Name").GetComponent<Text>(),
            null,
            null
        );
        defaultSellItemUI.Init
        (
            null,
            null,
            defaultSellItemUI.transform.Find("equipName").GetComponent<Text>(),
            null,
            m1,
            c1
        );

        rightScrollRect = transform.Find("rightPanel/scrollRectCanvas/scrollRect").GetComponent<UnityEngine.UI.ScrollRect>();
        petGrid = transform.Find("rightPanel/scrollRectCanvas/scrollRect/petgrid").GetComponent<UnityEngine.RectTransform>();
        defaultPetItemUI = transform.Find("rightPanel/scrollRectCanvas/scrollRect/petgrid/petItem").gameObject.AddComponent<PaiMaiHangItemUI>();
        defaultPetItemUI.Init
        (
             null,
            defaultPetItemUI.transform.Find("CommonItemUI/Icon").GetComponent<Image>(),
            defaultPetItemUI.transform.Find("petName").GetComponent<Text>(),
            defaultPetItemUI.transform.Find("petLevel").GetComponent<Text>(),
            null,
            null
        );
        daojuGrid = transform.Find("rightPanel/scrollRectCanvas/scrollRect/daojugrid").GetComponent<UnityEngine.RectTransform>();
        defaultDaoJuItemUI = transform.Find("rightPanel/scrollRectCanvas/scrollRect/daojugrid/CommonItemUIWithToggle").gameObject.AddComponent<CommonItemUI>();
        defaultDaoJuItemUI.Init();
        daojuchongwuTBG = transform.Find("rightPanel/daojuPetTbg").gameObject.AddComponent<TabButtonGroup>();
        daojuchongwuTBG.Init();
        daojuchongwuTBG.AddToggle(daojuchongwuTBG.transform.Find("Toggle").GetComponent<GameUUToggle>());
        daojuchongwuTBG.AddToggle(daojuchongwuTBG.transform.Find("Toggle 1").GetComponent<GameUUToggle>());

    }

}
