using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace init
{
    public class AssetsDownloadConfirmWnd : MonoBehaviour
    {
        public Button okBtn;
        public Button cancelBtn;
        public Text content;
        private Action mOkCallback = null;

        void Awake()
        {
            okBtn.onClick.AddListener(OK);
            cancelBtn.onClick.AddListener(Cancel);
        }

        public void Show(List<string[]> list, Action okCallback)
        {
            int totalSize = 0;
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                totalSize += int.Parse(list[i][3]);
            }

            string sizeStr = null;
            if (totalSize > 1000)
            {
                sizeStr = ((float)totalSize / 1024.0f).ToString("f1") + "MB";
            }
            else
            {
                sizeStr = totalSize.ToString() + "KB";
            }

            content.text = "本次更新将要下载约" + sizeStr + "素材，\n建议使用WIFI下载。";

            gameObject.SetActive(true);
            mOkCallback = okCallback;
        }

        private void OK()
        {
            gameObject.SetActive(false);
            if (mOkCallback != null)
            {
                mOkCallback();
            }
        }

        private void Cancel()
        {
            Application.Quit();
        }
    }
}

