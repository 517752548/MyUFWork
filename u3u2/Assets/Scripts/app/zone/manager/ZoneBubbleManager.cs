using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.net;
using app.utils;
using app.role;
using app.item;
using app.pet;
using DG.Tweening;

namespace app.zone
{
    public class ZoneBubbleManager : AbsMonoBehaviour
    {
        /// <summary>
        /// 同屏最多泡泡数。
        /// </summary>
        public const int MAX_BUBBLE_ON_SCREEN = 5;
        /// <summary>
        /// 每个泡泡的存在时间。
        /// </summary>
        public const float BUBBLE_EXIST_SECONDS = 2.5f;

        /// <summary>
        /// 飞到背包泡泡开始飞前的等待时间。
        /// </summary>
        public const float FLY_TO_BAG_WAIT_SECONDS = 0.1f;

        /// <summary>
        /// 一次最多往背包飞多少个。
        /// </summary>
        public const int MAX_FLY_TO_BAG_COUNT = 1;

        public bool isCanBubble { get; set; }

        public bool isEnabledByServer { get; set; }

        //private List<IZoneBubble> mDoingBubbles = new List<IZoneBubble>();
        //private List<IZoneBubble> mWaitingBubbles = new List<IZoneBubble>();
        private List<IZoneBubble> mDoingFlyToBagBubbles = new List<IZoneBubble>();
        private List<IZoneBubble> mWaitingFlyToBagBubbles = new List<IZoneBubble>();

        private Dictionary<ZoneBubbleContentType, List<IZoneBubble>> mDoingBubblesDict = new Dictionary<ZoneBubbleContentType, List<IZoneBubble>>();
        private Dictionary<ZoneBubbleContentType, List<ZoneBubbleConfig>> mWaitingBubblesDict = new Dictionary<ZoneBubbleContentType, List<ZoneBubbleConfig>>();

        private class ZoneBubbleConfig
        {
            public ZoneBubbleType type;
            public ZoneBubbleContentType contentType;
            public string bundlePath;
            public string imageType;
            public string imgName;
            public List<Dictionary<string, string>> richTextContent;
            public string[] imgTextContent;
            public string backGroundImgName;
            public bool showNow;
            public string flyToBagImgBundlePath;
            public int flyToBagTimes;

            public ZoneBubbleConfig(
                ZoneBubbleType type,
                ZoneBubbleContentType contentType,
                string imageType,
                string bundlePath,
                string imgName,
                List<Dictionary<string, string>> richTextContent,
                string[] imgTextContent,
                string backGroundImgName,
                bool showNow,
                string flyToBagImgBundlePath,
                int flyToBagTimes)
            {
                this.type = type;
                this.contentType = contentType;
                this.imageType = imageType;
                this.bundlePath = bundlePath;
                this.imgName = imgName;
                this.richTextContent = richTextContent;
                this.imgTextContent = imgTextContent;
                this.backGroundImgName = backGroundImgName;
                this.showNow = showNow;
                this.flyToBagImgBundlePath = flyToBagImgBundlePath;
                this.flyToBagTimes = flyToBagTimes;
            }
        }

        private static ZoneBubbleManager mIns = new ZoneBubbleManager();

        public static ZoneBubbleManager ins
        {
            get
            {
                return mIns;
            }
        }

        public ZoneBubbleManager()
        {
            if (ZoneBubbleManager.ins != null)
            {
                throw new Exception("ZoneBubbleManager instance already exists!");
            }

            isEnabledByServer = true;
        }

        /// <summary>
        /// 单张图片冒泡。
        /// </summary>
        /// <param name="bundlePath">图片所在AssetsBundle路径。</param>
        /// <param name="imgName">单张图片名称（图片所在的AssetsBundle是一个集合时用到）。</param>
        /// <param name="background">冒泡的背景。</param>
        /// <param name="showNow">If set to <c>true</c> 是否忽略队列，立即显示。</param>
        /// <param name="flyToBagTextureBundlePath">往背包里飞的贴图路径。</param>
        /// <param name="flyToBagTimes">往背包里飞几次。</param>
        public void BubbleImage(
            string imageType,
            string bundlePath,
            string imgName,
            string backgroundName = null,
            bool showNow = false,
            string flyToBagTextureBundlePath = null,
            int flyToBagTimes = 0,
            ZoneBubbleContentType contentType = ZoneBubbleContentType.DEFAULT)
        {
            /*
            ZoneImageBubble bubble = new ZoneImageBubble(bundlePath, imgName, background, contentType);
            bubble.flyToBagTextureBundlePath = flyToBagTextureBundlePath;
            bubble.flyToBagTimes = flyToBagTimes;
            PushBubble(bubble, showNow);
            */
            ZoneBubbleConfig bubbleCfg = new ZoneBubbleConfig(
                ZoneBubbleType.IMAGE, contentType, imageType, bundlePath, imgName, null, null,
                backgroundName, showNow, flyToBagTextureBundlePath, flyToBagTimes);
            PushBubble(bubbleCfg);
        }

