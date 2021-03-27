using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.Serialization;
namespace Gear
{
	[AddComponentMenu("UI/Animate Sprite", 200)]
	public class AnimateSprite : RawImage
	{
		public bool autoSize = true;
		protected Rect _uvRect = new Rect();
		protected AtlasInfo _atlasInfo;
		public AtlasInfo atlasInfo
		{
			get
			{
				return _atlasInfo;
			}

			set
			{
				_atlasInfo = value;
				if (value != null)
				{
					texture = _atlasInfo.texture;
				}
			}
		}

		protected int _frameRate = -1;
		public int frameRate
		{
			get
			{
				return _frameRate;
			}

			set
			{
				_frameRate = value;
			}
		}
		protected int _currFrame = 0;
		protected float _currDelta = 0f;
		protected bool _isPlaying = false;
		public bool isPlaying
		{
			get
			{
				return _isPlaying;
			}
		}

		protected bool _loop = true;
		public bool loop
		{
			get
			{
				return _loop;
			}
			set
			{
				_loop = value;
			}
		}
		protected float _interval = 0f;
		public float interval
		{
			get
			{
				return _interval;
			}

			set
			{
				_interval = value;
			}
		}
		protected bool _isIntervalTiming = false;
		protected float _currIntervalTime = 0f;
		protected override void Awake()
		{
			base.Awake();
			raycastTarget = false;
			color = Color.clear;
		}

		public void Play()
		{
			if (_atlasInfo == null)
			{
				return;
			}
			if (_atlasInfo.GetSpriteNum() == 0)
			{
				return;
			}
			if (color.Equals(Color.clear))
			{
				color = Color.white;
			}
			if (frameRate == -1)
			{
				frameRate = _atlasInfo.GetSpriteNum();
			}
			if (autoSize)
			{
				//根据第一个sprite的宽高来设置RectTransform的宽高
				Sprite firstSprite = _atlasInfo.GetSprites()[0];
				RectTransform rectTSF = rectTransform;
				rectTransform.sizeDelta = new Vector2(firstSprite.rect.width, firstSprite.rect.height);
			}
			_isPlaying = true;
			_isIntervalTiming = false;
			_currIntervalTime = 0f;
			_currFrame = 0;
			UpdateUVRect();
		}

		public void Stop()
		{
			_isPlaying = false;
			ClearUV();
		}

		public void PlayFrame(int frame)
		{
			_isPlaying = false;
			_currFrame = frame;
			UpdateUVRect();
		}

		public void PlayNextFrame()
		{
			if (_atlasInfo == null)
			{
				return;
			}
			_currFrame++;
			UpdateUVRect();
			if (_currFrame >= _atlasInfo.GetSpriteNum())
			{
				if (_loop)
				{
					_currFrame = 0;
					if (_interval > 0f)
					{
						ClearUV();
						_isIntervalTiming = true;
					}
				}
				else
				{
					Stop();
				}
			}
		}

		public void ClearUV()
		{
			_uvRect.x = 0f;
			_uvRect.y = 0f;
			_uvRect.width = 0f;
			_uvRect.height = 0f;
			uvRect = _uvRect;
		}

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
			if (_isIntervalTiming)
			{
				if (_currIntervalTime >= _interval)
				{
					_isIntervalTiming = false;
					_currIntervalTime = 0;
				}
				else
				{
					_currIntervalTime += Time.deltaTime;
					return;
				}
			}
			_currDelta += Time.deltaTime;
			if (_currDelta > (1f / _frameRate))
			{
				_currDelta = 0f;
				PlayNextFrame();
			}
		}

		private void UpdateUVRect()
		{
			if (_atlasInfo == null)
			{
				return;
			}
			if (_currFrame >= _atlasInfo.GetSpriteNum())
			{
				return;
			}
			if (_atlasInfo.GetSpriteNum() == 1)
			{
				_uvRect.x = 0;
				_uvRect.y = 0;
				_uvRect.width = 1;
				_uvRect.height = 1;
				uvRect = _uvRect;
				return;
			}
			Sprite s = _atlasInfo.GetSprites()[_currFrame];
			_uvRect.x = s.uv[2].x;
			_uvRect.y = s.uv[2].y;
			_uvRect.width = s.uv[3].x - s.uv[2].x;
			_uvRect.height = s.uv[0].y - s.uv[2].y;
			uvRect = _uvRect;
		}

		protected override void OnDestroy()
		{
			Stop();
			_atlasInfo = null;
			base.OnDestroy();
		}
	}
}