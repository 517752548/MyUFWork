using UnityEngine;
using System;
using System.Collections.Generic;
using LuaInterface;
using LuaFramework;
using UnityEditor;

using BindType = ToLuaMenu.BindType;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using DG.Tweening.Plugins.Options;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using Gear;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.Video;

public static class CustomSettings
{
	public static string FrameworkPath = AppConst.FrameworkRoot;
	public static string saveDir = FrameworkPath + "/ToLua/Source/Generate/";
	public static string toluaBaseType = FrameworkPath + "/ToLua/BaseType/";
	public static string baseLuaDir = FrameworkPath + "/ToLua/Lua";
	public static string injectionFilesPath = Application.dataPath + "/ToLua/Injection/";

    //lua print或者error重定向
    public const int PRINTLOGLINE = 208;                //ToLua.Print函数中Debugger.Log位置
    public const int PCALLERRORLINE = 810;              //LuaState.Pcall函数中throw位置
    public const int LUADLLERRORLINE = 803;             //LuaDLL.luaL_argerror函数中throw位置

    public const string LUAJIT_CMD_OPTION = "-b -g";    //luajit.exe 编译命令行参数

	//导出时强制做为静态类的类型(注意customTypeList 还要添加这个类型才能导出)
	//unity 有些类作为sealed class, 其实完全等价于静态类
	public static List<Type> staticClassTypes = new List<Type>
	{
		typeof(UnityEngine.Application),
		typeof(UnityEngine.Time),
		typeof(UnityEngine.Screen),
		typeof(UnityEngine.SleepTimeout),
		typeof(UnityEngine.Input),
		typeof(UnityEngine.Resources),
		typeof(UnityEngine.Physics),
		typeof(UnityEngine.RenderSettings),
		typeof(UnityEngine.QualitySettings),
		typeof(UnityEngine.GL),
		typeof(UnityEngine.Graphics),
		typeof(UnityEngine.SceneManagement.SceneManager),

	};

    //附加导出委托类型(在导出委托时, customTypeList 中牵扯的委托类型都会导出， 无需写在这里)
    public static DelegateType[] customDelegateList = 
    {        
        _DT(typeof(Action)),                
        _DT(typeof(UnityEngine.Events.UnityAction)),
        _DT(typeof(System.Predicate<int>)),
        _DT(typeof(System.Action<int>)),
        _DT(typeof(System.Comparison<int>)),
        _DT(typeof(System.Func<int, int>)),
        //_DT(typeof(TestEventListener.OnClick)),
        //_DT(typeof(TestEventListener.VoidDelegate)),
    };

