using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 洗孔消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipHoleRefreshTemplateDBBase : TemplateDBBase<EquipHoleRefreshTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipHoleRefreshTemplate> idKeyDic = new Dictionary<int, EquipHoleRefreshTemplate>();
        
		protected static EquipHoleRefreshTemplateDB _ins;
        public static EquipHoleRefreshTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipHoleRefreshTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipHoleRefreshTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipHoleRefreshTemplate equipholerefreshtemplate)
        {
            if (this.idKeyDic.ContainsKey(equipholerefreshtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipholerefreshtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipholerefreshtemplate.Id, equipholerefreshtemplate);
            return true;
        }

        public override EquipHoleRefreshTemplate getTemplate(int id)
        {
            EquipHoleRefreshTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipHoleRefreshTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipHoleRefreshTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipHoleRefreshTemplate equipholerefreshtemplate = new EquipHoleRefreshTemplate();
				//id，每个表都有
				equipholerefreshtemplate.Id = reader.GetInt32(startIndex++);
		
				equipholerefreshtemplate.levelMin = reader.GetInt32(startIndex++);
	
				equipholerefreshtemplate.levelMax = reader.GetInt32(startIndex++);
	
				equipholerefreshtemplate.costGold = reader.GetInt32(startIndex++);
	
				equipholerefreshtemplate.itemId = reader.GetInt32(startIndex++);
	
				equipholerefreshtemplate.itemNum = reader.GetInt32(startIndex++);
	
				EquipHoleRefreshTemplateDB.Instance.addTemplate(equipholerefreshtemplate);
				}
			}
		}

}
}