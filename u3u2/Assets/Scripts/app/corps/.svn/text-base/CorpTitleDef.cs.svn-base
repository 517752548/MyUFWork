using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CorpTitleDef
{
    /// <summary>
    /// 帮派职位定义
    /// </summary>
    public enum CorpTitleType
    {
        NONE,
        BANGZHONG,
        JINGYING,
        FUBANGZHU,
        BANGZHU
    }

    public static string GetCorpTitleName(int titleid)
    {
        string name = LangConstant.BANGPAI + LangConstant.ZHIWEI;
        switch (titleid)
        {
            case (int)CorpTitleType.BANGZHONG:
                name = LangConstant.BANGZHONG;
            break;
            case (int)CorpTitleType.JINGYING:
            name = LangConstant.JINGYING;
            break;
            case (int)CorpTitleType.FUBANGZHU:
            name = LangConstant.FUBANGZHU;
            break;
            case (int)CorpTitleType.BANGZHU:
            name = LangConstant.BANGZHU;
            break;
        }
        return name;
    }

}
