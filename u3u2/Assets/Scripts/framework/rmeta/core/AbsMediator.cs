using System;
using System.Reflection;
using System.Text;
public abstract class AbsMediator:AbsMonoBehaviour
{
    protected String ui_path;
    protected String ui_fieldInfoName;
    
    public AbsMediator()
    {
        getTags();
    }

    protected virtual REventAttribute getREventTags(object a_obj)
    {
        REventAttribute ea = a_obj as REventAttribute;
        RMetaEventHandler handler = RMetaEventHandler.CreateDelegate(typeof(RMetaEventHandler), this, ea.handler) as RMetaEventHandler;
        EventCore.addRMetaEventListener(ea.type, handler);
        return ea;
    }

    protected InjectAttribute getInjectTags(FieldInfo fieldInfo, object a_obj)
    {
        Type f_type = fieldInfo.FieldType;
        InjectAttribute ia = a_obj as InjectAttribute;
        if (ia.ui == null)
        {
            object obj = Activator.CreateInstance(f_type);
            Type type = this.GetType();
            object[] parms = new object[1];
            parms[0] = obj;
            type.InvokeMember(fieldInfo.Name, BindingFlags.SetField, null, this, parms);
        }
        else
        {
            ui_path = ia.ui;
            ui_fieldInfoName = fieldInfo.Name;
        }
        return ia;
    }

    private void getRBindTags(FieldInfo fieldInfo, object a_obj)
    {
        Type f_type = fieldInfo.FieldType;
        object obj = Singleton.GetObj(f_type);

        Type type = this.GetType();
        object[] parms = new object[1];
        parms[0] = obj;
        type.InvokeMember(fieldInfo.Name, BindingFlags.SetField, null, this, parms);

        RBindAttribute ra = a_obj as RBindAttribute;
        if (ra.handler != null)
        {
            RMetaEventHandler handler = RMetaEventHandler.CreateDelegate(typeof(RMetaEventHandler), this, ra.handler) as RMetaEventHandler;
            EventCore.addRMetaEventListener(f_type.Namespace + "." + f_type.Name + "." + ra.changedType, handler);
        }
    }

    private void getTags()
    {
        Type type = this.GetType();
        object[] ary = type.GetCustomAttributes(false);

        int count = ary.Length;
        object obj;

        for (int i = 0; i < count; i++)
        {
            obj = ary[i];
            getREventTags(obj);
        }

        ary = type.GetFields();
        count = ary.Length;
        object[] ary_pro;
        int count_pro;
        for (int i = 0; i < count; i++)
        {
            FieldInfo fieldInfo = ary[i] as FieldInfo;
            ary_pro = Attribute.GetCustomAttributes(fieldInfo);
            count_pro = ary_pro.Length;
            for (int j = 0; j < count_pro; j++)
            {
                if (ary_pro[j].GetType().Name == "InjectAttribute")
                {
                    getInjectTags(fieldInfo, ary_pro[j]);
                }
                else if (ary_pro[j].GetType().Name == "RBindAttribute")
                {
                    getRBindTags(fieldInfo, ary_pro[j]);
                }
            }
        }
    }

    public override string ToString()
    {
        return new StringBuilder(this.GetType().Namespace).Append(".").Append(this.GetType().Name).ToString();
    }
}