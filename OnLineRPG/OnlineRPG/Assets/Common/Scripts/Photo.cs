using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using BetaFramework;

public class Photo : MonoBehaviour, IDownloadListener
{
    public Image photo;

    [HideInInspector]
    public string url;
    [HideInInspector]
    public Sprite sprite;

    [HideInInspector]
    public int width, height;

    protected int realWidth, realHeight;
    public Action<Texture2D> onPhotoLoaded;

    public void SetSize(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void SetRealSize(int realWidth, int realHeight)
    {
        this.realWidth = realWidth;
        this.realHeight = realHeight;
    }

    public virtual void Load(bool usecache = false)
    {
        if ((!string.IsNullOrEmpty(url)) && url.Contains("head_"))
        {
            ResourceManager.LoadAsync<Sprite>(string.Format("championships_{0}.png", url), op =>
           {
               photo.sprite = op;
           });
            return;
        }
        if (sprite != null)
        {
            photo.sprite = sprite;
            return;
        }

        if (usecache && Record.HasFile(PrefKeys.FaceBookImageCache))
        {
            OnSuccess(0, Record.LoadFileByBytes(PrefKeys.FaceBookImageCache));
        }
        else
            AppEngine.SDownloadManager.GetBytes(this, url);
    }



    protected virtual void OnPhotoLoaded(Texture2D sprite)
    {
        if (onPhotoLoaded != null) onPhotoLoaded(sprite);
    }

    public void OnError(int transactionId, string errorMessage)
    {
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        try
        {
            var texture = new Texture2D(width, height, TextureFormat.RGB24, false);
            texture.LoadImage(bytes);

            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                                        new Vector2(0.5f, 0.5f)); ;
            photo.sprite = sprite;
            sprite = null;
            OnPhotoLoaded(texture);
        }
        catch (Exception ex)
        {
            LoggerHelper.Exception(ex);
        }

    }
}