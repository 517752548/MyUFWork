using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物培养消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTrainCostTemplateDBBase : TemplateDBBase<PetTrainCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTrainCostTemplate> idKeyDic = new Dictionary<int, PetTrainCostTemplate>();
        
		protected static PetTrainCostTemplateDB _ins;
        public static PetTrainCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTrainCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTrainCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTrainCostTemplate pettraincosttemplate)
        {
            if (this.idKeyDic.ContainsKey(pettraincosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettraincosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettraincosttemplate.Id, pettraincosttemplate);
            return true;
        }

        public override PetTrainCostTemplate getTemplate(int id)
        {
            PetTrainCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTrainCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTrainCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTrainCostTemplate pettraincosttemplate = new PetTrainCostTemplate();
				//id，每个表都有
				pettraincosttemplate.Id = reader.GetInt32(startIndex++);
		
				pettraincosttemplate.currencyTypeId = reader.GetInt32(startIndex++);
	
				pettraincosttemplate.currencyNum = reader.GetInt32(startIndex++);
	
				pettraincosttemplate.needVipLevel = reader.GetInt32(startIndex++);
	
				PetTrainCostTemplateDB.Instance.addTemplate(pettraincosttemplate);
				}
			}
		}

}
}