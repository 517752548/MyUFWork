using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupLifeTips : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Close());
	}

	IEnumerator Close()
	{
		yield return new WaitForSeconds(3);
		gameObject.SetActive(false);
	}
	
}
