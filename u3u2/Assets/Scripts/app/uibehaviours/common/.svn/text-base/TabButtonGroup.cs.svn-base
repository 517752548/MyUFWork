using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 切换回调,索引从0开始
/// </summary>
public delegate void TabChangeHandler(int currentTabIndex);
public delegate void AllTabCloseHandler();

public class TabButtonGroup : MonoBehaviour
{
    public void Init()
    {
    }
    public List<GameUUToggle> toggleList = new List<GameUUToggle>();

    private TabChangeHandler _tabChangeHandler;

    private AllTabCloseHandler _allTabCloseHandler;

    private int _currentTabIndex = -1;
    //private bool awakeCallBack = false;
    private bool selectDefault = true;
    private bool reSelected = false;
    public TabChangeHandler TabChangeHandler
    {
        get { return _tabChangeHandler; }
        set { _tabChangeHandler = value; }
    }

    private bool hasAwake = false;

    /*
    void Awake()
    {
        if (hasAwake)
        {
            return;
        }
        hasAwake = true;
        updateSelect();
    }
    */

    public void setHasAwake()
    {
        hasAwake = true;
    }

    private void updateSelect()
    {
        if (_currentTabIndex == -1)
        {
            //没有选中的
            bool hasOn = false;
            for (int i = 0;toggleList!=null&& i < toggleList.Count; i++)
            {
                if (toggleList[i].isOn && selectDefault)
                {//默认选中的
                    _currentTabIndex = i;
                    hasOn = true;
                    break;
                }
                if (!selectDefault)
                {//不需要默认选中
                    toggleList[i].isOn = false;
                }
            }
            if (selectDefault && !hasOn)
            {//需要默认时，如果没有选中的 默认选中第一个
                if (toggleList != null && toggleList.Count > 0)
                {
                    _currentTabIndex = 0;
                    toggleList[0].isOn = true;
                }
            }
        }
        /*
        //添加监听
        for (int i = 0; i < toggleList.Count; i++)
        {
            removeAllListener(toggleList[i]);
            toggleList[i].SetValueChangedCallBack(doClick);
        }
        */
        if (_currentTabIndex != -1)
        {
            //有选中的
            for (int i = 0; toggleList != null && i < toggleList.Count; i++)
            {
                if (i == _currentTabIndex)
                {
                    if (!toggleList[i].isOn)
                    {
                        toggleList[i].isOn = true;
                    }
                    doSet();
                }
                else
                {
                    toggleList[i].ClearClickCallBack();
                    toggleList[i].isOn = false;
                    toggleList[i].AddValueChangedCallBack(doClick);
                }
            }
        }
    }

    /*
    public void SetIndexNoCallBack(int indexv)
    {
        if (!hasAwake)
        {
            _currentTabIndex = indexv;
            awakeCallBack = false;
        }
        else
        {
            for (int i = 0; i < toggleList.Count; i++)
            {
                if (i == indexv)
                {
                    _currentTabIndex = i;
                    bool tmp = reSelected;
                    reSelected = false;
                    toggleList[i].isOn = true;
                    reSelected = tmp;
                    //Debug.Log("TTTTTTTTTTTTT setIndex:: " + toggleList[i].group.name + " Index: " + i);
                    break;
                }
            }
        }
    }
    */

    public void SetIndexWithCallBack(int indexv)
    {
        if (!hasAwake)
        {
            _currentTabIndex = indexv;
            //            awakeCallBack = true;
            updateSelect();
        }
        else
        {
            ForceSetIndex = indexv;
        }
    }

    /// <summary>
    /// 刷新当前选中的
    /// </summary>
    public void RefreshCurrent()
    {
        if (_currentTabIndex != -1)
        {
            ForceSetIndex = _currentTabIndex;
        }
        else
        {
            if (toggleList != null && toggleList.Count > 0)
            {
                ForceSetIndex = 0;
            }
        }
    }

    public int index
    {
        get
        {
            return _currentTabIndex;
        }
    }

    private int ForceSetIndex
    {
        set
        {
            for (int i = 0; i < toggleList.Count; i++)
            {
                if (value == i)
                {
                    if (!toggleList[i].isOn)
                    {
                        bool tmp = reSelected;
                        reSelected = true;
                        toggleList[i].isOn = true;
                        reSelected = tmp;
                    }
                    else
                    {
                        doSet();
                    }
                }
                else
                {
                    toggleList[i].isOn = false;
                }
            }
        }
    }

