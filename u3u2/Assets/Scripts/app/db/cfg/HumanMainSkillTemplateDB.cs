using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.pet;

namespace app.db
{
    public class HumanMainSkillTemplateDB : HumanMainSkillTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        private Dictionary<int, List<HumanMainSkillTemplate>> mXinFaListByJobType = new Dictionary<int, List<HumanMainSkillTemplate>>();
        private Dictionary<int, List<HumanMainSkillTemplate>> mXinFaListByXinFaType = new Dictionary<int, List<HumanMainSkillTemplate>>();
        private List<HumanMainSkillTemplate> mXinFaList = null;

        public List<HumanMainSkillTemplate> GetXinFaListByJobType(int jobtype)
        {
            if (mXinFaListByJobType.ContainsKey(jobtype))
            {
                return mXinFaListByJobType[jobtype];
            }

            List<HumanMainSkillTemplate> list = new List<HumanMainSkillTemplate>();
            foreach (KeyValuePair<int, HumanMainSkillTemplate> pair in idKeyDic)
            {
                if (PetJobType.ContainJob(pair.Value.jobId,jobtype))
                {
                    list.Add(pair.Value);
                }
            }
            list.Sort(Sortor);
            mXinFaListByJobType.Add(jobtype, list);
            return list;
        }

        /**
         * xinfaType(0:物理，1:法术)
         */
        public List<HumanMainSkillTemplate> GetXinFaListByXinFaType(int jobid,int xinfaType)
        {
            if (mXinFaListByXinFaType.ContainsKey(xinfaType))
            {
                return mXinFaListByXinFaType[xinfaType];
            }

            List<HumanMainSkillTemplate> list = new List<HumanMainSkillTemplate>();
            int jobindex = 0;
            foreach (KeyValuePair<int, HumanMainSkillTemplate> pair in idKeyDic)
            {
                if ((pair.Value.Id<5 && 0 == xinfaType) || (pair.Value.Id>4 && 1 == xinfaType))
                {
                    if (pair.Value.jobId == jobid)
                    {
                        list.Insert(jobindex, pair.Value);
                        jobindex++;
                    }
                    else
                    {
                        list.Add(pair.Value);
                    }
                }
            }
            //list.Sort(Sortor);
            mXinFaListByXinFaType.Add(xinfaType, list);
            return list;
        }

        public List<HumanMainSkillTemplate> GetXinFaList(int jobid)
        {
            if (mXinFaList == null)
            {
                mXinFaList = new List<HumanMainSkillTemplate>();
                int jobindex = 0;
                foreach (KeyValuePair<int, HumanMainSkillTemplate> pair in idKeyDic)
                {
                    if (pair.Value.jobId == jobid)
                    {
                        mXinFaList.Insert(jobindex, pair.Value);
                        ++jobindex;
                    }
                    else
                    {
                        mXinFaList.Add(pair.Value);
                    }
                }
                //mXinFaList.Sort(Sortor);
            }
            return mXinFaList;
        }

        public int GetXinFaType(int xinfaid)
        {
            foreach (KeyValuePair<int, HumanMainSkillTemplate> pair in idKeyDic)
            {
                if (pair.Value.Id == xinfaid)
                {
                    return pair.Value.Id > 4 ? 1 : 0;
                }
            }

            return -1;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Sortor(HumanMainSkillTemplate a, HumanMainSkillTemplate b)
        {
            //排序按照index由小到大
            if (a.Id > b.Id)
            {
                return 1;
            }
            else if (a.Id < b.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
