using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 特殊奖励条件
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ExamSpecialRewardConditionTemplateDBBase : TemplateDBBase<ExamSpecialRewardConditionTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ExamSpecialRewardConditionTemplate> idKeyDic = new Dictionary<int, ExamSpecialRewardConditionTemplate>();
        
		protected static ExamSpecialRewardConditionTemplateDB _ins;
        public static ExamSpecialRewardConditionTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ExamSpecialRewardConditionTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ExamSpecialRewardConditionTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ExamSpecialRewardConditionTemplate examspecialrewardconditiontemplate)
        {
            if (this.idKeyDic.ContainsKey(examspecialrewardconditiontemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + examspecialrewardconditiontemplate.Id);
                return false;
            }
            this.idKeyDic.Add(examspecialrewardconditiontemplate.Id, examspecialrewardconditiontemplate);
            return true;
        }

        public override ExamSpecialRewardConditionTemplate getTemplate(int id)
        {
            ExamSpecialRewardConditionTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ExamSpecialRewardConditionTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ExamSpecialRewardConditionTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ExamSpecialRewardConditionTemplate examspecialrewardconditiontemplate = new ExamSpecialRewardConditionTemplate();
				//id，每个表都有
				examspecialrewardconditiontemplate.Id = reader.GetInt32(startIndex++);
		
				examspecialrewardconditiontemplate.typeId = reader.GetInt32(startIndex++);
	
				examspecialrewardconditiontemplate.rightAnswerNum = reader.GetInt32(startIndex++);
	
				examspecialrewardconditiontemplate.rewardId = reader.GetInt32(startIndex++);
	
				ExamSpecialRewardConditionTemplateDB.Instance.addTemplate(examspecialrewardconditiontemplate);
				}
			}
		}

}
}