using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class SkillPerformEffectItemTemplate
    {
        /// <summary>
        /// 技能特效id
        /// </summary>
	    public String effectId;
	
	    /// <summary>
        /// 技能特效类型
	    /// </summary>
        public int effectType;
	
	    /// <summary>
        /// 特效出现目标
	    /// </summary>
        public int effectShowTargetType;
	
	    /// <summary>
        /// 特效出现位置
	    /// </summary>
        public int effectShowPosType;
	
        /**特效对应目标（1每个目标各一个，2所有目标公用一个）*/
	    public int effectImpactTargetType;

	    /// <summary>
        /// 特效出现时间(秒)
	    /// </summary>
        public float effectShowTime;

        public SkillPerformEffectItemTemplate(SqliteDataReader reader, int startIndex)
        {
            this.effectId = reader.GetString(startIndex++);
            this.effectType = reader.GetInt32(startIndex++);
            this.effectShowTargetType = reader.GetInt32(startIndex++);
            this.effectShowPosType = reader.GetInt32(startIndex++);
			this.effectImpactTargetType = reader.GetInt32(startIndex++);
            this.effectShowTime = reader.GetFloat(startIndex++);
        }
    }
}
