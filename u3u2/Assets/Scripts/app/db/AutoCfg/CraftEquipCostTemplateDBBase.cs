using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 打造-打造花费
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CraftEquipCostTemplateDBBase : TemplateDBBase<CraftEquipCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CraftEquipCostTemplate> idKeyDic = new Dictionary<int, CraftEquipCostTemplate>();
        
		protected static CraftEquipCostTemplateDB _ins;
        public static CraftEquipCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CraftEquipCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CraftEquipCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CraftEquipCostTemplate craftequipcosttemplate)
        {
            if (this.idKeyDic.ContainsKey(craftequipcosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + craftequipcosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(craftequipcosttemplate.Id, craftequipcosttemplate);
            return true;
        }

        public override CraftEquipCostTemplate getTemplate(int id)
        {
            CraftEquipCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CraftEquipCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CraftEquipCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CraftEquipCostTemplate craftequipcosttemplate = new CraftEquipCostTemplate();
				//id，每个表都有
				craftequipcosttemplate.Id = reader.GetInt32(startIndex++);
		
				craftequipcosttemplate.equipId = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.equipTypeId = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.canCraftFlag = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.levelMin = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.levelMax = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.colorGroupId = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.costGold = reader.GetInt32(startIndex++);
	
		        craftequipcosttemplate.costItemList = new List<CraftEquipCostItem>(3);
		        for (int i = 0; i < 3; i++)
		        {
		            craftequipcosttemplate.costItemList.Add(new CraftEquipCostItem(reader, startIndex));
		            startIndex += 2;
		        }
	
				craftequipcosttemplate.recipeId = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.fixedAttrGroupId = reader.GetInt32(startIndex++);
	
				craftequipcosttemplate.itemProbGroupId = reader.GetInt32(startIndex++);
	
				CraftEquipCostTemplateDB.Instance.addTemplate(craftequipcosttemplate);
				}
			}
		}

}
}