using IFix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

//在这里配置哪些文件可以打补丁
[Configure]
public class IFixConfig
{
    [IFix]
    static IEnumerable<Type> ToProcess
    {
        get
        {
            return Assembly.Load("Assembly-CSharp").GetTypes();
            //return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
            //        where type.Name.Equals("IFixMgr")
            //        select type);
        }
    }
}