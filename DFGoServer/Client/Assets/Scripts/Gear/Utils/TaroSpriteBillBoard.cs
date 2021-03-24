using UnityEngine;
using System.Collections;

public class TaroSpriteBillBoard : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (CSGlobal.faceCamera == null)
			return;
		transform.rotation = Quaternion.Euler(CSGlobal.faceCamera.transform.rotation.eulerAngles.x, CSGlobal.faceCamera.transform.rotation.eulerAngles.y, 0);
	}
}
