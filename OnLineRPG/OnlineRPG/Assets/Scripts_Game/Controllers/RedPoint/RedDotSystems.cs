using System.Collections.Generic;
using UnityEngine;

public class RedDotSystem : ISystem
{
    //红点变化通知
    public delegate void OnPointNumChange(RedDotNode node);
    RedDotNode mRootNode;//红点树Root节点
    //初始化红点树
    static List<string> IsPointTreeList = new List<string>
    {
        //有红点的先往 const 中添加，然后在这里添加
        RedDotConst.Menu,
        RedDotConst.PointCollect,
        RedDotConst.Build,
        RedDotConst.Message,
        //RedDotConst.Pet,
        //RedDotConst.Map,
        //RedDotConst.Nice,
        RedDotConst.Email,
        //RedDotConst.Setting,
        
    };

    //开始进行初始化
    public override void InitSystem()
    {
        mRootNode = new RedDotNode();
        mRootNode.nodeName = RedDotConst.Menu;

        foreach (var s in IsPointTreeList)
        {
            var node = mRootNode;
            var treeNodeAy = s.Split('.');
            //判断数组的第[0]项是否是根结点，不是的话就会报错
            if (treeNodeAy[0] != mRootNode.nodeName)
            {
                Debug.Log("红点树根结点报错:" + treeNodeAy[0]);
                continue;
            }
            //数组存储每一个节点的名字[0]根结点[1]根的子节点  [2]是【1】的子节点以此类推
            if (treeNodeAy.Length > 1)
            {
                for (int i = 1; i < treeNodeAy.Length; i++)
                {
                    if (!node.dicChilds.ContainsKey(treeNodeAy[i]))
                    {
                        //添加节点
                        node.dicChilds.Add(treeNodeAy[i], new RedDotNode());
                    }
                    //节点名字  节点的父节点是是上一级节点
                    node.dicChilds[treeNodeAy[i]].nodeName = treeNodeAy[i];
                    node.dicChilds[treeNodeAy[i]].parent = node;
                    //初始化红点树的最后一次重新赋值
                    node = node.dicChilds[treeNodeAy[i]];
                }
            }
        }
        base.InitSystem();
    }


    //事件回调    参数（节点名字，节点数量改变的回调方法）
    public void SetRedPointNodeCallBack(string strNode, RedDotSystem.OnPointNumChange callBack)
    {
        var nodelist = strNode.Split('.');
        if (nodelist.Length == 1)
        {
            if (nodelist[0] != RedDotConst.Menu)
            {
                Debug.Log("Get Wrong Root Node Current is" + nodelist[0]);
                return;
            }
        }

        var node = mRootNode;
        for (int i = 1; i < nodelist.Length; i++)
        {
            if (!node.dicChilds.ContainsKey(nodelist[i]))
            {
                Debug.Log("不包含这个孩子结点:" + nodelist[i]);
                return;
            }
            node = node.dicChilds[nodelist[i]];
            //最后一个节点了
            if (i == nodelist.Length - 1)
            {
                node.numChangeFunc = callBack;
                return;
            }
        }
    }

    //驱动层
    public void SetInvoke(string strNode, int rpNum)
    {
        //分析树节点
        var nodeList = strNode.Split('.');
        if (nodeList.Length == 1)
        {
            if (nodeList[0] != RedDotConst.Menu)
            {
                Debug.Log("根结点发生错误！现在的节点是" + nodeList[0]);
                return;
            }
        }

        var node = mRootNode;
        for (int i = 1; i < nodeList.Length; i++)
        {
            if (!node.dicChilds.ContainsKey(nodeList[i]))
            {
                Debug.Log("不包含这个孩子结点:" + nodeList[i]);
                return;
            }
            node = node.dicChilds[nodeList[i]];
            //最后一个节点
            if (i == nodeList.Length - 1)
            {
                //设置节点的红点数量
                node.SetRedPointNum(rpNum);
            }
        }
    }
}
