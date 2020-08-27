using System.Collections;
using UnityEngine;

public class DlayDestroy : MonoBehaviour
{
    public float dlayTime = 5f;

    public bool isPetEffect;

    private bool collected;

    // Use this for initialization
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(dlayTime);
        if (isPetEffect && !collected)
        {
//            if(gameObject.name == "prefab_15003_Skill3_Self_FX")
//                Debug.LogError("回收应该回收的特效");
            collected = true;
//            DataManager.EffectPool.PetEffectDestroy(gameObject);
        }
        else
        {
//            if(gameObject.name == "prefab_15003_Skill3_Self_FX")
//                Debug.LogError("销毁了应该回收的特效");
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        if (isPetEffect && !collected)
        {
//            if(gameObject.name == "prefab_15003_Skill3_Self_FX")
//                Debug.LogError("回收应该回收的特效");
            collected = true;
//            DataManager.EffectPool.PetEffectDestroy(gameObject);
        }
        else
        {
            if(collected)
                return;
//            if(gameObject.name == "prefab_15003_Skill3_Self_FX")
//                Debug.LogError("销毁了应该回收的特效");
            Destroy(gameObject);
        }

    }
}