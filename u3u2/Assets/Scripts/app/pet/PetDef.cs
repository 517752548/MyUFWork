using System;
using System.Collections.Generic;
using app.db;
using app.role;
using UnityEngine;

namespace app.pet
{
    public class PetDef
    {
        /// <summary>
        /// 一级属性的显示顺序
        /// </summary>
        public static List<int> PetAPropKeyList;
        /// <summary>
        /// 一级属性 已经增加的显示顺序
        /// </summary>
        public static List<int> PetAddedAPropKeyList;

        /// <summary>
        /// 获取 一级属性的显示顺序，属性的key
        /// </summary>
        /// <returns></returns>
        public static List<int> GetPetAPropKeyList()
        {
            if (PetAPropKeyList == null)
            {
                PetAPropKeyList=new List<int>();
                PetAPropKeyList.Add(PetAProperty.STRENGTH);
                PetAPropKeyList.Add(PetAProperty.AGILITY);
                PetAPropKeyList.Add(PetAProperty.INTELLECT);
                PetAPropKeyList.Add(PetAProperty.FAITH);
                PetAPropKeyList.Add(PetAProperty.STAMINA);
            }
            return PetAPropKeyList;
        }

        /// <summary>
        /// 获取 一级属性 已经增加的显示顺序，属性的key
        /// </summary>
        /// <returns></returns>
        public static List<int> GetPetAddedAPropKeyList()
        {
            if (PetAddedAPropKeyList == null)
            {
                PetAddedAPropKeyList = new List<int>();
                PetAddedAPropKeyList.Add(PetAProperty.STRENGTH_GROWTH);
                PetAddedAPropKeyList.Add(PetAProperty.AGILITY_GROWTH);
                PetAddedAPropKeyList.Add(PetAProperty.INTELLECT_GROWTH);
                PetAddedAPropKeyList.Add(PetAProperty.FAITH_GROWTH);
                PetAddedAPropKeyList.Add(PetAProperty.STAMINA_GROWTH);
            }
            return PetAddedAPropKeyList;
        } 

        /// <summary>
        /// 二级属性的显示顺序，key为职业，列表为该职业要显示的二级属性
        /// </summary>
        public static Dictionary<int, List<int>> PetBPropKeyListDic;
        /// <summary>
        /// 根据职业获取，二级属性的显示顺序，key为职业，列表为该职业要显示的二级属性
        /// </summary>
        public static List<int> GetPetBPropKeyListByJobType(int jobtype)
        {
            if (PetBPropKeyListDic==null)
            {
                PetBPropKeyListDic = new Dictionary<int, List<int>>();
                List<int> list = new List<int> {
                    PetBProperty.HP,
                    PetBProperty.MP,
                    PetBProperty.PHYSICAL_ATTACK,
                    PetBProperty.PHYSICAL_ARMOR,
                    PetBProperty.PHYSICAL_HIT,
                    PetBProperty.PHYSICAL_DODGY,
                    PetBProperty.PHYSICAL_CRIT,
                    PetBProperty.PHYSICAL_ANTICRIT,
                    //PetBProperty.MAGIC_ATTACK,
                    PetBProperty.MAGIC_ARMOR,
                    //PetBProperty.MAGIC_HIT,
                    PetBProperty.MAGIC_DODGY,
                    //PetBProperty.MAGIC_CRIT,
                    PetBProperty.MAGIC_ANTICRIT,
                    PetBProperty.SPEED,
                    //PetBProperty.SP,
                    PetBProperty.LIFE
                };
                PetBPropKeyListDic.Add(1, list);
                List<int> list2 = new List<int> {
                    PetBProperty.HP,
                    PetBProperty.MP,
                    //PetBProperty.PHYSICAL_ATTACK,
                    PetBProperty.PHYSICAL_ARMOR,
                    //PetBProperty.PHYSICAL_HIT,
                    PetBProperty.PHYSICAL_DODGY,
                    //PetBProperty.PHYSICAL_CRIT,
                    PetBProperty.PHYSICAL_ANTICRIT,
                    PetBProperty.MAGIC_ATTACK,
                    PetBProperty.MAGIC_ARMOR,
                    PetBProperty.MAGIC_HIT,
                    PetBProperty.MAGIC_DODGY,
                    PetBProperty.MAGIC_CRIT,
                    PetBProperty.MAGIC_ANTICRIT,
                    PetBProperty.SPEED,
                    //PetBProperty.SP,
                    PetBProperty.LIFE
                };
                PetBPropKeyListDic.Add(2, list2);
            }
            List<int> petBPropKeyList;
            PetBPropKeyListDic.TryGetValue(jobtype, out petBPropKeyList);
            return petBPropKeyList;
        }

