using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///  下拉菜单
/// </summary>
public class DropDownMenu : MonoBehaviour
{
    public GameUUToggle mainToggle;
    public Text mainToggleText;

    public GameObject dropDownObj;
    public TabButtonGroup dropDownTBG;
    public GridLayoutGroup dropDownGrid;
    public ToggleWithText defaultDownToggle;

    public List<ToggleWithText> ToggleList;
    private List<string> downList;
    private TabChangeHandler _tabChangeHandler;
    private int initIndex = -1;
    public TabChangeHandler TabChangeHandler
    {
        set { _tabChangeHandler = value; }
    }

    private bool hasAddListener = false;
    private bool _touchUpClose = true;
    private bool selectDefault = true;

    private bool mIsInited = false;
    private bool mIsStarted = false;

    public void Init()
    {
        Transform mainToggle = transform.Find("Toggle");
        if (mainToggle != null)
        {
            this.mainToggle = mainToggle.GetComponent<GameUUToggle>();
        }
        Transform mainToggleText = transform.Find("Toggle/Label");
        if (mainToggleText != null)
        {
            this.mainToggleText = mainToggleText.GetComponent<Text>();
        }
        Transform dropDownObj = transform.Find("downListBg");
        if (dropDownObj != null)
        {
            this.dropDownObj = dropDownObj.gameObject;
        }
        Transform dropDownTBG = transform.Find("downListBg/downList");
        if (dropDownTBG != null)
        {
            this.dropDownTBG = dropDownTBG.gameObject.AddComponent<TabButtonGroup>();
        }
        Transform dropDownGrid = transform.Find("downListBg/downList");
        if (dropDownGrid != null)
        {
            this.dropDownGrid = dropDownGrid.GetComponent<GridLayoutGroup>();
        }
        Transform defaultDownToggle = transform.Find("downListBg/downList/Toggle");
        if (defaultDownToggle != null)
        {
            this.defaultDownToggle = defaultDownToggle.gameObject.AddComponent<ToggleWithText>();
            this.defaultDownToggle.Init(defaultDownToggle.gameObject.GetComponent<GameUUToggle>(), defaultDownToggle.transform.Find("Label").GetComponent<Text>());
        }
        this.ToggleList = null;

        Init(this.mainToggle, this.mainToggleText, this.dropDownObj, this.dropDownTBG, this.dropDownGrid, this.defaultDownToggle, this.ToggleList);

    }

    public void Init(List<ToggleWithText> ToggleList)
    {
        Transform mainToggle = transform.Find("Toggle");
        if (mainToggle != null)
        {
            this.mainToggle = mainToggle.GetComponent<GameUUToggle>();
        }
        Transform mainToggleText = transform.Find("Toggle/Label");
        if (mainToggleText != null)
        {
            this.mainToggleText = mainToggleText.GetComponent<Text>();
        }
        Transform dropDownObj = transform.Find("downListBg");
        if (dropDownObj != null)
        {
            this.dropDownObj = dropDownObj.gameObject;
        }
        Transform dropDownTBG = transform.Find("downListBg/downList");
        if (dropDownTBG != null)
        {
            this.dropDownTBG = dropDownTBG.gameObject.AddComponent<TabButtonGroup>();
        }
        Transform dropDownGrid = transform.Find("downListBg/downList");
        if (dropDownGrid != null)
        {
            this.dropDownGrid = dropDownGrid.GetComponent<GridLayoutGroup>();
        }
        Init(this.mainToggle, this.mainToggleText, this.dropDownObj, this.dropDownTBG, this.dropDownGrid, null, ToggleList);
    }

    public void Init(GameUUToggle mainToggle, Text mainToggleText, GameObject dropDownObj, TabButtonGroup dropDownTBG, GridLayoutGroup dropDownGrid, ToggleWithText defaultDownToggle, List<ToggleWithText> ToggleList = null)
    {
        this.mainToggle = mainToggle;
        this.mainToggleText = mainToggleText;
        this.dropDownObj = dropDownObj;
        this.dropDownTBG = dropDownTBG;
        this.dropDownGrid = dropDownGrid;
        this.defaultDownToggle = defaultDownToggle;
        this.ToggleList = ToggleList;

        if (mainToggle != null)
        {
            mainToggle.isOn = false;
            mainToggle.SetValueChangedCallBack(showOrHide);
        }
        if (defaultDownToggle != null) defaultDownToggle.gameObject.SetActive(false);
        dropDownTBG.TabChangeHandler = selectToggle;
        if (initIndex != -1)
        {
            dropDownTBG.SetIndexWithCallBack(initIndex);
        }
        else
        {
            if (selectDefault)
            {
                initIndex = 0;
                dropDownTBG.SetIndexWithCallBack(0);
            }
        }

        if (this.ToggleList != null)
        {
            int len = this.ToggleList.Count;
            for (int i = 0; i < len; i++)
            {
                ToggleList[i].toggle.isOn = false;
                ToggleList[i].toggle.group.allowSwitchOff = false;
                ToggleList[i].transform.SetParent(dropDownGrid.transform);
                ToggleList[i].transform.localScale = Vector3.one;
                dropDownTBG.AddToggle(ToggleList[i].toggle);
                ToggleList[i].gameObject.SetActive(true);
                ToggleList[i].transform.SetAsLastSibling();
            }
        }

        mIsInited = true;
    }

