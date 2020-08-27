using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Views
{
    public class PartTransparentMask : MaskableGraphic, UnityEngine.ICanvasRaycastFilter
    {
        [SerializeField] private RectTransform target;

        private bool targetRaycastEnable = true;
        
        protected override void Start()
        {
            base.Start();
            Init();
            //UpdateMaterialShader(0, new Rect(), Vector3.zero, 0);
        }

        public void Init()
        {
            if (target == null)
            {
                if (transform.childCount > 0)
                {
                    var trans = transform.GetChild(0);
                    target = trans.GetComponent<RectTransform>();
                    if (target == null)
                        target = trans.gameObject.AddComponent<RectTransform>();
                }
                else
                {
                    var obj = new GameObject("target");
                    obj.transform.SetParent(transform, false);
                    target = obj.AddComponent<RectTransform>();
                }
                
            }
        }

        public void ShowRect(Rect rt, bool targetRaycastEnable = true)
        {
            Init();
            this.targetRaycastEnable = targetRaycastEnable;
            enabled = true;
            UpdateMaterialShader(1, rt, Vector3.zero, 0);
        }

        public void ShowCircle(Vector3 center, float radius, bool targetRaycastEnable = true)
        {
            Init();
            this.targetRaycastEnable = targetRaycastEnable;
            enabled = true;
            UpdateMaterialShader(0, new Rect(), center, radius);
        }

        public void Show(bool targetRaycastEnable = true)
        {
            Init();
            this.targetRaycastEnable = targetRaycastEnable;
            enabled = true;
            UpdateMaterialShader(0, new Rect(), Vector3.zero, 0);
        }

        public void Hide()
        {
            UpdateMaterialShader(0, new Rect(), Vector3.zero, 0);
            enabled = false;
        }

        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            if (!targetRaycastEnable)
                return true;
            // 点击在箭头框内部则无效，否则生效
            return !RectTransformUtility.RectangleContainsScreenPoint(target, sp, eventCamera);
        }

        private void UpdateMaterialShader(int isRect, Rect rt, Vector3 center, float radius)
        {
            if (isRect > 0)
            {
                target.SetLocalX(rt.x + rt.width / 2);
                target.SetLocalY(rt.y - rt.height / 2);
                target.sizeDelta = new Vector2(rt.width, rt.height);
            }
            else
            {
                target.localPosition = center;
                target.sizeDelta = Vector2.one * radius;
            }
            if (material != null)
            {
                material.SetInt("_IsRect", isRect);
                material.SetVector("_CircleCenter", new Vector4(center.x, center.y, 0, 0));
                material.SetFloat("_Radius", radius);
                material.SetVector("_RectPos", new Vector4(rt.x, rt.y, 0, 0));
                material.SetVector("_RectSize", new Vector4(rt.width, rt.height, 0, 0));
            }
        }


        // private void Update()
        // {
        //     // 当引导箭头位置或者大小改变后更新，注意：未处理拉伸模式
        //     if (target && center != target.anchoredPosition || size != target.sizeDelta)
        //     {
        //         this.center = target.anchoredPosition;
        //         this.size = target.sizeDelta;
        //         SetAllDirty();
        //         if (material != null)
        //             material.SetVector("_Center", new Vector4(center.x, center.y, 0, 0));
        //     }
        // }
    }
}