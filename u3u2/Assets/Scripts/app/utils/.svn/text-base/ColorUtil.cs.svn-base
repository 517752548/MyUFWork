using UnityEngine;
using UnityEngine.UI;
using app.main;

namespace app.utils
{
    /// <summary>
    /// 品质颜色定义
    /// </summary>
    class ColorUtil
    {

        /** 白色 */
        public const int WHITE_ID = 1;
        /** 绿色 */
        public const int GREEN_ID = 2;
        /** 蓝色 */
        public const int BLUE_ID = 3;
        /** 紫色 */
        public const int PURPLE_ID = 4;
        /** 橙色 */
        public const int ORANGE_ID = 5;
        /** 红色 */
        public const int RED_ID = 6;

        /** 白色 */
        public const string WHITE = "#FFFFFF";
        /** 绿色 */
        public const string GREEN = "#37EE38";
        /** 蓝色 */
        public const string BLUE = "#0069E0";
        /** 紫色 */
        public const string PURPLE = "#9D36FF";
        /** 橙色 */
        public const string ORANGE = "#FF8523";
        /** 红色 */
        public const string RED = "#FF0000";


        public static string getQualityColor(int qualityValue)
        {
            string colorStr = "#FFFFFF";

            switch (qualityValue)
            {
                case WHITE_ID:
                    colorStr = WHITE;
                    break;
                case GREEN_ID:
                    colorStr = GREEN;
                    break;
                case BLUE_ID:
                    colorStr = BLUE;
                    break;
                case PURPLE_ID:
                    colorStr = PURPLE;
                    break;
                case ORANGE_ID:
                    colorStr = ORANGE;
                    break;
                case RED_ID:
                    colorStr = RED;
                    break;
                default:
                    colorStr = WHITE;
                    break;
            }
            return colorStr;
        }

        /// <summary>
        /// 根据颜色id获取颜色的文字
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        public static string getColorText(int colorId)
        {
            string text = "";

            switch (colorId)
            {
                case WHITE_ID:
                    text = LangConstant.WHITE;
                    break;
                case GREEN_ID:
                    text = LangConstant.GREEN;
                    break;
                case BLUE_ID:
                    text = LangConstant.BLUE;
                    break;
                case PURPLE_ID:
                    text = LangConstant.PURPLE;
                    break;
                case ORANGE_ID:
                    text = LangConstant.ORANGE;
                    break;
                case RED_ID:
                    text = LangConstant.RED;
                    break;
                default:
                    text = LangConstant.WHITE;
                    break;
            }
            return text;
        }

        /// <summary>
        /// 根据颜色id获取颜色的描述文字
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        public static string getColorDescText(int colorId)
        {
            string text = "";

            switch (colorId)
            {
                case WHITE_ID:
                    text = LangConstant.GAO_GRADE;
                    break;
                case GREEN_ID:
                    text = LangConstant.ZHONG_GRADE;
                    break;
                case BLUE_ID:
                    text = LangConstant.DI_GRADE;
                    break;
                case PURPLE_ID:
                    text = LangConstant.JIAODI_GRADE;
                    break;
                case ORANGE_ID:
                    text = LangConstant.JIDI_GRADE;
                    break;
                default:
                    text = LangConstant.GAO_GRADE;
                    break;
            }
            return text;
        }

        /// <summary>
        /// 获取品质文本
        /// </summary>
        /// <param name="qualityValue"></param>
        /// <param name="text"></param>
        /// <returns></returns>

        public static string getColorText(int qualityValue, string text)
        {
            return "<color=" + getQualityColor(qualityValue) + ">" + text + "</color>";
        }

        public static string getColorText(string color, string text)
        {
            return "<color=" + color + ">" + text + "</color>";
        }

        public static string getColorText(bool enough, string text)
        {
            return "<color=" + (enough ? GREEN : RED) + ">" + text + "</color>";
        }

        public static string getColorAndSizeText(string color, int fontsize, string text)
        {
            return "<color=" + color + "><size=" + fontsize + ">" + text + "</size></color>";
        }

        private static Material UIDefaultGray;

        private static void initUIDefaultGray()
        {
            if (UIDefaultGray == null)
            {
#if UNITY_EDITOR
                UIDefaultGray = new Material(Shader.Find("UI/Default_Gray"));
#else
                UIDefaultGray = new Material(GameClient.ins.gameShaders.FindShader("UI/Default_Gray"));
#endif
            }
        }

        public static void Gray(Image image)
        {
            initUIDefaultGray();
            //if (image.material != null)
            //{
            //    image.material.shader = UIDefaultGray;
            //}
            //else
            {
                image.material = UIDefaultGray;
            }
        }

        public static void Gray(Button button)
        {
            initUIDefaultGray();
            //if (button.image.material != null)
            //{
            //    button.image.material.shader = UIDefaultGray;
            //}
            //else
            {
                //GameObject.DestroyImmediate(button.image.material, true);
                button.image.material = UIDefaultGray;
            }
        }

        public static void Gray(RawImage image)
        {
            initUIDefaultGray();
            //if (image.material != null)
            //{
            //    image.material.shader = UIDefaultGray;
            //}
            //else
            {
                image.material = UIDefaultGray;
            }
        }

        public static void DeGray(Image image)
        {
            image.material = null;
        }

        public static void DeGray(Button button)
        {
            //GameObject.DestroyImmediate(button.image.material, true);
            button.image.material = null;
        }

        public static void DeGray(RawImage image)
        {
            //GameObject.DestroyImmediate(image.material, true);
            image.material = null;
        }

        /// <summary>
        /// 把色值字符串转换为颜色对象。
        /// </summary>
        /// <param name="color">例如:"255,255,255"。</param>
        /// <returns></returns>
        public static Color GetColorRGB(string rgb)
        {
            return GetColorRGBA(rgb);
        }

        /// <summary>
        /// 把色值字符串转换为颜色对象。
        /// </summary>
        /// <param name="color">例如:"255,255,255,255"。</param>
        /// <returns></returns>
        public static Color GetColorRGBA(string rgba)
        {
            string[] strArr = rgba.Split(new char[] { '|' });
            int len = strArr.Length;
            float r = (len >= 1 ? float.Parse(strArr[0]) / 255.0f : 0.0f);
            float g = (len >= 2 ? float.Parse(strArr[1]) / 255.0f : 0.0f);
            float b = (len >= 3 ? float.Parse(strArr[2]) / 255.0f : 0.0f);
            float a = (len >= 4 ? float.Parse(strArr[3]) / 255.0f : 1.0f);
            return new Color(r, g, b, a);
        }
    }
}

