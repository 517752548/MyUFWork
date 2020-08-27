using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    public float MoveSpeed = 50f;
    public float XOffset = 20;
    public float YOffset = 20;
    public float ZOffset = 0;
    public float AccelerometerUpdateInterval = 1.0f / 60.0f;    //加速器刷新间隔
    public float LowPassKernelWidthInSeconds = 1.0f;            //值越大,被过滤值将汇集当前输入采样越慢
    public float LowPassFilterFactor;                           //过滤范围

    private Vector3 _lowPassValue = Vector3.zero;

    private void Start()
    {
        _lowPassValue = Input.acceleration;
        LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
    }

    private void Update()
    {
        Vector3 lowPassAcceleration = LowPassFilterAccelerometer();

        lowPassAcceleration = new Vector3(lowPassAcceleration.x * XOffset, lowPassAcceleration.y * YOffset, lowPassAcceleration.z * ZOffset);
        transform.position = Vector3.Lerp(transform.position, lowPassAcceleration, Time.deltaTime * MoveSpeed);
    }

    private Vector3 LowPassFilterAccelerometer()
    {
        _lowPassValue = Vector3.Lerp(_lowPassValue, Input.acceleration, LowPassFilterFactor);
        return _lowPassValue;
    }
}