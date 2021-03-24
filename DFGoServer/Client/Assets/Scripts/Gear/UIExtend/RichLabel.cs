using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// 扩展标签。(标签从外到内包含顺序<href><color>，<image>独立)
/// 标签格式：
///     <href param=[点击参数]>[超链接显示内容]</href>
///     <image name=[图片名称]/>  PS:图片通过AtlasSpriteManager.Instance.GetSprite函数进行加载
/// </summary>
[RequireComponent(typeof(Text))]
[ExecuteInEditMode]
public class RichLabel : BaseMeshEffect, IPointerClickHandler
{
	#region 数据定义----------------------------------------------------------------

	Text txtCom = null;

	/// <summary>
	/// 范围信息类。
	/// </summary>
	private class RangeInfo
	{
		/// <summary>
		/// 起始索引(包含)。
		/// </summary>
		public int StartIndex { get; set; }

		/// <summary>
		/// 结束索引(不包含)。
		/// </summary>
		public int EndIndex { get; set; }
	}

	/// <summary>
	/// 颜色信息类。
	/// </summary>
	private class ColorInfo : RangeInfo
	{
		/// <summary>
		/// 文本颜色。
		/// </summary>
		public Color TextColor { get; set; }
	}

	/// <summary>
	/// 超链接信息类。
	/// </summary>
	private class HrefInfo : RangeInfo
	{
		/// <summary>
		/// 超链接参数。
		/// </summary>
		public string Param;

		/// <summary>
		/// 点击区域列表。
		/// </summary>
		public List<Rect> Boxes = new List<Rect>();
	}

	/// <summary>
	/// 图像信息类。
	/// </summary>
	private class ImageInfo : RangeInfo
	{
		/// <summary>
		/// 图片名称。
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 图片位置。
		/// </summary>
		public Vector2 Position { get; set; }

		/// <summary>
		/// 图片尺寸。
		/// </summary>
		public Vector2 Size { get; set; }

		/// <summary>
		/// 图片缩放。
		/// </summary>
		public float Scale { get; set; }
	}

	/// <summary>
	/// 超链接点击事件。
	/// </summary>
	[Serializable]
	public class HrefClickEvent : UnityEvent<string> { }

	#endregion
	#region 对外操作----------------------------------------------------------------

	public float GetPreferredWidth(string str)
	{
		var settings = txtCom.GetGenerationSettings(Vector2.zero);
		return txtCom.cachedTextGeneratorForLayout.GetPreferredWidth(str, settings) / txtCom.pixelsPerUnit;
	}

	public float GetPreferredHeight(string str, float width = 312.0f)
	{
		var settings = txtCom.GetGenerationSettings(new Vector2(width, 0.0f));
		return txtCom.cachedTextGeneratorForLayout.GetPreferredHeight(str, settings) / txtCom.pixelsPerUnit;
	}

	/// <summary>
	/// 修改网格。
	/// </summary>
	/// <param name="vh">顶点数据访问接口。</param>
	public override void ModifyMesh(VertexHelper vh)
	{
		if (!IsActive())
		{
			return;
		}

		//ModifyImageMesh(vh);                      //隐藏图片的占位符

		List<UIVertex> vertices = new List<UIVertex>();
		vh.GetUIVertexStream(vertices);

		

		Vector2 lineuv = GetUnderLineUV(vertices);      //计算下划线纹理坐标
		GetTextSize(vertices);
		ModifyColorMesh(vertices);                      //颜色调整
		ModifyHrefMesh(vertices, lineuv);               //超链接下划线颜色依赖字符颜色，需要在颜色调整之后
		ModifyImageMesh(vertices);                      //隐藏图片的占位符
		

		vh.Clear();
		vh.AddUIVertexTriangleStream(vertices);
	}

