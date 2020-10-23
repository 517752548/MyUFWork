using UnityEngine;
using UnityEngine.UI;

public class JiangLiUI : UIMonoBehaviour {

    public GameUUButton closeBtn;
    public TabButtonGroup toggles;
    public JiangLiToggleUI toggleItem;
    public QianDaoUI qianDaoUI;
    public MeiRiZaiXianUI meiRiJiangLiUI;

    public WeeklyRewardUI weeklyRewardUI;
    public LevelRewardUI levelRewardUI;
    public LevelRewardUI VIPlevelRewardUI;
    public QiRiMuBiaoUI qirimubiaoUI;
    public BangpaijingsaijiangliUI jingsaiJiangliUI;
    public FubenJiangliUI fubenJiangliUI;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        toggles=transform.Find("toggles/ScrollRect/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        toggles.Init();
        toggleItem=transform.Find("toggles/ScrollRect/Image/grid/ToggleItem").gameObject.AddComponent<JiangLiToggleUI>();
        toggleItem.Init();

        //qianDaoUI=transform.Find("qiandao").gameObject.AddComponent<QianDaoUI>();
        //qianDaoUI.Init();
        //meiRiJiangLiUI=transform.Find("meirijiangli").gameObject.AddComponent<MeiRiZaiXianUI>();
        //meiRiJiangLiUI.Init();
        //weeklyRewardUI=transform.Find("WeeklyReward").gameObject.AddComponent<WeeklyRewardUI>();
        //weeklyRewardUI.Init();
        //levelRewardUI=transform.Find("LevelReward").gameObject.AddComponent<LevelRewardUI>();
        //levelRewardUI.Init();

        //weeklyRewardUI.gameObject.SetActive(false);
        //meiRiJiangLiUI.gameObject.SetActive(false);
        //levelRewardUI.gameObject.SetActive(false);

    }

}

public class JiangLiToggleUI : MonoBehaviour
{
    public Text toggleText;

    public void Init()
    {
        toggleText = transform.Find("Text").GetComponent<Text>();
    }
}
