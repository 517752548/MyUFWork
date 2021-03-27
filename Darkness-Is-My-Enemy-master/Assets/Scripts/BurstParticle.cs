using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstParticle : MonoBehaviour
{
    public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
