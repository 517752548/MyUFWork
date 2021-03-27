using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Gear;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
#endif
namespace UnityEngine.UI
{
	public class UGUIExternalMenuOptions
	{
		private const string kUILayerName = "UI";

		private const string kStandardSpritePath = "UI/Skin/UISprite.psd";
		private const string kBackgroundSpritePath = "UI/Skin/Background.psd";
		private const string kInputFieldBackgroundPath = "UI/Skin/InputFieldBackground.psd";
		private const string kKnobPath = "UI/Skin/Knob.psd";
		private const string kCheckmarkPath = "UI/Skin/Checkmark.psd";
		private const string kDropdownArrowPath = "UI/Skin/DropdownArrow.psd";
		private const string kMaskPath = "UI/Skin/UIMask.psd";

		static private DefaultControls.Resources s_StandardResources;

		static private DefaultControls.Resources GetStandardResources()
		{
			if (s_StandardResources.standard == null)
			{
				s_StandardResources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>(kStandardSpritePath);
				s_StandardResources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>(kBackgroundSpritePath);
				s_StandardResources.inputField = AssetDatabase.GetBuiltinExtraResource<Sprite>(kInputFieldBackgroundPath);
				s_StandardResources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite>(kKnobPath);
				s_StandardResources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite>(kCheckmarkPath);
				s_StandardResources.dropdown = AssetDatabase.GetBuiltinExtraResource<Sprite>(kDropdownArrowPath);
				s_StandardResources.mask = AssetDatabase.GetBuiltinExtraResource<Sprite>(kMaskPath);
			}
			return s_StandardResources;
		}

