using System;
using System.Collections.Generic;
using Hotfix;
using UnityEngine;

namespace ET
{
    public static partial class UIHelper
    {
        public static UIBase Create<T>(string UIName, GameObject uiGameObject,params object[] objs) where T : UIBaseComponent, new()
        {
            try
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(uiGameObject);
                UIBase ui = EntityFactory.CreateWithParent<UIBase, string, GameObject>(Game.Scene.GetComponent<UIManagerComponent>(),UIName, gameObject);
                ui.paras = objs;
                ui.UIGuid = System.Guid.NewGuid().ToString();
                RectTransform uirecttransform = ui.GameObject.GetComponent<RectTransform>();
                uirecttransform.anchorMax = Vector2.one;
                uirecttransform.pivot = Vector2.one * 0.5f;
                ui.GameObject.transform.localScale = Vector3.one;
                uirecttransform.offsetMax = Vector2.zero;
                uirecttransform.offsetMin = Vector2.zero;
                ui.AddComponent<T>().Init(gameObject);
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public static void CloseUI(UIBase UIName, Dictionary<UILayerNew, List<UIBase>> ui_base)
        {
            foreach (var uilayer in ui_base.Keys)
            {
                if (ui_base[uilayer].Find(x=>x.UIGuid == UIName.UIGuid) != null)
                {
                    if (ui_base[uilayer][ui_base[uilayer].Count - 1].UIGuid == UIName.UIGuid)
                    {
                        ui_base[uilayer].Remove(UIName);
                        if (ui_base[uilayer].Count > 0)
                        {
                            ui_base[uilayer][ui_base[uilayer].Count - 1].ReEnable();
                        }
                    }
                    else
                    {
                        ui_base[uilayer].Remove(UIName);
                    }
                    UIName.OnClose();
                    break;
                }
            }
        }

        public static void HandlerUI(UIBase _uibase, UILayerNew layer, UIOpenType openType, Dictionary<UILayerNew, List<UIBase>> ui_base)
        {
            List<UIBase> layerQueue = null;
            if (ui_base.ContainsKey(layer))
            {
                layerQueue = ui_base[layer];
            }
            else
            {
                layerQueue = new List<UIBase>();
                ui_base.Add(layer, layerQueue);
            }

            switch (layer)
            {
                case UILayerNew.GameUI:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().GameUI, false);
                    break;
                case UILayerNew.Fixed:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().Fixed, false);
                    break;
                case UILayerNew.Normal:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().Normal, false);
                    break;
                case UILayerNew.TopBar:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().TopBar, false);
                    break;
                case UILayerNew.PopUp:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().PopUp, false);
                    break;
                case UILayerNew.GuideUi:
                    _uibase.GameObject.transform.SetParent(Game.Scene.GetComponent<UIManagerComponent>().GuideUI, false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof (layer), layer, null);
            }

            UIBase lastUibase = layerQueue.Count == 0? null : layerQueue[layerQueue.Count - 1];
            if (lastUibase != null)
            {
                switch (openType)
                {
                    case UIOpenType.Stack:
                        lastUibase.Hidden();
                        layerQueue.Remove(lastUibase);
                        layerQueue.Add(_uibase);
                        break;
                    case UIOpenType.Replace:
                        lastUibase.OnClose();
                        layerQueue.Add(_uibase);
                        break;
                }
            }
            else
            {
                switch (openType)
                {
                    case UIOpenType.Stack:
                        layerQueue.Add(_uibase);
                        break;
                    case UIOpenType.Replace:
                        layerQueue.Add(_uibase);
                        break;
                } 
            }
        }
    }
}