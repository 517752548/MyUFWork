using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class FRStar : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FlyToTarget(Vector3 pos,FastRaceHead _FastRaceHead)
    {
        gameObject.SetActive(true);
        float delay = 0.5f;
        float fly = 0.5f;
        transform.DOScale(Vector3.one * 0.8f, fly).SetDelay(delay).OnStart(() =>
        {
            anim.SetTrigger("fly");
        });
        transform.DOMove(_FastRaceHead.star.position, fly).OnComplete(() =>
        {
            AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().AddScore();
            _FastRaceHead.DoAnim();
            ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_FRStar_Boom).Completed += op =>
            {
                Transform star = transform.GetChild(0);
                if (star)
                {
                    star.gameObject.SetActive(false);
                }
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_frstarDown);
                GameObject effect = Instantiate(op.Result,transform,false);
                effect.SetActive(true);
                Destroy(gameObject,0.8f);
            };
            
        }).SetDelay(delay);
    }
}
