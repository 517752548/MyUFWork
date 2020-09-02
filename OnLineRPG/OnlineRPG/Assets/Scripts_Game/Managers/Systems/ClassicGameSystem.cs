using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using PathC;
using Scripts_Game.Utils.Comm;
using UnityEngine.UI;

public class ClassicGameSystem : ISystem
{
    /// <summary>
    /// 当前的关卡
    /// </summary>
    public IntSyncField currentLevel => AppEngine.SyncManager.Data.ClassicLevel;

    public string wordVersion = "unknown";
    private Dictionary<int, ClassicWorldEntity> classicWorldCache = new Dictionary<int, ClassicWorldEntity>();
    private Dictionary<int, ClassicSubWorldEntity> classicSubworldCache = new Dictionary<int, ClassicSubWorldEntity>();
    private Dictionary<int, ClassicLevelEntity> classicLevelCache = new Dictionary<int, ClassicLevelEntity>();
    private Dictionary<int, ClassicPackage> classicPackageCache = new Dictionary<int, ClassicPackage>();

    //    private ClassicWorldContainer _localClassicWorldContainer;
    private ClassicWorldContainer _onlineClassicWorldContainer;
    private SubwordRewardTable _subWorldRewardTable;
    private TextAsset preloadtext;

    public override void InitSystem()
    {
        classicLevelCache = new Dictionary<int, ClassicLevelEntity>();
        string configname = string.Format("{0}_StoryConfig{1}.asset", Const.Platform, AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib());
        Addressables.LoadAssetAsync<ClassicWorldContainer>(configname).Completed +=
            (obj) =>
            {
                _onlineClassicWorldContainer = obj.Result;
                _onlineClassicWorldContainer.Load();
                base.InitSystem();
            };
        _subWorldRewardTable =
            PreLoadManager.GetPreLoadConfig<SubwordRewardTable>(ViewConst.asset_SubwordRewardTable_Table);
    }



    public string GetAbTestSpecialId()
    {
        if (_onlineClassicWorldContainer != null)
        {
            return _onlineClassicWorldContainer.ABTestBISymbel;
        }

        return "unknown";
    }

    /// <summary>
    /// 获取一个config 取决于有没有加载到线上的config
    /// </summary>
    /// <returns></returns>
    public ClassicWorldContainer GetClassicWorldContainer()
    {
        if (_onlineClassicWorldContainer != null)
        {
            return _onlineClassicWorldContainer;
        }

        return null;
    }

    /// <summary>
    /// 使用之前确保已经异步加载到内存了
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    public ClassicLevelEntity GetClassicLevel(int levelIndex)
    {
        if (classicLevelCache.ContainsKey(levelIndex))
            return classicLevelCache[levelIndex];
        return null;
    }

    public ClassicLevelEntity GetCurClassicLevel()
    {
        ClearOldLevel(currentLevel.Value);
        return GetClassicLevel(currentLevel.Value);
    }

    private void ClearOldLevel(int levelIndex)
    {
        List<int> needRemove = new List<int>();
        foreach (int key in classicLevelCache.Keys)
        {
            if (key + 1 < levelIndex)
            {
                needRemove.Add(key);
            }
        }

        for (int i = 0; i < needRemove.Count; i++)
        {
            classicLevelCache.Remove(needRemove[i]);
        }
    }

    /// <summary>
    /// 获取某个关卡的world 使用之前先加载这个关卡成功
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    public ClassicWorldEntity GetClassicWorld(int levelIndex)
    {
        if (classicWorldCache.ContainsKey(levelIndex))
        {
            return classicWorldCache[levelIndex];
        }

        if (_onlineClassicWorldContainer != null)
        {
            ClassicWorldEntity end = null;
            for (int i = 0; i < _onlineClassicWorldContainer.dataList.Count; i++)
            {
                if (_onlineClassicWorldContainer.dataList[i].ContainLevel(levelIndex))
                {
                    return _onlineClassicWorldContainer.dataList[i];
                }

                if (end == null && _onlineClassicWorldContainer.dataList[i].WorldState == 0)
                    end = _onlineClassicWorldContainer.dataList[i];
            }

            return end;
        }

        Debug.LogError("kong de" + levelIndex);
        return null;
    }

