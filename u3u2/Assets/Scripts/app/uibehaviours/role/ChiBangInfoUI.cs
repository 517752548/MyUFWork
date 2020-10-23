using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChiBangInfoUI : UIMonoBehaviour
{

    public TabButtonGroup chibangTBG;
    public CommonItemUI defaultChiBangItem;
    public GridLayoutGroup chibangItemGrid;
    public Text jieshu;
    public Text chibangName;
    public Text zhandouli;
    public GameObject modelContainer;
    public GameUUButton useBtn;
    public ProgressBar zhufuzhiPg;
    public Text jinjieCostText;
    public MoneyItemUI jinjieCost;
    public GameUUButton jinjieBtn;
    public GameUUToggle autoBuyToggle;
    public List<Text> benjiePropList;
    public List<Text> xiajiePropList;
    public GameObject jinjieContent;
    public GameObject shangxianGo;

    public void Init()
    {
        base.Init();
        chibangTBG = transform.Find("ScrollViewVertical").gameObject.AddComponent<TabButtonGroup>();
        chibangTBG.Init();
        defaultChiBangItem = transform.Find("ScrollViewVertical/grid/CommonItemUIWithToggle70_70").gameObject.AddComponent<CommonItemUI>();
        defaultChiBangItem.Init();
        chibangItemGrid = transform.Find("ScrollViewVertical/grid").GetComponent<GridLayoutGroup>();
        jieshu = transform.Find("jieshu").GetComponent<Text>();
        chibangName = transform.Find("Image (6)/mingcheng").GetComponent<Text>();
        zhandouli = transform.Find("zhandouli").GetComponent<Text>();
        modelContainer = transform.Find("modelContainer").gameObject;
        useBtn = transform.Find("useBtn").GetComponent<GameUUButton>();
        zhufuzhiPg = transform.Find("jinjieContent/zhufuzhiPg").gameObject.AddComponent<ProgressBar>();
        zhufuzhiPg.Init
        (
            zhufuzhiPg.transform.Find("background").GetComponent<Image>(),
            zhufuzhiPg.transform.Find("background/foreground").GetComponent<Image>(),
            zhufuzhiPg.transform.Find("Text").GetComponent<Text>(), 324
        );
        jinjieCostText = transform.Find("jinjieContent/xiaohao/mingcheng").GetComponent<Text>();

        jinjieCost = transform.Find("jinjieContent/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        Image moneyImg = transform.Find("jinjieContent/MoneyItem/Image").GetComponent<Image>();
        Text text = transform.Find("jinjieContent/MoneyItem/Text").GetComponent<Text>();
        jinjieCost.Init(moneyImg, text, null);

        jinjieBtn = transform.Find("jinjieContent/jinjieBtn").GetComponent<GameUUButton>();
        autoBuyToggle = transform.Find("jinjieContent/Toggle").GetComponent<GameUUToggle>();
        benjiePropList = new List<Text>();
        Text jieText1 = transform.Find("ScrollViewVertical (1)/grid/jieshu (1)").GetComponent<Text>();
        benjiePropList.Add(jieText1);
        Text jieText2 = transform.Find("ScrollViewVertical (1)/grid/jieshu (2)").GetComponent<Text>();
        benjiePropList.Add(jieText2);
        Text jieText3 = transform.Find("ScrollViewVertical (1)/grid/jieshu (3)").GetComponent<Text>();
        benjiePropList.Add(jieText3);
        Text jieText4 = transform.Find("ScrollViewVertical (1)/grid/jieshu (4)").GetComponent<Text>();
        benjiePropList.Add(jieText4);
        Text jieText5 = transform.Find("ScrollViewVertical (1)/grid/jieshu (5)").GetComponent<Text>();
        benjiePropList.Add(jieText5);
        Text jieText6 = transform.Find("ScrollViewVertical (1)/grid/jieshu (6)").GetComponent<Text>();
        benjiePropList.Add(jieText6);
        xiajiePropList = new List<Text>();
        Text xiajieText1 = transform.Find("ScrollViewVertical (2)/grid/jieshu (1)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText1);
        Text xiajieText2 = transform.Find("ScrollViewVertical (2)/grid/jieshu (2)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText2);
        Text xiajieText3 = transform.Find("ScrollViewVertical (2)/grid/jieshu (3)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText3);
        Text xiajieText4 = transform.Find("ScrollViewVertical (2)/grid/jieshu (4)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText4);
        Text xiajieText5 = transform.Find("ScrollViewVertical (2)/grid/jieshu (5)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText5);
        Text xiajieText6 = transform.Find("ScrollViewVertical (2)/grid/jieshu (6)").GetComponent<Text>();
        xiajiePropList.Add(xiajieText6);

        jinjieContent = transform.Find("jinjieContent").gameObject;
        shangxianGo = transform.Find("shangxian").gameObject;

        shangxianGo.gameObject.SetActive(false);

    }
}
