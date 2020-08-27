using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using UnityEngine;

public class DailyRequestWord : BaseRequestParam
{
    public int daily;
    public DailyRequestWord(ServerCode MId, int day):base(MId)
    {
        daily = day;
    }
}

public class DailyWordList : BaseResponseData<DailyWords>
{
}

public class DailyWords
{
    public List<DailyQuestionEntity> dailyInit;
}