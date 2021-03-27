using Gear;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 文本控件，支持超链接、图片
/// </summary>
[AddComponentMenu("UI/LinkImageText", 10)]
public class LinkImageText : Text, IPointerClickHandler, ICanvasRaycastFilter
{
	/// <summary>
	/// 图像信息类。
	/// </summary>
	private class ImageInfo
	{
		public int startIdx;

		public int endIdx;
	}

	/// <summary>
	/// 超链接信息类
	/// </summary>
	private class HrefInfo
	{
		public int startIndex;

		public int endIndex;

		public Color32 color;

		public string param;

		public string name;

		public readonly List<Rect> boxes = new List<Rect>();
	}


	/// <summary>
	/// 解析完最终的文本
	/// </summary>
	private string m_OutputText;

	/// <summary>
	/// 图片池
	/// </summary>
	protected readonly List<FaceAnimateSprite> m_ImagesPool = new List<FaceAnimateSprite>();

	/// <summary>
	/// 图片的最后一个顶点的索引
	/// </summary>
	private readonly List<ImageInfo> m_ImagesVertexIndex = new List<ImageInfo>();

	/// <summary>
	/// 超链接信息列表
	/// </summary>
	private readonly List<HrefInfo> m_HrefInfos = new List<HrefInfo>();

	/// <summary>
	/// 文本构造器
	/// </summary>
	protected static readonly StringBuilder s_TextBuilder = new StringBuilder();

	[Serializable]
	public class HrefClickEvent : UnityEvent<string> { }

	[SerializeField]
	private HrefClickEvent m_OnHrefClick = new HrefClickEvent();

	/// <summary>
	/// 超链接点击事件
	/// </summary>
	public HrefClickEvent OnHrefClick
	{
		get { return m_OnHrefClick; }
		set { m_OnHrefClick = value; }
	}

	/// <summary>
	/// 正则取出所需要的属性
	/// </summary>
	private static readonly Regex s_ImageRegex =
		new Regex(@"<quad name=(.+?) size=(\d*) width=(\d*) height=(\d*) ofx=(-?\d*) ofy=(-?\d*) type=(.+?) />", RegexOptions.Singleline);

	/// <summary>
	/// 超链接正则
	/// </summary>
	private static readonly Regex s_HrefRegex =
		new Regex(@"<href param=(.*?)>(.*?)</href>", RegexOptions.Singleline);

	/// <summary>
	/// 颜色匹配正则表达式。
	/// </summary>
	private static Regex ColorRegex =
		new Regex(@"<color=(.*?)>(.*?)</color>", RegexOptions.Singleline);

	/// <summary>
	/// 全角的空格在排版时不会被打断换行。
	/// </summary>
	public static string NoBreakingSpace = "\u00A0";

	/// <summary>
	/// 下划线占位符，用于计算下划线的纹理坐标。
	/// </summary>
	private static string UnderLineChar = "<size=4>█</size>";

	/// <summary>
	/// 下划线高度。
	/// </summary>
	private float m_UnderLineHeight = 2;


	/// <summary>
	/// 创建图像控件。
	/// </summary>
	/// <returns></returns>
	public FaceAnimateSprite CreateImage()
	{
		GameObject go = new GameObject();
		FaceAnimateSprite fas = go.AddComponent<FaceAnimateSprite>();
		RectTransform rt = go.transform as RectTransform;
		go.layer = gameObject.layer;
		rt.SetParent(rectTransform);
		rt.localPosition = Vector3.zero;
		rt.localRotation = Quaternion.identity;
		rt.localScale = Vector3.one;
		return fas;
	}


	public override string text
	{
		get
		{
			return m_Text;
		}
		set
		{
			if (String.IsNullOrEmpty(value))
			{
				if (String.IsNullOrEmpty(m_Text))
					return;
				m_Text = "";
				SetVerticesDirty();
			}
			else if (m_Text != value)
			{
				m_Text = GetOutputText(value); // 获取超链接解析后的最后输出文本

				SetVerticesDirty();
				SetLayoutDirty();
			}
		}
	}


