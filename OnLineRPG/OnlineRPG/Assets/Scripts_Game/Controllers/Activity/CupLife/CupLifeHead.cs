using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CupLifeHead : MonoBehaviour
{
    public Transform star;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textbg;

    private bool canclick = true;

    // Start is called before the first frame update
    void Start()
    {
        text.text = DataManager.FastRaceData.Score.ToString();
        textbg.text = DataManager.FastRaceData.Score.ToString();
    }

    public void ClickHeadBtn()
    {
        if (canclick == false)
        {
            return;
        }

        canclick = false;
        TimersManager.SetTimer(0.5f, () => { canclick = true; });
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value <
            DataManager.FastRaceData.RepFastRaceConfigPacketData.level)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_CommonNotice_Level, null,
                string.Format("Level {0}",
                    DataManager.FastRaceData.RepFastRaceConfigPacketData.level));
            return;
        }

        if (Application.internetReachability == NetworkReachability.NotReachable) //没网的情况直接不显示广告
        {
            UIManager.OpenUIAsync(ViewConst.prefab_NetConnectFailDialog, null, null);
            BetaFramework.LoggerHelper.Log("reward video invalid - no net");
            return;
        }

        if (DataManager.FastRaceData.Score > 0)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_WeekRankListDialog);
            return;
        }

        UIManager.OpenUIAsync(ViewConst.prefab_WeekendPropagandaDialog);
    }

    public void DoAnim()
    {
        text.text = DataManager.FastRaceData.Score.ToString();
        textbg.text = DataManager.FastRaceData.Score.ToString();
    }
}