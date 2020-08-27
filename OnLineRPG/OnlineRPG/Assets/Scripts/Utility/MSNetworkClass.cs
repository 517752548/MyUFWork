using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

public enum MSNetworkClassStatus
{
    Loading,
    Complete
}

/// <summary>
/// 代表一个网络请求
/// </summary>
public class MSNetworkClass
{
    public MSNetworkClassStatus m_netStatus = MSNetworkClassStatus.Loading;
    public Action<string> m_OnErrorAction;
    public Action<string> m_OnSuccessAction;
    private HttpWebRequest httpWebRequest;

    public void HttpPostRequest(string url, IDictionary<string, string> parameters)
    {
        try
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf8"; // 必须指明字符集！

            // 参数
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                Dictionary<string, object> aDic = new Dictionary<string, object>();
                aDic["request"] = httpWebRequest;
                aDic["postData"] = buffer.ToString();

                httpWebRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), aDic);
            }
        }
        catch (Exception e)
        {
            OnError(e.Message);
            BetaFramework.LoggerHelper.Log("HttpAsyDownload - \"" + url + "\" download failed!"
                                + "\nMessage:" + e.Message);
        }
    }

    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
        Dictionary<string, object> aDic = (Dictionary<string, object>)asynchronousResult.AsyncState;

        HttpWebRequest request = (HttpWebRequest)aDic["request"];
        // End the operation
        Stream postStream = request.EndGetRequestStream(asynchronousResult);

        string postData = (string)aDic["postData"];

        // Convert the string into a byte array.
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        // Write to the request stream.
        postStream.Write(byteArray, 0, postData.Length);
        postStream.Close();

        // Start the asynchronous operation to get the response
        //request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        IAsyncResult result = (IAsyncResult)request.BeginGetResponse(new AsyncCallback(_OnResponseCallback), httpWebRequest);
    }

    private void _OnResponseCallback(IAsyncResult ar)
    {
        try
        {
            HttpWebRequest req = ar.AsyncState as HttpWebRequest;
            if (req == null) return;
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string responseContent = streamReader.ReadToEnd();
                streamReader.Close();

                OnSuccess(responseContent);
            }
            else
            {
                OnError(response.StatusCode.ToString());
            }
            response.Close();
        }
        catch (Exception e)
        {
            OnError(e.Message);
            BetaFramework.LoggerHelper.Log("HttpAsyDownload download failed!"
                                + "\nMessage:" + e.Message);
        }
    }

    private void OnError(string str)
    {
        Loom.QueueOnMainThread(() =>
        {
            if (m_OnErrorAction != null) m_OnErrorAction(str);
            ClearResource();
        });
    }

    private void OnSuccess(string str)
    {
        Loom.QueueOnMainThread(() =>
        {
            if (m_OnSuccessAction != null) m_OnSuccessAction(str);
            ClearResource();
        });
    }

    /// <summary>
    /// Call in Complete
    /// </summary>
    public void ClearResource()
    {
        m_netStatus = MSNetworkClassStatus.Complete;
        if (httpWebRequest != null)
        {
            httpWebRequest.Abort();
            httpWebRequest = null;
        }
    }
}