
using System.Collections.Generic;
using app.utils;

namespace app.db
{
    public class VipConfigTemplateDB : VipConfigTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public string GetVipTeQuanTextByLevel(int viplevel)
        {
            string str = "";
            foreach (KeyValuePair<int, VipConfigTemplate> pair in idKeyDic)
            {
                for (int i = 0; i < pair.Value.vipItemList.Count; i++)
                {
                    if (i == viplevel)
                    {
                        if (pair.Value.vipItemList[i].open&&pair.Value.desc != null)
                        {
                            if (!pair.Value.desc.Contains("{0}"))
                            {
                                str += pair.Value.desc+"\n";
                            }
                            else
                            {
                                str += StringUtil.Assemble(pair.Value.desc,
                                    new string[1] {pair.Value.vipItemList[i].num + ""})+"\n";
                            }
                        }
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 获得特权开放的vip等级
        /// </summary>
        /// <param name="tequanId">特权id，取值 VIPTeQuanIdDef</param>
        /// <returns></returns>
        public int GetVipTeQuanOpenLevel(int tequanId)
        {
            VipConfigTemplate tpl = getTemplate(tequanId);
            if (tpl==null)
            {
                return -1;
            }
            for (int i = 0; i < tpl.vipItemList.Count; i++)
            {
                if (tpl.vipItemList[i].open)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}