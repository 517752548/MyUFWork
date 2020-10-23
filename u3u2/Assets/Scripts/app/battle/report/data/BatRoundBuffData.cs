using app.db;
using System.Collections;

namespace app.battle
{
    /// <summary>
    /// 一条buff数据。
    /// </summary>
    public class BatRoundBuffData : BatRoundBehavData
    {
        public int uuid { get; private set; }
        public int id { get; private set; }
        public SkillBuffTemplate tpl { get; private set; }
        public SkillBuffStateType stateType { get; private set; }
        public int roundLeft { get; private set; }

        public BatRoundBuffData(BatRoundStageType stageType) : base(stageType)
        {
            type = BattleRoundBehavType.BUFF;
        }

        public void Parse(IDictionary data)
        {
            uuid = JsonHelper.GetIntData(BattleReportDef.REPORT_ITEM_BUFF_UUID.ToString(), data);
            id = JsonHelper.GetIntData(BattleReportDef.REPORT_ITEM_BUFF_ID.ToString(), data);
            tpl = SkillBuffTemplateDB.Instance.getTemplate(id);
            hostUUID = JsonHelper.GetStringData(BattleReportDef.REPORT_ITEM_TARGET.ToString(), data);
            stateType = (SkillBuffStateType)(JsonHelper.GetIntData(BattleReportDef.REPORT_ITEM_BUFF_STATE.ToString(), data));
            roundLeft = JsonHelper.GetIntData(BattleReportDef.REPORT_ITEM_BUFF_LEFT.ToString(), data);
        }
    }
}