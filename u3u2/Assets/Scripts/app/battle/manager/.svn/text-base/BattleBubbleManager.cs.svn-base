using System;
using app.story;
using UnityEngine;

namespace app.battle
{
    public class BattleBubbleManager
    {
        public const string BUBBLE_CATCH_NAME = "app.battle.BatBubble.bubble";

        //public readonly string textBundlePath = PathUtil.Ins.GetUITexturePath("text");
        
        private static BattleBubbleManager mIns = new BattleBubbleManager();

        public static BattleBubbleManager ins
        {
            get
            {
                return mIns;
            }
        }

        public BattleBubbleManager()
        {
            if (BattleBubbleManager.ins != null)
            {
                throw new Exception("BattleBubbleManager instance already exists!");
            }
        }

        public BatBubble BubbleHPChange(int diffValue, Vector3 globalPos, bool isCrit, BatCharacterAttackType attackType, float offsetY = 0.0f,bool isStoryUse=false)
        {
            int type = diffValue >= 0 ? 3 : 2;
            return BubbleNumBubble(diffValue, type, globalPos, isCrit, attackType, offsetY,isStoryUse);
        }

        public BatBubble BubbleMPChange(int diffValue, Vector3 globalPos, bool isCrit, BatCharacterAttackType attackType, float offsetY = 0.0f)
        {
            return BubbleNumBubble(diffValue, 1, globalPos, isCrit, attackType, offsetY);
        }

        public BatBubble BubbleSPChange(int diffValue, Vector3 globalPos, bool isCrit, BatCharacterAttackType attackType, float offsetY = 0.0f)
        {
            return BubbleNumBubble(diffValue, 3, globalPos, isCrit, attackType, offsetY);
        }

        private BatBubble BubbleNumBubble(int value, int type, Vector3 globalPos, bool isCrit, BatCharacterAttackType attackType, float offsetY,bool isStoryUse=false)
        {
            //string sign = value >= 0 ? "+" : "-";
            char[] diffChars = value.ToString().ToCharArray();
            int len = diffChars.Length;

            if (value > 0)
            {
                len++;
            }
            string[] content = new string[len];

            int start = 0;
            if (value > 0)
            {
                content[0] = "+_" + type;
                start = 1;
            }

            for (int i = start; i < len; i++)
            {
                content[i] = diffChars[i - start].ToString() + "_" + type;
            }

            BatBubble bubble = CreateBubble();
            bubble.Show(content, globalPos, (isStoryUse?StoryManager.ModelMaxHeight:BattleModel.ins.maxModelHeight + offsetY), isCrit, attackType, isStoryUse);
            return bubble;
        }

        private BatBubble CreateBubble()
        {
            string cacheName = BUBBLE_CATCH_NAME;
            ICacheable ic = MemCache.FetchFreeCache(cacheName, MemCacheType.OTHER);
            if (ic == null)
            {
                BatBubble bubble = new BatBubble();
                MemCache.Cache(bubble);
                bubble.Use();
                return bubble;
            }
            ic.Use();
            return (BatBubble)ic;
        }
    }
}