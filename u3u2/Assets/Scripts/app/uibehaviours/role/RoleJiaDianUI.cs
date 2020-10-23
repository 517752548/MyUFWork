using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleJiaDianUI : UIMonoBehaviour
{

    public GameObject JiaDianLeftGo;
    public GameObject JiaDianRightGo;

    public GridLayoutGroup PropGrid;
    public GridLayoutGroup PropATextGrid;
    public Text Qianli;
    public GameUUButton JiaDianShuoMing;

    public GameUUButton xidian;
    public GameUUButton savedian;

    public GridLayoutGroup PropAGrid;
    public List<RoleJiaDianItem> PropAItemList;
    public Transform m_qichonginfo;

    public override void Init()
    {
        base.Init();
        JiaDianLeftGo=transform.Find("JiaDianLeftInfo").gameObject;
        JiaDianRightGo=transform.Find("JiaDianRightInfo").gameObject;
        PropGrid=transform.Find("JiaDianLeftInfo/grid").GetComponent<GridLayoutGroup>();
        PropATextGrid=transform.Find("JiaDianLeftInfo/grid 1").GetComponent<GridLayoutGroup>();
        Qianli=transform.Find("JiaDianRightInfo/qianli/Qianli").GetComponent<Text>();
        JiaDianShuoMing=transform.Find("JiaDianRightInfo/qianli/jiadianInfo").GetComponent<GameUUButton>();
        xidian=transform.Find("JiaDianRightInfo/xidian").GetComponent<GameUUButton>();
        savedian=transform.Find("JiaDianRightInfo/savedian").GetComponent<GameUUButton>();
        PropAGrid=transform.Find("JiaDianRightInfo/grid").GetComponent<GridLayoutGroup>();
        PropAItemList = new List<RoleJiaDianItem>();

        RoleJiaDianItem item1 = transform.Find("JiaDianRightInfo/grid/qiangzhuang").gameObject.AddComponent<RoleJiaDianItem>();
        item1.Init();
        PropAItemList.Add(item1);
        RoleJiaDianItem item2 = transform.Find("JiaDianRightInfo/grid/minjie").gameObject.AddComponent<RoleJiaDianItem>();
        item2.Init();
        PropAItemList.Add(item2);
        RoleJiaDianItem item3 = transform.Find("JiaDianRightInfo/grid/zhili").gameObject.AddComponent<RoleJiaDianItem>();
        item3.Init();
        PropAItemList.Add(item3);
        RoleJiaDianItem item4 = transform.Find("JiaDianRightInfo/grid/xinyang").gameObject.AddComponent<RoleJiaDianItem>();
        item4.Init();
        PropAItemList.Add(item4);
        RoleJiaDianItem item5 = transform.Find("JiaDianRightInfo/grid/naili").gameObject.AddComponent<RoleJiaDianItem>();
        item5.Init();
        PropAItemList.Add(item5);

        m_qichonginfo = transform.Find("JiaDianLeftInfo/qichonginfo");

    }
}
