using System.Collections;
using System.Collections.Generic;
using app.utils;

namespace app.battle
{
    /// <summary>
    /// 一回合的一个阶段中所有的行为数据。
    /// </summary>
    public abstract class BatRoundStageData
    {
        public List<BatRoundBehavData> startItems { get; protected set; }
        public List<BatRoundBehavData> exeItems { get; protected set; }
        public List<BatRoundBehavData> defItems { get; protected set; }
        public List<BatRoundBehavData> adjustItems { get; protected set; }
        public List<BatRoundBehavData> endItems { get; protected set; }

        protected float mSecondsCost = 0;

        private BatRoundStageType mStageType = BatRoundStageType.NONE;
        
        public BatRoundStageData(BatRoundStageType stageType)
        {
            startItems = new List<BatRoundBehavData>();
            exeItems = new List<BatRoundBehavData>();
            defItems = new List<BatRoundBehavData>();
            adjustItems = new List<BatRoundBehavData>();
            endItems = new List<BatRoundBehavData>();
            mStageType = stageType;
        }

        public abstract void Parse(object data);
        public abstract float secondsCost { get; }

        protected void ParseBehavItemDatas(IList datas, List<BatRoundBehavData> items)
        {
            if (datas != null && items != null)
            {
                int len = datas.Count;
                for (int i = 0; i < len; i++)
                {
                    IDictionary data = (IDictionary)(datas[i]);

                    if (data.Contains(BattleReportDef.RECORD_CONTENT_SKILLID.ToString()))
                    {
                        //技能。
                        BatRoundSkillData skillData = new BatRoundSkillData(mStageType);
                        skillData.Parse(data, items == exeItems);
                        if (skillData.skillTpl.Id == BatSkillID.USE_ITEM)
                        {
                            int skillResLen = skillData.results.Count;
                            for (int j = 0; j < skillResLen; j++)
                            {
                                if (!skillData.results[j].isUseDrugsSuccess)
                                {
                                    ClientLog.LogWarning("不体现嗑药失败的战报。");
                                    continue;
                                }
                            }
                        }
                        items.Add(skillData);
                        mSecondsCost += BattleDef.DEFAULT_SKILL_SECONDS_COST;
                    }
                    else
                    {
                        ClientLog.LogError("并没有解析技能以外的行为数据!");
                    }
                }
            }
        }

        public bool isStartDone
        {
            get
            {
                int len = startItems.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!startItems[i].isDone)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isExecuteDone
        {
            get
            {
                int len = exeItems.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!exeItems[i].isDone)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isDefenceDone
        {
            get
            {
                int len = defItems.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!defItems[i].isDone)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isAdjustDone
        {
            get
            {
                int len = adjustItems.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!adjustItems[i].isDone)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isEndDone
        {
            get
            {
                int len = endItems.Count;
                for (int i = 0; i < len; i++)
                {
                    if (!endItems[i].isDone)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isDone
        {
            get
            {
                return isStartDone && isExecuteDone && isDefenceDone && isAdjustDone && isEndDone;
            }
        }
    }
}