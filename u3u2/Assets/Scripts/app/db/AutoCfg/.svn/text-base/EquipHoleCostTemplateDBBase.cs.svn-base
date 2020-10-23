using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 打孔消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipHoleCostTemplateDBBase : TemplateDBBase<EquipHoleCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EquipHoleCostTemplate> idKeyDic = new Dictionary<int, EquipHoleCostTemplate>();
        
		protected static EquipHoleCostTemplateDB _ins;
        public static EquipHoleCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EquipHoleCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EquipHoleCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EquipHoleCostTemplate equipholecosttemplate)
        {
            if (this.idKeyDic.ContainsKey(equipholecosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + equipholecosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(equipholecosttemplate.Id, equipholecosttemplate);
            return true;
        }

        public override EquipHoleCostTemplate getTemplate(int id)
        {
            EquipHoleCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EquipHoleCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EquipHoleCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EquipHoleCostTemplate equipholecosttemplate = new EquipHoleCostTemplate();
				//id，每个表都有
				equipholecosttemplate.Id = reader.GetInt32(startIndex++);
		
				equipholecosttemplate.hole = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.levelMin = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.levelMax = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.costGold = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.itemId1 = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.itemNum1 = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.itemId2 = reader.GetInt32(startIndex++);
	
				equipholecosttemplate.itemNum2 = reader.GetInt32(startIndex++);
	
				EquipHoleCostTemplateDB.Instance.addTemplate(equipholecosttemplate);
				}
			}
		}

}
}