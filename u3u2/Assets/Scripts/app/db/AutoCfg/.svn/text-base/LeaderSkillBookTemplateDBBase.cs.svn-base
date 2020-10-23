using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 人物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LeaderSkillBookTemplateDBBase : TemplateDBBase<LeaderSkillBookTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LeaderSkillBookTemplate> idKeyDic = new Dictionary<int, LeaderSkillBookTemplate>();
        
		protected static LeaderSkillBookTemplateDB _ins;
        public static LeaderSkillBookTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LeaderSkillBookTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LeaderSkillBookTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LeaderSkillBookTemplate leaderskillbooktemplate)
        {
            if (this.idKeyDic.ContainsKey(leaderskillbooktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + leaderskillbooktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(leaderskillbooktemplate.Id, leaderskillbooktemplate);
            return true;
        }

        public override LeaderSkillBookTemplate getTemplate(int id)
        {
            LeaderSkillBookTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LeaderSkillBookTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LeaderSkillBookTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LeaderSkillBookTemplate leaderskillbooktemplate = new LeaderSkillBookTemplate();
				//id，每个表都有
				leaderskillbooktemplate.Id = reader.GetInt32(startIndex++);
		
				leaderskillbooktemplate.nameLangId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.name = reader.GetString(startIndex++);
	
				leaderskillbooktemplate.descLangId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.desc = reader.GetString(startIndex++);
	
				leaderskillbooktemplate.icon = reader.GetString(startIndex++);
	
				leaderskillbooktemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.bagId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.rarityId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.level = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.pageId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.orderId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.canUsed = reader.GetBoolean(startIndex++);
	
				leaderskillbooktemplate.canSelled = reader.GetBoolean(startIndex++);
	
				leaderskillbooktemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.sellPrice = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.modelId = reader.GetString(startIndex++);
	
				leaderskillbooktemplate.canCompose = reader.GetBoolean(startIndex++);
	
				leaderskillbooktemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.listingFee = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        leaderskillbooktemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            leaderskillbooktemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				leaderskillbooktemplate.expiredHour = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.composeNum = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.composeItemId = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.composeGold = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.jobLimit = reader.GetInt32(startIndex++);
	
				leaderskillbooktemplate.skillId = reader.GetInt32(startIndex++);
	
				LeaderSkillBookTemplateDB.Instance.addTemplate(leaderskillbooktemplate);
				}
			}
		}

}
}