    public ClassicWorldEntity GetCurClassicWorld()
    {
        return GetClassicWorld(currentLevel.Value);
    }

    /// <summary>
    /// 获取某个关卡的subworld信息   使用之前先加载这个关卡
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    public ClassicSubWorldEntity GetClassicSubWorld(int levelIndex)
    {
        if (classicSubworldCache.ContainsKey(levelIndex))
        {
            return classicSubworldCache[levelIndex];
        }

        if (_onlineClassicWorldContainer != null)
        {
            for (int i = 0; i < _onlineClassicWorldContainer.dataList.Count; i++)
            {
                for (int j = 0; j < _onlineClassicWorldContainer.dataList[i].SubWorldList.Count; j++)
                {
                    if (_onlineClassicWorldContainer.dataList[i].SubWorldList[j].GetLevelIdDict()
                        .ContainsKey(levelIndex))
                    {
                        return _onlineClassicWorldContainer.dataList[i].SubWorldList[j];
                    }
                }
            }
        }

        return null;
    }

    public ClassicSubWorldEntity GetCurClassicSubWorld()
    {
        return GetClassicSubWorld(currentLevel.Value);
    }

    public ClassicPackage GetClassicPackage(int levelIndex)
    {
        if (classicPackageCache.ContainsKey(levelIndex))
        {
            return classicPackageCache[levelIndex];
        }

        if (_onlineClassicWorldContainer != null)
        {
            for (int i = 0; i < _onlineClassicWorldContainer.dataList.Count; i++)
            {
                for (int j = 0; j < _onlineClassicWorldContainer.dataList[i].SubWorldList.Count; j++)
                {
                    for (int k = 0; k < _onlineClassicWorldContainer.dataList[i].SubWorldList[j].Packages.Count; k++)
                    {
                        if (_onlineClassicWorldContainer.dataList[i].SubWorldList[j].Packages[k]
                            .ContainsLevel(levelIndex))
                        {
                            return _onlineClassicWorldContainer.dataList[i].SubWorldList[j].Packages[k];
                        }
                    }
                }
            }
        }

        return null;
    }

    public ClassicPackage GetCurClassicPackage()
    {
        return GetClassicPackage(currentLevel.Value);
    }

