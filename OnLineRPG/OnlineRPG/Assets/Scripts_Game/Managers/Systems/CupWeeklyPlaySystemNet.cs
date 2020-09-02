using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;

public class CupWeeklyPlaySystemNet
{
    private CupWeeklyPlaySystem frps;

    public CupWeeklyPlaySystemNet(CupWeeklyPlaySystem frps)
    {
        this.frps = frps;
    }

    public void GetConfig()
    {
        CupWeeklyRequestConig requestConig = new CupWeeklyRequestConig
        {
            mId = (int) ServerCode.FastRace,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value
        };
        //Debug.LogError(JsonConvert.SerializeObject(requestConig));
        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceConfig_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("FR config error");
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RepFastRaceConfigPacket>(aobj.downloadHandler.text);
                    //Debug.LogError("Fast配置" + aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        //Debug.LogError("ac id " + data.data.acId);
                        DataManager.FastRaceData.RepFastRaceConfigPacketData = data.data;
                        if (DataManager.FastRaceData.ActivityID != data.data.acId)
                        {
                            frps.NewActivityStart();
                            DataManager.FastRaceData.ActivityID = data.data.acId;
                        }

                        DataManager.FastRaceData.ConfigInit = true;
                        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.FRConfigInited);
                    }
                    else
                    {
                        Debug.LogError("FR config parse error");
                    }
                }
            }, JsonConvert.SerializeObject(requestConig),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }

    public void CreateRoom(Action<FastRaceRoomRepData> callback)
    {
        RequestRoom requestRoom = new RequestRoom
        {
            mId = (int) ServerCode.JoinFastRaceRoom,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
            roomId = 0,

            name = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerName(),

            level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value,

            headImg = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerHeadUrl()
        };
        Debug.LogFormat("form acid {0}-{1}-{2}-{3}", DataManager.FastRaceData.ActivityID,
            DataManager.FastRaceData.RoomId, DataManager.DeviceData.DeviceId,
            AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value);
        Debug.Log(JsonConvert.SerializeObject(requestRoom));
        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceRoom_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("FR CreateRoom error");
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
                else
                {
                    try
                    {
                        var data = JsonConvert.DeserializeObject<FastRaceRoomRepPack>(aobj.downloadHandler.text);
                        Debug.Log("房间" + aobj.downloadHandler.text);
                        if (data.code == (int) RepCodes.SUCCESSED)
                        {
                            if (data.data.status == 1)
                            {
                                Debug.Log("CreateRoom - " + data.data.roomGroup);
                                DataManager.FastRaceData.RoomId = data.data.roomId;
                                DataManager.FastRaceData.RoomGroup = data.data.roomGroup;
                                DataManager.FastRaceData.FastRaceRoomRepData = data.data;
                                if (callback != null)
                                    callback.Invoke(data.data);
                            }
                            else
                            {
                                if (callback != null)
                                    callback.Invoke(null);
                            }
                        }
                        else
                        {
                            if (callback != null)
                                callback.Invoke(null);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.StackTrace);
                        if (callback != null)
                            callback.Invoke(null);
                    }
                }
            }, JsonConvert.SerializeObject(requestRoom),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }

    public void UploadScore(int Score, string HeadImg, Action<UploadScoreRepData> callback)
    {
        RequestUploadScore requestUploadScore = new RequestUploadScore
        {
            mId = (int) ServerCode.FRUploadScore,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
            roomId = DataManager.FastRaceData.RoomId,
            roomGroup = DataManager.FastRaceData.RoomGroup,
            score = Score,
            headImg = HeadImg,
            name = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().GetPlayerName()
        };
        Debug.Log(JsonConvert.SerializeObject(requestUploadScore));
        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceUploadScore_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("FR upload score error");
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
                else
                {
                    Debug.Log("上传分数" + aobj.downloadHandler.text);
                    try
                    {
                        var data = JsonConvert.DeserializeObject<UploadScoreRep>(aobj.downloadHandler.text);

                        if (data.code == (int) RepCodes.SUCCESSED)
                        {
                            if (callback != null)
                            {
                                if (callback != null)
                                {
                                    callback.Invoke(data.data);
                                }

                                // data.data.RinkList.Sort(delegate(FastRacePerson p1, FastRacePerson p2)
                                // {
                                //     return p1.JoinTime.CompareTo(p2.JoinTime);
                                // });
                                // callback.Invoke(data.data);
                                // Debug.LogError("人数 " + data.data.RinkList.Count);
                            }
                        }
                        else
                        {
                            if (callback != null)
                            {
                                callback.Invoke(null);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.StackTrace);
                        if (callback != null)
                            callback.Invoke(null);
                    }
                }
            }, JsonConvert.SerializeObject(requestUploadScore),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }

    /// <summary>
    /// 获取用户排名
    /// </summary>
    /// <param name="callback"></param>
    public void GetPlayerRank(Action<MyRankIndex> callback)
    {
        RankConfig requestUploadScore = new RankConfig
        {
            mId = (int) ServerCode.GetFastRaceRank,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
            roomId = DataManager.FastRaceData.RoomId,
            roomGroup = DataManager.FastRaceData.RoomGroup,
        };
        //Debug.LogError(JsonConvert.SerializeObject(requestUploadScore));
        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceMyRank_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    //Debug.LogError("FR upload score error");
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
                else
                {
                    //Debug.LogError("获取排名" + aobj.downloadHandler.text);
                    // string fake =
                    //     "{\"code\":200,\"data\":{\"status\":3,\"rink\":2,\"rewardId\":11,\"rewardNum\":20,\"type\":0}}";
                    // var data = JsonConvert.DeserializeObject<MyRankIndex>(fake);
                    var data = JsonConvert.DeserializeObject<MyRankIndex>(aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        if (callback != null)
                        {
                            if (callback != null)
                            {
                                callback.Invoke(data);
                            }
                        }
                    }
                    else
                    {
                        if (callback != null)
                        {
                            callback.Invoke(null);
                        }
                    }
                }
            }, JsonConvert.SerializeObject(requestUploadScore),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }


    /// <summary>
    /// 获取排行榜信息
    /// </summary>
    /// <param name="callback"></param>
    public void GetRankList(Action<RanListInfo> callback)
    {
        RankConfig requestUploadScore = new RankConfig
        {
            mId = (int) ServerCode.GetFastRaceList,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
            roomId = DataManager.FastRaceData.RoomId,
            roomGroup = DataManager.FastRaceData.RoomGroup,
        };
        Debug.LogError(JsonConvert.SerializeObject(requestUploadScore));
        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceRankList_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("FR upload score error");
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
                else
                {
                    Debug.LogError("获取排行榜" + aobj.downloadHandler.text);
                    try
                    {
                        var data = JsonConvert.DeserializeObject<RankList>(aobj.downloadHandler.text);

                        if (data.code == (int) RepCodes.SUCCESSED)
                        {
                            if (callback != null)
                            {
                                if (callback != null)
                                {
                                    for (int i = 0; i < data.data.rankingList.Count; i++)
                                    {
                                        data.data.rankingList[i].rank = i + 1;
                                    }

                                    callback.Invoke(data.data);
                                }
                            }
                        }
                        else
                        {
                            if (callback != null)
                            {
                                callback.Invoke(null);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.StackTrace);
                        if (callback != null)
                            callback.Invoke(null);
                    }
                }
            }, JsonConvert.SerializeObject(requestUploadScore),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }

    /// <summary>
    /// 领取奖励
    /// </summary>
    /// <param name="callback"></param>
    public void Reward(Action<bool> callback)
    {
        RequestReward requestReward = new RequestReward
        {
            mId = (int) ServerCode.GetFastRaceReward,
            acId = DataManager.FastRaceData.ActivityID,
            deviceId = AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value,
            roomId = DataManager.FastRaceData.RoomId,
            roomGroup = DataManager.FastRaceData.RoomGroup,
        };

        WebRequestPostUtility.Instance.PostJson(URLSetting.SERVER_FastRaceGetReward_URL, (aobj) =>
            {
                if (aobj.isHttpError || aobj.isNetworkError)
                {
                    Debug.LogError("FR reward  error");
                    if (callback != null)
                    {
                        callback.Invoke(false);
                    }
                }
                else
                {
                    var data = JsonConvert.DeserializeObject<RewardRep>(aobj.downloadHandler.text);
                    if (data.code == (int) RepCodes.SUCCESSED)
                    {
                        if (callback != null)
                            callback.Invoke(true);
                    }
                    else
                    {
                        Debug.LogError("FR  reward parse error");
                        if (callback != null)
                            callback.Invoke(false);
                    }
                }
            }, JsonConvert.SerializeObject(requestReward),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetFastRaceHeaders());
    }
}

