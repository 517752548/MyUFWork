using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 战斗属性系数表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class BattlePropCoefTemplateDBBase : TemplateDBBase<BattlePropCoefTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, BattlePropCoefTemplate> idKeyDic = new Dictionary<int, BattlePropCoefTemplate>();
        
		protected static BattlePropCoefTemplateDB _ins;
        public static BattlePropCoefTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new BattlePropCoefTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, BattlePropCoefTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(BattlePropCoefTemplate battlepropcoeftemplate)
        {
            if (this.idKeyDic.ContainsKey(battlepropcoeftemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + battlepropcoeftemplate.Id);
                return false;
            }
            this.idKeyDic.Add(battlepropcoeftemplate.Id, battlepropcoeftemplate);
            return true;
        }

        public override BattlePropCoefTemplate getTemplate(int id)
        {
            BattlePropCoefTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get BattlePropCoefTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_BattlePropCoefTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				BattlePropCoefTemplate battlepropcoeftemplate = new BattlePropCoefTemplate();
				//id，每个表都有
				battlepropcoeftemplate.Id = reader.GetInt32(startIndex++);
		
				battlepropcoeftemplate.phArmor = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.phHit = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.phDodgy = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.phCrit = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.phAntiCrit = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.maArmor = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.maHit = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.maDodgy = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.maCrit = reader.GetInt32(startIndex++);
	
				battlepropcoeftemplate.maAntiCrit = reader.GetInt32(startIndex++);
	
				BattlePropCoefTemplateDB.Instance.addTemplate(battlepropcoeftemplate);
				}
			}
		}

}
}