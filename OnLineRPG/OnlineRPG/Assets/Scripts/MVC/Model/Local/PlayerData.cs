using BetaFramework;
using EventUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerData : IData
{

	//记录玩家应该得到的箱子，防止丢失
	public RecordExtra.StringPrefData playerGetSubWorldReward;
	public RecordExtra.IntPrefData CurClassicWorldID;
	public bool claimPlayerGetSubWorldReward = false;
	public RecordExtra.ObjectPrefData<KnowledgeCardData> KnowledgeCards;
	
	public void Initilize()
	{
		playerGetSubWorldReward = new RecordExtra.StringPrefData("playerGetSubWorldReward","");
		CurClassicWorldID = new RecordExtra.IntPrefData("CurClassicWorldID", -1);
		KnowledgeCards = new RecordExtra.ObjectPrefData<KnowledgeCardData>("sync_data_cards", new KnowledgeCardData());
		KnowledgeCards.Value.SetChangeListener(() => KnowledgeCards.Save());
	}
}