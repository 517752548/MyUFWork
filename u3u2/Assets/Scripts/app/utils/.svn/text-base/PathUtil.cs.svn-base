using System.Collections;
using System.Collections.Generic;
using app.db;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;
using app.config;

public class PathUtil
{
    public const string UI_RELATIVE_DIR = "UI/";
    public const string UI_ATLAS_RELATIVE_DIR = "UIAtlas/";
    public const string UI_TEXTUER_RELATIVE_DIR = "UITextures/";
    public const string UI_EFFECT_RELATIVE_DIR = "UIEffects/";
    public const string MUSIC_RELATIVE_DIR = "Music/";


    public const string FONTS_RELATIVE_DIR = "Fonts/";
    public const string ZONE_SCENE_RELATIVE_DIR = "ZoneScenes/";
    public const string CHARACTER_RELATIVE_DIR = "Characters/";
    public const string EFFECT_RELATIVE_DIR = "Effects/";
    public const string WEAPON_RELATIVE_DIR = "Weapons/";

    public const string ABL_FILE_EXT = ".abl";
    public const string BIN_FILE_EXT = ".bin";

    public const string TEXTURE_UI = "UI/";
    //public const string TEXTUER_ITEM = "item/";
    //public const string TEXTUER_YINGXIONG = "yingxiong/";
    //public const string TEXTUER_SKILL = "skill/";
    //public const string TEXTUER_SKILL_NAME = "skillName/";
    //public const string TEXTUER_SKILL_EFFECT_NAME = "skillEffectName/";
    public const string TEXTUER_CREATEROLE = "createRole/";
    //public const string TEXTUER_BODY = "body/";
    //public const string TEXTUER_NPC_BODY = "npcbody/";
    public const string SPINE_NPC_DIR = "spine/npc/";
    public const string MAPEFFECT_PREFIX = "mapeffect_";
    /// <summary>
    /// 头像。
    /// </summary>
    //public const string TEXTUER_HEAD = "head/";

    public const string TEXTUER_YUAN_HEAD = "yuanhead/";

    /*
    /// <summary>
    /// 活动图标。
    /// </summary>
    public const string TEXTURE_ACTIVITY_ICON = "activityIcon/";
    */

    /// <summary>
    /// 心法图标
    /// </summary>
    public const string XINFA_ICON = "xinfa/";

    /// <summary>
    /// 加载背景
    /// </summary>
    public const string LOADING_BG = "loadingBg/";

    /// <summary>
    /// 变异材质球相对目录
    /// </summary>
    public const string VARIATION_MAT_RELATIVE_DIR = "Variation/";

    /// <summary>
    /// 翅膀相对目录
    /// </summary>
    public const string WING_RELATIVE_DIR = "Wings/";

    public string uiEffectsPath = null;
    public string uiDependenciesPath = null;
    public string activityIconAtlasPath = null;
    public string headAtlasPath = null;
    public string itemAtlasPath = null;
    public string skillAtlasPath = null;
    public string xinfaAtlasPath = null;
    public string chongzhiAtlasPath = null;
    public string mozuAtlasPath = null;
    public string skillNameAtlasPath = null;
    public string skillEffectNameAtlasPath = null;
    public List<string> RoleModelNameList = new List<string>
    {"nvxiake","nanxiake","nvcike","nancike","nvshushi","nanshushi","nvxiuzhen","nanxiuzhen"};
    public List<string> NpcModelNameList = new List<string>
        {"cangkulaoban","dianxiaoer","linyayi","mantianxia","chongwuxianzi","hongniang","linyuanshan","yunliangren","chuansongdian","laofuzi","lvyexianzong","zhongkui"};
    public string extFilesRoot { get; private set; }

	private Dictionary<string, string> mFilePathes = new Dictionary<string, string> ();

