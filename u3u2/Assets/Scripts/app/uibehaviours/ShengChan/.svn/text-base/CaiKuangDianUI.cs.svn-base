using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CaiKuangDianUI : MonoBehaviour
{
    public Text kuangdianName;
    public GameUUToggle leibieToggle;
    public Text leibieNameText;
    public DropDownMenu leibieDropDownMenu;

    public GameUUToggle shijianToggle;
    public Text shijianNameText;
    public DropDownMenu shijianDropDownMenu;

    public GameUUToggle xuanzekuanggongToggle;
    public GameObject kuanggongListGo;
    public Image kuanggongIcon;
    public Text kuanggongNameText;
    public TabButtonGroup kuanggongTBG;
    public GridLayoutGroup kuanggongGrid;
    public CaiKuangFriendItem defaultKuanggongItem;

    public GameObject huoliGo;
    public GameObject daojishiGo;
    public Text huolinameText;
    public Text daojishiText;
    public Text daojishiLabel;
    public GameUUButton kaishiCaiKuangBtn;
    public GameUUButton shouquBtn;

    public void Init()
    {
        kuangdianName = transform.Find("Image 1/Text").GetComponent<Text>();
        leibieToggle = transform.Find("leibie/Toggle").GetComponent<GameUUToggle>();
        leibieNameText = transform.Find("leibie/Name").GetComponent<Text>();

        {
            leibieDropDownMenu = transform.Find("leibie").gameObject.AddComponent<DropDownMenu>();
            TabButtonGroup tbGroup =
              leibieDropDownMenu.transform.Find("leibieList").gameObject.AddComponent<TabButtonGroup>();
            ToggleWithText toggleWithText = leibieDropDownMenu.transform.Find("leibieList/Image/scrollview/grid/kuangItem").gameObject.AddComponent<ToggleWithText>();
            toggleWithText.Init(toggleWithText.GetComponent<GameUUToggle>(), toggleWithText.transform.Find("name").GetComponent<Text>());
            leibieDropDownMenu.Init(
                leibieDropDownMenu.transform.Find("Toggle").GetComponent<GameUUToggle>(),
                leibieDropDownMenu.transform.Find("Name").GetComponent<Text>(),
                leibieDropDownMenu.transform.Find("leibieList").gameObject,
                tbGroup,
                leibieDropDownMenu.transform.Find("leibieList/Image/scrollview/grid").GetComponent<GridLayoutGroup>(),
                toggleWithText
                );
        }
        leibieDropDownMenu.TouchUpClose = false;

        shijianToggle = transform.Find("shijian/Toggle").GetComponent<GameUUToggle>();
        shijianNameText = transform.Find("shijian/Name").GetComponent<Text>();
        shijianDropDownMenu = transform.Find("shijian").gameObject.AddComponent<DropDownMenu>();
        TabButtonGroup tbGroup1 =
       shijianDropDownMenu.transform.Find("shijianList").gameObject.AddComponent<TabButtonGroup>();
        ToggleWithText toggleWithText1 = shijianDropDownMenu.transform.Find("shijianList/Image/scrollview/grid/friendItem").gameObject.AddComponent<ToggleWithText>();
        toggleWithText1.Init(toggleWithText1.GetComponent<GameUUToggle>(), toggleWithText1.transform.Find("name").GetComponent<Text>());

        shijianDropDownMenu.Init(
            shijianDropDownMenu.transform.Find("Toggle").GetComponent<GameUUToggle>(),
            shijianDropDownMenu.transform.Find("Name").GetComponent<Text>(),
            shijianDropDownMenu.transform.Find("shijianList").gameObject,
            tbGroup1,
            shijianDropDownMenu.transform.Find("shijianList/Image/scrollview/grid").GetComponent<GridLayoutGroup>(),
            toggleWithText1);
        shijianDropDownMenu.TouchUpClose = false;
        xuanzekuanggongToggle = transform.Find("friendList/Toggle").GetComponent<GameUUToggle>();
        kuanggongListGo = transform.Find("friendList/friendList").gameObject;
        kuanggongIcon = transform.Find("friendList/Icon").GetComponent<Image>();
        kuanggongNameText = transform.Find("friendList/Name").GetComponent<Text>();
        kuanggongTBG = transform.Find("friendList/friendList/Image/scrollview/grid").gameObject.AddComponent<TabButtonGroup>();

        kuanggongGrid = transform.Find("friendList/friendList/Image/scrollview/grid").GetComponent<GridLayoutGroup>();
        defaultKuanggongItem = transform.Find("friendList/friendList/Image/scrollview/grid/friendItem").gameObject.AddComponent<CaiKuangFriendItem>();
        defaultKuanggongItem.Init();
        huoliGo = transform.Find("xuyaohuoli").gameObject;
        daojishiGo = transform.Find("daojishi").gameObject;
        huolinameText = transform.Find("xuyaohuoli/Text").GetComponent<Text>();
        daojishiText = transform.Find("daojishi/daojishi").GetComponent<Text>();
        daojishiLabel = transform.Find("daojishi/Text 3").GetComponent<Text>();
        kaishiCaiKuangBtn = transform.Find("kaishi").GetComponent<GameUUButton>();
        shouquBtn = transform.Find("shouqu").GetComponent<GameUUButton>();
        kuanggongListGo.gameObject.SetActive(false);
        kuanggongIcon.gameObject.SetActive(false);
        huoliGo.gameObject.SetActive(false);



    }


}
