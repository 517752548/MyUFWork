using System.Collections.Generic;
using System.Linq;

namespace app.db
{
    public class ExamTemplateDB : ExamTemplateDBBase
    {
		protected Dictionary<int,ExamTemplate> idKeyDic = new Dictionary<int,ExamTemplate >();
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

		public void loadAllCfg()
		{
			loadExamTemplateByDB(ExamTemplateDB.Instance);
		}
		
		public void clearAllCfg()
		{
			ExamTemplateDB.Instance.getIdKeyDic().Clear();
			idKeyDic.Clear();
		}
		private void loadExamTemplateByDB<D>(TemplateDBBase<D> db) where D : ExamTemplate
		{
			db.loadAllTemplate();
			List<int> keyList = db.getIdKeyDic().Keys.Cast<int>().ToList<int>();
			for (int i = 0; i < keyList.Count; i++)
			{
				int id = keyList[i];
				addData(id, db.getTemplate(id) as ExamTemplate);
			}
			// XXX 将原来的数据删掉，统一从该类[ItemTemplateDB]获取数据
			db.getIdKeyDic().Clear();
		}
		private void addData(int id,ExamTemplate value)
		{
			this.idKeyDic.Add(id,value);
		}
		public ExamTemplate getTemplate(int id)
		{
			ExamTemplate value = null;
			idKeyDic.TryGetValue(id,out value);
			return value;
		}
    }
}
