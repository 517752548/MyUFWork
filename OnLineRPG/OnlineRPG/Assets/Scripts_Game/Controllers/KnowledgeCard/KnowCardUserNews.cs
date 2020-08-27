using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KnowCardUserNews : MonoBehaviour
{
    // Start is called before the first frame update
    public Image userHeadIcon;
    public Text userNameText;
    public Text userPostText;
    public TextMeshProUGUI fanText;
    private List<LocalKnowledgeCard> _knowledgeCards;

    public void Start()
    {
        initUserData();
    }

    private void initUserData()
    {
        userPostText.text = DataManager.PlayerData.KnowledgeCards.Value.allCards.Count + " posts";
        
        int fansCount = AppEngine.SyncManager.Data.fansNumber.Value;
        fanText.text = XUtils.GetFormatFans(fansCount);
    }
}
