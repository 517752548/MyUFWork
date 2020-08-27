using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;
using UnityEngine;

public class TestABWordLibSystem : ISystem
{

    public RecordExtra.StringPrefData WordAB;
    public override void InitSystem()
    {
        WordAB = new RecordExtra.StringPrefData(PrefKeys.WordTestAB, "X");
        //老用户全部是A
        if (AppEngine.SyncManager.Data.ClassicLevel.Value > 1 && WordAB.Value.Equals("X"))
        {
            SetADAB("A");
            OnCompleted();
            return;
        }
        if (WordAB.Value.Equals("X"))
        {
            RequestAB();
        }
        OnCompleted();
    }

    public string GetUserTestLib()
    {
#if UNITY_IOS
        return "";
#endif
        if (WordAB == null || WordAB.Value.Equals("X"))
        {
            UserEnterGame();
        }
        return WordAB.Value;
    }

    private void RequestAB()
    {
        string json = JsonConvert.SerializeObject(new BaseRequestParam(ServerCode.TestWordAB));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                //error
            }
            else
            {
                TestABResponseData responseData = JsonConvert.DeserializeObject<TestABResponseData>(back.downloadHandler.text);
                if (responseData.code != 200)
                {
                    //error
                }
                else
                {
                    if (responseData.data != null)
                    {
                        SetADAB(responseData.data.group);
                    }
                }

            }
            OnCompleted();
        }, json);
    }
    /// <summary>
    /// 设置一个词库的ab，如果这个词库已经被设置了，则不会被再设置
    /// </summary>
    /// <param name="testAB"></param>
    public void SetADAB(string testAB)
    {
        if (WordAB != null && testAB.Equals("A") && WordAB.Value.Equals("X"))
        {
            WordAB.Value = testAB;
        }
        else if (WordAB != null && testAB.Equals("B") && WordAB.Value.Equals("X"))
        {
            WordAB.Value = testAB;
        }
    }


    /// <summary>
    /// 如果读条完毕，但是玩家还没有被设置AB，则直接设置一个随机AB
    /// </summary>
    public void UserEnterGame()
    {
        if (AppEngine.SyncManager.Data.ClassicLevel.Value > 1 && WordAB.Value.Equals("X"))
        {
            SetADAB("A");
            return;
        }
        if (WordAB.Value.Equals("X"))
        {
            int id = UnityEngine.Random.Range(0, 1001);
            if (id <= 500)
            {
                SetADAB("A");
            }
            else
            {
                SetADAB("B");
            }
        }
    }
}


