using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TaroLocalRotation : MonoBehaviour
{
	public Vector3 eulerAngles = Vector3.zero;
	void Start()
	{
	}

	void Update()
	{
		transform.Rotate(eulerAngles);
	}
}
