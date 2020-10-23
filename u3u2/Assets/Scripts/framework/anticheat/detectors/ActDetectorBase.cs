using UnityEngine.Events;

namespace anticheat
{
    public abstract class ActDetectorBase : AbsMonoBehaviour
    {
        public bool autoDispose = true;
        //protected const string CONTAINER_NAME = "Anti-Cheat Toolkit Detectors";
        public bool keepAlive = true;
        //protected const string MENU_PATH = "GameObject/Create Other/Code Stage/Anti-Cheat Toolkit/";
        protected UnityAction onDetection;

        protected ActDetectorBase()
        {
        }

        protected virtual void DisposeInternal()
        {
            //this.StopDetectionInternal();
            //UnityEngine.Object.Destroy(this.gameObject);
        }

        protected virtual bool Init(ActDetectorBase instance, string detectorName)
        {
            if (instance != null)
            {
                //Debug.LogWarning("[ACT] Only one " + detectorName + " instance allowed!");
                //UnityEngine.Object.Destroy(this.gameObject);
                return false;
            }
            if (!this.IsPlacedCorrectly(detectorName))
            {
                //Debug.LogWarning("[ACT] " + detectorName + " is placed in scene incorrectly and will be auto-destroyed!\nPlease, use \"" + "GameObject/Create Other/Code Stage/Anti-Cheat Toolkit/".Replace("/", "->") + detectorName + "\" menu to correct this!");
                //UnityEngine.Object.Destroy(this.gameObject);
                return false;
            }
            //UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
            return true;
        }

        protected virtual bool IsPlacedCorrectly(string componentName)
        {
            return true;
            //return (((this.gameObject.name == componentName) && (base.GetComponentsInChildren<Component>().Length == 2)) && (this.transform.childCount == 0));
        }

        private void OnApplicationQuit()
        {
            this.DisposeInternal();
        }

        private void OnDisable()
        {
            this.StopDetectionInternal();
        }

        private void OnLevelWasLoaded(int index)
        {
            if (!this.keepAlive)
            {
                this.DisposeInternal();
            }
        }

        protected abstract void StopDetectionInternal();
    }
}