    public async void LoadLocalClassicLevel(int levelIndex, Action<bool> callback)
    {
        GameAnalyze.LogEvent("ClickLevel", levelIndex.ToString());
        LoggerHelper.Log("Version:" + wordVersion);
        if (classicLevelCache.ContainsKey(levelIndex))
        {
            callback?.Invoke(true);
            return;
        }

        GetClassicWorldContainer().GetLevelInfo(levelIndex,
            out var _classicWorldEntity, out var _classicSubWorldEntity, out var _classicPackage, out var levelID);

        if (levelID == -1)
        {
            callback?.Invoke(false);
            return;
        }

        Addressables.LoadAssetAsync<TextAsset>($"{Const.Platform}_Level_{levelID}.txt").Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                ClassicLevelEntity level = JsonConvert.DeserializeObject<ClassicLevelEntity>(op.Result.text);

                Addressables.LoadAssetAsync<TextAsset>($"{Const.Platform}_Card_{_classicPackage.CardID}.txt").Completed += cardop =>
                {
                    if (cardop.Status == AsyncOperationStatus.Succeeded)
                    {
                        KnowledgeCardEntity currentCard =
                            JsonConvert.DeserializeObject<KnowledgeCardEntity>(cardop.Result.text);
                        _classicPackage._CardEntity = currentCard;

                        if (_classicPackage.CardLevelID != level.ID)
                        {
                            level.SolutionCardID = null;
                            level._SolutionCard = null;
                        }
                        else
                        {
                            level._SolutionCard = currentCard;
                        }

                        currentCard.LoadLocalImage(cardok =>
                        {
                            if (cardok)
                            {
                                level.LoadLocalImage((ok) =>
                                {
                                    if (ok)
                                    {
                                        classicWorldCache[levelIndex] = _classicWorldEntity;
                                        classicSubworldCache[levelIndex] = _classicSubWorldEntity;
                                        classicPackageCache[levelIndex] = _classicPackage;
                                        classicLevelCache[levelIndex] = level;
                                        AppEngine.SSystemManager.GetSystem<NotificationSystem>()
                                            .SendAnswerTips(level.Questions[level.Questions.Count - 1].Answer);
                                        callback?.Invoke(true);
                                    }
                                    else
                                    {
                                        callback?.Invoke(false);
                                    }
                                });
                            }
                            else
                            {
                                callback?.Invoke(false);
                            }
                        });
                    }
                    else
                    {
                        callback?.Invoke(false);
                    }
                };
            }
            else
            {
                callback?.Invoke(false);
            }
        };
    }

    public async void LoadClassicLevel(int levelIndex, Action<bool> callback)
    {
        if (levelIndex <= 6)
        {
            LoadLocalClassicLevel(levelIndex, callback);
            return;
        }

        GameAnalyze.LogEvent("ClickLevel", levelIndex.ToString());
        LoggerHelper.Log("Version:" + wordVersion);
        if (classicLevelCache.ContainsKey(levelIndex))
        {
            callback?.Invoke(true);
            return;
        }

        GetClassicWorldContainer().GetLevelInfo(levelIndex,
            out var _classicWorldEntity, out var _classicSubWorldEntity, out var _classicPackage, out var levelID);

        if (levelID == -1)
        {
            callback?.Invoke(false);
            return;
        }

        WebRequestGetUtility.Instance.Get(PathLevelConst.ServerLevelURL + "/Levels/" + $"Level_{levelID}.txt",
            op =>
            {
                if (op.isDone && !op.isHttpError && !op.isNetworkError)
                {
                    ClassicLevelEntity level =
                        JsonConvert.DeserializeObject<ClassicLevelEntity>(op.downloadHandler.text);

                    WebRequestGetUtility.Instance.Get(
                        PathLevelConst.ServerLevelURL + "/Cards/" + $"Card_{_classicPackage.CardID}.txt",
                        cardop =>
                        {
                            if (cardop.isDone && !cardop.isHttpError && !cardop.isNetworkError)
                            {
                                KnowledgeCardEntity currentCard =
                                    JsonConvert.DeserializeObject<KnowledgeCardEntity>(cardop.downloadHandler.text);
                                CommUtil.SaveCacheText($"Card_{_classicPackage.CardID}.txt", cardop.downloadHandler.data);
                                _classicPackage._CardEntity = currentCard;

                                if (_classicPackage.CardLevelID != level.ID)
                                {
                                    level.SolutionCardID = null;
                                    level._SolutionCard = null;
                                }
                                else
                                {
                                    level._SolutionCard = currentCard;
                                }

                                currentCard.LoadImage(cardok =>
                                {
                                    if (cardok)
                                    {
                                        level.LoadOnLineImage((ok) =>
                                        {
                                            if (ok)
                                            {
                                                classicWorldCache[levelIndex] = _classicWorldEntity;
                                                classicSubworldCache[levelIndex] = _classicSubWorldEntity;
                                                classicPackageCache[levelIndex] = _classicPackage;
                                                classicLevelCache[levelIndex] = level;
                                                AppEngine.SSystemManager.GetSystem<NotificationSystem>()
                                                    .SendAnswerTips(level.Questions[level.Questions.Count - 1]
                                                        .Answer);
                                                callback?.Invoke(true);
                                            }
                                            else
                                            {
                                                Debug.Log("关卡图片或URL不存在");
                                                callback?.Invoke(false);
                                            }
                                        });
                                    }
                                    else
                                    {
                                        Debug.Log("Card图片或URL不存在");
                                        callback?.Invoke(false);
                                    }
                                });
                            }
                            else
                            {
                                Debug.Log("Card或URL不存在");
                                callback?.Invoke(false);
                            }
                        });
                }
                else
                {
                    Debug.Log("关卡或URL不存在" + PathLevelConst.ServerLevelURL + "/Levels/" + $"Level_{levelID}.txt");
                    callback?.Invoke(false);
                }
            });
    }

    public void GetSubWorldBoxProgress(int completeLevelIndex, out int curProgress, out int totalProgress)
    {
        int startLevelIndex = 0, endLevelIndex = 0;
        for (int i = 0; i < _subWorldRewardTable.dataList.Count; i++)
        {
            if (_subWorldRewardTable.dataList[i].LevelIndex > completeLevelIndex)
            {
                endLevelIndex = _subWorldRewardTable.dataList[i].LevelIndex;
                startLevelIndex = i > 0 ? _subWorldRewardTable.dataList[i - 1].LevelIndex : 0;
                break;
            }

            if (_subWorldRewardTable.dataList[i].LevelIndex == completeLevelIndex)
            {
                startLevelIndex = _subWorldRewardTable.dataList[i].LevelIndex;
                endLevelIndex = (i + 1) < _subWorldRewardTable.dataList.Count
                    ? _subWorldRewardTable.dataList[i + 1].LevelIndex
                    : startLevelIndex;
                break;
            }
        }

        curProgress = completeLevelIndex - startLevelIndex;
        totalProgress = endLevelIndex - startLevelIndex;
    }

    /// <summary>
    /// 获取比参数大的第一个奖励level
    /// </summary>
    /// <param name="rewardLevel">奖励level</param>
    /// <returns>0表示未获取到，即当前任务为最大level</returns>
    public int GetNextRewardLevel(int rewardLevel)
    {
        var res = _subWorldRewardTable.dataList.Find(x => x.LevelIndex > rewardLevel);
        if (res == null)
        {
            return 0;
        }
        else
        {
            return res.LevelIndex;
        }
    }

    public string GetSubWorldRewardId(int completedLevelIndex)
    {
        // var subWorld = GetClassicSubWorld(completedLevelIndex);
        // if (subWorld != null)
        //     return subWorld.RewardID.ToString();
        // return "1";
        var rewardData = _subWorldRewardTable?.dataList.Find(x => x.LevelIndex == completedLevelIndex);
        if (rewardData != null)
            return rewardData.RewardId;
        return "1";
    }

    public SubwordRewardTable_Data GetSubWorldRewardData(int completedLevelIndex)
    {
        return _subWorldRewardTable?.dataList.Find(x => x.LevelIndex == completedLevelIndex);
    }

    public List<LocalKnowledgeCard> GetOwnCards()
    {
        List<LocalKnowledgeCard> cardList = new List<LocalKnowledgeCard>();
        var allCards = DataManager.PlayerData.KnowledgeCards.Value.allCards;
        if (_onlineClassicWorldContainer != null)
        {
            for (int i = 0; i < _onlineClassicWorldContainer.dataList.Count; i++)
            {
                var world = _onlineClassicWorldContainer.dataList[i];
                for (int j = 0; j < world.SubWorldList.Count; j++)
                {
                    for (int k = 0; k < world.SubWorldList[j].Packages.Count; k++)
                    {
                        var pack = world.SubWorldList[j].Packages[k];
                        if (pack.EndLevelIndex < currentLevel.Value)
                        {
                            var cardId = pack.CardID;
                            var card = allCards.Find(c => c.cardID == cardId);
                            if (card == null)
                            {
                                card = DataManager.PlayerData.KnowledgeCards.Value.AddKnowledgeCard(
                                    pack.EndLevelIndex, cardId, UnityEngine.Random.Range(50, 100));
                            }

                            cardList.Add(new LocalKnowledgeCard()
                            {
                                count = card.count,
                                cardID = cardId,
                                creatTime = card.creatTime,
                                isNew = card.isNew,
                                isClickHeart = card.isClickHeart,
                                Praise_points = card.praise
                            });
                        }
                    }
                }
            }
        }

        return cardList;
    }

    public void PreloadNextLevels()
    {
    }
}