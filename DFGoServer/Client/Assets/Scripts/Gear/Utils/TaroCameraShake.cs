using UnityEngine;
using System.Collections;
using DG.Tweening;
[ExecuteInEditMode]
public class TaroCameraShake : MonoBehaviour
{
	private Camera _camera;
	public float delay;
	public float duration;
	public Vector3 strength = Vector3.one;
	public int vibrato;
	public float randomness;

	void Start()
	{
		Invoke("ExecShake", delay);
	}

	void OnEnable()
	{
		Invoke("ExecShake", delay);
	}

	public void ExecShake()
	{
		if (_camera == null)
		{

			GameObject cgo = GameObject.Find("Main Camera");
			if (cgo != null)
			{
				_camera = cgo.GetComponent<Camera>();
			}
		}
		if (_camera != null)
		{
			_camera.transform.DOShakePosition(duration, strength, vibrato, randomness);
		}
	}
}
