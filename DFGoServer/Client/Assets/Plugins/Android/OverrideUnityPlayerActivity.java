package com.centurygame.letus;

import android.app.Activity;
import android.content.ClipData;
import android.content.ClipDescription;
import android.content.ClipboardManager;
import android.os.Bundle;
import android.os.Looper;
import android.text.TextUtils;

import com.NotchFit.NotchFit;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;
import com.wcl.notchfit.args.NotchProperty;
import com.wcl.notchfit.args.NotchScreenType;
import com.wcl.notchfit.core.OnNotchCallBack;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class OverrideUnityPlayerActivity extends UnityPlayerActivity {

    public int notchHeight = 0;

    public int getNotchHeight() {
        return notchHeight;
    }

    public String getPublisherName() {
        return "none";
    }

    public void init() {
        UnityPlayer.UnitySendMessage("GameManager", "OnInitSuccess", "");
    }

    // Setup activity layout
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        NotchFit.fit(this, NotchScreenType.FULL_SCREEN, new OnNotchCallBack() {
            @Override
            public void onNotchReady(NotchProperty notchProperty) {
                if (notchProperty.isNotchEnable()) {
                    notchHeight = notchProperty.getNotchHeight();
                }
            }
        });
    }

    /**
     * 获取进程号对应的进程名
     *
     * @param pid 进程号
     * @return 进程名
     */
    private static String getProcessName(int pid) {
        BufferedReader reader = null;
        try {
            reader = new BufferedReader(new FileReader("/proc/" + pid + "/cmdline"));
            String processName = reader.readLine();
            if (!TextUtils.isEmpty(processName)) {
                processName = processName.trim();
            }
            return processName;
        } catch (Throwable throwable) {
            throwable.printStackTrace();
        } finally {
            try {
                if (reader != null) {
                    reader.close();
                }
            } catch (IOException exception) {
                exception.printStackTrace();
            }
        }
        return null;
    }

    ////////////////////剪贴板部分开始//////////////////////////
    public static ClipboardManager clipboard = null;

    /*
     * 向剪贴板中添加文本
     */
    public void copyTextToClipboard(String str)
            throws Exception {
        if (Looper.myLooper() == null) {
            Looper.prepare();
        }
        clipboard = (ClipboardManager) getSystemService(Activity.CLIPBOARD_SERVICE);
        ClipData textCd = ClipData.newPlainText("data", str);
        clipboard.setPrimaryClip(textCd);
    }

    /*
     * 从剪贴板中获取文本
     */
    public String getTextFromClipboard() {
        if (clipboard != null && clipboard.hasPrimaryClip()
                && clipboard.getPrimaryClipDescription().hasMimeType(ClipDescription.MIMETYPE_TEXT_PLAIN)) {
            ClipData cdText = clipboard.getPrimaryClip();
            ClipData.Item item = cdText.getItemAt(0);
            return item.getText().toString();
        }
        return "null";
    }
    ////////////////////剪贴板部分结束//////////////////////////
}
