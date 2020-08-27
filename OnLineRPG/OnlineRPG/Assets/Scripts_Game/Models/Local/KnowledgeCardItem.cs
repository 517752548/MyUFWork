using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Bag
{
    public class KnowledgeCardItem:BaseItem
    {
        public int count;
        public Dictionary<string, LocalKnowledgeCard> LocalKnowledgeCards = new Dictionary<string, LocalKnowledgeCard>();

        private List<LocalKnowledgeCard> _knowledgeCards = new List<LocalKnowledgeCard>();
        public void AddKnowledgeCard(string cardId,int Praise_points)
        {
            if (LocalKnowledgeCards.ContainsKey(cardId))
            {
                LocalKnowledgeCards[cardId].count++;
            }
            else
            {
                LocalKnowledgeCard _card = new LocalKnowledgeCard();
                _card.cardID = cardId;
                _card.count = 1;
                _card.creatTime = AppEngine.STimeHeart.RealTime.ToString("g");
                _card.Praise_points = Praise_points;
                LocalKnowledgeCards.Add(cardId,_card);
            }
            Save();
            _knowledgeCards = new List<LocalKnowledgeCard>(LocalKnowledgeCards.Values);
        }

        public List<LocalKnowledgeCard> GetAllKnowledgeCards()
        {
            if (_knowledgeCards.Count == 0)
            {
                _knowledgeCards = new List<LocalKnowledgeCard>(LocalKnowledgeCards.Values);
            }
            return _knowledgeCards;
        }

        /// <summary>
        /// 获取某个对象
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public void LoadKnowledgeCard(string cardId,Action<KnowledgeCardEntity> callback)
        {
            Addressables.LoadAssetAsync<KnowledgeCardEntity>(string.Format("Card_{0}.asset",cardId)).Completed += (op) =>
            {
                if (op.Status == AsyncOperationStatus.Succeeded)
                {
                    if (callback != null)
                    {
                        callback.Invoke(op.Result);
                    }
                    else
                    {
                        callback.Invoke(null);
                    }
                }
            };
        }

        public void SetData(string cardId, int count, string time, int point)
        {
            LocalKnowledgeCard _card = new LocalKnowledgeCard();
            _card.cardID = cardId;
            _card.count = count;
            _card.creatTime = time;
            _card.Praise_points = point;
            LocalKnowledgeCards.Add(cardId,_card);
            _knowledgeCards = new List<LocalKnowledgeCard>(LocalKnowledgeCards.Values);
        }

        public void SaveDataChange()
        {
            Save();
        }

        private void Save()
        {
            //AppEngine.SSystemManager.GetSystem<BagSystem>().SaveProperty(this,null);
        }
        
    }
    
}

