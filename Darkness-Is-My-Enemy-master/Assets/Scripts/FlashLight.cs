using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public float offset;
    public float BatteryLifeTime;
    public int InitialRange;
    public int InitialIntensity;
    public Slider BatterySlider;

    private Player _player;
    private Light _light;
    private float _totalBatteryLifetime = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        if (Input.GetKeyDown(KeyCode.B))
        {
            if(_player.BatteryNum > 0)
            {
                _light.range += 5;
                _light.intensity += 5;
                _totalBatteryLifetime += BatteryLifeTime;
                _player.BatteryNum -= 1;
            }
            BatterySlider.maxValue = _totalBatteryLifetime;
            BatterySlider.value = _totalBatteryLifetime;
        }

        if(_totalBatteryLifetime > 0)
        {
            _totalBatteryLifetime -= Time.deltaTime;
            BatterySlider.value -= Time.deltaTime;
        }
        else
        {
            _light.range = InitialRange;
            _light.intensity = InitialIntensity;
        }
    }

    void Aim()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("Player").transform.position);

        if (Input.mousePosition.x < playerScreenPoint.x)
        {
            //if (Math.Abs(_player.move) < .01)
            //{
            //    GameObject.FindGameObjectWithTag("Player").transform.eulerAngles = new Vector3(0f, 180f, 0f);
            //}
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else
        {
            //if (Math.Abs(_player.move) < .01)
            //{
            //    GameObject.FindGameObjectWithTag("Player").transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //}
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }
}