        /// <summary>
        /// (六个)二级属性的显示顺序，key为职业，列表为该职业要显示的二级属性
        /// </summary>
        public static Dictionary<int, List<int>> PetBSmallPropKeyListDic;
        /// <summary>
        /// (六个)根据职业获取，二级属性的显示顺序，key为职业，列表为该职业要显示的二级属性
        /// </summary>
        public static List<int> GetPetBSmallPropKeyListByJobType(int jobtype)
        {
            if (PetBSmallPropKeyListDic == null)
            {
                PetBSmallPropKeyListDic = new Dictionary<int, List<int>>();
                List<int> list = new List<int> {
                    PetBProperty.HP,
                   // RoleBaseIntProperties.LIFE,
                   PetBProperty.LIFE,
                    PetBProperty.PHYSICAL_ATTACK,
                    PetBProperty.PHYSICAL_ARMOR,
                    //PetBProperty.PHYSICAL_HIT,
                    //PetBProperty.PHYSICAL_DODGY,
                    //PetBProperty.PHYSICAL_CRIT,
                    //PetBProperty.PHYSICAL_ANTICRIT,
                    //PetBProperty.MAGIC_ATTACK,
                    PetBProperty.MAGIC_ARMOR,
                    //PetBProperty.MAGIC_HIT,
                    //PetBProperty.MAGIC_DODGY,
                    //PetBProperty.MAGIC_CRIT,
                    //PetBProperty.MAGIC_ANTICRIT,
                    PetBProperty.SPEED,
                    //PetBProperty.SP,
                    //PetBProperty.XW
                };
                PetBSmallPropKeyListDic.Add(1, list);
                List<int> list2 = new List<int> {
                    PetBProperty.HP,
                   // RoleBaseIntProperties.LIFE,
                   PetBProperty.LIFE,
                    //PetBProperty.PHYSICAL_ATTACK,
                    PetBProperty.PHYSICAL_ARMOR,
                    //PetBProperty.PHYSICAL_HIT,
                    //PetBProperty.PHYSICAL_DODGY,
                    //PetBProperty.PHYSICAL_CRIT,
                    //PetBProperty.PHYSICAL_ANTICRIT,
                    PetBProperty.MAGIC_ATTACK,
                    PetBProperty.MAGIC_ARMOR,
                    //PetBProperty.MAGIC_HIT,
                    //PetBProperty.MAGIC_DODGY,
                    //PetBProperty.MAGIC_CRIT,
                    //PetBProperty.MAGIC_ANTICRIT,
                    PetBProperty.SPEED,
                    //PetBProperty.SP,
                    //PetBProperty.XW
                };
                PetBSmallPropKeyListDic.Add(2, list2);

            }
            List<int> petBPropKeyList;
            PetBSmallPropKeyListDic.TryGetValue(jobtype, out petBPropKeyList);
            return petBPropKeyList;
        }

        private static Dictionary<int,Vector3> roleModelRotation;
        /// <summary>
        /// 获得八个主角的旋转角度
        /// </summary>
        /// <param name="roleTplId"></param>
        /// <returns></returns>
        public static Vector3 GetRoleModelRotation(int roleTplId)
        {
            if (roleModelRotation==null)
            {
                roleModelRotation = new Dictionary<int, Vector3>();
                roleModelRotation.Add(1001,new Vector3(5,162,358));
                roleModelRotation.Add(1002,new Vector3(5,165,358));
                roleModelRotation.Add(1003,new Vector3(0,160,0));
                roleModelRotation.Add(1004,new Vector3(5,165,358));
                roleModelRotation.Add(1005,new Vector3(5,168,358));
                roleModelRotation.Add(1006,new Vector3(7,163,358));
                roleModelRotation.Add(1007,new Vector3(0,160,1));
                roleModelRotation.Add(1008,new Vector3(0,151,0));
                //nv xia ke  5 162 358   1
                //nanxiake   5 165 358  0.95
                //nvcike     0 160 0     1
                //nancike    5 165 358   1
                //nvshushi   5 168 358   1
                //nanshushi  7 163 358  0.95 
                //nvxiuzhen  0 160 1     1
                //nanxiuzhen 0 151 0    0.9
            }
            if (roleModelRotation.ContainsKey(roleTplId))
            {
                return roleModelRotation[roleTplId];
            }
            return Vector3.zero;
        }
    }

    /// <summary>
    /// 角色类型。
    /// </summary>
    public enum PetType
    {
        NONE,
        /// <summary>
        /// 主将(1)。
        /// </summary>
        LEADER,

        /// <summary>
        /// 宠物(2)。
        /// </summary>
        PET,

        /// <summary>
        /// 伙伴(3)。
        /// </summary>
        FRIEND,

        /// <summary>
        /// 怪物(4)。
        /// </summary>
        MONSTER,
        
