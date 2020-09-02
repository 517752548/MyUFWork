using BetaFramework;
using DG.Tweening;
using EventUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour, IDownloadListener
{
    public CanvasGroup canvasGroupOne;
    public CanvasGroup canvasGroupTwo;
    public CanvasGroup currentGroup;

    public Texture2D defaultTex;

    protected Tweener tweenerOne;
    protected Tweener tweenerTwo;

    protected RawImage imageOne;
    protected RawImage imageTwo;

    protected GameObject particle;

    protected string currentUrl;

    private static Dictionary<string, Texture2D> m_Textures = new Dictionary<string, Texture2D>();

    private int currentIndex = 0;

    protected virtual void Start()
    {
        RestartBG();
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    public virtual void RestartBG()
    {
        imageOne = canvasGroupOne.GetComponent<RawImage>();
        imageTwo = canvasGroupTwo.GetComponent<RawImage>();

        int unlockWorld, unlockSubWorld, unlockLevel;

        if (SceneManager.GetActiveScene().name == WordScene.MainScene)
        {

           // OnBackgroundChanged(string.Format("{0}_{1}", "bg", unlockWorld%4));
        }
    }

    protected virtual void OnDestroy()
    {
    }

    protected virtual void OnBackgroundChanged(string name)
    {
        return;
        string url = string.Format("{0}.png",name);

        if (url == currentUrl)
        {
            return;
        }

        currentUrl = url;
        Texture2D texture = null;
        if (m_Textures.TryGetValue(url, out texture))
        {
            OnTextureLoaded(texture);
            return;
        }
        ResourceManager.LoadAsync<Texture2D>(url,  ( go) =>
        {
            
            if (!m_Textures.ContainsKey(url))
            {
                m_Textures.Add(url, go);
            }
            OnTextureLoaded(go);
        });
        //StartCoroutine(LoadStreamAssetsTexture(url));
        //AppEngine.SDownloadManager.GetBytes(this, url, true);
    }

    protected virtual void OnTextureLoaded(Texture2D texture)
    {
        if (tweenerOne != null) tweenerOne.Kill();
        if (tweenerTwo != null) tweenerTwo.Kill();

        if (currentGroup == canvasGroupOne)
        {
            if (imageTwo == null)
            {
                return;
            }
            imageTwo.texture = texture;
            canvasGroupTwo.alpha = 0;
            canvasGroupTwo.transform.SetAsLastSibling();

            tweenerTwo = canvasGroupTwo.DOFade(1, 0.1f).OnComplete(() => { canvasGroupOne.alpha = 0; imageOne.texture = null; });
            currentGroup = canvasGroupTwo;
        }
        else
        {
            if (imageOne == null)
            {
                return;
            }
            imageOne.texture = texture;
            canvasGroupOne.alpha = 0;
            canvasGroupOne.transform.SetAsLastSibling();

            tweenerOne = canvasGroupOne.DOFade(1, 0.1f).OnComplete(() => { canvasGroupTwo.alpha = 0; imageTwo.texture = null; });
            currentGroup = canvasGroupOne;
        }
    }

    public void OnError(int transactionId, string errorMessage)
    {
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        if (bytes.Length == 0)
            return;

        var texture = new Texture2D(1280, 720, TextureFormat.RGB24, false);
        texture.LoadImage(bytes);

        OnTextureLoaded(texture);
    }

    private IEnumerator LoadStreamAssetsTexture(string url)
    {
        Texture2D texture = null;
        if (m_Textures.TryGetValue(url, out texture))
        {
            OnTextureLoaded(texture);
            yield break;
        }

        string absUrl = PathTool.GetPath(ResLoadLocation.Streaming) + url;

        WWW www = new WWW(absUrl);

        yield return www;

        if (www.isDone && www.texture != null)
        {
            OnTextureLoaded(www.texture);

            if (!m_Textures.ContainsKey(url))
            {
                m_Textures.Add(url, www.texture);
            }
        }
    }
}