using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 战斗力相关
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetFightPowerTemplateDBBase : TemplateDBBase<PetFightPowerTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetFightPowerTemplate> idKeyDic = new Dictionary<int, PetFightPowerTemplate>();
        
		protected static PetFightPowerTemplateDB _ins;
        public static PetFightPowerTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetFightPowerTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetFightPowerTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetFightPowerTemplate petfightpowertemplate)
        {
            if (this.idKeyDic.ContainsKey(petfightpowertemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + petfightpowertemplate.Id);
                return false;
            }
            this.idKeyDic.Add(petfightpowertemplate.Id, petfightpowertemplate);
            return true;
        }

        public override PetFightPowerTemplate getTemplate(int id)
        {
            PetFightPowerTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetFightPowerTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetFightPowerTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetFightPowerTemplate petfightpowertemplate = new PetFightPowerTemplate();
				//id，每个表都有
				petfightpowertemplate.Id = reader.GetInt32(startIndex++);
		
				petfightpowertemplate.name = reader.GetString(startIndex++);
	
				petfightpowertemplate.HP = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.MP = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalAttack = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalArmor = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalHit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalDodgy = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalCrit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.physicalAnticrit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalAttack = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalArmor = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalHit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalDodgy = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalCrit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.magicalAnticrit = reader.GetDouble(startIndex++);
	
				petfightpowertemplate.speed = reader.GetDouble(startIndex++);
	
				PetFightPowerTemplateDB.Instance.addTemplate(petfightpowertemplate);
				}
			}
		}

}
}