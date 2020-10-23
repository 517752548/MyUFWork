using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 打造-材料提升概率
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CraftEquipItemProbTemplateDBBase : TemplateDBBase<CraftEquipItemProbTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CraftEquipItemProbTemplate> idKeyDic = new Dictionary<int, CraftEquipItemProbTemplate>();
        
		protected static CraftEquipItemProbTemplateDB _ins;
        public static CraftEquipItemProbTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CraftEquipItemProbTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CraftEquipItemProbTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CraftEquipItemProbTemplate craftequipitemprobtemplate)
        {
            if (this.idKeyDic.ContainsKey(craftequipitemprobtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + craftequipitemprobtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(craftequipitemprobtemplate.Id, craftequipitemprobtemplate);
            return true;
        }

        public override CraftEquipItemProbTemplate getTemplate(int id)
        {
            CraftEquipItemProbTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CraftEquipItemProbTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CraftEquipItemProbTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CraftEquipItemProbTemplate craftequipitemprobtemplate = new CraftEquipItemProbTemplate();
				//id，每个表都有
				craftequipitemprobtemplate.Id = reader.GetInt32(startIndex++);
		
				craftequipitemprobtemplate.groupId = reader.GetInt32(startIndex++);
	
				craftequipitemprobtemplate.gradeId = reader.GetInt32(startIndex++);
	
				craftequipitemprobtemplate.propList = new List<int>(5);
				for (int i = 0; i < 5; i++)
		        {
		            craftequipitemprobtemplate.propList.Add(reader.GetInt32(startIndex++));
		        }
	
				craftequipitemprobtemplate.maxNum = reader.GetInt32(startIndex++);
	
				CraftEquipItemProbTemplateDB.Instance.addTemplate(craftequipitemprobtemplate);
				}
			}
		}

}
}