        /// <summary>
        /// 富文本冒泡。
        /// </summary>
        /// <param name="bundlePath">富文本内容。</param>
        /// <param name="background">冒泡的背景。</param>
        /// <param name="showNow">If set to <c>true</c> 是否忽略队列，立即显示。</param>
        /// <param name="flyToBagTextureBundlePath">往背包里飞的贴图路径。</param>
        /// <param name="flyToBagTimes">往背包里飞几次。</param>
        public void BubbleRichText(
            List<Dictionary<string, string>> content,
            string backgroundName = null,
            bool showNow = false,
            string flyToBagTextureBundlePath = null,
            int flyToBagTimes = 0,
            ZoneBubbleContentType contentType = ZoneBubbleContentType.DEFAULT)
        {
            /*
            ZoneRichTextBubble bubble = new ZoneRichTextBubble(content, background, contentType);
            bubble.flyToBagTextureBundlePath = flyToBagTextureBundlePath;
            bubble.flyToBagTimes = flyToBagTimes;
            PushBubble(bubble, showNow);
            */
            ZoneBubbleConfig bubbleCfg = new ZoneBubbleConfig(
                ZoneBubbleType.RICH_TEXT, contentType, null, null, null, content, null,
                backgroundName, showNow, flyToBagTextureBundlePath, flyToBagTimes);
            PushBubble(bubbleCfg);
        }

        /// <summary>
        /// 图片字文本冒泡。
        /// </summary>
        /// <param name="bundlePath">图片字文本内容。</param>
        /// /// <param name="bundlePath">图片字们所在AssetsBundle路径。</param>
        /// <param name="background">冒泡的背景。</param>
        /// <param name="showNow">If set to <c>true</c> 是否忽略队列，立即显示。</param>
        /// <param name="flyToBagTextureBundlePath">往背包里飞的贴图路径。</param>
        /// <param name="flyToBagTimes">往背包里飞几次。</param>
        public void BubbleImageText(
            string imageType,
            string bundlePath,
            string[] content,
            string backgroundName = null,
            bool showNow = false,
            string flyToBagTextureBundlePath = null,
            int flyToBagTimes = 0,
            ZoneBubbleContentType contentType = ZoneBubbleContentType.DEFAULT)
        {
            /*
            ZoneImageTextBubble bubble = new ZoneImageTextBubble(content, background, contentType);
            bubble.flyToBagTextureBundlePath = flyToBagTextureBundlePath;
            bubble.flyToBagTimes = flyToBagTimes;
            PushBubble(bubble, showNow);
            */
            /*
            ZoneBubbleType type,
                ZoneBubbleContentType contentType,
                string imageType,
                string bundlePath,
                string imgName,
                List<Dictionary<string, string>> richTextContent,
                string[] imgTextContent,
                string backGroundImgName,
                bool showNow,
                string flyToBagImgBundlePath,
                int flyToBagTimes
            */
            ZoneBubbleConfig bubbleCfg = new ZoneBubbleConfig(
                ZoneBubbleType.IMAGE_TEXT, contentType, imageType, bundlePath, null, null, content,
                backgroundName, showNow, flyToBagTextureBundlePath, flyToBagTimes);
            PushBubble(bubbleCfg);
        }

        /// <summary>
        /// 强制立刻冒出一行文本。
        /// </summary>
        /// <param name="text"></param>
        public void BubbleSysMsg(string text, bool showNow = true, ZoneBubbleContentType contenttype = ZoneBubbleContentType.DEFAULT)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", "text");
            dic.Add("text", text);
            list.Add(dic);
            BubbleRichText(list, "bubbleBackground", showNow, null, 0, contenttype);
        }

