using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ImageFreeRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	public GameObject targetGo;
	public new Camera camera;

	bool canVerticalRotation = false;

	bool isMouseDown;

	bool touchStart1;
	bool touchStart2;

	bool touchMove1;
	bool touchMove2;

	bool touchEnd1;
	bool touchEnd2;


	Touch touch1;
	Touch touch2;

	Vector2 tempTouchPos1;
	Vector2 tempTouchPos2;
	Vector2 oldTouchPos1;
	Vector2 oldTouchPos2;

	Vector3 tmpBackward = Vector3.zero;
	Vector3 heightTempVector;
	Vector3 cameraAimPos;

	Vector3 tempAngle = new Vector3(0, 180, 0);

	Vector3 cameraOriginalPos;

	float axisXGap;
	float axisYGap;
	float rotX;
	float rotY;
	float rotZ;


	float modelHeight = 0.0f;

	float dist = 0.0f;
	float touchDistRate = 0.04f;
	float zoomSpeed = 20.0f;        //缩进速度

	float tempDist = 10.0f;
	float maxDist = 7.0f;
	float minDist = 2.0f;

	bool isReset = false;
	bool canStretching = false; // 是否可以拉伸

	enum PART
	{
		FACE,
		BACK,
		FRONT,
		WAIST,
		LEG,
	}

	// Use this for initialization
	void Start()
	{

	}


	public float speed = 20;

	private bool _mouseDown = false;



	void Update()
	{
		if(canVerticalRotation)
		{
			UpdateRotation360();
		}
		else
		{
			UpdateRotation();
		}

		if (canStretching && (camera != null))
		{
			UpdateDist();
		}
	}

	void LateUpdate()
	{
		if (canStretching && (camera != null))
		{
			UpdatePos();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isMouseDown = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isMouseDown = false;
	}

	// 旋转
	void UpdateRotation()
	{
		if (!isMouseDown)
			return;

		if (targetGo == null)
			return;

		axisXGap = 0f;

		if (PlatformUtil.IsWindowsPlayer() || PlatformUtil.IsRunInEditor())
		{
			axisXGap = Input.GetAxis("Mouse X") * 0.5f;			
		}
		else
		{
			int touchCount = Input.touchCount;
			if (touchCount == 1)
			{
				touch1 = Input.GetTouch(0);
				if (touch1.phase == TouchPhase.Moved)
				{
					axisXGap = touch1.deltaPosition.x * 0.03f;					
				}
			}
		}

		rotX = targetGo.transform.eulerAngles.x + (axisYGap * 20);
		rotY = targetGo.transform.eulerAngles.y + (-axisXGap * 20);
		rotZ = targetGo.transform.eulerAngles.z;

		targetGo.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
	}


	void UpdateRotation360()
	{
		if (!isMouseDown)
			return;

		if (targetGo == null)
			return;

		axisXGap = 0f;
		axisYGap = 0f;

		if (PlatformUtil.IsWindowsPlayer() || PlatformUtil.IsRunInEditor())
		{
			axisXGap = Input.GetAxis("Mouse X");
			axisYGap = Input.GetAxis("Mouse Y");
		}else
		{
			if (Input.touchCount == 1)
			{
				touch1 = Input.GetTouch(0);
				if (touch1.phase == TouchPhase.Moved)
				{
					axisXGap = touch1.deltaPosition.x * 0.03f;
					axisYGap = touch1.deltaPosition.y * 0.03f;
				}
			}
		}

		targetGo.transform.Rotate(Vector3.up, -axisXGap * 20, Space.World);
		targetGo.transform.Rotate(Vector3.right, axisYGap * 20, Space.World);
	}



	//////////////////////////////////////////////////////////////////////////////
	public void SetVerticalRotationState(bool canRotation)
	{
		this.canVerticalRotation = canRotation;
	}


	public void SetModelHeight(float h)
	{
		canStretching = true;

		modelHeight = h;

		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.FRONT);

		cameraOriginalPos = camera.transform.position;
		cameraAimPos = cameraOriginalPos;

		maxDist = Vector3.Distance(camera.transform.position, targetGo.transform.position);
	}

	// 查看脸部
	public void LookFace()
	{
		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.FACE);

		targetGo.transform.DOLocalRotate(Vector3.zero, 0.2f);

		camera.transform.DOKill();
		canStretching = true;
		cameraAimPos = CalcNearPos(heightTempVector, PART.FACE);
		camera.transform.position = cameraAimPos;
	}

	// 查看背部
	public void LookBack()
	{
		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.BACK);

		targetGo.transform.DOLocalRotate(tempAngle, 0.2f);

		cameraAimPos = cameraOriginalPos;

		canStretching = false;
		camera.transform.DOKill();
		camera.transform.DOMove(cameraOriginalPos, 0.5f).OnComplete(() =>
		{
			canStretching = true;
		});
	}

	// 查看正面
	public void LookFront()
	{
		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.FRONT);

		targetGo.transform.DOLocalRotate(Vector3.zero, 0.2f);

		cameraAimPos = cameraOriginalPos;

		canStretching = false;
		camera.transform.DOKill();
		camera.transform.DOMove(cameraOriginalPos, 0.5f).OnComplete(() =>
		{
			canStretching = true;
		});
	}

	// 查看腰部
	public void LookWaist()
	{
		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.WAIST);

		targetGo.transform.DOLocalRotate(Vector3.zero, 0.2f);

		camera.transform.DOKill();
		canStretching = true;
		cameraAimPos = CalcNearPos(heightTempVector, PART.WAIST);
		camera.transform.position = cameraAimPos;
	}

	// 查看腿部
	public void LookLeg()
	{
		heightTempVector = targetGo.transform.position;
		heightTempVector.y = heightTempVector.y + GetPartRatio(PART.LEG);

		targetGo.transform.DOLocalRotate(Vector3.zero, 0.2f);

		camera.transform.DOKill();
		canStretching = true;
		cameraAimPos = CalcNearPos(heightTempVector, PART.LEG);
		camera.transform.position = cameraAimPos;
	}

	float GetPartRatio(PART type)
	{
		switch (type)
		{
			case PART.FACE:
				return modelHeight * 0.95f;
			case PART.BACK:
				return modelHeight * 0.5f;
			case PART.FRONT:
				return modelHeight * 1.13f;
			case PART.WAIST:
				return modelHeight * 0.618f;
			case PART.LEG:
				return 0f;
			default:
				return modelHeight;
		}
	}

	// 拉近距离
	float GetZoomInDist(PART type)
	{
		switch (type)
		{
			case PART.FACE:
				return minDist;
			case PART.BACK:
				return minDist;
			case PART.FRONT:
				return minDist;
			case PART.WAIST:
				return minDist;
			case PART.LEG:
				return 2.6f;
			default:
				return minDist;
		}
	}

	Vector3 CalcNearPos(Vector3 targetPos, PART type)
	{
		// 计算角度
		Vector3 angle = (targetPos - cameraOriginalPos).normalized;

		// 计算位置
		Vector3 newPos = targetPos - angle * GetZoomInDist(type);

		return newPos;
	}


	void UpdateDist()
	{
		dist = 0;

		if (PlatformUtil.IsWindowsPlayer() || PlatformUtil.IsRunInEditor())
		{
			dist -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		}
		else
		{
			// 多点触摸
			if (Input.touchCount > 1)
			{
				touch1 = Input.GetTouch(0);
				touch2 = Input.GetTouch(1);

				touchStart1 = (touch1.phase == TouchPhase.Stationary) || (touch1.phase == TouchPhase.Began);
				touchStart2 = (touch2.phase == TouchPhase.Stationary) || (touch2.phase == TouchPhase.Began);
				if (touchStart1 || touchStart2)
				{
					tempTouchPos1 = touch1.position;
					tempTouchPos2 = touch2.position;

					oldTouchPos1 = tempTouchPos1;
					oldTouchPos2 = tempTouchPos2;
				}

				touchMove1 = touch1.phase == TouchPhase.Moved;
				touchMove2 = touch2.phase == TouchPhase.Moved;
				if (touchMove1 || touchMove2)
				{
					tempTouchPos1 = touch1.position;
					tempTouchPos2 = touch2.position;
					var diff = Vector2.Distance(oldTouchPos1, oldTouchPos2) - Vector2.Distance(tempTouchPos1, tempTouchPos2);
					if (diff < 0)
					{
						dist = touchDistRate * zoomSpeed;
					}
					else if (diff > 0)
					{
						dist = touchDistRate * zoomSpeed * -1;
					}

					oldTouchPos1 = tempTouchPos1;
					oldTouchPos2 = tempTouchPos2;
				}

				touchEnd1 = (touch1.phase == TouchPhase.Ended) || (touch1.phase == TouchPhase.Canceled);
				touchEnd2 = (touch2.phase == TouchPhase.Ended) || (touch2.phase == TouchPhase.Canceled);
				if (touchEnd1 || touchEnd2)
				{
					dist = 0;
				}
			}
		}

		if (dist == 0)
			return;

		// 距离判断
		tempDist = Vector3.Distance(heightTempVector, camera.transform.position);

		tempDist = tempDist + dist;

		if (tempDist < minDist)
		{
			dist = dist - (tempDist - minDist);
		}

		if (tempDist > maxDist)
		{
			dist = dist - (tempDist - maxDist);
		}

		tmpBackward = (heightTempVector - camera.transform.position).normalized;
		cameraAimPos = camera.transform.position - tmpBackward * dist;
	}

	void UpdatePos()
	{
		camera.transform.position = Vector3.Lerp(camera.transform.position, cameraAimPos, Time.unscaledDeltaTime);
	}

}
