using System;
using System.Collections.Generic;
using System.Xml.Linq;
using init;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选择服务器界面
/// </summary>
public class SelectServerUI : MonoBehaviour
{
    //////////////////////////////////Inspector Start///////////////
    //第一个界面的内容
    public Text defServerText;
    public Text defServerStateText;
    public Button selectBtn;
    //弹出的选服界面的内容

    public GameObject selectServerObj;
    public Button sureBtn;
    public Button closeBtn;

    public GridLayoutGroup tabGrid;
    public Toggle defTabToggle;

    public GridLayoutGroup serverGrid;
    public Toggle defServerToggle;
    //////////////////////////////////Inspector End///////////////////
    //测试服 开关-------START
    private int clickAppVer = 0;
    private int triggerClickCount = 5;
    private int testServerId = 1001;
    // private bool testServerVisi = false;
    private bool testServerVisi = true;
    private Toggle testToggle;
    //测试服 开关-------END
    //选择服务器列表 一个页签显示的数目
    private const int numPerTab = 10;
    private int currentSelectTab=0;
    private InitView initview;
    private bool hasInit = false;

    private List<Toggle> tabList = new List<Toggle>();

    private List<ServerItem> serverValueList = new List<ServerItem>();
    public List<ServerItem> ServerValueList
    {
        get { return serverValueList; }
    }

    private List<Toggle> serverToggleList = new List<Toggle>();
    public List<Toggle> ServerToggleList
    {
        get { return serverToggleList; }
    }

    private string selectedServerId = "";
    public string SelectedServerId
    {
        get { return selectedServerId; }
        private set
        {
            selectedServerId = value;
            if (initview!=null) initview.selectedServerId = value;
        }
    }

    private ServerItem selectedServerItem;

    public ServerItem SelectedServerItem
    {
        get { return selectedServerItem; }
        private set
        {
            selectedServerItem = value;
            selectedServerId = selectedServerItem.serverid;

            defServerText.text = selectedServerItem.name;
            defServerStateText.text = selectedServerItem.getState();
        }
    }

    public void ShowPanel()
    {
        selectServerObj.SetActive(true);
        if (!hasInit)
        {
            hasInit = true;

            //构建tab列表
            int tabnum = (int)Math.Floor((double)(ServerValueList.Count * 1f / numPerTab))
                + (ServerValueList.Count % numPerTab == 0 ? 0 : 1);
            for (int i = 0; i < tabnum; i++)
            {
                Toggle item = GameObject.Instantiate(defTabToggle);
                item.gameObject.SetActive(true);
                item.gameObject.GetComponentInChildren<Text>().text = (i * numPerTab + 1) + "~" + ((i + 1) * numPerTab);
                item.transform.SetParent(tabGrid.transform);
                item.transform.localScale = Vector3.one;
                tabList.Add(item);
                item.onValueChanged.AddListener(changeTab);
            }
            defTabToggle.gameObject.SetActive(false);

            defServerToggle.gameObject.SetActive(false);
        }
        tabList[0].isOn = true;
        //changeTab(true);
    }

    private void closePanel()
    {
        selectServerObj.SetActive(false);
    }
    /// <summary>
    /// 设置服务器列表 数据
    /// </summary>
    /// <param name="serverList"></param>
    public void setData(IEnumerable<XElement> serverList,InitView initviewv)
    {
        selectedServerId = null;
        selectedServerItem = null;
        initview = initviewv;
        sureBtn.onClick.RemoveAllListeners();
        sureBtn.onClick.AddListener(OnServerSelected);
        closeBtn.onClick.RemoveAllListeners();
        closeBtn.onClick.AddListener(closePanel);
        selectBtn.onClick.RemoveAllListeners();
        selectBtn.onClick.AddListener(ShowPanel);
        //////////////////清理数据//////////
        for (int i = 0; i < tabList.Count; i++)
        {
            GameObject.DestroyImmediate(tabList[i].gameObject, true);
            tabList[i] = null;
        }
        tabList.Clear();

        int itemsCount = serverToggleList.Count;
        for (int i = 0; i < itemsCount; i++)
        {
            GameObject.DestroyImmediate(serverToggleList[i].gameObject, true);
            serverToggleList[i] = null;
        }
        serverToggleList.Clear();
        serverValueList.Clear();
        clickAppVer = 0;
        //////////////////清理数据//////////
        //////////////////设置数据//////////
        foreach (XElement elem in serverList)
        {
            ServerItem serveritem = new ServerItem();
            serveritem.setData(elem);
            serverValueList.Add(serveritem);
        }
        //设置默认服务器
        setDefaultServer();
        //设置 测试服是否 可见
        #if WINGLOONG
                testServerVisi = true;
        #else
                if (!ClientConfig.Ins.debug)
                {
                    testServerVisi = false;
                }
                else
                {
                    testServerVisi = true;
                }
        #endif
                //////////////////设置数据//////////
        //服务器列表数据排序
        ServerValueList.Sort(sortServerList);
    }

    public int sortServerList(ServerItem a,ServerItem b)
    {
        //默认服务器在前
        if (int.Parse(a.def) > int.Parse(b.def))
        {
            return -1;
        }
        else if (int.Parse(a.serverid) < int.Parse(b.serverid))
        {
            return 1;
        }
        //服务器id由大到小
        if (int.Parse(a.serverid) > int.Parse(b.serverid))
        {
            return -1;
        }
        else if (int.Parse(a.serverid) < int.Parse(b.serverid))
        {
            return 1;
        }
        return 0;
    }
    /// <summary>
    /// 设置默认数据
    /// </summary>
    private void setDefaultServer()
    {
        int defaultServerId = initview.GetDefaultServerId();
        if (defaultServerId != 0)
        {
            //设置 已经 存储的 默认服务器
            for (int i = 0; i < serverValueList.Count; i++)
            {
                if (serverValueList[i].serverid == (defaultServerId + ""))
                {
                    SelectedServerItem = serverValueList[i];

                    return;
                }
            }
        }
        for (int i = 0; i < serverValueList.Count; i++)
        {
            if (ServerValueList[i].def == "1")
            {
                SelectedServerItem = serverValueList[i];
                return;
            }
        }
    }

