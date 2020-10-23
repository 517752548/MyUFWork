using System.Collections;

namespace app.battle
{
    public class BatSkillTarget
    {
        public BatRoundSkillResultData mData = null;

        public BatSkillTarget(BatRoundSkillResultData data)
        {
            this.mData = data;
        }

        public BatCharacter character
        {
            get
            {
                return mData != null ? mData.target : null;
            }
        }

        public int hpDiff
        {
            get
            {
                return mData != null ? mData.hpDiff : 0;
            }
        }

        public int mpDiff
        {
            get
            {
                return mData != null ? mData.mpDiff : 0;
            }
        }

        public int spDiff
        {
            get
            {
                return mData != null ? mData.spDiff : 0;
            }
        }

        public bool isCrit
        {
            get
            {
                return mData != null ? mData.isCrit : false;
            }
        }

        public bool isDodgy
        {
            get
            {
                return mData != null ? mData.isDodgy : false;
            }
        }

        public bool isDefense
        {
            get
            {
                return mData != null ? mData.isDefense : false;
            }
        }

        public BatRoundBuffData buffData
        {
            get
            {
                return mData != null ? mData.buffData : null;
            }
        }

        public bool isBeCaught
        {
            get
            {
                return mData != null ? mData.isBeCaught : false;
            }
        }

        public bool isEscaped
        {
            get
            {
                return mData != null ? mData.isEscaped : false;
            }
        }
        
        public bool isDeadFly
        {
            get
            {
                return mData != null ? mData.isDeadFly : false;
            }
        }
        
        public bool isNoBubble
        {
            get
            {
                return mData != null ? mData.isNoBubble : false;
            }
        }
        
        public string targetUUID
        {
            get
            {
                return mData != null ? mData.targetUUID : null;
            }
        }
        
        public BatCharacterStatusData summonResultStatusData
        {
            get
            {
                return mData != null ? mData.summonTargetStatusData : null;
            }
        }
        
        public bool isSummonSuccess
        {
            get
            {
                return mData != null ? mData.isSummonSuccess : false;
            }
        }

        public bool chivalricStatusChanged
        {
            get
            {
                return mData != null ? mData.chivalricStatusChanged : false;
            }
        }

        public bool hasChivalric
        {
            get
            {
                return mData != null ? mData.hasChivalric : false;
            }
        }

        public int chivalricId
        {
            get
            {
                return mData != null ? mData.chivalricId : 0;
            }
        }
    }
}