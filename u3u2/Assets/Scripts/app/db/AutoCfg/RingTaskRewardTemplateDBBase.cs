using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 跑环任务奖励配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class RingTaskRewardTemplateDBBase : TemplateDBBase<RingTaskRewardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, RingTaskRewardTemplate> idKeyDic = new Dictionary<int, RingTaskRewardTemplate>();
        
		protected static RingTaskRewardTemplateDB _ins;
        public static RingTaskRewardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new RingTaskRewardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, RingTaskRewardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(RingTaskRewardTemplate ringtaskrewardtemplate)
        {
            if (this.idKeyDic.ContainsKey(ringtaskrewardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + ringtaskrewardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(ringtaskrewardtemplate.Id, ringtaskrewardtemplate);
            return true;
        }

        public override RingTaskRewardTemplate getTemplate(int id)
        {
            RingTaskRewardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get RingTaskRewardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_RingTaskRewardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				RingTaskRewardTemplate ringtaskrewardtemplate = new RingTaskRewardTemplate();
				//id，每个表都有
				ringtaskrewardtemplate.Id = reader.GetInt32(startIndex++);
		
				ringtaskrewardtemplate.levelMin = reader.GetInt32(startIndex++);
	
				ringtaskrewardtemplate.levelMax = reader.GetInt32(startIndex++);
	
				ringtaskrewardtemplate.ringNum = reader.GetInt32(startIndex++);
	
				ringtaskrewardtemplate.normalRewardId = reader.GetInt32(startIndex++);
	
				ringtaskrewardtemplate.vipLevelLimit = reader.GetInt32(startIndex++);
	
				ringtaskrewardtemplate.vipRewardId = reader.GetInt32(startIndex++);
	
				RingTaskRewardTemplateDB.Instance.addTemplate(ringtaskrewardtemplate);
				}
			}
		}

}
}