        public void BubbleItemChange(CommonItemData itemData, int changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            if (changeValue > 0)
            {
                ItemDetailData detailData = new ItemDetailData();
                detailData.setData(itemData);
                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                Dictionary<string, string> txtDict1 = new Dictionary<string, string>();
                txtDict1.Add("type", "text");
                txtDict1.Add("text", LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(detailData.GetItemColorInt(), detailData.itemTemplate.name));
                content.Add(txtDict1);
                Dictionary<string, string> imgDict = new Dictionary<string, string>();
                imgDict.Add("type", "img");
                imgDict.Add("imageType", "sprite");
                imgDict.Add("src", PathUtil.Ins.itemAtlasPath);
                imgDict.Add("name", detailData.itemTemplate.icon);
                imgDict.Add("height", "40");
                content.Add(imgDict);
                Dictionary<string, string> txtDict2 = new Dictionary<string, string>();
                txtDict2.Add("type", "text");
                txtDict2.Add("text", ColorUtil.getColorText(detailData.GetItemColorInt(), "x" + changeValue));
                content.Add(txtDict2);
                //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                string flyToBagTextureBundlePath = detailData.itemTemplate.icon;
                    //PathUtil.Ins.GetUITexturePath(detailData.itemTemplate.icon, PathUtil.TEXTUER_ITEM);
                //BubbleRichText(content, "bubbleBackground", false, flyToBagTextureBundlePath, changeValue, ZoneBubbleContentType.SOMETHING_CHANGE);
                BubbleRichText(content, "bubbleBackground", false, flyToBagTextureBundlePath, changeValue, ZoneBubbleContentType.DEFAULT);
            }
        }

