using DG.Tweening;
using UnityEngine;

public class RubyFly : MonoBehaviour
{
    public SpriteRenderer _sprite;

    /// <summary>
    /// 延迟销毁
    /// </summary>
    /// <param name="time"></param>
    public void DelayDestroy(float time)
    {
        BetaFramework.TimersManager.SetTimer(time - 0.25f, () =>
        {
            if (_sprite)
            {
                _sprite.DOFade(0, 0.3f).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            }
            else
            {
                Destroy(gameObject,0.3f);
            }
            
        });
    }
}