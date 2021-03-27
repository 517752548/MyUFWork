using UnityEngine;
using System.Collections;

public class HUDBloodContent : HUDBaseContent
{
	public HUDBloodQuad bottomQuad;
	public HUDBloodQuad middleQuad;
	public HUDBloodQuad topQuad;
	private Vector3 _syncPosition;
	private float lastMiddleWaitTime = 0f;
	public HUDBloodContent()
	{
		AllocateBuffer(30);
	}

	protected override HUDQuad GetTemporary()
	{
		HUDQuad quad = null;
		if (recycleQuadList.Count > 0)
		{
			quad = recycleQuadList.Dequeue();
			return quad;
		}
		quad = new HUDBloodQuad();
		return quad;
	}

	public void SetSyncPosition(Vector3 pos)
	{
		_syncPosition = pos;
	}

	protected HUDBloodQuad AppendItem(string spriteName)
	{
		Sprite sprite = null;
		_parentMesh.allSprite.TryGetValue(spriteName, out sprite);
		if (sprite != null)
		{
			HUDBloodQuad quad = GetTemporary() as HUDBloodQuad;
			quad.SetSprite(sprite);
			quads.Add(quad);

			CheckAndResizeBuffer();
			return quad;
		}
		return null;
	}

	public void AddBottom(string spriteName)
	{
		HUDBloodQuad quad = AppendItem(spriteName);
		if (quad != null)
		{
			bottomQuad = quad;
			bottomQuad.SetProgress(1f);
		}
	}
	public void AddMiddle(string spriteName)
	{
		HUDBloodQuad quad = AppendItem(spriteName);
		if (quad != null)
		{
			middleQuad = quad;
			middleQuad.SetProgress(1f);
		}
	}
	public void AddTop(string spriteName)
	{
		HUDBloodQuad quad = AppendItem(spriteName);
		if (quad != null)
		{
			topQuad = quad;
			topQuad.SetProgress(1f);
		}
	}

	public void SetProgress(float value, bool isTween = true)
	{
		if (topQuad != null)
		{
			topQuad.SetProgress(value);
		}
		if (!isTween)
		{
			if (middleQuad != null)
			{
				middleQuad.SetProgress(value);
			}
		}
		else
		{
			lastMiddleWaitTime = Time.time;
		}
	}

	public override void CalcQuadsVert()
	{
		float centerX = _startVertPos.x;
		float centerY = _startVertPos.y;
		float startX = _startVertPos.x;
		float startY = _startVertPos.y;
		_rectMaxWidth = 0f;
		_rectMaxHeight = 0f;
		for (int i = 0; i < quads.Count; i++)
		{
			HUDBloodQuad quad = quads[i] as HUDBloodQuad;
			quad.SetCenterPosInContent(centerX, centerY);
			quad.SetStartVert(startX - quad.GetVertWidth() / 2, startY - quad.GetVertHeight() / 2);
			_rectMaxWidth = Mathf.Max(quad.GetVertWidth(), _rectMaxWidth);
			_rectMaxHeight = Mathf.Max(quad.GetVertHeight(), _rectMaxHeight);
		}
	}

	public override void Update()
	{
		if (_isStop)
		{
			return;
		}
		if (_isStopRender)
		{
			return;
		}
		CalcQuadsVert();
		//处理中间条的缓动减少
		if (topQuad != null && middleQuad != null)
		{
			if (middleQuad.GetProgress() > topQuad.GetProgress())
			{
				if (lastMiddleWaitTime != -1f && Time.time - lastMiddleWaitTime > 0.3f)
				{
					lastMiddleWaitTime = -1f;
				}
				if (lastMiddleWaitTime == -1f)
				{
					middleQuad.SetProgress(middleQuad.GetProgress() - 0.03f);
				}
			}
			else
			{
				middleQuad.SetProgress(topQuad.GetProgress());
			}
		}
		DrawBuffer();
		CleanUpBuffer();
	}

	public override void Clear()
	{
		bottomQuad = null;
		middleQuad = null;
		topQuad = null;
		base.Clear();
	}

	public override void Destroy()
	{
		bottomQuad = null;
		middleQuad = null;
		topQuad = null;
		base.Destroy();
	}
}
