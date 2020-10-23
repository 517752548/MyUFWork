using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 打造-装备类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CraftEquipTypeTemplateDBBase : TemplateDBBase<CraftEquipTypeTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, CraftEquipTypeTemplate> idKeyDic = new Dictionary<int, CraftEquipTypeTemplate>();
        
		protected static CraftEquipTypeTemplateDB _ins;
        public static CraftEquipTypeTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new CraftEquipTypeTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, CraftEquipTypeTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(CraftEquipTypeTemplate craftequiptypetemplate)
        {
            if (this.idKeyDic.ContainsKey(craftequiptypetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + craftequiptypetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(craftequiptypetemplate.Id, craftequiptypetemplate);
            return true;
        }

        public override CraftEquipTypeTemplate getTemplate(int id)
        {
            CraftEquipTypeTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get CraftEquipTypeTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_CraftEquipTypeTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				CraftEquipTypeTemplate craftequiptypetemplate = new CraftEquipTypeTemplate();
				//id，每个表都有
				craftequiptypetemplate.Id = reader.GetInt32(startIndex++);
		
				craftequiptypetemplate.name = reader.GetString(startIndex++);
	
				CraftEquipTypeTemplateDB.Instance.addTemplate(craftequiptypetemplate);
				}
			}
		}

}
}