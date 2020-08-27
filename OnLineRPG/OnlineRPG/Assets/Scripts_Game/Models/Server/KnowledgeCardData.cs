﻿using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class KnowledgeCardData : BaseSyncHandData
{
    public List<KnowledgeCard> allCards = new List<KnowledgeCard>();

    public KnowledgeCard AddKnowledgeCard(int level, string cardId, int praise)
    {
        KnowledgeCard card = allCards.Find(c => c.cardID == cardId);
        if (card != null)
        {
            card.count++;
            card.needSync = true;
        }
        else
        {
            card = new KnowledgeCard()
            {
                level = level,
                count = 1,
                cardID = cardId,
                creatTime = AppEngine.STimeHeart.RealTime.ToString("g"),
                praise = praise,
                isNew = 0,
                isClickHeart = 0,
                needSync = true
            };
            allCards.Add(card);
        }
        OnDataChange();
        return card;
    }

    public void ClearAllNewFlag()
    {
        allCards.ForEach(c =>
        {
            if (c.isNew == 0)
            {
                c.isNew = 1;
                c.needSync = true;
            }
        });
        OnDataChange();
    }

    public override BaseSyncHandData Clone()
    {
        KnowledgeCardData obj = new KnowledgeCardData();
        obj.allCards.AddRange(allCards);
        return obj;
    }

    public override bool IsEqual(BaseSyncHandData other)
    {
        return allCards.Count == (other as KnowledgeCardData).allCards.Count;
    }
}

public class KnowledgeCard
{
    public int level;
    public string cardID;
    public string creatTime;
    public int praise;
    public int isNew;
    public int isClickHeart;
    public int count;
    public bool needSync;
}