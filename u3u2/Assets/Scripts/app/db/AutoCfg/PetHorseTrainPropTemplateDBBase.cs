using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 骑宠培养数值
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorseTrainPropTemplateDBBase : TemplateDBBase<PetHorseTrainPropTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetHorseTrainPropTemplate> idKeyDic = new Dictionary<int, PetHorseTrainPropTemplate>();
        
		protected static PetHorseTrainPropTemplateDB _ins;
        public static PetHorseTrainPropTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetHorseTrainPropTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetHorseTrainPropTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetHorseTrainPropTemplate pethorsetrainproptemplate)
        {
            if (this.idKeyDic.ContainsKey(pethorsetrainproptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pethorsetrainproptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pethorsetrainproptemplate.Id, pethorsetrainproptemplate);
            return true;
        }

        public override PetHorseTrainPropTemplate getTemplate(int id)
        {
            PetHorseTrainPropTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetHorseTrainPropTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetHorseTrainPropTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetHorseTrainPropTemplate pethorsetrainproptemplate = new PetHorseTrainPropTemplate();
				//id，每个表都有
				pethorsetrainproptemplate.Id = reader.GetInt32(startIndex++);
		
				pethorsetrainproptemplate.trainTypeId = reader.GetInt32(startIndex++);
	
				pethorsetrainproptemplate.minusFlag = reader.GetInt32(startIndex++);
	
				pethorsetrainproptemplate.propMin = reader.GetInt32(startIndex++);
	
				pethorsetrainproptemplate.propMax = reader.GetInt32(startIndex++);
	
				pethorsetrainproptemplate.weight = reader.GetInt32(startIndex++);
	
				PetHorseTrainPropTemplateDB.Instance.addTemplate(pethorsetrainproptemplate);
				}
			}
		}

}
}