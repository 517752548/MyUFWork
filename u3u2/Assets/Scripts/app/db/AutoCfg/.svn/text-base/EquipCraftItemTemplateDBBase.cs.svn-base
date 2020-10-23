using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备打造材料
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipCraftItemTemplateDBBase : TemplateDBBase<EquipCraftItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipCraftItemTemplate> idKeyDic = new Dictionary<int, EquipCraftItemTemplate>();
        
		protected static EquipCraftItemTemplateDB _ins;
        public static EquipCraftItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipCraftItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipCraftItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipCraftItemTemplate equipcraftitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(equipcraftitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipcraftitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipcraftitemtemplate.Id, equipcraftitemtemplate);
            return true;
        }

        public override EquipCraftItemTemplate getTemplate(int id)
        {
            EquipCraftItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipCraftItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipCraftItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipCraftItemTemplate equipcraftitemtemplate = new EquipCraftItemTemplate();
				//id，每个表都有
				equipcraftitemtemplate.Id = reader.GetInt32(startIndex++);
		
				equipcraftitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.name = reader.GetString(startIndex++);
	
				equipcraftitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.desc = reader.GetString(startIndex++);
	
				equipcraftitemtemplate.icon = reader.GetString(startIndex++);
	
				equipcraftitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.level = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				equipcraftitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				equipcraftitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.modelId = reader.GetString(startIndex++);
	
				equipcraftitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				equipcraftitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        equipcraftitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            equipcraftitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				equipcraftitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				equipcraftitemtemplate.groupId = reader.GetInt32(startIndex++);
	
				EquipCraftItemTemplateDB.Instance.addTemplate(equipcraftitemtemplate);
				}
			}
		}

}
}