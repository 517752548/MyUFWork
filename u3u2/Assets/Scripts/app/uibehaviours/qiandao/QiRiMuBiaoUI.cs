using UnityEngine.UI;

public class QiRiMuBiaoUI:UIMonoBehaviour
{
    public GameUUMask mask;
    public GridLayoutGroup grid;
    public QiRiMuBiaoItemUI itemUI;
    public TabButtonGroup tbg;

    public override void Init()
    {
        base.Init();
        grid = transform.Find("Image_mask/scrollRect/itemGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        itemUI =
            transform.Find("Image_mask/scrollRect/itemGrid/RewardItem")
                .gameObject.AddComponent<QiRiMuBiaoItemUI>();
        itemUI.Init();
        mask = transform.Find("Image_mask").GetComponent<GameUUMask>();
        tbg = grid.gameObject.AddComponent<TabButtonGroup>();

        GameUUToggle toggle1 = transform.Find("ScrollViewHorizon/grid/Toggle (1)").GetComponent<GameUUToggle>();
        GameUUToggle toggle2 = transform.Find("ScrollViewHorizon/grid/Toggle (2)").GetComponent<GameUUToggle>();
        GameUUToggle toggle3 = transform.Find("ScrollViewHorizon/grid/Toggle (3)").GetComponent<GameUUToggle>();
        GameUUToggle toggle4 = transform.Find("ScrollViewHorizon/grid/Toggle (4)").GetComponent<GameUUToggle>();
        GameUUToggle toggle5 = transform.Find("ScrollViewHorizon/grid/Toggle (5)").GetComponent<GameUUToggle>();
        GameUUToggle toggle6 = transform.Find("ScrollViewHorizon/grid/Toggle (6)").GetComponent<GameUUToggle>();
        GameUUToggle toggle7 = transform.Find("ScrollViewHorizon/grid/Toggle (7)").GetComponent<GameUUToggle>();
        tbg.AddToggle(toggle1);
        tbg.AddToggle(toggle2);
        tbg.AddToggle(toggle3);
        tbg.AddToggle(toggle4);
        tbg.AddToggle(toggle5);
        tbg.AddToggle(toggle6);
        tbg.AddToggle(toggle7);

    }
}
