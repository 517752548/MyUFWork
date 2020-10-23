using System.Collections.Generic;
using app.net;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace app.guide
{
    public class GuideMaskWnd:BaseWnd
    {
        private static GuideMaskWnd _ins;

        public GuideUI UI;
        
        /// <summary>
        /// 当前正在引导的目标对象
        /// </summary>
        private GameObject targetObject;
        /// <summary>
        /// 当前正在引导的目标对象 的 原始父级
        /// 消除引导时，还原使用
        /// </summary>
        private Transform targetParent;
        private RectTransform targetObjectRTF;
        private Vector2 targetOriginalSizeDelta=Vector2.zero;

        private GridLayoutGroup gridlayout;
        
        private GameObject targetObjectTmp;
        private bool waitNextFrameOperation = false;

        //private Tweener tweener;

        public GuideMaskWnd()
        {
            base.isShowBgMask = false;
            uiName = "guideMaskImage";
        }

        public static GuideMaskWnd Ins
        {
            get
            {
                if (_ins==null)
                {
                    _ins = (Singleton.GetObj(typeof (GuideMaskWnd)) as GuideMaskWnd);
                }
                return _ins; 
            }
        }

        public override void initWnd()
        {
            base.initWnd();
            
            UI = ui.AddComponent<GuideUI>();
            UI.Init();

            UI.biankuangImage.gameObject.SetActive(false);
            UI.xiaoshouObj.gameObject.SetActive(false);

            EventTriggerListener.Get(UI.highLightImage.gameObject).onClick = clickHighLightMask;
            EventTriggerListener.Get(UI.upImage.gameObject).onClick = clickMask;
            EventTriggerListener.Get(UI.leftImage.gameObject).onClick = clickMask;
            EventTriggerListener.Get(UI.rightImage.gameObject).onClick = clickMask;
            EventTriggerListener.Get(UI.bottomImage.gameObject).onClick = clickMask;

            UI.tiaoguoBtn.SetClickCallBack(clickTiaoGuo);
        }

        public void switchMask(bool hightLight=false)
        {
            if (UI==null)
            {
                return;
            }
            //ClientLog.LogError("------切换到高亮状态" + hightLight);
            UI.highLightImage.enabled = hightLight;
            UI.maskObj.SetActive(!hightLight);
            if (hightLight)
            {
                UI.biankuangImage.gameObject.SetActive(!hightLight);
                UI.xiaoshouObj.gameObject.SetActive(!hightLight);
            }
        }

        public bool isCurHighLight()
        {
            return UI != null && UI.highLightImage!=null&& UI.highLightImage.enabled;
        }

        private void clickHighLightMask(GameObject go)
        {

        }

        public override void hide(RMetaEvent e = null)
        {
            if (UI != null)
            {
                UI.upLayout.gameObject.SetActive(false);
                UI.leftLayout.gameObject.SetActive(false);
                UI.rightLayout.gameObject.SetActive(false);
                UI.bottomLayout.gameObject.SetActive(false);
            }
            base.hide(e);
        }

        private void clickMask(GameObject go)
        {
            //ZoneBubbleManager.ins.BubbleSysMsg("请点击高亮区域");
        }

        private void clickTiaoGuo()
        {
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.QuestNavigat)
            {
                GuideCGHandler.sendCGFinishGuide((int)GuideIdDef.QuestNavigat);
            }
            clickTarget(false);
            GuideManager.Ins.RemoveGuide();
        }

        protected override void clickSpaceArea(GameObject go)
        {
            return;
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
            if (!isShown)
            {
                return;
            }
            if (waitNextFrameOperation)
            {
                if (targetObjectTmp != null)
                {
                    targetObject = targetObjectTmp;
                    targetParent = targetObject.transform.parent;
                    gridlayout = targetParent.GetComponent<GridLayoutGroup>();
                    if (gridlayout != null)
                    {
                        if (GuideManager.Ins.targetSizeDelta.x != 0)
                        {
                            targetOriginalSizeDelta.x = GuideManager.Ins.targetSizeDelta.x;
                        }
                        else
                        {
                            targetOriginalSizeDelta.x = gridlayout.cellSize.x;
                        }
                        if (GuideManager.Ins.targetSizeDelta.y != 0)
                        {
                            targetOriginalSizeDelta.y = GuideManager.Ins.targetSizeDelta.y;
                        }
                        else
                        {
                            targetOriginalSizeDelta.y = gridlayout.cellSize.y;
                        }
                    }
                    else
                    {
                        targetObjectRTF = targetObject.GetComponent<RectTransform>();
                        if (targetObjectRTF != null)
                        {
                            if (GuideManager.Ins.targetSizeDelta.x != 0)
                            {
                                targetOriginalSizeDelta.x = GuideManager.Ins.targetSizeDelta.x;
                            }
                            else
                            {
                                targetOriginalSizeDelta.x = targetObjectRTF.sizeDelta.x;
                            }
                            if (GuideManager.Ins.targetSizeDelta.y != 0)
                            {
                                targetOriginalSizeDelta.y = GuideManager.Ins.targetSizeDelta.y;
                            }
                            else
                            {
                                targetOriginalSizeDelta.y = targetObjectRTF.sizeDelta.y;
                            }
                        }
                        else
                        {
                            targetOriginalSizeDelta = GuideManager.Ins.targetSizeDelta;
                        }
                    }
                    if (targetObjectRTF == null)
                    {
                        targetObjectRTF = targetObject.GetComponent<RectTransform>();
                    }
                    targetObjectTmp = null;
                }
                else if (targetObject!=null)
                {
                    Vector3 worldPos = targetObject.transform.TransformPoint(Vector3.zero);
                    Vector3 localpos = UI.transform.InverseTransformPoint(worldPos);
                    if (GuideManager.Ins.totalOffset != Vector3.zero)
                    {
                        localpos += GuideManager.Ins.totalOffset;
                    }
                    Vector3 maskpos = localpos;
                    if (GuideManager.Ins.maskOffset != Vector3.zero)
                    {
                        maskpos += GuideManager.Ins.maskOffset;
                    }
                    UI.containerLayout.preferredWidth = targetOriginalSizeDelta.x;
                    UI.containerLayout.preferredHeight = targetOriginalSizeDelta.y;

                    UI.leftLayout.preferredHeight = targetOriginalSizeDelta.y;
                    UI.rightLayout.preferredHeight = targetOriginalSizeDelta.y;
                    if (targetObjectRTF != null)
                    {
                        if (targetObjectRTF.pivot.x == 0.5)
                        {
                            float leftwidth = UGUIConfig.UISpaceWidth / 2 + (maskpos.x) - targetOriginalSizeDelta.x / 2;
                            UI.leftLayout.preferredWidth = leftwidth;
                            UI.rightLayout.preferredWidth = UGUIConfig.UISpaceWidth - targetOriginalSizeDelta.x -
                                                            leftwidth;
                        }
                        else if (targetObjectRTF.pivot.x == 0)
                        {
                            float leftwidth = UGUIConfig.UISpaceWidth / 2 + (maskpos.x);
                            UI.leftLayout.preferredWidth = leftwidth;
                            UI.rightLayout.preferredWidth = UGUIConfig.UISpaceWidth - targetOriginalSizeDelta.x -
                                                            leftwidth;
                        }
                        else if (targetObjectRTF.pivot.x == 1)
                        {
                            float leftwidth = UGUIConfig.UISpaceWidth / 2 + (maskpos.x) - targetOriginalSizeDelta.x;
                            UI.leftLayout.preferredWidth = leftwidth;
                            UI.rightLayout.preferredWidth = UGUIConfig.UISpaceWidth - targetOriginalSizeDelta.x -
                                                            leftwidth;
                        }
                        if (targetObjectRTF.pivot.y == 0.5)
                        {
                            float upheight = UGUIConfig.UISpaceHeight / 2 - (maskpos.y) - targetOriginalSizeDelta.y / 2;
                            UI.upLayout.preferredHeight = upheight;
                            UI.bottomLayout.preferredHeight = UGUIConfig.UISpaceHeight - targetOriginalSizeDelta.y -
                                                              upheight;
                        }
                        else if (targetObjectRTF.pivot.y == 0)
                        {
                            float upheight = UGUIConfig.UISpaceHeight / 2 - (maskpos.y) - targetOriginalSizeDelta.y;
                            UI.upLayout.preferredHeight = upheight;
                            UI.bottomLayout.preferredHeight = UGUIConfig.UISpaceHeight - targetOriginalSizeDelta.y -
                                                              upheight;
                        }
                        else if (targetObjectRTF.pivot.y == 1)
                        {
                            float upheight = UGUIConfig.UISpaceHeight / 2 - (maskpos.y);
                            UI.upLayout.preferredHeight = upheight;
                            UI.bottomLayout.preferredHeight = UGUIConfig.UISpaceHeight - targetOriginalSizeDelta.y -
                                                              upheight;
                        }
                    }
                    else
                    {
                        float leftwidth = UGUIConfig.UISpaceWidth / 2 + (maskpos.x) - targetOriginalSizeDelta.x / 2;
                        UI.leftLayout.preferredWidth = leftwidth;
                        UI.rightLayout.preferredWidth = UGUIConfig.UISpaceWidth - targetOriginalSizeDelta.x - leftwidth;

                        float upheight = UGUIConfig.UISpaceHeight / 2 - (maskpos.y) - targetOriginalSizeDelta.y / 2;
                        UI.upLayout.preferredHeight = upheight;
                        UI.bottomLayout.preferredHeight = UGUIConfig.UISpaceHeight - targetOriginalSizeDelta.y -
                                                          upheight;
                    }

                    UI.biankuangImage.gameObject.SetActive(true);
                    UI.xiaoshouObj.gameObject.SetActive(true);
                    UI.zhiImage.gameObject.SetActive(true);

                    UI.upLayout.gameObject.SetActive(true);
                    UI.leftLayout.gameObject.SetActive(true);
                    UI.rightLayout.gameObject.SetActive(true);
                    UI.bottomLayout.gameObject.SetActive(true);
                    RectTransform rtf = UI.biankuangImage.GetComponent<RectTransform>();
                    if (targetObjectRTF != null)
                    {
                        rtf.anchorMin = targetObjectRTF.anchorMin;
                        rtf.anchorMax = targetObjectRTF.anchorMax;
                        rtf.pivot = targetObjectRTF.pivot;
                    }
                    else
                    {
                        rtf.anchorMin = Vector2.one*0.5f;
                        rtf.anchorMax = Vector2.one * 0.5f;
                        rtf.pivot = Vector2.one * 0.5f;
                    }
                    rtf.sizeDelta = new Vector2(targetOriginalSizeDelta.x + 30, targetOriginalSizeDelta.y + 30);
                    if (GuideManager.Ins.kuangOffset != Vector3.zero)
                    {
                        UI.biankuangImage.transform.localPosition = localpos + GuideManager.Ins.kuangOffset;
                    }
                    else
                    {
                        UI.biankuangImage.transform.localPosition = localpos;
                    }
                    RectTransform shourtf = UI.xiaoshouObj.GetComponent<RectTransform>();
                    shourtf.sizeDelta = targetOriginalSizeDelta;//new Vector2(targetOriginalSizeDelta.x + 20, targetOriginalSizeDelta.y + 20);
                    if (targetObjectRTF != null)
                    {
                        shourtf.anchorMin = targetObjectRTF.anchorMin;
                        shourtf.anchorMax = targetObjectRTF.anchorMax;
                        shourtf.pivot = targetObjectRTF.pivot;
                    }
                    else
                    {
                        shourtf.anchorMin = Vector2.one*0.5f;
                        shourtf.anchorMax = Vector2.one * 0.5f;
                        shourtf.pivot = Vector2.one * 0.5f;
                    }
                   
                    UI.biankuangImage.transform.SetAsLastSibling();
                    UI.tiaoguoBtn.transform.SetAsLastSibling();
                    UI.xiaoshouObj.transform.SetAsLastSibling();

                    waitNextFrameOperation = false;
                    UI.xiaoshouObj.transform.localPosition = localpos;
                    handMoveEnd();
                    //tweener = TweenUtil.MoveTo(UI.xiaoshouObj.transform, localpos,0.5f, null, handMoveEnd);
                }
            }
            if (Input.GetMouseButtonUp(0)&&GuideManager.Ins.AutoRunNext)
            {
                if ((EventSystem.current != null && targetObject!=null&&
                    (EventSystem.current.currentSelectedGameObject == targetObject)))
                    //(EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject == targetObject)))
                {
                    //ClientLog.LogWarning("点击到目标");
                    clickTarget();
                }
            }
        }
        
        private void handMoveEnd()
        {
            if (!UI.xiaoshouObj.activeInHierarchy)
            {
                return;
            }
            TweenUtil.ScaleTo(UI.xiaoshouObj.transform,Vector3.one*1.2f,1,null,null,null,0,Ease.OutElastic,-1);
        }
        /// <summary>
        /// 获取鼠标点下的第一个 T 类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static IList<GameObject> GetTListByMousePoint(Camera camera)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            return FilterTListByRaycastHit(Physics.RaycastAll(ray));
        }
        /// <summary>
        /// 筛选 T 类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raycastHitList"></param>
        /// <returns></returns>
        private static IList<GameObject> FilterTListByRaycastHit(RaycastHit[] raycastHitList)
        {
            if (raycastHitList == null || raycastHitList.Length == 0) return null;
            IList<GameObject> resultList = new List<GameObject>();
            foreach (RaycastHit raycastHit in raycastHitList)
            {
                GameObject gameObject = raycastHit.transform.gameObject;
                if (gameObject != null)
                {
                    resultList.Add(gameObject);
                }
            }
            return resultList;
        } 


        private void onTimer(RTimer r)
        {
            UI.zhiImage.transform.localScale = Vector3.one*1.1f;
        }

        public void clickTarget(bool donext=true)
        {
            if (UI==null)
            {
                return;
            }
            targetObject = null;
            targetParent = null;
            targetObjectRTF = null;
            targetOriginalSizeDelta = Vector2.zero;
            gridlayout = null;
            targetObjectTmp = null;

            UI.biankuangImage.gameObject.SetActive(false);
            UI.xiaoshouObj.gameObject.SetActive(false);
            //if (tweener!=null)
            //{
            //    tweener.Kill();
            //}
            //tweener = null;
            
            //hide();
            if (donext)
            {
                //执行下一步
                GuideManager.Ins.DoNext();
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            if (GuideManager.Ins.targetObject!=null)
            {
                targetObjectTmp = GuideManager.Ins.targetObject;
                waitNextFrameOperation = true;
            }
        }

        public void reshow()
        {
            if (GuideManager.Ins.targetObject != null)
            {
                targetObjectTmp = GuideManager.Ins.targetObject;
                waitNextFrameOperation = true;
            }
        }

        public override void Destroy()
        {
            EventTriggerListener.Get(UI.highLightImage.gameObject).onClick = null;
            EventTriggerListener.Get(UI.upImage.gameObject).onClick = null;
            EventTriggerListener.Get(UI.leftImage.gameObject).onClick = null;
            EventTriggerListener.Get(UI.rightImage.gameObject).onClick = null;
            EventTriggerListener.Get(UI.bottomImage.gameObject).onClick = null;

            UI.tiaoguoBtn.ClearClickCallBack();
            //if (tweener != null)
            //{
            //    tweener.Kill();
            //}
            //tweener = null;
            UI = null;
            _ins = null;
            base.Destroy();
            
        }
    }
    
}