class CupWeeklyRoomRepPack
{
    public int code;
    public CupWeeklyRoomRepData data;
}

public class CupWeeklyRoomRepData
{
    public int roomId;
    public string roomGroup;
    public int status;
}

class CupWeeklyRepConfigPacket
{
    public int code;
    public CupWeeklyRepConfigPacketData data;
}

public class CupWeeklyRepConfigPacketData
{
    public int status;
    public int countdown;
    public int acId;
    public int type;
    public int level;
    public int showPanel;
    public int order;
}

class CupWeeklyUploadScoreRep
{
    public int code;
    public CupWeeklyUploadScoreRepData data;
}

public class CupWeeklyMyRankIndex
{
    public int code;
    public CupWeeklyMyRankInfo data;
}

public class CupWeeklyRankList
{
    public int code;
    public CupWeeklyRanListInfo data;
}

public class CupWeeklyRanListInfo
{
    public int status;
    public List<CupWeeklyRankListInfo> rankingList;
}

public class CupWeeklyRankListInfo
{
    public string headImg;
    public string name;
    public string passportId;
    public int score;
    public int type;
    public int rewardId;

    public int rewardNum;

    //这个是自己算的，不是服务器给的，服务器给排好顺序了
    public int rank;
}

public class CupWeeklyMyRankInfo
{
    public int status;
    public int rink;
    public int rewardId;
    public int rewardNum;
    public int type;
}

public class CupWeeklyUploadScoreRepData
{
    public int status;
}

class CupWeeklyRewardRep
{
    public int code;
}


/// <summary>
/// 请求开房间的类
/// </summary>
class CupWeeklyRequestRoom
{
    public int mId;
    public int acId;
    public int roomId;
    public int level;
    public string name;
    public string headImg;
    public string deviceId;
}

class CupWeeklyRequestUploadScore
{
    public int mId;
    public int acId;
    public int roomId;
    public string roomGroup;
    public string name;
    public string headImg;
    public int score;
    public string deviceId;
}

class CupWeeklyRankConfig
{
    public int mId;
    public int acId;
    public int roomId;
    public string roomGroup;
    public string deviceId;
}

class CupWeeklyRequestConig : BaseRequestParam
{
    public int acId;
    public string deviceId;
}

class CupWeeklyRequestReward
{
    public int mId;
    public int acId;
    public int roomId;
    public string roomGroup;
    public string deviceId;
}