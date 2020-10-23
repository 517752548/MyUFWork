using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备重铸
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipRecastTemplateDBBase : TemplateDBBase<EquipRecastTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipRecastTemplate> idKeyDic = new Dictionary<int, EquipRecastTemplate>();
        
		protected static EquipRecastTemplateDB _ins;
        public static EquipRecastTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipRecastTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipRecastTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipRecastTemplate equiprecasttemplate)
        {
            if (this.idKeyDic.ContainsKey(equiprecasttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equiprecasttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equiprecasttemplate.Id, equiprecasttemplate);
            return true;
        }

        public override EquipRecastTemplate getTemplate(int id)
        {
            EquipRecastTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipRecastTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipRecastTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipRecastTemplate equiprecasttemplate = new EquipRecastTemplate();
				//id，每个表都有
				equiprecasttemplate.Id = reader.GetInt32(startIndex++);
		
				equiprecasttemplate.isAbleToRecast = reader.GetInt32(startIndex++);
	
				equiprecasttemplate.currencyType = reader.GetInt32(startIndex++);
	
				equiprecasttemplate.currencyNum = reader.GetInt32(startIndex++);
	
				equiprecasttemplate.itemId = reader.GetInt32(startIndex++);
	
				equiprecasttemplate.itemNum = reader.GetInt32(startIndex++);
	
				EquipRecastTemplateDB.Instance.addTemplate(equiprecasttemplate);
				}
			}
		}

}
}