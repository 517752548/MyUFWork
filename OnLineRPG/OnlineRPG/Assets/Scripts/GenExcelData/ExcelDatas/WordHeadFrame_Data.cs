// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the FrameWork Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
//  Build Time：2019-09-26 15:07:44.849
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 头像框表表数据
/// </summary>
public class WordHeadFrame_Data : BaseExcelData
{
    
    /// <summary>
    /// 头像框名称
    /// </summary>
    public string Name;

    /// <summary>
    /// 介绍
    /// </summary>
    public string Descrip;

    /// <summary>
    /// 缩略图资源
    /// </summary>
    public string Thumb;

    /// <summary>
    /// UI资源
    /// </summary>
    public string UIRes;

    /// <summary>
    /// 位置顺序
    /// </summary>
    public int Order;

    /// <summary>
    /// 资源在本地
    /// </summary>
    public int LocalRes;

    public int GetRowsCount()
    {
        return 13;
    }
    public int GetColumnsCount()
    {
        return 7;
    }
    public void Init(Dictionary<string, object> data)
    {
        
        ID = Convert.ToString(data["ID"]);
        Name = Convert.ToString(data["Name"]);
        Descrip = Convert.ToString(data["Descrip"]);
        Thumb = Convert.ToString(data["Thumb"]);
        UIRes = Convert.ToString(data["UIRes"]);
        Order = Convert.ToInt32(data["Order"]);
        LocalRes = Convert.ToInt32(data["LocalRes"]);
    }
    override public string ToString()
    {
        return string.Format("ID={0},Name={1},Descrip={2},Thumb={3},UIRes={4},Order={5},LocalRes={6}", ID, Name, Descrip, Thumb, UIRes, Order, LocalRes);
    }
}