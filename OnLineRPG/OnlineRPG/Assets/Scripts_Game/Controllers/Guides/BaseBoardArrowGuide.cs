using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using BetaFramework;
using System.Collections.Generic;

public class BaseBoardArrowGuide : BaseBoardGuide
{
    [SerializeField]
    protected RectTransform arrow;
    [SerializeField]
    protected Transform arrowTarget;
    
    public override void OnOpen()
    {
        base.OnOpen();

        AdjustPosition();
    }
    
    protected virtual void AdjustPosition()
    {
        Vector3 oldPos = arrowTarget.localPosition;
        arrowTarget.position = guideParam.targetInfo.target.position;
        arrowTarget.SetLocalZ(0);
        Vector3 delta = arrowTarget.localPosition - oldPos;
        board.localPosition += new Vector3(0, delta.y, 0);
        arrow.localPosition += delta;
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        //return base.EnterAnim(objs);
        //if (anim != null && hidingAnimation != null)
        //{
        //    anim.SetTrigger("show");
        //}
        OpenSuccess();

        yield break;

    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        //return base.ExitAnim(l_callBack, objs);
        if (anim != null && hidingAnimation != null)
        {
            anim.SetTrigger("close");
            yield return new WaitForSeconds(hidingAnimation.length);
        }
        else
            yield return new WaitForSeconds(0.2f);
        
        ExitSuccess();

        yield break;
    }
}
