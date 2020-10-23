using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 科举试题
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ExamTemplateDBBase : TemplateDBBase<ExamTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, ExamTemplate> idKeyDic = new Dictionary<int, ExamTemplate>();
        
		protected static ExamTemplateDB _ins;
        public static ExamTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ExamTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, ExamTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(ExamTemplate examtemplate)
        {
            if (this.idKeyDic.ContainsKey(examtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + examtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(examtemplate.Id, examtemplate);
            return true;
        }

        public override ExamTemplate getTemplate(int id)
        {
            ExamTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get ExamTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_ExamTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				ExamTemplate examtemplate = new ExamTemplate();
				//id，每个表都有
				examtemplate.Id = reader.GetInt32(startIndex++);
		
				examtemplate.name = reader.GetString(startIndex++);
	
				examtemplate.typeId = reader.GetInt32(startIndex++);
	
				examtemplate.rightAnswerID = reader.GetInt32(startIndex++);
	
				examtemplate.firstAnswerID = reader.GetInt32(startIndex++);
	
				examtemplate.firstAnswer = reader.GetString(startIndex++);
	
				examtemplate.secendAnswerID = reader.GetInt32(startIndex++);
	
				examtemplate.secendAnswer = reader.GetString(startIndex++);
	
				examtemplate.thirdAnswerID = reader.GetInt32(startIndex++);
	
				examtemplate.thirdAnswer = reader.GetString(startIndex++);
	
				examtemplate.fourthAnswerID = reader.GetInt32(startIndex++);
	
				examtemplate.fourthAnswer = reader.GetString(startIndex++);
	
				examtemplate.rightAnswerRewardId = reader.GetInt32(startIndex++);
	
				examtemplate.wrongAnswerRewardId = reader.GetInt32(startIndex++);
	
				ExamTemplateDB.Instance.addTemplate(examtemplate);
				}
			}
		}

}
}