using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using UnityEngine;

public class FBEvents : MonoBehaviour
{
    public delegate void EventHandlerFBLoginSucceed();

    public delegate void EventHandlerFBLoginFaild(string error);

    public delegate void EventHandlerFBInvitedSucceed(string resultJsonStr);

    public delegate void EventHandlerFBInvitedFaild(string error);

    public delegate void EventHandlerFBGotFriendSucceed(string resultJsonStr);

    public delegate void EventHandlerFBGotFriendFaild(string error);

    public static event EventHandlerFBLoginSucceed onLoginSucceed;

    public static event EventHandlerFBLoginFaild onLoginFaild;

    public static event EventHandlerFBInvitedSucceed onInvitedSucceed;

    public static event EventHandlerFBInvitedFaild onInvitedFaild;

    public static event EventHandlerFBGotFriendSucceed onGotFriendSucceed;

    public static event EventHandlerFBGotFriendFaild onGotFriendFaild;

    private static bool startFinished = false;

    private void Awake()
    {
        if (!startFinished)
        {
            startFinished = true;
            gameObject.name = "FacebookEvents";
            AppEngine.AddDontGameObject(this.gameObject);
        }
    }

    public void onFBLoginSucceed()
    {
        if (onLoginSucceed != null)
            onLoginSucceed();
    }

    public void onFBloginFaild(string error)
    {
        if (onLoginFaild != null)
            onLoginFaild(error);
    }

    public void onFBInvitedSucceed(string resultJsonStr)
    {
        Record.SetInt("giftCoins", 500);
//        UIManager.OpenUIAsync(ViewConst.prefab_GiftDialog);

        if (onInvitedSucceed != null)
            onInvitedSucceed(resultJsonStr);
    }

    public void AndroidCallCheckLogin()
    {
        FBSdkAgent.Login();
    }

    public void onFBInvitedFaild(string error)
    {
        if (onInvitedFaild != null)
            onInvitedFaild(error);
    }

    public void onGotFBFriendSucceed(string resultJsonStr)
    {
        if (onGotFriendSucceed != null)
            onGotFriendSucceed(resultJsonStr);
    }

    public void onGotFBFriendFaild(string error)
    {
        if (onGotFriendFaild != null)
            onGotFriendFaild(error);
    }
}