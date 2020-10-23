using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 藏宝图任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TreasureMapTemplateDBBase : TemplateDBBase<TreasureMapTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, TreasureMapTemplate> idKeyDic = new Dictionary<int, TreasureMapTemplate>();
        
		protected static TreasureMapTemplateDB _ins;
        public static TreasureMapTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new TreasureMapTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, TreasureMapTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(TreasureMapTemplate treasuremaptemplate)
        {
            if (this.idKeyDic.ContainsKey(treasuremaptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + treasuremaptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(treasuremaptemplate.Id, treasuremaptemplate);
            return true;
        }

        public override TreasureMapTemplate getTemplate(int id)
        {
            TreasureMapTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get TreasureMapTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_TreasureMapTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				TreasureMapTemplate treasuremaptemplate = new TreasureMapTemplate();
				//id，每个表都有
				treasuremaptemplate.Id = reader.GetInt32(startIndex++);
		
				treasuremaptemplate.levelMin = reader.GetInt32(startIndex++);
	
				treasuremaptemplate.levelMax = reader.GetInt32(startIndex++);
	
				treasuremaptemplate.questGroupId = reader.GetInt32(startIndex++);
	
				TreasureMapTemplateDB.Instance.addTemplate(treasuremaptemplate);
				}
			}
		}

}
}