using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotNode 
{
    //节点名称
    public string nodeName;
    //总的红点数量
    public int pointNum=0;
    //父节点
    public RedDotNode parent = null;
    //发生变化的回调函数
    public RedDotSystem.OnPointNumChange numChangeFunc;
    //子节点   （结点的const名称 结点数据）
    public Dictionary<string, RedDotNode> dicChilds = new Dictionary<string, RedDotNode>();

    /// <summary>
    /// 设置当前节点的红点数量
    /// </summary>
    /// <param name="rpNum"></param>
    public void SetRedPointNum(int rpNum)
    {
        //红点数量只能设置叶子节点
        if (dicChilds.Count > 0)
        {
            Debug.LogError("Only Can Set Leaf Node!");
            return;
        }
        pointNum = rpNum;
        NotifyPointNumChange(this);
        if (parent != null)
        {
            ChangePredPointNum(parent);
        }
    }
    /// <summary>
    /// 计算当前红点数量
    /// </summary>
    private void ChangePredPointNum(RedDotNode node)
    {
        int num = 0;
        foreach (var item in node.dicChilds.Values)
        {
            num += item.pointNum;
        }
        //红点有变化
        if (num != node.pointNum)
        {
            node.pointNum = num;
            NotifyPointNumChange(node);
        }
    }
    /// <summary>
    /// 通知红点数量变化
    /// </summary>
    private void NotifyPointNumChange(RedDotNode node)
    {       
        node.numChangeFunc?.Invoke(this);
    }
}
