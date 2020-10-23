using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备分解
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipDecomposeTemplateDBBase : TemplateDBBase<EquipDecomposeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipDecomposeTemplate> idKeyDic = new Dictionary<int, EquipDecomposeTemplate>();
        
		protected static EquipDecomposeTemplateDB _ins;
        public static EquipDecomposeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipDecomposeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipDecomposeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipDecomposeTemplate equipdecomposetemplate)
        {
            if (this.idKeyDic.ContainsKey(equipdecomposetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipdecomposetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipdecomposetemplate.Id, equipdecomposetemplate);
            return true;
        }

        public override EquipDecomposeTemplate getTemplate(int id)
        {
            EquipDecomposeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipDecomposeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipDecomposeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipDecomposeTemplate equipdecomposetemplate = new EquipDecomposeTemplate();
				//id，每个表都有
				equipdecomposetemplate.Id = reader.GetInt32(startIndex++);
		
				equipdecomposetemplate.color = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.lowLevel = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.hightLevel = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.currencyType = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.currencyNum = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.rewardId = reader.GetInt32(startIndex++);
	
				equipdecomposetemplate.isAvailable = reader.GetInt32(startIndex++);
	
				EquipDecomposeTemplateDB.Instance.addTemplate(equipdecomposetemplate);
				}
			}
		}

}
}