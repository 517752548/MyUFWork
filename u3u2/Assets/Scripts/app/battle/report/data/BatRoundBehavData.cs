using System;

namespace app.battle
{
    /// <summary>
    /// 一条行为数据。
    /// </summary>
    public abstract class BatRoundBehavData
    {
        public BattleRoundBehavType type { get; protected set; }
        public string hostUUID { get; protected set; }
        public BatCharacter host { get; set; }
        protected bool mIsDone = false;
        public BatRoundStageType stageType { get; private set; }

        public BatRoundBehavData(BatRoundStageType stageType)
        {
            this.stageType = stageType;
            mIsDone = false;
        }

        public virtual bool isDone
        {
            get
            {
                return mIsDone;
            }
            set
            {
                mIsDone = value;
            }
        }
    }
}