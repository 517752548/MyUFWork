using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordGameManager : BaseGameManager
    {
        public OneWordLevelProgressData ProgressData;
        private OneWordLevel level;
        
        public override void Init()
        {
            ProgressData = Record.GetObject(PrefKeys.OneWordLevelProgress,new OneWordLevelProgressData());
            level = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().GetCurrentGameLevel();
            GameTempData = new OneWordGameCollectData(level);
            base.Init();
        }
        
        public override void ShowGameADVideo()
        {
            if (AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>().IsAllCompleted)
                return;
            AppEngine.SAdManager.ShowInterstitialByCondition(AdManager.InterstitialCallPlace.OneWordEnter);
        }
        public override BaseFSMManager InstantiateFSM()
        {
            OneWordFsmManager manager = gameObject.GetComponent<OneWordFsmManager>();
            if (manager == null)
                manager = gameObject.AddComponent<OneWordFsmManager>();
            manager.Init(this);
            return manager;
        }

        public OneWordLevel GetLevel()
        {
            return level;
        }
        
        public override void ClearLevelProgress()
        {
            Record.DeleteKey(PrefKeys.OneWordLevelProgress);
            ProgressData = null;
        }

        public void SaveLocal()
        {
            Record.SetObject(PrefKeys.OneWordLevelProgress, ProgressData);
        }
    
        private void OnApplicationPause(bool pauseStatus)
        {
            SaveLocal();
        }

        private void OnApplicationQuit()
        {
            SaveLocal();
        }

        private void OnDestroy()
        {
            SaveLocal();
        }
        
        public override string GetLevelSeq()
        {
            return level.Order.ToString();
        }
    }
    
    public class OneWordLevelProgressData
    {
        public string levelId;
        /// <summary>
        /// key answer   value 存档
        /// </summary>
        public Dictionary<string, string> levelData;

        public Dictionary<string, bool> wordUseHint2;


        public OneWordLevelProgressData()
        {
            levelId = "";
            levelData = new Dictionary<string, string>();
            wordUseHint2 = new Dictionary<string, bool>();
        }

        public void CacheMemory(List<BaseWord> words)
        {
            foreach (var word in words)
            {
                levelData[word.Answer] = word.StateInfo;
                if (!word.IsKeyboardHintUsed) continue;
                if (wordUseHint2.ContainsKey(word.Answer))
                {
                    wordUseHint2[word.Answer] = true;
                }
                else
                {
                    wordUseHint2.Add(word.Answer, true);
                }
            }
        }

        public void CheckLevel(string levelId)
        {
            if (!this.levelId.Equals(levelId))
            {
                levelData.Clear();
                wordUseHint2.Clear();
            }
        }
    }
}