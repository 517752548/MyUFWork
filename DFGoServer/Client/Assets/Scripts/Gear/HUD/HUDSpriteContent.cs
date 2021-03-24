using UnityEngine;

public class HUDSpriteContent : HUDBaseContent
{
	private Vector3 _syncPosition;

	public HUDSpriteContent()
	{
		AllocateBuffer(4);
	}

	public void SetSyncPosition(Vector3 pos)
	{
		_syncPosition = pos;
	}

	public void SetSprite(string spriteName)
	{
		Append(spriteName);
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
		DrawBuffer();
		CleanUpBuffer();
	}
}
