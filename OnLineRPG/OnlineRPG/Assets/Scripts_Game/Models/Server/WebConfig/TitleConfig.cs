using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleConfig : WebConfig<List<TitleReceiveData>>
{
    public override ServerCode mId => ServerCode.TitleConfig;
}

public class TitleReceiveData
{
    public int id;
    public string name;
    public string resources;//sprite资源名
    public string introduce;//简介
    public string next;//下一级
    public string title;//文案
    public string scarcity;//稀有度
    public string limit;//限时

}
