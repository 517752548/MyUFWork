using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleConfig : WebConfig<List<TitleReceiveData>>
{
    public override ServerCode mId => ServerCode.TitleConfig;
    //public override object GetRequest => new UploadTitleData((int)ServerCode.TitleConfig, TitleData.currentTitleId,
    //   TitleData.obtainId ,TitleData.showTime);
    public override void OnLoadComplete()
    {
        base.OnLoadComplete();
        if (online)
        {

        }
        else
        {

        }
        
    }
}

public class UploadTitleData
{
    public int mid;
    public int currentId;//当前使用称号ID
    public int obtainId;//获得新称号ID
    public int showTime;//限时 -1 为永久
    public UploadTitleData(int mid, int currentId, int obtainId, int showTime)
    {
        this.mid = mid;
        this.currentId = currentId;
        this.obtainId = obtainId;
        this.showTime = showTime;
    }
}

public class TitleBackData
{
    public int mId;
    public int code;
    public string ok;
}

public class DeleteTitleData
{
    public int mId;
    public int delete_id;
}

public class GetTitle
{
    public int mId;
    public int code;
    public GetTitleData data;
}
public class GetTitleData
{
    public int currentTitleId;
    public List<DataList> dataList = new List<DataList>();

}
public class DataList
{
    public int id;
    public string time;
}
public class TitleReceiveData
{
    public int id;
    public string name;
    public string resources;//sprite资源名
    public string introduce;//简介
    public int next;//下一级
    public string title;//文案
    public int scarcity;//稀有度
    public int limit;//限时
    public string theme;//主题
    public string effect;//特效
}
