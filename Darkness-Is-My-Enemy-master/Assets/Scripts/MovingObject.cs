using UnityEngine;
using System.Collections;
[DisallowMultipleComponent]
public class MovingObject : MonoBehaviour
{


    [SerializeField]
    Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField]
    float period = 2f;

    [Range(0, 1)]
    [SerializeField]
    float movementFactor;  // 0 or 1 

    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        float cycles = Time.time / period; // grows from 0
        const float tau = Mathf.PI * 2f; //6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startPos + offset;
    }
}

