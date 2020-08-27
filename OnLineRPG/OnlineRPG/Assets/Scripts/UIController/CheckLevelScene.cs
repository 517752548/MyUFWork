using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class CheckLevelScene : MonoBehaviour
{
    public int level = 7;
    // Start is called before the first frame update
    void Start()
    {
        AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().LoadClassicLevel(level, op =>
        {
            if (op)
            {
                level++;
                Start();
                Debug.Log(level);
            }
            else
            {
                Debug.LogError(level);
            }
        });
    }


}