    //在这里添加你要导出注册到lua的类型列表
    public static BindType[] customTypeList =
    {                
        //------------------------为例子导出--------------------------------
        //_GT(typeof(TestEventListener)),
        //_GT(typeof(TestProtol)),
        //_GT(typeof(TestAccount)),
        //_GT(typeof(Dictionary<int, TestAccount>)).SetLibName("AccountMap"),
        //_GT(typeof(KeyValuePair<int, TestAccount>)),
        //_GT(typeof(Dictionary<int, TestAccount>.KeyCollection)),
        //_GT(typeof(Dictionary<int, TestAccount>.ValueCollection)),
        //_GT(typeof(TestExport)),
        //_GT(typeof(TestExport.Space)),
        //-------------------------------------------------------------------        
        _GT(typeof(LuaInjectionStation)),
		_GT(typeof(InjectType)),
		_GT(typeof(Debugger)).SetNameSpace(null),
		_GT(typeof(GNetManager)),
		_GT(typeof(GByteArray)),
		_GT(typeof(Scene)),
		_GT(typeof(LoadSceneMode)),
		_GT(typeof(SceneManager)),
		_GT(typeof(GSceneLoader)),
		_GT(typeof(GLuaComponent)),
		_GT(typeof(GResManager)),
		_GT(typeof(NavMesh)),
		_GT(typeof(NavMeshHit)),
		_GT(typeof(NavMeshAgent)),
		_GT(typeof(NavMeshPath)),
		_GT(typeof(NavMeshObstacle)),
		_GT(typeof(NavMeshObstacleShape)),
		_GT(typeof(Debug)),
		_GT(typeof(TexturePackerManager)),
		_GT(typeof(AnimationEvent)),
		_GT(typeof(TouchPhase)),
		_GT(typeof(EventSystem)),
		_GT(typeof(AnimationCullingType)),
		_GT(typeof(ObjectPoolManager)),
		_GT(typeof(PlatformUtil)),
		_GT(typeof(ParticleSystem.MainModule)),
		_GT(typeof(ParticleSystem.MinMaxCurve)),
		_GT(typeof(LuaConst)),
		_GT(typeof(ApplicationKernel)),
		_GT(typeof(ApplicationLua)),
		_GT(typeof(Gizmos)),
		_GT(typeof(CSGlobal)),
		_GT(typeof(LayerMask)),
		_GT(typeof(AvatarFreeRotate)),
		_GT(typeof(TimelineAsset)),
		_GT(typeof(TimelineClip)),
		_GT(typeof(TimelinePlayable)),
		_GT(typeof(Playable)),
		_GT(typeof(PlayableAsset)),
		_GT(typeof(PlayableBehaviour)),
		_GT(typeof(PlayableBinding)),
		_GT(typeof(PlayableDirector)),
		_GT(typeof(PlayableTrack)),
		_GT(typeof(DirectorWrapMode)),
		_GT(typeof(DirectorUpdateMode)),
		_GT(typeof(ScriptableObject)),
		_GT(typeof(Mesh)),
		_GT(typeof(LayoutGroup)),
		_GT(typeof(HorizontalLayoutGroup)),
		_GT(typeof(VerticalLayoutGroup)),
		_GT(typeof(GridLayoutGroup)),
		_GT(typeof(ContentSizeFitter)),
		_GT(typeof(ContentSizeFitter.FitMode)),
		_GT(typeof(GridLayoutGroup.Constraint)),
		_GT(typeof(LayoutUtility)),
		_GT(typeof(ColorUtility)),
		_GT(typeof(RectOffset)),
		_GT(typeof(InputField.CharacterValidation)),
		_GT(typeof(InputField.ContentType)),
		_GT(typeof(UIDrawModelPanelVO)),
		_GT(typeof(UIDrawModelData)),
		_GT(typeof(SystemInfo)),
		_GT(typeof(AnimatorCullingMode)),
        //_GT(typeof(TouchScreenKeyboard.Status)),
        //_GT(typeof(TouchScreenKeyboard)),
        //_GT(typeof(TouchScreenKeyboardType)),
        _GT(typeof(HUDManager)),
		_GT(typeof(HUDBaseMesh)),
		_GT(typeof(HUDBaseContent)),
		_GT(typeof(HUDSkipContent)),
		_GT(typeof(HUDQuad)),
		_GT(typeof(HUDBloodContent)),
		_GT(typeof(HUDBloodQuad)),
		_GT(typeof(HUDTextContent)),
		_GT(typeof(HUDSpriteContent)),
		_GT(typeof(SkipMotionCurveScriptable)),
		_GT(typeof(SkipMotionCurveData)),
		_GT(typeof(Image.Type)),
		_GT(typeof(Font)),
		_GT(typeof(UnityEngine.Rendering.ShadowCastingMode)),
		_GT(typeof(Resolution)),
		_GT(typeof(InputField.LineType)),
		_GT(typeof(LightShadowResolution)),
		_GT(typeof(GFileManager)),
		_GT(typeof(GFileBundleInfo)),
		_GT(typeof(BundleStorageLocation)),
		_GT(typeof(GLoaderQueue)),
		_GT(typeof(GBaseLoader)),
		_GT(typeof(GBinaryLoader)),
		_GT(typeof(AndroidJavaClass)),
		_GT(typeof(AndroidJavaObject)),
		_GT(typeof(AndroidJavaProxy)),
		_GT(typeof(AndroidJNI)),
		_GT(typeof(AndroidJNIHelper)),
		_GT(typeof(JProxy)),
		_GT(typeof(UIRoot)),
		_GT(typeof(Projector)),
		_GT(typeof(DepthTextureMode)),
		_GT(typeof(AtlasManager)),
		_GT(typeof(AtlasInfo)),
		_GT(typeof(AnimateSprite)),
		_GT(typeof(GWebManager)),
		_GT(typeof(VideoPlayer)),
		_GT(typeof(VideoSource)),
		_GT(typeof(TextureWrapMode)),
		_GT(typeof(FilterMode)),
		_GT(typeof(VideoRenderMode)),
		_GT(typeof(UGUIEffectDepth)),
		_GT(typeof(RollText)),
		_GT(typeof(ThreadPriority)),
		_GT(typeof(NetworkReachability)),
		_GT(typeof(ParticleSystemRenderer)),
		_GT(typeof(FaceAnimateSprite)),
		_GT(typeof(AnimateFrameData)),
		_GT(typeof(AnimateFrameInfo)),
		_GT(typeof(Navigation)),
		_GT(typeof(Navigation.Mode)),
		_GT(typeof(WWWForm)),
		_GT(typeof(TextMesh)),
		_GT(typeof(TextMeshPro)),
		_GT(typeof(TextMeshProUGUI)),
		_GT(typeof(RangeScrollRect)),
		_GT(typeof(UILocalizationComponent)),
		_GT(typeof(StorageUtil)),
		_GT(typeof(CustomParticalLength)),
		_GT(typeof(AndroidCall)),
		_GT(typeof(UnityReceiveNativeMessage)),
		_GT(typeof(TDGA)),
		_GT(typeof(AdmobAD)),
		_GT(typeof(Dict4Lua)),
		//_GT(typeof(LuaDebugTool)),
		//_GT(typeof(LuaValueInfo)),

#if USING_DOTWEENING
		_GT(typeof(DG.Tweening.Ease)),
		_GT(typeof(DG.Tweening.DOTween)),
		_GT(typeof(DG.Tweening.Tween)).SetBaseType(typeof(System.Object)).AddExtendType(typeof(DG.Tweening.TweenExtensions)),
		_GT(typeof(DG.Tweening.Sequence)).AddExtendType(typeof(DG.Tweening.TweenSettingsExtensions)),
		_GT(typeof(DG.Tweening.Tweener)).AddExtendType(typeof(DG.Tweening.TweenSettingsExtensions)),
		_GT(typeof(DG.Tweening.LoopType)),
		_GT(typeof(DG.Tweening.PathMode)),
		_GT(typeof(DG.Tweening.PathType)),
		_GT(typeof(DG.Tweening.RotateMode)),
		_GT(typeof(Component)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Transform)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(RectTransform)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Light)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Material)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Rigidbody)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Camera)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(AudioSource)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Text)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)),
		_GT(typeof(Image)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(Slider)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)),
		_GT(typeof(ScrollRect)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)),
		_GT(typeof(CanvasGroup)).AddExtendType(typeof(DG.Tweening.DOTweenModuleUI)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
		_GT(typeof(DG.Tweening.Core.TweenerCore<Vector3,Vector3,VectorOptions>)),
		_GT(typeof(DG.Tweening.Core.TweenerCore<Vector3,Vector3[],Vector3ArrayOptions>)),
		_GT(typeof(DG.Tweening.Core.TweenerCore<float,float,FloatOptions>)),
		_GT(typeof(DG.Tweening.Core.TweenerCore<string,string,StringOptions>)),
		_GT(typeof(DG.Tweening.UpdateType)),
        //_GT(typeof(LineRenderer)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(TrailRenderer)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(SpriteRenderer)).AddExtendType(typeof(DG.Tweening.DOTweenModuleSprite)),
#else

        _GT(typeof(Component)),
		_GT(typeof(Transform)),
		_GT(typeof(Material)),
		_GT(typeof(Light)),
		_GT(typeof(Rigidbody)),
		_GT(typeof(Camera)),
		_GT(typeof(AudioSource)),
        //_GT(typeof(LineRenderer))
        _GT(typeof(TrailRenderer)),
        _GT(typeof(SpriteRenderer)),
#endif
      
        _GT(typeof(Behaviour)),
		_GT(typeof(MonoBehaviour)),
		_GT(typeof(GameObject)),
		_GT(typeof(TrackedReference)),
		_GT(typeof(Application)),
		_GT(typeof(Physics)),
		_GT(typeof(Collider)),
		_GT(typeof(Time)),
		_GT(typeof(Texture)),
		_GT(typeof(Texture2D)),
		_GT(typeof(Shader)),
		_GT(typeof(Renderer)),
#if !UNITY_5_4_OR_NEWER || UNITY_4_6 || UNITY_4_7
		_GT(typeof(WWW)),
#else
        _GT(typeof(UnityWebRequest)),
        _GT(typeof(DownloadHandler)),
        _GT(typeof(DownloadHandlerBuffer)),
#if UNITY_2017_1_OR_NEWER
        _GT(typeof(UnityWebRequestAsyncOperation)),
#endif
#endif
		_GT(typeof(Screen)),
		_GT(typeof(CameraClearFlags)),
		_GT(typeof(AudioClip)),
		_GT(typeof(AssetBundle)),
		_GT(typeof(ParticleSystem)),
		_GT(typeof(ParticleSystem.EmissionModule)),
		_GT(typeof(ParticleSystem.TrailModule)),
		_GT(typeof(AsyncOperation)).SetBaseType(typeof(System.Object)),
		_GT(typeof(LightType)),
		_GT(typeof(SleepTimeout)),
#if UNITY_5_3_OR_NEWER && !UNITY_5_6_OR_NEWER
        _GT(typeof(UnityEngine.Experimental.Director.DirectorPlayer)),
#endif
        _GT(typeof(Animator)),
		_GT(typeof(AnimatorStateInfo)),
		_GT(typeof(Input)),
		_GT(typeof(KeyCode)),
		_GT(typeof(SkinnedMeshRenderer)),
		_GT(typeof(Space)),


		_GT(typeof(MeshRenderer)),
#if !UNITY_5_4_OR_NEWER
        _GT(typeof(ParticleEmitter)),
        _GT(typeof(ParticleRenderer)),
        _GT(typeof(ParticleAnimator)), 
#endif
        
        _GT(typeof(BoxCollider)),
		_GT(typeof(MeshCollider)),
		_GT(typeof(SphereCollider)),
		_GT(typeof(CharacterController)),
		_GT(typeof(CapsuleCollider)),

		_GT(typeof(Animation)),
		_GT(typeof(AnimationClip)).SetBaseType(typeof(UnityEngine.Object)),
		_GT(typeof(AnimationState)),
		_GT(typeof(AnimationBlendMode)),
		_GT(typeof(QueueMode)),
		_GT(typeof(PlayMode)),
		_GT(typeof(WrapMode)),
		_GT(typeof(AnimationCurve)),
		_GT(typeof(Keyframe)),


		_GT(typeof(QualitySettings)),
		_GT(typeof(RenderSettings)),
		_GT(typeof(SkinWeights)),
		_GT(typeof(RenderTextureFormat)),
		_GT(typeof(RenderTexture)),
		_GT(typeof(Resources)),
		_GT(typeof(LuaProfiler)),
          
        //for LuaFramework
        _GT(typeof(PlayerPrefs)),
		_GT(typeof(Canvas)),
		_GT(typeof(CanvasScaler)),
		_GT(typeof(GraphicRaycaster)),
		_GT(typeof(GraphicRaycaster.BlockingObjects)),
		_GT(typeof(Rect)),
		//_GT(typeof(RectTransform)),
//		_GT(typeof(Text)),
		//_GT(typeof(Image)),
		_GT(typeof(RawImage)),
		_GT(typeof(InputField)),
		_GT(typeof(InputField.OnChangeEvent)),
		_GT(typeof(InputField.SubmitEvent)),
		_GT(typeof(Button)),
		_GT(typeof(Button.ButtonClickedEvent)),
		_GT(typeof(LongClickButton)),
		_GT(typeof(LongClickButton.LongClickEvent)),
		_GT(typeof(LongClickButton.LongClickEventEx)),
		_GT(typeof(DoubleClickButton)),
		_GT(typeof(DoubleClickButton.DoubleClickedEvent)),
		_GT(typeof(Toggle)),
		_GT(typeof(Toggle.ToggleEvent)),
		_GT(typeof(RangeScrollRect.RangeScrollRectEvent)),
		_GT(typeof(ToggleGroup)),
		_GT(typeof(LongClickToggle)),
		//_GT(typeof(Slider)),
		_GT(typeof(Slider.SliderEvent)),
		_GT(typeof(Scrollbar)),
		_GT(typeof(Scrollbar.ScrollEvent)),
		//_GT(typeof(ScrollRect)),
		_GT(typeof(ScrollRect.ScrollRectEvent)),
		_GT(typeof(ScrollRect.ScrollbarVisibility)),
		_GT(typeof(ScrollRect.MovementType)),
		_GT(typeof(Joystick)),
		_GT(typeof(Sprite)),
		_GT(typeof(LayoutRebuilder)),
		_GT(typeof(RectTransformUtility)),
		_GT(typeof(UICustomTextGradient)),
		_GT(typeof(RichLabel)),
		_GT(typeof(RichLabel.HrefClickEvent)),
		_GT(typeof(LinkImageText)),
		_GT(typeof(LinkImageText.HrefClickEvent)),
		_GT(typeof(TextAnchor)),
		_GT(typeof(Outline)),
		_GT(typeof(ImageFreeRotate)),
		_GT(typeof(Graphic)),
		_GT(typeof(Util)),
		_GT(typeof(AppConst)),
		_GT(typeof(LuaHelper)),

		_GT(typeof(CircleList)),
        _GT(typeof(UnderLine)),
        _GT(typeof(UnregularButtonWithCollider)),
        _GT(typeof(ImageContent)),
    };

	public static List<Type> dynamicList = new List<Type>()
	{
		typeof(MeshRenderer),
#if !UNITY_5_4_OR_NEWER
        typeof(ParticleEmitter),
        typeof(ParticleRenderer),
        typeof(ParticleAnimator),
#endif

        typeof(BoxCollider),
		typeof(MeshCollider),
		typeof(SphereCollider),
		typeof(CharacterController),
		typeof(CapsuleCollider),

		typeof(Animation),
		typeof(AnimationClip),
		typeof(AnimationState),

		typeof(SkinWeights),
		typeof(RenderTexture),
		typeof(Rigidbody),
	};

	//重载函数，相同参数个数，相同位置out参数匹配出问题时, 需要强制匹配解决
	//使用方法参见例子14
	public static List<Type> outList = new List<Type>()
	{

	};

	//ngui优化，下面的类没有派生类，可以作为sealed class
	public static List<Type> sealedList = new List<Type>()
	{
		/*typeof(Transform),
        typeof(UIRoot),
        typeof(UICamera),
        typeof(UIViewport),
        typeof(UIPanel),
        typeof(UILabel),
        typeof(UIAnchor),
        typeof(UIAtlas),
        typeof(UIFont),
        typeof(UITexture),
        typeof(UISprite),
        typeof(UIGrid),
        typeof(UITable),
        typeof(UIWrapGrid),
        typeof(UIInput),
        typeof(UIScrollView),
        typeof(UIEventListener),
        typeof(UIScrollBar),
        typeof(UICenterOnChild),
        typeof(UIScrollView),
        typeof(UIButton),
        typeof(UITextList),
        typeof(UIPlayTween),
        typeof(UIDragScrollView),
        typeof(UISpriteAnimation),
        typeof(UIWrapContent),
        typeof(TweenWidth),
        typeof(TweenAlpha),
        typeof(TweenColor),
        typeof(TweenRotation),
        typeof(TweenPosition),
        typeof(TweenScale),
        typeof(TweenHeight),
        typeof(TypewriterEffect),
        typeof(UIToggle),
        typeof(Localization),*/
	};

	public static BindType _GT(Type t)
	{
		return new BindType(t);
	}

	public static DelegateType _DT(Type t)
	{
		return new DelegateType(t);
	}


	[MenuItem("Lua/Attach Profiler", false, 151)]
	static void AttachProfiler()
	{
		if (!Application.isPlaying)
		{
			EditorUtility.DisplayDialog("警告", "请在运行时执行此功能", "确定");
			return;
		}

		LuaClient.Instance.AttachProfiler();
	}

	[MenuItem("Lua/Detach Profiler", false, 152)]
	static void DetachProfiler()
	{
		if (!Application.isPlaying)
		{
			return;
		}

		LuaClient.Instance.DetachProfiler();
	}
}
