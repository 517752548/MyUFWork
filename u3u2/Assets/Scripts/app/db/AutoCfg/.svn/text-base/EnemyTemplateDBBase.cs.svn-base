using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 单个怪物表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyTemplateDBBase : TemplateDBBase<EnemyTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, EnemyTemplate> idKeyDic = new Dictionary<int, EnemyTemplate>();
        
		protected static EnemyTemplateDB _ins;
        public static EnemyTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new EnemyTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, EnemyTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(EnemyTemplate enemytemplate)
        {
            if (this.idKeyDic.ContainsKey(enemytemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + enemytemplate.Id);
                return false;
            }
            this.idKeyDic.Add(enemytemplate.Id, enemytemplate);
            return true;
        }

        public override EnemyTemplate getTemplate(int id)
        {
            EnemyTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get EnemyTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_EnemyTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				EnemyTemplate enemytemplate = new EnemyTemplate();
				//id，每个表都有
				enemytemplate.Id = reader.GetInt32(startIndex++);
		
				enemytemplate.nameLangId = reader.GetInt64(startIndex++);
	
				enemytemplate.name = reader.GetString(startIndex++);
	
				enemytemplate.attackTypeId = reader.GetInt32(startIndex++);
	
				enemytemplate.sexId = reader.GetInt32(startIndex++);
	
				enemytemplate.jobId = reader.GetInt32(startIndex++);
	
				enemytemplate.modelId = reader.GetString(startIndex++);
	
				enemytemplate.musicIds = reader.GetString(startIndex++);
	
				enemytemplate.modelHeight = reader.GetFloat(startIndex++);
	
				enemytemplate.level = reader.GetInt32(startIndex++);
	
				enemytemplate.petTplId = reader.GetInt32(startIndex++);
	
				enemytemplate.hp = reader.GetInt64(startIndex++);
	
				enemytemplate.mp = reader.GetInt32(startIndex++);
	
				enemytemplate.speed = reader.GetInt32(startIndex++);
	
				enemytemplate.physicalAttack = reader.GetInt32(startIndex++);
	
				enemytemplate.physicalArmor = reader.GetInt32(startIndex++);
	
				enemytemplate.physicalHit = reader.GetInt32(startIndex++);
	
				enemytemplate.physicalDodgy = reader.GetInt32(startIndex++);
	
				enemytemplate.physicalCrit = reader.GetInt32(startIndex++);
	
				enemytemplate.phsicalAntiCrit = reader.GetInt32(startIndex++);
	
				enemytemplate.magicAttack = reader.GetInt32(startIndex++);
	
				enemytemplate.magicArmor = reader.GetInt32(startIndex++);
	
				enemytemplate.magicHit = reader.GetInt32(startIndex++);
	
				enemytemplate.magicDodgy = reader.GetInt32(startIndex++);
	
				enemytemplate.magicCrit = reader.GetInt32(startIndex++);
	
				enemytemplate.magicAntiCrit = reader.GetInt32(startIndex++);
	
				enemytemplate.sp = reader.GetInt32(startIndex++);
	
				enemytemplate.xw = reader.GetInt32(startIndex++);
	
				enemytemplate.life = reader.GetInt32(startIndex++);
	
				enemytemplate.strengthGrowth = reader.GetInt32(startIndex++);
	
				enemytemplate.agilityGrowth = reader.GetInt32(startIndex++);
	
				enemytemplate.intellectGrowth = reader.GetInt32(startIndex++);
	
				enemytemplate.faithGrowth = reader.GetInt32(startIndex++);
	
				enemytemplate.staminaGrowth = reader.GetInt32(startIndex++);
	
		        enemytemplate.skillList = new List<SkillItem>(5);
		        for (int i = 0; i < 5; i++)
		        {
		            enemytemplate.skillList.Add(new SkillItem(reader, startIndex));
		            startIndex += 3;
		        }
	
				enemytemplate.speakList = new List<string>(3);
				for (int i = 0; i < 3; i++)
		        {
		            enemytemplate.speakList.Add(reader.GetString(startIndex++));
		        }
	
				EnemyTemplateDB.Instance.addTemplate(enemytemplate);
				}
			}
		}

}
}