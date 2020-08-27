using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class FastRaceData : IData
{
    /// <summary>
    /// 玩家是否可以领奖
    /// </summary>
    public bool CanGetReward;
    /// <summary>
    /// 领奖的id和数量
    /// </summary>
    public int rewardID;
    public int rewardNum;
    public int RoomId
    {
        get { return _Roomid; }
        set
        {
            _Roomid = value;
            Record.SetInt(PrefKeys.FastRaceRoomID, value);
        }
    }

    private int _Roomid;

    public int ActivityID
    {
        get { return _ActivityID; }
        set
        {
            _ActivityID = value;
            Record.SetInt(PrefKeys.FastRaceACID, value);
        }
    }

    private int _ActivityID;

    public bool showButtonEffect = false;
    public int Score
    {
        get { return _score; }
        set
        {
            showButtonEffect = true;
            _score = value;
            Record.SetInt(PrefKeys.FastRaceScore, _score);
        }
    }

    /// <summary>
    /// 服务端返回的配置
    /// </summary>
    public RepFastRaceConfigPacketData RepFastRaceConfigPacketData
    {
        get { return m_RepFastRaceConfigPacketData; }

        set { m_RepFastRaceConfigPacketData = value; }
    }

    public bool ConfigInit
    {
        get { return m_configInit; }

        set { m_configInit = value; }
    }

    public FastRaceRoomRepData FastRaceRoomRepData
    {
        get { return m_fastRaceRoomRepData; }

        set { m_fastRaceRoomRepData = value; }
    }

    public string RoomGroup
    {
        get { return m_RoomGroup; }

        set
        {
            m_RoomGroup = value;
            Record.SetString(PrefKeys.FastRaceRoomGroup, value);
        }
    }

    private int _score;

    private RepFastRaceConfigPacketData m_RepFastRaceConfigPacketData;
    private FastRaceRoomRepData m_fastRaceRoomRepData;

    private bool m_configInit;
    private string m_RoomGroup;

    

    public void Initilize()
    {
        _Roomid = Record.GetInt(PrefKeys.FastRaceRoomID, 0);
        _ActivityID = Record.GetInt(PrefKeys.FastRaceACID, -1);
        _score = Record.GetInt(PrefKeys.FastRaceScore, 0);
        m_RoomGroup = Record.GetString(PrefKeys.FastRaceRoomGroup, "0");
    }

    /// <summary>
    /// 新活动开启，清楚上次的缓存数据
    /// </summary>
    public void NewActivityStart()
    {
        RoomId = 0;
        Score = 0;
    }
}