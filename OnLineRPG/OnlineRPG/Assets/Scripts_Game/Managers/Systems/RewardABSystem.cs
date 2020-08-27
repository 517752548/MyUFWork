using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;
using UnityEngine;

public class RewardABSystem : ISystem
{
    public RecordExtra.StringPrefData RewardAB;
    private RewardAB _rewardAb;
    private PropertyAB _propertyConfig;

    public override void InitSystem()
    {
        if (RewardAB == null)
        {
            RewardAB = new RecordExtra.StringPrefData(PrefKeys.RewardAB, "X");
        }
        if (RewardAB.Value.Equals("X"))
        {
            //RequestAB();
            UserEnterGame();
        }
        

        AppEngine.SResourceManager.LoadAssetAsync<RewardAB>(
#if UNITY_IOS
            string.Format("RewardAB_Ios_Reward_{0}.asset", GetUserRewardLib()),
#else
            string.Format("RewardAB_Android_Reward_{0}.asset", GetUserRewardLib()),
#endif
            ok =>
            {
                _rewardAb = ok;
                if (_rewardAb != null && _propertyConfig != null)
                {
                    OnCompleted();
                }
            });
        AppEngine.SResourceManager.LoadAssetAsync<PropertyAB>(
#if UNITY_IOS
            string.Format("PropertyAB_Ios_Prop_{0}.asset", GetUserRewardLib()), 
#else
            string.Format("PropertyAB_Android_Prop_{0}.asset", GetUserRewardLib()),
#endif
            
            ok =>
            {
                _propertyConfig = ok;
                if (_rewardAb != null && _propertyConfig != null)
                {
                    OnCompleted();
                }
            });
    }

    public string GetUserRewardLib()
    {
        if (RewardAB == null || RewardAB.Value.Equals("X"))
        {
            UserEnterGame();
        }
        return RewardAB.Value;
    }

    public PropertyAB GetUserPropConfig()
    {
        return _propertyConfig;
    }
    

    private void RequestAB()
    {
        string json = JsonConvert.SerializeObject(new BaseRequestParam(ServerCode.RewardAB));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                //error
            }
            else
            {
                RewardABResponseData responseData =
                    JsonConvert.DeserializeObject<RewardABResponseData>(back.downloadHandler.text);
                if (responseData.code != 200)
                {
                    //error
                }
                else
                {
                    if (responseData.data != null)
                    {
                        SetRewardAB(responseData.data.group);
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
    public void SetRewardAB(string testAB)
    {
        if (RewardAB != null && RewardAB.Value.Equals("X") && (testAB.Equals("A") || testAB.Equals("B")))
        {
            RewardAB.Value = testAB;
        }
    }
    
    public RewardAB GetRewardInfoTable()
    {
        return _rewardAb;
    }

    public string GetABReportStr()
    {
        string reportstr = GetRewardInfoTable().reportStr;
        if (string.IsNullOrEmpty(reportstr))
        {
            return Const.Version;
        }

        return reportstr;
    }

    /// <summary>
    /// 如果读条完毕，但是玩家还没有被设置AB，则直接设置一个随机AB
    /// </summary>
    public void UserEnterGame()
    {
        if (RewardAB == null)
        {
            RewardAB = new RecordExtra.StringPrefData(PrefKeys.RewardAB, "X");
        }
        if (RewardAB.Value.Equals("X"))
        {
            int id = UnityEngine.Random.Range(0, 1001);
            if (id <= 500)
            {
                SetRewardAB("A");
            }
            else
            {
                SetRewardAB("B");
            }
        }
    }
    
}

public class RewardABResponseData : BaseResponseData<RewardABGroup>
{
}

public class RewardABGroup
{
    public string group;
}