    private static PathUtil _ins;
    public static PathUtil Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new PathUtil();
            }
            return _ins;
        }
    }

    public PathUtil()
    {
        uiEffectsPath = GetUIPath("UIEffects");
        uiDependenciesPath = GetUIDependenciesPath();
        activityIconAtlasPath = GetUIAtltasPath("activityIcon");
        headAtlasPath = GetUIAtltasPath("head");
        itemAtlasPath = GetUIAtltasPath("item");
        skillAtlasPath = GetUIAtltasPath("skill");
        xinfaAtlasPath = GetUIAtltasPath("xinfa");
        chongzhiAtlasPath = GetUIAtltasPath("chongzhi");
        mozuAtlasPath = GetUIAtltasPath("mozu");
        skillNameAtlasPath = GetUIAtltasPath("skillName");
        skillEffectNameAtlasPath = GetUIAtltasPath("skillEffectName");
        extFilesRoot = Application.temporaryCachePath;
        #if !UNITY_EDITOR && UNITY_ANDROID
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        extFilesRoot = jo.Call<string>("getTheFilesDir");
        #endif
    }

    /*
    public String assets_root
    {
        get
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    return new StringBuilder("file://").Append(Application.streamingAssetsPath).Append("/").ToString();
                case RuntimePlatform.Android:
                    return new StringBuilder(Application.streamingAssetsPath).Append("/").ToString();
                default:
                    return new StringBuilder("file://").Append(Application.streamingAssetsPath).Append("/").ToString();
            }
        }
    }
    */

    /// <summary>
    /// UI路径。
    /// </summary>
    /// <param name="uiName"></param>
    /// <returns></returns>
    public string GetUIPath(string fileName)
    {
        return new StringBuilder(UI_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }

    public string GetUIAtltasPath(string fileName)
    {
        return new StringBuilder(UI_ATLAS_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }

    private string GetUIDependenciesPath()
    {
        return GetUIPath("UIDependencies");
    }
    /*
    public string GetSingleCommonTexturesPath()
    {
        return GetUIPath("SingleCommonTextures");
    }
    */

    /// <summary>
    /// UI贴图路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <param dictionary="fileName">贴图相对于UITexture目录的相对目录</dictionary>
    /// <returns></returns>
    public string GetUITexturePath(string fileName, string dictionary = TEXTURE_UI)
    {
        /*
        if (dictionary == TEXTUER_ITEM)
        {
            //fileName = "10001";
        }
        else if (dictionary == TEXTUER_SKILL && fileName == "")
        {
            //fileName = "1001";
        }
        else if (dictionary == TEXTUER_HEAD && fileName == "")
        {
            fileName = "default";
        }
        */
        return new StringBuilder(UI_TEXTUER_RELATIVE_DIR).Append(dictionary).Append(dictionary.Split('/')[0]).Append("_").Append(fileName).Append("_tex").Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// UI特效路径。
    /// </summary>
    /// <param name="uiName"></param>
    /// <returns></returns>
    public string GetUIEffectPath(string effectName)
    {
        return new StringBuilder(UI_EFFECT_RELATIVE_DIR).Append(effectName).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 获得声音资源路径
    /// </summary>
    /// <param name="musicName"></param>
    /// <returns></returns>
    public string GetMusicPath(string musicName, AudioEnumType audioType)
    {
        string dicName = "";
        switch (audioType)
        {
            case AudioEnumType.BackGround:
                dicName = "backGround_";
                break;
            case AudioEnumType.Role:
                dicName = "role_";
                break;
            case AudioEnumType.NPC:
                dicName = "npc_";
                break;
            case AudioEnumType.Skill:
                //技能的名字，配置表里带了前缀
                dicName = "";
                break;
            default:
                break;
        }
        return new StringBuilder(MUSIC_RELATIVE_DIR).Append(dicName).Append(musicName).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 字体路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string GetFontPath(string fileName)
    {
        return new StringBuilder(FONTS_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 副本地图场景路径。
    /// </summary>
    /// <param name="sceneId"></param>
    /// <returns></returns>
    public string GetZoneScenePath(string sceneName)
    {
        return new StringBuilder(ZONE_SCENE_RELATIVE_DIR).Append(sceneName).Append(ABL_FILE_EXT).ToString();
    }
    /*
    public string GetZoneSceneMapTilesPath(string sceneName)
    {
        return new StringBuilder(ZONE_SCENE_RELATIVE_DIR).Append(sceneName).Append("_tiles").Append(FILE_EXT).ToString();
    }
    */
    public string GetZoneSceneMapTilePath(string sceneName, int col, int row)
    {
        return new StringBuilder(ZONE_SCENE_RELATIVE_DIR).Append(sceneName).Append("/map_").Append(col).Append("_").Append(row).Append(BIN_FILE_EXT).ToString();
    }

    /// <summary>
    /// 角色路径。
    /// </summary>
    /// <param name="displayModelId"></param>
    /// <returns></returns>
    public string[] GetCharacterDisplayModelPath(string displayModelId, bool needDependence = true)
    {
        if (displayModelId == "chuansongdian")
        {
            needDependence = false;
        }
        int count = needDependence ? 2 : 1;
        string[] res = new string[count];
        if (needDependence)
        {
            //res[0] = new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append("_mat").Append(FILE_EXT).ToString();
            //res[1] = new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append("_anim").Append(FILE_EXT).ToString();
            //res[2] = new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append(FILE_EXT).ToString();
            res[0] =new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append("_anim").Append(ABL_FILE_EXT).ToString();
            res[1] =new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append(ABL_FILE_EXT).ToString();
        }
        else
        {
            res[0] = new StringBuilder(CHARACTER_RELATIVE_DIR).Append(displayModelId).Append(ABL_FILE_EXT).ToString();
        }

        return res;
    }

    /// <summary>
    /// npcSpine动画路径。
    /// </summary>
    /// <param name="displayModelId"></param>
    /// <returns></returns>
    public string GetSpineNPCDisplayModelPath(string displayModelId)
    {
        if (string.IsNullOrEmpty(displayModelId)) return "moren";
        return new StringBuilder(SPINE_NPC_DIR).Append("spine_npc_").Append(displayModelId).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 特效路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string GetEffectPath(string fileName)
    {
        return new StringBuilder(EFFECT_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 获得地图特效路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string GetMapEffectPath(string fileName)
    {
        return new StringBuilder(EFFECT_RELATIVE_DIR).Append(MAPEFFECT_PREFIX).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }
    /// <summary>
    /// 武器路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string GetWeaponPath(string fileName)
    {
        return new StringBuilder(WEAPON_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 变异材质球路径。
    /// </summary>
    /// <param name="displayModelId"></param>
    /// <returns></returns>
    public string GetVariationMatPath(string displayModelId)
    {
        return new StringBuilder(VARIATION_MAT_RELATIVE_DIR).Append("b_").Append(displayModelId).Append(ABL_FILE_EXT).ToString();
    }

    /// <summary>
    /// 翅膀路径。
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string[] GetWingPath(string fileName)
    {
        string[] res = new string[2];
        //res[0] = new StringBuilder(WING_RELATIVE_DIR).Append(fileName).Append("_mat").Append(FILE_EXT).ToString();
        //res[1] = new StringBuilder(WING_RELATIVE_DIR).Append(fileName).Append("_anim").Append(FILE_EXT).ToString();
        //res[2] = new StringBuilder(WING_RELATIVE_DIR).Append(fileName).Append(FILE_EXT).ToString();
        
        res[0] = new StringBuilder(WING_RELATIVE_DIR).Append(fileName).Append("_anim").Append(ABL_FILE_EXT).ToString();
        res[1] = new StringBuilder(WING_RELATIVE_DIR).Append(fileName).Append(ABL_FILE_EXT).ToString();
        
        return res;
    }

    public string GetFinalPath(string path, bool forceExternal = false)
    {
		if (mFilePathes.ContainsKey (path)) {
			return mFilePathes [path];
		} else {
            string finalPath = null;
			string outAppPackPath = new StringBuilder (extFilesRoot).Append ("/Assets/").Append (path).ToString ();
			if (outAppPackPath.IndexOf ("file://") == 0) {
				outAppPackPath = outAppPackPath.Substring (7);
			}
			outAppPackPath = outAppPackPath.Replace ('/', System.IO.Path.DirectorySeparatorChar);

			if (forceExternal || (!ClientConfig.Ins.debug && ClientConfig.Ins.externalArts && (File.Exists (outAppPackPath) || Directory.Exists (outAppPackPath)))) {
				finalPath = outAppPackPath;
			} else {
				finalPath = new StringBuilder (Application.streamingAssetsPath).Append ("/").Append (path).ToString ();
                /*
				if (inAppPackPath.IndexOf ("file://") == 0) {
					inAppPackPath = inAppPackPath.Substring (7);
				}
				inAppPackPath = inAppPackPath.Replace ('/', System.IO.Path.DirectorySeparatorChar);
				finalPath = inAppPackPath;
                */
			}

			if (finalPath.IndexOf ("file://") == -1) {
				finalPath = new StringBuilder ("file://").Append (finalPath).ToString ();
			}
			mFilePathes.Add(path, finalPath);
            return finalPath;
		}
        return null;
    }
    
    /// <summary>
    /// 设置Pet头像。
    /// </summary>
    /// <param name="icon"></param>
    /// <param name="sourcePath"></param>
    /*
    public void SetPetIconSource(RawImage icon, int petTemplateId, UnityAction onComplete = null)
    {
        string dictionary = TEXTUER_HEAD;
        PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(petTemplateId);
        if (petTpl != null)
        {
            SetRawImageSource(icon, petTpl.modelId, dictionary, false, onComplete);
        }
    }
    */

    private Dictionary<RawImage, bool> mRawImgAutoSizeDic = new Dictionary<RawImage, bool>();
    private Dictionary<string, Dictionary<RawImage, UnityAction<string, RawImage>>> mRawImgCallbacks = new Dictionary<string, Dictionary<RawImage, UnityAction<string, RawImage>>>();

    /// <summary>
    /// 设置图标
    /// </summary>
    /// <param name="icon"></param>
    /// <param name="sourceName"></param>
    /// <param name="dictionary"></param>
    /// <param name="auto">NativeSize</param>
    /// <param name="onComplete"></param>
    public void SetRawImageSource(RawImage icon, string sourceName, string dictionary, bool autoSize = false, UnityAction<string, RawImage> onComplete = null)
    {
        string path = PathUtil.Ins.GetUITexturePath(sourceName, dictionary);
        bool hasAssets = SourceManager.Ins.hasAssetBundle(path);
        Texture texture;
        if (hasAssets)
        {
            texture = SourceManager.Ins.GetAsset<Texture>(path);
            icon.texture = texture;
            if (autoSize)
            {
                icon.SetNativeSize();
                //RectTransform rt = icon.GetComponent<RectTransform>();
                //rt.sizeDelta = new Vector2(texture.width, texture.height);
            }
            if (onComplete != null)
            {
                onComplete(path, icon);
            }
        }
        else
        {
            if (!mRawImgAutoSizeDic.ContainsKey(icon))
            {
                mRawImgAutoSizeDic.Add(icon, autoSize);
            }
            Dictionary<RawImage, UnityAction<string, RawImage>> pathCallbacks;
            mRawImgCallbacks.TryGetValue(path, out pathCallbacks);
            if (pathCallbacks == null)
            {
                pathCallbacks = new Dictionary<RawImage, UnityAction<string, RawImage>>();
                mRawImgCallbacks.Add(path, pathCallbacks);
            }

            if (!pathCallbacks.ContainsKey(icon))
            {
                pathCallbacks.Add(icon, onComplete);
            }

            SourceLoader.Ins.load(path, SetRawImageSourceLoadComplete);
        }
    }

    private void SetRawImageSourceLoadComplete(RMetaEvent e)
    {
        LoadInfo loadInfo = e.data as LoadInfo;
        Texture texture1 = SourceManager.Ins.GetAsset<Texture>(loadInfo.urlPath);
        Dictionary<RawImage, UnityAction<string, RawImage>> pathCallbacks = mRawImgCallbacks[loadInfo.urlPath];
        IDictionaryEnumerator pathCallbacksEnum = pathCallbacks.GetEnumerator();
        while (pathCallbacksEnum.MoveNext())
        {
            RawImage icon = (RawImage)pathCallbacksEnum.Key;
            if (icon != null)
            {
                icon.texture = texture1;

                if (mRawImgAutoSizeDic.ContainsKey(icon))
                {
                    if (mRawImgAutoSizeDic[icon])
                    {
                        icon.SetNativeSize();
                    }
                    mRawImgAutoSizeDic.Remove(icon);
                }

                UnityAction<string, RawImage> imgCallback = (UnityAction<string, RawImage>)pathCallbacksEnum.Value;
                if (imgCallback != null)
                {
                    imgCallback(loadInfo.urlPath, icon);
                }
            }
        }

        mRawImgCallbacks.Remove(loadInfo.urlPath);
    }

    private Dictionary<Image, bool> mImgAutoSizeDic = new Dictionary<Image, bool>();
    private Dictionary<string, Dictionary<Image, UnityAction<Image, string, string>>> mImgCallbacks = new Dictionary<string, Dictionary<Image, UnityAction<Image, string, string>>>();

    /// <summary>
    /// 设置图标
    /// </summary>
    public void SetImageSource(Image icon, string spriteName, string atlasName, UnityAction<Image, string, string> onComplete = null, bool autoSize = false)
    {
        string path = PathUtil.Ins.GetUIAtltasPath(atlasName);
        bool hasAssets = SourceManager.Ins.hasAssetBundle(path);
        Sprite sprite;
        if (hasAssets)
        {
            sprite = SourceManager.Ins.GetAsset<Sprite>(path, spriteName);
            icon.sprite = sprite;
            if (autoSize)
            {
                //RectTransform rt = icon.GetComponent<RectTransform>();
                //rt.sizeDelta = new Vector2(texture.rect.width, texture.rect.height);
                icon.SetNativeSize();
            }
            if (onComplete != null)
            {
                onComplete(icon, spriteName, path);
            }
        }
        else
        {
            if (!mImgAutoSizeDic.ContainsKey(icon))
            {
                mImgAutoSizeDic.Add(icon, autoSize);
            }
            Dictionary<Image, UnityAction<Image, string, string>> pathCallbacks;
            mImgCallbacks.TryGetValue(atlasName + spriteName, out pathCallbacks);
            if (pathCallbacks == null)
            {
                pathCallbacks = new Dictionary<Image, UnityAction<Image, string, string>>();
                mImgCallbacks.Add(atlasName + spriteName, pathCallbacks);
            }

            if (!pathCallbacks.ContainsKey(icon))
            {
                pathCallbacks.Add(icon, onComplete);
            }

            string[] pars = new string[] { spriteName, atlasName };
            SourceLoader.Ins.load(path, SetImageSourceLoadComplete, null, pars);
        }
    }

    private void SetImageSourceLoadComplete(RMetaEvent e)
    {
        LoadInfo loadInfo = e.data as LoadInfo;
        string[] pars = (string[])loadInfo.param;
        string spriteName = pars[0];
        string atlasName = pars[1];
        Sprite sprite = SourceManager.Ins.GetAsset<Sprite>(loadInfo.urlPath, spriteName);
        Dictionary<Image, UnityAction<Image, string, string>> pathCallbacks = mImgCallbacks[atlasName + spriteName];
        IDictionaryEnumerator pathCallbacksEnum = pathCallbacks.GetEnumerator();
        while (pathCallbacksEnum.MoveNext())
        {
            Image icon = (Image)pathCallbacksEnum.Key;
            if (icon != null)
            {
                icon.sprite = sprite;

                if (mImgAutoSizeDic.ContainsKey(icon))
                {
                    if (mImgAutoSizeDic[icon])
                    {
                        icon.SetNativeSize();
                    }

                    mImgAutoSizeDic.Remove(icon);
                }

                UnityAction<Image, string, string> imgCallback = (UnityAction<Image, string, string>)pathCallbacksEnum.Value;
                if (imgCallback != null)
                {
                    imgCallback(icon, spriteName, loadInfo.urlPath);
                }
            }
        }

        mImgCallbacks.Remove(atlasName + spriteName);
    }
    
    public void SetActivityIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, activityIconAtlasPath, setNativeSize);
    }
    
    public void SetHeadIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, headAtlasPath, setNativeSize);
    }

    public void SetHeadIcon(Image img, int petTplId, bool setNativeSize = false)
    {
        PetTemplate tpl = PetTemplateDB.Instance.getTemplate(petTplId);
        if (tpl != null) SetSprite(img, tpl.modelId, headAtlasPath, setNativeSize);
    }

    public void SetItemIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, itemAtlasPath, setNativeSize);
    }
    
    public void SetSkillIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, skillAtlasPath, setNativeSize);
    }
    
    public void SetXinFaIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, xinfaAtlasPath, setNativeSize);
    }

    public void SetChongZhiIcon(Image img, string iconName, bool setNativeSize = false)
    {
        SetSprite(img, iconName, chongzhiAtlasPath,setNativeSize);
    }

    public void SetSprite(Image img, string spriteName, string atlasPath, bool setNativeSize = false)
    {
        img.sprite = SourceManager.Ins.GetAsset<Sprite>(atlasPath, spriteName);
        if (img.sprite == null)
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            img.gameObject.SetActive(true);
            if (setNativeSize)
            {
                img.SetNativeSize();
            }
        }
    }
    /// <summary>
    /// 根据名字，从ui中获取sprite
    /// </summary>
    /// <param name="uiname"></param>
    /// <param name="assetdicname"></param>
    /// <param name="assetname"></param>
    /// <param name="suffix"></param>
    /// <returns></returns>
    public Object GetAssetFromUIByName(string uiname, string assetdicname, string assetname, string suffix = ".png")
    {
        string assetfinalname = "assets/ui2/textures/"+assetdicname+"/"+assetname+suffix;
        return SourceManager.Ins.GetAsset<Object>(GetUIPath(uiname), assetfinalname);
    }

    /// <summary>
    /// 从模型动画名称 文件 获取模型的所有动画名数组
    /// </summary>
    /// <param name="modelId"></param>
    /// <param name="prefix"></param>
    /// <returns></returns>
    /*
    public string[] GetAnimArr(string modelId,string prefix=null)
    {
        Type type = CharactorAnimName.Ins.GetType();
        object obj = Activator.CreateInstance(type, true);
        string[] resources = null;
        FieldInfo classField = type.GetField(modelId);
        if (classField != null)
        {
            resources = classField.GetValue(obj) as string[];
            if (prefix != null)
            {
                List<string> newArr = new List<string>();
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i].IndexOf(prefix) >= 0)
                    {
                        newArr.Add(resources[i]);
                    }
                }
                return newArr.ToArray();
            }
            else
            {
                return resources;
            }
        }
        return resources;
    }
    */
}

