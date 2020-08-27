using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppThreadController : MonoBehaviour
{

	private static AppThreadController _instance = null;

	public static AppThreadController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<AppThreadController>();
			return _instance;
		}
	}
}
