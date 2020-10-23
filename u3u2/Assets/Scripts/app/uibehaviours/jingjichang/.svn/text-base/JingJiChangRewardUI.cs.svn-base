using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JingJiChangRewardUI : MonoBehaviour
{

    public GameUUButton closeBtn;
    public Text curPaiming;
    public Text peimingduan;
    public JingJiChangRewardItemUI myRewardItem;
    public GridLayoutGroup rewardGrid;
    public JingJiChangRewardItemUI defaultItem;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();

        Transform tfPaiming = transform.Find("Image/paimingtext");
        if (tfPaiming)
        {
              curPaiming=tfPaiming.GetComponent<UnityEngine.UI.Text>();
        }
      
        peimingduan=transform.Find("dangqianPaiMing").GetComponent<UnityEngine.UI.Text>();
        myRewardItem = transform.Find("defaultRewardItem").gameObject.AddComponent<JingJiChangRewardItemUI>();
        myRewardItem.Init();
        rewardGrid=transform.Find("ScrollViewVertical /grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultItem=transform.Find("ScrollViewVertical /grid/jiangliItem").gameObject.AddComponent<JingJiChangRewardItemUI>();
        defaultItem.Init();


    }

}
