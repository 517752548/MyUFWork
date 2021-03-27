using UnityEngine;
using System.Collections;

public class FreeCameraControl : MonoBehaviour
{
	// Use this for initialization
	private GameObject gameObject;
	float x1;
	float x2;
	float x3;
	float x4;
	void Start()
	{
		gameObject = GameObject.FindWithTag("MainCamera");
	}

	// Update is called once per frame
	void Update()
	{
		//空格键抬升高度
		if (Input.GetKey(KeyCode.Space))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
		}

		//w键前进
		if (Input.GetKey(KeyCode.W))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, 5 * Time.deltaTime));
		}
		//s键后退
		if (Input.GetKey(KeyCode.S))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, -5 * Time.deltaTime));
		}
		//a键后退
		if (Input.GetKey(KeyCode.A))
		{
			this.gameObject.transform.Translate(new Vector3(-5, 0, 0 * Time.deltaTime));
		}
		//d键后退
		if (Input.GetKey(KeyCode.D))
		{
			this.gameObject.transform.Translate(new Vector3(5, 0, 0 * Time.deltaTime));
		}
	}
}