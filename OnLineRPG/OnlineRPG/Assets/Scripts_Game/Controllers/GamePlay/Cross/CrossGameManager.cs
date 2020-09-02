using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossGameManager : BaseGameManager
    {
        public RecordExtra.ObjectPrefData<CrossLevelProgressData> ProgressData { get; private set; }
        
        public bool TipReplay { get; private set; }

        private CrossLevelEntity _levelEntity;
        
        public override BaseFSMManager InstantiateFSM()
        {
            CrossFsmManager manager = gameObject.GetComponent<CrossFsmManager>();
            if (manager == null)
                manager = gameObject.AddComponent<CrossFsmManager>();
            manager.Init(this);
            return manager;
        }

        public override void ShowGameADVideo()
        {
            
        }

        public CrossLevelEntity GetLevel()
        {
            return _levelEntity;
        }

        public int GetBeeMaxCount()
        {
            return _levelEntity.BeeCount;
            int beeCount = 3;
            switch (_levelEntity.SizeRow)
            {
                case 4:
                case 5:
                    beeCount = 3;
                    break;
                case 6:
                case 7:
                    beeCount = 4;
                    break;
                case 8:
                case 9:
                    beeCount = 6;
                    break;
            }
            return beeCount;
        }

        public override void Init()
        {
            var sys = AppEngine.SSystemManager.GetSystem<EliteSystem>();
            int term = sys.currentWordID;
            int term_level = sys.currentLevelID;
            _levelEntity = sys.GetCurrentCrossLevel();
            ProgressData = new RecordExtra.ObjectPrefData<CrossLevelProgressData>(
                $"cross_{term}_{term_level}_{_levelEntity.ID}",new CrossLevelProgressData());
            if (ProgressData.Value.LevelID > 0 && ProgressData.Value.LevelID != _levelEntity.ID)
            {
                ProgressData.Value = new CrossLevelProgressData();
            }

            TipReplay = ProgressData.Value.LevelID < 0 && sys.IsReplayCurLevel();
            ProgressData.Value.LevelID = _levelEntity.ID;
            GameTempData.levelID = _levelEntity.ID;
            base.Init();
        }
        
        public override void ClearLevelProgress()
        {
            ProgressData.Value = null;
        }
        
        public virtual void SaveLocal()
        {
            ProgressData.Save();
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
    }
}