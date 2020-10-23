using UnityEngine;
using DG.Tweening;

namespace app.zone
{
    public interface IZoneBubble
    {
        //ZoneBubbleContentType contentType { get; }
        Tweener moveTweener { get; }
        Tweener fadeOutTweener { get; }
        Tweener fadeInTweener { get; }
        float secondsLeft { get; set; }
        GameObject gameObject { get; }
        float width { get; }
        float height { get; }
        string flyToBagTextureBundlePath { get;set; }
        int flyToBagTimes { get; set; }
        bool isDestroied { get; }
        bool isMoveFinished { get; }
        Tweener Move(Vector3 targetPos);
        Tweener FadeOut();
        void KillMoveTweener();
        void KillFadeOutTweener();
        void KillFadeInTweener();
        void Destroy();
        void Use();
        void UnUse();
    }
}

