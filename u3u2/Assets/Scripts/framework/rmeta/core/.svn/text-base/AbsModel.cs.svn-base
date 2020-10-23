using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public abstract class AbsModel
{
    private static Dictionary<Type, AbsModel> modelDic = new Dictionary<Type, AbsModel>();
    private Type mType;

    public AbsModel()
    {
        mType = this.GetType();
        if (!modelDic.ContainsKey(mType))
        {
            modelDic.Add(mType, this);
        }
    }

	public static void DestroyAllModel()
	{
		IDictionaryEnumerator enumerator = modelDic.GetEnumerator();
		while (enumerator.MoveNext())
		{
			AbsModel v = (AbsModel)enumerator.Value;
			v.Destroy();
		}
		modelDic.Clear();
	}

    public static Dictionary<Type, AbsModel>.ValueCollection getAllModel()
    {
        return modelDic.Values;
        //return null;
    }
    
    public void addChangeEvent(String changedType, RMetaEventHandler handler)
    {
        EventCore.addRMetaEventListener(GetFinalEventType(changedType), handler);
    }

    public void dispatchChangeEvent(String changedType, object data)
    {
        EventCore.dispathRMetaEventByParms(GetFinalEventType(changedType), data);
    }

    public void removeChangeEvent(String changedType, RMetaEventHandler handler)
    {
        EventCore.removeRMetaEventListener(GetFinalEventType(changedType), handler);
    }
    
    public string GetFinalEventType(string type)
    {
        return new StringBuilder(mType.Namespace).Append(".").Append(mType.Name).Append(".").Append(type).ToString();
    }

    public abstract void Destroy();
}

