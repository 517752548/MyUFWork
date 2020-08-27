using UnityEngine;

public class RateRewardGuide : BaseBoardArrowGuide
{
    public override void OnOpen()
    {
        base.OnOpen();
    }

    protected override void AdjustPosition()
    {
        base.AdjustPosition();
        float cellSize = (float) objs[1];
        int count = (int) objs[2];
        float padding = 30f;
        var rt = arrowTarget.gameObject.GetComponent<RectTransform>();
        rt.localPosition -= new Vector3(cellSize / 2 + padding, 0, 0);
        rt.sizeDelta = new Vector2(cellSize * count + padding * 2, cellSize + padding * 2);
    }
}