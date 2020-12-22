using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LastFlash : MonoBehaviour
{
    private Light _light;
    private float _startDelayTime;

    public float DelayTime;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _startDelayTime = DelayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startDelayTime > 0)
        {
            _startDelayTime -= Time.deltaTime;
        }
        else
        {
            if (_light.range > 0)
            {
                _light.range -= 5;
            }
            if(_light.intensity > 0)
            {
                _light.intensity -= 5;
            }
            _startDelayTime = DelayTime;
        }

        if(_light.intensity == 0 && _light.range == 0)
        {
            //Time.timeScale = 0;

        }
        
    }
}
