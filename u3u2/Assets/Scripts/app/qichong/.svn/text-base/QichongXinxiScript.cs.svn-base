using UnityEngine;
using System.Collections;
using app.pet;

namespace app.qichong
{

    public class QichongXinxiScript : BaseUI
    {

        private QichongXinxiUI mXinxiUI;
        private QichongshuxingScript shuxingScript;
        private QichongzizhiScript zizhiScript;
        private QichongchengzhangScript chengzhangScript;
        private QichongwuxingScript wuxingScript;

        private QichongShuxingUI shuxingUI;
        private QichongzizhiUI zizhiUI;
        private QichongchengzhangUI chengzhangUI;
        private QichongwuxingUI wuxingUI;

        Pet pet = null;

        private QichongView mQiChongView;
        public QichongXinxiScript(QichongXinxiUI xinxiUI, QichongView qichongView)
        {
            mXinxiUI = xinxiUI;
            //  shuxingScript = new QichongshuxingScript(xinxiUI.shuxingUI);
            //  zizhiScript = new QichongzizhiScript(xinxiUI.zizhiUI);
            //    chengzhangScript = new QichongchengzhangScript(xinxiUI.chengzhangUI);
            //     wuxingScript = new QichongwuxingScript(xinxiUI.wuxingUI);
            mXinxiUI.tabs.TabChangeHandler = ChangeTab;
            mQiChongView = qichongView;
            mXinxiUI.tabs.SetIndexWithCallBack(0);
        }

        public void SetData(Pet pet)
        {
            this.pet = pet;
            mXinxiUI.tabs.SetIndexWithCallBack(mXinxiUI.tabs.index);
        }

        private void ChangeTab(int index)
        {
            switch (index)
            {
                case 0:
                    if (shuxingScript == null)
                    {
                        mXinxiUI.StartCoroutine(InitShuxingUI(1));
                    }
                    else
                    {

                        shuxingScript.SetData(pet);
                        SetChildVisible(mXinxiUI.objQiChongXinxi_shuxing, true);
                    }
                    SetChildVisible(mXinxiUI.objQiChongXinxi_chengzhang, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_wuxing, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_zizhi, false);
                    break;
                case 1:
                    //SetChildVisible(mXinxiUI.shuxingUI, false);
                    //SetChildVisible(mXinxiUI.zizhiUI, true);
                    //SetChildVisible(mXinxiUI.chengzhangUI, false);
                    //SetChildVisible(mXinxiUI.wuxingUI, false);
                    if (zizhiScript == null)
                    {
                        mXinxiUI.StartCoroutine(InitZizhiUI(0));
                    }
                    else
                    {

                        SetChildVisible(mXinxiUI.objQiChongXinxi_zizhi, true);
                        zizhiScript.UpdatePanel(pet);
                    }
                    SetChildVisible(mXinxiUI.objQiChongXinxi_shuxing, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_chengzhang, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_wuxing, false);
                    break;
                case 2:
                    //SetChildVisible(mXinxiUI.shuxingUI, false);
                    //SetChildVisible(mXinxiUI.zizhiUI, false);
                    //SetChildVisible(mXinxiUI.chengzhangUI, true);
                    //SetChildVisible(mXinxiUI.wuxingUI, false);
                    if (chengzhangScript == null)
                    {
                        mXinxiUI.StartCoroutine(InitChengZhangUI(0));
                    }
                    else
                    {
             
                        SetChildVisible(mXinxiUI.objQiChongXinxi_chengzhang, true);

                        chengzhangScript.UpdatePanel(pet);
                    }
                    SetChildVisible(mXinxiUI.objQiChongXinxi_wuxing, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_zizhi, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_shuxing, false);
                    break;
                case 3:
                    //SetChildVisible(mXinxiUI.shuxingUI, false);
                    //SetChildVisible(mXinxiUI.zizhiUI, false);
                    //SetChildVisible(mXinxiUI.chengzhangUI, false);
                    //SetChildVisible(mXinxiUI.wuxingUI, true);
                    if (wuxingScript == null)
                    {
                        mXinxiUI.StartCoroutine(InitWuXingUI(1));
                    }
                    else
                    {

                        SetChildVisible(mXinxiUI.objQiChongXinxi_wuxing, true);
                        
                        wuxingScript.UpdatePanel(pet);
                    }
                    SetChildVisible(mXinxiUI.objQiChongXinxi_zizhi, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_shuxing, false);
                    SetChildVisible(mXinxiUI.objQiChongXinxi_chengzhang, false);
                    break;
            }
        }

