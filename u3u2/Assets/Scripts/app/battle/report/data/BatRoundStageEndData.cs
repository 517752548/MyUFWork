using System;
using System.Collections;

namespace app.battle
{
    public class BatRoundStageEndData : BatRoundStageData
    {
        public BatRoundStageEndData() : base(BatRoundStageType.END)
        {

        }
        
        public override void Parse(object data)
        {
            ParseBehavItemDatas((IList)data, endItems);
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

