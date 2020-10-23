using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace app.db
{
	/**
	 * 任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class QuestTemplateDBBase : TemplateDBBase<QuestTemplate>
	{
		// key模板Id，value模板对象
        protected Dictionary<int, QuestTemplate> idKeyDic = new Dictionary<int, QuestTemplate>();
        
		protected static QuestTemplateDB _ins;
        public static QuestTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new QuestTemplateDB();
                }
                return _ins;
            }
        }
        
        public override Dictionary<int, QuestTemplate> getIdKeyDic()
        {
            return idKeyDic;
        }

        public override bool addTemplate(QuestTemplate questtemplate)
        {
            if (this.idKeyDic.ContainsKey(questtemplate.Id))
            {
                ClientLog.LogError("error! idKeyDic id is: " + questtemplate.Id);
                return false;
            }
            this.idKeyDic.Add(questtemplate.Id, questtemplate);
            return true;
        }

        public override QuestTemplate getTemplate(int id)
        {
            QuestTemplate data = null;
            this.idKeyDic.TryGetValue(id, out data);
            if (data == null)
            {
                ClientLog.LogError("get QuestTemplate error!data is null! id=" + id);
            }
            return data;
        }

		public override void loadAllTemplate()
		{
			using (SqliteDataReader reader = DbAccess.Instance.ReadFullTable("t_QuestTemplate"))
			{
				while (reader.Read())
				{
				int startIndex = 0;
				
				QuestTemplate questtemplate = new QuestTemplate();
				//id，每个表都有
				questtemplate.Id = reader.GetInt32(startIndex++);
		
				questtemplate.titleLangId = reader.GetInt64(startIndex++);
	
				questtemplate.title = reader.GetString(startIndex++);
	
				questtemplate.questType = reader.GetInt32(startIndex++);
	
				questtemplate.repeat = reader.GetBoolean(startIndex++);
	
				questtemplate.dailyTimes = reader.GetInt32(startIndex++);
	
				questtemplate.preQuestId = reader.GetInt32(startIndex++);
	
				questtemplate.acceptMinLevel = reader.GetInt32(startIndex++);
	
				questtemplate.minTeamMemberNum = reader.GetInt32(startIndex++);
	
		        questtemplate.specialCondition = new List<SpecialCondition>(2);
		        for (int i = 0; i < 2; i++)
		        {
		            questtemplate.specialCondition.Add(new SpecialCondition(reader, startIndex));
		            startIndex += 3;
		        }
	
				questtemplate.rewardId = reader.GetInt32(startIndex++);
	
				questtemplate.showRewardId = reader.GetInt32(startIndex++);
	
				questtemplate.desc = reader.GetString(startIndex++);
	
				questtemplate.finishNpcTalkDescLangId = reader.GetInt64(startIndex++);
	
				questtemplate.finishNpcTalkDesc = reader.GetString(startIndex++);
	
				questtemplate.requireDescLangId = reader.GetInt64(startIndex++);
	
				questtemplate.requireDesc = reader.GetString(startIndex++);
	
				questtemplate.finishDescLangId = reader.GetInt64(startIndex++);
	
				questtemplate.finishDesc = reader.GetString(startIndex++);
	
				questtemplate.startNpcMapId = reader.GetInt32(startIndex++);
	
				questtemplate.startNpc = reader.GetInt32(startIndex++);
	
				questtemplate.endNpcMapId = reader.GetInt32(startIndex++);
	
				questtemplate.endNpc = reader.GetInt32(startIndex++);
	
				questtemplate.autoAccept = reader.GetInt32(startIndex++);
	
				questtemplate.autoFinish = reader.GetInt32(startIndex++);
	
				questtemplate.storyId = reader.GetInt32(startIndex++);
	
				questtemplate.videoStoryId = reader.GetInt32(startIndex++);
	
				questtemplate.pathStr = reader.GetString(startIndex++);
	
		        questtemplate.specialDestination = new List<SpecialDestination>(1);
		        for (int i = 0; i < 1; i++)
		        {
		            questtemplate.specialDestination.Add(new SpecialDestination(reader, startIndex));
		            startIndex += 6;
		        }
	
				questtemplate.rewardIdOnCondition = new List<int>(8);
				for (int i = 0; i < 8; i++)
		        {
		            questtemplate.rewardIdOnCondition.Add(reader.GetInt32(startIndex++));
		        }
	
				questtemplate.enemyArmyIdList = new List<int>(5);
				for (int i = 0; i < 5; i++)
		        {
		            questtemplate.enemyArmyIdList.Add(reader.GetInt32(startIndex++));
		        }
	
				questtemplate.taskDropRewardId = reader.GetInt32(startIndex++);
	
				QuestTemplateDB.Instance.addTemplate(questtemplate);
				}
			}
		}

}
}