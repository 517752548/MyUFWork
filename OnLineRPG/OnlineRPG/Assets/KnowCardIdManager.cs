using System;
using System.Collections;
using System.Collections.Generic;
using Bag;
using BetaFramework;
using Newtonsoft.Json;
using PathC;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class KnowCardIdManager
{
    public static KnowCardIdManager instance;
    private Dictionary<string, ArrayList> _dictionary = new Dictionary<string, ArrayList>();
    private ArrayList CardList = new ArrayList();
    private ArrayList LocalKnowledgeCardList = new ArrayList();
    public string showCard = "showCard";
    private Dictionary<string, KnowledgeCardEntity> cardCache = new Dictionary<string, KnowledgeCardEntity>();

    private KnowCardIdManager()
    {
        _dictionary.Add(showCard, CardList);
    }

    public static KnowCardIdManager getInstance()
    {
        if (instance == null)
        {
            instance = new KnowCardIdManager();
        }

        return instance;
    }

    public void addId(string operationType, string id)
    {
        if (_dictionary.ContainsKey(operationType))
        {
            ArrayList list = _dictionary[operationType];
            if (!list.Contains(id))
            {
                list.Add(id);
            }
        }
    }

    public bool isOperationKnowCard(string operationType, string id)
    {
        if (_dictionary.ContainsKey(operationType))
        {
            ArrayList list = _dictionary[operationType];
            if (list.Contains(id))
            {
                return true;
            }
        }

        return false;
    }

    public void removeCardId(string operationType, string id)
    {
        if (_dictionary.ContainsKey(operationType))
        {
            ArrayList list = _dictionary[operationType];
            if (list.Contains(id))
            {
                list.Remove(id);
            }
        }
    }

    //记录有new标签的面板
    public void addLocalKnowledgeCard(LocalKnowledgeCard localKnowledgeCard)
    {
        if (!LocalKnowledgeCardList.Contains(localKnowledgeCard))
        {
            LocalKnowledgeCardList.Add(localKnowledgeCard);
        }
    }

    public void resetAllNewFlag()
    {
        for (int i = 0; i < LocalKnowledgeCardList.Count; i++)
        {
            LocalKnowledgeCard localKnowledgeCard = LocalKnowledgeCardList[i] as LocalKnowledgeCard;
            localKnowledgeCard.isNew = 0;
        }
    }

    public void destory()
    {
        resetAllNewFlag();
        LocalKnowledgeCardList.Clear();
        CardList.Clear();
        _dictionary.Clear();
        instance = null;
    }

    /// <summary>
    /// 获取某个对象
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public void LoadKnowledgeCard(string cardId, Action<KnowledgeCardEntity> callback)
    {
        if (cardCache.ContainsKey(cardId))
        {
            callback.Invoke(cardCache[cardId]);
            return;
        }

        if (CommUtil.HasCacheText($"Card_{cardId}.txt"))
        {
            KnowledgeCardEntity currentCard =
                JsonConvert.DeserializeObject<KnowledgeCardEntity>(CommUtil.LoadCacheCard($"Card_{cardId}.txt"));
            currentCard.LoadImage(cardok =>
                {
                    if (!cardCache.ContainsKey(cardId))
                        cardCache.Add(cardId, currentCard);
                    callback?.Invoke(currentCard);
                }, false
            );
        }
        else
        {
            WebRequestGetUtility.Instance.Get(
                PathLevelConst.ServerLevelURL + "/Cards/" + $"Card_{cardId}.txt",
                cardop =>
                {
                    if (cardop.isDone && !cardop.isHttpError && !cardop.isNetworkError)
                    {
                        KnowledgeCardEntity currentCard =
                            JsonConvert.DeserializeObject<KnowledgeCardEntity>(cardop.downloadHandler.text);
                        CommUtil.SaveCacheText($"Card_{cardId}.txt",cardop.downloadHandler.data);
                        currentCard.LoadImage(cardok =>
                            {
                                if (!cardCache.ContainsKey(cardId))
                                    cardCache.Add(cardId, currentCard);
                                callback?.Invoke(currentCard);
                            }, false
                        );
                    }
                    else
                    {
                        callback.Invoke(null);
                    }
                });
        }
    }
}