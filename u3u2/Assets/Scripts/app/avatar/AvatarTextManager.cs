using UnityEngine;
using UnityEngine.UI;
using app.utils;
using app.zone;


namespace app.avatar
{
    /// <summary>
    /// 地图上 角色的 文本信息
    /// </summary>
    class AvatarTextManager
    {
        //public Camera avatarCam { get; set; }

        private static AvatarTextManager _ins;

        //private Dictionary<string,GameObject> avatarTextDic = new Dictionary<string, GameObject>();

        //public GameObject avatarTextContainer { get; private set; }
        private GameObject mAvatarTextContainer = null;

        public static AvatarTextManager Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new AvatarTextManager();
                }
                return _ins;
            }
        }
        
        public AvatarTextManager()
        {
            //CreateAvatarTextContainer();
        }
        
        public GameObject avatarTextContainer
        {
            get
            {
                CreateAvatarTextContainer();
                return mAvatarTextContainer;
            }
        }

        public void SetActive(bool value)
        {
            if (avatarTextContainer != null)
            {
                avatarTextContainer.SetActive(value);
            }
        }

        /// <summary>
        /// 创建角色文本
        /// </summary>
        private void CreateAvatarTextContainer()
        {
            if (mAvatarTextContainer == null)
            {
                mAvatarTextContainer = new GameObject("avatarTextContainer");
                GameObject.DontDestroyOnLoad(mAvatarTextContainer);
                /*
                avatarTextContainer.transform.SetParent(UGUIConfig.UICanvas.transform);
                avatarTextContainer.layer = LayerConfig.Layer_UI;
                avatarTextContainer.transform.localScale = Vector3.one;
                avatarTextContainer.AddComponent<RectTransform>();
                avatarTextContainer.GetComponent<RectTransform>().anchorMin = Vector2.zero;
                avatarTextContainer.GetComponent<RectTransform>().anchorMax = Vector2.zero;
                avatarTextContainer.transform.localPosition = Vector3.zero;
                */
            }
        }

        public GameObject[] CreateAvatarText(string name, string text, Color color, bool outline, int layer)
        {
            return CreateAvatarText(name, text, color, outline, 24, layer);
        }

        public GameObject[] CreateAvatarText(string name, string text, Color color, bool outline, int fontSize, int layer)
        {
            //CreateAvatarTextContainer();

            GameObject cavGo = new GameObject(name);
            cavGo.AddComponent<Canvas>();
            cavGo.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            cavGo.AddComponent<CanvasRenderer>();
            //cavGo.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            CanvasGroup cavGroup = cavGo.AddComponent<CanvasGroup>();
            cavGroup.interactable = false;
            cavGroup.blocksRaycasts = false;

            //cavGo.AddComponent<CanvasScaler>();
            //cavGo.AddComponent<GraphicRaycaster>();
            //cav.renderMode = RenderMode.WorldSpace;
            //cav.worldCamera = camera;

            //GameObject textGo = new GameObject(text);
            //Text txt = textGo.AddComponent<Text>();
            //txt.font = SourceManager.Ins.defaultFont;
            //txt.fontSize = fontSize;
            ////RectTransform rtf = txt.GetComponent<RectTransform>();
            ////rtf.sizeDelta = new Vector2(width, height);
            //txt.color = color;
            ////txt.alignment = TextAnchor.MiddleCenter;
            //txt.text = text;
            //txt.horizontalOverflow = HorizontalWrapMode.Overflow;
            //txt.verticalOverflow = VerticalWrapMode.Overflow;
            //txt.alignment = TextAnchor.MiddleCenter;
            GameObject textname = GetText(text, color, fontSize, outline);
            
            ContentSizeFitter sizeFitter = textname.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            //cavGo.AddComponent<Shadow>().effectDistance = new Vector2(2f, -2f);

            textname.transform.SetParent(cavGo.transform);
            //textname.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

            GameObjectUtil.SetLayer(cavGo, layer);
            cavGo.transform.SetParent(avatarTextContainer.transform);
            cavGo.transform.localScale = Vector3.one * 0.01f * 1.2f;
            GameObject[] objs = new GameObject[3];
            objs[0] = cavGo;
            objs[1] = textname;
            return objs;
        }

        public GameObject CreateAvatarText(string name, GameObject go, int layer)
        {
            //CreateAvatarTextContainer();
            GameObject cavGo = new GameObject(name);
            cavGo.AddComponent<Canvas>();
            cavGo.AddComponent<CanvasRenderer>();
            CanvasGroup cavGroup = cavGo.AddComponent<CanvasGroup>();
            cavGroup.blocksRaycasts = false;
            cavGroup.interactable = false;
            go.transform.SetParent(cavGo.transform);
            GameObjectUtil.SetLayer(cavGo, layer);
            cavGo.transform.SetParent(avatarTextContainer.transform);
            cavGo.transform.localScale = Vector3.one * 0.01f*1.2f;
            go.transform.localScale = go.transform.localScale * 1f;

            return cavGo;
        }

        public GameObject CreateAvatarImage(string name,int layer)
        {
            GameObject cavGo = new GameObject(name);
            cavGo.AddComponent<Canvas>();
            cavGo.AddComponent<CanvasRenderer>();
            CanvasGroup cavGroup = cavGo.AddComponent<CanvasGroup>();
            cavGroup.blocksRaycasts = false;
            cavGroup.interactable = false;

            GameObjectUtil.SetLayer(cavGo, layer);
            cavGo.transform.SetParent(avatarTextContainer.transform);
            cavGo.transform.localScale = Vector3.one;

            return cavGo;
        }

        private GameObject GetText(string text, Color color, int fontSize, bool outline)
        {
            GameObject textGo = new GameObject(text);
            Text txt = textGo.AddComponent<Text>();
            txt.raycastTarget = false;
            txt.font = SourceManager.Ins.defaultFont;
            txt.fontSize = fontSize;
            //RectTransform rtf = txt.GetComponent<RectTransform>();
            //rtf.sizeDelta = new Vector2(width, height);
            txt.color = color;
            //txt.alignment = TextAnchor.MiddleCenter;
            //txt.transform.localPosition = Vector3.zero;
            txt.text = text;
            txt.horizontalOverflow = HorizontalWrapMode.Overflow;
            txt.verticalOverflow = VerticalWrapMode.Overflow;
            txt.alignment = TextAnchor.UpperCenter;
            if (outline)
            {
                //textGo.AddComponent<Outline>();
                Shadow shadow = textGo.AddComponent<Shadow>();
                shadow.effectColor = Color.black;
                shadow.useGraphicAlpha = false;
            }
            RectTransform rect = txt.GetComponent<RectTransform>();
            rect.pivot = new Vector2(.5f, 1);
            rect.anchoredPosition3D = new Vector3(0,.16f,0);
            //txt.transform.localPosition = Vector3.zero;
            return textGo;
        }
        
        public void Clear()
        {
            GameObject.DestroyImmediate(mAvatarTextContainer, true);
        }

        
        /*
        public void ShowAvatarText(GameObject go)
        {
            go.SetActive(true);
        }

        public void HideAvatarText(GameObject go)
        {
            go.SetActive(false);
        }

        public GameObject AddAvatarText(string uuid, GameObject go)
        {
            CreateAvatarText();
            GameObject gameObj;
            avatarTextDic.TryGetValue(uuid, out gameObj);
            if (gameObj != null)
            {
                GameObject.DestroyImmediate(gameObj, true);
                avatarTextDic.Remove(uuid);
            }

            go.transform.SetParent(avatarTextContainer.transform);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            avatarTextDic.Add(uuid, go);
            return go;
        }

        public void updateAvatarTextPosition(string uuid, Vector3 avatarPos)
        {
            if (avatarCam != null)
            {
                GameObject go;
                avatarTextDic.TryGetValue(uuid,out go);
                if (go !=null)
                {
                    //Vector3 v3 = avatarCam.WorldToScreenPoint(avatarPos);
                    //v3.z = 0f;
                    //Vector3 viewPt = UGUIConfig.UICamera.ScreenToWorldPoint(v3);
                    //viewPt = avatarTextContainer.transform.InverseTransformPoint(viewPt);
                    //go.transform.localPosition = viewPt;
                    go.transform.localPosition = avatarPos;
                }
            }
        }
        public void RemoveAvatarText(string uuid)
        {
            GameObject go;
            avatarTextDic.TryGetValue(uuid, out go);
            if (go != null)
            {
                GameObject.DestroyImmediate(go,true);
                avatarTextDic.Remove(uuid);
            }
        }
        */
    }
}

