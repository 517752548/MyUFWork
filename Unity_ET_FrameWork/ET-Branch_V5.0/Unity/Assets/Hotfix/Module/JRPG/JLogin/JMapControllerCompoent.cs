using System;
using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ETHotfix
{
    public class JMapControllerCompoent: UIBaseComponent
    {
        public EventTrigger _eventtrigger;
        public bool GetMouseButtonDownZero = false;
        public Action pointDown;
        public Action pointUp;
        public override void OnOpen()
        {
            _eventtrigger = this.GameObject.Get<GameObject>("Panel").GetComponent<EventTrigger>();
            AddListener(EventTriggerType.PointerDown, this.MouseButtonDown);
            AddListener(EventTriggerType.PointerUp,this.MouseButtonUp);
            AddListener(EventTriggerType.PointerClick,this.MouseButtonOn);
        }

        public override void OnClose()
        {
            base.OnClose();
            RemoveListener(EventTriggerType.PointerDown, this.MouseButtonDown);
            RemoveListener(EventTriggerType.PointerUp,this.MouseButtonUp);
            RemoveListener(EventTriggerType.PointerClick,this.MouseButtonOn);
        }

        private void MouseButtonOn(BaseEventData data)
        {
            Log.Info("point click");
        }
        private void MouseButtonDown(BaseEventData data)
        {
            GetMouseButtonDownZero = true;
            pointDown?.Invoke();
            Log.Error("点击按下");
        }

        private void MouseButtonUp(BaseEventData data)
        {
            GetMouseButtonDownZero = false;
            this.pointUp?.Invoke();
            Log.Error("点击抬起");
        }



        private void AddListener(EventTriggerType id,UnityAction<BaseEventData> listener)
        {
            for (int i = 0; i < _eventtrigger.triggers.Count; i++)
            {
                if (_eventtrigger.triggers[i].eventID == id)
                {
                    _eventtrigger.triggers[i].callback.AddListener(listener);
                }
            }
        }

        private void RemoveListener(EventTriggerType id,UnityAction<BaseEventData> listener)
        {
            for (int i = 0; i < _eventtrigger.triggers.Count; i++)
            {
                if (_eventtrigger.triggers[i].eventID == id)
                {
                    _eventtrigger.triggers[i].callback.RemoveListener(listener);
                }
            }
        }

    }
}