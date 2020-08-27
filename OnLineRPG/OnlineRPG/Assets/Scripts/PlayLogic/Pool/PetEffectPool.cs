using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Spine;
using Spine.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

public class PetEffectPool
{
    
    private Dictionary<string,Queue<GameObject>> CachePets = new Dictionary<string, Queue<GameObject>>();
    //特效
    private Dictionary<string, Queue<GameObject>> petEffect = new Dictionary<string, Queue<GameObject>>();

    private GameObject content { get; set; }

    public PetEffectPool()
    {
        content = new GameObject("PetCache");
        GameObject.DontDestroyOnLoad(content);
    }

}