using app.net;
using System;
using System.Collections.Generic;

	public class ConstantModel
    {
		private static ConstantModel _ins;
		private Dictionary<string,string> idKeyDic = new Dictionary<string,string>();
		public static ConstantModel Ins 
		{ 
			get 
			{
				if (_ins == null) 
				{
                    //_ins = Singleton.getObj(typeof(ConstantModel)) as ConstantModel;
                    _ins = new ConstantModel();
				}
				return _ins;
			}
		}
        
		public void setData(GCConstantList msg)
		{
			ConstantInfo[]  cis = msg.getConstantInfoList();
			for (int i = 0; i < cis.Length; i++) 
			{
				idKeyDic.Add(cis[i].key,cis[i].value);
			}
		}
        
        public void Clear()
        {
            idKeyDic.Clear();
        }

        /// <summary>
        /// 根据常量的key获得常量的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetStringValueByKey(string key)
        {
            string value = "";
            if (idKeyDic.ContainsKey(key))
            {
                idKeyDic.TryGetValue(key, out value);
            }
            return value;
        }

        /// <summary>
        /// 根据常量的key获得常量的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetIntValueByKey(string key)
        {
            string value = "";
            if (idKeyDic.ContainsKey(key))
            {
                idKeyDic.TryGetValue(key, out value);
            }
            int val = 0;
            int.TryParse(value, out val);
            return val;
        }

        
        public double GetDoubleValueByKey(string key)
        {
            double value = -1f;
            string strValue = GetStringValueByKey(key);
            if (!string.IsNullOrEmpty(strValue))
            {
               value = Convert.ToDouble(strValue);
            }
            return value;
        }

	}
