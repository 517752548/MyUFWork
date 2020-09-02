using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagazingBook : MonoBehaviour
{
    public GameObject _new;
    public GameObject _finished;
    public GameObject _reward;
    public TextMeshProUGUI _vol;
    public Image _rewardImage;
    public TextMeshProUGUI _rewardNum;
    private MagazineDialog _magazineDialog;

    private EliteWorld elitedata;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetEliteData(MagazineDialog _magazineDialog, EliteWorld elitedata)
    {
        this._magazineDialog = _magazineDialog;
        this.elitedata = elitedata;
        RefreshUI();
    }

    public void RefreshUI()
    {
        _vol.text = string.Format("Vol.{0}", elitedata.id);
        ElitePref edata = AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(elitedata.id);
        if (!edata.levelStatus.Contains("0") && edata.levelStatus.Contains("1"))
        {
            _finished.SetActive(true);
        }
        else
        {
            _finished.SetActive(false);
        }

        _new.SetActive(elitedata.isNew);
        int currentStar = 0;
        for (int i = 0; i < edata.levelStatus.Length; i++)
        {
            if (edata.levelStatus[i].Equals('2'))
            {
                currentStar += CommUtil.GetLevelStar(elitedata.stars[i]);
            }
        }

        if (currentStar >= AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock3 && edata.rewardStatus[2].Equals('0'))
        {
            if (edata.rewardStatus[2].Equals('0'))
            {
                string[] rewardlist = elitedata.reward3.Split(',');
                _rewardNum.text = string.Format("+{0}", rewardlist[1]);
                BagItems_Data item = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(rewardlist[0]);
                if (item != null)
                {
                    ResourceManager
                            .LoadAsync<Sprite>(item.Sprite + ".png",
                        op => { _rewardImage.sprite = op; });
                }
            }
            else
            {
                _reward.SetActive(false);
            }
        }else if (currentStar >= AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock2 && edata.rewardStatus[1].Equals('0'))
        {
            if (edata.rewardStatus[1].Equals('0'))
            {
                string[] rewardlist = elitedata.reward2.Split(',');
                _rewardNum.text = string.Format("+{0}", rewardlist[1]);
                BagItems_Data item = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(rewardlist[0]);
                if (item != null)
                {
                    ResourceManager
                            .LoadAsync<Sprite>(item.Sprite + ".png",
                        op => { _rewardImage.sprite = op; });
                }
            }
            else
            {
                _reward.SetActive(false);
            }
        }
        else if (currentStar >= AppEngine.SSystemManager.GetSystem<EliteSystem>().currentConfig.data.init.unlock1 && edata.rewardStatus[0].Equals('0'))
        {
            if (edata.rewardStatus[0].Equals('0'))
            {
                string[] rewardlist = elitedata.reward1.Split(',');
                _rewardNum.text = string.Format("+{0}", rewardlist[1]);
                BagItems_Data item = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(rewardlist[0]);
                if (item != null)
                {
                    ResourceManager
                            .LoadAsync<Sprite>(item.Sprite + ".png",
                        op => { _rewardImage.sprite = op; });
                }
            }
            else
            {
                _reward.SetActive(false);
            }
        }
        else
        {
            _reward.SetActive(false);
        }
    }

    public void ClickBook()
    {
        AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID = elitedata.id;
        _magazineDialog.Close();
        UIManager.OpenUIAsync(ViewConst.prefab_HappinessSelectLevelDialog, null);
    }
}