using System;
using System.Collections.Generic;
using BetaFramework;
using Scripts.Utility;
using Scripts_Game.Managers;
using Scripts_Game.Views;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordCellManager : BaseCellManager
    {
        public Animator ani;
        public GameObject rewardTitle, rewardContent;
        public TextMeshProUGUI rewardTitleText;
        public Image rewardIconImage;
        public TextMeshProUGUI rewardCountText;
        public GameObject completeTitle;
        public TimeDisplay countDownTime;
        
        private OneWordLevel level;
        private RewardInventory _rewardData;
        public bool IsCompleted { get; private set; }

        private OneWordGameManager _GameManager { get { return m_baseGameManager as OneWordGameManager; } }

        public override void Init()
        {
            ani = GetComponent<Animator>();
            IsCompleted = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted;
            base.Init();
            var list = RewardMgr.GetRewards(level.RewardId.ToString());
            if (list != null && list.Count > 0)
            {
                _rewardData = list[0];
                BagItems_Data Item1Data = RewardMgr.GetInventoryConfig(_rewardData.type);
                Addressables.LoadAssetAsync<Sprite>(string.Format("{0}.png", Item1Data.Sprite)).Completed += op =>
                {
                    rewardIconImage.sprite = op.Result;
                };
                rewardCountText.text = "+" + _rewardData.count;
                rewardTitleText.text = Item1Data.Name;
            }
            else
                _rewardData = null;

            if (IsCompleted)
            {
                ShowComplete();
                ((OneWordGameCollectData) _GameManager.GameTempData).GameFinishPlayerEnter = true;
            }
            else
            {
                rewardTitle.SetActive(true);
                rewardContent.SetActive(true);
                completeTitle.SetActive(false);
                countDownTime.gameObject.SetActive(false);
            }
        }

        protected override void InitCells()
        {
            level = _GameManager.GetLevel();
            if (level == null)
                return;

            AdjustRect();
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = level.Answer.Length;

            level.Answer = level.Answer.ToUpper();
            BaseWord word = new OneWordWord(this, level);
            int beginColIndex = 0;
            int endColIndex = beginColIndex + word.Answer.Length - 1;
            word.Index = 0;
            for (int col = 0; col < word.Answer.Length; col++)
            {
                OneWordCell cell = AppEngine.SObjectPoolManager.Spawn(GetCellResName()).GetComponent<OneWordCell>();

                if (col >= beginColIndex && col <= endColIndex)
                {
                    cell.Init(this, word.Answer.Substring(col - beginColIndex, 1), col, cellSize);
                }
                else
                {
                    cell.Init(this, null, col, cellSize);
                }

                cell.transform.SetParent(gridLayout.transform, false);
                cell.gameObject.SetActive(true);

                word.AddCell(cell);
                allCells.Add(cell);
            }

            wordList.Add(word);
        }

        public override void CheckGame()
        {
            if (IsCompleted)
            {
                curWord = wordList[0];
                curWord?.SetSelect(true);
                return;
            }
            base.CheckGame();
        }

        public override void SetCurWord(BaseWord word)
        {
            base.SetCurWord(word);
            if (word != null && !IsCompleted)
                focusWordFlag.gameObject.SetActive(true);
        }

        protected override string GetCellResName()
        {
            return ViewConst.prefab_OneWordCell;
        }

        protected override int GetRowCount()
        {
            return 1;
        }

        protected override int GetRowCellCount()
        {
            int count = 6;//base.GetRowCellCount();
            int len = level.Answer.Length;
            if (len > count)
                count = len;

            return count;
        }

        protected override void RecoveryLastProgress()
        {
            base.RecoveryLastProgress();
            _GameManager.ProgressData.CheckLevel(level.LevelID());
            for (int i = 0; i < wordList.Count; i++)
            {
                if (!IsCompleted)
                {
                    if (_GameManager.ProgressData.levelData.ContainsKey(wordList[i].Answer))
                    {
                        wordList[i].StateInfo = _GameManager.ProgressData.levelData[wordList[i].Answer];
                    }

                    if (_GameManager.ProgressData.wordUseHint2.ContainsKey(wordList[i].Answer))
                    {
                        wordList[i].IsKeyboardHintUsed = _GameManager.ProgressData.wordUseHint2[wordList[i].Answer];
                    }
                }
                else
                {
                    wordList[i].StateInfo = "1111111111111111";
                }

                wordList[i].Refresh();
            }

            //CheckGame();
        }

        public override void CacheLevelProgress()
        {
            if (_GameManager.ProgressData != null && level != null)
            {
                _GameManager.ProgressData.levelId = level.LevelID();
                _GameManager.ProgressData.CacheMemory(wordList);
            }
        }

        public override void InputLetter(string letter)
        {
            if (IsCompleted)
                return;
            base.InputLetter(letter);
        }
        

        public string LevelReward()
        {
            ani.SetTrigger("unlock");
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_flash_unlock);
            // if (_rewardData != null)
            // {
            //     AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(_rewardData.ID,
            //         _rewardData.number, "flash");
            // }
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().CompleteCurLevel(level.LevelID());
            IsCompleted = true;
            //FlyRewardView.instance.RateFlyCoin(reward.transform, null);
            //AppEngine.SSystemManager.GetSystem<BagSystem>().ChangeProperty<Bag.Coin>(5, false, null);

            return level.RewardId.ToString();
        }

        public void ShowComplete()
        {
            focusWordFlag.gameObject.SetActive(false);
            rewardTitle.SetActive(false);
            rewardContent.SetActive(false);
            completeTitle.SetActive(true);
            countDownTime.gameObject.SetActive(true);
            GameManager.GetEntity<BaseSkillManager>().specificCellHint.SetHintEnable(false);
            GameManager.GetEntity<BaseSkillManager>().keyboardHint.SetHintEnable(false);
            GameManager.GetEntity<BaseSkillManager>().multiCellsHint.SetHintEnable(false);
            GameManager.GetEntity<BaseSkillManager>().specificWordHint.SetHintEnable(false);
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate += OnTimeUpdate;
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().UpdateTime();
            GameManager.GetEntity<OneWordRewardVideo>().CheckRefresh();
        }

        private void OnTimeUpdate(int sec)
        {
            var time = new CountDownTime(sec);
            countDownTime.SetTime(time.Hour, time.Minute, time.Second);
            if (IsCompleted 
                && AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsReady()
                && !AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsCompleted)
            {
                AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate -= OnTimeUpdate;
                UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow,OpenType.Replace, (ui, para) =>
                {
                    DataManager.ProcessData._GameMode = GameMode.OneWord;
                    MainSceneDirector.Instance.SwitchUi(GameUI.Game, ok =>
                    {
                        Timer.Schedule(AppThreadController.instance, 0.2f, () =>
                        {
                            UIManager.CloseUIWindow(
                                UIManager.GetWindow<GameLoadingWindow>(ViewConst.prefab_GameLoadingWindow)); 
                        });
                    });

                });
            }
        }

        private void OnDestroy()
        {
            AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().OnTimeUpdate -= OnTimeUpdate;
        }
        
        protected override void OnWordCompleted(List<BaseWord> words)
        {
            base.OnWordCompleted(words);
        }

        public override void OnWordWrong(BaseWord word,string wrongword)
        {
            if (word is BaseNormalWord)
            {
                base.OnWordWrong(word,wrongword);
            }
        }
    }
}