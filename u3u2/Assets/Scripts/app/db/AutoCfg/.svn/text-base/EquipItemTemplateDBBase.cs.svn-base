using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备物品模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipItemTemplateDBBase : TemplateDBBase<EquipItemTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipItemTemplate> idKeyDic = new Dictionary<int, EquipItemTemplate>();
        
		protected static EquipItemTemplateDB _ins;
        public static EquipItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipItemTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipItemTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipItemTemplate equipitemtemplate)
        {
            if (this.idKeyDic.ContainsKey(equipitemtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipitemtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipitemtemplate.Id, equipitemtemplate);
            return true;
        }

        public override EquipItemTemplate getTemplate(int id)
        {
            EquipItemTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipItemTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipItemTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipItemTemplate equipitemtemplate = new EquipItemTemplate();
				//id，每个表都有
				equipitemtemplate.Id = reader.GetInt32(startIndex++);
		
				equipitemtemplate.nameLangId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.name = reader.GetString(startIndex++);
	
				equipitemtemplate.descLangId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.desc = reader.GetString(startIndex++);
	
				equipitemtemplate.icon = reader.GetString(startIndex++);
	
				equipitemtemplate.bindTypeId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.identityTypeId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.itemTypeId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.bagId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.rarityId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.level = reader.GetInt32(startIndex++);
	
				equipitemtemplate.maxOverlap = reader.GetInt32(startIndex++);
	
				equipitemtemplate.pageId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.orderId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.canUsed = reader.GetBoolean(startIndex++);
	
				equipitemtemplate.canSelled = reader.GetBoolean(startIndex++);
	
				equipitemtemplate.sellCurrencyId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.sellPrice = reader.GetInt32(startIndex++);
	
				equipitemtemplate.modelId = reader.GetString(startIndex++);
	
				equipitemtemplate.canCompose = reader.GetBoolean(startIndex++);
	
				equipitemtemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				equipitemtemplate.listingFee = reader.GetInt32(startIndex++);
	
				equipitemtemplate.tradeBasePriceType = reader.GetInt32(startIndex++);
	
				equipitemtemplate.tradeBasePrice = reader.GetInt32(startIndex++);
	
		        equipitemtemplate.wayList = new List<ItemGetWayTemplate>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            equipitemtemplate.wayList.Add(new ItemGetWayTemplate(reader, startIndex));
		            startIndex += 3;
		        }
	
				equipitemtemplate.expiredHour = reader.GetInt32(startIndex++);
	
				equipitemtemplate.composeNum = reader.GetInt32(startIndex++);
	
				equipitemtemplate.composeItemId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.composeGold = reader.GetInt32(startIndex++);
	
				equipitemtemplate.isFixedAttr = reader.GetInt32(startIndex++);
	
				equipitemtemplate.positionId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.gradeId = reader.GetInt32(startIndex++);
	
				equipitemtemplate.jobLimit = reader.GetInt32(startIndex++);
	
				equipitemtemplate.sexLimit = reader.GetInt32(startIndex++);
	
				equipitemtemplate.propLimit = reader.GetInt32(startIndex++);
	
				equipitemtemplate.propValueLimit = reader.GetInt32(startIndex++);
	
				equipitemtemplate.durability = reader.GetInt32(startIndex++);
	
				equipitemtemplate.leftModel = reader.GetString(startIndex++);
	
				equipitemtemplate.rightModel = reader.GetString(startIndex++);
	
				equipitemtemplate.basePropValue = reader.GetInt32(startIndex++);
	
				equipitemtemplate.addPropValue = reader.GetInt32(startIndex++);
	
				equipitemtemplate.bindPropValue = reader.GetInt32(startIndex++);
	
		        equipitemtemplate.basePropList = new List<EquipItemAttribute>(1);
		        for (int i = 0; i < 1; i++)
		        {
		            equipitemtemplate.basePropList.Add(new EquipItemAttribute(reader, startIndex));
		            startIndex += 2;
		        }
	
		        equipitemtemplate.addPropList = new List<EquipItemAttribute>(6);
		        for (int i = 0; i < 6; i++)
		        {
		            equipitemtemplate.addPropList.Add(new EquipItemAttribute(reader, startIndex));
		            startIndex += 2;
		        }
	
				EquipItemTemplateDB.Instance.addTemplate(equipitemtemplate);
				}
			}
		}

}
}