using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadItem : MonoBehaviour {
    public Toggle toggle;
    public GameObject fbAddBtn;
    public Image headImage;
    public GameObject fbFlag;

    private int index;
    private Action<int> callback;

    public void InitFBImage(int index, bool isFbLogin, byte[] bytes, ToggleGroup toggleGroup, Action<int> selCahngeListener)
    {
        fbAddBtn.SetActive(!isFbLogin);
        fbFlag.SetActive(isFbLogin);
        if (bytes == null)
        {
            headImage.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            try
            {
                Vector2 size = headImage.gameObject.GetComponent<RectTransform>().sizeDelta;
                var texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
                texture.LoadImage(bytes);

                headImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                                            new Vector2(0.5f, 0.5f));
                headImage.transform.parent.gameObject.SetActive(true);
            }
            catch (System.Exception ex)
            {
                LoggerHelper.Exception(ex);
                headImage.transform.parent.gameObject.SetActive(false);
            }
        }
        Init(selCahngeListener, index, toggleGroup);
    }

    public void InitLocalHeadImage(int index, Sprite sprite, ToggleGroup toggleGroup, Action<int> selCahngeListener)
    {
        fbAddBtn.SetActive(false);
        fbFlag.SetActive(false);
        headImage.sprite = sprite;
        headImage.transform.parent.gameObject.SetActive(true);
        Init(selCahngeListener, index, toggleGroup);
    }

    private void Init(Action<int> selCahngeListener, int index, ToggleGroup toggleGroup)
    {
        this.callback = selCahngeListener;
        this.index = index;
        toggle.group = toggleGroup;
        transform.SetParent(toggleGroup.transform,false);
        transform.localScale = Vector3.one;
        toggle.onValueChanged.AddListener(OnSelChanged);
    }

    public void ClickFbLogin()
    {
        UIManager.OpenUIAsync(ViewConst.prefab_FBSignInDialog, OpenType.Replace);
    }

	public void OnSelChanged(bool sel)
    {
        if (sel && callback != null)
        {
            callback(index);
        }
    }
}