	/// <summary>
	/// 点击事件检测是否点击到超链接文本
	/// </summary>
	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		Vector2 lp;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(graphic.rectTransform, eventData.position, eventData.pressEventCamera, out lp);
		foreach (var hrefInfo in m_HrefInfos)
		{
			var boxes = hrefInfo.Boxes;
			for (var i = 0; i < boxes.Count; ++i)
			{
				if (boxes[i].Contains(lp))
				{
					OnHrefClick.Invoke(hrefInfo.Param);
					return;
				}
			}
		}
		OnHrefClick.Invoke(string.Empty);           //通知点击了文本
	}

	/// <summary>
	/// 重新生成文本。
	/// </summary>
	public void Rebuild()
	{
		HideAllImage();
		txtCom.text = ParseText();
	}

	#endregion

	#region 对外属性----------------------------------------------------------------

	/// <summary>
	/// 获取或设置文本。
	/// </summary>
	public string text
	{
		get { return m_Text; }
		set
		{
			if (m_Text.CompareTo(value) != 0)
			{
				m_Text = value;
				HideAllImage();
				txtCom.text = ParseText();
				this.graphic.Rebuild(CanvasUpdate.PreRender);
			}
		}
	}

	/// <summary>
	/// 获取超链接点击事件。
	/// </summary>
	public HrefClickEvent OnHrefClick
	{
		get { return m_HrefClickEvent; }
		set { m_HrefClickEvent = value; }
	}

	/// <summary>
	/// 获取图片挂接点。
	/// </summary>
	public RectTransform ImageHolder
	{
		get { return m_ImageHolder; }
	}

	/// <summary>
	/// 获取文本显示宽度。
	/// </summary>
	public float TextWidth
	{
		get { return m_TextWidth; }
	}

	/// <summary>
	/// 获取文本显示高度。
	/// </summary>
	public float TextHeight
	{
		get { return m_TextHeight; }
	}
	/// <summary>
	/// 获取param（第一个） lua中调用
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public string GetParamStr(string text)
	{
		foreach (Match match in HrefRegex.Matches(text))
		{
			string param = match.Groups[1].Value.Trim();
			if (param != null && param != string.Empty)
			{
				return param;
			}
		}
		return string.Empty;
	}

	#endregion

	#region 内部操作----------------------------------------------------------------

	/// <summary>
	/// 唤醒。
	/// </summary>
	protected override void Awake()
	{
		base.Awake();
		m_ImageHolder = GetComponent<RectTransform>();
		txtCom = GetComponent<Text>();
		LuaFramework.Util.ClearChildImmediate(m_ImageHolder);
		m_Images.Clear();
		//Rebuild();
	}

	/// <summary>
	/// 解析文本。
	/// </summary>
	/// <returns>解析后显示的文本内容。</returns>
	private string ParseText()
	{
		//解析顺序不能改变，后边的解析在改变最终字符串内容时，会对前面解析出来的索引范围进行修正
		string temp = ParseColor(m_Text);
		temp = ParseHref(temp);
		temp = ParseImage(temp);
		//temp = temp.Replace(" ", NoBreakingSpace);
		return temp;
	}

	/// <summary>
	/// 全角的空格在排版时不会被打断换行。
	/// </summary>
	public static string NoBreakingSpace = "\u00A0";

	/// <summary>
	/// 解析颜色值。
	/// </summary>
	/// <returns>解析后的字符串。</returns>
	public string ParseColor(string text)
	{
		Color def = GetComponent<Text>().color;
		int index = 0;
		m_ColorInfos.Clear();
		CacheSB.Length = 0;
		CacheSB.Append(UnderLineChar);      //首个解析函数要加下划线占位符
		foreach (Match match in ColorRegex.Matches(text))
		{
			string colorstr = match.Groups[1].Value.Trim();
			string innertext = match.Groups[2].Value;
			ColorInfo info = new ColorInfo();
			CacheSB.Append(text.Substring(index, match.Index - index));       //匹配目标前的那一部分
			info.StartIndex = CacheSB.Length;
			info.EndIndex = info.StartIndex + innertext.Length;
			info.TextColor = LuaFramework.Util.HtmlStringToColor(colorstr, def);
			m_ColorInfos.Add(info);
			CacheSB.Append(innertext);
			index = match.Index + match.Length;
		}
		CacheSB.Append(text.Substring(index, text.Length - index));
		return CacheSB.ToString();
	}

	/// <summary>
	/// 解析超链接值。
	/// </summary>
	/// <returns>解析后的字符串。</returns>
	public string ParseHref(string text)
	{
		int index = 0;
		m_HrefInfos.Clear();
		CacheSB.Length = 0;
		foreach (Match match in HrefRegex.Matches(text))
		{
			string param = match.Groups[1].Value.Trim();
			string innertext = match.Groups[2].Value;
			int cut = match.Length - innertext.Length;          //匹配调整后缩短的长度
			HrefInfo info = new HrefInfo();
			CacheSB.Append(text.Substring(index, match.Index - index));       //匹配目标前的那一部分
			info.StartIndex = CacheSB.Length;
			info.EndIndex = info.StartIndex + innertext.Length;
			info.Param = param;
			m_HrefInfos.Add(info);
			CacheSB.Append(innertext);
			index = match.Index + match.Length;
			AdujstIndex(m_ColorInfos, info.StartIndex, info.StartIndex + match.Length, cut, 7);       //7为"</href>"标签的长度
		}
		CacheSB.Append(text.Substring(index, text.Length - index));
		return CacheSB.ToString();
	}

	/// <summary>
	/// 解析图像值。
	/// </summary>
	/// <returns>解析后的字符串。</returns>
	public string ParseImage(string text)
	{
		m_ImageInfos.Clear();
		m_Images.RemoveAll(image => image == null);

		foreach (Match match in ImageRegex.Matches(text))
		{
			ImageInfo imgInfo = new ImageInfo();
			imgInfo.StartIndex = match.Index;
			imgInfo.EndIndex = match.Index + 1;

			m_ImageInfos.Add(imgInfo);

			if (m_Images.Count == 0)
			{
				GetComponentsInChildren<Image>(m_Images);
			}

			if (m_ImageInfos.Count > m_Images.Count)
			{
				m_Images.Add(CreateImage());
			}

			string spriteName = match.Groups[1].Value;
			int size = int.Parse(match.Groups[2].Value);
			int width = int.Parse(match.Groups[3].Value);
			int height = int.Parse(match.Groups[4].Value);
			Image img = m_Images[m_ImageInfos.Count - 1];
			if (img.sprite == null || img.sprite.name != spriteName)
			{
				img.sprite = AtlasSpriteManager.Instance.GetSprite(spriteName);
				img.name = spriteName;
			}
			img.rectTransform.sizeDelta = new Vector2(width, height);
			img.enabled = true;
		}

		for (var i = m_ImageInfos.Count; i < m_Images.Count; i++)
		{
			if (m_Images[i])
			{
				m_Images[i].enabled = false;
			}
		}

		return text;
	}

	/// <summary>
	/// 调整索引。
	/// </summary>
	/// <param name="infos">索引信息列表。</param>
	/// <param name="start">调整区域的原起始索引。（包含）</param>
	/// <param name="end">调整区域的原结束索引。（不包含）</param>
	/// <param name="cut">区域被减少的长度。</param>
	/// <param name="endcut">区域被减少的右侧长度。（当颜色区间在调整区间内时，起始索引要排除此长度）</param>
	private static void AdujstIndex<T>(List<T> infos, int start, int end, int cut, int endcut) where T : RangeInfo
	{
		//索引区间不会和传入的索引区间交叠，只有不相交或被包含两种关系
		for (int i = infos.Count - 1; i >= 0; --i)
		{
			RangeInfo info = infos[i];
			if (info.StartIndex >= end)
			{
				//颜色区间在调整区间右侧，减去cut
				info.StartIndex -= cut;
				info.EndIndex -= cut;
			}
			else if (info.StartIndex >= start)
			{
				//颜色区间在调整区间内，少减endcut
				int tcut = cut - endcut;
				info.StartIndex -= tcut;
				info.EndIndex -= tcut;
			}
			else
			{
				break;
			}
		}
	}

	/// <summary>
	/// 调整索引。
	/// </summary>
	/// <param name="infos">索引信息列表。</param>
	/// <param name="offset">要调整的索引值。</param>
	private static void AdujstIndex<T>(List<T> infos, int offset) where T : RangeInfo
	{
		for (int i = 0; i < infos.Count; ++i)
		{
			RangeInfo info = infos[i];
			info.StartIndex += offset;
			info.EndIndex += offset;
		}
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
	/// 获取文本尺寸。
	/// </summary>
	/// <param name="vertices">顶点数组。</param>
	private void GetTextSize(List<UIVertex> vertices)
	{
		float fs = GetComponent<Text>().fontSize;
		if (vertices.Count <= 0)
		{
			m_TextWidth = fs;
			m_TextHeight = fs;
			return;
		}

		//查找最高和最低点  
		float minx = vertices[0].position.x;
		float maxx = vertices[0].position.x;
		float miny = vertices[0].position.y;
		float maxy = vertices[0].position.y;
		for (int i = 1; i < vertices.Count; ++i)
		{
			Vector3 pos = vertices[i].position;
			Vector2 uv = vertices[i].uv0;
			if (vertices[i].color.a > 0 && Math.Abs(uv.x) + Math.Abs(uv.y) > 0)        //只统计可视字符
			{
				minx = Math.Min(minx, pos.x);
				maxx = Math.Max(maxx, pos.x);
				miny = Math.Min(miny, pos.y);
				maxy = Math.Max(maxy, pos.y);
			}
		}

		m_TextWidth = Math.Max(fs, maxx - minx + 2);
		m_TextHeight = Math.Max(fs, maxy - miny + 2);
	}

	/// <summary>
	/// 调整颜色。
	/// </summary>
	/// <param name="vertices">顶点数组。</param>
	private void ModifyColorMesh(List<UIVertex> vertices)
	{
		for (int i = 0; i < m_ColorInfos.Count; ++i)
		{
			ColorInfo info = m_ColorInfos[i];
			int start = info.StartIndex * 6;
			int end = Math.Min(info.EndIndex * 6, vertices.Count);
			for (int j = start; j < end; ++j)
			{
				UIVertex uiv = vertices[j];
				uiv.color = info.TextColor;
				vertices[j] = uiv;
			}
		}
	}

	/// <summary>
	/// 调整下划线。
	/// </summary>
	/// <param name="vertices">顶点数组。</param>
	/// <param name="lineuv">下划线的纹理坐标。</param>
	private void ModifyHrefMesh(List<UIVertex> vertices, Vector2 lineuv)
	{
		Vector3[] linev = new Vector3[6];
		for (int i = 0; i < m_HrefInfos.Count; ++i)
		{
			HrefInfo info = m_HrefInfos[i];
			int start = info.StartIndex * 6;
			int end = Math.Min(info.EndIndex * 6, vertices.Count);
			if (start >= vertices.Count)
				break;
			UIVertex startuiv = vertices[start];
			Bounds bounds = new Bounds(startuiv.position, Vector3.zero);
			info.Boxes.Clear();
			for (int j = start + 1; j < end; ++j)
			{
				Vector3 pos = vertices[j].position;
				if (j % 6 == 0 && pos.y < bounds.min.y) // 换行重新添加包围框，每个字符6个点
				{
					info.Boxes.Add(new Rect(bounds.min, bounds.size));
					bounds = new Bounds(pos, Vector3.zero);
				}
				else
				{
					bounds.Encapsulate(pos); // 扩展包围框
				}
			}
			info.Boxes.Add(new Rect(bounds.min, bounds.size));

			//在末尾添加下划线顶点，下划线颜色等于线条第一个字符的颜色
			for (int j = 0; j < info.Boxes.Count; ++j)
			{
				Rect r = info.Boxes[j];
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
					uiv.position = linev[k];
					vertices.Add(uiv);
				}
			}
		}
	}

	/// <summary>
	/// 调整图像。
	/// </summary>
	/// <param name="vertices">顶点数组。</param>
	private void ModifyImageMesh(List<UIVertex> vertices)
	{
		//UIVertex vert = new UIVertex();
		//for (var i = 0; i < m_ImageInfos.Count; i++)
		//{
		//	var imgInfo = m_ImageInfos[i];
		//	int start = imgInfo.StartIndex;
		//	int endIndex = imgInfo.EndIndex;

		//	var rt = m_Images[i].rectTransform;
		//	var size = rt.sizeDelta;

		//	if (endIndex < toFill.currentVertCount)
		//	{
		//		toFill.PopulateUIVertex(ref vert, endIndex);
		//		rt.anchoredPosition = new Vector2(vert.position.x + size.x / 2, vert.position.y + size.y / 2);

		//		// 抹掉左下角的小黑点
		//		for (int j = endIndex, m = endIndex - 3; j > m; j--)
		//		{
		//			toFill.PopulateUIVertex(ref vert, j);
		//			vert.color = new Color32(0, 0, 0, 0);
		//		}
		//	}
		//}

		//if (m_ImageInfos.Count != 0)
		//{
		//	m_ImageInfos.Clear();
		//}

		for (int i = 0; i < m_ImageInfos.Count; ++i)
		{
			ImageInfo info = m_ImageInfos[i];
			int start = info.StartIndex * 6;
			int end = Math.Min(info.EndIndex * 6, vertices.Count);
			Vector3 startpos = vertices[start].position;
			Vector3 mpos = Vector3.zero;
			//float iw = 0;
			//float ih = 0;
			for (int j = start; j < end; ++j)
			{
				UIVertex uiv = vertices[j];
				Vector3 pos = uiv.position;
				uiv.color = new Color32(0, 0, 0, 0);
				vertices[j] = uiv;
				mpos += pos;
				//iw = Math.Max(iw, pos.x - startpos.x);
				//ih = Math.Max(ih, startpos.y - pos.y);
			}
			int n = end - start;
			info.Position = new Vector2(mpos.x / n, mpos.y / n);
			//info.Size = new Vector2(iw, ih);

			//m_Images[i].rectTransform.anchoredPosition = m_ImageInfos[i].Position;
			Image img = m_Images[i];
			img.rectTransform.anchoredPosition = info.Position;
		}

		////非运行时的编辑器状态不生成
		//if (Application.isPlaying)
		//{
		//	CancelInvoke();
		//	Invoke("RefreshImage", 0);      //推迟到下一帧刷新图片显示，ModifyMesh函数内不能随便搞事
		//									//this.transform.localScale = Vector3.zero;           //先隐藏
		//}
	}

	/// <summary>
	/// 刷新图像。
	/// </summary>
	private void RefreshImage()
	{
		//补足不够的
		//while (m_Images.Count < m_ImageInfos.Count)
		//{
		//	Image img = CreateImage();
		//	m_Images.Add(img);
		//}

		//更新位置和图图像
		for (int i = 0; i < m_ImageInfos.Count; ++i)
		{
			//ImageInfo info = m_ImageInfos[i];
			m_Images[i].rectTransform.anchoredPosition = m_ImageInfos[i].Position;
			//Image img = m_Images[i].rectTransform.anchoredPosition = info.Position;
			//RectTransform rt = img.GetComponent<RectTransform>();
			//img.enabled = true;
			//rt.anchoredPosition = info.Position;
			//rt.sizeDelta = info.Size * info.Scale;
			//if (info.Name.CompareTo(img.name) != 0)
			//{
			//	img.name = info.Name;
			//	img.sprite = AtlasSpriteManager.Instance.GetSprite(info.Name);
			//	//img.SetNativeSize();
			//}
			//rt.localScale = Vector3.one * info.Scale;
		}

		//隐藏多余的
		//for (int i = m_ImageInfos.Count; i < m_Images.Count; ++i)
		//{
		//	m_Images[i].gameObject.SetActive(false);
		//}
		//this.transform.localScale = Vector3.one;
	}

	/// <summary>
	/// 创建图像控件。
	/// </summary>
	/// <returns></returns>
	private Image CreateImage()
	{
		float fs = GetComponent<Text>().fontSize;
		GameObject go = DefaultControls.CreateImage(new DefaultControls.Resources());
		RectTransform rt = go.transform as RectTransform;
		Image img = go.GetComponent<Image>();
		go.layer = gameObject.layer;
		rt.SetParent(m_ImageHolder);
		rt.localPosition = Vector3.zero;
		rt.localRotation = Quaternion.Euler(0, 0, 0);
		rt.localScale = Vector3.one;
		rt.anchoredPosition3D = Vector3.zero;
		rt.sizeDelta = new Vector2(fs, fs);
		rt.anchorMin = m_ImageHolder.pivot;
		rt.anchorMax = rt.anchorMin;
		img.preserveAspect = true;
		return img;
	}

	/// <summary>
	/// 隐藏所有图像
	/// </summary>
	private void HideAllImage()
	{
		for (int i = 0; i < m_Images.Count; ++i)
		{
			//m_Images[i].gameObject.SetActive(false);
		}
	}

	#endregion

	#region 内部数据----------------------------------------------------------------

	/// <summary>
	/// 下划线占位符，用于计算下划线的纹理坐标。
	/// </summary>
    private static string UnderLineChar = "<size=4>█</size>";

	/// <summary>
	/// 颜色匹配正则表达式。
	/// </summary>
	private static Regex ColorRegex = new Regex(@"<color=(.*?)>(.*?)</color>", RegexOptions.Singleline);

	/// <summary>
	/// 超链接匹配正则表达式。
	/// </summary>
	private static readonly Regex HrefRegex = new Regex(@"<href param=(.*?)>(.*?)</href>", RegexOptions.Singleline);

	/// <summary>
	/// 图像匹配正则表达式
	/// </summary>
	private static readonly Regex ImageRegex =
		//new Regex(@"<image name=(.+?)/>", RegexOptions.Singleline);
		new Regex(@"<quad name=(.+?) size=(\d*) width=(\d*) height=(\d*) />", RegexOptions.Singleline);

	/// <summary>
	/// 缓存。
	/// </summary>
	private static StringBuilder CacheSB = new StringBuilder();

	/// <summary>
	/// 原始文本。
	/// </summary>
	[TextArea(3, 10)]
	[SerializeField]
	private string m_Text = string.Empty;

	/// <summary>
	/// 颜色信息。
	/// </summary>
	private List<ColorInfo> m_ColorInfos = new List<ColorInfo>();

	/// <summary>
	/// 超链接信息。
	/// </summary>
	private List<HrefInfo> m_HrefInfos = new List<HrefInfo>();

	/// <summary>
	/// 超链接点击事件对象。
	/// </summary>
	[SerializeField]
	private HrefClickEvent m_HrefClickEvent = new HrefClickEvent();

	/// <summary>
	/// 下划线高度。
	/// </summary>
	[SerializeField]
	private float m_UnderLineHeight = 1;

	/// <summary>
	/// 图片挂接点。
	/// </summary>
	private RectTransform m_ImageHolder;

	/// <summary>
	/// 图像列表。
	/// </summary>
	private List<Image> m_Images = new List<Image>();

	/// <summary>
	/// 图像信息。
	/// </summary>
	private List<ImageInfo> m_ImageInfos = new List<ImageInfo>();

	/// <summary>
	/// 显示文本宽度。
	/// </summary>
	private float m_TextWidth;

	/// <summary>
	/// 显示文本高度。
	/// </summary>
	private float m_TextHeight;

	#endregion
}