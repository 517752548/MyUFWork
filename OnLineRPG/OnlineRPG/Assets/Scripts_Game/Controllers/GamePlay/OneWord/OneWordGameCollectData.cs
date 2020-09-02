using System;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordGameCollectData : GameCollectData
    {
        public bool GameFinishPlayerEnter = false;
        private OneWordLevel level;
        
        public OneWordGameCollectData(OneWordLevel level)
        {
            this.level = level;
        }

        public override void ReportWin(TimeSpan gameSpendTime)
        {
            //base.ReportWin(gameSpendTime);
            string p_type = "1";
            if (level.Order >= 100)
            {
                p_type = "2";
            }
            GameAnalyze.LogflashCrazePass(level.StartTimeStamp.ToString(), level.QuestionId, level.Order.ToString(), 
                hint1num.ToString(), hint2num.ToString(), hint3num.ToString(), 
                hint4num.ToString(), "1",p_type, ClassicVoiceKeyboard.VoiceProportion.ToString());
        }
        
        public override void ReportOutLevel()
        {
            endTime = DateTime.Now;
            TimeSpan gameSpendTime = endTime - startTime - uselessTime;
            if (gameSpendTime < TimeSpan.Zero)
            {
                gameSpendTime = TimeSpan.Zero;
            }

            string p_statue = "0";
            if (GameFinishPlayerEnter)
                p_statue = "2";
            
            string p_type = "1";
            if (level.Order >= 100)
            {
                p_type = "2";
            }
            GameAnalyze.LogflashCrazePass(level.StartTimeStamp.ToString(), level.QuestionId, level.Order.ToString(),
                hint1num.ToString(), hint2num.ToString(), hint3num.ToString(),
                hint4num.ToString(), p_statue, p_type, ClassicVoiceKeyboard.VoiceProportion.ToString());
        }
    }
}