        /// <summary>
        /// 骑宠(5)。
        /// </summary>
        PET_FOR_RIDE
    }

    public enum PetQuality
    {
        /// <summary>
        /// 无。
        /// </summary>
        NONE,
        /// <summary>
        /// 普通。
        /// </summary>
        PUTONG,
        /// <summary>
        /// 优秀。
        /// </summary>
        YOUXIU,
        /// <summary>
        /// 杰出。
        /// </summary>
        JIECHU,
        /// <summary>
        /// 卓越。
        /// </summary>
        ZHUOYUE,
        /// <summary>
        /// 完美。
        /// </summary>
        WANMEI,
        /// <summary>
        /// 超凡。
        /// </summary>
        CHAOFAN

    }

    public class PetJobType
    {
        public const int NONE = 0;
        /** 侠客 */
        public const int XIAKE = 1;
        /** 刺客 */
        public const int CIKE = 2;
        /** 术士 */
        public const int SHUSHI = 4;
        /** 修真 */
        public const int XIUZHEN = 8;
        
        public const int ALL = 999;

        public static string GetJobName(int job)
        {
            switch (job)
            {
                case XIAKE:
                    return LangConstant.XIA_KE;
                case CIKE:
                    return LangConstant.CI_KE;
                case SHUSHI:
                    return LangConstant.SHU_SHI;
                case XIUZHEN:
                    return LangConstant.XIU_ZHEN;
            }
            return "";
        }

        public static string GetJobIconName(int jobid)
        {
            string jobImgName = "";
            switch (jobid)
            {
                case PetJobType.XIAKE:
                    jobImgName = "xiake";
                    break;
                case PetJobType.CIKE:
                    jobImgName = "cike";
                    break;
                case PetJobType.SHUSHI:
                    jobImgName = "shushi";
                    break;
                case PetJobType.XIUZHEN:
                    jobImgName = "xiuzhen";
                    break;
            }
            return jobImgName;
        }

        public static string GetJobNameByRoleTplId(int roleTplId)
        {
            PetTemplate pt = PetTemplateDB.Instance.getTemplate(roleTplId);
            if (pt!=null)
            {
                return GetJobName(pt.jobId);
            }
            return "";
        }
        /// <summary>
        /// 检查是否包含自己的职业
        /// </summary>
        /// <param name="jobs"></param>
        /// <param name="myjob"></param>
        /// <returns></returns>
        public static bool ContainJob(int jobs, int myjob)
        {
            return ((myjob & jobs) == myjob) ? true : false;
        }
        
        public static string GetJobLimitDesc(int job, int sex)
        {
            string totalStr = "";
            string sexname = "";
            if (PetSexType.ContainSex(sex, PetSexType.NAN) && PetSexType.ContainSex(sex, PetSexType.NV))
            {
                sexname = "";
                if (ContainJob(job, PetJobType.XIAKE) && ContainJob(job, PetJobType.CIKE) &&
                    ContainJob(job, PetJobType.SHUSHI) && ContainJob(job, PetJobType.XIUZHEN))
                {
                    return "通用";
                }
            }
            else
            {
                if (PetSexType.ContainSex(sex, PetSexType.NAN))
                {
                    sexname = PetSexType.GetSexName(PetSexType.NAN);
                }
                else if (PetSexType.ContainSex(sex, PetSexType.NV))
                {
                    sexname = PetSexType.GetSexName(PetSexType.NV);
                }
            }
            if (ContainJob(job, PetJobType.XIAKE))
            {
                totalStr += sexname + GetJobName(PetJobType.XIAKE) + "  ";
            }
            if (ContainJob(job, PetJobType.CIKE))
            {
                totalStr += sexname + GetJobName(PetJobType.CIKE) + "  ";
            }
            if (ContainJob(job, PetJobType.SHUSHI))
            {
                totalStr += sexname + GetJobName(PetJobType.SHUSHI) + "  ";
            }
            if (ContainJob(job, PetJobType.XIUZHEN))
            {
                totalStr += sexname + GetJobName(PetJobType.XIUZHEN) + "  ";
            }
            return totalStr;
        }
    }

    public class PetSexType
    {
        public const int NV = 1;
        public const int NAN = 2;

        public static string GetSexName(int sex)
        {
            string str;
            switch (sex)
            {
                case NV:
                    str = "女";
                    break;
                case NAN:
                    str = "男";
                    break;
                default:
                    str = "";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 检查是否包含自己的性别
        /// </summary>
        /// <param name="jobs"></param>
        /// <param name="myjob"></param>
        /// <returns></returns>
        public static bool ContainSex(int sexs, int mysex)
        {
            return ((mysex & sexs) == mysex) ? true : false;
        }
    }
}
