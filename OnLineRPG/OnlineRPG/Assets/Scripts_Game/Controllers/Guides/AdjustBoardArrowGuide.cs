using UnityEngine;
using System.Collections;

public class AdjustBoardArrowGuide : BaseBoardArrowGuide
{
    [SerializeField]
    protected Transform arrowBase;

    protected float arrowDistance = 1;

    protected override void AdjustPosition()
    {
        arrowDistance = Vector3.Distance(arrow.position, arrowTarget.position);
        Vector3 oldPos = arrowTarget.localPosition;
        arrowTarget.position = guideParam.targetInfo.target.position;
        arrowTarget.SetLocalZ(0);
        Vector3 delta = arrowTarget.localPosition - oldPos;
        Vector3 deltaY = new Vector3(0, delta.y, 0);
        arrowBase.localPosition += deltaY;
        board.localPosition += deltaY;

        AdjustArrowPosition(arrowTarget, arrow);
    }

    protected void AdjustArrowPosition(Transform arrowTarget, Transform arrow)
    {
        Quaternion q = Quaternion.FromToRotation(new Vector3(0, -1, 0), arrowTarget.position - arrowBase.position);
        arrow.rotation = Quaternion.Euler(0, 0, q.eulerAngles.z);
        arrow.position = Vector3.MoveTowards(arrowTarget.position, arrowBase.position, arrowDistance);
    }
}
