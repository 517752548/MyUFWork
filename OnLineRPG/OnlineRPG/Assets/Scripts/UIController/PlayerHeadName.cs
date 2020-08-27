using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BetaFramework;
using System;

public class PlayerHeadName : MonoBehaviour, IDownloadListener
{
    public Button headBtn;
    public Image headImane;
    public InputField nameInput;
    public Button clearEditBtn;
    public Button startEditBtn;

    private string fbUserId, fbHeadUrl, nickName;
    private int headIndex;
    private bool isSelfInfo;

    public void Init(bool isSelf, string fbId, string fbHeadUrl, string name, int headIndex)
    {
        this.isSelfInfo = isSelf;
        this.headIndex = headIndex;
        this.fbUserId = fbId;
        this.fbHeadUrl = fbHeadUrl;
        this.nickName = name;

        nameInput.onEndEdit.RemoveAllListeners();
        nameInput.text = string.IsNullOrEmpty(name) ? "NoName" : name;
        if (isSelf)//展示自己的信息，可以修改名字、改头像
        {
            startEditBtn.gameObject.SetActive(true);
            clearEditBtn.gameObject.SetActive(false);
            headBtn.interactable = true;
            headBtn.onClick.RemoveAllListeners();
            headBtn.onClick.AddListener(ClickHead);
            nameInput.onEndEdit.AddListener(onEndEdit);
            startEditBtn.onClick.RemoveAllListeners();
            startEditBtn.onClick.AddListener(ClickNameEditor);
            clearEditBtn.onClick.RemoveAllListeners();
            clearEditBtn.onClick.AddListener(ClickClearEditor);
        }
        else//展示其他玩家的信息，不能显示修改名字、改头像UI
        {
            headBtn.interactable = false;
            nameInput.enabled = false;
            startEditBtn.gameObject.SetActive(false);
            clearEditBtn.gameObject.SetActive(false);
            startEditBtn.onClick.RemoveAllListeners();
            clearEditBtn.onClick.RemoveAllListeners();
        }

        UpdateHeadImage();
    }

    private void UpdateHeadImage()
    {
        if (headIndex == 0)
        {
            if (isSelfInfo && Record.HasFile(PrefKeys.FaceBookImageCache))
            {
                byte[] bytes = Record.LoadFileByBytes(PrefKeys.FaceBookImageCache);
                SetFBHeadImage(bytes);
            }
            else
            {
                AppEngine.SDownloadManager.GetBytes(this, fbHeadUrl);
            }
        }
        else
        {
            //headImane.sprite = DataManager.PlayerData.GetHeaderIcon(headIndex - 1);
        }
    }

    private void ClickNameEditor()
    {
        startEditBtn.gameObject.SetActive(false);
        nameInput.selectionFocusPosition = nameInput.text.Length - 1;
        nameInput.ActivateInputField();
        clearEditBtn.gameObject.SetActive(true);
        nameInput.textComponent.alignment = TextAnchor.MiddleLeft;
    }

    private void ClickClearEditor()
    {
        nameInput.text = "";
    }

    private void onEndEdit(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;
        nameInput.textComponent.alignment = TextAnchor.MiddleCenter;
        clearEditBtn.gameObject.SetActive(false);
        startEditBtn.gameObject.SetActive(true);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.NickNameChanged);
    }

    private void ClickHead()
    {
        //展示头像选择面板
//        UIManager.OpenUIAsync(ViewConst.prefab_ProfilesPhotoDialog, OpenType.Over, null, (Action<int>)OnChooseHeadImage);
    }



    //private void OnLoginFB()
    //{
    //    ButtonCD.DoButtonCD(fbLogin, 2f);
    //    UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog, OpenType.Replace);
    //}

    public void OnError(int transactionId, string errorMessage)
    {
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        SetFBHeadImage(bytes);
        if (isSelfInfo && bytes != null && bytes.Length > 0)
        {
            Record.SaveStringInFileAnsy(bytes, PrefKeys.FaceBookImageCache);
        }
    }

    private void SetFBHeadImage(byte[] bytes)
    {
        try
        {
            Vector2 size = headImane.gameObject.GetComponent<RectTransform>().sizeDelta;
            var texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
            texture.LoadImage(bytes);

            headImane.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                                        new Vector2(0.5f, 0.5f));
        }
        catch (System.Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }
}