        IEnumerator InitShuxingUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }

            mXinxiUI.objQiChongXinxi_shuxing = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mQiChongView.uiPath, mQiChongView.uiName + "XinXi_shuxing")) as GameObject;
            mXinxiUI.objQiChongXinxi_shuxing.SetActive(true);
            GameObjectUtil.Bind(mXinxiUI.objQiChongXinxi_shuxing.transform, mXinxiUI.transform, true, true);
            mXinxiUI.objQiChongXinxi_shuxing.transform.localScale = Vector3.one;
            shuxingUI = mXinxiUI.objQiChongXinxi_shuxing.AddComponent<QichongShuxingUI>();
            shuxingUI.Init();
            shuxingScript = new QichongshuxingScript(shuxingUI);
            shuxingScript.SetData(pet);
        }

        IEnumerator InitZizhiUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                 yield return null;
            }
            mXinxiUI.objQiChongXinxi_zizhi = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mQiChongView.uiPath, mQiChongView.uiName + "XinXi_zizhi")) as GameObject;
            mXinxiUI.objQiChongXinxi_zizhi.SetActive(true);
            GameObjectUtil.Bind(mXinxiUI.objQiChongXinxi_zizhi.transform, mXinxiUI.transform, true, true);
            mXinxiUI.objQiChongXinxi_zizhi.transform.localScale = Vector3.one;
            zizhiUI = mXinxiUI.objQiChongXinxi_zizhi.AddComponent<QichongzizhiUI>();
            zizhiUI.Init();
            zizhiScript = new QichongzizhiScript(zizhiUI);
            zizhiScript.UpdatePanel(pet);           
        }

        IEnumerator InitChengZhangUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            mXinxiUI.objQiChongXinxi_chengzhang = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mQiChongView.uiPath, mQiChongView.uiName + "XinXi_chengzhang")) as GameObject;
            mXinxiUI.objQiChongXinxi_chengzhang.SetActive(true);
            GameObjectUtil.Bind(mXinxiUI.objQiChongXinxi_chengzhang.transform, mXinxiUI.transform, true, true);
            mXinxiUI.objQiChongXinxi_chengzhang.transform.localScale = Vector3.one;
            chengzhangUI = mXinxiUI.objQiChongXinxi_chengzhang.AddComponent<QichongchengzhangUI>();
            chengzhangUI.Init();
            chengzhangScript = new QichongchengzhangScript(chengzhangUI);
            chengzhangScript.UpdatePanel(pet);           
        }

        IEnumerator InitWuXingUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            mXinxiUI.objQiChongXinxi_wuxing = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mQiChongView.uiPath, mQiChongView.uiName + "XinXi_wuxing")) as GameObject;
            mXinxiUI.objQiChongXinxi_wuxing.SetActive(true);
            GameObjectUtil.Bind(mXinxiUI.objQiChongXinxi_wuxing.transform, mXinxiUI.transform, true, true);
            mXinxiUI.objQiChongXinxi_wuxing.transform.localScale = Vector3.one;
            wuxingUI = mXinxiUI.objQiChongXinxi_wuxing.AddComponent<QichongwuxingUI>();
            wuxingUI.Init();
            wuxingScript = new QichongwuxingScript(wuxingUI);
            wuxingScript.UpdatePanel(pet);         

        }

        public override void Destroy()
        {
            if (shuxingScript != null)
            {
                shuxingScript.Destroy();
            }
            
            if (zizhiScript != null)
            {
                zizhiScript.Destroy();
            }
            
            if (chengzhangScript != null)
            {
                chengzhangScript.Destroy();
            }
            
            if (wuxingScript != null)
            {
                wuxingScript.Destroy();
            }
            base.Destroy();
            mXinxiUI = null;
        }
    }
}
