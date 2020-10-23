using System;
using System.Collections;

namespace app.battle
{
    public class BatRoundStageProcessData : BatRoundStageData
    {
        public BatRoundStageProcessData() : base(BatRoundStageType.PROGRESS)
        {

        }

        public override void Parse(object data)
        {
            IDictionary dic = (IDictionary)data;
            IList startDataList = JsonHelper.GetListData(BattleReportDef.BATTLE_ACTION_START.ToString(), dic);
            IList exeDataList = JsonHelper.GetListData(BattleReportDef.BATTLE_ACTION_EXECUTE.ToString(), dic);
            IList defDataList = JsonHelper.GetListData(BattleReportDef.BATTLE_ACTION_DEFENCE.ToString(), dic);
            IList adjustDataList = JsonHelper.GetListData(BattleReportDef.BATTLE_ACTION_ADJUST.ToString(), dic);
            IList endDataList = JsonHelper.GetListData(BattleReportDef.BATTLE_ACTION_END.ToString(), dic);

            ParseBehavItemDatas(startDataList, startItems);
            ParseBehavItemDatas(exeDataList, exeItems);
            ParseBehavItemDatas(defDataList, defItems);
            ParseBehavItemDatas(adjustDataList, adjustItems);
            ParseBehavItemDatas(endDataList, endItems);
        }

        public override float secondsCost
        {
            get
            {
                return mSecondsCost;
            }
        }
    }
}

