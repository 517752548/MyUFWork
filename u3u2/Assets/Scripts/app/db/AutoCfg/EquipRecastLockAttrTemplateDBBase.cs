using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 装备锁定属性重铸
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipRecastLockAttrTemplateDBBase : TemplateDBBase<EquipRecastLockAttrTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipRecastLockAttrTemplate> idKeyDic = new Dictionary<int, EquipRecastLockAttrTemplate>();
        
		protected static EquipRecastLockAttrTemplateDB _ins;
        public static EquipRecastLockAttrTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipRecastLockAttrTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipRecastLockAttrTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipRecastLockAttrTemplate equiprecastlockattrtemplate)
        {
            if (this.idKeyDic.ContainsKey(equiprecastlockattrtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equiprecastlockattrtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equiprecastlockattrtemplate.Id, equiprecastlockattrtemplate);
            return true;
        }

        public override EquipRecastLockAttrTemplate getTemplate(int id)
        {
            EquipRecastLockAttrTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipRecastLockAttrTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipRecastLockAttrTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipRecastLockAttrTemplate equiprecastlockattrtemplate = new EquipRecastLockAttrTemplate();
				//id，每个表都有
				equiprecastlockattrtemplate.Id = reader.GetInt32(startIndex++);
		
				equiprecastlockattrtemplate.equipColorId = reader.GetInt32(startIndex++);
	
				equiprecastlockattrtemplate.lockNum = reader.GetInt32(startIndex++);
	
				equiprecastlockattrtemplate.itemId = reader.GetInt32(startIndex++);
	
				equiprecastlockattrtemplate.itemNum = reader.GetInt32(startIndex++);
	
				equiprecastlockattrtemplate.currencyType = reader.GetInt32(startIndex++);
	
				equiprecastlockattrtemplate.currencyNum = reader.GetInt32(startIndex++);
	
				EquipRecastLockAttrTemplateDB.Instance.addTemplate(equiprecastlockattrtemplate);
				}
			}
		}

}
}