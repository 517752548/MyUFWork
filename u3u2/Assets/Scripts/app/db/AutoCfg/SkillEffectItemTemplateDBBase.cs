using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 仙符道具
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectItemTemplateDBBase : TemplateDBBase<SkillEffectItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, SkillEffectItemTemplate> idKeyDic = new Dictionary<int, SkillEffectItemTemplate>();
        
		protected static SkillEffectItemTemplateDB _ins;
        public static SkillEffectItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new SkillEffectItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, SkillEffectItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(SkillEffectItemTemplate skilleffectitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(skilleffectitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + skilleffectitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(skilleffectitemtemplate.Id, skilleffectitemtemplate);
            return true;
        }

        public override SkillEffectItemTemplate getTemplate(int id)
        {
            SkillEffectItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get SkillEffectItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_SkillEffectItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				SkillEffectItemTemplate skilleffectitemtemplate = new SkillEffectItemTemplate();
				//id，每个表都有
				skilleffectitemtemplate.Id = reader.GetInt32(startIndex++);
		
				skilleffectitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.name = reader.GetString(startIndex++);
	
				skilleffectitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.desc = reader.GetString(startIndex++);
	
				skilleffectitemtemplate.icon = reader.GetString(startIndex++);
	
				skilleffectitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.level = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				skilleffectitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				skilleffectitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.modelId = reader.GetString(startIndex++);
	
				skilleffectitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				skilleffectitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        skilleffectitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            skilleffectitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				skilleffectitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.skillEffectId = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.initExp = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.levelMax = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.embedType = reader.GetInt32(startIndex++);
	
				skilleffectitemtemplate.uniqueFlag = reader.GetInt32(startIndex++);
	
				SkillEffectItemTemplateDB.Instance.addTemplate(skilleffectitemtemplate);
				}
			}
		}

}
}