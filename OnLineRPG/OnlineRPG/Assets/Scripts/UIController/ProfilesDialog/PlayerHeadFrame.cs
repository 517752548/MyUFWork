using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeadFrame : MonoBehaviour, IDownloadListener
{
    public Image headerImage;
    public Transform frameContent;

    public bool IsSelf = true;
    public bool ToShowProfile = false;

    private string url = null;
    private int frameId = -1;
    private string curUrl = null;
    private bool loadLocalHead = false;
    private string userId = "";

    // Start is called before the first frame update
    void Start()
    {
        UpdateContent();
        if (IsSelf)
        {
            EventUtil.EventDispatcher.AddEventListener("", UpdateContent);
            EventUtil.EventDispatcher.AddEventListener(GlobalEvents.HeadChanged, UpdateContent);
        }
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EventUtil.EventDispatcher.RemoveEventListener("", UpdateContent);
        EventUtil.EventDispatcher.RemoveEventListener(GlobalEvents.HeadChanged, UpdateContent);
    }

    public void OnClick()
    {
        if (ToShowProfile)
        {
//            if (IsSelf)
                //GiftDisplayDialog.DisplayGifts(
                //    new GiftSet((int)LocalItem.Coin, 0)
                //    .Append((int)LocalItem.Hint2, 0)
                //    .Append((int)OnLineItem.Exp, 0)
                //    .Append((int)OnLineItem.HeadBG, 1)
                //    .Append((int)OnLineItem.WordDisk, 1)
                //    .Append((int)OnLineItem.BG, 1)
                //    .Append((int)OnLineItem.NormalPet, 1001), null);
//                PlayerProfilesDialog.ShowOwnProfile();
//            else
//                PlayerProfilesDialog.ShowOtherProfile(userId);
        }

    }

    public void SetData(string headUrl, int frameId, bool isSelf, string userId = "")
    {
        url = headUrl;
        IsSelf = isSelf;
        if (!isSelf) this.userId = userId;
        this.frameId = frameId;
        UpdateContent();
    }

    private void UpdateContent()
    {
        if (IsSelf && Record.HasFile(PrefKeys.FaceBookImageCache))
        {
            if (!loadLocalHead)
            {
                byte[] bytes = Record.LoadFileByBytes(PrefKeys.FaceBookImageCache);
                SetFBHeadImage(bytes);
                loadLocalHead = true;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(url) && (curUrl == null || !curUrl.Equals(url)))
            {
                curUrl = url;
                AppEngine.SDownloadManager.GetBytes(this, url);
            }
        }

//        if (IsSelf && frameId < 0)
//        {
//            frameId = DataManager.OnLineData.GetItemNumber(OnLineItem.UserInfo, (int)UserInfo.HeadBGID);
//            if (frameId == 0) frameId = 1;
//        }

		//var d = AppEngine.SConfigManager.GetExcelDataItem<WordHeadFrame_Data>(ViewConst.asset_WordHeadFrame_1, frameId.ToString());
		//AppEngine.SResourceManager.petLoadManager.LoadOnLineBundleAsync<GameObject>(d.Thumb, (GameObject obj) => { 
		//	if (obj != null) {
		//		Instantiate(obj, frameImage.transform);
		//	}
		//});
//        CommandChannel.GetInstance().PostParamCommand<SkinTab, int, Action<GameObject>>(SkinReplaceCommandGroup.GetPrefab,
//            SkinTab.Frames, frameId, (GameObject obj) =>
//            {
//                if (obj != null)
//                {
//                    Instantiate(obj, frameContent, false);
//                }
//            });
    }

    public void OnError(int transactionId, string errorMessage)
    {
        curUrl = null;
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        SetFBHeadImage(bytes);
        if (IsSelf && bytes != null && bytes.Length > 0)
        {
            Record.SaveStringInFileAnsy(bytes, PrefKeys.FaceBookImageCache);
        }
    }

    private void SetFBHeadImage(byte[] bytes)
    {
        try
        {
            Vector2 size = headerImage.gameObject.GetComponent<RectTransform>().sizeDelta;
            var texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
            texture.LoadImage(bytes);

            headerImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                                        new Vector2(0.5f, 0.5f));
        }
        catch (System.Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }
}
