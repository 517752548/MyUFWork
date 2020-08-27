using DG.Tweening;
using UnityEngine;

public class AnimationStatus : MonoBehaviour
{
    public Vector2 OutScreenPos;
    public float GameStartDelay;

    public void DelayShow()
    {
        transform.DOLocalMove(Vector2.zero, 0.5f).SetDelay(GameStartDelay);
    }

    public void DelayHide()
    {
        transform.DOLocalMove(OutScreenPos, 0.5f);
    }

    public void ShowAtOnce()
    {
        transform.localPosition = Vector3.zero;
    }

    public void HideAtOnce()
    {
        transform.localPosition = new Vector3(OutScreenPos.x, OutScreenPos.y, 0);
    }
}