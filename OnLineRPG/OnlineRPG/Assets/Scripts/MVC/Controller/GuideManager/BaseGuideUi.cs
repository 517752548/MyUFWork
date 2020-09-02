using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGuideUi : UIWindowBase
{
    protected Dictionary<string,Transform> movedTransforms = new Dictionary<string, Transform>();
    protected object[] obj;
    public virtual void SetGuideElement(params object[] obj)
    {
        this.obj = obj;
    }


    /// <summary>
    /// 通过把这个组件移动到自己类下来达到高亮的目的
    /// </summary>
    /// <param name="transform"></param>
    protected void HighLightGameObjectByMoveParent(Transform TargetTransform)
    {
        if (!movedTransforms.ContainsKey(TargetTransform.name))
        {
            movedTransforms.Add(TargetTransform.name,TargetTransform.parent);
        }
        TargetTransform.SetParent(transform,false);
    }

    /// <summary>
    /// 把对象移动到原来的层级上去
    /// </summary>
    /// <param name="TargetTransform"></param>
    protected void ReCoverGameObjectToparent(Transform TargetTransform)
    {
        if (!movedTransforms.ContainsKey(TargetTransform.name))
        {
            TargetTransform.SetParent(movedTransforms[TargetTransform.name],false);
        }
    }
    
}
