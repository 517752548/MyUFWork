using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 活动UI奖励模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ActivityUIRewardTemplateDBBase : TemplateDBBase<ActivityUIRewardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ActivityUIRewardTemplate> idKeyDic = new Dictionary<int, ActivityUIRewardTemplate>();
        
		protected static ActivityUIRewardTemplateDB _ins;
        public static ActivityUIRewardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ActivityUIRewardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ActivityUIRewardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ActivityUIRewardTemplate activityuirewardtemplate)
        {
            if (this.idKeyDic.ContainsKey(activityuirewardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + activityuirewardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(activityuirewardtemplate.Id, activityuirewardtemplate);
            return true;
        }

        public override ActivityUIRewardTemplate getTemplate(int id)
        {
            ActivityUIRewardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ActivityUIRewardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ActivityUIRewardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ActivityUIRewardTemplate activityuirewardtemplate = new ActivityUIRewardTemplate();
				//id，每个表都有
				activityuirewardtemplate.Id = reader.GetInt32(startIndex++);
		
				activityuirewardtemplate.rewardId = reader.GetInt32(startIndex++);
	
				activityuirewardtemplate.showRewardId = reader.GetInt32(startIndex++);
	
				ActivityUIRewardTemplateDB.Instance.addTemplate(activityuirewardtemplate);
				}
			}
		}

}
}