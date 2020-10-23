using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 在线礼包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class OnlineGiftTemplateDBBase : TemplateDBBase<OnlineGiftTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, OnlineGiftTemplate> idKeyDic = new Dictionary<int, OnlineGiftTemplate>();
        
		protected static OnlineGiftTemplateDB _ins;
        public static OnlineGiftTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new OnlineGiftTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, OnlineGiftTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(OnlineGiftTemplate onlinegifttemplate)
        {
            if (this.idKeyDic.ContainsKey(onlinegifttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + onlinegifttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(onlinegifttemplate.Id, onlinegifttemplate);
            return true;
        }

        public override OnlineGiftTemplate getTemplate(int id)
        {
            OnlineGiftTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get OnlineGiftTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_OnlineGiftTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				OnlineGiftTemplate onlinegifttemplate = new OnlineGiftTemplate();
				//id，每个表都有
				onlinegifttemplate.Id = reader.GetInt32(startIndex++);
		
				onlinegifttemplate.cd = reader.GetInt64(startIndex++);
	
				onlinegifttemplate.rewardId = reader.GetInt32(startIndex++);
	
				onlinegifttemplate.showRewardId = reader.GetInt32(startIndex++);
	
				OnlineGiftTemplateDB.Instance.addTemplate(onlinegifttemplate);
				}
			}
		}

}
}