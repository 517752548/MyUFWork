using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 活动UI模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ActivityUITemplateDBBase : TemplateDBBase<ActivityUITemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ActivityUITemplate> idKeyDic = new Dictionary<int, ActivityUITemplate>();
        
		protected static ActivityUITemplateDB _ins;
        public static ActivityUITemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ActivityUITemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ActivityUITemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ActivityUITemplate activityuitemplate)
        {
            if (this.idKeyDic.ContainsKey(activityuitemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + activityuitemplate.Id);
                return false;
            }
            this.idKeyDic.Add(activityuitemplate.Id, activityuitemplate);
            return true;
        }

        public override ActivityUITemplate getTemplate(int id)
        {
            ActivityUITemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ActivityUITemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ActivityUITemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ActivityUITemplate activityuitemplate = new ActivityUITemplate();
				//id，每个表都有
				activityuitemplate.Id = reader.GetInt32(startIndex++);
		
				activityuitemplate.behaviorId = reader.GetInt32(startIndex++);
	
				activityuitemplate.name = reader.GetString(startIndex++);
	
				activityuitemplate.energyNumPerTime = reader.GetInt32(startIndex++);
	
				activityuitemplate.activityNumPerTime = reader.GetInt32(startIndex++);
	
				activityuitemplate.activityTotalTime = reader.GetInt32(startIndex++);
	
				activityuitemplate.funcId = reader.GetInt32(startIndex++);
	
				activityuitemplate.activityTimeEventId = reader.GetInt32(startIndex++);
	
				activityuitemplate.participateRecommendRandom = reader.GetInt32(startIndex++);
	
				activityuitemplate.hyperlink = reader.GetString(startIndex++);
	
				activityuitemplate.activityTimeDesc = reader.GetString(startIndex++);
	
				activityuitemplate.startTimeDesc = reader.GetString(startIndex++);
	
				activityuitemplate.taskMemberDesc = reader.GetString(startIndex++);
	
				activityuitemplate.desc = reader.GetString(startIndex++);
	
				activityuitemplate.showRewardId = reader.GetInt32(startIndex++);
	
				activityuitemplate.icon = reader.GetString(startIndex++);
	
				activityuitemplate.timeLimitActivityId = reader.GetInt32(startIndex++);
	
				activityuitemplate.superScript = reader.GetString(startIndex++);
	
				activityuitemplate.openConditionDesc = reader.GetString(startIndex++);
	
				ActivityUITemplateDB.Instance.addTemplate(activityuitemplate);
				}
			}
		}

}
}