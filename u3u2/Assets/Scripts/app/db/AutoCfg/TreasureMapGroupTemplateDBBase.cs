using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 藏宝图任务组模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TreasureMapGroupTemplateDBBase : TemplateDBBase<TreasureMapGroupTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TreasureMapGroupTemplate> idKeyDic = new Dictionary<int, TreasureMapGroupTemplate>();
        
		protected static TreasureMapGroupTemplateDB _ins;
        public static TreasureMapGroupTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TreasureMapGroupTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TreasureMapGroupTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TreasureMapGroupTemplate treasuremapgrouptemplate)
        {
            if (this.idKeyDic.ContainsKey(treasuremapgrouptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + treasuremapgrouptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(treasuremapgrouptemplate.Id, treasuremapgrouptemplate);
            return true;
        }

        public override TreasureMapGroupTemplate getTemplate(int id)
        {
            TreasureMapGroupTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TreasureMapGroupTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TreasureMapGroupTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TreasureMapGroupTemplate treasuremapgrouptemplate = new TreasureMapGroupTemplate();
				//id，每个表都有
				treasuremapgrouptemplate.Id = reader.GetInt32(startIndex++);
		
				treasuremapgrouptemplate.questGroupId = reader.GetInt32(startIndex++);
	
				treasuremapgrouptemplate.questId = reader.GetInt32(startIndex++);
	
				treasuremapgrouptemplate.weight = reader.GetInt32(startIndex++);
	
				TreasureMapGroupTemplateDB.Instance.addTemplate(treasuremapgrouptemplate);
				}
			}
		}

}
}