		private const float kWidth = 160f;
		private const float kThickHeight = 30f;
		private const float kThinHeight = 20f;
		private static Vector2 s_ThickElementSize = new Vector2(kWidth, kThickHeight);
		private static Vector2 s_ThinElementSize = new Vector2(kWidth, kThinHeight);
		private static Vector2 s_ImageElementSize = new Vector2(100f, 100f);
		private static Color s_DefaultSelectableColor = new Color(1f, 1f, 1f, 1f);
		private static Color s_PanelColor = new Color(1f, 1f, 1f, 0.392f);
		private static Color s_TextColor = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1f);
		private static void SetPositionVisibleinSceneView(RectTransform canvasRTransform, RectTransform itemTransform)
		{
			// Find the best scene view
			SceneView sceneView = SceneView.lastActiveSceneView;
			if (sceneView == null && SceneView.sceneViews.Count > 0)
				sceneView = SceneView.sceneViews[0] as SceneView;

			// Couldn't find a SceneView. Don't set position.
			if (sceneView == null || sceneView.camera == null)
				return;

			// Create world space Plane from canvas position.
			Vector2 localPlanePosition;
			Camera camera = sceneView.camera;
			Vector3 position = Vector3.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRTransform, new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2), camera, out localPlanePosition))
			{
				// Adjust for canvas pivot
				localPlanePosition.x = localPlanePosition.x + canvasRTransform.sizeDelta.x * canvasRTransform.pivot.x;
				localPlanePosition.y = localPlanePosition.y + canvasRTransform.sizeDelta.y * canvasRTransform.pivot.y;

				localPlanePosition.x = Mathf.Clamp(localPlanePosition.x, 0, canvasRTransform.sizeDelta.x);
				localPlanePosition.y = Mathf.Clamp(localPlanePosition.y, 0, canvasRTransform.sizeDelta.y);

				// Adjust for anchoring
				position.x = localPlanePosition.x - canvasRTransform.sizeDelta.x * itemTransform.anchorMin.x;
				position.y = localPlanePosition.y - canvasRTransform.sizeDelta.y * itemTransform.anchorMin.y;

				Vector3 minLocalPosition;
				minLocalPosition.x = canvasRTransform.sizeDelta.x * (0 - canvasRTransform.pivot.x) + itemTransform.sizeDelta.x * itemTransform.pivot.x;
				minLocalPosition.y = canvasRTransform.sizeDelta.y * (0 - canvasRTransform.pivot.y) + itemTransform.sizeDelta.y * itemTransform.pivot.y;

				Vector3 maxLocalPosition;
				maxLocalPosition.x = canvasRTransform.sizeDelta.x * (1 - canvasRTransform.pivot.x) - itemTransform.sizeDelta.x * itemTransform.pivot.x;
				maxLocalPosition.y = canvasRTransform.sizeDelta.y * (1 - canvasRTransform.pivot.y) - itemTransform.sizeDelta.y * itemTransform.pivot.y;

				position.x = Mathf.Clamp(position.x, minLocalPosition.x, maxLocalPosition.x);
				position.y = Mathf.Clamp(position.y, minLocalPosition.y, maxLocalPosition.y);
			}

			itemTransform.anchoredPosition = position;
			itemTransform.localRotation = Quaternion.identity;
			itemTransform.localScale = Vector3.one;
		}
		private static void PlaceUIElementRoot(GameObject element, MenuCommand menuCommand)
		{
			GameObject parent = menuCommand.context as GameObject;
			if (parent == null || parent.GetComponentInParent<Canvas>() == null)
			{
				parent = GetOrCreateCanvasGameObject();
			}

			string uniqueName = GameObjectUtility.GetUniqueNameForSibling(parent.transform, element.name);
			element.name = uniqueName;
			Undo.RegisterCreatedObjectUndo(element, "Create " + element.name);
			Undo.SetTransformParent(element.transform, parent.transform, "Parent " + element.name);
			GameObjectUtility.SetParentAndAlign(element, parent);
			if (parent != menuCommand.context) // not a context click, so center in sceneview
				SetPositionVisibleinSceneView(parent.GetComponent<RectTransform>(), element.GetComponent<RectTransform>());

			Selection.activeGameObject = element;
		}
		private static GameObject CreateUIElementRoot(string name, Vector2 size)
		{
			GameObject child = new GameObject(name);
			RectTransform rectTransform = child.AddComponent<RectTransform>();
			rectTransform.sizeDelta = size;
			return child;
		}

		[MenuItem("GameObject/UI/[UGUIExternal]ProgressBar", false, 2200)]
		static public void AddProgressBar(MenuCommand menuCommand)
		{
			GameObject go = DefaultControls.CreateImage(GetStandardResources());
			PlaceUIElementRoot(go, menuCommand);
			go.name = "progressBar";
			go.AddComponent<UICustomProgressBar>();
			Image image = go.GetComponent<Image>();
			image.type = Image.Type.Simple;

			GameObject childProgress = new GameObject("progress");
			childProgress.AddComponent<RectTransform>();
			Image childProgressImage = childProgress.AddComponent<Image>();
			childProgressImage.type = Image.Type.Filled;
			childProgressImage.fillMethod = Image.FillMethod.Horizontal;
			SetParentAndAlign(childProgress, go);
			RectTransform childProgressRectTransform = childProgress.GetComponent<RectTransform>();
			childProgressRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			childProgressRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			childProgressRectTransform.sizeDelta = Vector2.zero;

			GameObject childText = new GameObject("Text");
			childText.AddComponent<RectTransform>();
			SetParentAndAlign(childText, go);

			Text text = childText.AddComponent<Text>();
			text.text = "percent";
			text.alignment = TextAnchor.MiddleCenter;
			text.horizontalOverflow = HorizontalWrapMode.Overflow;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			SetDefaultTextValues(text);

			RectTransform textRectTransform = childText.GetComponent<RectTransform>();
			textRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			textRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			textRectTransform.sizeDelta = Vector2.zero;
		}
		
		[MenuItem("GameObject/UI/[UGUIExternal]ComboBox", false, 2201)]
		static public void AddComboBox(MenuCommand menuCommand)
		{
			GameObject go = CreateUIElementRoot("ComboBox", s_ThickElementSize);
			PlaceUIElementRoot(go, menuCommand);
			go.AddComponent<UICustomComboBox>();

			GameObject button = DefaultControls.CreateButton(GetStandardResources());
			SetParentAndAlign(button, go);

			GameObject scrollView = DefaultControls.CreateScrollView(GetStandardResources());
			SetParentAndAlign(scrollView, go);

			RectTransform textRectTransform = scrollView.GetComponent<RectTransform>();
			textRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			textRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			textRectTransform.anchoredPosition = new Vector2(0f, -115f);
			textRectTransform.sizeDelta = new Vector2(160f, 200f);

			GameObject scrollContent = scrollView.transform.Find("Viewport/Content").gameObject;
			GameObject template = DefaultControls.CreateToggle(GetStandardResources());
			SetParentAndAlign(template, scrollContent);
			template.name = "template";
		}

		[MenuItem("GameObject/UI/[UGUIExternal]ScrollList", false, 2202)]
		static public void AddCustomScrollList(MenuCommand menuCommand)
		{
			GameObject scrollView = DefaultControls.CreateScrollView(GetStandardResources());
			scrollView.AddComponent<UICustomScrollList>();
			GameObject.DestroyImmediate(scrollView.GetComponent<Image>());
			ScrollRect scrollRect = scrollView.GetComponent<ScrollRect>();
			GameObject.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
			GameObject.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
			scrollRect.horizontalScrollbar = null;
			scrollRect.verticalScrollbar = null;
			PlaceUIElementRoot(scrollView, menuCommand);

			GameObject viewport = scrollView.transform.Find("Viewport").gameObject;
			Image viewportImage = viewport.GetComponent<Image>();
			RectTransform viewportRect = viewport.GetComponent<RectTransform>();
			viewportRect.sizeDelta = Vector2.zero;
			viewportImage.sprite = null;

			GameObject content = scrollView.transform.Find("Viewport/Content").gameObject;

			RectTransform contentRect = content.GetComponent<RectTransform>();
			contentRect.anchorMax = new Vector2(0, 1);
			contentRect.anchorMin = new Vector2(0, 1);
			contentRect.pivot = new Vector2(0, 1);
		}

		[MenuItem("GameObject/UI/[UGUIExternal]ScrollLoopList", false, 2203)]
		static public void AddScrollLoopList(MenuCommand menuCommand)
		{
			GameObject scrollView = DefaultControls.CreateScrollView(GetStandardResources());
			scrollView.AddComponent<UICustomScrollLoopList>();
			GameObject.DestroyImmediate(scrollView.GetComponent<Image>());
			ScrollRect scrollRect = scrollView.GetComponent<ScrollRect>();
			GameObject.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
			GameObject.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
			scrollRect.horizontalScrollbar = null;
			scrollRect.verticalScrollbar = null;
			PlaceUIElementRoot(scrollView, menuCommand);

			GameObject viewport = scrollView.transform.Find("Viewport").gameObject;
			Image viewportImage = viewport.GetComponent<Image>();
			RectTransform viewportRect = viewport.GetComponent<RectTransform>();
			viewportRect.sizeDelta = Vector2.zero;
			viewportImage.sprite = null;

			GameObject content = scrollView.transform.Find("Viewport/Content").gameObject;

			RectTransform contentRect = content.GetComponent<RectTransform>();
			contentRect.anchorMax = new Vector2(0, 1);
			contentRect.anchorMin = new Vector2(0, 1);
			contentRect.pivot = new Vector2(0, 1);

			GameObject child = new GameObject("FirstPadder");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, content);

			child = new GameObject("EndPadder");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, content);

			child = new GameObject("RecycledItems");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, scrollView);
		}

		[MenuItem("GameObject/UI/[UGUIExternal]ScrollFlowList", false, 2204)]
		static public void AddScrollFlowList(MenuCommand menuCommand)
		{
			GameObject scrollView = DefaultControls.CreateScrollView(GetStandardResources());
			scrollView.AddComponent<UICustomScrollFlowList>();
			GameObject.DestroyImmediate(scrollView.GetComponent<Image>());
			ScrollRect scrollRect = scrollView.GetComponent<ScrollRect>();
			GameObject.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
			GameObject.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
			scrollRect.horizontalScrollbar = null;
			scrollRect.verticalScrollbar = null;
			PlaceUIElementRoot(scrollView, menuCommand);

			GameObject viewport = scrollView.transform.Find("Viewport").gameObject;
			Image viewportImage = viewport.GetComponent<Image>();
			RectTransform viewportRect = viewport.GetComponent<RectTransform>();
			viewportRect.sizeDelta = Vector2.zero;
			viewportImage.sprite = null;

			GameObject content = scrollView.transform.Find("Viewport/Content").gameObject;

			RectTransform contentRect = content.GetComponent<RectTransform>();
			contentRect.anchorMax = new Vector2(0, 1);
			contentRect.anchorMin = new Vector2(0, 1);
			contentRect.pivot = new Vector2(0, 1);

			GameObject child = new GameObject("FirstPadder");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, content);

			child = new GameObject("EndPadder");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, content);

			child = new GameObject("RecycledItems");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, scrollView);
		}

		[MenuItem("GameObject/UI/[UGUIExternal]NumberImage", false, 2205)]
		static public void AddNumberImage(MenuCommand menuCommand)
		{
			GameObject scrollView = DefaultControls.CreateScrollView(GetStandardResources());
			scrollView.name = "numberImage";
			scrollView.AddComponent<UICustomNumberImage>();
			GameObject.DestroyImmediate(scrollView.GetComponent<Image>());
			ScrollRect scrollRect = scrollView.GetComponent<ScrollRect>();
			GameObject.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
			GameObject.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
			scrollRect.horizontalScrollbar = null;
			scrollRect.verticalScrollbar = null;
			PlaceUIElementRoot(scrollView, menuCommand);

			GameObject viewport = scrollView.transform.Find("Viewport").gameObject;
			GameObject.DestroyImmediate(viewport.GetComponent<Image>());
			GameObject.DestroyImmediate(viewport.GetComponent<Mask>());

			GameObject content = scrollView.transform.Find("Viewport/Content").gameObject;

			RectTransform contentRect = content.GetComponent<RectTransform>();
			contentRect.anchorMax = new Vector2(1, 1);
			contentRect.anchorMin = new Vector2(0, 1);
			contentRect.pivot = new Vector2(0, 1);

			HorizontalLayoutGroup hlg = content.AddComponent<HorizontalLayoutGroup>();
			hlg.childAlignment = TextAnchor.UpperCenter;
			hlg.childControlWidth = false;
			hlg.childControlHeight = false;
			hlg.childForceExpandWidth = false;
			hlg.childForceExpandHeight = false;

			GameObject child = new GameObject("template");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, content);
			Image image = child.AddComponent<Image>();
			image.sprite = null;
			image.color = Color.clear;
		}
		[MenuItem("GameObject/UI/[UGUIExternal]AnimateSprite", false, 2206)]
		static public void AddAnimateSprite(MenuCommand menuCommand)
		{
			GameObject go = CreateUIElementRoot("animateSprite", s_ThickElementSize);
			PlaceUIElementRoot(go, menuCommand);
			go.AddComponent<AnimateSprite>();
			RectTransform rect = go.GetComponent<RectTransform>();
			rect.sizeDelta = new Vector2(100, 100);
		}
		[MenuItem("GameObject/UI/[UGUIExternal]RollText", false, 2207)]
		static public void AddRollText(MenuCommand menuCommand)
		{
			GameObject go = CreateUIElementRoot("rollText", s_ThickElementSize);
			PlaceUIElementRoot(go, menuCommand);
			RollText rt = go.AddComponent<RollText>();
			go.AddComponent<Image>();
			Mask mask = go.AddComponent<Mask>();
			mask.showMaskGraphic = false;
			RectTransform rectTSF = go.GetComponent<RectTransform>();
			rectTSF.sizeDelta = new Vector2(150, 30);
			GameObject child = new GameObject("Text");
			child.AddComponent<RectTransform>();
			SetParentAndAlign(child, go);
			Text t = child.AddComponent<Text>();
			t.horizontalOverflow = HorizontalWrapMode.Overflow;
			rt.mask = mask.rectTransform;
			rt.textTSF = t.rectTransform;
			t.rectTransform.anchorMin = new Vector2(0, 0);
			t.rectTransform.anchorMax = new Vector2(1, 1);
			t.rectTransform.offsetMin = Vector2.zero;
			t.rectTransform.offsetMax = Vector2.zero;

		}
		[MenuItem("GameObject/UI/[UGUIExternal]LinkImageText", false, 2208)]
		static public void AddLinkImageText(MenuCommand menuCommand)
		{
			GameObject go = CreateUIElementRoot("htmlText", s_ThickElementSize);
			PlaceUIElementRoot(go, menuCommand);
			LinkImageText text = go.AddComponent<LinkImageText>();

		}
		private static void SetParentAndAlign(GameObject child, GameObject parent)
		{
			if (parent == null)
				return;

			child.transform.SetParent(parent.transform, false);
			SetLayerRecursively(child, parent.layer);
		}

		private static void SetLayerRecursively(GameObject go, int layer)
		{
			go.layer = layer;
			Transform t = go.transform;
			for (int i = 0; i < t.childCount; i++)
				SetLayerRecursively(t.GetChild(i).gameObject, layer);
		}


		private static void SetDefaultTextValues(Text lbl)
		{
			// Set text values we want across UI elements in default controls.
			// Don't set values which are the same as the default values for the Text component,
			// since there's no point in that, and it's good to keep them as consistent as possible.
			lbl.color = s_TextColor;

		}

		public static void CreateEventSystem(MenuCommand menuCommand)
		{
			GameObject parent = menuCommand.context as GameObject;
			CreateEventSystem(true, parent);
		}
		private static void CreateEventSystem(bool select)
		{
			CreateEventSystem(select, null);
		}
		private static void CreateEventSystem(bool select, GameObject parent)
		{
			var esys = Object.FindObjectOfType<EventSystem>();
			if (esys == null)
			{
				var eventSystem = new GameObject("EventSystem");
				GameObjectUtility.SetParentAndAlign(eventSystem, parent);
				esys = eventSystem.AddComponent<EventSystem>();
				eventSystem.AddComponent<StandaloneInputModule>();

				Undo.RegisterCreatedObjectUndo(eventSystem, "Create " + eventSystem.name);
			}

			if (select && esys != null)
			{
				Selection.activeGameObject = esys.gameObject;
			}
		}

		static public GameObject CreateNewUI()
		{
			// Root for the UI
			var root = new GameObject("Canvas");
			root.layer = LayerMask.NameToLayer(kUILayerName);
			Canvas canvas = root.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			root.AddComponent<CanvasScaler>();
			root.AddComponent<GraphicRaycaster>();
			Undo.RegisterCreatedObjectUndo(root, "Create " + root.name);

			// if there is no event system add one...
			CreateEventSystem(false);
			return root;
		}
		// Helper function that returns a Canvas GameObject; preferably a parent of the selection, or other existing Canvas.
		static public GameObject GetOrCreateCanvasGameObject()
		{
			GameObject selectedGo = Selection.activeGameObject;

			// Try to find a gameobject that is the selected GO or one if its parents.
			Canvas canvas = (selectedGo != null) ? selectedGo.GetComponentInParent<Canvas>() : null;
			if (canvas != null && canvas.gameObject.activeInHierarchy)
				return canvas.gameObject;

			// No canvas in selection or its parents? Then use just any canvas..
			canvas = Object.FindObjectOfType(typeof(Canvas)) as Canvas;
			if (canvas != null && canvas.gameObject.activeInHierarchy)
				return canvas.gameObject;

			// No canvas in the scene at all? Then create a new one.
			return UGUIExternalMenuOptions.CreateNewUI();
		}
	}
}