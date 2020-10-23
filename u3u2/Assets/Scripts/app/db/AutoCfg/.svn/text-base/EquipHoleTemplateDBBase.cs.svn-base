using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备孔数
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipHoleTemplateDBBase : TemplateDBBase<EquipHoleTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipHoleTemplate> idKeyDic = new Dictionary<int, EquipHoleTemplate>();
        
		protected static EquipHoleTemplateDB _ins;
        public static EquipHoleTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipHoleTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipHoleTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipHoleTemplate equipholetemplate)
        {
            if (this.idKeyDic.ContainsKey(equipholetemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipholetemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipholetemplate.Id, equipholetemplate);
            return true;
        }

        public override EquipHoleTemplate getTemplate(int id)
        {
            EquipHoleTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipHoleTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipHoleTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipHoleTemplate equipholetemplate = new EquipHoleTemplate();
				//id，每个表都有
				equipholetemplate.Id = reader.GetInt32(startIndex++);
		
				equipholetemplate.colorId = reader.GetInt32(startIndex++);
	
				equipholetemplate.levelMin = reader.GetInt32(startIndex++);
	
				equipholetemplate.levelMax = reader.GetInt32(startIndex++);
	
				equipholetemplate.maxHoleNum = reader.GetInt32(startIndex++);
	
				EquipHoleTemplateDB.Instance.addTemplate(equipholetemplate);
				}
			}
		}

}
}