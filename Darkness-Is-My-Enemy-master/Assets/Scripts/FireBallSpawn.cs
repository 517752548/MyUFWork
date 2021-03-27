using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawn : MonoBehaviour
{
    public GameObject FireBall;
    public float TimeGap;

    private float _startTimeGap;
    // Start is called before the first frame update
    void Start()
    {
        _startTimeGap = TimeGap;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_startTimeGap) < .01)
        {
            Instantiate(FireBall, transform.position, Quaternion.identity);
            _startTimeGap = TimeGap;
        }
        else
        {
            _startTimeGap -= Time.deltaTime;
        }
    }
}
