using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetSkillBookItemTemplateDBBase : TemplateDBBase<PetSkillBookItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetSkillBookItemTemplate> idKeyDic = new Dictionary<int, PetSkillBookItemTemplate>();
        
		protected static PetSkillBookItemTemplateDB _ins;
        public static PetSkillBookItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetSkillBookItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetSkillBookItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetSkillBookItemTemplate petskillbookitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(petskillbookitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petskillbookitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petskillbookitemtemplate.Id, petskillbookitemtemplate);
            return true;
        }

        public override PetSkillBookItemTemplate getTemplate(int id)
        {
            PetSkillBookItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetSkillBookItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetSkillBookItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetSkillBookItemTemplate petskillbookitemtemplate = new PetSkillBookItemTemplate();
				//id，每个表都有
				petskillbookitemtemplate.Id = reader.GetInt32(startIndex++);
		
				petskillbookitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.name = reader.GetString(startIndex++);
	
				petskillbookitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.desc = reader.GetString(startIndex++);
	
				petskillbookitemtemplate.icon = reader.GetString(startIndex++);
	
				petskillbookitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.level = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				petskillbookitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				petskillbookitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.modelId = reader.GetString(startIndex++);
	
				petskillbookitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				petskillbookitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        petskillbookitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            petskillbookitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				petskillbookitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.skillTplId = reader.GetInt32(startIndex++);
	
				petskillbookitemtemplate.bookLevel = reader.GetInt32(startIndex++);
	
				PetSkillBookItemTemplateDB.Instance.addTemplate(petskillbookitemtemplate);
				}
			}
		}

}
}