using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CupLifeItem : MonoBehaviour
{


    public GameObject[] rankObj;
    public TextMeshProUGUI RankText;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI playerName;

    public Photo playerphoto;
    public GameObject reward;
    public Image rewareImage;
    public TextMeshProUGUI rewardNum;

    public GameObject top3Reward;
    public TextMeshProUGUI top3rewardText;
    public GameObject hasGetIcon;
    private RankListInfo info;

    // Use this for initialization
    void Start()
    {

    }

    public void SetPlayerInfo(RankListInfo info)
    {
        this.info = info;
        if (info.rank < 4 && info.rank >= 0)
        {
            rankObj[info.rank - 1].SetActive(true);
        }
        else
        {
            RankText.text = info.rank.ToString();
        }

        ScoreText.text = info.score.ToString();
        if (info.passportId == AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value)
        {
            //我自己
            //info.headImg = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerHeadUrl();
            if (!string.IsNullOrEmpty(AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value))
            {
                playerName.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
            }
            else
            {
                playerName.text = "Player";
            }

        }
        else
        {
            playerName.text = info.name;
        }

        if (info.rewardId > 0 && info.rewardNum > 0)
        {
            if (info.passportId == AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value)
            {
                if (info.type != 0 && info.rewardId > 0 && info.rewardNum > 0)
                {
                    hasGetIcon.SetActive(true);
                }
            }
            if (info.rank < 4 && info.rewardId == 10)
            {
                top3rewardText.text = info.rewardNum.ToString();
                top3Reward.SetActive(true);
                top3Reward.transform.GetChild(info.rank - 1).gameObject.SetActive(true);
                reward.SetActive(false);
            }
            else
            {
                reward.SetActive(true);
                BagItems_Data item = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                    .GetTarget(info.rewardId.ToString());
                if (item != null)
                {
                    ResourceManager
                        .LoadAsync<Sprite>(item.Sprite + ".png",
                        op =>
                        {
                            rewareImage.sprite = op;
                        });
                    rewardNum.text = string.Format("x{0}", info.rewardNum);
                }
                else
                {
                    reward.SetActive(false);
                }
            }

        }
        else
        {
            reward.SetActive(false);
        }
        playerphoto.url = info.headImg;
        playerphoto.Load(info.passportId == AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value);
    }

    public void SetFadeRank(int rank)
    {
        for (int i = 0; i < rankObj.Length; i++)
        {
            rankObj[i].SetActive(false);
        }
        if (rank < 4 && rank >= 0)
        {
            rankObj[rank - 1].SetActive(true);
        }
        else
        {
            RankText.text = rank.ToString();
        }
    }

}
