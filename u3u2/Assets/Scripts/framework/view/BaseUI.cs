using app.avatar;
using app.db;
using app.pet;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class BaseUI : AbsMonoBehaviour
{
    public string uiPath { get; private set; }
    public string uiName { get; set; }
    public bool hasSubUI { get; set; }
    public bool avatarRotatable { get; set; }
    public bool avatarPlayAnim { get; set; }
    public GameObject ui { get; protected set; }
    protected UIAvatarBase avatarBase;
    //是否已经初始化
    public bool hasInit { get; private set; }

    public bool isHidden { get; private set; }

    private string canvasName;
    private List<string> mInpuList;
    private InputField mCurInputField;
    protected Vector2 mShowPos;
    //不根据位置隐藏
    protected bool ignorePositionShow = false;

    /// <summary>
    /// ui层级
    /// </summary>
    public WndType UILayer { get; private set; }

    public UIAvatarBase GetAvatarBase()
    {
        return avatarBase;
    }

    public BaseUI()
    {
        avatarRotatable = true;
        avatarPlayAnim = true;
    }

    public void initUILayer()
    {
        UILayer = (WndType)(ui.layer - LayerConfig.MainUI);
    }

    public Canvas GetMyLayerCanvas()
    {
        return UGUIConfig.GetCanvasByWndType(UILayer);
    }

    public Camera GetMyLayerCamera()
    {
        return UGUIConfig.GetCameraByWndType(UILayer);
    }

    public InputField CreateInputField(Color textColor, int fontSize, Image parentGo,
        bool multiLine = false, InputField.InputType inputType = InputField.InputType.Standard, float xoffset = 0f, float yoffset = 0f,bool openValueChange=false)
    {
        //手动创建输入框
        InputField inputText = new GameObject().AddComponent<InputField>();
        //inputText.name = "inputText";
        inputText.transform.SetParent(parentGo == null ? ui.transform : parentGo.transform);
        RectTransform inputRTF = inputText.gameObject.AddComponent<RectTransform>();
        inputText.transform.localScale = Vector3.one;
        inputRTF.anchorMin = Vector2.zero;
        inputRTF.anchorMax = Vector2.one;
        inputRTF.sizeDelta = Vector2.zero;
        inputText.inputType = inputType;
        inputText.selectionColor = new Color(186 / 255f, 155 / 255f, 119 / 255f, 200 / 255f);
        if (openValueChange)
        {inputText.onValueChange.AddListener(InputFieldChange);}
        inputText.onEndEdit.AddListener(InputFieldEndEitor);
        inputRTF.anchoredPosition = new Vector2(xoffset, yoffset);
        EventTriggerListener.Get(inputText.gameObject).onClick = InputFieldOnClick;

        Text t = new GameObject().AddComponent<Text>();
        //t.name = "text";
        t.color = textColor;
        t.alignment = TextAnchor.MiddleCenter;
        t.supportRichText = false;
        t.font = SourceManager.Ins.defaultFont;
        t.fontStyle = FontStyle.Normal;
        t.fontSize = fontSize;
        t.transform.SetParent(inputText.transform);
        t.transform.localScale = Vector3.one;
        RectTransform trtf = t.GetComponent<RectTransform>();
        trtf.anchorMin = Vector2.zero;
        trtf.anchorMax = Vector2.one;
        trtf.anchoredPosition = Vector2.zero;
        trtf.sizeDelta = Vector2.zero;

        //Text t2 = new GameObject().AddComponent<Text>();
        //t2.name = "text";
        //t2.color = textColor;
        //t2.alignment = TextAnchor.UpperLeft;
        //t2.supportRichText = false;
        //t2.font = SourceManager.Ins.defaultFont;
        //t2.fontStyle = FontStyle.Normal;
        //t2.fontSize = fontSize;
        //t2.transform.SetParent(inputText.transform);
        //t2.transform.localScale = Vector3.one;
        //RectTransform trtf2 = t2.GetComponent<RectTransform>();
        //trtf2.anchorMin = Vector2.zero;
        //trtf2.anchorMax = Vector2.one;
        //trtf2.anchoredPosition = Vector2.zero;
        //trtf2.sizeDelta = Vector2.zero;

        inputText.textComponent = t;
        //inputText.placeholder = t2;
        inputText.targetGraphic = parentGo;
        inputText.lineType = multiLine ? InputField.LineType.MultiLineNewline : InputField.LineType.SingleLine;
        changeChildLayer(inputText.gameObject, parentGo == null ? ui.layer : parentGo.gameObject.layer);
        return inputText;
    }

    private void InputFieldOnClick(GameObject obj)
    {
        if (mInpuList != null) mInpuList = null;
        mInpuList = new List<string>();
        mInpuList.Clear();
        mCurInputField = obj.GetComponent<InputField>();
    }

    private void InputFieldChange(string s)
    {
        if (s.Contains("System.Collections.Generic.List"))
        {
            s = "";
        }
        if (mInpuList == null) mInpuList = new List<string>();
        if (mInpuList.Count > 3) mInpuList.RemoveAt(0);
        mInpuList.Add(s);
        //ClientLog.LogError("-------------------------------zhaohaoChange:" + s);
    }

    private void InputFieldEndEitor(string s)
    {
        if (mInpuList == null || mCurInputField == null)
        {
            return;
        }
        //ClientLog.LogError("-------------------------------zhaohaoEndEitor:" + s);
        if (mInpuList.Count >= 3 && mInpuList[mInpuList.Count - 1].Trim() == ""
            /*&& mInpuList[1].Length > mInpuList[0].Length*/)
        {
            //ClientLog.LogError("-------------------------------强制设置3" + mInpuList[mInpuList.Count - 2]);
            mCurInputField.text = mInpuList[mInpuList.Count - 2];

        }
        if (mInpuList.Count >= 2)
        {
            if (mInpuList.Count == 2 && mInpuList[mInpuList.Count - 1].Trim() == "")
            {
                //ClientLog.LogError("-------------------------------强制设置3"+mInpuList[mInpuList.Count - 2]);
                mCurInputField.text = mInpuList[mInpuList.Count - 2];
            }
            if (mInpuList.Count >= 3 && mInpuList[1].Length == 1 && mInpuList[2].Trim() == "")
            {
                mCurInputField.text = "";
            }
        }
        if (mInpuList.Count >= 1)
        {

            if (mInpuList.Count == 1 && mInpuList[mInpuList.Count - 1].Trim() == "")
            {
                ClientLog.LogError("-------------------------------强制设置1"+mInpuList[0]);
                mCurInputField.text = mInpuList[0];
            }
        }
        mInpuList.Clear();
    }

    /// <summary>
    /// 获取场景中对象上挂的脚本
    /// </summary>
    /// <typeparam name="T">脚本类型</typeparam>
    /// <param name="componentPath">组件</param>
    /// <returns></returns>
    public T getComponent<T>(string componentPath) where T : MonoBehaviour
    {
        if (!componentPath.StartsWith("/"))
        {
            componentPath = "/" + componentPath;
        }

        GameObject go = GameObject.Find(canvasName + "/" + uiName + componentPath);

        if (go == null)
        {
            ClientLog.LogError("getComponent获取GameObject为空，路径：" + uiName + componentPath);
        }
        return go.GetComponent<T>();
    }

    /// <summary>
    /// 修改所有子物体的层级
    /// </summary>
    /// <param name="go"></param>
    /// <param name="layerConfigInt"></param>
    public void changeChildLayer(GameObject go, int layerConfigInt)
    {
        GameObjectUtil.SetLayer(go, layerConfigInt);
    }
    /// <summary>
    /// 设置显示在最上层
    /// </summary>
    /// <param name="go"></param>
    public void setAsLastSibling(GameObject go)
    {
        if (go != null)
        {
            go.transform.SetAsLastSibling();
        }
    }

    /// <summary>
    /// 设置显示在最下层
    /// </summary>
    /// <param name="go"></param>
    public void setAsFirstSibling(GameObject go)
    {
        if (go != null)
        {
            go.transform.SetAsFirstSibling();
        }
    }

    private RMetaEvent preLoadParam = null;

    public void preLoadUI(RMetaEvent e = null)
    {
        isHidden = false;
        preLoadParam = e;
        if (uiName != null)
        {
            uiPath = PathUtil.Ins.GetUIPath(uiName);
            //GameClient.ins.SimpleLoad(uiPath, loadResourceCompleteHandler, !hasSubUI, true);
            LoadArgs loadArgs = LoadArgs.NONE;
            if (!hasSubUI)
            {
                loadArgs = LoadArgs.SLIMABLE;
            }
            SourceLoader.Ins.load(uiPath, loadResourceCompleteHandler, null, (e != null) ? e.data : null, false, loadArgs);
        }
        else
        {
            show(e);
        }
    }

    public virtual void show(RMetaEvent e = null)
    {
        isHidden = false;
        if (uiName != null && ui != null)
        {
            /*
            if (!ui.activeSelf)
            {
                ui.SetActive(true);
            }
            */
            Canvas cv = UGUIConfig.GetCanvasByWndType(UILayer);
            if (this.ui.transform.parent != cv.transform)
            {
                this.ui.transform.SetParent(cv.transform);
                if(!this.ui.active){
                    this.ui.SetActive(true);
                }
            }
            RectTransform rt = this.ui.GetComponent<RectTransform>();
            if (rt.anchoredPosition != mShowPos)
            {
                rt.anchoredPosition = mShowPos;
            }
            ShowAvatarModel();

            ui.transform.SetAsLastSibling();
            if (avatarBase != null)
            {
                //avatarBase.SetActive(true);
                avatarBase.ResetRot();
                /*
                if (mAvatarAnim != null)
                {
                    mAvatarAnim.Play(AvatarBase.ANIM_NAME_IDLE);
                    mAvatarAnimName = AvatarBase.ANIM_NAME_IDLE;
                    mAvatarPlayIdleTime = Time.time;
                }
                */
            }
            //object[] parms = new object[1];
            //_ui.name = ui_path;
            //parms[0] = _ui;
            //Type type = this.GetType();
            //type.InvokeMember(ui_fieldInfoName, BindingFlags.SetField, null, this, parms);
        }
        //ui已经创建完毕，执行初始化操作
        if (hasInit == false)
        {
            initUI();
        }
        if (LogPanel.Ins.ui != null)
        {
            LogPanel.Ins.changeSibling();
        }
    }

    /// <summary>
    /// 初始化界面
    /// </summary>
    public virtual void initUI()
    {
        hasInit = true;
    }

    public void loadResourceCompleteHandler(RMetaEvent e)
    {
        //ClientLog.Log("UILoadCost:" + (Time.unscaledTime - mTempTime));
        if (uiName != null)
        {
            initlizeUI(e);
        }
    }

    public void initlizeUI(RMetaEvent e)
    {
        if (ui)
        {
            show(preLoadParam);
        }
        else
        {
            UICreator.ins.CreateUI(this, true);
        }
    }

    public void OnUICreated(GameObject ui, RMetaEvent e = null)
    {
        //ClientLog.Log("UICreateCost:" + (Time.unscaledTime - mTempTime));

        if (this.ui != null)
        {
            //已经创建过的ui，避免再次创建
            SourceManager.Ins.removeReference(uiPath, ui);
            ui = null;
            return;
        }

        this.ui = ui;
        //_ui = SourceManager.Ins.createObjectFromAssetBundle(uiPath);
        if (ui == null)
        {
            ClientLog.LogError("ui == null! uiPath:::" + uiPath);
        }
        else
        {
            initUILayer();

            Vector3 v3 = this.ui.GetComponent<RectTransform>().anchoredPosition3D;
            Vector2 v2 = this.ui.GetComponent<RectTransform>().anchoredPosition;
            Vector2 offsetMin = this.ui.GetComponent<RectTransform>().offsetMin;
            Vector2 offsetMax = this.ui.GetComponent<RectTransform>().offsetMax;
            Vector2 anchorMin = this.ui.GetComponent<RectTransform>().anchorMin;
            Vector2 anchorMax = this.ui.GetComponent<RectTransform>().anchorMax;
            Canvas cv = UGUIConfig.GetCanvasByWndType(UILayer);
            this.ui.transform.SetParent(cv.transform);
            canvasName = cv.name;
            //ui.changeChildLayer(go, LayerConfig.MainUI + (int)ui.UILayer);
            this.ui.GetComponent<RectTransform>().anchorMin = anchorMin;
            this.ui.GetComponent<RectTransform>().anchorMax = anchorMax;
            this.ui.GetComponent<RectTransform>().offsetMin = offsetMin;
            this.ui.GetComponent<RectTransform>().offsetMax = offsetMax;
            this.ui.GetComponent<RectTransform>().anchoredPosition3D = v3;
            this.ui.GetComponent<RectTransform>().anchoredPosition = v2;
            this.ui.transform.localScale = Vector3.one;
            //_ui.SetActive(false);
            mShowPos = v2;
            initlizeUI(e);
        }
    }

    //private Pet petModelData;

    //private PetTemplate roleTemplate;
    /// <summary>
    /// 添加宠物模型到UI上
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="avatarModelName"></param>
    public void AddPetModelToUI(Vector3 pos, Vector3 rot, Vector3 scale,
        Pet pet, GameObject avatarModelParentv = null)
    {
        /*
        petModelData = pet;
        AddAvatarModelToUI(pos,rot,scale,pet.getTpl().modelId,avatarModelParentv);
        */
        if (avatarBase == null)
        {
            avatarBase = new UIAvatarBase(this);
        }
        avatarBase.Init(pet, pos, rot, scale, avatarModelParentv == null ? ui.transform : avatarModelParentv.transform);
        
    }
    /// <summary>
    /// 添加宠物模型到UI上
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="avatarModelName"></param>
    public void AddPetModelToUI(Vector3 pos, Vector3 rot, Vector3 scale,
        PetTemplate pettpl, GameObject avatarModelParentv = null)
    {
        /*
        petModelData = pet;
        AddAvatarModelToUI(pos,rot,scale,pet.getTpl().modelId,avatarModelParentv);
        */
        if (avatarBase == null)
        {
            avatarBase = new UIAvatarBase(this);
        }
        avatarBase.Init(pettpl,pos, rot, scale, avatarModelParentv == null ? ui.transform : avatarModelParentv.transform);

    }
    /// <summary>
    /// 添加角色模型到UI上
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="avatarModelName"></param>
    public void AddRoleModelToUI(Vector3 pos, Vector3 scale,
        PetTemplate role, GameObject avatarModelParentv = null,EquipItemTemplate weaponTpl = null)
    {
        /*
        roleTemplate = role;
        AddAvatarModelToUI(pos, Vector3.zero, scale, role.modelId, avatarModelParentv);
        */
        if (avatarBase == null)
        {
            avatarBase = new UIAvatarBase(this);
        }
        avatarBase.Init(role, pos,Vector3.zero, scale, avatarModelParentv == null ? ui.transform : avatarModelParentv.transform,weaponTpl);
    }

    /// <summary>
    /// 添加角色模型到UI上
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="avatarModelName"></param>
    public void AddAvatarModelToUI(Vector3 pos, Vector3 rot, Vector3 scale,
        string avatarModelNamev, GameObject avatarModelParentv = null,EquipItemTemplate weaponTpl = null, bool showVariatedSkin = false,bool showshadow=true)
    {
        if (avatarBase == null)
        {
            avatarBase = new UIAvatarBase(this);
        }
        avatarBase.Init(avatarModelNamev, pos, rot, scale, avatarModelParentv == null ? ui.transform : avatarModelParentv.transform, weaponTpl, showshadow, showVariatedSkin);
    }

    public void UpdateAvatarWeapon(EquipItemTemplate weaponTpl)
    {
        if (avatarBase != null)
        {
            avatarBase.ShowWeapon(weaponTpl);
        }
    }

    /// <summary>
    /// 移除角色模型
    /// </summary>
    public void RemoveAvatarModel()
    {
        if (avatarBase != null)
        {
            avatarBase.Destroy();
            avatarBase = null;
        }
        /*
        if (avatarBase != null)
        {
            avatarBase.SetActive(false);
        }
        */
    }

    public void ShowAvatarModel()
    {
        if (avatarBase != null && isShown)
        {
            avatarBase.SetActive(true);
        }
    }

    public void HideAvatarModel()
    {
        if (avatarBase != null)
        {
            avatarBase.SetActive(false);
        }
    }

    public virtual void hide(RMetaEvent e = null)
    {
        if (ui != null)
        {
            //ui.SetActive(false);
            Canvas cv = UGUIConfig.GetCanvasByWndType(WndType.INVISIBLE);
            this.ui.transform.SetParent(cv.transform);
            this.ui.SetActive(false);
            ///将界面移出屏幕位置，否则滚动条会接收点击，遮挡物体///
            //this.ui.transform.localPosition = new Vector3(mShowPos.x, mShowPos.y + UGUIConfig.UISpaceHeight, mShowPos.z);
            HideAvatarModel();
        }
        /*
        if (avatarBase != null)
        {
            avatarBase.SetActive(false);
        }
        */
        isHidden = true;
        //dispose();
    }

    /// <summary>
    /// 回收
    /// </summary>
    public virtual void Destroy()
    {
        RemoveAvatarModel();

        Singleton.RemoveObj(this.GetType());

        if (ui != null)
        {
            GameObject.DestroyImmediate(ui, true);
            ui = null;
            if (!string.IsNullOrEmpty(uiName))
            {
                //SourceManager.Ins.UnloadAssetBundle(PathUtil.Ins.GetUIPath(ui_path));
                SourceManager.Ins.removeReference(PathUtil.Ins.GetUIPath(uiName), null, true);
            }
        }
        //petModelData = null;
        //roleTemplate = null;
        hasInit = false;
    }

    public bool isShown
    {
        get
        {
            if (ui != null)
            {
                if (ignorePositionShow)
                {
                    return ui.activeSelf && GetCurrentCanvas() != UGUIConfig.GetCanvasByWndType(WndType.INVISIBLE);
                }
                else
                {
                    return ui.activeSelf && ui.GetComponent<RectTransform>().anchoredPosition == mShowPos && GetCurrentCanvas() != UGUIConfig.GetCanvasByWndType(WndType.INVISIBLE);
                }
            }
            return false;
        }
    }

    private Canvas GetCurrentCanvas()
    {
        if (ui != null)
        {
            Transform trans = ui.transform.parent;
            while (trans.parent != null)
            {
                trans = trans.parent;
            }
            return trans.gameObject.GetComponent<Canvas>();
        }
        return null;
    }

    public string CanvasName
    {
        set { canvasName = value; }
    }

    public RMetaEvent PreLoadParam
    {
        get { return preLoadParam; }
    }

    public override void Update()
    {
        base.Update();
        if (avatarBase != null)
        {
            avatarBase.Update();
        }
    }

    public void SetChildVisible(GameObject child, bool value)
    {
        if (child != null)
        {
            child.SetActive(value);
        }
    }

    public void SetChildVisible(MonoBehaviour child, bool value)
    {
        if (child != null)
        {
            child.gameObject.SetActive(value);
        }
    }

    public void SetChildVisible(UIMonoBehaviour child, bool value)
    {
        if (child != null)
        {
            if (value)
            {
                child.Show();
            }
            else
            {
                child.Hide();
            }
        }
    }

}