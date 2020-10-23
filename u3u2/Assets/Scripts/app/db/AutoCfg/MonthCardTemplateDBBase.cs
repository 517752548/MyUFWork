using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 月卡模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MonthCardTemplateDBBase : TemplateDBBase<MonthCardTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, MonthCardTemplate> idKeyDic = new Dictionary<int, MonthCardTemplate>();
        
		protected static MonthCardTemplateDB _ins;
        public static MonthCardTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new MonthCardTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, MonthCardTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(MonthCardTemplate monthcardtemplate)
        {
            if (this.idKeyDic.ContainsKey(monthcardtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + monthcardtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(monthcardtemplate.Id, monthcardtemplate);
            return true;
        }

        public override MonthCardTemplate getTemplate(int id)
        {
            MonthCardTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get MonthCardTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_MonthCardTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				MonthCardTemplate monthcardtemplate = new MonthCardTemplate();
				//id，每个表都有
				monthcardtemplate.Id = reader.GetInt32(startIndex++);
		
				monthcardtemplate.monthCurrId = reader.GetInt32(startIndex++);
	
				monthcardtemplate.monthCurrNum = reader.GetInt32(startIndex++);
	
				monthcardtemplate.rebateCurrId = reader.GetInt32(startIndex++);
	
				monthcardtemplate.rebateCurrNum = reader.GetInt32(startIndex++);
	
				monthcardtemplate.dayRebateCurrId = reader.GetInt32(startIndex++);
	
				monthcardtemplate.dayRebateCurrNum = reader.GetInt32(startIndex++);
	
				MonthCardTemplateDB.Instance.addTemplate(monthcardtemplate);
				}
			}
		}

}
}