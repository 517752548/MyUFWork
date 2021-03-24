using UnityEngine;
using System.Collections;
using Gear;
namespace Gear
{
	public class FaceAnimateSprite : AnimateSprite
	{
		public string faceName = "";
		public AnimateFrameData frameData;
		public int offsetX = 0;
		public int offsetY = 0;

		private void Update()
		{
			if (!isPlaying)
			{
				return;
			}
			if (_atlasInfo == null)
			{
				return;
			}
			if (frameData == null)
			{
				return;
			}
			_currDelta += Time.deltaTime;

			Sprite s = _atlasInfo.GetSprites()[_currFrame];
			if (s == null)
			{
				return;
			}
			AnimateFrameInfo info = frameData.GetFrameInfoByName(s.name);
			if (info == null)
			{
				return;
			}
			if (_currDelta > info.duration)
			{
				_currDelta = 0f;
				PlayNextFrame();
			}
		}

		protected override void OnDestroy()
		{
			frameData = null;
			base.OnDestroy();
		}
	}
}