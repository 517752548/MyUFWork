using System;
using System.Linq;
using EventUtil;
using UnityEngine;

namespace BetaFramework
{
    public class PlatformEvents : MonoBehaviour
    {
        public static void Init()
        {
            GameObject eventObject = new GameObject("PlatformEvents");
            eventObject.AddComponent<PlatformEvents>();
            AppEngine.AddDontGameObject(eventObject);
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private static event Action _onScreenOpenEvent;

        public static event Action onScreenOpenEvent
        {
            add
            {
                if (_onScreenOpenEvent == null || !_onScreenOpenEvent.GetInvocationList().Contains(value))
                {
                    _onScreenOpenEvent += value;
                }
            }

            remove
            {
                if (_onScreenOpenEvent != null && _onScreenOpenEvent.GetInvocationList().Contains(value))
                {
                    _onScreenOpenEvent -= value;
                }
            }
        }

        public void onScreenOpen()
        {
            _onScreenOpenEvent();
        }

        private static event Action _onUnityViewDidAppearEvent;

        public static event Action onUnityViewDidAppearEvent
        {
            add
            {
                if (_onUnityViewDidAppearEvent == null || !_onUnityViewDidAppearEvent.GetInvocationList().Contains(value))
                {
                    _onUnityViewDidAppearEvent += value;
                }
            }

            remove
            {
                if (_onUnityViewDidAppearEvent != null && _onUnityViewDidAppearEvent.GetInvocationList().Contains(value))
                {
                    _onUnityViewDidAppearEvent -= value;
                }
            }
        }

        public void viewDidAppear()
        {
            if (_onUnityViewDidAppearEvent != null)
                _onUnityViewDidAppearEvent();
        }

        private static event Action _onUnityViewDisAppearEvent;

        public static event Action onUnityViewDisAppearEvent
        {
            add
            {
                if (_onUnityViewDisAppearEvent == null || !_onUnityViewDisAppearEvent.GetInvocationList().Contains(value))
                {
                    _onUnityViewDisAppearEvent += value;
                }
            }

            remove
            {
                if (_onUnityViewDisAppearEvent != null && _onUnityViewDisAppearEvent.GetInvocationList().Contains(value))
                {
                    _onUnityViewDisAppearEvent -= value;
                }
            }
        }

        public void viewWillDisappear()
        {
            if (_onUnityViewDisAppearEvent != null)
                _onUnityViewDisAppearEvent();
        }

		public void PushToggleStateChange(string stringAvailable)
		{
			BetaFramework.LoggerHelper.Log("PushToggleStateChange " + stringAvailable);
			if (stringAvailable == "false") {
				//EventDispatcher.TriggerEvent(GlobalEvents.NotiToggleChanged, false);
			}
		}
	}
}