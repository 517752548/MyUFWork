using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 宠物培养数值
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTrainPropTemplateDBBase : TemplateDBBase<PetTrainPropTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTrainPropTemplate> idKeyDic = new Dictionary<int, PetTrainPropTemplate>();
        
		protected static PetTrainPropTemplateDB _ins;
        public static PetTrainPropTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTrainPropTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTrainPropTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTrainPropTemplate pettrainproptemplate)
        {
            if (this.idKeyDic.ContainsKey(pettrainproptemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettrainproptemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettrainproptemplate.Id, pettrainproptemplate);
            return true;
        }

        public override PetTrainPropTemplate getTemplate(int id)
        {
            PetTrainPropTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTrainPropTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTrainPropTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTrainPropTemplate pettrainproptemplate = new PetTrainPropTemplate();
				//id，每个表都有
				pettrainproptemplate.Id = reader.GetInt32(startIndex++);
		
				pettrainproptemplate.trainTypeId = reader.GetInt32(startIndex++);
	
				pettrainproptemplate.minusFlag = reader.GetInt32(startIndex++);
	
				pettrainproptemplate.propMin = reader.GetInt32(startIndex++);
	
				pettrainproptemplate.propMax = reader.GetInt32(startIndex++);
	
				pettrainproptemplate.weight = reader.GetInt32(startIndex++);
	
				PetTrainPropTemplateDB.Instance.addTemplate(pettrainproptemplate);
				}
			}
		}

}
}