        public void BubbleAddPet(Pet pet)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
            Dictionary<string, string> textDict1 = new Dictionary<string, string>();
            textDict1.Add("type", "text");
            textDict1.Add("text", LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(pet.getColorId(), pet.getTpl().name));
            content.Add(textDict1);
            Dictionary<string, string> imgDict = new Dictionary<string, string>();
            imgDict.Add("type", "img");
            imgDict.Add("imageType", "sprite");
            imgDict.Add("src", PathUtil.Ins.headAtlasPath);
            imgDict.Add("name", pet.getTpl().modelId);
            imgDict.Add("height", "33");
            content.Add(imgDict);
            Dictionary<string, string> txtDict2 = new Dictionary<string, string>();
            txtDict2.Add("type", "text");
            txtDict2.Add("text", ColorUtil.getColorText(pet.getColorId(), "x1"));
            content.Add(txtDict2);
            //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
            //BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.SOMETHING_CHANGE);
            BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
        }

        public void BubbleHumanIntPropChange(int key, int changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            if (changeValue > 0)
            {
                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                /*
                if (key == RoleBaseIntProperties.VIP_EXP)
                {
                    if (changeValue > 0)
                    {
                        Dictionary<string, string> textDict = new Dictionary<string, string>();
                        textDict.Add("type", "text");
                        textDict.Add("text", LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(ColorUtil.GREEN, changeValue.ToString()));
                        content.Add(textDict);
                        Dictionary<string, string> imgDict = new Dictionary<string, string>();
                        imgDict.Add("type", "text");
                        imgDict.Add("text", ColorUtil.getColorText(ColorUtil.GREEN, "<VIP_EXP>"));
                        content.Add(imgDict);
                    }
                }
                else
                */
                
                /*
                if (key == RoleBaseIntProperties.FIGHT_POWER)
                {
                    int colorID = changeValue > 0 ? ColorUtil.GREEN_ID : ColorUtil.RED_ID;
                    string valueStr = changeValue > 0 ? "+" + (changeValue.ToString()) : changeValue.ToString();

                    Dictionary<string, string> textDict = new Dictionary<string, string>();
                    textDict.Add("type", "text");
                    textDict.Add("text", LangConstant.FIGHT_POWER + ColorUtil.getColorText(colorID, valueStr));
                    content.Add(textDict);
                }
                */

                if (content.Count > 0)
                {
                    //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    //BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.SOMETHING_CHANGE);
                    BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
                }
            }
        }

        public void BubbleHumanLongPropChange(int key, long changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            if (changeValue > 0)
            {
                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                List<int> showBubbleMoneyKey = new List<int>();
                showBubbleMoneyKey.Add(RoleBaseStrProperties.GOLD);
                showBubbleMoneyKey.Add(RoleBaseStrProperties.GOLD_2);
                showBubbleMoneyKey.Add(RoleBaseStrProperties.ALL_BOND);
                showBubbleMoneyKey.Add(RoleBaseStrProperties.GIFT_BOND);
                showBubbleMoneyKey.Add(RoleBaseStrProperties.SKILL_POINT);

                List<int> showBubbleCurrencyType = new List<int>();
                showBubbleCurrencyType.Add(CurrencyTypeDef.GOLD);
                showBubbleCurrencyType.Add(CurrencyTypeDef.GOLD_2);
                showBubbleCurrencyType.Add(CurrencyTypeDef.BOND);
                showBubbleCurrencyType.Add(CurrencyTypeDef.GIFT_BOND);
                showBubbleCurrencyType.Add(CurrencyTypeDef.SKILL_POINT);

                if (showBubbleMoneyKey.Contains(key))
                {
                    Dictionary<string, string> textDict = new Dictionary<string, string>();
                    textDict.Add("type", "text");
                    textDict.Add("text", LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(ColorUtil.GREEN, changeValue.ToString()));
                    content.Add(textDict);
                    Dictionary<string, string> imgDict = new Dictionary<string, string>();
                    imgDict.Add("type", "img");
                    imgDict.Add("imageType", "sprite");
                    imgDict.Add("src", PathUtil.Ins.uiDependenciesPath);
                    imgDict.Add("name", CurrencyTypeDef.GetCurrencyIcon(showBubbleCurrencyType[showBubbleMoneyKey.IndexOf(key)]));
                    imgDict.Add("height", "27");
                    content.Add(imgDict);
                }

                if (content.Count > 0)
                {
                    //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    //BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.SOMETHING_CHANGE);
                    BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
                }
            }
        }

        public void BubbleHumanEXPChange(long changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
            Dictionary<string, string> textDict = new Dictionary<string, string>();
            textDict.Add("type", "text");
            textDict.Add("text",
                LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(ColorUtil.GREEN, changeValue.ToString()));
            content.Add(textDict);
            Dictionary<string, string> imgDict = new Dictionary<string, string>();
            imgDict.Add("type", "img");
            imgDict.Add("imageType", "sprite");
            imgDict.Add("src", PathUtil.Ins.uiDependenciesPath);
            imgDict.Add("name", "exp2");
            imgDict.Add("height", "27");
            content.Add(imgDict);
            if (content.Count > 0)
            {
                //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                //BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.SOMETHING_CHANGE);
                BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
            }
        }

        public void BubbleLeaderIntPropChange(Pet pet, int key, int changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }

            BubblePetIntPropChange(pet, key, changeValue);
        }

        public void BubbleLeaderLongPropChange(Pet pet, int key, long changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }
            /*
            if (key == RoleBaseStrProperties.EXP)
            {
                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                Dictionary<string, string> textDict = new Dictionary<string, string>();
                textDict.Add("type", "text");
                textDict.Add("text",
                    LangConstant.YOU_HAVE_GOT + ColorUtil.getColorText(ColorUtil.GREEN, changeValue.ToString()));
                content.Add(textDict);
                Dictionary<string, string> imgDict = new Dictionary<string, string>();
                imgDict.Add("type", "img");
                imgDict.Add("src", PathUtil.Ins.uiDependenciesPath);
                imgDict.Add("name", "exp2");
                imgDict.Add("height", "27");
                content.Add(imgDict);
                if (content.Count > 0)
                {
                    GameObject background =
                        (GameObject) (GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    BubbleRichText(content, background, false, false, null, 0, ZoneBubbleType.PROP_CHANGE);
                }
            }
            else
            */
            //{
            BubblePetLongPropChange(pet, key, changeValue);
            //}
        }

        public void BubblePetIntPropChange(Pet pet, int key, int changeValue)
        {
            /*
            if (changeValue != 0)
            {
                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();

                string name = LangConstant.getPetPropertyName(key);
                string valueStr = ColorUtil.getColorText(pet.getColorId(), pet.getName()) + " ";
                valueStr += changeValue > 0 ? 
                    ColorUtil.getColorText(ColorUtil.GREEN, name + " +" + changeValue.ToString()) :
                    ColorUtil.getColorText(ColorUtil.RED, name + " " + changeValue.ToString());

                Dictionary<string, string> textDict = new Dictionary<string, string>();
                textDict.Add("type", "text");
                textDict.Add("text", valueStr);
                content.Add(textDict);

                GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                BubbleRichText(content, background);
            }
            */
            if (!isEnabledByServer)
            {
                return;
            }
            BubblePetLongPropChange(pet, key, changeValue);
        }

        public void BubblePetLongPropChange(Pet pet, int key, long changeValue)
        {
            if (!isEnabledByServer)
            {
                return;
            }
            //if (changeValue != 0 && (PropertyType.isPetAProp(key) || PropertyType.isPetBProp(key)))
            if (changeValue != 0 && (PropertyType.isPetBProp(key)))
            {
                if (key == PetBProperty.HP ||
                    key == PetBProperty.MP ||
                    key == PetBProperty.SPEED ||
                    (key == PetBProperty.MAGIC_ATTACK && pet.getTpl().attackTypeId == 2) ||
                    (key == PetBProperty.PHYSICAL_ATTACK && pet.getTpl().attackTypeId == 1))
                {

                    List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();

                    string name = LangConstant.getPetPropertyName(key);
                    string valueStr = ColorUtil.getColorText(pet.getColorId(), pet.getName()) + " ";
                    valueStr += changeValue > 0 ?
                        ColorUtil.getColorText(ColorUtil.GREEN, name + " +" + changeValue.ToString()) :
                        ColorUtil.getColorText(ColorUtil.RED, name + " " + changeValue.ToString());

                    Dictionary<string, string> textDict = new Dictionary<string, string>();
                    textDict.Add("type", "text");
                    textDict.Add("text", valueStr);
                    content.Add(textDict);

                    //GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    //BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.SOMETHING_CHANGE);
                    BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
                }
            }
        }

        /// <summary>
        /// 往背包里飞的泡泡。
        /// </summary>
        /// <param name="bubble">Bubble.</param>
        private void FlyToBag(IZoneBubble bubble)
        {
            bubble.gameObject.transform.localPosition = Vector3.zero;
            bubble.secondsLeft = FLY_TO_BAG_WAIT_SECONDS;
            bubble.gameObject.SetActive(false);
            mWaitingFlyToBagBubbles.Add(bubble);
        }

        private void PushBubble(ZoneBubbleConfig bubbleCfg)
        {
            List<IZoneBubble> doingBubbles = null;
            List<ZoneBubbleConfig> waitingBubbles = null;

            if (!mDoingBubblesDict.ContainsKey(bubbleCfg.contentType))
            {
                doingBubbles = new List<IZoneBubble>();
                mDoingBubblesDict.Add(bubbleCfg.contentType, doingBubbles);
            }
            else
            {
                doingBubbles = mDoingBubblesDict[bubbleCfg.contentType];
            }

            if (!mWaitingBubblesDict.ContainsKey(bubbleCfg.contentType))
            {
                waitingBubbles = new List<ZoneBubbleConfig>();
                mWaitingBubblesDict.Add(bubbleCfg.contentType, waitingBubbles);
            }
            else
            {
                waitingBubbles = mWaitingBubblesDict[bubbleCfg.contentType];
            }

            if (isCanBubble)
            {
                //可以冒泡。
                if (doingBubbles.Count == MAX_BUBBLE_ON_SCREEN)
                {
                    if (bubbleCfg.showNow)
                    {
                        /*
                        doingBubbles[0].UnUse();
                        doingBubbles.RemoveAt(0);
                        IZoneBubble bubble = CreateBubble(bubbleCfg);
                        if (bubble != null)
                        {
                            doingBubbles.Add(bubble);
                            TweenBubble(bubble);
                        }
                        */
                        waitingBubbles.Insert(0, bubbleCfg);
                    }
                    else
                    {
                        waitingBubbles.Add(bubbleCfg);
                    }
                }
                else
                {
                    /*
                    IZoneBubble bubble = CreateBubble(bubbleCfg);
                    if (bubble != null)
                    {
                        doingBubbles.Add(bubble);
                        TweenBubble(bubble);
                    }
                    */

                    if (bubbleCfg.showNow)
                    {
                        int len = doingBubbles.Count;
                        if (len == 0 || doingBubbles[len - 1].isMoveFinished)
                        {
                            IZoneBubble bubble = CreateBubble(bubbleCfg);
                            if (bubble != null)
                            {
                                doingBubbles.Add(bubble);
                                TweenBubble(bubble);
                            }
                        }
                        else
                        {
                            waitingBubbles.Insert(0, bubbleCfg);
                        }
                    }
                    else
                    {
                        waitingBubbles.Add(bubbleCfg);
                    }
                }
            }
            else
            {
                //不可以冒泡。
                if (bubbleCfg.showNow)
                {
                    if (doingBubbles.Count == MAX_BUBBLE_ON_SCREEN)
                    {
                        doingBubbles[0].UnUse();
                        doingBubbles.RemoveAt(0);
                    }

                    IZoneBubble bubble = CreateBubble(bubbleCfg);
                    if (bubble != null)
                    {
                        doingBubbles.Add(bubble);
                        TweenBubble(bubble);
                    }
                }
                else
                {
                    waitingBubbles.Add(bubbleCfg);
                }
            }
        }

        private IZoneBubble CreateBubble(ZoneBubbleConfig bubbleCfg)
        {
            GameObject background = null;

            IZoneBubble bubble = null;
            ICacheable ic = null;

            if (bubbleCfg.type == ZoneBubbleType.IMAGE)
            {
                ic = MemCache.FetchFreeCache(ZoneImageBubble.CACHE_NAME, MemCacheType.OTHER);
                if (ic == null)
                {
                    if (!string.IsNullOrEmpty(bubbleCfg.backGroundImgName))
                    {
                        background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    }
                    ic = new ZoneImageBubble(bubbleCfg.imageType, bubbleCfg.bundlePath, bubbleCfg.imgName, background);
                    ic.Use();
                    MemCache.Cache(ic);
                }
                else
                {
                    ic.Use();
                    ((ZoneImageBubble)ic).SetContent(bubbleCfg.imageType, bubbleCfg.bundlePath, bubbleCfg.imgName);
                }
            }
            else if (bubbleCfg.type == ZoneBubbleType.IMAGE_TEXT)
            {
                ic = MemCache.FetchFreeCache(ZoneImageTextBubble.CACHE_NAME, MemCacheType.OTHER);
                if (ic == null)
                {
                    if (!string.IsNullOrEmpty(bubbleCfg.backGroundImgName))
                    {
                        background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    }
                    ic = new ZoneImageTextBubble(bubbleCfg.bundlePath, bubbleCfg.imgTextContent, background);
                    ic.Use();
                    MemCache.Cache(ic);
                }
                else
                {
                    ic.Use();
                    ((ZoneImageTextBubble)ic).SetContent(bubbleCfg.bundlePath, bubbleCfg.imgTextContent);
                }
            }
            else if (bubbleCfg.type == ZoneBubbleType.RICH_TEXT)
            {
                ic = MemCache.FetchFreeCache(ZoneRichTextBubble.CACHE_NAME, MemCacheType.OTHER);
                if (ic == null)
                {
                    if (!string.IsNullOrEmpty(bubbleCfg.backGroundImgName))
                    {
                        background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                    }
                    ic = new ZoneRichTextBubble(bubbleCfg.richTextContent, background);
                    ic.Use();
                    MemCache.Cache(ic);
                }
                else
                {
                    ic.Use();
                    ((ZoneRichTextBubble)ic).SetContent(bubbleCfg.richTextContent);
                }
            }

            if (ic != null)
            {
                bubble = (IZoneBubble)ic;
                if (bubble != null)
                {
                    bubble.flyToBagTextureBundlePath = bubbleCfg.flyToBagImgBundlePath;
                    bubble.flyToBagTimes = bubbleCfg.flyToBagTimes;
                    bubble.secondsLeft = BUBBLE_EXIST_SECONDS;
                    //bubble.gameObject.GetComponent<CanvasGroup>().alpha = 0;
                    /*
                    if (bubbleCfg.contentType == ZoneBubbleContentType.SYSTEM_MESSAGE)
                    {
                        bubble.gameObject.transform.localPosition = new Vector3(0, bubble.height / 2.0f, 0);
                    }
                    */
                }
            }

            return bubble;
        }

        /// <summary>
        /// 在ZoneManager的Update中调用。
        /// </summary>
        public override void DoUpdate(float deltaTime)
        {
            IDictionaryEnumerator enumerator = mDoingBubblesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                List<IZoneBubble> doingBubbles = (List<IZoneBubble>)enumerator.Value;
                int len = doingBubbles.Count;
                for (int i = 0; i < len; i++)
                {
                    doingBubbles[i].secondsLeft -= deltaTime;
                    if (doingBubbles[i].secondsLeft <= 0.0f)
                    {
                        doingBubbles[i].UnUse();
                        doingBubbles.RemoveAt(i);
                        i--;
                        len--;
                        continue;
                    }
                    else if (doingBubbles[i].secondsLeft <= 0.3f)
                    {
                        doingBubbles[i].FadeOut();
                    }
                }

                if (isCanBubble)
                {
                    if (len == 0 || doingBubbles[len - 1].isMoveFinished)
                    {
                        if (len < MAX_BUBBLE_ON_SCREEN)
                        {
                            List<ZoneBubbleConfig> waitingBubbles = null;
                            mWaitingBubblesDict.TryGetValue((ZoneBubbleContentType)enumerator.Key, out waitingBubbles);
                            if (waitingBubbles != null && waitingBubbles.Count > 0)
                            {
                                ZoneBubbleConfig bubbleCfg = waitingBubbles[0];
                                waitingBubbles.RemoveAt(0);
                                IZoneBubble bubble = CreateBubble(bubbleCfg);
                                if (bubble != null)
                                {
                                    doingBubbles.Add(bubble);
                                    TweenBubble(bubble);
                                    len++;
                                }
                            }
                        }
                    }
                }
            }

            UpdateFlyToBagBubbles();
        }

        private void UpdateFlyToBagBubbles()
        {
            int len = mWaitingFlyToBagBubbles.Count;
            if (len > 0)
            {
                IZoneBubble bubble = mWaitingFlyToBagBubbles[0];
                if (bubble.secondsLeft <= 0)
                {
                    FlyBubbleToBag(bubble);
                    mWaitingFlyToBagBubbles.RemoveAt(0);
                }
                else
                {
                    bubble.secondsLeft -= Time.deltaTime;
                }
            }

            len = mDoingFlyToBagBubbles.Count;
            for (int i = 0; i < len; i++)
            {
                if (mDoingFlyToBagBubbles[i].isDestroied)
                {
                    mDoingFlyToBagBubbles.RemoveAt(i);
                    i--;
                    len--;
                }
            }
        }

        private void TweenBubble(IZoneBubble bubble)
        {
            if (!bubble.gameObject.activeSelf)
            {
                bubble.gameObject.SetActive(true);
            }

            //bubble.gameObject.GetComponent<CanvasGroup>().alpha = 1;
            bubble.gameObject.transform.localPosition = Vector3.zero;

            Vector3 pos = new Vector3(0, bubble.height + 5, 0);

            bubble.Move(pos);
            //bubble.FadeOut();
            if (bubble.moveTweener != null)
            {
                bubble.moveTweener.OnUpdate(UpdateBubblesPosition);
            }

            /*
            if (bubble.flyToBagTextureBundlePath != null)
            {
                for (int i = 0; i < bubble.flyToBagTimes; i++)
                {
                    if (i < MAX_FLY_TO_BAG_COUNT)
                    {
                        FlyToBag(new ZoneImageBubble(bubble.flyToBagTextureBundlePath, null));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            */
        }

        private void UpdateBubblesPosition()
        {
            IDictionaryEnumerator enumerator = mDoingBubblesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                List<IZoneBubble> doingBubbles = (List<IZoneBubble>)enumerator.Value;

                int len = doingBubbles.Count;
                for (int i = len - 1; i >= 1; i--)
                {
                    IZoneBubble downBubble = doingBubbles[i];
                    if (!downBubble.isDestroied)
                    {
                        Vector3 downBubblePos = downBubble.gameObject.transform.localPosition;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            IZoneBubble upBubble = doingBubbles[j];
                            if (!upBubble.isDestroied)
                            {
                                Vector3 upBubblePos = upBubble.gameObject.transform.localPosition;

                                if ((upBubblePos.y - downBubblePos.y) < (upBubble.height + downBubble.height) / 2.0f + 5)
                                {
                                    upBubble.KillMoveTweener();
                                    upBubblePos.y = downBubblePos.y + (upBubble.height + downBubble.height) / 2.0f + 5;
                                    upBubble.gameObject.transform.localPosition = upBubblePos;
                                }

                                break;
                            }
                        }
                    }
                }
            }
        }

        private void FlyBubbleToBag(IZoneBubble bubble)
        {
            mDoingFlyToBagBubbles.Add(bubble);

            Vector3 pos = Vector3.zero;
            if (ZoneUI.ins.UI != null && ZoneUI.ins.isShown)
            {
                if (ZoneUI.ins.isShowingBtns)
                {
                    pos = ZoneUI.ins.GetBagBtnWorldPos();
                }
                else
                {
                    pos = ZoneUI.ins.GetBaGuaBtnWorldPos();
                }

                pos = UGUIConfig.GetCanvasByWndType(WndType.POPTIPS).transform.InverseTransformPoint(pos);
            }
            else
            {
                Vector2 size = UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).GetComponent<RectTransform>().sizeDelta;
                Vector3 scale = UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).GetComponent<RectTransform>().localScale;
                pos.x = size.x / 2.0f;
                pos.y = -size.y / 2.0f;
                pos.Scale(scale);
            }
            pos.z = 0f;
            bubble.gameObject.SetActive(true);
            bubble.Move(pos);
            if (bubble.moveTweener != null)
            {
                bubble.moveTweener.OnComplete(bubble.Destroy);
            }
            //TweenUtil.MoveTo(bubble.gameObject.transform, pos, 1, null, bubble.Destroy);
        }

        /// <summary>
        /// 清除所有显示和未显示的泡泡。
        /// </summary>
        public void Clear()
        {
            int len = 0;

            IDictionaryEnumerator enumerator = mDoingBubblesDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                List<IZoneBubble> doingBubbles = (List<IZoneBubble>)enumerator.Value;

                len = doingBubbles.Count;
                for (int i = 0; i < len; i++)
                {
                    doingBubbles[i].UnUse();
                }

                doingBubbles.Clear();
            }

            mDoingBubblesDict.Clear();

            len = mWaitingFlyToBagBubbles.Count;
            for (int i = 0; i < len; i++)
            {
                mWaitingFlyToBagBubbles[i].UnUse();
            }

            mWaitingFlyToBagBubbles.Clear();

            len = mDoingFlyToBagBubbles.Count;
            for (int i = 0; i < len; i++)
            {
                mDoingFlyToBagBubbles[i].UnUse();
            }

            mDoingFlyToBagBubbles.Clear();
        }

        /*
        /// <summary>
        /// 通用奖励冒泡。
        /// </summary>
        /// <param name="data">奖励内容。</param>
        public void BubbleReward(RewardData data)
        {
            List<Dictionary<string, string>> valueContent = new List<Dictionary<string, string>>();
            List<IZoneBubble> bubbles = new List<IZoneBubble>();

            int len = data.items.Count;
            for (int i = 0; i < len; i++)
            {
                RewardItemData itemData = data.items[i];
                switch (itemData.type)
                {
                    case RewardType.CURRENCY_BOUND:

                        break;
                    case RewardType.CURRENCY_GIFT_BOND:

                        break;
                    case RewardType.CURRENCY_GOLD:
                        {
                            Dictionary<string, string> dict = null;
                            if (valueContent.Count > 0)
                            {
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", ", ");
                                valueContent.Add(dict);
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", "GOLD*" + itemData.ivalue.ToString());
                                valueContent.Add(dict);
                            }
                            else
                            {
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", LangConstant.YOU_HAVE_GOT + "GOLD*" + itemData.ivalue.ToString());
                                valueContent.Add(dict);
                            }
                        }
                        break;
                    case RewardType.CURRENCY_HONOR:

                        break;
                    case RewardType.CURRENCY_POWER:

                        break;
                    case RewardType.CURRENCY_SKILL_POINT:

                        break;
                    case RewardType.CURRENCY_SYS_BOND:

                        break;
                    case RewardType.EXP:
                        {
                            Dictionary<string, string> dict = null;
                            if (valueContent.Count > 0)
                            {
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", ", ");
                                valueContent.Add(dict);
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", "EXP*" + itemData.ivalue.ToString());
                                valueContent.Add(dict);
                            }
                            else
                            {
                                dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", LangConstant.YOU_HAVE_GOT + "EXP*" + itemData.lvalue.ToString());
                                valueContent.Add(dict);
                            }
                        }
                        break;
                    case RewardType.ITEM:
                        {
                            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(itemData.id);
                            if (itemTpl != null)
                            {
                                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                                Dictionary<string, string> dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", LangConstant.YOU_HAVE_GOT + itemTpl.name + "*" + itemData.ivalue);
                                content.Add(dict);
                                GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                                ZoneRichTextBubble itemBubble = new ZoneRichTextBubble(content, background);
                                itemBubble.flyToBagTextureBundlePath = PathUtil.Ins.GetUITexturePath(itemTpl.icon, PathUtil.TEXTUER_ITEM);
                                itemBubble.flyToBagTimes = itemData.ivalue;
                                bubbles.Add(itemBubble);
                            }
                        }
                        break;
                    case RewardType.PET:
                        {
                            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(itemData.id);
                            if (petTpl != null)
                            {
                                List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
                                Dictionary<string, string> dict = new Dictionary<string, string>();
                                dict.Add("type", "text");
                                dict.Add("text", LangConstant.YOU_HAVE_GOT + petTpl.name + "*1");
                                content.Add(dict);
                                GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                                ZoneRichTextBubble petBubble = new ZoneRichTextBubble(content, background);
                                bubbles.Add(petBubble);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            if (valueContent.Count > 0)
            {
                GameObject background = (GameObject)(GameObject.Instantiate(SourceManager.Ins.GetCommonUI("bubbleBackground")));
                ZoneRichTextBubble valueBubble = new ZoneRichTextBubble(valueContent, background);
                bubbles.Insert(0, valueBubble);
            }

            len = bubbles.Count;
            for (int i = 0; i < len; i++)
            {
                PushBubble(bubbles[i], false);
            }

            bubbles.Clear();
        }
        */
    }
}