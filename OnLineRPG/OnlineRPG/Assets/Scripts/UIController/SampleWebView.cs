/*
 * Copyright (C) 2012 GREE, Inc.
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using BetaFramework;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SampleWebView : MonoBehaviour
{
    private const string startPage = "faqStart.html";
    private const string errorPage = "faq404.html";
    private List<string> localPages = new List<string>() { startPage, errorPage };
    private const string Format = "{{\"device_id\":\"{0}\",\"mobile_type\":\"{1}\",\"os_version\":\"{2}\",\"game_version\":\"{3}\", \"game_package\":\"{4}\",\"language\":\"{5}\",\"location\":\"{6}\",\"player_tag\":\"{7}\", \"player_gold\":\"{8}\",\"player_item_gold\":\"{9}\",\"player_login_days\":\"{10}\",\"player_level\":\"{11}\",\"is_pay\":\"{12}\"}}";
    private string ContactUs = "https://fonlinewgl.wordzhgame.net/faq/contact.html";
    private WebViewObject webViewObject;
    public Action<int> closeAction;
    public Action showContact;
    public Action hiddenContact;

    private IEnumerator Start()
    {
        yield return CreateWebViewObject();
    }

    private IEnumerator CreateWebViewObject()
    {
        foreach (var url in localPages)
        {
            var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
            var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
            byte[] result = null;
            if (src.Contains("://"))
            {  // for Android
                var www = new WWW(src);
                yield return www;
                result = www.bytes;
                Debug.Log("www error " + www.error + " ---- " + result.Length);
            }
            else
            {
                result = System.IO.File.ReadAllBytes(src);
            }
            System.IO.File.WriteAllBytes(dst, result);
        }

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.gameObject.SetActive(false);
        webViewObject.transform.SetParent(this.transform);
        webViewObject.gameObject.SetActive(true);
        webViewObject.Init(
            cb: (msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
                if (msg.Equals("close"))
                {
                    if (closeAction != null)
                    {
                        closeAction(0);
                    }
                }
                else if (msg.Equals("showContact"))
                {
                    if (showContact != null)
                    {
                        showContact();
                    }
                }
                else if (msg.Equals("hiddenContact"))
                {
                    if (hiddenContact != null)
                    {
                        hiddenContact();
                    }
                }
                else if (msg.Equals("getNetWorkStatus"))
                {
                    webViewObject.EvaluateJS(string.Format("setNetworkStatus({0})", string.Format("{{\"status\":\"{0}\"}}", PlatformUtil.GetNetReachAble() ? "1" : "0")));
                }
                else
                {
                    if (Regex.Match(msg, "^event").Success)
                    {
                        string newMsg = Regex.Replace(msg, "^event", "");
                        Dictionary<string, string> eventAndParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(newMsg);
                        if (eventAndParameters.ContainsKey("eventName"))
                        {
                            string eventName = eventAndParameters["eventName"];
                            eventAndParameters.Remove("eventName");
                            LogEventToPlatForm(eventName, eventAndParameters);
                        }
                    }
                }
            },
            err: (msg) =>
            {
                Debug.Log(string.Format("CallOnError[{0}]", msg));
                //if (!PlatformUtil.GetNetReachAble())
                //{
                //    LoadErrorPage();
                //}
            },
            started: (msg) =>
            {
                Debug.Log(string.Format("CallOnStarted[{0}]", msg));
            },
            ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
#if !UNITY_ANDROID
                // NOTE: depending on the situation, you might prefer
                // the 'iframe' approach.
                // cf. https://github.com/gree/unity-webview/issues/189
#if true
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        window.location = 'unity:' + msg;
                      }
                    }
                  }
                ");
#else
                webViewObject.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        var iframe = document.createElement('IFRAME');
                        iframe.setAttribute('src', 'unity:' + msg);
                        document.documentElement.appendChild(iframe);
                        iframe.parentNode.removeChild(iframe);
                        iframe = null;
                      }
                    }
                  }
                ");
#endif
#endif
                webViewObject.EvaluateJS(@"Unity.call('event{\'eventName\':\'aa\',\'level\':\'2\'}')");//'ua=' + navigator.userAgent
                webViewObject.EvaluateJS(string.Format("setting({0})", FuncArgs())); //@"setting({'key1':'123'})");
                Debug.Log("777777777 " + FuncArgs());
            },
            //ua: "custom user agent string",
            enableWKWebView: true);
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        //webViewObject.bitmapRefreshCycle = 1;
#endif
        webViewObject.SetMargins(0, (int)((this.transform as RectTransform).offsetMax.y * (-1) * Screen.height / 1280), 0, 0);
        webViewObject.SetVisibility(true);

#if !UNITY_WEBPLAYER
        if (!PlatformUtil.GetNetReachAble())
        {
            LoadErrorPage();
        }
        else
        {
            LoadUrl(startPage);
        }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
        webViewObject.EvaluateJS(
            "parent.$(function() {" +
            "   window.Unity = {" +
            "       call:function(msg) {" +
            "           parent.unityWebView.sendMessage('WebViewObject', msg)" +
            "       }" +
            "   };" +
            "});");
#endif
        yield break;
    }

    private void LoadErrorPage()
    {
        var url = errorPage;
        var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
        webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
    }

    /*#if !UNITY_WEBPLAYER
        void OnGUI()
        {
            if (webViewObject != null) {
                GUI.enabled = webViewObject.CanGoBack();
                if (GUI.Button(new Rect(10, 10, 80, 80), "<"))
                {
                    webViewObject.GoBack();
                }
                GUI.enabled = true;

                GUI.enabled = webViewObject.CanGoForward();
                if (GUI.Button(new Rect(100, 10, 80, 80), ">"))
                {
                    webViewObject.GoForward();
                }
                GUI.enabled = true;
                GUI.TextField(new Rect(300, 10, 300, 80), "" + webViewObject.Progress());
            }
            GUI.enabled = true;
            if (GUI.Button(new Rect(200,10,80,80), "X")) {
                //webViewObject.SetVisibility(!webViewObject.GetVisibility());
                if (webViewObject != null && webViewObject.GetVisibility()) {
                    Destroy(webViewObject);
                    webViewObject = null;
                } else {
                    StartCoroutine(CreateWebViewObject());
                }
            }
        }
    #endif
    */

    public bool CanGoBack()
    {
        return webViewObject.CanGoBack();
    }

    public void GoBack()
    {
        webViewObject.GoBack();
    }

    private void OnDestroy()
    {
        Destroy(webViewObject);
    }

    private string FuncArgs()
    {
        //string jsonText = "{\"shenzheng\":\"深圳\",\"beijing\":\"北京\",\"shanghai\":[{\"zj1\":\"zj11\",\"zj2\":\"zj22\"},\"zjs\"]}";
        //Dictionary<string, string> aDic = new Dictionary<string, string>()
        //{
        //};
        return "";
//        return string.Format(Format, PlatformUtil.GetIDFA(),
//            SystemInfo.deviceModel,
//            SystemInfo.operatingSystem,
//            Const.Version,
//            Application.identifier,
//            Language.settings.defaultLangCode,
//            PlatformUtil.GetNativeCountry(),
//            DataManager.BusinessData.PlayerTag,
//            AppEngine.SSystemManager.GetSystem<BagSystem>().GetPropertyCount<Bag.Coin>(),
//                             DataManager.SkillData.PropTotalcoin,
//                             PlayerInfoUtils.GetLoginContinueDay().ToString(),
//                             DataManager.LevelData.CurrentAbsUnlockLevel.ToString(),
//                             DataManager.PlayerData.IsBuy ? "1" : "0");
    }

    /// <summary>
    /// true 创建成功 false 已存在无需创建
    /// </summary>
    /// <returns><c>true</c>, if web dir was created, <c>false</c> otherwise.</returns>
    private bool CreateWebDirIfNotExisted()
    {
        string currPath = System.IO.Path.Combine(Application.persistentDataPath, "retry/js");
        Debug.Log("currpath " + currPath);
        //检查是否存在文件夹
        if (false == System.IO.Directory.Exists(currPath))
        {
            //创建pic文件夹
            System.IO.Directory.CreateDirectory(currPath);
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator WriteWebFileToProperPlace(System.IO.DirectoryInfo adi, string aSubPath)
    {
        Debug.Log("persistent path " + Application.persistentDataPath);
        var dst = System.IO.Path.Combine(Application.persistentDataPath, aSubPath);
        Debug.Log("persistent path after" + dst + "----subpath " + aSubPath);
        foreach (System.IO.FileInfo f in adi.GetFiles())
        {
            var src = f.FullName;
            if (Regex.Match(src, ".meta$").Success)
            {
                continue;
            }
            Debug.Log("f name " + f.Name + " " + f.FullName);

            byte[] result = null;
            if (src.Contains("://"))
            {  // for Android
                var www = new WWW(src);
                yield return www;
                result = www.bytes;
            }
            else
            {
                result = System.IO.File.ReadAllBytes(src);
            }
            System.IO.File.WriteAllBytes(string.Format("{0}/{1}", dst, f.Name), result);
        }
        foreach (System.IO.DirectoryInfo di in adi.GetDirectories())
        {
            yield return WriteWebFileToProperPlace(di, string.Format("{0}/{1}", aSubPath, di.Name));
        }
    }

    private void LoadUrl(string aUrl)
    {
        if (Regex.Match(aUrl, "^http").Success)
        {
            webViewObject.LoadURL(aUrl.Replace(" ", "%20"));
        }
        else
        {
            var url = aUrl;
            var dst = System.IO.Path.Combine(Application.persistentDataPath, url);

            Regex aRegex = new Regex("/.*$");
            url = aRegex.Replace(aUrl, "");
            Debug.Log("url replace " + url);
            webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
        }
    }

    public void LoadContactUs()
    {
        LoadUrl(ContactUs);
    }

    public void UserClickGoBack()
    {
        webViewObject.EvaluateJS("userClickGoBack()");
    }

    public void LogEventToPlatForm(string eventName, Dictionary<string, string> parameters)
    {
        if (parameters == null || parameters.Keys.Count < 1)
        {
            GameAnalytics.LogEvent(eventName);
        }
        else
        {
            GameAnalytics.LogEventWithParameters(eventName, parameters);
        }
    }
}