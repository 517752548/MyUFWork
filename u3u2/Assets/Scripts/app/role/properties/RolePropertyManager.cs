using System;
using System.Collections.Generic;
using app.net;
using app.role;

public delegate void onRolePropChanged();
public abstract class RolePropertyManager<T> where T : Role
{
    /// <summary>
    /// 属性变更的事件字典，key是属性，value是事件集合
    /// </summary>
    private Dictionary<int, HashSet<onRolePropChanged>> changedEventDic = new Dictionary<int, HashSet<onRolePropChanged>>();
    /// <summary>
    /// PetA任意属性变化的事件
    /// </summary>
    private onRolePropChanged petAPropChangedHandler;
    /// <summary>
    /// PetB任意属性变化的事件
    /// </summary>
    private onRolePropChanged petBPropChangedHandler;

    protected T owner;

    protected Dictionary<int, int> intPropDic = new Dictionary<int, int>();
    protected Dictionary<int, string> strPropDic = new Dictionary<int, string>();

    public RolePropertyManager(T role)
    {
        if (role == null)
        {
            throw new Exception("role is null!");
        }
        owner = role;
    }

    /// <summary>
    /// 更新PetAProperty变更时的事件处理方法，即任意属性变更，均调用此方法，不做细分
    /// </summary>
    /// <param name="handler"></param>
    public void addPetAPropChangedEvent(onRolePropChanged handler)
    {
        petAPropChangedHandler = handler;
    }

    /// <summary>
    /// 更新PetBProperty变更时的事件处理方法，即任意属性变更，均调用此方法，不做细分
    /// </summary>
    /// <param name="handler"></param>
    public void addPetBPropChangedEvent(onRolePropChanged handler)
    {
        petBPropChangedHandler = handler;
    }

    /// <summary>
    /// 添加指定属性key变更时的处理方法
    /// </summary>
    /// <param name="handler">处理方法</param>
    /// <param name="propKeyArr">经过 PropertyType.genPropertyKey 处理过的属性key数组</param>
    public void addPropChangedEvent(onRolePropChanged handler, int[] propKeyArr)
    {
        for (int i = 0; i < propKeyArr.Length; i++)
        {
            int key = propKeyArr[i];
            if (!changedEventDic.ContainsKey(key))
            {
                changedEventDic[key] = new HashSet<onRolePropChanged>();
            }
            HashSet<onRolePropChanged> lst = changedEventDic[key];
            
            lst.Add(handler);
        }
    }

    /// <summary>
    /// 添加指定属性key变更时的处理方法
    /// </summary>
    /// <param name="handler">处理方法</param>
    /// <param name="propKey">经过 PropertyType.genPropertyKey 处理过的属性key</param>
    public void addPropChangedEvent(onRolePropChanged handler, int propKey)
    { 
        int[] t = {propKey};
        addPropChangedEvent(handler, t);
    }

    private void onPropChanged(int[] changedKeyArr)
    {
        //已经调用过的方法集合，排重用，不重复调用相同的方法
        HashSet<onRolePropChanged> calledSet = new HashSet<onRolePropChanged>();
        bool isPetAChanged = false;
        bool isPetBChanged = false;

        for (int i = 0; i < changedKeyArr.Length; i++ )
        {
            int changedKey = changedKeyArr[i];
            if (!isPetAChanged && PropertyType.isPetAProp(changedKey))
            {
                isPetAChanged = true;
            }
            if (!isPetBChanged && PropertyType.isPetBProp(changedKey))
            {
                isPetBChanged = true;
            }

            HashSet<onRolePropChanged> curSet;
            changedEventDic.TryGetValue(changedKey, out curSet);
            if (curSet != null && curSet.Count > 0)
            {
                foreach (onRolePropChanged handler in curSet)
                {
                    if (!calledSet.Contains(handler))
                    {
                        calledSet.Add(handler);
                        handler();
                    }
                }
            }
        }

        if (isPetAChanged)
        {
            if (null != petAPropChangedHandler)
            {
                petAPropChangedHandler();
            }
        }

        if (isPetBChanged)
        {
            if (null != petBPropChangedHandler)
            {
                petBPropChangedHandler();
            }
        }
    }

    protected int getInt(int k)
    {
        int ret;
        intPropDic.TryGetValue(k, out ret);
        return ret;
    }

    protected string getString(int k)
    {
        string ret;
        strPropDic.TryGetValue(k, out ret);
        return ret;
    }

    protected long getLong(int k)
    {
        string ret;
        strPropDic.TryGetValue(k, out ret);
        if (ret == null || ret == "")
        {
            return 0;
        }
        long tmp=0;
        long.TryParse(ret,out tmp);
        return tmp;
    }

    public void updateIntDic(KeyValuePairIntData[] propArr)
    {
        int[] changedKeyArr = new int[propArr.Length];
        for (int i = 0; i < propArr.Length; i++ )
        {
            intPropDic[propArr[i].key] = propArr[i].value;
            changedKeyArr[i] = propArr[i].key;
        }
        onPropChanged(changedKeyArr);
    }

    public void updateStrDic(KeyValuePairStringData[] propArr)
    {
        int[] changedKeyArr = new int[propArr.Length];
        for (int i = 0; i < propArr.Length; i++)
        {
            strPropDic[propArr[i].key] = propArr[i].value;
            changedKeyArr[i] = propArr[i].key;
        }
        onPropChanged(changedKeyArr);
    }

    public void Destory()
    {
        if(changedEventDic!=null)changedEventDic.Clear();
        petAPropChangedHandler=null;
        petBPropChangedHandler=null;
        owner=null;
        if(intPropDic!=null)intPropDic.Clear();
        if(strPropDic!=null)strPropDic.Clear();
    }
}

