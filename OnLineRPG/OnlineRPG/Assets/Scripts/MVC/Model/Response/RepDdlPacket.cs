using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class RepDdlPacket : SerializablePacket
{
    public int code;
    public RepDdlData data;
}

public class RepDdlData
{
    public string StoreId;
    public int DDL_V;
    public bool DDL_SW;
    public int DDL_SL;
    public string DDL_DD;
    public int DDL_DP;
    public string Belong;
    public bool DDL_NDF;

    public RepDdlData()
    {
        DDL_V = -1;
        DDL_SW = false;
        DDL_SL = 99999;
        DDL_DD = "2";
        DDL_DP = 10;
        Belong = "unkuown";
        DDL_NDF = true;
    }

    private int m_currentIndex = -1;
    private DateTime _time = DateTime.MinValue;


    private int currentIndex
    {
        get
        {
            if (_time == DateTime.MinValue)
            {
                if (Record.HasKey(PrefKeys.DDL_TurnTime))
                {
                    //如果有记录了时间
                    string timeRecore = Record.GetString(PrefKeys.DDL_TurnTime);
                    if (timeRecore == DateTime.Today.ToString())
                    {
                        //如果是今天
                        m_currentIndex = Record.GetInt(PrefKeys.DDL_TurnIndex, 0);
                        _time = DateTime.Today;
                        LoggerHelper.Log("DDL:ddlTurn是同一天:" + m_currentIndex);
                    }
                    else
                    {
                        _time = DateTime.Today;
                        m_currentIndex = 0;
                        Record.SetInt(PrefKeys.DDL_TurnIndex, 0);
                        Record.SetString(PrefKeys.DDL_TurnTime, _time.ToString());
                        LoggerHelper.Log("DDL:ddlTurn不是同一天:" + m_currentIndex);
                    }
                }
                else
                {
                    _time = DateTime.Today;
                    m_currentIndex = 0;
                    Record.SetInt(PrefKeys.DDL_TurnIndex, 0);
                    Record.SetString(PrefKeys.DDL_TurnTime, _time.ToString());
                    LoggerHelper.Log("DDL:ddlTurn第一次玩:" + m_currentIndex);
                }
            }
            else
            {
                if (_time != DateTime.Today)
                {
                    _time = DateTime.Today;
                    m_currentIndex = 0;
                    Record.SetInt(PrefKeys.DDL_TurnIndex, 0);
                    Record.SetString(PrefKeys.DDL_TurnTime, _time.ToString());
                    LoggerHelper.Log("DDL:跨天了也清零");
                }
            }

            return m_currentIndex;
        }
        set
        {
            m_currentIndex = value;
            Record.SetInt(PrefKeys.DDL_TurnIndex, m_currentIndex);
        }
    }
    

    private List<string> m_ddlList = null;

    private List<string> ddlList
    {
        get
        {
            if (m_ddlList == null)
            {
                m_ddlList = new List<string>();
                string[] ddlstring = DDL_DD.Split(';');
                for (int i = 0; i < ddlstring.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ddlstring[i]))
                    {
                        m_ddlList.Add(ddlstring[i]);
                    }
                }
            }

            return m_ddlList;
        }
    }

    public bool CanPlayDdlLevel(int currentLevel)
    {
        LoggerHelper.Log("DDL:当前ddl开关" + DDL_SW + "- 开启关卡" + DDL_SL + "-当前关卡-" + currentLevel);
        if (!DDL_SW)
            return false;
        if (currentLevel < DDL_SL)
            return false;
        if (currentIndex >= DDL_DP)
        {
            currentIndex = 0;
        }

        if (!DDL_NDF)
        {
            //如果是ndf
            return true;
        }

        currentIndex++;
        LoggerHelper.Log("DDL:当前轮的第几关" + currentIndex);
        if (ddlList.Contains(currentIndex.ToString()))
        {
            //如果当前关卡是难度关卡
            return true;
        }


        return false;
    }


    public void ClearTurn()
    {
        currentIndex = 0;
    }

    public string ShowInfo()
    {
        return _time.ToString() + "--" +  currentIndex;
    }
}