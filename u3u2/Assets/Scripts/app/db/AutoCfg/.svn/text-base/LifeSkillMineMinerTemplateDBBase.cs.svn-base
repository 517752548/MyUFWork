using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 生活技能-采矿-矿工
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineMinerTemplateDBBase : TemplateDBBase<LifeSkillMineMinerTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, LifeSkillMineMinerTemplate> idKeyDic = new Dictionary<int, LifeSkillMineMinerTemplate>();
        
		protected static LifeSkillMineMinerTemplateDB _ins;
        public static LifeSkillMineMinerTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new LifeSkillMineMinerTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, LifeSkillMineMinerTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(LifeSkillMineMinerTemplate lifeskillmineminertemplate)
        {
            if (this.idKeyDic.ContainsKey(lifeskillmineminertemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + lifeskillmineminertemplate.Id);
                return false;
            }
            this.idKeyDic.Add(lifeskillmineminertemplate.Id, lifeskillmineminertemplate);
            return true;
        }

        public override LifeSkillMineMinerTemplate getTemplate(int id)
        {
            LifeSkillMineMinerTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get LifeSkillMineMinerTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_LifeSkillMineMinerTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				LifeSkillMineMinerTemplate lifeskillmineminertemplate = new LifeSkillMineMinerTemplate();
				//id，每个表都有
				lifeskillmineminertemplate.Id = reader.GetInt32(startIndex++);
		
				lifeskillmineminertemplate.name = reader.GetString(startIndex++);
	
				lifeskillmineminertemplate.minerModelId = reader.GetInt32(startIndex++);
	
				LifeSkillMineMinerTemplateDB.Instance.addTemplate(lifeskillmineminertemplate);
				}
			}
		}

}
}