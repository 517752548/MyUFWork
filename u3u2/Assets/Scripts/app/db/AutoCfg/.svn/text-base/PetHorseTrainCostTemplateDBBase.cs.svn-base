using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠培养消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseTrainCostTemplateDBBase : TemplateDBBase<PetHorseTrainCostTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseTrainCostTemplate> idKeyDic = new Dictionary<int, PetHorseTrainCostTemplate>();
        
		protected static PetHorseTrainCostTemplateDB _ins;
        public static PetHorseTrainCostTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseTrainCostTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseTrainCostTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseTrainCostTemplate pethorsetraincosttemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsetraincosttemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsetraincosttemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsetraincosttemplate.Id, pethorsetraincosttemplate);
            return true;
        }

        public override PetHorseTrainCostTemplate getTemplate(int id)
        {
            PetHorseTrainCostTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseTrainCostTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseTrainCostTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseTrainCostTemplate pethorsetraincosttemplate = new PetHorseTrainCostTemplate();
				//id，每个表都有
				pethorsetraincosttemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsetraincosttemplate.currencyTypeId = reader.GetInt32(startIndex++);
	
				pethorsetraincosttemplate.currencyNum = reader.GetInt32(startIndex++);
	
				pethorsetraincosttemplate.needVipLevel = reader.GetInt32(startIndex++);
	
				PetHorseTrainCostTemplateDB.Instance.addTemplate(pethorsetraincosttemplate);
				}
			}
		}

}
}