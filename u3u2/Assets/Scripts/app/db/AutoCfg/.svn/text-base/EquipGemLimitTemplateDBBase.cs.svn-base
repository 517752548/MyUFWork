using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 镶嵌宝石限制
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipGemLimitTemplateDBBase : TemplateDBBase<EquipGemLimitTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipGemLimitTemplate> idKeyDic = new Dictionary<int, EquipGemLimitTemplate>();
        
		protected static EquipGemLimitTemplateDB _ins;
        public static EquipGemLimitTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipGemLimitTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipGemLimitTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipGemLimitTemplate equipgemlimittemplate)
        {
            if (this.idKeyDic.ContainsKey(equipgemlimittemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipgemlimittemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipgemlimittemplate.Id, equipgemlimittemplate);
            return true;
        }

        public override EquipGemLimitTemplate getTemplate(int id)
        {
            EquipGemLimitTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipGemLimitTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipGemLimitTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipGemLimitTemplate equipgemlimittemplate = new EquipGemLimitTemplate();
				//id，每个表都有
				equipgemlimittemplate.Id = reader.GetInt32(startIndex++);
		
				equipgemlimittemplate.posId = reader.GetInt32(startIndex++);
	
				equipgemlimittemplate.gemItemId = reader.GetInt32(startIndex++);
	
				EquipGemLimitTemplateDB.Instance.addTemplate(equipgemlimittemplate);
				}
			}
		}

}
}