    private void changeTab(bool state)
    {
        if (!state)
        {
            return;
        }
        int selectTab = 0;
        for (int i = 0; i < tabList.Count; i++)
        {
            if (tabList[i].isOn)
            {
                selectTab = i;
                break;
            }
        }
        currentSelectTab = selectTab;
        int startnum = selectTab * numPerTab;
        int endnum = startnum + numPerTab;
        int itemsCount = serverToggleList.Count;
        int index = 0;
        testToggle = null;
        for (int i = startnum; i < endnum; i++)
        {
            if (i >= serverValueList.Count)
            {//数据末尾
                break;
            }
            if (index < itemsCount)
            {
                serverToggleList[index].gameObject.SetActive(true);
                serverToggleList[index].gameObject.GetComponentInChildren<Text>().text = serverValueList[i].name +" "+ serverValueList[i].getState();
            }
            else
            {
                Toggle item = GameObject.Instantiate(defServerToggle);
                item.gameObject.SetActive(true);
                item.gameObject.GetComponentInChildren<Text>().text = serverValueList[i].name +" "+ serverValueList[i].getState();
                item.transform.SetParent(serverGrid.transform);
                item.transform.localScale = Vector3.one;
                serverToggleList.Add(item);
            }
            //设置测试服 toggle
            if (serverValueList[i].serverid == (testServerId + ""))
            {
                testToggle = serverToggleList[index];
            }
            index++;
        }
        //隐藏多余的
        for (int i = index; i < numPerTab; i++)
        {
            if (i < serverValueList.Count)
            {
                serverToggleList[i].gameObject.SetActive(false);
            }
        }
        if (testToggle!=null)
        {
            testToggle.gameObject.SetActive(testServerVisi);
        }
    }

    private void OnServerSelected()
    {
        int valueindex = -1;
        int len = serverToggleList.Count;
        for (int i = 0; i < len; i++)
        {
            if (serverToggleList[i].isOn)
            {
                valueindex = i + numPerTab*currentSelectTab;
                SelectedServerItem = serverValueList[valueindex];
                break;
            }
        }
        closePanel();
    }
   
    /// <summary>
    /// 点击主界面版本号 文本，触发 测试服 开关
    /// </summary>
    /// <param name="go"></param>
    public void clickVersionText(GameObject go)
    {
        clickAppVer++;
        if (clickAppVer == triggerClickCount)
        {
            if (testServerVisi)
            {
                //触发 隐藏 测试服
                if (testToggle != null)
                {
                    testToggle.gameObject.SetActive(false);
                }
                testServerVisi = false;
            }
            else
            {
                //触发 显示 测试服
                if (testToggle != null)
                {
                    testToggle.gameObject.SetActive(true);
                    //testToggle.transform.SetAsLastSibling();
                }
                testServerVisi = true;
            }
            clickAppVer = 0;
        }
    }


    public void Destroy()
    {
        sureBtn.onClick.RemoveAllListeners();
        closeBtn.onClick.RemoveAllListeners();
        selectBtn.onClick.RemoveAllListeners();
        //////////////////清理数据//////////
        for (int i = 0; i < tabList.Count; i++)
        {
            GameObject.DestroyImmediate(tabList[i].gameObject, true);
            tabList[i] = null;
        }
        tabList.Clear();

        int itemsCount = serverToggleList.Count;
        for (int i = 0; i < itemsCount; i++)
        {
            GameObject.DestroyImmediate(serverToggleList[i].gameObject, true);
            serverToggleList[i] = null;
        }
        serverToggleList.Clear();
        serverValueList.Clear();
        clickAppVer = 0;
        hasInit = false;
    }

}

public class ServerItem
{
    public XElement elem;
    /// <summary>
    /// 域
    /// </summary>
    public string domain;
    /// <summary>
    /// CN中文
    /// </summary>
    public string lan;
    /// <summary>
    /// 0正常，1爆满，2维护
    /// </summary>
    public string ishot;
    /// <summary>
    /// 1是最新，0非最新
    /// </summary>
    public string isnew;
    /// <summary>
    /// 1是默认，0非默认
    /// </summary>
    public string def;
    /// <summary>
    /// 服务器名字
    /// </summary>
    public string name;
    /// <summary>
    /// 服务器id
    /// </summary>
    public string serverid;

    public XAttribute canpay;

    public void setData(XElement elemv)
    {
        if (elemv == null)
        {
            return;
        }
        elem=elemv;
        domain = elem.Attribute("domain").Value;
        lan = elem.Attribute("lan").Value;
        ishot = elem.Attribute("ishot")!=null?elem.Attribute("ishot").Value:"0";
        isnew = elem.Attribute("isnew")!=null?elem.Attribute("isnew").Value:"0";
        def = elem.Attribute("def").Value;
        name = elem.Attribute("name").Value;
        serverid = elem.Attribute("serverid").Value;
        canpay = elem.Attribute("canpay");
        try
        {
            int.Parse(serverid);
        }
        catch (Exception)
        {
            serverid = "0";
        }
    }

    public string getState()
    {
        switch (ishot)
        {
            case "0":
                    return "<color=#00ff00>正常</color>";
            case "1":
                    return "<color=#ff0000>爆满</color>";
            case "2":
                    return "<color=#000000>维护</color>";
            default:
                    return "<color=#00ff00>正常</color>";
        }
    }
}