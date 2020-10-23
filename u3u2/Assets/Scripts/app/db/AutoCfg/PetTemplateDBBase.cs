using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 英雄模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetTemplateDBBase : TemplateDBBase<PetTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, PetTemplate> idKeyDic = new Dictionary<int, PetTemplate>();
        
		protected static PetTemplateDB _ins;
        public static PetTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new PetTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, PetTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(PetTemplate pettemplate)
        {
            if (this.idKeyDic.ContainsKey(pettemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + pettemplate.Id);
                return false;
            }
            this.idKeyDic.Add(pettemplate.Id, pettemplate);
            return true;
        }

        public override PetTemplate getTemplate(int id)
        {
            PetTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get PetTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_PetTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				PetTemplate pettemplate = new PetTemplate();
				//id，每个表都有
				pettemplate.Id = reader.GetInt32(startIndex++);
		
				pettemplate.nameLangId = reader.GetInt64(startIndex++);
	
				pettemplate.name = reader.GetString(startIndex++);
	
				pettemplate.typeId = reader.GetInt32(startIndex++);
	
				pettemplate.attackTypeId = reader.GetInt32(startIndex++);
	
				pettemplate.sexId = reader.GetInt32(startIndex++);
	
				pettemplate.jobId = reader.GetInt32(startIndex++);
	
				pettemplate.modelId = reader.GetString(startIndex++);
	
				pettemplate.musicIds = reader.GetString(startIndex++);
	
				pettemplate.modelScale = reader.GetString(startIndex++);
	
				pettemplate.fightLevel = reader.GetInt32(startIndex++);
	
				pettemplate.petpetTypeId = reader.GetInt32(startIndex++);
	
				pettemplate.petpetKindId = reader.GetInt32(startIndex++);
	
				pettemplate.catchProb = reader.GetInt32(startIndex++);
	
				pettemplate.catchItemId = reader.GetInt32(startIndex++);
	
				pettemplate.catchItemNum = reader.GetInt32(startIndex++);
	
				pettemplate.petTransColor = reader.GetString(startIndex++);
	
				pettemplate.initGene = reader.GetInt32(startIndex++);
	
				pettemplate.initGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.leasehold = reader.GetInt32(startIndex++);
	
				pettemplate.leaseCurrencyType = reader.GetInt32(startIndex++);
	
				pettemplate.leaseCurrencyCount = reader.GetInt32(startIndex++);
	
				pettemplate.leaseItemId = reader.GetInt32(startIndex++);
	
				pettemplate.sortId = reader.GetInt32(startIndex++);
	
				pettemplate.gotDesc = reader.GetString(startIndex++);
	
				pettemplate.strength = reader.GetInt32(startIndex++);
	
				pettemplate.agility = reader.GetInt32(startIndex++);
	
				pettemplate.intellect = reader.GetInt32(startIndex++);
	
				pettemplate.faith = reader.GetInt32(startIndex++);
	
				pettemplate.stamina = reader.GetInt32(startIndex++);
	
				pettemplate.hp = reader.GetInt64(startIndex++);
	
				pettemplate.mp = reader.GetInt32(startIndex++);
	
				pettemplate.speed = reader.GetInt32(startIndex++);
	
				pettemplate.physicalAttack = reader.GetInt32(startIndex++);
	
				pettemplate.physicalArmor = reader.GetInt32(startIndex++);
	
				pettemplate.physicalHit = reader.GetInt32(startIndex++);
	
				pettemplate.physicalDodgy = reader.GetInt32(startIndex++);
	
				pettemplate.physicalCrit = reader.GetInt32(startIndex++);
	
				pettemplate.phsicalAntiCrit = reader.GetInt32(startIndex++);
	
				pettemplate.magicAttack = reader.GetInt32(startIndex++);
	
				pettemplate.magicArmor = reader.GetInt32(startIndex++);
	
				pettemplate.magicHit = reader.GetInt32(startIndex++);
	
				pettemplate.magicDodgy = reader.GetInt32(startIndex++);
	
				pettemplate.magicCrit = reader.GetInt32(startIndex++);
	
				pettemplate.magicAntiCrit = reader.GetInt32(startIndex++);
	
				pettemplate.sp = reader.GetInt32(startIndex++);
	
				pettemplate.xw = reader.GetInt32(startIndex++);
	
				pettemplate.life = reader.GetInt32(startIndex++);
	
				pettemplate.strengthGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.agilityGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.intellectGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.faithGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.staminaGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.randGrowth = reader.GetInt32(startIndex++);
	
				pettemplate.descInfo = reader.GetString(startIndex++);
	
				pettemplate.charaInfo = reader.GetString(startIndex++);
	
				pettemplate.petTalentSkillPackId = reader.GetInt32(startIndex++);
	
				pettemplate.petTrainCoef1 = reader.GetInt32(startIndex++);
	
				pettemplate.petTrainCoef2 = reader.GetInt32(startIndex++);
	
		        pettemplate.skillList = new List<SkillItem>(5);
		        for (int i = 0; i < 5; i++)
		        {
		            pettemplate.skillList.Add(new SkillItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				pettemplate.listingFeeType = reader.GetInt32(startIndex++);
	
				pettemplate.listingFee = reader.GetInt32(startIndex++);
	
				pettemplate.skillNum = reader.GetInt32(startIndex++);
	
				pettemplate.senseTalentSkillRate = reader.GetInt32(startIndex++);
	
				PetTemplateDB.Instance.addTemplate(pettemplate);
				}
			}
		}

}
}