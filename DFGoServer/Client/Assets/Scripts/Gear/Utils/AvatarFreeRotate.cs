using UnityEngine;
using System.Collections;

public class AvatarFreeRotate : MonoBehaviour
{
	private bool isMouseDown;
	// Use this for initialization
	void Start()
	{
		BoxCollider collider = GetComponent<BoxCollider>();
		if (!collider)
		{
			collider = gameObject.AddComponent<BoxCollider>();
		}
		collider.center = new Vector3(0, 1, 0);
		collider.size = new Vector3(1f, 3f, 0.5f);
	}

	void Update()
	{
		if (!isMouseDown)
			return;
		float axisXGap = 0f;
		if (PlatformUtil.IsWindowsPlayer() || PlatformUtil.IsRunInEditor())
		{
			axisXGap = Input.GetAxis("Mouse X") * 0.5f;
		}
		else
		{
			int touchCount = Input.touchCount;
			if (touchCount == 1)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Moved)
				{
					axisXGap = touch.deltaPosition.x * 0.03f;
				}
			}
		}
		float rotX = transform.eulerAngles.x;
		float rotY = transform.eulerAngles.y + (-axisXGap * 20);
		float rotZ = transform.eulerAngles.z;
		transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
	}

	private void OnMouseDown()
	{
		isMouseDown = true;
	}

	private void OnMouseUp()
	{
		isMouseDown = false;
	}
}
