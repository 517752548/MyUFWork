using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    public class GuideHighlightMask : MaskableGraphic, UnityEngine.ICanvasRaycastFilter
    {
        public RectTransform arrow;
        public Vector2 center = Vector2.zero;
        public Material maskMaterial;
        private Vector2 size = new Vector2(200, 100);
        private Shader maskShader;

        protected override void Start()
        {
            base.Start();
            maskMaterial = this.material;
            if (maskMaterial != null)
                maskShader = maskMaterial.shader;
            if (maskMaterial != null)
                maskMaterial.SetVector("_Center", new Vector4(center.x, center.y, 0, 0));
        }

        public void DoUpdate()
        {
            // 当引导箭头位置或者大小改变后更新，注意：未处理拉伸模式
            if (arrow && center != arrow.anchoredPosition || size != arrow.sizeDelta)
            {
                this.center = arrow.anchoredPosition;
                this.size = arrow.sizeDelta;
                SetAllDirty();
                if (maskMaterial != null)
                    maskMaterial.SetVector("_Center", new Vector4(center.x, center.y, 0, 0));
            }
        }


        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            // 点击在箭头框内部则无效，否则生效
            return !RectTransformUtility.RectangleContainsScreenPoint(arrow, sp, eventCamera);
        }


        private void Update()
        {
            DoUpdate();
        }
    }
}