// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the FrameWork Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
//  Build Time：2019-09-26 15:07:44.760
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表数据
/// </summary>
public class PlayerLevel_Data : BaseExcelData
{
    
    /// <summary>
    /// 所需经验
    /// </summary>
    public int Exp;

    public int GetRowsCount()
    {
        return 77;
    }
    public int GetColumnsCount()
    {
        return 2;
    }
    public void Init(Dictionary<string, object> data)
    {
        
        ID = Convert.ToString(data["ID"]);
        Exp = Convert.ToInt32(data["Exp"]);
    }
    override public string ToString()
    {
        return string.Format("ID={0},Exp={1}", ID, Exp);
    }
}