    /// <summary>
    /// 选中之后 需要修改 child的层级到最上层
    /// </summary>
    public AllTabCloseHandler AllTabCloseHandler
    {
        set
        {
            _allTabCloseHandler = value;
            if (toggleList != null && toggleList.Count > 0)
            {
                toggleList[0].group.allowSwitchOff = true;
            }
        }
    }

    public bool SelectDefault
    {
        set { selectDefault = value; }
    }

    public bool ReSelected
    {
        set { reSelected = value; }
    }

    private void doSet()
    {
        for (int i = 0; i < toggleList.Count; i++)
        {
            if (toggleList[i].isOn)
            {
                _currentTabIndex = i;
                if (_tabChangeHandler != null)
                {
                    _tabChangeHandler(i);
                }
                break;
            }
        }
    }

    private void doClick(bool state)
    {
        if (!state)
        {//关闭
            bool hason = false;
            for (int i = 0; i < toggleList.Count; i++)
            {
                if (toggleList[i].isOn)
                {
                    hason = true;
                    break;
                }
            }
            if (!hason)
            {//全部关闭
                _currentTabIndex = -1;
                if (_allTabCloseHandler != null)
                {
                    _allTabCloseHandler();
                }
            }
            return;
        }
        for (int i = 0; i < toggleList.Count; i++)
        {
            if (toggleList[i].isOn)
            {
                if (_currentTabIndex == i && reSelected == false)
                {//选中的是同一个，不处理
                    return;
                }
                //Debug.Log("TTTTTTTTTTTTT ChangeTabIndex:: " + toggleList[i].group.name + " Index: " + i);
                _currentTabIndex = i;
                if (_tabChangeHandler != null)
                {
                    _tabChangeHandler(i);
                }
                break;
            }
        }
    }

    public void ClearToggleList()
    {
        if (toggleList != null)
        {
            for (int i = 0; i < toggleList.Count; i++)
            {
                removeAllListener(toggleList[i]);
            }
            toggleList.Clear();
        }
        _currentTabIndex = -1;
    }

    public void AddToggle(GameUUToggle toggle)
    {
        if (toggleList == null)
        {
            toggleList = new List<GameUUToggle>();
        }
        if (toggleList.Contains(toggle))
        {
            //已经添加
            return;
        }
        //removeAllListener(toggle);
        //toggle.SetValueChangedCallBack(doClick);
        toggle.AddValueChangedCallBack(doClick);
        toggleList.Add(toggle);
        if (_currentTabIndex == -1)
        {
            if (toggle.isOn)
            {
                _currentTabIndex = toggleList.Count - 1;
            }
        }
    }

    public void InsertToggle(GameUUToggle toggle, int index)
    {
        if (toggleList == null)
        {
            toggleList = new List<GameUUToggle>();
        }

        int idx = toggleList.IndexOf(toggle);

        if (idx == -1)
        {
            toggle.AddValueChangedCallBack(doClick);
            toggleList.Insert(index, toggle);
            if (index == _currentTabIndex)
            {
                if (!toggle.isOn)
                {
                    toggle.isOn = true;
                }
                else
                {
                    SetIndexWithCallBack(_currentTabIndex);
                }
            }
        }
        else
        {
            throw new Exception("不能重复添加Toggle!");
        }
    }

    public void RemoveToggle(GameUUToggle toggle)
    {
        int idx = toggleList.IndexOf(toggle);
        if (idx != -1)
        {
            toggle.RemoveValueChangedCallBack(doClick);
            toggleList.RemoveAt(idx);
            /*
            if (_currentTabIndex == idx)
            {
                if (toggleList.Count > 0)
                {
                    SetIndexWithCallBack(0);
                }
                else
                {
                    UnSelectAll(true);
                }
            }
            */
            
            if (_currentTabIndex == idx || _currentTabIndex >= toggleList.Count)
            {
                _currentTabIndex = -1;
            }
        }
    }

    private void removeAllListener(GameUUToggle tg)
    {
        if (tg != null) tg.ClearClickCallBack();
    }

    public void UnSelectAll(bool forceCallBack = false)
    {
        if (toggleList != null && toggleList.Count > 0)
        {
            toggleList[0].group.allowSwitchOff = true;
        }
        for (int i = 0; i < toggleList.Count; i++)
        {
            if (toggleList[i].isOn)
            {
                toggleList[i].isOn = false;
                forceCallBack = false;
            }
        }
        _currentTabIndex = -1;
        if (forceCallBack)
        {
            _allTabCloseHandler();
        }
    }

}
