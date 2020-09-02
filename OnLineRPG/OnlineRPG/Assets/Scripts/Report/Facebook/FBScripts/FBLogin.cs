using Facebook.Unity;

/**
 * Copyright (c) 2014-present, Facebook, Inc. All rights reserved.
 *
 * You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
 * copy, modify, and distribute this software in source code or binary form for use
 * in connection with the web services and APIs provided by Facebook.
 *
 * As with any software that integrates with the Facebook platform, your use of
 * this software is subject to the Facebook Developer Principles and Policies
 * [http://developers.facebook.com/policy/]. This copyright notice shall be
 * included in all copies or substantial portions of the software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;

// Class responsible for Facebook Login in Friend Smash!
// For more details on Facebook Login see: https://developers.facebook.com/docs/facebook-login/overview
public static class FBLogin
{
    // Constants for the list of permissions we are requesting when prompting for Facebook Login
    // Read permissions and publish permissions should be requested seperatly and within context
    // See more: https://developers.facebook.com/docs/facebook-login/permissions/overview
    private static readonly List<string> readPermissions = new List<string> { "public_profile", "email","user_friends" };

    private static readonly List<string> publishPermissions = new List<string> { "publish_actions" };

    public static void PromptForLogin(Action<bool> callback = null)
    {
        // Login for read permissions
        // https://developers.facebook.com/docs/unity/reference/current/FB.LogInWithReadPermissions
        FB.LogInWithReadPermissions(readPermissions, delegate (ILoginResult result)
        {
            BetaFramework.LoggerHelper.Log("LoginCallback");
            if (FB.IsLoggedIn)
            {
                BetaFramework.LoggerHelper.Log("Logged in with ID: " + AccessToken.CurrentAccessToken.UserId +
                          "\nGranted Permissions: " + AccessToken.CurrentAccessToken.Permissions.ToCommaSeparateList());
                if (callback != null)
                {
                    callback(true);
                }
            }
            else
            {
                if (result.Error != null)
                {
                    BetaFramework.LoggerHelper.Error(result.Error);
                }
                BetaFramework.LoggerHelper.Log("Not Logged In");
                if (callback != null)
                {
                    callback(false);
                }
            }
        });
    }

    public static void PromptForPublish(Action callback = null)
    {
        // Login for publish permissions
        // https://developers.facebook.com/docs/unity/reference/current/FB.LogInWithPublishPermissions
        FB.LogInWithPublishPermissions(publishPermissions, delegate (ILoginResult result)
        {
            BetaFramework.LoggerHelper.Log("LoginCallback");
            if (FB.IsLoggedIn)
            {
                BetaFramework.LoggerHelper.Log("Logged in with ID: " + AccessToken.CurrentAccessToken.UserId +
                          "\nGranted Permissions: " + AccessToken.CurrentAccessToken.Permissions.ToCommaSeparateList());
            }
            else
            {
                if (result.Error != null)
                {
                    BetaFramework.LoggerHelper.Error(result.Error);
                }
                BetaFramework.LoggerHelper.Log("Not Logged In");
            }
            if (callback != null)
            {
                callback();
            }
        });
    }

    public static void FBLogout()
    {
        FB.LogOut();
    }

    #region Util

    // Helper function to check whether the player has granted 'publish_actions'
    public static bool HavePublishActions
    {
        get
        {
            return (FB.IsLoggedIn &&
                   (AccessToken.CurrentAccessToken.Permissions as List<string>).Contains("publish_actions")) ? true : false;
        }
        private set { }
    }

    #endregion Util
}