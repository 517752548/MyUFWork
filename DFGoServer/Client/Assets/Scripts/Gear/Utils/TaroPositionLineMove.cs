using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TaroPositionLineMove : MonoBehaviour
{
	public float moveTime = 0f;
	private float startMoveTime = 0f;
	public bool once = false;
	public Vector3 moveOffsetVector = Vector3.zero;
	Vector3 startPos;
	Vector3 endPos;
	private bool isStop = false;
	void Start()
	{
		startMoveTime = Time.time;
		startPos = transform.position;
		endPos = transform.position + moveOffsetVector;
		isStop = false;
	}

	void Update()
	{
		if (isStop)
			return;

		if (moveTime <= 0f)
			return;

		float t = Mathf.Clamp01((Time.time - startMoveTime) / moveTime);
		if (t >= 1)
		{
			if (!once)
			{
				startMoveTime = Time.time;
				transform.position = startPos;
			}
			else
			{
				isStop = true;
			}
			return;
		}
		transform.position = Vector3.Lerp(startPos, endPos, t);
	}
}
