using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 每日签到奖励
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class DailySignGiftTemplateDBBase : TemplateDBBase<DailySignGiftTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, DailySignGiftTemplate> idKeyDic = new Dictionary<int, DailySignGiftTemplate>();
        
		protected static DailySignGiftTemplateDB _ins;
        public static DailySignGiftTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DailySignGiftTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, DailySignGiftTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(DailySignGiftTemplate dailysigngifttemplate)
        {
            if (this.idKeyDic.ContainsKey(dailysigngifttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + dailysigngifttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(dailysigngifttemplate.Id, dailysigngifttemplate);
            return true;
        }

        public override DailySignGiftTemplate getTemplate(int id)
        {
            DailySignGiftTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get DailySignGiftTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_DailySignGiftTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				DailySignGiftTemplate dailysigngifttemplate = new DailySignGiftTemplate();
				//id，每个表都有
				dailysigngifttemplate.Id = reader.GetInt32(startIndex++);
		
				dailysigngifttemplate.rewardId = reader.GetInt32(startIndex++);
	
				dailysigngifttemplate.showRewardId = reader.GetInt32(startIndex++);
	
				dailysigngifttemplate.isSpecial = reader.GetInt32(startIndex++);
	
				dailysigngifttemplate.vipRewardTimes = reader.GetInt32(startIndex++);
	
				dailysigngifttemplate.vipLevelLimit = reader.GetInt32(startIndex++);
	
				DailySignGiftTemplateDB.Instance.addTemplate(dailysigngifttemplate);
				}
			}
		}

}
}