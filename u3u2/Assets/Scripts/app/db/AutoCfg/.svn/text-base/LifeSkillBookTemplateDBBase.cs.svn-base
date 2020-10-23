using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillBookTemplateDBBase : TemplateDBBase<LifeSkillBookTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillBookTemplate> idKeyDic = new Dictionary<int, LifeSkillBookTemplate>();
        
		protected static LifeSkillBookTemplateDB _ins;
        public static LifeSkillBookTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillBookTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillBookTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillBookTemplate lifeskillbooktemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillbooktemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillbooktemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillbooktemplate.Id, lifeskillbooktemplate);
            return true;
        }

        public override LifeSkillBookTemplate getTemplate(int id)
        {
            LifeSkillBookTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillBookTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillBookTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillBookTemplate lifeskillbooktemplate = new LifeSkillBookTemplate();
				//id，每个表都有
				lifeskillbooktemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillbooktemplate.nameLangId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.name = reader.GetString(startIndex++);
	
				lifeskillbooktemplate.descLangId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.desc = reader.GetString(startIndex++);
	
				lifeskillbooktemplate.icon = reader.GetString(startIndex++);
	
				lifeskillbooktemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.bagId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.rarityId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.level = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.pageId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.orderId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.canUsed = reader.GetBoolean(startIndex++);
	
				lifeskillbooktemplate.canSelled = reader.GetBoolean(startIndex++);
	
				lifeskillbooktemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.sellPrice = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.modelId = reader.GetString(startIndex++);
	
				lifeskillbooktemplate.canCompose = reader.GetBoolean(startIndex++);
	
				lifeskillbooktemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.listingFee = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        lifeskillbooktemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            lifeskillbooktemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				lifeskillbooktemplate.expiredHour = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.composeNum = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.composeItemId = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.composeGold = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.jobLimit = reader.GetInt32(startIndex++);
	
				lifeskillbooktemplate.skillId = reader.GetInt32(startIndex++);
	
				LifeSkillBookTemplateDB.Instance.addTemplate(lifeskillbooktemplate);
				}
			}
		}

}
}