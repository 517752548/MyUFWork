using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class WebRequestPostUtility : MonoBehaviour
{

    public static WebRequestPostUtility Instance;

    enum RequestType
    {
        TEXT_GET,
        TEXTUREE_GET,
        ASSETBUNDEL,
        POST_FORM,
        POST_URLENCODED,
        POST_JSON,
        POST_XML
    }

    class PostContent
    {
        public WWWForm formData;
        public string stringContent;

        public PostContent(WWWForm formData)
        {
            this.formData = formData;
        }

        public PostContent(string text)
        {
            this.stringContent = text;
        }
    }

    public void Get(string url,Action<UnityWebRequest> action,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url,action,RequestType.TEXT_GET,headers));
    }

    public void GetTexture(string url,Action<UnityWebRequest> action,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.TEXTUREE_GET,headers));
    }

    public void GetAssetBundle(string url,Action<UnityWebRequest> action,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.ASSETBUNDEL,headers));
    }

    public void Post(string url, Action<UnityWebRequest> action, WWWForm formData,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.POST_FORM,headers, new PostContent(formData)));
    }

    public void PostUrlEncoded(string url,Action<UnityWebRequest> action,string json,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.POST_URLENCODED,headers,new PostContent(json)));
    }

    public void PostJson(string url, Action<UnityWebRequest> action, string json,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.POST_JSON,headers, new PostContent(json)));
    }

    public void PostXml(string url, Action<UnityWebRequest> action, string json,Dictionary<string,string> headers = null)
    {
        StartCoroutine(Request(url, action, RequestType.POST_XML, headers,new PostContent(json)));
    }

    IEnumerator Request(string url,Action<UnityWebRequest> action,RequestType type,Dictionary<string,string> headers, PostContent postContent =null)
    {
        UnityWebRequest webRequest = null;

        switch (type)
        {
            case RequestType.TEXT_GET:
                webRequest = UnityWebRequest.Get(url);
                break;
            case RequestType.TEXTUREE_GET:
                webRequest = UnityWebRequestTexture.GetTexture(url);
                break;
            case RequestType.ASSETBUNDEL:
                webRequest = UnityWebRequestAssetBundle.GetAssetBundle(url);
                break;
            case RequestType.POST_FORM:
                webRequest = UnityWebRequest.Post(url, postContent.formData); 
                break;
            case RequestType.POST_URLENCODED:
                webRequest = CreatUnityWebRequest(url,postContent.stringContent,"application/x-www-form-urlencoded");
                //可以不进行设置，此时默认为urlencoded
                break;
            case RequestType.POST_JSON:
                webRequest = CreatUnityWebRequest(url,postContent.stringContent,"application/json");
                break;
            case RequestType.POST_XML:
                webRequest = CreatUnityWebRequest(url,postContent.stringContent,"text/xml");
                break;
            default:
                break;
        }

        if(webRequest==null)
        {
            Debug.Log("WebRequest initialise error");
            yield break;
        }

        if (headers != null)
        {
            foreach (string headersKey in headers.Keys)
            {
                webRequest.SetRequestHeader(headersKey,headers[headersKey]);
            } 
        }
        yield return webRequest.SendWebRequest();

        action?.Invoke(webRequest);

        action = null;
        webRequest.Dispose();
        webRequest = null;
        Resources.UnloadUnusedAssets();
    }

    private UnityWebRequest CreatUnityWebRequest(string url,string data,string contentType)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.uploadHandler = (UploadHandler) new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
        webRequest.uploadHandler.contentType = contentType;
        webRequest.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        return webRequest;
    }
    private void Awake()
    {
        Instance = this;
    }
}