	public override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		UpdateQuadImage();
	}


	protected void UpdateQuadImage()
	{
#if UNITY_EDITOR
		//非运行时的编辑器状态不生成
		if (!Application.isPlaying)
		{
			return;
		}
#endif

		m_ImagesVertexIndex.Clear();
		m_ImagesPool.RemoveAll(image => image == null);

		foreach (Match match in s_ImageRegex.Matches(text))
		{
			ImageInfo imgInfo = new ImageInfo();
			imgInfo.startIdx = match.Index * 4;
			imgInfo.endIdx = match.Index * 4 + 3;

			m_ImagesVertexIndex.Add(imgInfo);

			if (m_ImagesPool.Count == 0)
			{
				GetComponentsInChildren<FaceAnimateSprite>(m_ImagesPool);
			}

			if (m_ImagesVertexIndex.Count > m_ImagesPool.Count)
			{
				m_ImagesPool.Add(CreateImage());
			}

			string spriteName = match.Groups[1].Value;
			int size = int.Parse(match.Groups[2].Value);
			int width = int.Parse(match.Groups[3].Value);
			int height = int.Parse(match.Groups[4].Value);
			int offsetX = int.Parse(match.Groups[5].Value);
			int offsetY = int.Parse(match.Groups[6].Value);
			string type = match.Groups[7].Value;

			FaceAnimateSprite img = m_ImagesPool[m_ImagesVertexIndex.Count - 1];
			if (string.IsNullOrEmpty(img.faceName) || img.faceName != spriteName)
			{
				AtlasInfo ai;
				if (!string.IsNullOrEmpty(type) && type.Equals("texture"))
				{
					ai = AtlasManager.GetInstance().LoadTextureWithAtlasInfo(spriteName);

				}
				else
				{
					ai = AtlasManager.GetInstance().LoadAtlas(spriteName);
				}
				if (ai != null)
				{
					AnimateFrameData fd = GResManager.GetInstance().LoadScriptableObject(AnimateFrameData.SCRIPTABLE_PATH) as AnimateFrameData;
					if (ai != null && fd != null)
					{
						img.atlasInfo = ai;
						img.frameData = fd;
						img.faceName = spriteName;
						img.offsetX = offsetX;
						img.offsetY = offsetY;
						img.Play();
					}
				}

				//else
				//{
				//	Sprite s = AtlasSpriteManager.Instance.GetSprite(spriteName);
				//	if (s != null)
				//	{
				//		if (img.color.Equals(Color.clear))
				//		{
				//			img.color = Color.white;
				//		}
				//		img.texture = s.texture;
				//	}
				//}

			}
			img.rectTransform.sizeDelta = new Vector2(width, height);
			img.enabled = true;
		}

		for (var i = m_ImagesVertexIndex.Count; i < m_ImagesPool.Count; i++)
		{
			if (m_ImagesPool[i])
			{
				m_ImagesPool[i].enabled = false;
			}
		}
	}


	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);

		m_DisableFontTextureRebuiltCallback = true;

		RefreshImage(toFill);

		List<UIVertex> verts = new List<UIVertex>();
		toFill.GetUIVertexStream(verts);

		Vector2 lineuv = GetUnderLineUV(verts);
		RefreshHrefBoxes(verts, lineuv);

		toFill.Clear();
		toFill.AddUIVertexTriangleStream(verts);

		m_DisableFontTextureRebuiltCallback = false;
	}


	/// <summary>
	/// 刷新图像。
	/// </summary>
	/// <param name="verts"></param>
	private void RefreshImage(VertexHelper toFill)
	{
		UIVertex vert = new UIVertex();
		for (var i = 0; i < m_ImagesVertexIndex.Count; i++)
		{
			var imgInfo = m_ImagesVertexIndex[i];
			int start = imgInfo.startIdx;
			int endIndex = imgInfo.endIdx;

			var img = m_ImagesPool[i];
			var rt = img.rectTransform;
			var size = rt.sizeDelta;

			if (endIndex < toFill.currentVertCount)
			{
				toFill.PopulateUIVertex(ref vert, endIndex);
				rt.anchoredPosition = new Vector2(vert.position.x + size.x / 2 + img.offsetX, vert.position.y + size.y / 2 - 2 + img.offsetY);

				// 抹掉左下角的小黑点
				for (int j = start; j <= endIndex; j++)
				{
					toFill.PopulateUIVertex(ref vert, j);
					vert.color = new Color32(0, 0, 0, 0);
					toFill.SetUIVertex(vert, j);
				}
			}
		}

		//if (m_ImagesVertexIndex.Count != 0)
		//{
		//	m_ImagesVertexIndex.Clear();
		//}
	}


	/// <summary>
	/// 获取下划线纹理坐标。
	/// </summary>
	/// <param name="vertices">顶点数组。</param>
	/// <returns>下划线纹理坐标。(占位字符中点的uv)</returns>
	private Vector2 GetUnderLineUV(List<UIVertex> vertices)
	{
		Vector2 lineuv = Vector2.zero;
		int n = UnderLineChar.Length * 6;
		if (vertices.Count >= n)
		{
			int start = 8 * 6;      //<size=2>的长度
			for (int i = 0; i < 6; ++i)
			{
				lineuv += vertices[start + i].uv0;
			}
			lineuv /= 6;

			//隐藏额外的下划线占位字符
			UIVertex uiv = vertices[0];
			uiv.color = new Color32(0, 0, 0, 0);
			for (int i = 0; i < n; ++i)
			{
				vertices[i] = uiv;
			}
		}
		return lineuv;
	}


	/// <summary>
	/// 刷新超链接点击盒子。
	/// </summary>
	/// <param name="verts">顶点数组。</param>
	private void RefreshHrefBoxes(List<UIVertex> verts, Vector2 lineuv)
	{
		Vector3[] linev = new Vector3[6];
		for (int i = 0; i < m_HrefInfos.Count; ++i)
		{
			HrefInfo info = m_HrefInfos[i];
			int start = info.startIndex * 6;
			int end = Math.Min(info.endIndex * 6, verts.Count);
			if (start >= verts.Count)
				break;

			UIVertex startuiv = verts[start];
			Bounds bounds = new Bounds(startuiv.position, Vector3.zero);
			info.boxes.Clear();

			for (int j = start + 1; j < end; ++j)
			{
				Vector3 pos = verts[j].position;
				if (j % 6 == 0 && pos.y < bounds.min.y) // 换行重新添加包围框，每个字符6个点
				{
					info.boxes.Add(new Rect(bounds.min, bounds.size));
					bounds = new Bounds(pos, Vector3.zero);
				}
				else
				{
					bounds.Encapsulate(pos); // 扩展包围框
				}
			}
			info.boxes.Add(new Rect(bounds.min, bounds.size));

			//在末尾添加下划线顶点，下划线颜色等于线条第一个字符的颜色
			for (int j = 0; j < info.boxes.Count; ++j)
			{
				Rect r = info.boxes[j];
				float xl = r.min.x;
				float xr = r.max.x;
				float yt = r.min.y;
				float yb = yt - m_UnderLineHeight;
				linev[0] = new Vector3(xl, yt);
				linev[1] = new Vector3(xr, yt);
				linev[2] = new Vector3(xr, yb);
				linev[3] = new Vector3(xr, yb);
				linev[4] = new Vector3(xl, yb);
				linev[5] = new Vector3(xl, yt);
				for (int k = 0; k < linev.Length; ++k)
				{
					UIVertex uiv = startuiv;
					uiv.uv0 = lineuv;
					uiv.color = info.color;
					uiv.position = linev[k];
					verts.Add(uiv);
				}
			}
		}
	}


	/// <summary>
	/// 获取超链接解析后的最后输出文本
	/// </summary>
	/// <returns></returns>
	protected virtual string GetOutputText(string outputText)
	{
		int indexText = 0;
		s_TextBuilder.Length = 0;
		m_HrefInfos.Clear();

		s_TextBuilder.Append(UnderLineChar);

		foreach (Match match in s_HrefRegex.Matches(outputText))
		{
			s_TextBuilder.Append(outputText.Substring(indexText, match.Index - indexText));

			string innertext = match.Groups[2].Value;

			HrefInfo hrefInfo = new HrefInfo
			{
				startIndex = s_TextBuilder.Length, // 超链接里的文本起始顶点索引
				endIndex = s_TextBuilder.Length + innertext.Length,
				param = match.Groups[1].Value,
				name = innertext,
				color = this.color
			};

			foreach (Match colorMatch in ColorRegex.Matches(innertext))
			{
				String colorstr = colorMatch.Groups[1].Value.Trim();
				hrefInfo.color = LuaFramework.Util.HtmlStringToColor(colorstr, this.color);
			}

			m_HrefInfos.Add(hrefInfo);

			s_TextBuilder.Append(innertext);

			indexText = match.Index + match.Length;
		}

		s_TextBuilder.Append(outputText.Substring(indexText, outputText.Length - indexText));

		return s_TextBuilder.ToString();
	}

	///////////////////////////////////////////////////////

	/// <summary>
	/// Calculate if the ray location for this image is a valid hit location. Takes into account a Alpha test threshold.
	/// </summary>
	/// <param name="screenPoint">The screen point to check against</param>
	/// <param name="eventCamera">The camera in which to use to calculate the coordinating position</param>
	/// <returns>If the location is a valid hit or not.</returns>
	/// <remarks> Also see See:ICanvasRaycastFilter.</remarks>
	public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		Vector2 lp;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, eventCamera, out lp))
			return false;

		foreach (var hrefInfo in m_HrefInfos)
		{
			var boxes = hrefInfo.boxes;
			for (var i = 0; i < boxes.Count; ++i)
			{
				if (boxes[i].Contains(lp))
				{
					return true;
				}
			}
		}

		return false;
	}

	/// <summary>
	/// 点击事件检测是否点击到超链接文本
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerClick(PointerEventData eventData)
	{
		Vector2 lp;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			rectTransform, eventData.position, eventData.pressEventCamera, out lp);

		foreach (var hrefInfo in m_HrefInfos)
		{
			var boxes = hrefInfo.boxes;
			for (var i = 0; i < boxes.Count; ++i)
			{
				if (boxes[i].Contains(lp))
				{
					m_OnHrefClick.Invoke(hrefInfo.param);
					return;
				}
			}
		}
	}

	///////////////////////////////////////////////////////
	public float GetPreferredWidth(string str)
	{
		if (String.IsNullOrEmpty(str))
		{
			str = text;
		}

		var settings = GetGenerationSettings(Vector2.zero);
		return cachedTextGeneratorForLayout.GetPreferredWidth(str, settings) / pixelsPerUnit;
	}

	public float GetPreferredHeight(string str, float width = 312.0f)
	{
		if (String.IsNullOrEmpty(str))
		{
			str = text;
		}

		var settings = GetGenerationSettings(new Vector2(width, 0.0f));
		return cachedTextGeneratorForLayout.GetPreferredHeight(str, settings) / pixelsPerUnit;
	}

}
