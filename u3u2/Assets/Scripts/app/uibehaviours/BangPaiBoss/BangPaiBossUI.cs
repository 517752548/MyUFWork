using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiBossUI : MonoBehaviour 
{
    public Text text_title;
    public GameUUButton closeBtn;
    public Text text_bossReward;
    public GameUUButton btn_leftArrow;
    public GameUUButton btn_rightArrow;
    public GameUUButton btn_enterGame;
    public BangPaiBossItemUI[] bossItems;

    public void Init()
    {
        text_title = transform.Find("text_title").GetComponent<Text>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        text_bossReward = transform.Find("Text_bossReward_content").GetComponent<Text>();
        btn_leftArrow = transform.Find("Btn_leftArrow").GetComponent<GameUUButton>();
        btn_rightArrow = transform.Find("Btn_rightArrow").GetComponent<GameUUButton>();
        btn_enterGame = transform.Find("Button_enterBattle").GetComponent<GameUUButton>();
        bossItems = new BangPaiBossItemUI[5];


        for (int i = 0; i < bossItems.Length; i++)
        {
            string bossItemName = "BossItem_" + (i + 1);
            BangPaiBossItemUI itemUI = transform.Find("Image/"+bossItemName).gameObject.AddComponent<BangPaiBossItemUI>();
            itemUI.Init();
            bossItems[i] = itemUI;
        }


    }

}
