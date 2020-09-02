using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;
using UnityEngine;

public class TestABSystem : ISystem
{
    public RecordExtra.StringPrefData ADAB;
    private AdsConfig _AdsConfig;

    public override void InitSystem()
    {
        if (ADAB == null)
            ADAB = new RecordExtra.StringPrefData(PrefKeys.ADTestAB, "X");
        if (ADAB.Value.Equals("X"))
        {
            //RequestAB();
            UserEnterGame();
        }
#if UNITY_IOS
        ResourceManager.LoadAsync<AdsConfig>( 
            ADAB.Value == "A" ? ViewConst.asset_AdsConfig_IosA : ViewConst.asset_AdsConfig_IosB,
            ok =>
            {
                _AdsConfig = ok;
                OnCompleted();
            });
#else
ResourceManager.LoadAsync<AdsConfig>(ADAB.Value == "A"?ViewConst.asset_AdsConfig_AndroidA : ViewConst.asset_AdsConfig_AndroidA,
            ok =>
            {
                _AdsConfig = ok;
                OnCompleted();
            });
#endif
    }

    public AdsConfig GetADConfig()
    {
        return _AdsConfig;
    }

    public string GetUserTestLib()
    {
        if (ADAB == null || ADAB.Value.Equals("X"))
        {
            UserEnterGame();
        }

        return ADAB.Value;
    }

    private void RequestAB()
    {
        string json = JsonConvert.SerializeObject(new BaseRequestParam(ServerCode.TestADAB));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                //error
            }
            else
            {
                TestABResponseData responseData =
                    JsonConvert.DeserializeObject<TestABResponseData>(back.downloadHandler.text);
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
        if (ADAB != null && ADAB.Value.Equals("X"))
        {
            ADAB.Value = testAB;
        }
    }


    /// <summary>
    /// 如果读条完毕，但是玩家还没有被设置AB，则直接设置一个随机AB
    /// </summary>
    public void UserEnterGame()
    {
        if (ADAB == null)
        {
            ADAB = new RecordExtra.StringPrefData(PrefKeys.ADTestAB, "X");
        }

        if (ADAB.Value.Equals("X"))
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

public class TestABResponseData : BaseResponseData<TestABGroup>
{
}

public class TestABGroup
{
    public string group;
}