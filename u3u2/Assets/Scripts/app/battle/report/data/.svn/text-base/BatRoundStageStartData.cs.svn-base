using System;
using System.Collections;

namespace app.battle
{
    public class BatRoundStageStartData : BatRoundStageData
    {
        public BatRoundStageStartData() : base(BatRoundStageType.START)
        {

        }

        public override void Parse(object data)
        {
            ParseBehavItemDatas((IList)data, startItems);
        }

        public override float secondsCost
        {
            get
            {
                return 0;
            }
        }
    }
}

