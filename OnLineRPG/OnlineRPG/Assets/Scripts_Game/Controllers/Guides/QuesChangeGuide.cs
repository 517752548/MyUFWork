using UnityEngine;
using System.Collections;
using BetaFramework;

public class QuesChangeGuide : AdjustBoardArrowGuide
{
    [SerializeField]
    protected RectTransform arrow2;
    [SerializeField]
    protected Transform arrowTarget2;

    private Vector3 arrowTargetPos1, arrowTargetPos2;

    public override void OnOpen()
    {
        arrowTargetPos1 = (Vector3)objs[1];
        arrowTargetPos2 = (Vector3)objs[2];
        base.OnOpen();
    }

    protected override void AdjustPosition()
    {
        arrowDistance = Vector3.Distance(arrow.position, arrowTarget.position);
        Vector3 oldPos = arrowTarget.localPosition;
        arrowTarget.position = arrowTargetPos1;
        arrowTarget.SetLocalZ(0);
        Vector3 delta = arrowTarget.localPosition - oldPos;
        Vector3 deltaY = new Vector3(0, delta.y, 0);
        arrowBase.localPosition += deltaY;
        board.localPosition += deltaY;
        AdjustArrowPosition(arrowTarget, arrow);
        arrowTarget2.position = arrowTargetPos2;
        arrowTarget2.SetLocalZ(0);
        AdjustArrowPosition(arrowTarget2, arrow2);
    }
}
