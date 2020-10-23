using System.Collections.Generic;
using app.net;
using UnityEngine;
using app.model;

namespace app.tisheng
{
    public class TiShengView : BaseUI
    {
        private TiShengUI tishengUI;
        private MainButtonUI tishengBtn;
        private GCPromotePanel mGCPromotePanel;

        private bool mButtonState = false;

        private List<TiShengItemScript> allScripts = new List<TiShengItemScript>();

        private List<PromoteInfo> finalPromoteInfos = new List<PromoteInfo>();

        public TiShengView(TiShengUI tishengUI, MainButtonUI tishengBtn)
        {
            this.tishengUI = tishengUI;
            this.tishengBtn = tishengBtn;
            TiShengModel.instance.addChangeEvent(TiShengModel.PROMOTE_UPDATE,PromoteUpdate);
            TiShengModel.instance.addChangeEvent(TiShengModel.ONCLICK_PROMOTE,OnClickPromote);
            tishengUI.itemUI.gameObject.SetActive(false);
            PromoteUpdate();
        }

        public bool MButtonState
        {
            get { return mButtonState; }
        }

        private void PromoteUpdate(RMetaEvent e = null)
        {
             GCPromotePanel msg = null;
             if (e != null)
             {
                 msg = e.data as GCPromotePanel;

             }
             else
             {
                 msg = TiShengModel.instance.GCPromotePanel;
             }
            mGCPromotePanel = msg;
            if (mGCPromotePanel == null)
            {
                return;
            }

            PromoteInfo[] infos = mGCPromotePanel.getPromoteInfo();
            GetFinalPromoteInfo(infos);

            if (mGCPromotePanel != null && finalPromoteInfos.Count > 0)
            {
                InitButtonState();
                SetData();
            }
            else
            {
                tishengBtn.gameObject.SetActive(false);
                tishengUI.gameObject.SetActive(false);
            }
           
        }


        private void SetData()
        {
            for (int i = 0; i < finalPromoteInfos.Count; i++)
            {
                if (i == allScripts.Count)
                {
                    GameObject item = GameObject.Instantiate(tishengUI.itemUI.gameObject) as GameObject;
                    item.SetActive(true);
                    item.transform.SetParent(tishengUI.grid.transform);
                    item.transform.localScale = Vector3.one;
                    tishengItemUI itemUI = item.GetComponent<tishengItemUI>();
                    TiShengItemScript itemScript = new TiShengItemScript(itemUI,this);
                    allScripts.Add(itemScript);
                }
                allScripts[i].Show(true);
                allScripts[i].SetData(finalPromoteInfos[i]);
            }

            for (int i = finalPromoteInfos.Count; i < allScripts.Count; i++)
            {
                allScripts[i].Show(false);
            }
        }

        private void GetFinalPromoteInfo(PromoteInfo[] infos)
        {

            finalPromoteInfos.Clear();
            if (infos == null)
            {
                return;
            }


            for (int i = 0; i < infos.Length; i++)
            {
                if (!TiShengModel.instance.removeList.Contains(infos[i].protmoteId)
                    && IsFuncOpen(infos[i].protmoteId))
                {
                    finalPromoteInfos.Add(infos[i]);
                }
            }

        }

        private void InitButtonState()
        {
            tishengUI.gameObject.SetActive(false);
            mButtonState = false;
            tishengBtn.gameObject.SetActive(true);
            tishengBtn.btn.redDotVisible = true;
        }

        public void OnClickPromote(RMetaEvent e = null)
        {
            mButtonState = !MButtonState;
            tishengUI.gameObject.SetActive(MButtonState);
        }



        public void DoFunc(int funId)
        {
            int linkfuncIdef = GetLinkFunIdef(funId);
            if (linkfuncIdef == -1)
            {
                return;
            }

            LinkParse.Ins.linkToFunc(linkfuncIdef);
            TiShengModel.instance.TiShengLink();
        }

        /// <summary>
        /// 获取提升链接ID，打开提升功能ID
        /// </summary>
        /// <param name="funId"></param>
        /// <returns></returns>
        private int GetLinkFunIdef(int funId)
        {
            switch (funId)
            {
                case 1:
                    return FunctionIdDef.JUESEJIADIAN;
                case 2:
                    return FunctionIdDef.CHONGWU_JIADIAN;
                case 3:
                    return FunctionIdDef.SHENGXING;
                case 4:
                    return FunctionIdDef.XIANGQIAN;
                case 5:
                    return FunctionIdDef.XINFASHENGJI;
                case 6:
                    return FunctionIdDef.JINENGSHENGJI;
                case 7:
                    return FunctionIdDef.CHIBANG;
                case 8:
                    return FunctionIdDef.QICHONGJIADIAN;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// 获取提升功能id,要提升的功能是否开启检查
        /// </summary>
        /// <param name="funId"></param>
        /// <returns></returns>
        private int GetFunIdef(int funId)
        {
            switch (funId)
            {
                case 1:
                    return FunctionIdDef.JUESEJIADIAN;
                case 2:
                    return FunctionIdDef.CHONGWU_JIADIAN;
                case 3:
                    return FunctionIdDef.SHENGXING;
                case 4:
                    return FunctionIdDef.XIANGQIAN;
                case 5:
                    return FunctionIdDef.XINFAJINENG;
                case 6:
                    return FunctionIdDef.XINFAJINENG;
                case 7:
                    return FunctionIdDef.CHIBANG;
                case 8:
                    return FunctionIdDef.QICHONG;
                default:
                    return -1;
            }
        }

        private bool IsFuncOpen(int promoteId)
        {
            if (promoteId == 1 || promoteId == 2)
            {
                return true;
            }

            int funcId = GetFunIdef(promoteId);

            if (funcId == -1)
            {
                return false;
            }

            return FunctionModel.Ins.IsFuncOpen(funcId);
        }



        public void RemoveShowFunc(int funId)
        {
            if (!TiShengModel.instance.removeList.Contains(funId))
            {
                TiShengModel.instance.removeList.Add(funId);
                CheckRemoveState();
            }

            GetFinalPromoteInfo(mGCPromotePanel.getPromoteInfo());
            if (finalPromoteInfos.Count == 0)
            {
                PromoteUpdate();
            }
        }

        private void CheckRemoveState()
        {
            for (int i = 0; i < allScripts.Count;i++)
            {
                bool show = !TiShengModel.instance.removeList.Contains(allScripts[i].info.protmoteId);
                allScripts[i].Show(show);
            }
        }

        public override void Destroy()
        {
            TiShengModel.instance.removeChangeEvent(TiShengModel.PROMOTE_UPDATE, PromoteUpdate);
            TiShengModel.instance.removeChangeEvent(TiShengModel.ONCLICK_PROMOTE, OnClickPromote);
            base.Destroy();
        }

    }
}