    void Start()
    {
        if (mIsInited && !mIsStarted)
        {
            showOrHide(false);
            CancelInvoke("DoUpdate");
            InvokeRepeating("DoUpdate", 0, 0.1f);
            mIsStarted = true;
        }
    }

    void Update()
    {
        if (_touchUpClose && hasAddListener)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            if (Input.GetMouseButtonUp(0))
            {
                OnScreenTouchUp();
            }
#else
            if (Input.touchCount == 1)
            {
                if(Input.touches[0].phase==TouchPhase.Ended)
                {
                    OnScreenTouchUp();
                }
            }
#endif
        }
    }
    //#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
    //#else
    void DoUpdate()
    {
        if (this.gameObject.activeInHierarchy && dropDownObj.activeInHierarchy)
        {
            if (!hasAddListener)
            {
                hasAddListener = true;
            }
        }
        else
        {
            if (hasAddListener)
            {
                hasAddListener = false;
            }
        }
    }
    //#endif

    public void OnScreenTouchUp()
    {
        if (mainToggle != null)
        {
            mainToggle.isOn = false;
        }
        showOrHide(false);
    }

    public void setIndex(int selectIndex)
    {
        initIndex = selectIndex;
        dropDownTBG.SetIndexWithCallBack(selectIndex);
    }

    public int Index
    {
        get
        {
            return dropDownTBG.index;
        }
    }

    public bool TouchUpClose
    {
        set { _touchUpClose = value; }
    }

    public bool SelectDefault
    {
        set
        {
            selectDefault = value;
            dropDownTBG.SelectDefault = selectDefault;
        }
    }

    private void showOrHide(bool state)
    {
        dropDownObj.SetActive(state);
    }
    /// <summary>
    /// 更新下拉列表
    /// </summary>
    /// <param name="downList"></param>
    public void updateDropDownList(List<string> downlist)
    {
        if (ToggleList == null)
        {
            ToggleList = new List<ToggleWithText>();
        }
        this.downList = downlist;
        dropDownTBG.ClearToggleList();
        dropDownTBG.ReSelected = true;
        for (int i = 0; defaultDownToggle != null && i < downList.Count; i++)
        {
            if (i >= ToggleList.Count)
            {
                ToggleWithText tg = GameObject.Instantiate(defaultDownToggle);
                ToggleList.Add(tg);
                tg.toggle.isOn = false;
                tg.toggle.group.allowSwitchOff = false;
                tg.transform.SetParent(dropDownGrid.transform);
                tg.transform.localScale = Vector3.one;
            }
            dropDownTBG.AddToggle(ToggleList[i].toggle);
            ToggleList[i].gameObject.SetActive(true);
            ToggleList[i].toggleText.text = downList[i];
            ToggleList[i].transform.SetAsLastSibling();
        }
        if (initIndex != -1 && initIndex < downlist.Count)
        {
            dropDownTBG.SetIndexWithCallBack(initIndex);
        }
        else if (downList.Count > 0)
        {
            if (selectDefault)
            {
                initIndex = 0;
                dropDownTBG.SetIndexWithCallBack(0);
            }
        }
        for (int i = downList.Count; i < ToggleList.Count; i++)
        {
            GameObject.DestroyImmediate(ToggleList[i].gameObject, true);
            ToggleList[i] = null;
        }
    }

    private void selectToggle(int tab)
    {
        if (ToggleList == null || tab >= ToggleList.Count)
        {
            return;
        }
        if (mainToggleText != null) mainToggleText.text = ToggleList[tab].toggleText.text;
        if (mainToggle != null)
        {
            mainToggle.isOn = false;
        }
        if (_tabChangeHandler != null)
        {
            _tabChangeHandler(tab);
        }
    }

}
