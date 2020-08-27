using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleData : BaseSyncHandData
{
    //当前称号ID
    public int currentTitleId = 0;
    //Titles titles = ;   从服务器拉取到称号数据
    public Dictionary<int, int> titleDic = new Dictionary<int, int>();

}
