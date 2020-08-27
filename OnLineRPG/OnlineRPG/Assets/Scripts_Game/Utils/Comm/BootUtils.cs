using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootUtils
{
    
    #region DLLs
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int SetCursorPos(int x, int y);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern void mouse_event(MouseEventFlag dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

    // 方法参数说明
    // VOID mouse_event(
    //     DWORD dwFlags,         // motion and click options
    //     DWORD dx,              // horizontal position or change
    //     DWORD dy,              // vertical position or change
    //     DWORD dwData,          // wheel movement
    //     ULONG_PTR dwExtraInfo  // application-defined information
    // );

    [Flags]
    enum MouseEventFlag : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000
    }
    #endregion

    void Start()
    {
        
    }

    public static bool MoveTo(float x, float y)
    {
        if (x < 0 || y < 0 || x > UnityEngine.Screen.width || y > UnityEngine.Screen.height)
            return true;

        if (!UnityEngine.Screen.fullScreen)
        {
            UnityEngine.Debug.LogError("只能在全屏状态下使用！");
            return false;
        }

        SetCursorPos((int)x, (int)(UnityEngine.Screen.height - y));
        return true;
    }

    // 左键单击
    public static void LeftClick(float x = -1, float y = -1)
    {
        if (MoveTo(x, y))
        {
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
    }

    /// <summary>
    /// 点击某一个键盘按钮
    /// </summary>
    /// <param name="btn"></param>
    public static void ClickKeyBoardKey(KeyboardOneKey btn)
    {
        
       Vector3 pos = GameObject.Find("GameRoot/GamePlayCamera").GetComponent<Camera>().WorldToScreenPoint(btn.transform.position);
       LeftClick(pos.x,pos.y);
    }

}
