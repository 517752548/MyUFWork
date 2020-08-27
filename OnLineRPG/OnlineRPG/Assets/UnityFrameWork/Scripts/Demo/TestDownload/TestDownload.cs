using BetaFramework;
using System.Collections.Generic;
using UnityEngine;

public class TestDownload : MonoBehaviour, IDownloadListener
{
    private string[] str = new string[] {
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d468014c48.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d47227f5df.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d46802008e.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d4722849d2.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d468029c34.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d46802ec63.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d468034e92.jpg",
        "http://cdn.oss.gameimage.fotoable.net//word//puzzleImg//20190220//1915c6d46803e140.jpg"
    };

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < str.Length; i++)
        {
            TestGetBytes(str[i]);
        }
    }

    public void TestGetBytes(string url)
    {
        //string url = "http://cdn.oss.gameimage.fotoable.net/word/initConfig/20190123/1915c4813ddeae79.txt";
        //ModuleManager.FindModule<DownloadManager>().GetBytes(this, url);
    }

    public void TestPostBytes()
    {
        string url = "http://game.sandbox.wordzhgame.net/api/wordMania/initConfigV4";
        Dictionary<string, string> formFields = new Dictionary<string, string>();
        formFields.Add("appid", "com.fillword.cross.wordmind.ios.de");
        formFields.Add("platform", "ios");
        formFields.Add("ver", "1");
        formFields.Add("groupid", "31");

        //ModuleManager.FindModule<DownloadManager>().PostBytes(this, url, formFields);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnError(int id, string errorMessage)
    {
        LoggerHelper.Error(id + " " + errorMessage);
    }

    public void OnUpdate(int id, float progress)
    {
    }

    public void OnSuccess(int id, byte[] bytes)
    {
        LoggerHelper.Log(id + " " + bytes.Length);
    }
}