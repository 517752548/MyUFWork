using System;
using UnityEngine;

namespace app.utils
{
    public class GeometryUtil
    {
        /// <summary>
        /// 点到直线的距离。
        /// </summary>
        /// <param name="x1">直线上的点1横坐标。</param>
        /// <param name="y1">直线上的点1纵坐标。</param>
        /// <param name="x2">直线上的点2横坐标。</param>
        /// <param name="y2">直线上的点2纵坐标。</param>
        /// <param name="x0">直线外的点横坐标。</param>
        /// <param name="y0">直线外的点纵坐标。</param>
        /// <returns></returns>
        public static float DistFromDotToLine(float x1, float y1, float x2, float y2, float x0, float y0)
        {
            if (x1 == x2)
            {
                return Math.Abs(x0 - x1);
            }

            if (y1 == y2)
            {
                return Math.Abs(y0 - y1);
            }

            float k = (y2 - y1) / (x2 - x1);
            float a = k;
            float b = -1;
            float c = y1 - k * x1;
            return Mathf.Abs(a * x0 + b * y0 + c) * Mathf.Sqrt(a * a + b * b);
        }

        /// <summary>
        /// 求圆外一点与圆的两个切点。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static void GetTangentPoints(float a0, float b0, float r0, float x0, float y0, out float ox1, out float oy1, out float ox2, out float oy2)
        {
            // 点到圆心距离的平方
            float d2 = (x0 - a0) * (x0 - a0) + (y0 - b0) * (y0 - b0);
            // 点到圆心距离
            float d = Mathf.Sqrt(d2);
            // 半径的平方
            float r2 = r0 * r0;

            // 点到切点距离
            float l = Mathf.Sqrt(d2 - r2);
            // 点->圆心的单位向量
            float x = (a0 - x0) / d;
            float y = (b0 - y0) / d;
            // 计算切线与点心连线的夹角
            float f = Mathf.Asin(r0 / d);
            // 向正反两个方向旋转单位向量
            float x1 = x * Mathf.Cos(f) - y * Mathf.Sin(f);
            float y1 = x * Mathf.Sin(f) + y * Mathf.Cos(f);
            float x2 = x * Mathf.Cos(-f) - y * Mathf.Sin(-f);
            float y2 = x * Mathf.Sin(-f) + y * Mathf.Cos(-f);

            // 得到新座标
            ox1 = x1 * l + x0;
            oy1 = y1 * l + y0;
            ox2 = x2 * l + x0;
            oy2 = y2 * l + y0;
        }

        public static Rect GetRect(Vector3 center, float edgeHalfLen)
        {
            return new Rect(center.x - edgeHalfLen, center.z - edgeHalfLen, edgeHalfLen * 2, edgeHalfLen * 2);
        }

        public static Rect GetRect(Vector3 center, float halfWidth, float halfHeight)
        {
            return new Rect(center.x - halfWidth, center.z - halfHeight, halfWidth * 2, halfHeight * 2);
        }
    }
}
