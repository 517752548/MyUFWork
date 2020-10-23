using UnityEngine;
using UnityEngine.UI;

public class ChatBiaoQingUI:MonoBehaviour
{
    public TabButtonGroup tbg;

    public GridLayoutGroup biaoqingGrid;
    public BiaoQingItemUI biaoqingItem;

    public GridLayoutGroup daojuGrid;
    public CommonItemUI daojuItem;

    public GridLayoutGroup petGrid;
    public CommonItemUI petItem;

    public PageTurner pageturner;
    public GameUUButton closeBtn;
    public void Init()
    {
        tbg = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle biaoqing = transform.Find("tabGroup/toggles/biaoqing").GetComponent<GameUUToggle>();
        GameUUToggle daoju = transform.Find("tabGroup/toggles/daoju").GetComponent<GameUUToggle>();
        GameUUToggle chongwu = transform.Find("tabGroup/toggles/chongwu").GetComponent<GameUUToggle>();
        tbg.AddToggle(biaoqing);
        tbg.AddToggle(daoju);
        tbg.AddToggle(chongwu);
        biaoqingGrid = transform.Find("biaoqing/grid").gameObject.GetComponent<GridLayoutGroup>();
        daojuGrid = transform.Find("wupin/grid").gameObject.GetComponent<GridLayoutGroup>();
        petGrid = transform.Find("chongwu/grid").gameObject.GetComponent<GridLayoutGroup>();
        biaoqingItem = transform.Find("biaoqing/grid/item").gameObject.AddComponent<BiaoQingItemUI>();
        biaoqingItem.Init();

        daojuItem = transform.Find("wupin/grid/CommonItemUI70_70").gameObject.AddComponent<CommonItemUI>();
        daojuItem.Init();

        petItem = transform.Find("chongwu/grid/CommonItemUI70_70").gameObject.AddComponent<CommonItemUI>();
        petItem.Init();

        pageturner = transform.Find("PageTurner").gameObject.AddComponent<PageTurner>();
        pageturner.Init(pageturner.transform.Find("leftButton").GetComponent<GameUUButton>()
            ,pageturner.transform.Find("rightButton").GetComponent<GameUUButton>(),
        pageturner.transform.Find("Text").GetComponent<Text>());

        closeBtn = transform.Find("closeBtn").gameObject.GetComponent<GameUUButton>();
    }
}

public class BiaoQingItemUI:MonoBehaviour
{
    public GameObject biaoqingIcon;
    public FrameAnimation frameAnim;
    public GameUUButton Button0;
    public void Init()
    {
        Button0 = transform.Find("Button0").GetComponent<GameUUButton>();
        biaoqingIcon = transform.Find("Image").gameObject;
    }
}